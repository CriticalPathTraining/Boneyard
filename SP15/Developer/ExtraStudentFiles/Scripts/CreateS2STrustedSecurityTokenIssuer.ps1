Add-PSSnapin Microsoft.SharePoint.PowerShell -ErrorAction SilentlyContinue

$issuerID = [Guid]::NewGuid().ToString()
Write-Host "IssuerID: $issuerID"

# get the authentication realm (eg: works only for WINGTIP not CONTOSO)
$realm = Get-SPAuthenticationRealm -ServiceContext "http://dev.wingtip.com"

# get full name of the identifier (app ID + realm)
$fullIssuerID = $issuerID + '@' + $realm

# create STS issuer for cert that can be used for all apps
$certificate = Get-PfxCertificate -LiteralPath "c:\Dev\HighTrustCertificate.cer"
New-SPTrustedSecurityTokenIssuer -Name $issuerID -Certificate $certificate -IsTrustBroker -RegisteredIssuerName $fullIssuerID