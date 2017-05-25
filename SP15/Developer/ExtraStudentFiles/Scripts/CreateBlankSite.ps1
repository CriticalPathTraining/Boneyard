# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: CreateBlankSite.ps1
#
#       Author: Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: Creates a blank site.
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=

$siteUrl                   = "http://blank.wingtip.com"
$siteTitle                 = "Wingtip Blank Site"
$siteTemplate              = "STS#1"
$hnscHostWebAppTitle       = "SharePoint HNSC Host - 80"
$deleteExistingSite        = $true
$launchIeAfterCreatingSite = $true

#execute shared script
.\\CreateSiteCollection.ps1 -TargetUrl $siteUrl -SiteDisplayName $siteTitle -SiteTemplate $siteTemplate -HostNameSiteCollectionHostWebApp $hnscHostWebAppTitle -DeleteExistingSite $deleteExistingSite -LaunchIeAfterSiteCreation $launchIeAfterCreatingSite

Write-Host "It is now safe to close this dialog." -ForegroundColor White
Read-Host "Press any key to continue..."