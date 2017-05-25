Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$siteDomain = "intranet.wingtip.com"
$siteUrl = "http://$siteDomain"
$siteDisplayName = "Wingtip Intranet"
$siteTemplate = "STS#0"
$siteOwner = "WINGTIP\Administrator" 

cls
Write-Host 
Write-Host "This script will recreate the Wingtip Intranet site collection"
Write-Host 

$site = Get-SPSite | Where-Object {$_.Url -eq $siteUrl}
if ($site -ne $null) {
  Write-Host "Deleting existing site collection at $siteUrl..." -ForegroundColor Red
  Remove-SPSite -Identity $site -Confirm:$false
}

Write-Host "Creating site collection at $siteUrl using New-SPSite..." -ForegroundColor Yellow
$site = New-SPSite -URL $siteUrl -Name $siteDisplayName -Template $siteTemplate -OwnerAlias $siteOwner

IISRESET

Write-Host "Site collection created at $site.Url" -ForegroundColor Green
Write-Host "Launching site in Internet Explorer..." -ForegroundColor Green
Start iexplore $siteUrl