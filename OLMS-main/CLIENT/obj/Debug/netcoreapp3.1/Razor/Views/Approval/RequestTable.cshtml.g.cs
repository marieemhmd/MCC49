#pragma checksum "C:\Users\lenovo\Downloads\OLMS-main\CLIENT\Views\Approval\RequestTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82c2ac0f5dba287b291ffbd5c070a5fcfef501b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Approval_RequestTable), @"mvc.1.0.view", @"/Views/Approval/RequestTable.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\lenovo\Downloads\OLMS-main\CLIENT\Views\_ViewImports.cshtml"
using CLIENT;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lenovo\Downloads\OLMS-main\CLIENT\Views\_ViewImports.cshtml"
using CLIENT.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82c2ac0f5dba287b291ffbd5c070a5fcfef501b1", @"/Views/Approval/RequestTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffe964b7c289c35c556836e61e59e9c46c33c90c", @"/Views/_ViewImports.cshtml")]
    public class Views_Approval_RequestTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\lenovo\Downloads\OLMS-main\CLIENT\Views\Approval\RequestTable.cshtml"
  
    Layout = "_LayoutAdmin";
    ViewData["Title"] = "RequestTable";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-body"">
                <h4 class=""card-title"">Data Export</h4>
                <h6 class=""card-subtitle"">Export data to Copy, CSV, Excel, PDF & Print</h6>
                <div class=""table-responsive m-t-40"">
                    <table id=""table_id"" class=""display nowrap table table-hover table-striped table-bordered"" cellspacing=""0"" width=""100%"">
                        <thead>
                            <tr>
                                <th>No</th>
                                <th>Id</th>
                                <th>NIK</th>
                                <th>Reason Request</th>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th>Request Status</th>
                                <th>Notes</th>
                                <th>Actions</th>
                            </tr>
                        </thead>");
            WriteLiteral(@"
                        <tbody>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th>No</th>
                                <th>Id</th>
                                <th>NIK</th>
                                <th>Reason Request</th>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th>Request Status</th>
                                <th>Notes</th>
                                <th>Actions</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"

    <script>
        $(document).ready(function () {
            var dataTable = $('#table_id').DataTable({
                ""filter"": true,
                ""orderMulti"": false,
                dom: 'Bfrtip',
                buttons: ['copy', 'csv', 'excel', 'pdf', 'print'],
                ""ajax"": {
                    ""url"": ""/request/get"",
                    ""type"": ""GET"",
                    ""dataSrc"": ""data""
                },
                language: {
                    searchPlaceholder: ""Search...""
                },
                ""columnDefs"": [
                    {
                        ""targets"": [1],
                        ""visible"": false,
                    },
                    {
                        ""targets"": [1,2,3,4,5,7,8],
                        ""orderable"": false,
                    }
                ],
                ""columns"": [
                    {
                        ""data"": null,
                        ""render"": function (data, type, row, meta) {
            ");
                WriteLiteral(@"                return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    },
                    { ""data"": 'id' },
                    {
                        ""data"": 'niK_Employee',
                    },
                    { ""data"": 'reasonRequest' },
                    {
                        ""data"": 'startDate',
                        ""render"": function (data, type, row) {
                            return moment(data).format('DD MMMM YYYY');
                        }
                    },
                    {
                        ""data"": 'endDate',
                        ""render"": function (data, type, row) {
                            return moment(data).format('DD MMMM YYYY');
                        }
                    },
                    {
                        ""data"": 'requestStatus',
                        ""render"": function (data, type, row) {
                            if (data == 0) {
                                return ""<div cla");
                WriteLiteral(@"ss='text-center'><button value='0' class='btn-sm btn-info'>Waiting</button></div>""
                            }
                            else if (data == 1) {
                                return ""<div class='text-center'><button value='1' class='btn-sm btn-success'>Approved - HRD</button></div>""
                            }
                                else if (data == 2) {
                                return ""<div class='text-center'><button value='1' class='btn-sm btn-danger'>Rejected - HRD</button></div>""
                            }
                                else if (data == 3) {
                                return ""<div class='text-center'><button value='1' class='btn-sm btn-success'>Approved - Manager</button></div>""
                            }
                            else if (data == 4) {
                                return ""<div class='text-center'><button value='4' class='btn-sm btn-danger'>Rejected - Manager</button></div>""
                            }
             ");
                WriteLiteral(@"           }
                    },
                    { ""data"": 'notes' },
                    {
                        ""data"": 'niK_Employee',
                        ""render"": function (data, type, row, meta) {
                            return '<a class=""btn btn-info"" data-toggle=""tooltip"" data-placement=""top"" title=""Details ' + row['fullName'] + '""  onclick=""Get(\'' + row['nik'] + '\')""><i class =""far fa-info-circle""></i> Details</a> '
                        }
                    }
                ]
            });
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591