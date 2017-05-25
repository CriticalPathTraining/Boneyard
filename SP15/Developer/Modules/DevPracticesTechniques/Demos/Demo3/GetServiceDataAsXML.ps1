# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: GetServiceDataAsXML.ps1
#
#       Author: Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: Issues local query for JSON data
#
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=

$ErrorActionPreference = 'Stop'

Write-Host
Write-Host " Querying Service, Accept JSON Response" -ForegroundColor Black -BackgroundColor Gray

$webRequest = [System.Net.WebRequest]::Create("http://cptresources.wingtip.com:81/services/AdventureWorks2012Person.svc/AddressTypes")
$webRequest.Accept = "application/atom+xml"
$webResponse = $webRequest.GetResponse()