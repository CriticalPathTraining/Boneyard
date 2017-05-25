Clear-Host

Add-PSSnapin Microsoft.SharePoint.PowerShell -ErrorAction SilentlyContinue
. .\Create-PublishingPages.ps1

Write-Host "Creating News Publishing Site"

$siteCollectionUrl = "http://www.wingtip.com"
$siteTemplateNews = "BLANKINTERNET#1"
$SiteCollectionLanguage = 1033

$SiteUrl = $siteCollectionUrl + "/News" 
Write-Host " "


$web = Get-SPWeb -Site $siteCollectionUrl | Where-Object {$_.Url -eq $SiteUrl}
if ($web -ne $null) {
  Write-Host "Deleting existing News web at $siteUrl..." -ForegroundColor Red
  Remove-SPWeb -Identity $web -Confirm:$false
}


Write-Host "Creating Site for News"
$newsWeb = New-SPWeb $SiteUrl -Template $siteTemplateNews -Name "Press Releases"  -UseParentTopNav -Language $SiteCollectionLanguage
Write-Host "Site Created for News" -ForegroundColor Green
Write-Host " "

Write-Host " Uploading Images" -ForegroundColor Yellow
$imagesList = $newsWeb.Lists["Images"]
Get-ChildItem -Path .\Images | foreach {

    $bytes = [System.IO.File]::ReadAllBytes($_.FullName)
    $imgfile = $imagesList.RootFolder.Files.Add($_.Name, $bytes) 
    Write-Host " Uploading Image" $_.Name -ForegroundColor Yellow
    $imgfile.CheckIn("First Version")
    $imgfile.Publish("")
    if ($imgfile.Level -eq "Draft")
    {
        $imgfile.Approve("")
    }

}

Write-Host " Creating News Pages"
$sitepages = @("Action-Figure", "Stocks-Climb", "Record-Quarter")
$pageValues = @( @{"Title"="New Action Figure"; "Comments"="This is the Page Comments"; "PublishingRollupImage"="/News/PublishingImages/WP0001.jpg"; "PublishingPageContent"="$($pageContent)"; "ArticleStartDate"="1/28/2014"; "ArticleByLine"="Austin, TX"; "PublishingContactName"="Matthew McDermott"},
@{"Title"="Stock Prices Rise"; "Comments"="You can put comments here."; "PublishingRollupImage"="/News/PublishingImages/WP0002.jpg"; "PublishingPageContent"="$($pageContent)"; "ArticleStartDate"="1/26/2014"; "ArticleByLine"="Tampa, FL"; "PublishingContactName"="Ted Pattison"},
@{"Title"="Record Quarter for Wingtip Toys"; "Comments"="This is for comments"; "PublishingRollupImage"="/News/PublishingImages/WP0003.jpg"; "PublishingPageContent"="$($pageContent)"; "ArticleStartDate"="1/24/2014"; "ArticleByLine"="Austin, TX"; "PublishingContactName"="Katie Bowman"})

 
$sitepages.GetEnumerator() | % {
    $pageDef = "~SiteCollection/_catalogs/masterpage/ArticleLeft.aspx,Article Page"
    $pageDetails = $pageValues[$sitepages.IndexOf($_)]
    Import-PublishingPage $SiteUrl -PageName "$($_).aspx" -PageLayout $pageDef -Details $pageDetails
}


#Kick off a crawl
$contentSource = Get-SPEnterpriseSearchServiceApplication | Get-SPEnterpriseSearchCrawlContentSource -Identity 1
$contentSource.StartFullCrawl()