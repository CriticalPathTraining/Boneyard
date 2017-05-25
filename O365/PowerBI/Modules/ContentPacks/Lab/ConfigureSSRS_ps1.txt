Add-PSSnapin Microsoft.SharePoint.PowerShell

Install-SPRSService

Install-SPRSServiceProxy

Get-SPServiceInstance -all | where {$_.TypeName -like "SQL Server Reporting*"} | Start-SPServiceInstance

Write-Host "SQL Server Reporting Services are configured."
Write-Host "You can now create a new service application for SQL Server Reporting Services in Central Administration."
Write-Host 
Write-Host "Press ENTER to close this window"
Read-Host