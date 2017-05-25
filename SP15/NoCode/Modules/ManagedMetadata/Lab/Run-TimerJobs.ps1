Write-Host 
Write-Host "Sync the Enterprise Content Types"

# load Microsoft.SharePoint.PowerShell
Add-PSSnapin Microsoft.SharePoint.Powershell -ErrorAction "SilentlyContinue"

#Run the timer jobs to trip the MMS Service to Sync the Enterprise Content Types
Get-SPTimerJob -Identity "MetadataHubTimerJob" | Start-SPTimerJob
Get-SPTimerJob | where {($_.Title -like "Content Type Sub*") -and ($_.WebApplication.Name -eq "Wingtip Intranet") }  | Start-SPTimerJob

Write-Host
Read-Host  "Timer Jobs Run Complete. Press Enter to close..."
