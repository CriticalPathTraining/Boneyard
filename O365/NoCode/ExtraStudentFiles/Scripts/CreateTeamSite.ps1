# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: CreateTeamSite.ps1
#
#       Author: Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: Creates a team site.
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=

$siteUrl                   = "http://intranet.wingtip.com"
$siteTitle                 = "Wingtip Intranet"
$siteTemplate              = "STS#0"
$hnscHostWebAppTitle       = "SharePoint HNSC Host - 80"
$deleteExistingSite        = $true
$launchIeAfterCreatingSite = $true

#execute shared script
.\\CreateSiteCollection.ps1 -TargetUrl $siteUrl -SiteDisplayName $siteTitle -SiteTemplate $siteTemplate -HostNameSiteCollectionHostWebApp $hnscHostWebAppTitle -DeleteExistingSite $deleteExistingSite -LaunchIeAfterSiteCreation $launchIeAfterCreatingSite

Write-Host "It is now safe to close this dialog." -ForegroundColor White
Read-Host "Press any key to continue..."