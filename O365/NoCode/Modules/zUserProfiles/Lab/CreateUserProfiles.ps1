## Add-PSSnapin Microsoft.SharePoint.PowerShell
if (-not (Get-PSSnapin Microsoft.SharePoint.PowerShell -ErrorAction SilentlyContinue)) {
    Add-PSSnapin Microsoft.SharePoint.PowerShell -ErrorAction SilentlyContinue
	if (-not $?) {
		Write-Host $error[0].Exception.Message -ForegroundColor Red -BackgroundColor Cyan
		return
	}
}
		

##Get the Server Context
$context = Get-SPServiceContext -Site http://my.wingtip.com

## Get the User Profile Manager
$upm = New-Object Microsoft.Office.Server.UserProfiles.UserProfileManager($context)

##Read XML File
[xml]$userfile = Get-Content UserProfiles.xml 
##Create the User Profile
foreach( $user in $userfile.Users.User) 
{ 
	Write-Host "Checking User Profile: " $user.Name
	
	if (-not $upm.UserExists("wingtip\$($user.Name)"))
    {
        Write-Host "User profile does not exist: " $user.Name
        continue
	}
	else
	{
		Write-Host "Updating User Profile: " $user.Name
		$up = $upm.GetUserProfile("wingtip\$($user.Name)")
	}
	##Update from AD
	##Update from XML
	$up["AboutMe"].Value = $user.AboutMe
	$up["SPS-Responsibility"].Value = $user.Responsabilities.Split(";")
	$up["SPS-Skills"].Value = $user.Skills.Split(";")
	$up["SPS-Interests"].Value = $user.Interests.Split(";")
	$up["SPS-HireDate"].Value = $user.HireDate
	$up["SPS-TimeZone"].Value = $user.TimeZone
	$up["SPS-PastProjects"].Value = $user.PastProjects.Split(";")
	$up["SPS-School"].Value = $user.School
	$up["SPS-Birthday"].Value = $user.Birthday
	$up["SPS-Location"].Value = $user.OfficeLocation
    $up["WorkEmail"].Value = $user.EMail
	#$up["PictureURL"].Value = "http://my.wingtip.com:80/User Photos/Profile Pictures/wingtip_$($user.Name)_MThumb.jpg"
    #$up["PictureURL"].Value = "http://my.wingtip.com:80/User Photos/Profile Pictures/$($user.Name).jpg"
		                           
	Write-Host "Creating Personal Site"
	#$up.CreatePersonalSite()
	if ($up.PersonalSite -eq $null)
	{
		"Personal Site does not exist.  Creating Personal Site..."
		#$up.CreatePersonalSite();
	}
	else
	{
		"Personal Site exists.  Fetching Personal Site..."
	}
	Write-Host "Commiting User Profile: " $up["PreferredName"]
	$up.Commit()
}		


#How'd we do?
$upm.GetEnumerator() | ft DisplayName, PersonalSite

##Update Photo Store
Update-SPProfilePhotoStore -MySiteHostLocation http://my.wingtip.com/ 

