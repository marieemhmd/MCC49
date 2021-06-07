#pragma checksum "C:\Users\lenovo\Downloads\OLMS-main\CLIENT\Views\Position\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "384ec92792e3385d28dd0c66c57fba3e3a543c47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Position_Index), @"mvc.1.0.view", @"/Views/Position/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"384ec92792e3385d28dd0c66c57fba3e3a543c47", @"/Views/Position/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffe964b7c289c35c556836e61e59e9c46c33c90c", @"/Views/_ViewImports.cshtml")]
    public class Views_Position_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\lenovo\Downloads\OLMS-main\CLIENT\Views\Position\Index.cshtml"
   Layout = "_LayoutAdmin";
    ViewBag.Title = "Position";

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
                    <button type=""button"" class=""mb-3 btn btn-primary text-center"" data-toggle=""modal"" data-target=""#modal"" onclick=""resetButton()"">
                        <i class=""fas fa-user-plus""></i> Add New position
                    </button>
                    <table id=""PositionTable"" class=""display nowrap table table-hover table-striped table-bordered"" cellspacing=""0"" width=""100%"">
                        <thead>
                            <tr>
                                <th>No</th>
                                <th>ID</th>
                                <th>Position</th>
                                <th>Department</th>
                                <th>Actions</th>
            ");
            WriteLiteral(@"                </tr>
                        </thead>
                        <tbody>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th>No</th>
                                <th>ID</th>
                                <th>Position</th>
                                <th>Department</th>
                                <th>Actions</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>

");
            WriteLiteral(@"            <div class=""modal fade"" role=""dialog"" id=""modal"">
                <div class=""modal-dialog"">
                    <div class=""modal-content"">
                        <div class=""modal-header"">
                            <h2 class=""modal-title"">position</h2>
                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"" onclick=""Readonly()""><span aria-hidden=""true"">&times;</span></button>
                        </div>
                        <div class=""modal-body"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "384ec92792e3385d28dd0c66c57fba3e3a543c476347", async() => {
                WriteLiteral("\n                                <div class=\"form-row\">\n                                    <div class=\"col-md-6\">\n");
                WriteLiteral(@"                                        <div class=""form-group"">
                                            <label for=""PositionName"" class=""col-form-label"">Position Name<span class=""text-danger""> *</span></label>
                                            <div class=""controls"">
                                                <input type=""text"" class=""form-control"" name=""PositionName"" id=""PositionName"" required data-validation-required-message=""This field is required"">
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""col-md-6"">
                                        <div class=""form-group"">
                                            <label for=""DepartmentId"" class=""col-form-label"">Department<span class=""text-danger""> *</span></label>
");
                WriteLiteral(@"                                            <select class=""form-control"" name=""DepartmentId"" id=""DepartmentId""></select>
                                        </div>
                                    </div>
                                </div>
                                <div class=""modal-footer"">
                                    <button class=""btn"" data-dismiss=""modal"" aria-hidden=""true"" onclick=""Readonly()"">Close</button>
                                    <button class=""btn btn-primary"" type=""submit"" form=""form"">Submit</button>
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
            WriteLiteral("\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var isUpdate;
        $(document).ready(function () {
            dataTable = $('#PositionTable').DataTable({
                ""order"": [[0, ""asc""]],
                ""filter"": true,
                ""orderMulti"": false,
                dom: 'Bfrtip',
                buttons: ['copy', 'csv', 'excel', 'pdf', 'print'],
                ""ajax"": {
                    ""url"": ""/position/get"",
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
                        ""targets"": [0, 1, 3],
                        ""width"": ""5%"",
                    },
                    {
                        ""targets"": [4],
                        ""width"": ""10%"",
                    },
            ");
                WriteLiteral(@"        {
                        ""targets"": [2, 4],
                        ""orderable"": false,
                    }
                ],
                ""columns"": [
                    {
                        ""data"": null,
                        ""render"": function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    },
                    { ""data"": 'id' },
                    {
                        ""data"": 'positionName'
                    },
                    {
                        ""data"": 'department',
                        render: function (data, type, row) {
                            var obj = JSON.parse(JSON.stringify(data));
                            return obj.deptName;
                        }
                    },
                    {
                        ""data"": 'id',
                        ""render"": function (data, type, row, meta) {
                            return '<butt");
                WriteLiteral(@"on class=""btn btn-danger"" data-toggle=""tooltip"" data-placement=""top"" title=""Delete ' + row['positionName'] + '"" onclick=""Delete(\'' + row['id'] + '\')""><i class =""far fa-trash-alt""></i></button>'
                        }
                    }
                ]
            });

            //dept
            var DeptDynamicDropdown = '<option value=""-1"">Select Department</option>';
            $.ajax({
                type: ""GET"",
                url: '/Position/Get',
                success: function (data) {
                    var result = data['data']
                    for (var i = 0; i < result.length; i++) {
                        DeptDynamicDropdown += '<option value=""' + result[i].department.id + '"">' + result[i].department.deptName + '</option>';
                        $(""#DepartmentId"").html(DeptDynamicDropdown);
                    }
                }
            });

        });
        function Readonly() {
            $('#Id').attr('readonly', false);
        }
        $(""#form"").validate({
");
                WriteLiteral(@"            submitHandler: function (form) {
                var form = $(form);
                var urlString;
                if (isUpdate == 1)
                    urlString = ""position/put""
                else
                    urlString = ""position/post""
                $.ajax({
                    type: ""POST"",
                    url: urlString,
                    data: form.serialize(),
                    success: function (data) {
                        $('#modal').modal('hide');
                        $('#PositionTable').DataTable().ajax.reload();
                        Swal.fire({
                            position: 'center',
                            icon: 'success',
                            title: 'Your data has been saved',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    },
                    error: function (error) {
                        Swal.fire({
                            icon: '");
                WriteLiteral(@"error',
                            title: 'Oops...',
                            text: 'Something went wrong!',
                            footer: '<a href>Your Work cannot be saved</a>'
                        })
                    }
                });
            }
        });
        function resetButton() {
            isUpdate = 0;
            $('#form').trigger('reset');
        }
        function Get(id) {
            $('#Id').attr('readonly', true);
            $.ajax({
                url: ""position/GetById"",
                type: ""GET"",
                data: { 'id': id },
                success: function (data) {
                    $('#modal').modal('show');
                    var data = data['data'];
                    $('#Id').val(data.id);
                    $('#PositionName').val(data.positionName);
                    $('#DepartmentId').val(data.departmentId);
                    isUpdate = 1;
                }
            });
        }
        function Delete(id) {
            swal.fi");
                WriteLiteral(@"re({
                title: 'Are you sure?',
                text: ""You won't be able to revert this!"",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((data) => {
                if (data.isConfirmed) {
                    $.ajax({
                        type: ""POST"",
                        url: ""position/Delete"",
                        data: { 'id': id },
                        success: function (data) {
                            $('#PositionTable').DataTable().ajax.reload();
                            Swal.fire(
                                'Deleted!',
                                'Your data has been deleted.',
                                'success'
                            )
                        },
                        error: function (error) {
                            Swal.fire({
            ");
                WriteLiteral(@"                    icon: 'error',
                                title: 'Oops...',
                                text: 'Something went wrong!',
                                footer: '<a href>Your Work cannot be saved</a>'
                            })
                        },
                    });
                }
            });
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