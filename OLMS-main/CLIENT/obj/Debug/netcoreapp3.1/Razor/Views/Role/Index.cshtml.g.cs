#pragma checksum "C:\Users\lenovo\Downloads\OLMS-main\CLIENT\Views\Role\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8670919a45cff254b43bb164fb84a907bf6fd9b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Index), @"mvc.1.0.view", @"/Views/Role/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8670919a45cff254b43bb164fb84a907bf6fd9b9", @"/Views/Role/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffe964b7c289c35c556836e61e59e9c46c33c90c", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "C:\Users\lenovo\Downloads\OLMS-main\CLIENT\Views\Role\Index.cshtml"
   Layout = "_LayoutAdmin";
    ViewBag.Title = "Role";

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
                        <i class=""fas fa-user-plus""></i> Add New Role
                    </button>
                    <table id=""RoleTable"" class=""display nowrap table table-hover table-striped table-bordered"" cellspacing=""0"" width=""100%"">
                        <thead>
                            <tr>
                                <th>No</th>
                                <th>ID</th>
                                <th>Role</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
         ");
            WriteLiteral(@"               <tbody>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th>No</th>
                                <th>ID</th>
                                <th>Role</th>
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
                            <h2 class=""modal-title"">Role</h2>
                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"" onclick=""Readonly()""><span aria-hidden=""true"">&times;</span></button>
                        </div>
                        <div class=""modal-body"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8670919a45cff254b43bb164fb84a907bf6fd9b96195", async() => {
                WriteLiteral(@"
                                <div class=""form-row"">
                                    <div class=""col-md-6"" hidden>
                                        <div class=""form-group"">
                                            <label for=""roleID"" class=""col-form-label"">ID<span class=""text-danger""> *</span></label>
                                            <div class=""controls"">
                                                <input type=""number"" form-control"" name=""roleID"" id=""roleID"" required data-validation-required-message=""This field is required"">
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""col-md-12"">
                                        <div class=""form-group"">
                                            <label for=""RoleName"" class=""col-form-label"">Role Name<span class=""text-danger""> *</span></label>
                                            <div cla");
                WriteLiteral(@"ss=""controls"">
                                                <input type=""text"" class=""form-control"" name=""RoleName"" id=""roleName"" required data-validation-required-message=""This field is required"">
                                            </div>
                                        </div>
                                    </div>
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
            WriteLiteral(@"
                        </div>
                        <div class=""modal-footer"">
                            <button class=""btn"" data-dismiss=""modal"" aria-hidden=""true"" onclick=""Readonly()"">Close</button>
                            <button class=""btn btn-primary"" type=""submit"" form=""form"">Submit</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
            WriteLiteral("\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var isUpdate;
        $(document).ready(function () {
            dataTable = $('#RoleTable').DataTable({
                ""order"": [[0, ""asc""]],
                ""filter"": true,
                ""orderMulti"": false,
                dom: 'Bfrtip',
                buttons: ['copy', 'csv', 'excel', 'pdf', 'print'],
                ""ajax"": {
                    ""url"": ""/Role/get"",
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
                        ""targets"": [3],
                        ""width"": ""10%"",
                    },
                    ");
                WriteLiteral(@"{
                        ""targets"": [2, 3],
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
                    { ""data"": 'roleID' },
                    {
                        ""data"": 'roleName'
                    },
                    {
                        ""data"": 'roleID',
                        ""render"": function (data, type, row, meta) {
                            return '<a class=""btn btn-success"" data-toggle=""tooltip"" data-placement=""top"" title=""Edit ' + row['roleName'] + '""  onclick=""Get(\'' + row['roleID'] + '\')""><i class =""far fa-edit""></i> </a> ' +
                                '<button class=""btn btn-danger"" data-toggle=""tooltip"" data-placement=""top"" title=""Delete ");
                WriteLiteral(@"' + row['roleName'] + '"" onclick=""Delete(\'' + row['roleID'] + '\')""><i class =""far fa-trash-alt""></i></button>'
                        }
                    }
                ]
            });
        });
        function Readonly() {
            $('#roleID').attr('readonly', false);
        }
        $(""#form"").validate({
            rules: {
                roleName: ""required"",
            },
            submitHandler: function (form) {
                var form = $(form);
                var urlString;
                if (isUpdate == 1)
                    urlString = ""/Role/put""
                else
                    urlString = ""/Role/post""
                $.ajax({
                    type: ""POST"",
                    url: urlString,
                    data: form.serialize(),
                    success: function (data) {
                        $('#modal').modal('hide');
                        $('#RoleTable').DataTable().ajax.reload();
                        Swal.fire({
                          ");
                WriteLiteral(@"  position: 'center',
                            icon: 'success',
                            title: 'Your data has been saved',
                            showConfirmButton: false,
                            timer: 1500
                        })
                    },
                    error: function (error) {
                        Swal.fire({
                            icon: 'error',
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
            $('#roleID').attr('readonly', false);
            $('#form').trigger('reset');
        }
        function Get(id) {
            $('#roleID').attr('readonly', true);
            $.ajax({
                url: ""/Role/GetById"",
                type: ""GET"",
                data: { '");
                WriteLiteral(@"id': id },
                success: function (data) {
                    $('#modal').modal('show');
                    var data = data['data'];
                    $('#roleID').val(data.roleID);
                    $('#roleName').val(data.roleName);
                    isUpdate = 1;
                }
            });
        }
        function Delete(id) {
            swal.fire({
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
                        url: ""/Role/Delete"",
                        data: { 'id': id },
                        success: function (data) {
                            $('#RoleTable').Da");
                WriteLiteral(@"taTable().ajax.reload();
                            Swal.fire(
                                'Deleted!',
                                'Your data has been deleted.',
                                'success'
                            )
                        },
                        error: function (error) {
                            Swal.fire({
                                icon: 'error',
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