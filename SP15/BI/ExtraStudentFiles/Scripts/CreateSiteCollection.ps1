# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: CreateSiteCollection.ps1
#
#       Author: Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: Creates a new site collection in the target location.
#               If a site collection exists in the same location, that site collection is 
#                 deleted before this one is created.
#
#   Parameters: $TargetUrl - Fully qualified URL of the location where to create the site collection
#               $SiteDisplayName - Name of the top level site that's created
#               $SiteTemplate - Site template to use in creating the top level site (STS#0, STS#1, etc)
#  Optional Parameters:
#               $HostNameSiteCollectionHostWebApp - Name of the Web App hosting host name site collections. 
#                 If none specified, will create SPSite without HNSC host parameter.
#                     Default = ""
#               $DeleteExistingSite - If a site is found at the $TargetUrl, should it be automatically deleted?
#                     Default = FALSE
#               $LaunchIeAfterSiteCreation - Should the site be loaded in IE after creation?
#                     Default = FALSE
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=

param(
    [string]$TargetUrl,
    [string]$SiteDisplayName,
    [string]$SiteTemplate,
    [string]$HostNameSiteCollectionHostWebApp = "",
    [switch]$DeleteExistingSite = $false,
    [switch]$LaunchIeAfterSiteCreation = $false
)

$ErrorActionPreference = 'Stop'
$PreviousSPSiteInstanceFound = $false

Write-Host
Write-Host "Creating new site collection..." -ForegroundColor White
Write-Host " Script Steps:" -ForegroundColor White
Write-Host " (1 of 7) Validating parameters..." -ForegroundColor White
Write-Host " (2 of 7) Verify SharePoint PowerShell Snapin Loaded" -ForegroundColor White
Write-Host " (3 of 7) Check if site collection exists at target $SiteUrl" -ForegroundColor White
Write-Host " (4 of 7) Get reference to HNSC Web Application Host: $HostNameSiteCollectionHostWebApp" -ForegroundColor White
Write-Host " (5 of 7) Creating new site collection: $TargetUrl" -ForegroundColor White
Write-Host " (6 of 7) Creating shortcut: $TargetUrl" -ForegroundColor White
Write-Host " (7 of 7) Updating HOSTS file..." -ForegroundColor White
Write-Host


# -----------------------------------------------


# verify parameters passed in
Write-Host "(1 of 7) Validating parameters..." -ForegroundColor White
if ($TargetUrl -eq $null -xor $TargetUrl -eq ""){
	Write-Error '$TargetUrl is required'
	Exit
}
if ($SiteDisplayName -eq $null -xor $SiteDisplayName -eq ""){
	Write-Error '$SiteDisplayName is required'
	Exit
}
if ($SiteTemplate -eq $null -xor $SiteTemplate -eq ""){
	Write-Error '$SiteTemplate is required'
	Exit
}
Write-Host "    All parameters valid" -ForegroundColor Gray 


# -----------------------------------------------


# Load SharePoint PowerShell snapin
Write-Host
Write-Host "(2 of 7) Verify SharePoint PowerShell Snapin Loaded" -ForegroundColor White
$snapin = Get-PSSnapin | Where-Object {$_.Name -eq 'Microsoft.SharePoint.PowerShell'}
if ($snapin -eq $null) {
	Write-Host "    .. loading SharePoint PowerShell Snapin..." -ForegroundColor Gray
  Add-PSSnapin "Microsoft.SharePoint.PowerShell"
}
Write-Host "    Microsoft SharePoint PowerShell snapin loaded" -ForegroundColor Gray 


# -----------------------------------------------


Write-Host
Write-Host "(3 of 7) Check if site collection exists at target $SiteUrl" -ForegroundColor White
$targetSpSite = Get-SPSite | Where-Object {$_.Url -eq $TargetUrl}
if ($targetSpSite -ne $null) {
  Write-Host "    .. existing site collection found" -ForegroundColor Gray
  $PreviousSPSiteInstanceFound = $true
  if ($DeleteExistingSite -eq $true){
    Write-Host "    .. deleting existing site collection at $SiteUrl" -ForegroundColor Gray
    Remove-SPSite -Identity $SiteUrl -Confirm:$false
    Write-Host "    Existing site collection deleted" -ForegroundColor Gray
  } else {
  	Write-Warning "Found existing site collection at specified location: $TargetUrl"
    Write-Warning "To delete the site before creating it, rerun the script and specify -DeleteExistingSite $true"
    Write-Warning "Script aborting... site collection not created."
  	Write-Host
  	Write-Host
  	Exit
  }
}


# -----------------------------------------------


Write-Host
Write-Host "(4 of 7) Get reference to HNSC Web Application Host: $HostNameSiteCollectionHostWebApp" -ForegroundColor White
if ($HostNameSiteCollectionHostWebApp -ne ""){
  Write-Host "    .. retrieving web app: $HostNameSiteCollectionHostWebApp..." -ForegroundColor Gray
  $hnscWebApp = Get-SPWebApplication | Where-Object {$_.DisplayName -eq $HostNameSiteCollectionHostWebApp}
  Write-Host "    Retrived host named site collection web app" -ForegroundColor Gray
} else {
  Write-Host "    No HNSC web app specified, skipping this step" -ForegroundColor Gray
}


# -----------------------------------------------


Write-Host
Write-Host "(5 of 7) Creating new site collection: $TargetUrl" -ForegroundColor White
Write-Host "    .. creating site collection at $TargetUrl" -ForegroundColor Gray
if ($HostNameSiteCollectionHostWebApp -ne ""){
  $NewSpSite = New-SPSite -HostHeaderWebApplication $hnscWebApp -URL $TargetUrl -Name $SiteDisplayName -Template $SiteTemplate -OwnerAlias "WINGTIP\Administrator"
} else {
  $NewSpSite = New-SPSite -URL $TargetUrl -Name $SiteDisplayName -Template $SiteTemplate -OwnerAlias "WINGTIP\Administrator"
}
Write-Host "    Site collection created at $TargetUrl" -ForegroundColor Gray


# -----------------------------------------------


Write-Host
Write-Host "(6 of 7) Creating shortcut: $TargetUrl" -ForegroundColor White
Write-Host "    .. creating shortcut to site collection in IE's Favorites Bar" -ForegroundColor Gray
$scriptPath = Split-Path -Parent $MyInvocation.Mycommand.Definition
$scriptPath = Join-Path -Path $scriptPath -ChildPath "CreateSiteShortcut.ps1"
$scriptPath += " -TargetUrl $TargetUrl"
Invoke-Expression $scriptPath


# -----------------------------------------------


Write-Host
Write-Host "(7 of 7) Updating HOSTS file..." -ForegroundColor White
if ($PreviousSPSiteInstanceFound -ne $true) {
  Write-Host "    .. writing entry to HOSTS file" -ForegroundColor Gray

  # create site URL
  $siteUrl = $TargetUrl -replace "http://", ""

  # write entry to HOSTS file
  $hostsFilePath = "c:\Windows\System32\Drivers\etc\hosts"
  $hostEntry = "127.0.0.1       $siteUrl" 
  # Add-Content -Path $hostsFilePath -Value "`n"
  Add-Content -Path $hostsFilePath -Value $hostEntry
  Write-Host "    Entry added to HOSTS file" -ForegroundColor Gray
} else {
  Write-Host "    Skipping this step as site previously existed thus likely already has HOSTS entry" -ForegroundColor Gray
}


# -----------------------------------------------


Write-Host
Write-Host "Finished! Script details are as follows:" -ForegroundColor Green

Write-Host 
Write-Host "=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=" -ForegroundColor White
if ($HostNameSiteCollectionHostWebApp -ne ""){
  Write-Host "Site Host Web App: $HostNameSiteCollectionHostWebApp" -ForegroundColor White
}
Write-Host "Site Title:        $SiteDisplayName" -ForegroundColor White
Write-Host "Site URL:          $TargetUrl" -ForegroundColor White
Write-Host "Site Template:     $SiteTemplate" -ForegroundColor White
Write-Host "=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=" -ForegroundColor White
Write-Host 

# If specified, site is launched in IE
if ($LaunchIeAfterSiteCreation -eq $true){
  Write-Host "Launching site in Internet Explorer..." -ForegroundColor White
  Start iexplore $TargetUrl
  Write-Host "  IE launched & navigated to the site" -ForegroundColor Gray 
  Write-Host 
}
