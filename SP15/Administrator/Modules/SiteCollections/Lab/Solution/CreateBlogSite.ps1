Add-PSSnapin Microsoft.SharePoint.PowerShell

$webapp = Get-SPWebApplication -Identity "http://WingtipServer"

$siteUrl = "http://blog.wingtip.com/"
$siteTitle = "Wingtip Blog Site"
$siteOwner = "Wingtip\Administrator"
$siteTemplate = "BLOG#0"

$site = New-SPSite -Url $siteUrl -Template $siteTemplate -OwnerAlias $siteOwner -Name $siteTitle -HostHeaderWebApplication $webapp