<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pages-register.aspx.cs" Inherits="Cellar.WebClient.Account.pages_register" %>

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
                            <!-- Logo-->
                            <div class="card-header pt-4 pb-4 text-center bg-primary">
                                <a href="index.html">
                                    <span>
                                        <img src="https://coderthemes.com/hyper/assets/images/logo.png" alt="" height="18"></span>
                                </a>
                            </div>

                            <div class="card-body p-4">

                                <div class="text-center w-75 m-auto">
                                    <h4 class="text-dark-50 text-center mt-0 font-weight-bold">Free Sign Up</h4>
                                    <p class="text-muted mb-4">Don't have an account? Create your account, it takes less than a minute </p>
                                </div>

                                <p class="text-danger">
                                    <asp:Literal runat="server" ID="ErrorMessage" />
                                </p>

                                <div class="form-group">
                                    <label for="fullname">Full Name</label>
                                    <input runat="server" class="form-control" type="text" id="fullname" placeholder="Entra tu nombre" required>
                                </div>

                                <div class="form-group">
                                    <label for="emailaddress">Email address</label>
                                    <input runat="server" class="form-control" type="email" id="emailaddress" required placeholder="Entra tu email">
                                </div>

                                <div class="form-group">
                                    <label for="password">Password</label>
                                    <input runat="server" class="form-control" type="password" required id="password" placeholder="Entra tu contraseña">
                                </div>

                                <div class="form-group">
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="checkbox-signup">
                                        <label class="custom-control-label" for="checkbox-signup">I accept <a href="#" class="text-dark">Terms and Conditions</a></label>
                                    </div>
                                </div>

                                

                                <div class="form-group mb-0 text-center">
                                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registarse" CssClass="btn btn-primary" />
                                </div>

                            </div>
                            <!-- end card-body -->
                        </div>
                        <!-- end card -->

                        <div class="row mt-3">
                            <div class="col-12 text-center">
                                <p class="text-muted">Already have account? <a href="pages-login.aspx" class="text-dark ml-1"><b>Log In</b></a></p>
                            </div>
                            <!-- end col-->
                        </div>
                        <!-- end row -->

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
