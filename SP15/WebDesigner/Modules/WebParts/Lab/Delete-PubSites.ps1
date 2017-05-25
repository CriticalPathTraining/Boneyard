foreach ($web in Get-SPWeb -Site http://www.wingtip.com)
{
  if (!$web.IsRootWeb)
  {
    Write-Host "Removing:" $web.Url;
    Remove-SPWeb -Identity $web.Url -Confirm:$false;
    Write-Host "Removed:" $web.Url -ForegroundColor Green;

  }
}
