# EXE paths
$ExeMakeCert = "C:\Program Files\Microsoft Office Servers\15.0\Tools\makecert.exe"
$ExeCertManager = "C:\Program Files\Microsoft Office Servers\15.0\Tools\certmgr.exe"
  
# create the certificate
$path = "C:\Dev"
$certificateFullPath = Join-Path -Path $path -ChildPath "HighTrustCertificate.cer"
Write-Host "  .. creating new certificate at $certificateFullPath" -ForegroundColor Gray 
& $ExeMakeCert -r -pe -n "CN=$AppDomain" -b 01/01/2012 -e 01/01/2022 -ss my -sr localMachine -sky exchange -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12 $certificateFullPath
Write-Host "  Certificate created at $certificateFullPath" -ForegroundColor Gray 
  
# get certificate thumbprint
$appCertificate = Get-PfxCertificate -FilePath $certificateFullPath

Write-Host "  .. adding certificate to local machine root" -ForegroundColor Gray 
& $ExeCertManager /add $certificateFullPath /s /r localMachine root
Write-Host "  Certificate installed on local machine" -ForegroundColor Gray 
  
Write-Host "  .. exporting private key for certificate" -ForegroundColor Gray 
Get-ChildItem cert:\\localmachine\my | Where-Object {$_.Thumbprint -eq $appCertificate.Thumbprint} | ForEach-Object {
    $CertPfxName = (Get-Item -Path $certificateFullPath).BaseName
    $CertPfxName += ".pfx"
    $certExportPath = Join-Path -Path $path -ChildPath $CertPfxName
    Write-Host "  .. exporting private key for certificate (*.PFK)" -ForegroundColor Gray 
    $certFileByteArray = $_.Export("PFX", "Password1")
    [System.IO.File]::WriteAllBytes($certExportPath, $certFileByteArray)
    Write-Host "  Certificate exported" -ForegroundColor Gray 
}