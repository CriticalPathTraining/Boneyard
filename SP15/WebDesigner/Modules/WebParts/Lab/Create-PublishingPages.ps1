function Import-PublishingPage {
    param (
        $SiteUrl = $(throw "Required parameter -SiteUrl missing"),
        $PageName = $(throw "Required parameter -PageName missing"),
        $PageLayout = $(throw "Required parameter -PageLayout missing"),
        $Details

    )
 
    $site = New-Object Microsoft.SharePoint.SPSite($SiteUrl)
    $psite = New-Object Microsoft.SharePoint.Publishing.PublishingSite($site)
    $web = Get-SPWeb $SiteUrl
    $pweb = [Microsoft.SharePoint.Publishing.PublishingWeb]::GetPublishingWeb($web)
    $pagesListName = $pweb.PagesListName
 
    # get prerequisites
    $pageName = $PageName
    if (-not($pageName)) {
        Write-Host -ForegroundColor DarkRed "Error: Missing Page Name"
        throw "Page name parameter missing"
    }
 
    #$plDefinition = $PageXml.Module.File.Property | Where { $_.Name -eq "PublishingPageLayout" }
    $pagelayoutUrl = $PageLayout.SubString(0,$PageLayout.IndexOf(","))
    $pagelayoutFileName = $pagelayoutUrl.SubString($PageLayout.LastIndexOf("/")+1)
    $pagelayoutTitle = $PageLayout.SubString($PageLayout.IndexOf(",")+1)
    if (-not($pagelayoutUrl)) {
        Write-Host -ForegroundColor DarkRed "Error: Missing Page Layout"
        throw "Page Layout reference missing"
    }
         
    $pl = $psite.GetPageLayouts($false) | Where { $_.Name -eq $pagelayoutFileName }
 
    if (-not($pl)) {
        Write-Host -ForegroundColor DarkRed "Error: Page Layout not found" $plName
        throw "Page Layout '$plName' not found"
    }
 
    [Microsoft.SharePoint.Publishing.PublishingPage]$page = $null
    $file = $web.GetFile("$pagesListName/$pageName")
    if (-not($file.Exists)) {
        Write-Host "Page $pageName not found. Creating..." -NoNewline
        $page = $pweb.AddPublishingPage($pageName, $pl)
        Write-Host "DONE" -ForegroundColor Green
    }
    else {
        Write-Host "Configuring '$($file.ServerRelativeUrl)'..."
        $item = $file.Item
        $page = [Microsoft.SharePoint.Publishing.PublishingPage]::GetPublishingPage($item)
        if ($page.ListItem.File.CheckOutStatus -eq [Microsoft.SharePoint.SPFile+SPCheckOutStatus]::None) {
            $page.CheckOut()
        }
    }
 

    if ($false) {
        Write-Host "`tImporting Web Parts..." -NoNewline
 
        # fake context
        [System.Web.HttpRequest] $request = New-Object System.Web.HttpRequest("", $web.Url, "")
        $sw = New-Object System.IO.StringWriter
        $hr = New-Object System.Web.HttpResponse($sw)
        [System.Web.HttpContext]::Current = New-Object System.Web.HttpContext($request, $hr)
        [Microsoft.SharePoint.WebControls.SPControl]::SetContextWeb([System.Web.HttpContext]::Current, $web)
 
        $wpMgr = $web.GetLimitedWebPartManager("$pagesListName/$pageName", [System.Web.UI.WebControls.WebParts.PersonalizationScope]::Shared)
        foreach ($webPartDefinition in $PageXml.Module.File.AllUsersWebPart) {
            $err = $null
            $sr = New-Object System.IO.StringReader($webPartDefinition.InnerText)
            $xtr = New-Object System.Xml.XmlTextReader($sr);
            $wp = $wpMgr.ImportWebPart($xtr, [ref] $err)
            $oldWebPartId = $webPartDefinition.ID.Trim("{", "}")
            $wp.ID = "g_" + $oldWebPartId.Replace("-", "_")
            $wpMgr.AddWebPart($wp, $webPartDefinition.WebPartZoneID, $webPartDefinition.WebPartOrder)
            Write-Host "." -NoNewline
        }
 
        [System.Web.HttpContext]::Current = $null
        Write-Host "`n`tWeb Parts successfully imported"
    }
    else {
        Write-Host "`tNo Web Parts found"
    }
 
    if ($Details)
    {
        Write-Host "`tImporting content..."
        $li = $page.ListItem
        $Details.GetEnumerator() | ForEach-Object {
            Write-Host "`t$($_.Key)..." -NoNewline
            $field = $li.Fields.GetField($_.Key)
            if (-not($field.IsReadOnlyField)) {
                Write-Host $field.FieldTypeDefinition.TypeDisplayName "($($field.FieldValueType.FullName))" -ForegroundColor Cyan
                try 
                {
                    if ($field.FieldTypeDefinition.TypeDisplayName -eq "Publishing Image")
                    {
                        $value = new-object Microsoft.SharePoint.Publishing.Fields.ImageFieldValue
                        $value.ImageUrl = $_.Value
                        if ($_.Value) {
                            #$li[$_.Key] = $value
                            $li[$_.Key] = $value.ToString()
                            Write-Host "DONE" -ForegroundColor Green
                        }
                    }
                    else
                    {
                        $value = $field.GetValidatedString($_.Value.Replace("~SiteCollection/", $site.ServerRelativeUrl).Replace("~Site/", $web.ServerRelativeUrl))
                        if ($_.Value) {
                            $li[$_.Key] = $value
                            Write-Host "DONE" -ForegroundColor Green
                        }
                        else {
                            Write-Host "SKIPPED (Invalid value)" -ForegroundColor Red
                        }
                    }
                }
                catch {
                    Write-Host "SKIPPED (Invalid value)" -ForegroundColor Red
                }
            }
            else {
                Write-Host "SKIPPED (ReadOnly)" -ForegroundColor Red
            }
        }
        $li.Update()
        Write-Host "`tContent import completed" -ForegroundColor Green
    }
 
    $page.CheckIn("")
    $file = $page.ListItem.File
    $file.Publish("")
    if ($file.Level -eq "Draft")
    {
        $file.Approve("")
    }
 
    Write-Host "Page successfully imported" -ForegroundColor Green
}

$pageContent = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla non auctor neque, ac sollicitudin lacus. Maecenas vitae iaculis eros, non suscipit nulla. Sed pellentesque euismod nulla. In in tellus at magna bibendum sollicitudin id sed orci. Nunc eget aliquam odio. Nunc at facilisis sem, eu pharetra est. Aenean sit amet risus in lectus fringilla tincidunt id ac lacus. Nunc adipiscing scelerisque diam tincidunt rutrum.</p>
`<p>Fusce porttitor tincidunt erat, id malesuada justo ultricies ac. Cras sed turpis euismod, egestas elit a, faucibus enim. Nam tempor adipiscing suscipit. Proin varius venenatis magna quis adipiscing. Morbi in pellentesque ipsum. Praesent tortor augue, viverra et eros in, semper vestibulum lectus. Sed dictum mi non mauris pellentesque, accumsan eleifend neque sagittis. Morbi eu egestas nunc. Integer et leo consequat neque hendrerit dignissim eu eu mauris. Donec vitae hendrerit libero, vel facilisis magna. Integer eu eros varius magna sagittis pretium ac consectetur eros. Nullam blandit dictum eros tincidunt consectetur. Curabitur eget eros vitae odio elementum condimentum eget sed arcu. Mauris urna magna, accumsan vitae euismod a, vulputate vitae justo.</p>
`<p>Aliquam congue mauris vitae accumsan tempus. Mauris molestie mauris odio, sit amet accumsan orci accumsan vitae. Nunc quis lobortis enim. Phasellus fringilla, eros sit amet fermentum posuere, tortor orci volutpat nisl, et placerat nunc mi quis mauris. Pellentesque tincidunt et felis ut porta. Cras commodo quis lorem ac lacinia. Nunc feugiat risus et turpis posuere auctor. Donec eget dolor faucibus, feugiat dolor a, cursus velit. Suspendisse id sagittis lectus. Vestibulum euismod ac erat ac vestibulum. Duis id adipiscing dolor, a feugiat diam. Morbi eu egestas tortor.</p>
`<p>Aenean facilisis a lectus nec interdum. Nam egestas purus nec tristique tincidunt. Aenean lacus ipsum, luctus id ornare adipiscing, mollis sed dolor. Suspendisse potenti. Integer in nibh egestas, congue velit porttitor, tincidunt augue. Fusce vitae lectus ac massa vestibulum vulputate. Vestibulum quis suscipit justo, id adipiscing libero. Vivamus pretium id sapien vel luctus. Curabitur iaculis malesuada blandit. Aenean ipsum elit, vehicula eu risus sed, venenatis pulvinar nisl. Vivamus consequat ac diam eget rutrum. Nulla eget lobortis dui, eu porta felis. Donec ullamcorper tellus vitae ipsum tincidunt, in elementum erat laoreet. Pellentesque ante justo, pharetra vel commodo vitae, iaculis ac nulla. Aliquam volutpat rhoncus lectus in suscipit. Cras ipsum eros, adipiscing in vehicula quis, placerat eget odio.</p>"

#$sitepages = @("Details1g", "More-Details1g", "Better-News1g")
 
#$sitepages.GetEnumerator() | % {
    #WelcomeSplash
    #WelcomeLinks
    #BlankWebPartPage
    #$pageDef = "~SiteCollection/_catalogs/masterpage/BlankWebPartPage.aspx,Blank Web Part Page"
#    $pageDef = "~SiteCollection/_catalogs/masterpage/ArticleLeft.aspx,Article Page"
#    $pageDetails = @{"Title"="Good News"; "Comments"="This is a description"; "PublishingRollupImage"="/News/PublishingImages/WP0001.jpg"; "PublishingPageContent"="$($pageContent)"; "ArticleStartDate"="1/28/2014"; "ArticleByLine"="Austin, TX"; "PublishingContactName"="Matthew McDermott"}
#    Import-PublishingPage "http://www.wingtip.com/News" -PageName "$($_).aspx" -PageLayout $pageDef -Details $pageDetails
#}
 



