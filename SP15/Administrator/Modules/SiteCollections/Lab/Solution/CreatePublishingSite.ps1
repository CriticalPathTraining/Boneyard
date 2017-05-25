Add-PSSnapin Microsoft.SharePoint.PowerShell

$webapp = Get-SPWebApplication -Identity "http://WingtipServer"

$siteUrl = "http://www.wingtip.com/"
$siteTitle = "Wingtip Toys"
$siteOwner = "Wingtip\Administrator"
$siteTemplate = "BLANKINTERNET#0"

$site = New-SPSite -Url $siteUrl -Template $siteTemplate -OwnerAlias $siteOwner -Name $siteTitle -HostHeaderWebApplication $webapp

# enable anonymous access for site collection
if($site.IISAllowsAnonymous){
  Write-Host "Enabling anonymous access"
  $web = $site.RootWeb
  $web.AnonymousState = [Microsoft.SharePoint.SPWeb+WebAnonymousState]::On
  $web.Update()
}
else{
  Write-Host "Cannot enabling anonymous access because Web Application does not allow"
}
