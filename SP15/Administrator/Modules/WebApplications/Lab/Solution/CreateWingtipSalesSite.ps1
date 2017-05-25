Add-PSSnapin Microsoft.SharePoint.PowerShell

$webapp = Get-SPWebApplication -Identity "http://WingtipServer"

$siteUrl = "http://sales.wingtip.com/"
$siteTitle = "Wingtip Sales Site"
$siteAdmin1 = "Wingtip\AC"
$siteAdmin2 = "Wingtip\Administrator"
$siteTemplate = "STS#0"

# create root site collection
Write-Host "Creating Wingtip Sales site..."
$site = New-SPSite -HostHeaderWebApplication $webapp -Url $siteUrl -Name $siteTitle -OwnerAlias $siteAdmin1 -SecondaryOwnerAlias $siteAdmin2 -Template $siteTemplate
Write-Host "Wingtip Sales site created"

Write-Host