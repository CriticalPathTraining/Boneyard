# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: CreateSiteCollection.ps1
#
#       Author: Andrew Connell
#               Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: Creates a new site collection in the target location.
#               If a site collection exists in the same location, that site collection is 
#                 deleted before this one is created.
#
#   Parameters: $TargetUrl - Fully qualified URL of the location where to create the site collection
#               $SiteDisplayName - Name of the top level site that's created
#               $SiteTemplate - Site template to use in creating the top level site (STS#0, STS#1, etc)
#               $HostNameSiteCollectionHostWebApp - Name of the Web App hosting host name site collections
#  Optional Parameters:
#               $DeleteExistingSite - If a site is found at the $TargetUrl, should it be automatically deleted?
#                     Default = FALSE
#               $LaunchIeAfterSiteCreation - Should the site be loaded in IE after creation?
#                     Default = FALSE
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=

param(
	[string]$TargetUrl,
	[string]$SiteDisplayName,
	[string]$SiteTemplate,
  [string]$HostNameSiteCollectionHostWebApp,
	[switch]$DeleteExistingSite = $false,
	[switch]$LaunchIeAfterSiteCreation = $false
)

$ErrorActionPreference = 'Stop'

Write-Host
Write-Host "Creating new site collection..." -ForegroundColor White
Write-Host

# verify parameters passed in
Write-Host "(0) Validating parameters..." -ForegroundColor White
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



# Load SharePoint PowerShell snapin
Write-Host
Write-Host "(1) Verify SharePoint PowerShell Snapin Loaded" -ForegroundColor White
$snapin = Get-PSSnapin | Where-Object {$_.Name -eq 'Microsoft.SharePoint.PowerShell'}
if ($snapin -eq $null) {
	Write-Host "    ..  Loading SharePoint PowerShell Snapin" -ForegroundColor Gray
    Add-PSSnapin "Microsoft.SharePoint.PowerShell"
}
Write-Host "    .. Microsoft SharePoint PowerShell snapin loaded" -ForegroundColor Gray 



Write-Host
Write-Host "(2) Check if site collection exists at target URL" -ForegroundColor White
$targetSpSite = Get-SPSite | Where-Object {$_.Url -eq $TargetUrl}
if ($targetSpSite -ne $null) {
  if ($DeleteExistingSite -eq $true){
    Write-Host "    .. Deleting existing site collection at $SiteUrl" -ForegroundColor Gray
    Remove-SPSite -Identity $SiteUrl -Confirm:$false
    Write-Host "    .. Existing site collection deleted." -ForegroundColor Gray
  } else {
  	Write-Warning "Found existing site collection at specified location: $TargetUrl"
    Write-Warning "To delete the site before creating it, rerun the script and specify -DeleteExistingSite $true"
    Write-Warning "Script aborting... site collection not created."
  	Write-Host
  	Write-Host
  	Exit
  }
}



Write-Host
Write-Host "(3) Creating new site collection at $TargetUrl" -ForegroundColor White
$NewSpSite = New-SPSite -HostHeaderWebApplication $hnscWebApp -URL $TargetUrl -Name $SiteDisplayName -Template $SiteTemplate -OwnerAlias Administrator
Write-Host "    .. Site collection created at $TargetUrl" -ForegroundColor Gray
$RootWeb = $NewSite.RootWeb



Write-Host
Write-Host "Finished! Script details are as follows:" -ForegroundColor Green

Write-Host "=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=" -ForegroundColor White
Write-Host "Site Title:       $SiteDisplayName" -ForegroundColor White
Write-Host "Site URL:         $TargetUrl" -ForegroundColor White
Write-Host "Site ID:          $RootWeb.Id.ToString()" -ForegroundColor White
Write-Host "Site Template:    $SiteTemplate" -ForegroundColor White
Write-Host "=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=" -ForegroundColor White
Write-Host 

# If specified, site is launched in IE
if ($LaunchIeAfterSiteCreation -eq $true){
  Write-Host "Launching site in Internet Explorer..." -ForegroundColor White
  Start iexplore $TargetUrl
}
