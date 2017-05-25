Add-PSSnapin Microsoft.SharePoint.PowerShell

$contentDatabaseName = "ContentDB_WingtipEngineering"
$webappurl = "http://intranet.wingtip.com"

# create a new content database
New-SPContentDatabase $contentDatabaseName -WebApplication $webappurl

$siteUrl = "http://intranet.wingtip.com/sites/engineering"
$siteTitle = "Wingtip Engineering Site"
$siteOwner = "Wingtip\Administrator"
$siteTemplate = "STS#0"

$site = New-SPSite -Url $siteUrl -Template $siteTemplate -OwnerAlias $siteOwner -Name $siteTitle -ContentDatabase $contentDatabaseName
