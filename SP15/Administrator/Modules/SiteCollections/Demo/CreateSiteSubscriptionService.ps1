Add-PSSnapin Microsoft.SharePoint.PowerShell -ErrorAction SilentlyContinue

# assign root domain name to configure URL used to access app webs
Set-SPAppDomain "apps.wingtip.com" –confirm:$false 

# Start SPSubscriptionSettingsService and wait for it to start
Write-Host "Ensure Subscription Settings Service is running" 

$service = Get-SPServiceInstance |
               where{$_.GetType().Name -eq "SPSubscriptionSettingsServiceInstance"} 

if($service.Status -ne "Online") { 
    Write-Host "Starting subscription service" 
    Start-SPServiceInstance $service 
} 

# wait for subscription service to start" 
while ($service.Status -ne "Online") {
  # delay 5 seconds then check to see if service has started   sleep 5
  $service = Get-SPServiceInstance | 
                  where{ $_.GetType().Name -eq "SPSubscriptionSettingsServiceInstance" }
} 

# create an instance Subscription Service Application and proxy if they do not exist 
if($serviceApp -eq $null) { 
  Write-Host "Site Setting Subscription Service Application does not exist, time to create it" 
  $pool = Get-SPServiceApplicationPool "SharePoint Web Services Default" 
  $serviceAppName = "Site Setting Service Applicaton" 
  $serviceAppDbName = "Wingtip_SiteSettingServicedB"
  $serviceApp = New-SPSubscriptionSettingsServiceApplication -ApplicationPool $pool -Name $serviceAppName -DatabaseName $ServiceAppDbName 

  $serviceAppProxy = New-SPSubscriptionSettingsServiceApplicationProxy -ServiceApplication $serviceApp
  
  Write-Host "Instance of the Subscription Service has been created"
}

# assign name to default tenant to configure URL used to access web apps 
Set-SPAppSiteSubscriptionName -Name "WingtipTenant" -Confirm:$false