# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: CreateCptResourcesWebSite.ps1
#
#       Author: Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: Creates a new web site for hosting CPT resources used in demos & labs.
#               The site listens on http://cptresources.wingtip.com:81
#
#   Parameters: $hostingAppPool - Name of the app pool to host the web site
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=

$ErrorActionPreference = 'Stop'

$cptResourceSiteName              = "CPT Resources - 81"
$cptResourceSiteBindingHostHeader = "cptresources.wingtip.com"
$cptResourceSiteBindingPort       = 81
$cptResourceSitePath              = "C:\inetpub\wwwroot\CPTResources"
$spHnscAppPool                    = "SharePoint Default App Pool"

Write-Host
Write-Host "Create new IIS site for Critical Path Training Resources" -ForegroundColor Black -BackgroundColor Gray
Write-Host " Script Steps:" -ForegroundColor White
Write-Host " (1) Load IIS Web Administration Module" -ForegroundColor White
Write-Host " (2) Create CPT Resource Website" -ForegroundColor White
Write-Host " (3) Setup CPT Resource Website Binding" -ForegroundColor White
Write-Host

# Load Web Administration module
Write-Host
Write-Host "(1) Load IIS Web Administration Module" -ForegroundColor White
Write-Host "    .. checking if WebAdminstration module loaded..." -ForegroundColor Gray
$webAdminModule = Get-Module WebAdministration
if ($webAdminModule -ne $null){
  Write-Host "    WebAdminstration already loaded" -ForegroundColor Gray  
} else {
  Write-Host "    .. WebAdminstration module not loaded" -ForegroundColor Gray  
  Write-Host "    .. loading WebAdminstration module..." -ForegroundColor Gray  
  Import-Module WebAdministration
  Write-Host "    WebAdministration module now loaded" -ForegroundColor Gray  
}


# check if site already exists
Write-Host
Write-Host "(2) Create CPT Resource Website" -ForegroundColor White
$cptResourceSite = Get-Website | Where-Object {$_.Name -eq $cptResourceSiteName}
if ($cptResourceSite -ne $null) {
  Write-Host "    $cptResourceSiteName already created" -ForegroundColor Gray
} else {
  Write-Host "    .. $cptResourceSiteName site not present" -ForegroundColor Gray
  #check for existing physical path
  if (Test-Path $cptResourceSitePath) {
    Write-Host "    Path $cptResourceSitePath path present" -ForegroundColor Gray
  } else { 
    Write-Host "    .. $cptResourceSitePath path not present" -ForegroundColor Gray
    Write-Host "    .. creating path $cptResourceSitePath..." -ForegroundColor Gray
    $silence = New-Item -Path $cptResourceSitePath -ItemType Directory
    Write-Host "    Path $cptResourceSitePath created" -ForegroundColor Gray
  }
  Write-Host "    .. creating IIS web site: $cptResourceSiteName..." -ForegroundColor Gray
  $cptResourceSite = New-Website -Name $cptResourceSiteName -PhysicalPath $cptResourceSitePath -ApplicationPool $spHnscAppPool -HostHeader $cptResourceSiteBindingHostHeader -Port $cptResourceSiteBindingPort
  Write-Host "    $cptResourceSiteName site created" -ForegroundColor Gray
}


Write-Host
Write-Host "(3) Setup CPT Resource Website Binding" -ForegroundColor White
$cptBinding = Get-WebBinding -Name $cptResourceSiteName -HostHeader $cptResourceSiteBindingHostHeader -Port $cptResourceSiteBindingPort
if ($cptBinding -ne $null) {
  Write-Host "    Correct bindings for $cptResourceSiteName site present" -ForegroundColor Gray
} else {
  Write-Host "    .. binding for $cptResourceSiteName site not present" -ForegroundColor Gray
  Write-Host "    .. adding binding for $cptResourceSiteName site ..." -ForegroundColor Gray
  New-WebBinding -Name $cptResourceSiteName -HostHeader $cptResourceSiteBindingHostHeader -Port $cptResourceSiteBindingPort
  Write-Host "    Bindings for $cptResourceSiteName site created" -ForegroundColor Gray
}

Write-Host
Write-Host "Finished! You can now import web applications." -ForegroundColor Green
Write-Host "It is now safe to close this dialog." -ForegroundColor White
Read-Host "Press any key to continue..."

# add entry to HOST file to redirect requests to local machine
$hostsFilePath = "c:\Windows\System32\Drivers\etc\hosts"
$hostFileEntry = "127.0.0.1     $cptResourceSiteBindingHostHeader"
Add-Content -Path $hostsFilePath -Value "`r`n$hostFileEntry"
Write-Host "HOST file entry added: $hostFileEntry" -ForegroundColor Gray