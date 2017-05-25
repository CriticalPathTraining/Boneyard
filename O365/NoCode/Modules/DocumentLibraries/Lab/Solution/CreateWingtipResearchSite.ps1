Add-PSSnapin "Microsoft.SharePoint.PowerShell"

$siteUrl = "http://intranet.wingtip.com/sites/research"
$siteDisplayName = "Wingtip Product Research"
$siteTemplate = "STS#0"
$siteOwner = "WINGTIP\Administrator" 
cls
Write-Host 
Write-Host "This script will create the Wingtip Product Research Site"
Write-Host 

$site = Get-SPSite | Where-Object {$_.Url -eq $siteUrl}
if ($site -ne $null) {
  Write-Host "Deleting existing site collection at $siteUrl..." -ForegroundColor Red
  Remove-SPSite -Identity $site -Confirm:$false
}

Write-Host "Creating site collection at $siteUrl..." -ForegroundColor Yellow
$site = New-SPSite -URL $siteUrl -Name $siteDisplayName -Template $siteTemplate -OwnerAlias $siteOwner -HostHeaderWebApplication $hostWebApplication

Write-Host "Site collection created at $site.Url" -ForegroundColor Green

iisreset

Write-Host "Launching site in Internet Explorer..." -ForegroundColor Green
Start iexplore $siteUrl