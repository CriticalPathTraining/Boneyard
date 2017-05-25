Write-Host 
# define variables for script
$SiteTitle = "eDiscovery Site"
$SiteUrl = "http://intranet.wingtip.com/sites/eDiscovery"
$SiteTemplate = "EDISC#0"
$SiteCollectionOwner = "WINGTIP\Administrator"
$TestingSiteUrl = "http://intranet.wingtip.com/sites/producttesting"

# load Microsoft.SharePoint.PowerShell
Add-PSSnapin Microsoft.SharePoint.Powershell -ErrorAction "SilentlyContinue"

# delete any existing site found at target URL
$targetUrl = Get-SPSite -Limit All  | Where-Object {$_.Url -eq $SiteUrl}
if ($targetUrl -ne $null) {
  Write-Host "Deleting existing site at" $SiteUrl
  Remove-SPSite -Identity $SiteUrl -Confirm:$false
}

# create new site at target URL
Write-Host "Creating new site at" $SiteUrl 
$NewSite = New-SPSite -URL $SiteUrl -OwnerAlias $SiteCollectionOwner -Template $SiteTemplate -Name $SiteTitle
$RootWeb = $NewSite.RootWeb

iisreset

#Kick off a crawl
$contentSource = Get-SPEnterpriseSearchServiceApplication | Get-SPEnterpriseSearchCrawlContentSource -Identity 1
$contentSource.StartFullCrawl()

# display site info
Write-Host 
Write-Host "Site created successfully" -foregroundcolor Green
Write-Host "-------------------------------------" -foregroundcolor Green
Write-Host "URL:" $RootWeb.Url -foregroundcolor Red
Write-Host "ID:" $RootWeb.Id.ToString() -foregroundcolor Red
Write-Host "Title:" $RootWeb.Title -foregroundcolor Red
Write-Host "-------------------------------------" -foregroundcolor Green

$ie = new-object -com "InternetExplorer.Application"
$ie.navigate($SiteUrl)
$ie.visible = $true
