<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1.ascx.cs" Inherits="ExcelOData.VisualWebPart1.VisualWebPart1" %>


<script type="text/javascript" language="javascript" src="/_layouts/15/ExcelOData/jquery-1.6.2.min.js"></script>

<div id="resultsDiv">Loading...</div>

<script type="text/javascript">
    $(document).ready(function () {
        var e = ExecuteOrDelayUntilScriptLoaded(showSheet, "sp.js");
    });

    function showSheet() {

        Results = {
            element: '',
            url: '',

            init: function (element) {
                Results.element = element;
                Results.url = _spPageContextInfo.webAbsoluteUrl + "/_vti_bin/ExcelRest.aspx/Shared%20Documents/MiniCRM.xlsx/OData/Table1";
            },

            load: function () {
                $.ajax(
                    {
                        url: Results.url,
                        method: "GET",
                        headers: {
                            "accept": "application/json",
                        },
                        success: Results.onSuccess,
                        error: Results.onError
                    }
                );
            },

            onSuccess: function (data) {
                var results = data.d.results;
                var html = "<table>";

                for (var i = 0; i < results.length; i++) {
                    html += "<tr><td>";
                    html += results[i].ns1FullName;
                    html += "</td><td>"
                    html += results[i].ns1Email;
                    html += "</td><tr>";
                }

                html += "</table>";
                Results.element.html(html);
            },

            onError: function (err) {
                alert(JSON.stringify(err));
            }
        }

        Results.init($('#resultsDiv'));
        Results.load();
    }
</script>
