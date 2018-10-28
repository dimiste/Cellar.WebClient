<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SumaFacturas.aspx.cs" Inherits="Cellar.WebClient.Models.SumaFacturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- start page title -->
    <div class="row">
        <div class="col-12">
            <div class="page-title-box">
                <div class="page-title-right">

                    <ol class="breadcrumb m-0">
                        <li class="breadcrumb-item"><a href="javascript: void(0);">Hyper</a></li>
                        <li class="breadcrumb-item"><a href="javascript: void(0);">Apps</a></li>
                        <li class="breadcrumb-item active">Suma Facturas</li>
                    </ol>
                </div>
                <h4 class="page-title">Suma Facturas</h4>
            </div>
        </div>
    </div>
    <!-- end page title -->

    <!-- start row-->
    <div class="row table-responsive">
        <div class="col-12">
            <div class="card">
                <div class="card-body">

                    <input class="form-control" id="myInput" type="text" placeholder="Buscar factura en la lista...">

                    <div class="table-responsive">
                        <table class="table">

                            <asp:ListView ID="ListView1" runat="server" DataKeyNames="Mes" 
                                SelectMethod="ListView1_GetData"
                                
                                ItemType="Cellar.Data.Models.SumBills">
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
                                                <asp:Label ID="Mes" runat="server" Text="<%# Item.Mes %>"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="BaseSuperReducido" runat="server" Text="<%# Item.BaseSuperReducido %>"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="BaseReducido" runat="server" Text="<%# Item.BaseReducido %>" />
                                            </td>
                                            <td>
                                                <asp:Label ID="BaseNormal" runat="server" Text="<%# Item.BaseNormal %>"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="IVASuperReducido" runat="server" Text="<%# Item.IVASuperReducido %>" />
                                            </td>
                                            <td>
                                                <asp:Label ID="IVAReducido" runat="server" Text="<%# Item.IVAReducido %>" />
                                            </td>
                                            <td>
                                                <asp:Label ID="IVANormal" runat="server" Text="<%# Item.IVANormal %>" />
                                            </td>
                                            <td>
                                                <asp:Label ID="BaseTotal" runat="server" Text="<%# Item.BaseTotal %>" />
                                            </td>
                                            <td>
                                                <asp:Label ID="IVATotal" runat="server" Text="<%# Item.IVATotal %>" />
                                            </td>
                                            <td>
                                                <asp:Label ID="ImporteTotal" runat="server" Text="<%# Item.ImporteTotal %>" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <LayoutTemplate>
                                    <tr runat="server" class="success">
                                        <td>Mes</td>
                                        <td>Base 4%</td>
                                        <td>Base 10%</td>
                                        <td>Base 21%</td>
                                        <td>IVA 4%</td>
                                        <td>IVA 10%</td>
                                        <td>IVA 21%</td>
                                        <td>Base Total</td>
                                        <td>IVA Total</td>
                                        <td>Importe Total</td>
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


    

    <!-- bundle -->
    <script src="https://coderthemes.com/hyper/assets/js/app.min.js"></script>
</asp:Content>
