# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: DoWorkflowDebugging.ps1
#
#       Author: Andrew Connell
#               Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: To do SharePoint 2013 workflow debugging with Fiddler, you need to launch Fiddler but then recycle
#                 all involved services (Workflow Backend Service & WWW). Then do your debugging. When finished, 
#                 after closing Fiddler, you need to recycle the services again as Fiddler was trapping their traffic.
# 
#               See this post for setting up your SharePoint 2013 server for debugging workflow with Fiddler:
#                 http://www.andrewconnell.com/blog/archive/2012/07/18/sharepoint-2013-workflow-advanced-workflow-debugging-with-fiddler.aspx
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=

$ErrorActionPreference = 'Stop'

Write-Host
Write-Host "Setting up SharePoint 2013 Workflow Debugging" -ForegroundColor White
Write-Host
# Launch Fiddler
Write-Host
Write-Host "(1) Get Referece to Services" -ForegroundColor White
$wwwService = Get-Service | Where-Object {$_.Name -eq "W3SVC"}
$workflowService = Get-Service | Where-Object {$_.Name -eq "WorkflowServiceBackend"}


# Launch Fiddler
Write-Host
Write-Host "(2) Launching Fiddler" -ForegroundColor White
$fiddler = [System.Diagnostics.Process]::Start("C:\Program Files (x86)\Fiddler2\Fiddler.exe")


# Recycle Services
Write-Host
Write-Host "(3) Recycling Required Services" -ForegroundColor White
Write-Host "    Restarting the service:" $wwwService.Displayname -ForegroundColor Gray
Write-Host "    .. stopping service..." -ForegroundColor Gray
Stop-Service $wwwService
Write-Host "    .. starting service..." -ForegroundColor Gray
Start-Service $wwwService

Write-Host "    Restarting the service:" $workflowService.Displayname -ForegroundColor Gray
Write-Host "    .. stopping service..." -ForegroundColor Gray
Stop-Service $workflowService
Write-Host "    .. starting service..." -ForegroundColor Gray
Start-Service $workflowService


# Recycle Services
Write-Host
Write-Host "(4) Pausing PowerShell Script While Fiddler Is Open" -ForegroundColor White
Write-Host "    When Fiddler is closed, the script will continue" -ForegroundColor Gray
Write-Host "    Do not close this window..." -ForegroundColor Yellow
$fiddler.WaitForExit()

# Recycle Services
Write-Host
Write-Host "(5) Recycling Involved Services" -ForegroundColor White
Write-Host "    Restarting the service:" $wwwService.Displayname -ForegroundColor Gray
Write-Host "    .. stopping service..." -ForegroundColor Gray
Stop-Service $wwwService
Write-Host "    .. starting service..." -ForegroundColor Gray
Start-Service $wwwService

Write-Host "    Restarting the service:" $workflowService.Displayname -ForegroundColor Gray
Write-Host "    .. stopping service..." -ForegroundColor Gray
Stop-Service $workflowService
Write-Host "    .. starting service..." -ForegroundColor Gray
Start-Service $workflowService

Write-Host 
Write-Host "Finished!" -ForegroundColor Green
Write-Host
