
# setup for SharePoint Solutions Lab
Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$siteDomain = "OfficeServices.wingtip.com"
$siteUrl = "http://$siteDomain"
$siteDisplayName = "Office Services Lab"
$siteTemplate = "DEV#0"
$siteOwner = "WINGTIP\Administrator" 
$hostWebApplication = Get-SPWebApplication "http://wingtipserver"

cls
Write-Host 
Write-Host "This script will create the test site collection for $siteDisplayName"
Write-Host 

$site = Get-SPSite | Where-Object {$_.Url -eq $siteUrl}
if ($site -ne $null) {
  Write-Host "Deleting existing site collection at $siteUrl..." -ForegroundColor Red
  Remove-SPSite -Identity $site -Confirm:$false
}

Write-Host "Creating site collection at $siteUrl using New-SPSite..." -ForegroundColor Yellow
$site = New-SPSite -URL $siteUrl -Name $siteDisplayName -Template $siteTemplate -OwnerAlias $siteOwner -HostHeaderWebApplication $hostWebApplication

# add entry to HOST file to fix Visual Studio bug
$hostsFilePath = "c:\Windows\System32\Drivers\etc\hosts"
$hostFileEntry = "127.0.0.1     $siteDomain"
Add-Content -Path $hostsFilePath -Value "`r`n$hostFileEntry"
Write-Host "HOST file entry added: $hostFileEntry" -ForegroundColor Gray

function Create-WingtipUser($firstName, $lastName) {
    $displayName = "$firstName $lastName"
    $loginName = ("$firstName.$lastName").ToLower()
    $principalName = ("$loginName@wingtip.com").ToLower()
    Write-Host
    
    # checking to see if user already exists
    $adUser = Get-ADUser -filter {UserPrincipalName -eq $principalName}
    if ($adUser -eq $null) {
	    Write-Host "Creating user account for $principalName..." -ForegroundColor Yellow
	    $userPassword = ConvertTo-SecureString -AsPlainText "Password1" -Force
	    $newUser = New-ADUser -Path "CN=Users,DC=wingtip,DC=com" -SamAccountName $loginName -Name $displayName -DisplayName $displayName -EmailAddress $principalName -UserPrincipalName $principalName -Enabled $true -ChangePasswordAtLogon $false -PassThru -PasswordNeverExpires $true -AccountPassword $userPassword
    }
}

Create-WingtipUser "Ken" "Sanchez"
Create-WingtipUser "Michael" "Sullivan"
Create-WingtipUser "Rob" "Walters"
Create-WingtipUser "Janice" "Galvin"
Create-WingtipUser "Jill" "Williams"

Write-Host "Site collection created at $site.Url" -ForegroundColor Green
Write-Host "Launching site in Internet Explorer..." -ForegroundColor Green
Start iexplore $siteUrl

