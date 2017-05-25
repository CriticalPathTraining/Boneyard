# ensure log outfile folder exists
New-Item "C:\HealthData" -type directory -ErrorAction Ignore

# ensure SharePoint Powershell snap-in has been loaded
Add-PSSnapin Microsoft.SharePoint.PowerShell

# piece together path and file name for custom log file
$logFile = "C:\HealthData\LogFile1.log"

# get start and end times for the last 5 minutes
$startTime = (Get-Date).AddMinutes(-5)
$endTime = Get-Date

# determine target area for viewing ULS log entries
$area = "SharePoint Foundation"
$category = "Topology"

# merge ULS log entires into custom log file
Merge-SPLogFile -Path $logFile -StartTime $startTime -EndTime $endTime -Area $area -Category $category -Overwrite

