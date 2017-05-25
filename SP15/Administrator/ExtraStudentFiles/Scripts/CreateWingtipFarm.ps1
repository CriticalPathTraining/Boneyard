cls
# assumptions for running this script
# -----------------------------------------------------------------------------------------
#  1. Computer name is wingtipserver
#  2. Computer is AD domain controller within domain wingtip.com
#  3. SQL Server 2013 WEnterprise is already installed as local default instance
#  4. You are creating a SharePoint farm on a single server (not a multi-server farm)
#  5. SharePoint Prerequisites and SharePoint Server 2013 have alread been installed
#  6. The VM has network adapter named 'Internal' with static IP addresses of 192.168.150.1
#  7. The VM has been configured to disable User Access Control (UAC) features of Windows OS
# -----------------------------------------------------------------------------------------

function Configure-IPAddresesForFarm {
    $netadapter = Get-NetAdapter | Where-Object { $_.Name -like "*internal*" } 
    $netadapter | New-NetIPAddress -IPAddress 192.168.150.2 -PrefixLength 24 | Out-Null
    $netadapter | New-NetIPAddress -IPAddress 192.168.150.3 -PrefixLength 24 | Out-Null 
    $netadapter | New-NetIPAddress -IPAddress 192.168.150.4 -PrefixLength 24 | Out-Null
    $netadapter | New-NetIPAddress -IPAddress 192.168.150.5 -PrefixLength 24 | Out-Null 
}

function Disable-LoopbackChecks{

	# Disabling internal loopback
	Write-Host "Disabling internal loopback check for accessing host header sites"
	$regPath = "HKLM:\System\CurrentControlSet\Control\Lsa"
	$key = "DisableLoopbackCheck"
	if(test-path $regPath)	{
		$keyValue = (Get-ItemProperty $regpath).$key
		if($keyValue -ne $null){
			Set-ItemProperty -path $regPath -name $key -value "1"
		}
		else{
			$loopback = New-ItemProperty $regPath -Name $key -value "1" -PropertyType dword
		}
	}
	else{
		$loopback = New-ItemProperty $regPath -Name $key -value "1" -PropertyType dword
	}
    Write-Host
}

function New-DnsARecord($dnsName, $ipAddress) {
    Write-Host " - creating DNS A record for [$dnsName] with IP address of [$ipAddress]"
    # create WMI object to create DNS A Record
    $rec = [WmiClass]"\\wingtipserver\root\MicrosoftDNS:MicrosoftDNS_ResourceRecord"  
    $text = "$dnsName IN A $ipAddress"  
    $rec.CreateInstanceFromTextRepresentation("wingtipserver.wingtip.com", "wingtip.com", $text)  | Out-Null
} 

function Create-WingtipDnsRecords(){

    Write-Host "Creating DNS records required for sites in farm"
    New-DnsARecord -dnsName '*.wingtip.com' -ipAddress 192.168.150.1
    New-DnsARecord -dnsName 'intranet.wingtip.com' -ipAddress 192.168.150.2
    New-DnsARecord -dnsName 'extranet.wingtip.com' -ipAddress 192.168.150.3
    New-DnsARecord -dnsName 'my.wingtip.com' -ipAddress 192.168.150.4
    New-DnsARecord -dnsName 'appserver.wingtip.com' -ipAddress 192.168.150.5

    Write-Host
}

function Add-TrustedSiteToInternetExplorer{
    # remember currentl location
    $loc = Get-Location
    
    # add registrty entries for IE trusted sites
    Set-Location "HKCU:\Software\Microsoft\Windows\CurrentVersion\Internet Settings"
    Set-Location ZoneMap\Domains 
    New-Item *.wingtip.com | Out-Null
    Set-Location *.wingtip.com
    New-ItemProperty . -Name http -Value 1 -Type DWORD  | Out-Null
    New-ItemProperty . -Name https -Value 1 -Type DWORD  | Out-Null

    # return to original location
    Set-Location $loc
}

function Create-InternetExplorerShortcut($targetUrl, $caption){

     # make sure folders exist
    $favoritesRoot = Join-Path -Path $HOME -ChildPath "Favorites/Links"
    if (Test-Path -Path $favoritesRoot){} else { New-Item -Path $favoritesRoot -ItemType Directory | Out-Null }

    $shortcutPath = [string]::Format("{0}.url", $caption)
    $shortcutPath = Join-Path -Path $favoritesRoot -ChildPath $shortcutPath

    # create file
    if (Test-Path -Path $shortcutPath) {} else {
        New-Item -Path $shortcutPath -ItemType File | Out-Null

        # create file contents
        $shortcutConents = @()
        $shortcutConents += "[DEFAULT]"
        $shortcutConents += [string]::Format("BASEURL={0}", $targetUrl)
        $shortcutConents += "[InternetShortcut]"
        $shortcutConents += [string]::Format("URL={0}", $targetUrl)
        $shortcutConents += [string]::Format("IconFile={0}/_layouts/15/images/favicon.ico?rev=23", $targetUrl)
        $shortcutConents += "IconIndex=1"

        $shortcutConents | ForEach-Object {
          Add-Content -Path $shortcutPath -Value $_
        }

    }
}

function Create-SslTestCertificate($domain){

    $makecert = "C:\Program Files\Microsoft Office Servers\15.0\Tools\makecert.exe"
    $certmgr = "C:\Program Files\Microsoft Office Servers\15.0\Tools\certmgr.exe"

    # specify domain name for SSL certificate
    Write-Host "Creating and configuring SSL certificate for subject $domain"

    # create output directory to create SSL certificate file
    $outputDirectory = "c:\SslCertificates\"
    New-Item $outputDirectory -ItemType Directory -Force -Confirm:$false | Out-Null

    # create file name for SSL certificate file
    $certFileName  =  $outputDirectory + ($domain.Replace("*", "Wildcard")) + ".cer"

    & $makecert -r -pe -n "CN=$domain" -b 01/01/2012 -e 01/01/2022 -eku 1.3.6.1.5.5.7.3.1 -ss my -sr localMachine -sky exchange -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12 $certFileName | Out-Null

    & $certmgr /add $certFileName /s /r localMachine root | Out-Null
}

function Create-WingtipSslTestCertificates{
    Create-SslTestCertificate "extranet.wingtip.com"
    Create-SslTestCertificate "appserver.wingtip.com"
    Create-SslTestCertificate "*.wingtip.com"
    Write-Host
}

function Create-SharePointServiceAccounts{

    Write-Host "Creating Wingtip service accounts in Active Directory"

    # import module with ActiveDirectory cmdlets
    Write-Host " - loading PowerShell module with Active Directory cmdlets"
    Import-Module ActiveDirectory
   
    $WingtipDomain = "DC=wingtip,DC=com"
    $ouWingtipServiceAccountsName = "Wingtip Service Accounts"
    $ouWingtipServiceAccountsPath = "OU={0},{1}" -f $ouWingtipServiceAccountsName, $WingtipDomain
    $ouWingtipServiceAccounts = Get-ADOrganizationalUnit -Filter { name -eq $ouWingtipServiceAccountsName}

    if($ouWingtipServiceAccounts -ne $null){
        Write-Host ("The Organization Unit {0} has already been created" -f $ouWingtipServiceAccountsName)
    }

    Write-Host (" - creating {0} Organization Unit" -f $ouWingtipServiceAccountsName)
    New-ADOrganizationalUnit -Name $ouWingtipServiceAccountsName -Path $WingtipDomain -ProtectedFromAccidentalDeletion $false 

    $UserPassword = ConvertTo-SecureString -AsPlainText "Password1" -Force

    # create farm service account 
    $UserName = "SP_Farm"
    Write-Host (" - adding User: {0}" -f $UserName)
    New-ADUser -Path $ouWingtipServiceAccountsPath -SamAccountName $UserName -Name $UserName -DisplayName $UserName -AccountPassword $UserPassword -Enabled $true -ChangePasswordAtLogon $false -PasswordNeverExpires $true
    
    # adding sp_farm account to local Administrators group to configure User Profile Synchronoization
    # this account should be removed from Administrators group after farm has been built
    $user_farm = Get-ADUser -Filter "samAccountName -eq 'SP_Farm'"
    Add-ADGroupMember -Identity "Administrators" -Members $user_farm


    # create service app service account 
    $UserName = "SP_Services"
    Write-Host (" - adding User: {0}" -f $UserName)
    New-ADUser -Path $ouWingtipServiceAccountsPath -SamAccountName $UserName -Name $UserName -DisplayName $UserName -AccountPassword $UserPassword -Enabled $true -ChangePasswordAtLogon $false -PasswordNeverExpires $true

    # create web app service account 
    $UserName = "SP_Content"
    Write-Host (" - adding User: {0}" -f $UserName)
    # this account must be added to AD group named 'Performance Log Users' in order for ULS logging to work correctly
    New-ADUser -Path $ouWingtipServiceAccountsPath -SamAccountName $UserName -Name $UserName -DisplayName $UserName -AccountPassword $UserPassword -Enabled $true -ChangePasswordAtLogon $false -PasswordNeverExpires $true

    # add SP_Content to Performance Log Users group so it can write to ULS logs
    $user_content = Get-ADUser -Filter "samAccountName -eq 'SP_Content'"
    Add-ADGroupMember -Identity "Performance Log Users" -Members $user_content


    # create user profile synchronization account 
    $UserName = "SP_UPS"
    Write-Host (" - adding User: {0}" -f $UserName)
    New-ADUser -Path $ouWingtipServiceAccountsPath -SamAccountName $UserName -Name $UserName -DisplayName $UserName -AccountPassword $UserPassword -Enabled $true -ChangePasswordAtLogon $false -PasswordNeverExpires $true

    # create search crawler account 
    $UserName = "SP_Crawler"
    Write-Host (" - adding User: {0}" -f $UserName)
    New-ADUser -Path $ouWingtipServiceAccountsPath -SamAccountName $UserName -Name $UserName -DisplayName $UserName -AccountPassword $UserPassword -Enabled $true -ChangePasswordAtLogon $false -PasswordNeverExpires $true

    # create workflow manager service account 
    $UserName = "SP_Workflow"
    Write-Host (" - adding User: {0}" -f $UserName)
    New-ADUser -Path $ouWingtipServiceAccountsPath -SamAccountName $UserName -Name $UserName -DisplayName $UserName -AccountPassword $UserPassword -Enabled $true -ChangePasswordAtLogon $false -PasswordNeverExpires $true

    # adding sp_workflow account to local Administrators group
    $user_workflow = Get-ADUser -Filter "samAccountName -eq 'SP_Workflow'"
    Add-ADGroupMember -Identity "Administrators" -Members $user_workflow


     Write-Host 
}

function Create-NewWingtipFarm{

    Write-Host "Creaing a new farm by calling New-SPConfigurationDatabase..."
    New-SPConfigurationDatabase `
        -DatabaseServer $server `
        -DatabaseName $configDb `
        -AdministrationContentDatabaseName $centralAdminContentDB `
        -FarmCredentials $farmAccount `
        -Passphrase $farmPassphrase | Out-Null
    
    #Verifying farm creation
    $spfarm = Get-SPFarm -ErrorAction SilentlyContinue
    if ($spfarm -eq $null) {
      throw "Unable to verify farm creation."
    }

    Write-Host "Configuration database successfully created"
    Write-Host

    # set permissions on system resourced used by SharePoint
    Write-Host "running Initialize-SPResourceSecurity..."
    Initialize-SPResourceSecurity

    # install services for customized build out of service application instances
    Write-Host "running Install-SPService..."
    Install-SPService
        
    # install all SharePoint Server 2013 Features
    Write-Host "running Install-SPFeature -AllExistingFeatures..."
    Install-SPFeature -AllExistingFeatures | Out-Null

    #Provisioning Central Administration
    Write-Host "running New-SPCentralAdministration -Port '9999' -WindowsAuthProvider 'NTLM'.."
    New-SPCentralAdministration -Port "9999" -WindowsAuthProvider "NTLM"
       
    #Installing Help
    Write-Host "running Install-SPHelpCollection -All..."
    Install-SPHelpCollection -All

    #Installing Application Content
    Write-Host "running Install-SPApplicationContent..."
    Install-SPApplicationContent

    Write-Host "The new farm has been successfully created and initialized"
    Write-Host 

}

function Create-ManagedAccounts{

    Write-Host 
    Write-Host "Creating managed account for WINGTIP\SP_Services"
    $servicesAccountName = "WINGTIP\SP_Services"
    $servicesAccountPassword = "Password1"
    $servicesAccountecureStringPassword = ConvertTo-SecureString -String $servicesAccountPassword -AsPlainText -Force
    $credential_services = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $servicesAccountName, $servicesAccountecureStringPassword 
    New-SPManagedAccount -Credential $credential_services | Out-Null

    Write-Host "Creating managed account for WINGTIP\SP_Content"
    $contentAccountName = "WINGTIP\SP_Content"
    $contentAccountPassword = "Password1"
    $contentAccountecureStringPassword = ConvertTo-SecureString -String $contentAccountPassword -AsPlainText -Force
    $credential_content = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $contentAccountName, $contentAccountecureStringPassword 
    New-SPManagedAccount -Credential $credential_content | Out-Null
    Write-Host
}

function Get-ServiceApplicationPoolName{
    $applicationPoolName = "SharePoint Web Services Default"    
    $applicationPool = Get-SPServiceApplicationPool -Identity $applicationPoolName -ErrorAction SilentlyContinue
    if (!$applicationPool) {
        Write-Host "Creating service application pool for all Wingtip service applications"
        $serviceAppPoolAccountName = "WINGTIP\SP_Services"
        $applicationPool = New-SPServiceApplicationPool -Name $applicationPoolName -Account $serviceAppPoolAccountName 
    }
    return $applicationPool.Name
}

function Grant-ServiceApplicationPermission($app, $user, $permission, $admin){
    
    $sec = $app | Get-SPServiceApplicationSecurity -Admin:$admin
    $claim = New-SPClaimsPrincipal -Identity $user -IdentityType WindowsSamAccountName
    $sec | Grant-SPObjectSecurity -Principal $claim -Rights $permission
    $app | Set-SPServiceApplicationSecurity -ObjectSecurity $sec -Admin:$admin

}

function Create-HealthUsageApplication{

    # in production the log files should be kept on drive other than c:\ drive
    $logFileLocation = "C:\SharePoinUsageLogs"
    $maxSpaceAllocatedToLogFiles = 20
    $minutesToStartNewLogFile = 10
    
    # configure the Usage Service
    Write-Host "Configuring the Usage and Health Data Collection Service Application..."
    $svc = Get-SPUsageService -ErrorAction SilentlyContinue
    if ($svc -eq $null) {
        throw "Unable to retrieve SharePoint Usage Service."
    }
    Set-SPUsageService -Identity $svc `
	      -UsageLogMaxSpaceGB $maxSpaceAllocatedToLogFiles `
	      -UsageLogLocation $logFileLocation `
	      -UsageLogCutTime $minutesToStartNewLogFile `
	      -LoggingEnabled:$true


    Write-Host "Creating the Usage and Health Data Collection Service Application..."
    $appName = "Usage and Health Data Collection Service Application"
    $databaseName = "SharePoint_UsageDB"
    $databaseServer = "WINGTIPSERVER"
    $app = Get-SPUsageApplication $appName
    if ($app -eq $null) {
        $svc = Get-SPUsageService
        $app = $svc | New-SPUsageApplication -Name $appName -DatabaseName $databaseName -DatabaseServer $databaseServer

        Write-Host "Starting up the Usage and Health Data Collection Service Application Proxy..."
        $proxy = Get-SPServiceApplicationProxy | Where-Object {$_.Typename -like '*Usage*'}
        $proxy.Provision()
    }

    $daysToKeepTraceLogFile = 7
    $maxSpaceAllocateToTraceLogFile = 200

    Set-SPDiagnosticConfig `
        -DaysToKeepLogs $daysToKeepTraceLogFile `
        -LogDiskSpaceUsageGB $maxSpaceAllocateToTraceLogFile `
        -LogLocation $logFileLocation

    # configure usage definitions - currently set to default values
    Set-SPUsageDefinition -Identity "Analytics Usage" -Enable -DaysRetained 14 -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "App Monitoring" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "App Statistics." -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Bandwidth Monitoring" -Enable:$false -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Content Export Usage" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Content Import Usage" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Definition of usage fields for Education telemetry" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Definition of usage fields for service calls" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Definition of usage fields for SPDistributedCache calls" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Definition of usage fields for workflow telemetry" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Feature Use" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "File IO" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Page Requests" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "REST and Client API Action Usage" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "REST and Client API Request Usage" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Sandbox Request Resource Measures" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Sandbox Requests" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "SQL Exceptions Usage" -Enable:$false -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "SQL IO Usage" -Enable:$false -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "SQL Latency Usage" -Enable:$false -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Task Use" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Tenant Logging" -Enable:$false -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "Timer Jobs" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue
    Set-SPUsageDefinition -Identity "User Profile ActiveDirectory Import Usage" -Enable -DaysRetained 14  -ErrorAction SilentlyContinue


}

function Create-StateServiceApplication{

    $stateServiceDBName = “SharePoint_StateServiceDB”
    $stateServiceDB = Get-SPStateServiceDatabase stateServiceDBName
    if ($stateServiceDB -eq $null) {
        Write-Host "Creating and initializing state service database..."
        $stateServiceDB = New-SPStateServiceDatabase -Name $stateServiceDBName `
                                                     -DatabaseServer "WingtipServer" `
                                                     -Weight 1

        $stateServiceDB | Initialize-SPStateServiceDatabase
    }

    $stateServiceAppName = “State Service”
    $stateServiceApp = Get-SPStateServiceApplication $stateServiceAppName

    if ($stateServiceApp -eq $null) {
    Write-Host "Creating state service application..."
    $stateServiceApp = New-SPStateServiceApplication -Name $stateServiceAppName `
                                                     -Database $stateServiceDB
    }

    $stateServiceAppProxyName = "State Service Proxy"
    $stateServiceAppProxy = Get-SPStateServiceApplicationProxy $stateServiceAppProxyName
    if ($stateServiceAppProxy -eq $null) {
        Write-Host "Creating state service application proxy..."
        $stateServiceAppProxy = New-SPStateServiceApplicationProxy `
                                    -ServiceApplication $stateServiceApp `
                                    -Name $stateServiceAppProxyName `
                                    -DefaultProxyGroup
    }
}

function Start-ClaimsToWindowsTokenService{
    
    $claimsToWindowsTokenService = Get-SPServiceInstance | where {$_.TypeName -eq “Claims to Windows Token Service”}

    # start Claims to Windows Token Service if it is not started
    if($claimsToWindowsTokenService.Status -ne “Online”) {
       Write-Host "Starting the Claims to Windows Token Service"
       $claimsToWindowsTokenService | Start-SPServiceInstance | Out-Null
    }

    # If needed, configure service identity to run as account other than local SYSTEM account
    # Set-ServiceIdentity $claimsToWindowsTokenService "WINGTIP\SP_Farm"
}

function Start-UserCodeService{

    $serviceUserCode = Get-SPServiceInstance | where {$_.TypeName -eq “Microsoft SharePoint Foundation Sandboxed Code Service”}

    if ($serviceUserCode.Status -ne “Online”) {
        Write-Host "Starting the User Code Service"
        $serviceUserCode | Start-SPServiceInstance | Out-Null
    }

}

function Create-SecureStoreServiceApplication{

    $secureStoreService = Get-SPServiceInstance | where {$_.TypeName -eq “Secure Store Service”}
    if ($secureStoreService.Status -ne “Online”) {
      Write-Host "Starting the Secure Store Service..."
      $secureStoreService | Start-SPServiceInstance | Out-Null
    }

    $secureStoreServiceApplicationName = “Secure Store Services Service Application”
    $secureStoreServiceApplication = Get-SPServiceApplication | where {$_.Name -eq $secureStoreServiceApplicationName}
    if($secureStoreServiceApplication -eq $null) {
        Write-Host "Creating the Secure Store Service Application..."
        $secureStoreServiceApplication = New-SPSecureStoreServiceApplication `
                                            -Name $secureStoreServiceApplicationName `
                                            -DatabaseName “SharePoint_SecureStoreDB” `
                                            -DatabaseServer “WINGTIPSERVER” `
                                            -ApplicationPool $serviceAppPoolName `
                                            -AuditingEnabled:$false
    }

    $secureStoreServiceApplicationProxyName = "Secure Store Services Service Application Proxy"
    $secureStoreServiceApplicationProxy = Get-SPServiceApplicationProxy | where { $_.Name -eq $secureStoreServiceApplicationProxyName}
    if ($secureStoreServiceApplicationProxy -eq $null) {
        Write-Host "Creating the Secure Store Service Application Proxy..."
        $secureStoreServiceApplicationProxy = New-SPSecureStoreServiceApplicationProxy `
                                                -ServiceApplication $secureStoreServiceApplication `
                                                -Name $secureStoreServiceApplicationProxyName `
                                                -DefaultProxyGroup
    }
  
    # update and synchronize passphrase
    $secureStoreServiceApplicationPassphrase = "Password1"

    # take a pause to ensure proxy has been created and initialized
    Start-Sleep -Seconds 5

    Write-Host "Updating passphrase (e.g. master key) for Secure Store Service Application..."
    Update-SPSecureStoreMasterKey -ServiceApplicationProxy $secureStoreServiceApplicationProxy `
                                  -Passphrase $secureStoreServiceApplicationPassphrase
    
    Write-Host "Synchronizing passphrase for Secure Store Service Application..."
    while ($true) {
        # keep trying until Update-SPSecureStoreApplicationServerKey completes successfully
        try {
            Start-Sleep -Seconds 5
            Update-SPSecureStoreApplicationServerKey `
                -ServiceApplicationProxy $secureStoreServiceApplicationProxy `
                -Passphrase $secureStoreServiceApplicationPassphrase
            break
        }
        catch { }
    }
}

function Create-ExcelServicesApplication{

    $service = Get-SPServiceInstance | where {$_.TypeName -eq "Excel Calculation Services"}
    if ($service.Status -ne “Online”) {
        Write-Host "Starting Excel Calculation Services..."
        $service | Start-SPServiceInstance | Out-Null
    }

    $serviceApplicationName = "Excel Calculation Services Application"
    $serviceApplication = Get-SPExcelServiceApplication

    if($serviceApplication -eq $null) {
        Write-Host "Creating the Excel Calculation Services Application..."
        $serviceApplication = New-SPExcelServiceApplication `
				                    -Name $serviceApplicationName `
				                    -ApplicationPool $serviceAppPoolName `
				                    -ExternalDataConnectionLifetime 1800 `
				                    -LoadBalancingScheme "WorkbookUrl" `
				                    -SessionsPerUserMax 25 `
				                    -PrivateBytesMax -1 `
				                    -MemoryCacheThreshold 90 `
				                    -UnusedObjectAgeMax -1 `
				                    -ThrottleAccessViolationsPerSiteCollection 0 `
				                    -SiteCollectionAnonymousSessionsMax 25 `
				                    -WorkbookCache $appConfig.WorkbookCache `
				                    -WorkbookCacheSizeMax 40960 `
				                    -CachingOfUnusedFilesEnable:$true `
				                    -FileAccessMethod UseImpersonation `
				                    -EncryptedUserConnectionRequired None `
				                    -CrossDomainAccessAllowed:$false `
				                    -TerminateProcessOnAccessViolation:$false `
				                    -Default:$true
    
        # UNATTENDED EXECUTION ACCOUNT
    }

}

function Create-WordAutomationServicesApplication {
	
	$wordAutomationServices = Get-SPServiceInstance | where {$_.TypeName -eq "Word Automation Services"}
	
	if ($wordAutomationServices.Status -ne "Online") {
		Write-Host "Starting Word Automation Services instance..."
		$wordAutomationServices | Start-SPServiceInstance | Out-Null
	}

    $wordAutomationServicesApplicationName = "Word Automation Services Application"
	$wordAutomationServicesApplication = Get-SPServiceApplication | where {$_.Name -eq $wordAutomationServicesApplicationName}
    if ($wordAutomationServicesApplication -eq $null) {
	    Write-Host "Creating Word Automation Services Application..."
		$wordAutomationServicesApplication = New-SPWordConversionServiceApplication `
                                                    -Name $wordAutomationServicesApplicationName `
				                                    -DatabaseName "SharePoint_WordAutomationServicesDB" `
				                                    -DatabaseServer "WingtipServer" `
				                                    -ApplicationPool $serviceAppPoolName `
                                                    -Default 
	                                                

		Write-Host "Setting Word Automation Serices Settings..."
		Set-SPWordConversionServiceApplication -Identity $wordAutomationServicesApplication `
			-TimerJobFrequency 15 `
			-MaximumConversionAttempts 5 `
			-KeepAliveTimeout 30 `
			-ConversionsPerInstance 12 `
			-DisableEmbeddedFonts:$false `
			-DisableBinaryFileScan:$false `
			-RecycleProcessThreshold 100 `
			-ActiveProcesses 8 `
			-MaximumMemoryUsage 100


	}
}

function Create-PowerPointConversionServiceApplication {
	
	$powerPointConversionService = Get-SPServiceInstance | where {$_.TypeName -eq "PowerPoint Conversion Service"}
	
	if ($powerPointConversionService.Status -ne "Online") {
		Write-Host "Starting PowerPoint Conversion Service instance..."
		$powerPointConversionService | Start-SPServiceInstance | Out-Null
	}

    $powerPointConversionServiceApplicationName = "PowerPoint Conversion Service Application"
	$powerPointConversionServiceApplication= Get-SPServiceApplication | where {$_.Name -eq $powerPointConversionServiceApplicationName}
    if ($powerPointConversionServiceApplication -eq $null) {
	    Write-Host "Creating PowerPoint Conversion Service Application..."
		$powerPointConversionServiceApplication = New-SPPowerPointConversionServiceApplication `
                                                      -Name $powerPointConversionServiceApplicationName `
                                                      -ApplicationPool $serviceAppPoolName `

	    Write-Host "Creating PowerPoint Conversion Service Application Proxy..."
        $powerPointConversionServiceApplicationProxyName = "PowerPoint Conversion Service Application Proxy"
		$powerPointConversionServiceApplicationProxy = New-SPPowerPointConversionServiceApplicationProxy `
                                                           -Name $powerPointConversionServiceApplicationProxyName `
                                                           -ServiceApplication $powerPointConversionServiceApplication
	                                                

		Write-Host "Setting PowerPoint Conversion Service Settings..."
		Set-SPPowerPointConversionServiceApplication `
            -Identity $powerPointConversionServiceApplication `
            -CacheExpirationPeriodInSeconds 600 `
             -MaximumConversionsPerWorker 5 `
             -WorkerKeepAliveTimeoutInSeconds 120 `
             -WorkerProcessCount 3 `
             -WorkerTimeoutInSeconds 300 

	}
}

function Create-VisioGraphicsServiceApplication {

    $visioGraphicsService= Get-SPServiceInstance | where {$_.TypeName -eq "Visio Graphics Service"}
	if ($visioGraphicsService.Status -ne "Online") {
		Write-Host "Starting Visio Graphics Service instance..."
		$visioGraphicsService | Start-SPServiceInstance | Out-Null
	}

    $visioGraphicsServiceApplicationName = "Visio Graphics Service Application"
    $visioGraphicsServiceApplication = Get-SPVisioServiceApplication

    if ($visioGraphicsServiceApplication -eq $null) {
        Write-Host "Creating Visio Graphics Service Application..."
	    $visioGraphicsServiceApplication = New-SPVisioServiceApplication -Name $visioGraphicsServiceApplicationName -ApplicationPool $serviceAppPoolName


        Write-Host "Creating Visio Graphics Service Application Proxy..."
        $visioGraphicsServiceApplicationProxyName = "Visio Graphics Service Application Proxy"
        $visioGraphicsServiceApplicationProxy = New-SPVisioServiceApplicationProxy -Name $visioGraphicsServiceApplicationProxyName -ServiceApplication $visioGraphicsServiceApplicationName
		
        Write-Host "Setting Visio Graphics Service Application Settings..."
		Set-SPVisioPerformance -VisioServiceApplication $visioGraphicsServiceApplication -MaxRecalcDuration 60 -MaxDiagramCacheAge 60 -MaxDiagramSize 5 -MinDiagramCacheAge 5 -MaxCacheSize 512
		

		# $unattendedServiceAccount = Get-Credential "WINGTIP\Administrator"
		#$appId = "$($app.ID)-VisioUnattendedAccount"
		#$fName = "Visio Services Unattended Account Target App"
		#$appId = New-SSTargetApp $app $appId $fName $uAcct
		#$app | Set-SPVisioExternalData -UnattendedServiceAccountApplicationID $appId	

    }

}

function Create-BCSApplication{

    $service = Get-SPServiceInstance | where {$_.TypeName -eq "Business Data Connectivity Service"}
    if ($service.Status -ne "Online") {
        Write-Host "Starting Business Data Connectivity Service..."
        $service | Start-SPServiceInstance | Out-Null
    }

    $serviceApplicationName = “Business Connectivity Service Application”
    $serviceApplication = Get-SPServiceApplication | where {$_.Name -eq $serviceApplicationName}

    if($serviceApplication -eq $null) {
        Write-Host "Creating the Business Connectivity Service Application..."
        $serviceApplicationDB = "SharePoint_BusinessConnectivityServiceDB"
        $serviceApplication = New-SPBusinessDataCatalogServiceApplication `
                                  -Name $serviceApplicationName `
                                  -DatabaseServer "WINGTIPSERVER" `
                                  -DatabaseName $serviceApplicationDB `
                                  -ApplicationPool $serviceAppPoolName
 
    }
}

function Create-PerformancePointServiceApplication {

    $service = Get-SPServiceInstance | where {$_.TypeName -eq "PerformancePoint Service"}
    if ($service.Status -ne "Online") {
        Write-Host "Starting PerformancePoint Service..."
        $service | Start-SPServiceInstance | Out-Null
    }

    $serviceApplicationName = "PerformancePoint Service Application"
    $serviceApplication = Get-SPPerformancePointServiceApplication

    if($serviceApplication -eq $null) {
        Write-Host "Creating the PerformancePoint Service Application..."
        $serviceApplication = New-SPPerformancePointServiceApplication `
                                  -Name $serviceApplicationName `
                                  -DatabaseName "SharePoint_PerformancePointServiceDB" `
                                  -ApplicationPool $serviceAppPoolName 
    
        $serviceApplicationProxyName = "PerformancePoint Service Application Proxy"
        Write-Host "Creating the PerformancePoint Service Application Proxy..."
        $serviceApplicationProxy = New-SPPerformancePointServiceApplicationProxy `
                                       -Name $serviceApplicationName `
                                       -ServiceApplication $serviceApplication
    }

}

function Create-ManagedMetadataService{

    $service = Get-SPServiceInstance | where {$_.TypeName -eq "Managed Metadata Web Service"}
    if ($service.Status -ne "Online") {
        Write-Host "Starting Managed Metadata Service..."
        $service | Start-SPServiceInstance | Out-Null
    }

    $serviceApplicationName = "Managed Metadata Service Application"
    $serviceApplication = Get-SPServiceApplication | where {$_.Name -eq $serviceApplicationName}

    if($serviceApplication -eq $null) {
        Write-Host "Creating the Managed Metadata Service Application..."
        $serviceApplication = New-SPMetadataServiceApplication `
                                  -Name $serviceApplicationName `
                                  -ApplicationPool $serviceAppPoolName `
                                  -DatabaseName "SharePoint_ManagedMetadataTermStoreDB"
    
        $serviceApplicationProxyName = "Managed Metadata Service Application Proxy"
        Write-Host "Creating the Managed Metadata Service Application Proxy..."
        $serviceApplicationProxy = New-SPMetadataServiceApplicationProxy `
                                       -Name $serviceApplicationProxyName `
                                       -ServiceApplication $serviceApplication `
                                       -DefaultProxyGroup

                                       
        # configure proxy to automatically create new term set for managed navigation for each new publishing site
        $serviceApplicationProxy = Get-SPServiceApplicationProxy | Where-Object { $_.Name -eq $serviceApplicationProxyName}
        $serviceApplicationProxy.Properties.IsDefaultSiteCollectionTaxonomy = $true 
        $serviceApplicationProxy.Update()

        Grant-ServiceApplicationPermission $serviceApplication "WINGTIP\Administrator" "Full Control" $true
    }

}

function Create-AppManagementServiceApplication{

    $service = Get-SPServiceInstance | where {$_.TypeName -eq "App Management Service"}
    if ($service.Status -ne "Online") {
        Write-Host "Starting App Management Service..."
        $service | Start-SPServiceInstance | Out-Null
    }

    $serviceApplicationName = "App Management Service Application"
    $serviceApplication = Get-SPServiceApplication | where {$_.Name -eq $serviceApplicationName}

    if($serviceApplication -eq $null) {
        Write-Host "Creating the App Management Service Application..."
        $serviceApplication = New-SPAppManagementServiceApplication `
                                  -Name $serviceApplicationName `
                                  -ApplicationPool $serviceAppPoolName `
                                  -DatabaseName "SharePoint_AppManagementServiceDB"
    
        $serviceApplicationProxyName = "App Management Service Application Proxy"
        Write-Host "Creating the App Management Service Application Proxy..."
        $serviceApplicationProxy = New-SPAppManagementServiceApplicationProxy `
                                       -Name $serviceApplicationProxyName `
                                       -ServiceApplication $serviceApplication `
                                       -UseDefaultProxyGroup 
    }

}

function Create-SiteSubscriptionSettingsService{

    # assign root domain name to configure URL used to access app webs
    Set-SPAppDomain "apps.wingtip.com" –confirm:$false 

    $subscriptionSettingsService = Get-SPServiceInstance | where {$_.TypeName -like "Microsoft SharePoint Foundation Subscription Settings Service"}

    if($subscriptionSettingsService.Status -ne "Online") { 
        Write-Host "Starting Subscription Settings Service" 
        Start-SPServiceInstance $subscriptionSettingsService | Out-Null
    } 

    # wait for subscription service to start" 
    while ($service.Status -ne "Online") {
      # delay 5 seconds then check to see if service has started   sleep 5
      $service = Get-SPServiceInstance | where {$_.TypeName -like "Microsoft SharePoint Foundation Subscription Settings Service"}
    } 

    $subscriptionSettingsServiceApplicationName = "Site Subscription Settings Service Application"
    $subscriptionSettingsServiceApplication = Get-SPServiceApplication | where {$_.Name -eq $subscriptionSettingsServiceApplicationName} 

    # create an instance Subscription Service Application and proxy if they do not exist 
    if($subscriptionSettingsServiceApplication -eq $null) { 
      Write-Host "Creating Subscription Settings Service Application..." 
      $pool = Get-SPServiceApplicationPool "SharePoint Web Services Default" 
      $subscriptionSettingsServiceDB= "Sharepoint_SiteSubscriptionSettingsServiceDB"
      $subscriptionSettingsServiceApplication = New-SPSubscriptionSettingsServiceApplication `
                                                    -ApplicationPool $pool `
                                                    -Name $subscriptionSettingsServiceApplicationName `
                                                    -DatabaseName $subscriptionSettingsServiceDB 

      Write-Host "Creating Subscription Settings Service Application Proxy..." 
      $subscriptionSettingsServicApplicationProxy = New-SPSubscriptionSettingsServiceApplicationProxy `
                                                      -ServiceApplication $subscriptionSettingsServiceApplication

    }

    # assign name to default tenant to configure URL used to access web apps 
    Set-SPAppSiteSubscriptionName -Name "WingtipTenant" -Confirm:$false
}

function Create-SearchServiceApplication{

    Write-Host "Starting Enterprise Search Service Instance"
    Get-SPEnterpriseSearchServiceInstance -Local | Start-SPEnterpriseSearchServiceInstance;
    Get-SPEnterpriseSearchQueryAndSiteSettingsServiceInstance -Local | Start-SPEnterpriseSearchQueryAndSiteSettingsServiceInstance

    #Settings
    $indexLocation = "C:\SharePointSearch"  #Location must be empty, will be deleted during the process!
    $serviceAppPoolName = Get-ServiceApplicationPoolName

    $serviceApplicationName = "SharePoint Server Search Service Application"
    $serviceApplicationProxyName = "SharePoint Server Search Service Application Proxy"

    $databaseServer = "WINGTIPSERVER"
    $databaseName = "SharePoint_SearchServiceDB"
 
 
    $serviceApplication = Get-SPEnterpriseSearchServiceApplication -Identity $serviceApplicationName -ErrorAction SilentlyContinue
    if (!$serviceApplication) {
        Write-Host "Creating Search Service Application"
        $serviceApplication = New-SPEnterpriseSearchServiceApplication -Name $serviceApplicationName -ApplicationPool $serviceAppPoolName -DatabaseServer  $databaseServer -DatabaseName $databaseName

        Write-Host "Creating Search Service Application Proxy"
        New-SPEnterpriseSearchServiceApplicationProxy -Name $serviceApplicationProxyName -SearchApplication $serviceApplicationName | Out-Null
    }
 
 
    $searchInstance = Get-SPEnterpriseSearchServiceInstance -local 
    $initialSearchTopology = $serviceApplication | Get-SPEnterpriseSearchTopology -Active 
    $searchTopology = $serviceApplication | New-SPEnterpriseSearchTopology
 
    New-SPEnterpriseSearchAnalyticsProcessingComponent -SearchTopology $searchTopology -SearchServiceInstance $searchInstance | Out-Null
    New-SPEnterpriseSearchContentProcessingComponent -SearchTopology $searchTopology -SearchServiceInstance $searchInstance | Out-Null
    New-SPEnterpriseSearchQueryProcessingComponent -SearchTopology $searchTopology -SearchServiceInstance $searchInstance | Out-Null
    New-SPEnterpriseSearchCrawlComponent -SearchTopology $searchTopology -SearchServiceInstance $searchInstance  | Out-Null
    New-SPEnterpriseSearchAdminComponent -SearchTopology $searchTopology -SearchServiceInstance $searchInstance  | Out-Null
 
    Set-SPEnterpriseSearchAdministrationComponent -SearchApplication $serviceApplication -SearchServiceInstance  $searchInstance | Out-Null
 
    Remove-Item -Recurse -Force -LiteralPath $indexLocation -ErrorAction SilentlyContinue  | Out-Null
    mkdir -Path $indexLocation -Force  | Out-Null
 
    New-SPEnterpriseSearchIndexComponent -SearchTopology $searchTopology -SearchServiceInstance $searchInstance -RootDirectory $indexLocation | Out-Null
 
    Write-Host "Activating new search service topology"
    $SearchTopology.Activate()
 
    # Next call will provoke an error but after that the old topology can be deleted - just ignore it!
    try { $initialSearchTopology.Synchronize() } 
    catch{}
 
    Remove-SPEnterpriseSearchTopology -Identity $initialSearchTopology -Confirm:$false
    Write-Host "SharePoint Search has been configured"


    #SSA Search Center
    #http://search13/pages
    #Set the crawl Account
    #dht\srv_sp2010_crawl

}

# create web applications for farm



function Create-PrimaryWebApplication{

    # create variables for new web application
    $webAppName = “Wingtip HNSC Web Application” 
    $port = 80
    $hostHeader = “”
    $ssl = $false
    $authProvider = New-SPAuthenticationProvider -UseWindowsIntegratedAuthentication -UseBasicAuthentication
    $url = “http://wingtipserver”
    $appPoolName = “SharePoint Default App Pool”
    $appPoolAccount = Get-SPManagedAccount -Identity "WINGTIP\SP_Content"
    $dbServer = “WingtipServer”
    $dbName = “SharePoint_ContentDB_PrimaryWebApplication01”

    # create new web application
    Write-Host "Creating primary web application with support for HNSC..."
    $webapp = New-SPWebApplication `
                  -Name $webAppName `
                  -Port $port `
                  -HostHeader $hostHeader `
                  -SecureSocketsLayer:$ssl `
                  -AuthenticationProvider $authProvider `
                  -URL $url `
                  -ApplicationPool $appPoolName `
                  -ApplicationPoolAccount $appPoolAccount `
                  -DatabaseServer $dbServer `
                  -DatabaseName $dbName 

    Write-Host "Primary web application created"
    Write-Host

    # create variables for root site collection
    $siteUrl = "http://wingtipserver/"
    $siteTitle = "Wingtip Team Site"
    $siteOwner = "Wingtip\Administrator"
    $siteTemplate = "STS#0"

    # create root site collection
    Write-Host "Creating root site collection..."
    $site = New-SPSite -Url $siteUrl -Template $siteTemplate -OwnerAlias $siteOwner -Name $siteTitle
    Write-Host "Root site collection created"
    Write-Host 

}

function Create-WingtipIntranetWebApplication {

    # create variables for new web application
    $webAppName = “Wingtip Intranet” 
    $port = 80
    $ipAddress = "192.168.150.2"
    $hostHeader = “intranet.wingtip.com”
    $ssl = $false
    $authProvider = New-SPAuthenticationProvider -UseWindowsIntegratedAuthentication -UseBasicAuthentication 
    $url = “http://intranet.wingtip.com”
    $appPoolName = “SharePoint Default App Pool”
    $dbServer = “WingtipServer”
    $dbName = “SharePoint_ContentDB_WingtipIntranet01”

    # create new web application
    Write-Host "Creating Wingtip Intranet Web Application..."
    $webapp = New-SPWebApplication -Name $webAppName -Port $port -HostHeader $hostHeader -SecureSocketsLayer:$ssl -AuthenticationProvider $authProvider -URL $url -ApplicationPool $appPoolName -DatabaseServer $dbServer -DatabaseName $dbName 

    Write-Host "Configuring binding with IP address "
    Remove-WebBinding -Name $webAppName -bindingInformation (":" + $port + ":" + $hostHeader) 
    New-WebBinding -Name $webAppName -Protocol "http" -ip $ipAddress -Port $port -HostHeader $hostHeader
    
    Write-Host "Wingtip Intranet Web App Created"
    Write-Host


    # create variables for root site collection
    $siteUrl = "http://intranet.wingtip.com/"
    $siteTitle = "Wingtip Intranet"
    $siteOwner = "Wingtip\Administrator"
    $siteTemplate = "STS#0"

    # create root site collection
    Write-Host "Creating Wingtip Intranet Root Site Collection..."
    $site = New-SPSite -Url $siteUrl -Template $siteTemplate -OwnerAlias $siteOwner -Name $siteTitle
    Write-Host "Wingtip Intranet Root Site Collection Created"
    Write-Host 

}

function Create-WingtipExtranetWebApplication {

    # create variables for new web application
    $webAppName = “Wingtip Extranet” 
    $port = 443
    $hostHeader = “extranet.wingtip.com”
    $ssl = $true
    $authProvider = New-SPAuthenticationProvider -UseBasicAuthentication
    $url = “https://extranet.wingtip.com”
    $appPoolName = “SharePoint Default App Pool”
    $dbServer = “WingtipServer”
    $dbName = “SharePoint_ContentDB_WingtipExtranet01”

    # create new web application
    Write-Host "Creating Web App..."
    $webapp = New-SPWebApplication -Name $webAppName -Port $port -HostHeader $hostHeader -SecureSocketsLayer:$ssl -AuthenticationProvider $authProvider -URL $url -ApplicationPool $appPoolName -DatabaseServer $dbServer -DatabaseName $dbName 
    Write-Host "Wingtip Extranet Web App Created"
    Write-Host
    
    Write-Host "Configuring binding with IP address and SSL certificate"
    Remove-WebBinding -Name $webAppName -bindingInformation (":" + $port + ":" + $hostHeader) 
    New-WebBinding -Name $webAppName -Protocol "https" -ip $ipAddress -Port $port -HostHeader $hostHeader
    $wb = Get-WebBinding -Name $webAppName -Protocol "https" -IPAddress $ipAddress -Port 443 -HostHeader $hostHeader
    $certificate = gci Cert:\LocalMachine\my | where { $_.Subject -eq 'CN=extranet.wingtip.com' } 
    $certificateHash = $certificate.Thumbprint
    $wb.AddSslCertificate($certificateHash, "My");

    # create variables for root site collection
    $siteUrl = "https://extranet.wingtip.com/"
    $siteTitle = "Wingtip Extranet"
    $siteOwner = "Wingtip\Administrator"
    $siteTemplate = "STS#0"

    # create root site collection
    Write-Host "Creating Wingtip Extranet Root Site Collection..."
    $site = New-SPSite -Url $siteUrl -Template $siteTemplate -OwnerAlias $siteOwner -Name $siteTitle
    Write-Host "Wingtip Extranet Root Site Collection Created"
    Write-Host

}

function Create-MySiteHostWebApplication{

    # create variables for new web application
    $webAppName = “Wingtip My Site Host Web Application” 
    $port = 80
    $hostHeader = "my.wingtip.com"
    $ssl = $false
    $authProvider = New-SPAuthenticationProvider -UseWindowsIntegratedAuthentication -UseBasicAuthentication
    $url = “http://my.wingtip.com”
    $appPoolName = “SharePoint Default App Pool”
    $appPoolAccount = Get-SPManagedAccount -Identity "WINGTIP\SP_Content"
    $dbServer = “WingtipServer”
    $dbName = “SharePoint_ContentDB_MySiteHostWebApplication01”

    # create new web application
    Write-Host "Creating web application for My Site Host..."
    $webApplication = New-SPWebApplication `
                          -Name $webAppName `
                          -Port $port `
                          -HostHeader $hostHeader `
                          -SecureSocketsLayer:$ssl `
                          -AuthenticationProvider $authProvider `
                          -URL $url `
                          -ApplicationPool $appPoolName `
                          -DatabaseServer $dbServer `
                          -DatabaseName $dbName 

    Write-Host "My site host web application created"
    Write-Host

    # configure web application for my site host environment
    Remove-SPManagedPath -Identity "sites" -WebApplication $webApplication -Confirm:$false
    $webApplication | New-SPManagedPath -RelativeURL "my" -Explicit | Out-Null
    $webApplication | New-SPManagedPath -RelativeURL "personal"  | Out-Null

    $webApplication = Get-SPWebApplication -Identity $url
    $webApplication.SelfServiceSiteCreationEnabled = $true
    $webApplication.Update()

    # create variables for root site collection
    $siteUrl = "http://my.wingtip.com/"
    $siteTitle = "Wingtip My Site Host"
    $siteOwner = "Wingtip\Administrator"
    $siteTemplate = "SPSMSITEHOST#0"

    # create root site collection
    Write-Host "Creating root site collection..."
    $site = New-SPSite -Url $siteUrl -Template $siteTemplate -OwnerAlias $siteOwner -Name $siteTitle
    Write-Host "Root site collection created"
    Write-Host 

}

function Grant-WebApplicationPermissionsToServiceAccount{

    Write-Host "Granting SP_Services with permissions to access content DBs for each web application"

    foreach($webApplication in (Get-SPWebApplication)) {
      $webApplication.GrantAccessToProcessIdentity("WINGTIP\SP_Services")
    }

}

# add IP address for farm
Configure-IPAddresesForFarm

# disable loopback checks to enable local browsing to sites
Disable-LoopbackChecks

# add DNS A records required to build farm
Create-WingtipDnsRecords

# create SSL test certificates used in farm
Create-WingtipSslTestCertificates

# configure [*.wingtip.com] as trusted site in Internet Explorer
Add-TrustedSiteToInternetExplorer

# create active directory accounts for SharePoint service accounts
Create-SharePointServiceAccounts

# load in SharePoint snap-in
Add-PSSnapin Microsoft.SharePoint.PowerShell -WarningAction SilentlyContinue

# create variables used in this script
$server = "WingtipServer"
$configDb = "SharePoint_ConfigDB"
$centralAdminContentDB = "SharePoint_ContentDB_CentralAdmin"
$farmAccountName = "WINGTIP\SP_Farm"
$farmAccountPassword = "Password1"
$farmAccountSecureStringPassword = ConvertTo-SecureString -String $farmAccountPassword -AsPlainText -Force
$farmAccount = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $farmAccountName, $farmAccountSecureStringPassword 
$farmPassphrase = ConvertTo-SecureString "Password1" -AsPlainText -force

 

# create and initialize a new farm
Create-NewWingtipFarm

# reload PowerShell cmdlets due to weird bug where some Enterrpise cmdlets are no recognized
Remove-PSSnapin Microsoft.SharePoint.PowerShell -ErrorAction SilentlyContinue
Add-PSSnapin Microsoft.SharePoint.PowerShell -ErrorAction SilentlyContinue

# move aheat to build out farm

Create-ManagedAccounts

$serviceAppPoolName = Get-ServiceApplicationPoolName

Create-HealthUsageApplication

Create-StateServiceApplication

Start-ClaimsToWindowsTokenService

Start-UserCodeService

Create-SecureStoreServiceApplication

Create-ExcelServicesApplication

Create-WordAutomationServicesApplication

Create-PowerPointConversionServiceApplication 

Create-VisioGraphicsServiceApplication

Create-BCSApplication

Create-PerformancePointServiceApplication

Create-ManagedMetadataService

Create-AppManagementServiceApplication

Create-SiteSubscriptionSettingsService

Create-SearchServiceApplication

# create web applications 
Create-PrimaryWebApplication
Create-WingtipIntranetWebApplication
Create-WingtipExtranetWebApplication
Create-MySiteHostWebApplication
Grant-WebApplicationPermissionsToServiceAccount

# add bookmarks to Internet Explorer
Create-InternetExplorerShortcut "http://wingtipserver" "Test Site"
Create-InternetExplorerShortcut "http://intranet.wingtip.com" "Wingtip Intranet"
Create-InternetExplorerShortcut "https://extranet.wingtip.com" "Wingtip Extranet"
Create-InternetExplorerShortcut "http://wingtipserver:9999" "Central Admin"

# launch sites in Internet Explorer
#Start iexplore "http://intranet.wingtip.com" 
$ie = New-Object -com InternetExplorer.Application
$ie.Navigate2("http://wingtipserver:9999");
$navOpenInBackgroundTab = 0x1000;
$ie.Navigate2("http://wingtipserver", $navOpenInBackgroundTab);
$ie.Navigate2("http://intranet.wingtip.com", $navOpenInBackgroundTab);
$ie.Navigate2("https://extranet.wingtip.com", $navOpenInBackgroundTab);
$ie.Visible = $true;

Write-Host "Script complete - the Wingtip farm is now ready for access"
Write-Host "You must run two more scripts to configure user profiles and workflow services"
Write-Host 