Add-PSSnapin Microsoft.SharePoint.PowerShell

$webapp = Get-SPWebApplication -Identity "http://WingtipServer"

$siteUrl = "https://research.wingtip.com/"
$siteTitle = "Wingtip Research and Development"
$siteAdmin1 = "Wingtip\DavidM"
$siteAdmin2 = "Wingtip\Administrator"
$siteTemplate = "STS#1"

# create root site collection
Write-Host "Creating Wingtip Research site..."
$site = New-SPSite -HostHeaderWebApplication $webapp -Url $siteUrl -Name $siteTitle -OwnerAlias $siteAdmin1 -SecondaryOwnerAlias $siteAdmin2 -Template $siteTemplate
Write-Host "Wingtip Research site created"
Write-Host