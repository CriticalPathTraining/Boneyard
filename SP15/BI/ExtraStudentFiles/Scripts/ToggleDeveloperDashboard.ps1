Write-Host

# ensure SharePoint PowerShell snap-in has been loaded
Add-PSSnapin Microsoft.SharePoint.PowerShell

# get ContentService object using SharePoint server-side Object Model

$contentService = [Microsoft.SharePoint.Administration.SPWebService]::ContentService

# get the object for configuring Developer Dashboard settings
$devDashboardSettings = $contentService.DeveloperDashboardSettings

# toggle DisplayLevel property of Developer Dashboard settings object
if ($devDashboardSettings.DisplayLevel -eq "Off"){
  $devDashboardSettings.DisplayLevel = "On"
  $devDashboardSettings.TraceEnabled = $true
  Write-Host "Developer dashboard enabled." -ForegroundColor Yellow
} else {
  $devDashboardSettings.DisplayLevel = "Off"
  $devDashboardSettings.TraceEnabled = $false
  Write-Host "Developer dashboard disabled." -ForegroundColor Yellow
}

$devDashboardSettings.Update()

Write-Host


