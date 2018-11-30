<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InsertarFactura.aspx.cs" Inherits="Cellar.WebClient.InsertarFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/jquery-ui.min.js"></script>
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" />

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
                <input type="text" id="company" name="company" placeholder="Entra empresa..." class="form-control" runat="server">
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCompany" ControlToValidate="company" runat="server" Text="Elige de la lista" Display="Dynamic" ErrorMessage="Password field is required!" ForeColor="Red" EnableClientScript="False" />
            </div>

            <div class="form-group mb-3">
                <label for="exento">Exento IVA</label>
                <input type="text" id="exento" name="exento" class="form-control" placeholder="Importe exento" runat="server">
            </div>

            <div class="form-group mb-3">
                <label for="base4">Base 4%</label>
                <input type="text" id="base4" name="base4" class="form-control" placeholder="Base 4 %" runat="server">
            </div>

            <div class="form-group mb-3">
                <label for="base10">Base 10%</label>
                <input type="text" id="base10" name="base10" class="form-control" placeholder="Base 10 %" runat="server">
            </div>

            <div class="form-group mb-3">
                <label for="base21">Base 21%</label>
                <input type="text" id="base21" name="base21" class="form-control" placeholder="Base 21 %" runat="server">
            </div>




        </div>

        <div class="col-lg-6">

            <div class="form-group mb-3">
                <label for="date">Mes de Facturación</label>
                <%--<asp:TextBox runat="server" TextMode="Month" ID="month"></asp:TextBox>--%>
                <select runat="server" ID="month">
                    <option value="">Elige mes</option>
                    <option value="-01">Enero</option>
                    <option value="-02">Febrero</option>
                    <option value="-03">Marzo</option>
                    <option value="-04">Abril</option>
                    <option value="-05">Mayo</option>
                    <option value="-06">Junio</option>
                    <option value="-07">Julio</option>
                    <option value="-08">Agosto</option>
                    <option value="-09">Septiembre</option>
                    <option value="-10">Octubre</option>
                    <option value="-11">Noviembre</option>
                    <option value="-12">Diciembre</option>
                </select>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="month" runat="server" Text="Campo obligatorio" Display="Dynamic" ErrorMessage="Month field is required!" ForeColor="Red" EnableClientScript="False" />
            </div>

            <div class="form-group mb-3">
                <label for="date">Fecha de Compra</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" ControlToValidate="date" runat="server" Text="Campo obligatorio" Display="Dynamic" ErrorMessage="Password field is required!" ForeColor="Red" EnableClientScript="False" />
                <input class="form-control" id="date" type="date" name="date" runat="server">
            </div>

            <div class="form-group mb-3">
                <label for="bill">Factura escaneada</label>
                <br />
                <input id="bill" type="file" name="bill" runat="server">
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorBill" ControlToValidate="bill" runat="server" Text="Obligatorio subir factura" Display="Dynamic" ErrorMessage="Password field is required!" ForeColor="Red" EnableClientScript="False" />--%>
            </div>
        </div>

        <asp:Button runat="server" OnClick="ValidateBtn_OnClick" class="btn btn-primary" Text="Guardar" />
        <asp:Button runat="server" OnClick="CancelarBtn_OnClick" class="btn btn-primary" Text="Cancelar" />
    </div>
    <!-- end row-->

    <script type="text/javascript">

        // Para evitar conflictos con otras bibliotecas
        var $j = jQuery.noConflict();

        $j(function () {

            $j('#ContentPlaceHolder1_company').autocomplete({

                source: "../Empresas.ashx",
                //change: function () {
                //    if (!($('#ContentPlaceHolder1_company').val().includes(this.source))) {
                //        alert("no");
                //    }
                //}

            });


        })

    </script>

    <!-- bundle -->
    <script src="https://coderthemes.com/hyper/assets/js/app.min.js"></script>


</asp:Content>
