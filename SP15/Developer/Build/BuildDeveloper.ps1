# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: BuildDeveloper.ps1
#
#       Author: Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: Extracts all files needed for a course manual (PPTX & DOCX) to the specified folder
#
#   Parameters: $BuildTargetPath - Fully qualified path to the location where the files will be staged
#                 ex: "D:\CourseBuilds\"
#               $Audience - Audience for the course, specifically the folder name found in TFS
#                 ex: Developer
#               $SharePointVersion - Version of SharePoint, use the 
#                 ex: 15
#               $CourseCodes - Single or CSV list of course codes to process
#                 ex: GSA2013   or   GSA2013,WC-SPT2013
#               $CourseVersion - Version of the course
#                 ex: 1.0
# Optional Parameters:
#               $BuildZip - flag indicating if the student ZIP should be built
#               $RemoveStagingFolder - flag indicating if the staged folder used to ZIP should be removed 
#                                       after creating the zip
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=

param(
	[string]$BuildTargetPath = "D:\Apollo\Developer\",
	[string]$Audience = "Developer",
  [string]$SharePointVersion = "15",
	[string]$CourseCodes = "GSA2013,RS-GSA2013,SPT2013,WC-SPT2013",
	[string]$CourseVersion = "0.1",
  [switch]$BuildZip = $true,
  [switch]$RemoveStagingFolder = $true
)

$ErrorActionPreference = 'Stop'

Write-Host
Write-Host "Generating Manual Manifest..." -ForegroundColor White
Write-Host " Script Steps:" -ForegroundColor White

.\..\..\..\..\BuildScripts\BuildManualManifest.ps1 -BuildTargetPath $BuildTargetPath -Audience $Audience -SharePointVersion $SharePointVersion -CourseCodes $CourseCodes -CourseVersion $CourseVersion -UseProductionAsScouce:$false
.\..\..\..\..\BuildScripts\BuildStudentPackage.ps1 -BuildTargetPath $BuildTargetPath -Audience $Audience -SharePointVersion $SharePointVersion -CourseCodes $CourseCodes -CourseVersion $CourseVersion -BuildZip:$true -RemoveStagingFolder:$true -UseProductionAsScouce:$false