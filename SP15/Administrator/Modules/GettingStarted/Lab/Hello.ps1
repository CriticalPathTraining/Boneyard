# create a variable with a welcome message
$HelloMessage = "Hello Wonderful World of Windows PowerShell Scripting"

# write ouptu to Windows console window
Write-Host "-----------------------------------"
Write-Host $HelloMessage
Write-Host "Host name: "$(Get-Item env:\computerName).value
Write-Host "-----------------------------------"