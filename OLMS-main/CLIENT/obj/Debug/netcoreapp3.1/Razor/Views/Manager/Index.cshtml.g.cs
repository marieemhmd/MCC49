#pragma checksum "C:\Users\lenovo\Downloads\OLMS-main\CLIENT\Views\Manager\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d800e3215678ba7bb2f06af224c7f2356901229"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_Index), @"mvc.1.0.view", @"/Views/Manager/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d800e3215678ba7bb2f06af224c7f2356901229", @"/Views/Manager/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffe964b7c289c35c556836e61e59e9c46c33c90c", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\lenovo\Downloads\OLMS-main\CLIENT\Views\Manager\Index.cshtml"
  
    Layout = "_LayoutAdmin";
    ViewData["Title"] = "Manager's Table";

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
                                <th>Name</th>
                                <th>Reason Request</th>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th>Status</th>
                                <th>Notes</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
      ");
            WriteLiteral(@"                  <tbody>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th>No</th>
                                <th>Id</th>
                                <th>Name</th>
                                <th>Reason Request</th>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th>Status</th>
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
            WriteLiteral("<div class=\"modal fade\" role=\"dialog\" id=\"modal\">\n    <div class=\"modal-dialog modal-lg\">\n        <div class=\"modal-content\">\n            <div class=\"modal-body\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d800e3215678ba7bb2f06af224c7f23569012296825", async() => {
                WriteLiteral(@"
                    <div class=""form-body"">
                        <h3 class=""box-title"">Requester Info</h3>
                        <hr class=""m-t-0 m-b-40"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""form-group row"">
                                    <label class=""control-label text-right col-md-4"">NIK</label>
                                    <div class=""col-md-7"">
                                        <p class=""form-control-static"" id=""NIK"" name=""nik""> Loading... </p>
                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                            <div class=""col-md-6"">
                                <div class=""form-group row"">
                                    <label class=""control-label text-right col-md-3"">Name</label>
                                    <div class=""col-md-7"">
                  ");
                WriteLiteral(@"                      <p class=""form-control-static"" id=""FullName"" name=""FullName""> Loading... </p>
                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                        </div>
                        <!--/row-->
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""form-group row"">
                                    <label class=""control-label text-right col-md-4"">Email</label>
                                    <div class=""col-md-7"">
                                        <p class=""form-control-static"" id=""Email"" name=""Email""> Loading... </p>
                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                            <div class=""col-md-6"">
                                <div class=""form-group row"">
     ");
                WriteLiteral(@"                               <label class=""control-label text-right col-md-3"">Leave Quota</label>
                                    <div class=""col-md-7"">
                                        <p class=""form-control-static"" id=""RemainingQuota"" name=""RemainingQuota""> Loading... </p>
                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                        </div>
                        <!--/row-->
                        <h3 class=""box-title"">Details Request</h3>
                        <hr class=""m-t-0 m-b-40"">
                        <!--/row-->
                        <div class=""row"">
                            <div class=""col-md-6"" hidden>
                                <div class=""form-group row"">
                                    <label class=""control-label text-right col-md-2""> Request ID</label>
                                    <div class=""col-md-7"">
                                ");
                WriteLiteral(@"        <input type=""text"" class=""form-control-static"" id=""id"" name=""id"">
                                    </div>
                                </div>
                            </div>
                            <div class=""col-md-6"">
                                <div class=""form-group row"">
                                    <label class=""control-label text-right col-md-4"">Request ID</label>
                                    <div class=""col-md-7"">
                                        <p type=""text"" class=""form-control-static"" id=""ID"" name=""ID""></p>
                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                            <div class=""col-md-6"">
                                <div class=""form-group row"">
                                    <label class=""control-label text-right col-md-3"">Request Type</label>
                                    <div class=""col-md-7"">
                 ");
                WriteLiteral(@"                       <p class=""form-control-static"" id=""Reason"" name=""Reason""> Loading... </p>
                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                        </div>
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""form-group row"">
                                    <label class=""control-label text-right col-md-4"">Start Date</label>
                                    <div class=""col-md-7"">
                                        <p class=""form-control-static"" id=""StartDate"" name=""StartDate"">Loading...</p>
                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                            <div class=""col-md-6"">
                                <div class=""form-group row"">
                                 ");
                WriteLiteral(@"   <label class=""control-label text-right col-md-3"">End Date</label>
                                    <div class=""col-md-7"">
                                        <p class=""form-control-static"" id=""EndDate"" name=""EndDate""> Loading... </p>
                                    </div>
                                </div>
                            </div>
                            <!--/span-->
                        </div>
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""form-group row"">
                                    <label class=""control-label text-right col-md-4"">Submited Date</label>
                                    <div class=""col-md-7"">
                                        <p class=""form-control-static text-justify"" id=""DateRequest"" name=""DateRequest""> Loading... </p>
                                    </div>
                                </div>
                            </div>
                 ");
                WriteLiteral(@"           <div class=""col-md-6"">
                                <div class=""form-group row"">
                                    <label class=""control-label text-right col-md-2"">Notes</label>
                                    <div class=""col-md-8"">
                                        <p class=""form-control-static text-justify"" id=""Notes"" name=""Notes""> Loading... </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--Notes from manager-->
                    <hr />
                    <div class=""form-group"">
                        <h5>Note</h5>
                        <div class=""controls"">
                            <textarea name=""RejectedNotes"" id=""RejectedNotes"" class=""form-control"" required
                                      placeholder=""Enter your notes""></textarea>
                        </div>
                        <small class=""text-dange");
                WriteLiteral(@"r"">Enter a note if you reject the request for leave ...</small>
                    </div>

                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-success"" onclick=""approve()""> <i class=""fa fa-check""></i> Approve</button>
                        <button type=""button"" class=""btn btn-danger"" onclick=""reject()""> <i class=""fa fa-close""></i> Reject</button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </div>\n        </div>\n    </div>\n</div>\n");
            WriteLiteral("\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        debugger;
        $(document).ready(function () {
            var dataTable = $('#table_id').DataTable({
                ""filter"": true,
                ""orderMulti"": false,
                dom: 'Bfrtip',
                buttons: ['copy', 'csv', 'excel', 'pdf', 'print'],
                ""ajax"": {
                    ""url"": ""/request/ActionManager"",
                    ""type"": ""GET"",
                    ""dataSrc"": ""data""
                },
                language: {
                    searchPlaceholder: ""Search...""
                },
                ""columnDefs"": [
                    {
                        ""targets"": [0, 6],
                        ""width"": ""5%"",
                    },
                    {
                        ""targets"": [7, 1],
                        ""visible"": false,
                    },
                    {
                        ""targets"": [1, 2, 3, 4, 5, 6, 7, 8],
                        ""orderable"": false,
                    }
                ],
    ");
                WriteLiteral(@"            ""columns"": [
                    {
                        ""data"": null,
                        ""render"": function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    },
                    { ""data"": 'id' },
                    {
                        ""data"": 'username'                        
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
                    ");
                WriteLiteral(@"    ""data"": 'requestStatus',
                        ""render"": function (data, type, row) {
                            if (data == 0) {
                                return ""<div class='text-center'><button value='0' class='btn-sm btn-info'>Waiting</button></div>""
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
          ");
                WriteLiteral(@"                      return ""<div class='text-center'><button value='4' class='btn-sm btn-danger'>Rejected - Manager</button></div>""
                            }
                        }
                    },
                    { ""data"": 'notes' },
                    {
                        ""data"": 'id',
                        ""render"": function (data, type, row, meta) {
                            return '<a data-toggle=""modal"" data-target=""#modal"" class=""btn btn-outline-info text-warning"" data-toggle=""tooltip"" data-placement=""top"" title=""Details ' + '""  onclick=""Get(\'' + row['id'] + '\')""><i class=""fas fa-info""></i>  Details</a> '
                        }
                    }
                ]
            });
        });
        function Get(id) {
            $.ajax({
                url: ""/Request/GetById"",
                type: ""GET"",
                data: { 'id': id },
                success: function (data) {
                    $('#modal').modal('show');
                    var data = data");
                WriteLiteral(@"['data'];
                    $('#id').val(data.id);
                    $('#ID').text(data.id);
                    $('#NIK').text(data.niK_Employee);
                    $('#FullName').text(data.employee.fullName);
                    $('#Email').text(data.employee.email);
                    $('#RemainingQuota').text(data.employee.remainingQuota);
                    $('#StartDate').text(moment(data.startDate).format('DD MMMM YYYY'));
                    $('#EndDate').text(moment(data.endDate).format('DD MMMM YYYY'));
                    $('#Notes').text(data.notes);
                    $('#Reason').text(data.reasonRequest);
                    $('#DateRequest').text(moment(data.dateRequest).format('DD MMMM YYYY'));
                    //console.log(data);

                }
            });
        }

        
        function approve() {
            debugger;
            var id = $('#id').val();
            Approve(id);
        }

        function reject() {
            var id = $('#id').val();
          ");
                WriteLiteral(@"  Reject(id);
        }

        function Approve(id) {
            var approve = new Object();
            approve.id = $('#id').val();
            $.ajax({
                type: ""PUT"",
                url: ""/Manager/Approve"",
                data: approve,

                success: function (data) {
                    $('#modal').modal('hide');
                    $('#table_id').DataTable().ajax.reload();
                    Swal.fire(
                        'Approved!',
                        'Request has been approved.',
                        'success'
                    )
                    //console.log(data);
                }
            })
        }

        function Reject(id) {
            //debugger;
            var reject = new Object();
            reject.id = $('#id').val();
            reject.rejectedNotes = $('#RejectedNotes').val();
            if (reject.rejectedNotes === """" || reject.rejectedNotes === "" "") {
                Swal.fire(
                    'Enter your reason reject!',");
                WriteLiteral(@"
                    'Thank you...',
                    'error'
                )
            } else {
                $.ajax({
                    type: ""PUT"",
                    url: ""/Manager/Reject"",
                    data: reject,

                    success: function (data) {
                        $('#modal').modal('hide');
                        $('#table_id').DataTable().ajax.reload();
                        //console.log(data);
                        Swal.fire(
                            'Rejected!',
                            'Request has been rejected.',
                            'success'
                        )
                    }
                })

            }
        }
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