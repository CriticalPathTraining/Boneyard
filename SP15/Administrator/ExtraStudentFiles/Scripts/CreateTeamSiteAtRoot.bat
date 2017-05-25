powershell -Command "& {Set-ExecutionPolicy bypass}" -NoExit
powershell -Command "& {.\CreateSiteCollection.ps1 -TargetUrl 'http://intranet.wingtip.com' -SiteDisplayName 'Wingtip Intranet' -SiteTemplate 'STS#0' -DeleteExistingSite $true }" -NoExit

pause