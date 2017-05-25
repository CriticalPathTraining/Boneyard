Add-PSSnapin Microsoft.SharePoint.PowerShell
Clear-Host

# create variables for new web application
$webAppName = “Wingtip Extranet” 
$port = 443
$hostHeader = “extranet.wingtip.com”
$ssl = $true
$authProvider = New-SPAuthenticationProvider -UseBasicAuthentication
$url = “https://extranet.wingtip.com”
$appPoolName = “SharePoint - 80”
$dbServer = “WingtipServer”
$dbName = “WingtipExtranet_ContentDB”

# create new web application
Write-Host "Creating Web App..."
$webapp = New-SPWebApplication -Name $webAppName -Port $port -HostHeader $hostHeader -SecureSocketsLayer:$ssl -AuthenticationProvider $authProvider -URL $url -ApplicationPool $appPoolName -DatabaseServer $dbServer -DatabaseName $dbName 
Write-Host "Wingtip Extranet Web App Created"
Write-Host


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

Write-Host "Script complete"
Write-Host 