# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: CreateDeveloperSite.ps1
#
#       Author: Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: Creates a developer site.
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=

$siteUrl                   = "http://dev.wingtip.com"
$siteTitle                 = "Developer Site"
$siteTemplate              = "DEV#0"
$hnscHostWebAppTitle       = "SharePoint HNSC Host - 80"
$deleteExistingSite        = $true
$launchIeAfterCreatingSite = $true

#execute shared script
.\CreateSiteCollection.ps1 -TargetUrl $siteUrl -SiteDisplayName $siteTitle -SiteTemplate $siteTemplate -HostNameSiteCollectionHostWebApp $hnscHostWebAppTitle -DeleteExistingSite $deleteExistingSite -LaunchIeAfterSiteCreation $launchIeAfterCreatingSite

Write-Host "It is now safe to close this dialog." -ForegroundColor White
Read-Host "Press any key to continue..."