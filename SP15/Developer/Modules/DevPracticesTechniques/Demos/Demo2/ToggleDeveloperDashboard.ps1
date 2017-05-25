# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: ToggleDeveloperDashboard.ps1
#
#       Author: Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: Turns on the Developer Dashboard
#
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=

$ErrorActionPreference = 'Stop'

# Load SharePoint PowerShell snapin
Write-Host
Write-Host " Step 1 of 2: Loading SharePoint PowerShell Module" -ForegroundColor Black -BackgroundColor Gray
Write-Host
Write-Host "  Verify SharePoint PowerShell Snapin Loaded" -ForegroundColor White
$snapin = Get-PSSnapin | Where-Object {$_.Name -eq 'Microsoft.SharePoint.PowerShell'}
if ($snapin -eq $null) {
	Write-Host "    .. loading SharePoint PowerShell Snapin..." -ForegroundColor Gray
  Add-PSSnapin "Microsoft.SharePoint.PowerShell"
}
Write-Host "    Microsoft SharePoint PowerShell snapin loaded" -ForegroundColor Gray 


$contentService = [Microsoft.SharePoint.Administration.SPWebService]::ContentService
$devDashboardSettings = $contentService.DeveloperDashboardSettings

Write-Host
Write-Host " Turning on Developer Dashboard" -ForegroundColor White
if ($devDashboardSettings.DisplayLevel -eq "On"){
  $devDashboardSettings.DisplayLevel = "Off"
  Write-Host "Developer dashboard disabled." -ForegroundColor Gray
} else {
  $devDashboardSettings.DisplayLevel = "On"
  Write-Host "Developer dashboard enabled." -ForegroundColor Gray
}
$devDashboardSettings.Update()

Write-Host
Write-Host "Finished!" -ForegroundColor Green