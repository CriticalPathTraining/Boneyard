Add-PSSnapin Microsoft.SharePoint.PowerShell

$credential = Get-Credential "WINGTIP\SP_Content" -Verbose
New-SPManagedAccount -Credential $credential
