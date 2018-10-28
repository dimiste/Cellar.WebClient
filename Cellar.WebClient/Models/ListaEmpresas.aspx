<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaEmpresas.aspx.cs" Inherits="Cellar.WebClient.Models.ListaEmpresas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- third party css -->
    <link href="https://coderthemes.com/hyper/assets/css/vendor/jquery-jvectormap-1.2.2.css" rel="stylesheet" />
    <!-- third party css end -->

    <!-- third party css -->
    <link href="https://coderthemes.com/hyper/assets/css/vendor/dataTables.bootstrap4.css" rel="stylesheet" type="text/css" />
    <link href="https://coderthemes.com/hyper/assets/css/vendor/responsive.bootstrap4.css" rel="stylesheet" type="text/css" />
    <link href="https://coderthemes.com/hyper/assets/css/vendor/buttons.bootstrap4.css" rel="stylesheet" type="text/css" />
    <link href="https://coderthemes.com/hyper/assets/css/vendor/select.bootstrap4.css" rel="stylesheet" type="text/css" />
    <!-- third party css end -->

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>--%>
    <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- start page title -->
    <div class="row">
        <div class="col-12">
            <div class="page-title-box">
                <div class="page-title-right">
                    <a href="InsertarEmpresa.aspx" class="btn btn-primary">Insertar Empresa</a>

                    <ol class="breadcrumb m-0">
                        <li class="breadcrumb-item"><a href="javascript: void(0);">Hyper</a></li>
                        <li class="breadcrumb-item"><a href="javascript: void(0);">Apps</a></li>
                        <li class="breadcrumb-item active">Empresas</li>
                    </ol>
                </div>
                <h4 class="page-title">Lista Empresas</h4>
            </div>
        </div>
    </div>
    <!-- end page title -->

    <!-- start row-->
    <div class="row table-responsive">
        <div class="col-12">
            <div class="card">
                <div class="card-body">

                    <input class="form-control" id="myInput" type="text" placeholder="Buscar empresa en la lista...">

                    <div class="table-responsive">
                        <table class="table">

                            <%--<thead>
                                <tr>
                                    <td>
                                        <asp:Button runat="server" ID="ButonEliminar" Text="Eliminar" OnClick="ButonEliminar_Click" class="btn btn-primary" />
                                    </td>
                                    <td>Fecha de compra
                                    </td>
                                    <td>Empresa</td>
                                    <td>Factura</td>
                                    <td>Importe</td>
                                </tr>
                            </thead>--%>

                            <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id"
                                SelectMethod="ListView1_GetData"
                                ItemType="Cellar.Data.Models.Company">
                                <EditItemTemplate>
                                </EditItemTemplate>
                                <EmptyDataTemplate>
                                    <tr>
                                        <td>No se han devuelto datos.</td>

                                    </tr>
                                </EmptyDataTemplate>
                                <InsertItemTemplate>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <tbody id="myTable">
                                        <tr>
                                            <td>
                                                <%--<asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Eliminar" class="btn btn-primary" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Editar" class="btn btn-primary" />--%>
                                                <asp:CheckBox runat="server" ID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:Label ID="Name" runat="server" Text="<%# Item.Name %>"></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="Id" runat="server" Text='<%# Item.Id %> ' Visible="false" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <tr runat="server" class="success">
                                        <td runat="server" style="width: 200px">
                                            <asp:Button ID="DeleteButton" runat="server" OnClick="ButonEliminar_Click" Text="Eliminar" class="btn btn-primary" />
                                        </td>
                                        <td>Name</td>

                                    </tr>
                                    <tr id="itemPlaceholder" runat="server" visible="false">
                                    </tr>
                                </LayoutTemplate>

                            </asp:ListView>


                        </table>
                    </div>
                </div>
                <!-- end card body-->
            </div>
            <!-- end card -->
        </div>
        <!-- end col-->
    </div>
    <!-- end row-->

    <%--<div class="text-center">
        <asp:DataPager runat="server" PagedControlID="ListView1" PageSize="5" ID="Pagination">
            <Fields>
                <asp:NextPreviousPagerField ButtonCssClass="btn btn-inverse btn-xs"
                    ButtonType="Link"
                    ShowFirstPageButton="false"
                    ShowPreviousPageButton="true"
                    ShowNextPageButton="false" />
                <asp:NumericPagerField ButtonType="Link"
                    CurrentPageLabelCssClass="btn btn-primary btn-xs"
                    NumericButtonCssClass="btn btn-inverse btn-xs" />
                <asp:NextPreviousPagerField ButtonCssClass="btn btn-inverse btn-xs"
                    ButtonType="Link"
                    ShowNextPageButton="true"
                    ShowLastPageButton="false"
                    ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
    </div>--%>

    <script>
        var $j = jQuery.noConflict();
        $j(document).ready(function () {
            $j("#myInput").on("keyup", function () {
                var value = $j(this).val().toLowerCase();
                $j("#myTable tr").filter(function () {
                    $j(this).toggle($j(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>

    <!-- bundle -->
    <script src="https://coderthemes.com/hyper/assets/js/app.min.js"></script>

</asp:Content>
