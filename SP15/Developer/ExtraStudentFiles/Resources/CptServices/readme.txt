No NuGet packages are included in this project in order to minimuze the distribution package.
In order to build this project will need to download all referenced NuGet packages used in the project.
To do this
	> open the solution in Visual Studio 2012
	> [within VS 2012] Tools > Library Package Manager > Package Manager Console
	> in the Package Manager Console tool window that appears, click the RESTORE button
This will trigger NuGet to download all packages referenced in the packages.config file, but not currently residing in your system.


Because WCF Data Services does not support the $format operator, added HTTP module to rewrite the request by stripping $format from the URL & adding it as a ACCEPT HTTP Header. 
See this:
http://josheinstein.com/blog/index.php/2010/05/wcf-data-services-format-json/
Tweaked because WCF Data Services 5.0 RTM doesn't accept application/json anymore, now only accepts application/json;odata=verbose
http://blogs.msdn.com/b/astoriateam/archive/2012/04/09/wcf-data-services-5-0-rtm-release.aspx
> search for explination dated April 10 2012 @2:07p by Matt Meehan [MSFT] for explination