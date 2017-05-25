powershell -Command "& {Set-ExecutionPolicy bypass}" -NoExit
powershell -Command "& {.\CreateSiteCollection.ps1 -TargetUrl 'http://intranet.wingtip.com' -SiteDisplayName 'Wingtip Dev Site' -SiteTemplate 'STS#1' -DeleteExistingSite $true }" -NoExit

pause