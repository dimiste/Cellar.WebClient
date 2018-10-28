<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InsertarEmpresa.aspx.cs" Inherits="Cellar.WebClient.Models.InsertarEmpresa" %>
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
                        <li class="breadcrumb-item active">Insertar Factura</li>
                    </ol>
                </div>
                <h4 class="page-title">Insertar Factura</h4>
            </div>
        </div>
    </div>
    <!-- end page title -->


    <div class="row">
        <div class="col-lg-6">

            <div class="form-group mb-3">
                <label for="company">Empresa</label>
                <asp:TextBox runat="server" ID="company"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCompany" ControlToValidate="company" runat="server" Text="Campo obligatorio" Display="Dynamic" ErrorMessage="Password field is required!" ForeColor="Red" EnableClientScript="False" />
            </div>

            <asp:Button runat="server" OnClick="InsertCompany"  class="btn btn-primary" Text="Crear Empresa" />
        </div>

        
    </div>
    <!-- end row-->

    <!-- bundle -->
    <script src="https://coderthemes.com/hyper/assets/js/app.min.js"></script>

</asp:Content>
