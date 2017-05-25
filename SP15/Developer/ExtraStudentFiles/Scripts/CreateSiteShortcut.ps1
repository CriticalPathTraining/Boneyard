# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=
#       Script: CreateSiteShortcut.ps1
#
#       Author: Critical Path Training, LLC
#               http://www.CriticalPathTraining.com
#
#  Description: Creates a shortcut for the specified URL in the Modules folder for the Favorites Bar.
#
#   Parameters: $TargetUrl - Fully qualified URL of the location where to create the site collection
# =+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=

param(
	[string]$TargetUrl
)

$ErrorActionPreference = 'Stop'

# make sure folders exist
$favoritesRoot = Join-Path -Path $HOME -ChildPath "Favorites/Links"
$favoritesRoot = Join-Path -Path $favoritesRoot -ChildPath "Modules"
if (Test-Path -Path $favoritesRoot){} else { New-Item -Path $favoritesRoot -ItemType Directory | Out-Null }

$site = $TargetUrl -replace "http://", ""
$shortcutPath = $site -replace "-", ""
$shortcutPath = [string]::Format("{0}.url", $shortcutPath)
$shortcutPath = Join-Path -Path $favoritesRoot -ChildPath $shortcutPath

# create file
if (Test-Path -Path $shortcutPath) {} else {
    New-Item -Path $shortcutPath -ItemType File

    # create file contents
    $shortcutConents = @()
    $shortcutConents += "[DEFAULT]"
    $shortcutConents += [string]::Format("BASEURL={0}", $site)
    $shortcutConents += "[InternetShortcut]"
    $shortcutConents += [string]::Format("URL={0}", $TargetUrl)
    $shortcutConents += [string]::Format("IconFile=http://{0}/_layouts/15/images/favicon.ico", $site)
    $shortcutConents += "IconIndex=1"

    $shortcutConents | ForEach-Object {
      Add-Content -Path $shortcutPath -Value $_
    }
}
