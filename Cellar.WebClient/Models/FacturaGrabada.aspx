<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FacturaGrabada.aspx.cs" Inherits="Cellar.WebClient.Models.FacturaGrabada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Hyper - Responsive Bootstrap 4 Admin Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
    <meta content="Coderthemes" name="author" />
    <!-- App favicon -->
    <link rel="shortcut icon" href="https://coderthemes.com/hyper/assets/images/favicon.ico">

    <!-- App css -->
    <link href="../Scripts/ScriptsExternal/icons.min.css" rel="stylesheet" />
    <link href="../Scripts/ScriptsExternal/app.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="account-pages mt-5 mb-5">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-5">
                        <div class="card">
                            <!-- Logo -->
                            <div class="card-header pt-4 pb-4 text-center bg-primary">
                                <a href="Home.aspx">
                                    <span>
                                        <img src="https://coderthemes.com/hyper/assets/images/logo.png" alt="" height="18"></span>
                                </a>
                            </div>

                            <div class="card-body p-4">
                                <div class="text-center">
                                    
                                    <h4 class="text-uppercase text-success mt-3">Factura Insertada con Exito</h4>
                                    

                                    <a class="btn btn-info mt-3" href="Home.aspx"><i class="mdi mdi-reply"></i>Inicio</a>
                                    <a class="btn btn-info mt-3" href="InsertarFactura.aspx"><i class="mdi mdi-reply"></i>Insertar Factura</a>
                                </div>
                            </div>
                            <!-- end card-body-->
                        </div>
                        <!-- end card -->
                    </div>
                    <!-- end col -->
                </div>
                <!-- end row -->
            </div>
            <!-- end container -->
        </div>
        <!-- end page -->

        <footer class="footer footer-alt">
            2018 © Hyper - Coderthemes.com
        </footer>

        <!-- App js -->
        <script src="https://coderthemes.com/hyper/assets/js/app.min.js"></script>
    </form>
</body>
</html>
