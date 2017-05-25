Add-PSSnapin Microsoft.SharePoint.Powershell

$tenancy = New-SPSiteSubscription
$webapp = Get-SPWebApplication http://wingtipserver

$customer = "Customer01"

$sc1_siteUrl = "http://" + $customer + ".wingtip.com"
$sc1_siteTitle = $customer + " - Primary Site Collection"
$sc1_siteOwner = "WINGTIP\Administrator"
$sc1_siteTemplate = "STS#0"

$sc1 = New-SPSite -Url $sc1_siteUrl -Name $sc1_siteTitle -OwnerAlias $sc1_siteOwner -Template $sc1_siteTemplate -HostHeaderWebApplication $webapp -SiteSubscription $tenancy

$ta_siteUrl = "http://" + $customer + ".wingtip.com/sites/admin"
$ta_siteTitle = $customer + " - Tenant Admin Site Collection"
$ta_siteOwner = "WINGTIP\Administrator"
$ta_siteTemplate = "Tenantadmin#0"

$scAdmin = New-SPSite -Url $ta_siteUrl -Name $ta_siteTitle -OwnerAlias $ta_siteOwner -Template $ta_siteTemplate -HostHeaderWebApplication $webapp -SiteSubscription $tenancy -AdministrationSiteType TenantAdministration