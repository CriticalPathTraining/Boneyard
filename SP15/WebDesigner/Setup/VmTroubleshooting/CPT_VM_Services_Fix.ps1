Add-PSSnapin microsoft.sharepoint.powershell

function Grant-ServiceAppPermission($svcApp, [string]$account, [string]$permission, [bool]$admin) {
    try {
        $security = $svcApp | Get-SPServiceApplicationSecurity -Admin:$admin
        $principal = New-SPClaimsPrincipal -Identity $account -IdentityType WindowsSamAccountName
        $security | Grant-SPObjectSecurity -Principal $principal -Rights $permission
        $svcApp | Set-SPServiceApplicationSecurity -ObjectSecurity $security -Admin:$admin
    } catch {
        Write-Warning "Unable to grant `"$permission`" rights to `"$account`": $($_.Message)"
    }
}

#Grant the user full access to the term store
$svc = Get-SPMetadataServiceApplication "Managed Metadata Service"
Grant-ServiceAppPermission $svc "wingtip\administrator" "Full Access to Term Store" $false

#Get an updated instance of the service and flush the cache (adds an entry to the change log table)
$svc = Get-SPMetadataServiceApplication "Managed Metadata Service"
$svc.InitiateCacheFlush()

#Set the FIMService to delayed start and make sure it's started.
sc.exe config FIMService start= delayed-auto
Start-Service FIMService