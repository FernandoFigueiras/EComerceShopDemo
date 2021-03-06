﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmResselerRegister.aspx.cs" Inherits="TimeZone.ConfirmResselerRegister" %>


<!doctype html>
<html lang="zxx">
<head>
  <meta charset="utf-8">
  <meta http-equiv="x-ua-compatible" content="ie=edge">
  <title>Watch shop | eCommers</title>
  <meta name="description" content="">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="manifest" href="site.webmanifest">
  <link rel="shortcut icon" type="image/x-icon" href="assets/img/favicon.ico">

  <!-- CSS here -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/owl.carousel.min.css">
    <link rel="stylesheet" href="assets/css/flaticon.css">
    <link rel="stylesheet" href="assets/css/slicknav.css">
    <link rel="stylesheet" href="assets/css/animate.min.css">
    <link rel="stylesheet" href="assets/css/magnific-popup.css">
    <link rel="stylesheet" href="assets/css/fontawesome-all.min.css">
    <link rel="stylesheet" href="assets/css/themify-icons.css">
    <link rel="stylesheet" href="assets/css/slick.css">
    <link rel="stylesheet" href="assets/css/nice-select.css">
    <link rel="stylesheet" href="assets/css/style.css">
    <style>    
    .modalDialog {
        position: fixed;
        font-family: Arial, Helvetica, sans-serif;
        top: 0;
        right: 0;
        bottom: 0;
        left: 0;
        background: rgba(0,0,0,0.8);
        z-index: 99999;
        -webkit-transition: opacity 400ms ease-in;
        -moz-transition: opacity 400ms ease-in;
        transition: opacity 400ms ease-in;
    }
    .modalDialog > div {
        width: 400px;
        position: relative;
        margin: 10% auto;
        margin-left:20%;
        padding: 5px 20px 13px 20px;
        border-radius: 10px;
        background: #fff;
        background: -moz-linear-gradient(#fff, #999);
        background: -webkit-linear-gradient(#fff, #999);
        background: -o-linear-gradient(#fff, #999);
    }
    .close {
        background: #606061;
        color: #FFFFFF;
        line-height: 25px;
        position: absolute;
        right: -12px;
        text-align: center;
        top: -10px;
        width: 24px;
        text-decoration: none;
        font-weight: bold;
        -webkit-border-radius: 12px;
        -moz-border-radius: 12px;
        border-radius: 12px;
        -moz-box-shadow: 1px 1px 3px #000;
        -webkit-box-shadow: 1px 1px 3px #000;
        box-shadow: 1px 1px 3px #000;
    }
    .close:hover { background: #00d9ff; }
</style>  
</head>

<body>
  <header>
    <!-- Header Start -->
    <div class="header-area">
        <div class="main-header header-sticky">
            <div class="container-fluid">
                <div class="menu-wrapper">
                    <!-- Logo -->
                    <div class="logo">
                        <a href="index.html"><img src="assets/img/logo/logo.png" alt=""></a>
                    </div>
                    <!-- Main-menu -->
                    <div class="main-menu d-none d-lg-block">
                            <nav>                                                
                                <ul id="navigation">  
                                    <li><a href="Index.aspx">Home</a></li>
                                    <li><a href="Shop.aspx">shop</a></li>
                                    <li><a href="about.html">about</a></li>
                                    <li class="hot"><a href="#">Latest</a>
                                        <ul class="submenu">
                                            <li><a href="shop.html"> Product list</a></li>
                                            <li><a href="product_details.html"> Product Details</a></li>
                                        </ul>
                                    </li>
                                    <li><a href="#">Revendedor</a>
                                        <ul class="submenu">
                                            <li><a href="LoginResseler.aspx">Login Revendedor</a></li>
                                            <li><a href="Cart.aspx">Carrinho</a></li>
                                          </ul>
                                    </li>
                                    <li><a href="contact.html">Contact</a></li>
                                </ul>
                            </nav>
                        </div>
                        <!-- Header Right -->
                        <div class="header-right">
                            <ul>
                                <li>
                                    <div class="nav-search search-switch">
                                        <span class="flaticon-search"></span>
                                    </div>
                                </li>
                                <li> <a href="Login.aspx"><span class="flaticon-user"></span></a></li>
                                <li><a href="Cart.aspx"><span class="flaticon-shopping-cart"></span></a> </li>
                            </ul>
                        </div>
                    </div>
                <!-- Mobile Menu -->
                <div class="col-12">
                    <div class="mobile_menu d-block d-lg-none"></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Header End -->
  </header>
  <main>
      <form runat="server">
           <div id="divModalNoSuccess" runat="server" class ="modalDialog" visible="false">
               <div>
                   <h2>Nao foi possivel registar utilizador</h2>
                   <p>Tente novamente ou contacte loja</p>
                   <br />
			     <asp:Button runat="server"	ID="btnClose" Text="Close" data-toggle="modal"  OnClientClick="return"/>
               </div>
           </div>
      </form>
        

      <!-- Hero Area Start-->
      <div class="slider-area ">
          <div class="single-slider slider-height2 d-flex align-items-center">
              <div class="container">
                  <div class="row">
                      <div class="col-xl-12">
                          <div class="hero-cap text-center">
                              <h2>Confirmação de Registo</h2>
                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div>
      <!--================ confirmation part start =================-->
      <section class="confirmation_part section_padding">
        <div class="container">
          <div class="row">
            <div class="col-lg-12">
              <div class="confirmation_tittle">
                <span>Obrigado, o seu email está agora registado.</span>
                  <p>Para darmos seguimento ao seu processo de registo como Revendedor e necessario preencher os dados abaixo</p>

                  <form runat="server">

								<div id="divModal" runat="server" class="modalDialog" visible="false">
                                    <div>
                                        <h2>Utilizador existente</h2>
                                        <p>Ja existe um utilizador com esse email</p>
                                        <br />
                                        <asp:Button runat="server" ID="Button1" Text="Close" data-toggle="modal" OnClientClick="return" OnClick="btnClose_Click"  />
                                    </div>
                                </div>


								<div class="mt-10">
                                    <asp:TextBox runat="server" placeholder="Nome Empresa"
                                        onfocus="this.placeholder = ''" onblur="this.placeholder = 'Nome Empresa'" class="single-input" ID="fName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fName" Text="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </div>

                                <div class="mt-10">
                                    <asp:TextBox runat="server" placeholder="Apelido"
                                        onfocus="this.placeholder = ''" onblur="this.placeholder = 'Apelido'" class="single-input" ID="lName"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lName" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                </div>

                                <div class="mt-10">
                                    <asp:TextBox runat="server" placeholder="Email"
                                        onfocus="this.placeholder = ''" onblur="this.placeholder = 'Email'" class="single-input" ID="eMail" TextMode="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="eMail" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="eMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="#FF3300">introduza um email valido</asp:RegularExpressionValidator>
                                </div>
                                <div class="mt-10">
                                    <asp:TextBox runat="server" placeholder="Password"
                                        onfocus="this.placeholder = ''" onblur="this.placeholder = 'Password'" class="single-input" ID="passWd" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="passWd" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="mt-10">
                                    <asp:TextBox runat="server" placeholder="Confirmar Password" onfocus="this.placeholder = ''"
                                        onblur="this.placeholder = 'Address'" class="single-input" ID="confPassWd" TextMode="Password"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToCompare="passWd" ControlToValidate="confPassWd" ForeColor="#FF3300"></asp:CompareValidator>
                                </div>
                                <div class="mt-10">
                                    <span class="text-danger" id="validationSpan" style="visibility: hidden">Os campos assinalados a ( * ) são de preenchimento obrigatório</span>
                                </div>
                                <div class="mt-10">
                                    <asp:Button runat="server" class="genric-btn primary" Text="Criar conta" ID="registerButton" OnClick="registerButton_Click" />
                                </div>
							</form>
              </div>
            </div>


         

          </div>
        </div>
      </section>
      <!--================ confirmation part end =================-->
  </main>
  <footer>
    <!-- Footer Start-->
    <div class="footer-area footer-padding">
        <div class="container">
            <div class="row d-flex justify-content-between">
                <div class="col-xl-3 col-lg-3 col-md-5 col-sm-6">
                    <div class="single-footer-caption mb-50">
                        <div class="single-footer-caption mb-30">
                            <!-- logo -->
                            <div class="footer-logo">
                                <a href="index.html"><img src="assets/img/logo/logo2_footer.png" alt=""></a>
                            </div>
                            <div class="footer-tittle">
                                <div class="footer-pera">
                                    <p>Asorem ipsum adipolor sdit amet, consectetur adipisicing elitcf sed do eiusmod tem.</p>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-2 col-lg-3 col-md-3 col-sm-5">
                    <div class="single-footer-caption mb-50">
                        <div class="footer-tittle">
                            <h4>Quick Links</h4>
                            <ul>
                                <li><a href="#">About</a></li>
                                <li><a href="#"> Offers & Discounts</a></li>
                                <li><a href="#"> Get Coupon</a></li>
                                <li><a href="#">  Contact Us</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-lg-3 col-md-4 col-sm-7">
                    <div class="single-footer-caption mb-50">
                        <div class="footer-tittle">
                            <h4>New Products</h4>
                            <ul>
                                <li><a href="#">Woman Cloth</a></li>
                                <li><a href="#">Fashion Accessories</a></li>
                                <li><a href="#"> Man Accessories</a></li>
                                <li><a href="#"> Rubber made Toys</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-xl-3 col-lg-3 col-md-5 col-sm-7">
                    <div class="single-footer-caption mb-50">
                        <div class="footer-tittle">
                            <h4>Support</h4>
                            <ul>
                                <li><a href="#">Frequently Asked Questions</a></li>
                                <li><a href="#">Terms & Conditions</a></li>
                                <li><a href="#">Privacy Policy</a></li>
                                <li><a href="#">Report a Payment Issue</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Footer bottom -->
            <div class="row align-items-center">
                <div class="col-xl-7 col-lg-8 col-md-7">
                    <div class="footer-copy-right">
                        <p><!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
  Copyright &copy;<script>document.write(new Date().getFullYear());</script> All rights reserved | This template is made with <i class="fa fa-heart" aria-hidden="true"></i> by <a href="https://colorlib.com" target="_blank">Colorlib</a>
  <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. --></p>                 
                    </div>
                </div>
                <div class="col-xl-5 col-lg-4 col-md-5">
                    <div class="footer-copy-right f-right">
                        <!-- social -->
                        <div class="footer-social">
                            <a href="#"><i class="fab fa-twitter"></i></a>
                            <a href="https://www.facebook.com/sai4ull"><i class="fab fa-facebook-f"></i></a>
                            <a href="#"><i class="fab fa-behance"></i></a>
                            <a href="#"><i class="fas fa-globe"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Footer End-->
  </footer>
  <!--? Search model Begin -->
  <div class="search-model-box">
    <div class="h-100 d-flex align-items-center justify-content-center">
        <div class="search-close-btn">+</div>
        <form class="search-model-form">
            <input type="text" id="search-input" placeholder="Searching key.....">
        </form>
    </div>
  </div>
  <!-- Search model end -->

  <!-- JS here -->
  
  <script src="./assets/js/vendor/modernizr-3.5.0.min.js"></script>
  <!-- Jquery, Popper, Bootstrap -->
  <script src="./assets/js/vendor/jquery-1.12.4.min.js"></script>
  <script src="./assets/js/popper.min.js"></script>
  <script src="./assets/js/bootstrap.min.js"></script>
  <!-- Jquery Mobile Menu -->
  <script src="./assets/js/jquery.slicknav.min.js"></script>

  <!-- Jquery Slick , Owl-Carousel Plugins -->
  <script src="./assets/js/owl.carousel.min.js"></script>
  <script src="./assets/js/slick.min.js"></script>

  <!-- One Page, Animated-HeadLin -->
  <script src="./assets/js/wow.min.js"></script>
  <script src="./assets/js/animated.headline.js"></script>
  <script src="./assets/js/jquery.magnific-popup.js"></script>

  <!-- Scroll up, nice-select, sticky -->
  <script src="./assets/js/jquery.scrollUp.min.js"></script>
  <script src="./assets/js/jquery.nice-select.min.js"></script>
  <script src="./assets/js/jquery.sticky.js"></script>
  
  <!-- contact js -->
  <script src="./assets/js/contact.js"></script>
  <script src="./assets/js/jquery.form.js"></script>
  <script src="./assets/js/jquery.validate.min.js"></script>
  <script src="./assets/js/mail-script.js"></script>
  <script src="./assets/js/jquery.ajaxchimp.min.js"></script>
      
  <!-- Jquery Plugins, main Jquery -->	
  <script src="./assets/js/plugins.js"></script>
  <script src="./assets/js/main.js"></script>
      
</body>
</html>
