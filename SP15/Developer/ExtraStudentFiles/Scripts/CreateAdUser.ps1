# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: CreateAdUser.ps1
#
#       Author: Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: This script creates a new user and optionally adds them to the local Remote Desktop Users Group.
#
#   Parameters: $domainController - Server name to connect to
#               $userFirstName - First anme of the user (ie: John)
#               $userLastName - Last name of the user (ie: Doe)
#  Optional Parameters:
#               $addToLocalRemoteDesktopUserGroup
#                     Default = FALSE
#               $addToDomainAdminsUserGroup
#                     Default = FALSE
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
param(
	[string]$domainController,
	[string]$userFirstName,
	[string]$userLastName,
	[switch]$addToLocalRemoteDesktopUserGroup = $false,
	[switch]$addToDomainAdminsUserGroup = $false
)

$ErrorActionPreference = 'Stop'
$userDisplayName = "$userFirstName $userLastName"
$userLoginName = ("$userFirstName.$userLastName").ToLower()
$userPrincipalName = ("$userLoginName@wingtip.com").ToLower()
$localRdpGroup = "Remote Desktop Users"
$domainAdminsGroup = "Domain Admins"

Write-Host
Write-Host "Creating New AD User"

# load AD module
Write-Host "    .. loading Active Directory PowerShell module..." -ForegroundColor Gray
Import-Module ActiveDirectory
Write-Host "    Active Directory PowerShell module loaded" -ForegroundColor Gray


# checking if user already exists... if not, creates it
Write-Host
Write-Host "    .. getting user..." -ForegroundColor Gray
$adUser = Get-ADUser -filter {UserPrincipalName -eq $userPrincipalName}
if ($adUser -eq $null) {
	Write-Host "    User $userDisplayName not found" -ForegroundColor Gray
	Write-Host "    .. creating user $userDisplayName..." -ForegroundColor Gray
	$userPassword = ConvertTo-SecureString -AsPlainText "Password1" -Force
	$newUser = New-ADUser -Path "CN=Users,DC=wingtip,DC=com" -SamAccountName $userLoginName -Name $userDisplayName -DisplayName $userDisplayName -EmailAddress $userPrincipalName -UserPrincipalName $userPrincipalName -Enabled $true -ChangePasswordAtLogon $false -PassThru -PasswordNeverExpires $true -AccountPassword $userPassword
	Write-Host "    User $userDisplayName created" -ForegroundColor Gray
} else {
	Write-Host "    User $userDisplayName found" -ForegroundColor Gray
}

if ($addToLocalRemoteDesktopUserGroup){
  Write-Host
  Write-Host " (2) Verify $userDisplayName in local group $localRdpGroup" -ForegroundColor White
  Write-Host "    .. checking if $userDisplayName in group $localRdpGroup..." -ForegroundColor Gray
  #find local group
  $localComputerName = $env:COMPUTERNAME
  $computer = [ADSI]"WinNT://$localComputerName,computer"
  $localGroup = $computer.psbase.Children | 
                    Where-Object {$_.psbase.schemaclassname -eq "group"} | 
                    Where-Object {$_.Path -eq "WinNT://WINGTIP/$localComputerName/$localRdpGroup"}
  $foundUser = $false
  #walk thru all members in group until find item
  $localGroup.Members() | ForEach-Object {
    $groupMemberName = $_.GetType().InvokeMember("Name", "GetProperty", $null, $_, $null)
    if ($groupMemberName -eq $userLoginName) {$foundUser = $true}
  }
  if ($foundUser -eq $true) {
    Write-Host "    Found WINGTIP\$userLoginName in group $localRdpGroup" -ForegroundColor Gray
  } else {
    Write-Host "    WINGTIP\$userLoginName not in group $localRdpGroup" -ForegroundColor Gray

    Write-Host "    .. adding user WINGTIP\$userLoginName to group $localRdpGroup..." -ForegroundColor Gray
    ([ADSI]"WinNT://$localComputerName/$localRdpGroup,group").Add("WinNT://WINGTIP/$userLoginName")
    Write-Host "    WINGTIP\$userLoginName added to local group $localRdpGroup" -ForegroundColor Gray
  }
}

if ($addToDomainAdminsUserGroup){
  Write-Host
  Write-Host " (3) Verify $userDisplayName in local group $domainAdminsGroup" -ForegroundColor White
  Write-Host "    .. checking if $userDisplayName in group $domainAdminsGroup..." -ForegroundColor Gray
  #find group
  $localComputerName = $env:COMPUTERNAME
  $computer = [ADSI]"WinNT://$localComputerName,computer"
  $localGroup = $computer.psbase.Children | 
                    Where-Object {$_.psbase.schemaclassname -eq "group"} | 
                    Where-Object {$_.Path -eq "WinNT://WINGTIP/$localComputerName/$domainAdminsGroup"}
  $foundUser = $false
  #walk thru all members in group until find item
  $localGroup.Members() | ForEach-Object {
    $groupMemberName = $_.GetType().InvokeMember("Name", "GetProperty", $null, $_, $null)
    if ($groupMemberName -eq $userLoginName) {$foundUser = $true}
  }
  if ($foundUser -eq $true) {
    Write-Host "    Found WINGTIP\$userLoginName in group $domainAdminsGroup" -ForegroundColor Gray
  } else {
    Write-Host "    WINGTIP\$userLoginName not in group $domainAdminsGroup" -ForegroundColor Gray

    Write-Host "    .. adding user WINGTIP\$userLoginName to group $domainAdminsGroup..." -ForegroundColor Gray
    ([ADSI]"WinNT://$localComputerName/$domainAdminsGroup,group").Add("WinNT://WINGTIP/$userLoginName")
    Write-Host "    WINGTIP\$userLoginName added to local group $domainAdminsGroup" -ForegroundColor Gray
  }
}