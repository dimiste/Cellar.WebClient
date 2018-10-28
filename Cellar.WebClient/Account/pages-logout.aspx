<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pages-logout.aspx.cs" Inherits="Cellar.WebClient.Account.pages_logout" %>

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
        <div>

            <div class="account-pages mt-5 mb-5">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-lg-5">
                            <div class="card">

                                <!-- Logo -->
                                <div class="card-header pt-4 pb-4 text-center bg-primary">
                                    <a href="/Models/Home.aspx">
                                        <span>
                                            <img src="https://coderthemes.com/hyper/assets/images/logo.png" alt="" height="18"></span>
                                    </a>
                                </div>

                                <div class="card-body p-4">

                                    <div class="text-center w-75 m-auto">
                                        <h4 class="text-dark-50 text-center mt-0 font-weight-bold">Hasta Pronto !</h4>
                                        <p class="text-muted mb-4">Satisfactoriamente os desconectásteis.</p>
                                    </div>

                                    <div class="logout-icon m-auto">
                                        <svg version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
                                            viewBox="0 0 161.2 161.2" enable-background="new 0 0 161.2 161.2" xml:space="preserve">
                                            <path class="path" fill="none" stroke="#0acf97" stroke-miterlimit="10" d="M425.9,52.1L425.9,52.1c-2.2-2.6-6-2.6-8.3-0.1l-42.7,46.2l-14.3-16.4
                                            c-2.3-2.7-6.2-2.7-8.6-0.1c-1.9,2.1-2,5.6-0.1,7.7l17.6,20.3c0.2,0.3,0.4,0.6,0.6,0.9c1.8,2,4.4,2.5,6.6,1.4c0.7-0.3,1.4-0.8,2-1.5
                                            c0.3-0.3,0.5-0.6,0.7-0.9l46.3-50.1C427.7,57.5,427.7,54.2,425.9,52.1z" />
                                            <circle class="path" fill="none" stroke="#0acf97" stroke-width="4" stroke-miterlimit="10" cx="80.6" cy="80.6" r="62.1" />
                                            <polyline class="path" fill="none" stroke="#0acf97" stroke-width="6" stroke-linecap="round" stroke-miterlimit="10" points="113,52.8
                                            74.1,108.4 48.2,86.4 " />

                                            <circle class="spin" fill="none" stroke="#0acf97" stroke-width="4" stroke-miterlimit="10" stroke-dasharray="12.2175,12.2175" cx="80.6" cy="80.6" r="73.9" />
                                        </svg>
                                    </div>
                                    <!-- end logout-icon-->

                                </div>
                                <!-- end card-body-->
                            </div>
                            <!-- end card-->

                            <div class="row mt-3">
                                <div class="col-12 text-center">
                                    <p class="text-muted">Back to <a href="pages-login.aspx" class="text-dark ml-1"><b>Log In</b></a></p>
                                </div>
                                <!-- end col -->
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

        </div>
    </form>
</body>
</html>
