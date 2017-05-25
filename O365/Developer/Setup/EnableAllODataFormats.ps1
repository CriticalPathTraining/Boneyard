$configOwnerName = "JSONLightDependentAssembly"

$spWebConfigModClass ="Microsoft.SharePoint.Administration.SPWebConfigModification"

$dependentAssemblyPath ="configuration/runtime/*[local-name()='assemblyBinding' and namespace-uri()='urn:schemas-microsoft-com:asm.v1']"
$dependentAssemblyNameStart ="*[local-name()='dependentAssembly'][*/@name='"
$dependentAssemblyNameEnd = "'][*/@publicKeyToken='31bf3856ad364e35'][*/@culture='neutral']"
$dependentAssemblyValueStart = "<dependentAssembly><assemblyIdentity name='"
$dependentAssemblyValueEnd ="' publicKeyToken='31bf3856ad364e35' culture='neutral' /><bindingRedirect oldVersion='5.0.0.0' newVersion='5.6.0.0' /></dependentAssembly>"

$edmAssemblyName ="Microsoft.Data.Edm"
$odataAssemblyName ="Microsoft.Data.Odata"
$dataServicesAssemblyName ="Microsoft.Data.Services"
$dataServicesClientAssemblyName ="Microsoft.Data.Services.Client"
$spatialAssemblyName ="System.Spatial"

$assemblyNamesArray = $edmAssemblyName,$odataAssemblyName,$dataServicesAssemblyName,$dataServicesClientAssemblyName, $spatialAssemblyName


Add-PSSnapin Microsoft.SharePoint.Powershell
$webService = [Microsoft.SharePoint.Administration.SPWebService]::ContentService

################ Adds individual assemblies ####################

For ($i=0; $i -lt 5; $i++)  
{
    echo "Adding Assembly..."$assemblyNamesArray[$i]

    $dependentAssembly = New-Object $spWebConfigModClass
    $dependentAssembly.Path=$dependentAssemblyPath
    $dependentAssembly.Sequence =0 # First item to be inserted
    $dependentAssembly.Owner = $configOwnerName
    $dependentAssembly.Name =$dependentAssemblyNameStart + $assemblyNamesArray[$i] + $dependentAssemblyNameEnd
    $dependentAssembly.Type = 0 #Ensure Child Node
    $dependentAssembly.Value = $dependentAssemblyValueStart + $assemblyNamesArray[$i] + $dependentAssemblyValueEnd

    $webService.WebConfigModifications.Add($dependentAssembly)
}

###############################################################

echo "Saving Web Config Modification"

$webService.Update()
$webService.ApplyWebConfigModifications()

echo "Update Complete"
