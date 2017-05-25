$makecert = "C:\Program Files\Microsoft Office Servers\15.0\Tools\makecert.exe"
$certmgr = "C:\Program Files\Microsoft Office Servers\15.0\Tools\certmgr.exe"

# specify domain name for SSL certificate
$domain = "extranet.wingtip.com"

# create output directory to create SSL certificate file
$outputDirectory = "c:\Certs\"
New-Item $outputDirectory -ItemType Directory -Force -Confirm:$false | Out-Null

# create file name for SSL certificate file
$certFileName  =  $outputDirectory + $domain + ".cer"

Write-Host 
Write-Host "Creating SSL certificate file..."
& $makecert -r -pe -n "CN=$domain" -b 01/01/2012 -e 01/01/2022 -eku 1.3.6.1.5.5.7.3.1 -ss my -sr localMachine -sky exchange -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12 $certFileName

Write-Host 
Write-Host "Registering SSL certificate with IIS set..."
& $certmgr /add $certFileName /s /r localMachine root