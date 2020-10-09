<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="TimeZone.ManageProducts" %>



<!doctype html>
<html class="no-js" lang="zxx">
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
        margin-left:40%;
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
    <!-- Preloader Start -->
    <div id="preloader-active">
        <div class="preloader d-flex align-items-center justify-content-center">
            <div class="preloader-inner position-relative">
                <div class="preloader-circle"></div>
                <div class="preloader-img pere-text">
                    <img src="assets/img/logo/logo.png" alt="">
                </div>
            </div>
        </div>
    </div>
    <!-- Preloader Start -->
    <header>
        <!-- Header Start -->
       <div class="header-area">
            <div class="main-header header-sticky">
                <div class="container-fluid">
                    <div class="menu-wrapper">
                        <!-- Logo -->
                        <div class="logo">
                            <a href="index.aspx"><img src="assets/img/logo/logo.png" alt=""></a>
                        </div>
                        <!-- Main-menu -->
                        <div class="main-menu d-none d-lg-block">
                            <nav>                                                
                                <ul id="navigation">  
                                    <li><a href="IndexLogedInAdmin.aspx">Home</a></li>
                                    <li><a href="ManageProducts.aspx">Gerir Produtos</a></li>
                                    <li><a href="ManageResselers.aspx">Gerir Revendedores</a></li>
                                    <li><a href="ManageOrders.aspx">Gerir Encomendas</a></li>
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
                                <li> </li>
                                <li><a href="Cart.aspx"><span class="flaticon-shopping-cart"></span></a> </li>
                            </ul>
                        </div>
                         <div class="main-menu d-none d-lg-block">
                            <nav>                                                
                                <ul>  
                                    <li><asp:Label runat="server" ID="userName"></asp:Label>
                                        <ul class="submenu">
                                            <li><a href="IndexLogedInAdmin.aspx?logout=true" id="logoutLink">Logout</a></li>
                                          </ul>
                                    </li>
                                </ul>
                            </nav>
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
        <!-- Hero Area Start-->
        <div class="slider-area ">
            <div class="single-slider slider-height2 d-flex align-items-center">
                <div class="container">
                    <div class="row">
                        <div class="col-xl-12">
                            <div class="hero-cap text-center">
                                <h2>Gestao de Produtos</h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Hero Area End-->

        <!--Modal start-->


        <!--Modal End-->


        <!-- Start Align Area -->
        <form runat="server">


            <div id="divModal" runat="server" class="modalDialog" visible="false">
                                    <div>
                                        <h2>Erro</h2>
                                        <p>Nao foi possivel inserir produto</p>
                                        <br />
                                        <asp:Button runat="server" ID="btnClose" Text="Close" data-toggle="modal" OnClientClick="return" OnClick="btnClose_Click" />
                                    </div>
                                </div>



            <div class="whole-wrap">
                <div class="container box_1170">
                    <div class="section-top-border">
                        <div class="row">
                            <div class="col-lg-8 col-md-8">
                                <h3 class="mb-30">Inserir produtos</h3>
                                <center>
                                    <div class="mt-10">
                                    <asp:TextBox runat="server" placeholder="Descricao produto"
                                        onfocus="this.placeholder = ''" onblur="this.placeholder = 'Descricao produto'" class="single-input" ID="prodDescript"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="prodDescript" Text="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </div>
                                <div class="mt-10">
                                    <asp:TextBox runat="server" placeholder="Preco"
                                        onfocus="this.placeholder = ''" onblur="this.placeholder = 'Preco'" class="single-input" ID="prodPrice"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="prodPrice" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                    <span style="visibility:hidden" class="text-info" id="priceFlag">Formado incorrecto</span>
                                </div>
                                <div class="mt-10">
                                    <asp:TextBox runat="server" placeholder="Stock"
                                        onfocus="this.placeholder = ''" onblur="this.placeholder = 'Stock'" class="single-input" ID="prodStock" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="prodStock" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                    <span style="visibility:hidden" class="text-info" id="stockFlag">Formado incorrecto</span>
                               </div>
                                     <div class="mt-10">
                                    <asp:Button runat="server" class="genric-btn primary" Text="Inserir Produto" ID="btnInsertProd" OnClick="btnInsertProd_Click" />
                                </div>
                                </center>


                                <br /><br />

                                <center>
                                     
                                    <asp:Panel runat="server" Visible ="true" ID="ProdShow">
                                    <h3 class="mb-30">Produtos em loja</h3>
                              <asp:Repeater ID="Repeater1" runat="server">
                                  <HeaderTemplate>
                                      <section class="cart_area section_padding">
        <div class="container">
          <div class="cart_inner">
            <div class="table-responsive">
              <table class="table">
                <thead>
                  <tr>
                      <th scope="col">Id</th>
                    <th scope="col">Descricao</th>
                    <th scope="col">Preco</th>
                    <th scope="col">Stock</th>
                  </tr>
                </thead>
                
             

                                  </HeaderTemplate>
                                  <ItemTemplate>
                                      <tbody>
                  <tr>
                      <td>
                      <h5><%# Eval("Id") %></h5>
                    </td>
                    <td>
                      <h5><%# Eval("Description") %></h5>
                    </td>
                    <td>
                      <h5><%# Eval("Price") %></h5>
                    </td>
                    <td>
                      <h5><%# Eval("Stock") %></h5>
                    </td>
                  </tr>

                  
                  
                </tbody>
                                  </ItemTemplate>
                                  <FooterTemplate>
                                       </table>
                                                </div>
      </section>
                                  </FooterTemplate>



                              </asp:Repeater>
                                    </asp:Panel>
                                    </div>
                                     <div class="mt-10">
                                    <asp:Button runat="server" class="genric-btn primary" Text="Editar Produtos" ID="btn_edit" OnClick="btn_edit_Click" CausesValidation="false"/>
                                </div>

                                    <asp:Panel runat="server" ID="EditProd" Visible="true">




                                        <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="Repeater2_ItemDataBound"  OnItemCommand="Repeater2_ItemCommand1">
                                            <HeaderTemplate>
                                                <div class="container">
          <div class="cart_inner">
            <div class="table-responsive">
              <table class="table">
                <thead>
                  <tr>
                       <th scope="col">Id</th>
                    <th scope="col">Descricao</th>
                    <th scope="col">Preco</th>
                    <th scope="col">Stock</th>
                  </tr>
                </thead>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                       <tbody>
                  <tr>
                   <td><asp:Label ID="lblId" runat="server" ></asp:Label></td>
                        <td><asp:TextBox ID="tb_description" runat="server"></asp:TextBox></td>
                         <td><asp:TextBox ID="tb_price" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="tb_stock" runat="server"></asp:TextBox></td>
                       <td>
                           <asp:ImageButton runat="server" ID="btnSave" ImageUrl="~/Images/grunge-yes-no-icon-2.png" CommandName="btnSave" CausesValidation="false" />
                    </td>
                      <td>
                          <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="~/Images/grunge-no-icon.png"  CommandName="btnDelete" CausesValidation="false"  />
                    </td>
                  </tr>

                  
                  
                </tbody>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr>
                   <td><asp:Label ID="lblId" runat="server" ></asp:Label></td>
                        <td><asp:TextBox ID="tb_description" runat="server"></asp:TextBox></td>
                         <td><asp:TextBox ID="tb_price" runat="server"></asp:TextBox></td>
                        <td><asp:TextBox ID="tb_stock" runat="server"></asp:TextBox></td>
                       <td>
                           <asp:ImageButton runat="server" ID="btnSave" ImageUrl="~/Images/grunge-yes-no-icon-2.png" CommandName="btnSave" CausesValidation="false" CommandArgument="id"/>
                    </td>
                                                     <td>
                          <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="~/Images/grunge-no-icon.png"  CommandName="btnDelete" CausesValidation="false"  />
                    </td>
                  </tr>
                                            </AlternatingItemTemplate>
                                            <FooterTemplate>
                                                  </table>
                                                </div>
      </section>
                                            </FooterTemplate>

                                        </asp:Repeater>
















                                 
                                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:clockShopConnectionString %>" SelectCommand="SELECT * FROM [products]"></asp:SqlDataSource>











                                 
                                    </asp:Panel>
                            </center>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

           
        </form>
        <!-- End Align Area -->
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
                                    <a href="index.html">
                                        <img src="assets/img/logo/logo2_footer.png" alt=""></a>
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
                                    <li><a href="#">Offers & Discounts</a></li>
                                    <li><a href="#">Get Coupon</a></li>
                                    <li><a href="#">Contact Us</a></li>
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
                                    <li><a href="#">Man Accessories</a></li>
                                    <li><a href="#">Rubber made Toys</a></li>
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
                            <p>
                                <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                                Copyright &copy;<script>document.write(new Date().getFullYear());</script>
                                All rights reserved | This template is made with <i class="fa fa-heart" aria-hidden="true"></i>by <a href="https://colorlib.com" target="_blank">Colorlib</a>
                                <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                            </p>
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

    <!-- Scroll up, nice-select, sticky -->
    <script src="./assets/js/jquery.scrollUp.min.js"></script>
    <script src="./assets/js/jquery.nice-select.min.js"></script>
    <script src="./assets/js/jquery.sticky.js"></script>
    <script src="./assets/js/jquery.magnific-popup.js"></script>

    <!-- contact js -->
    <script src="./assets/js/contact.js"></script>
    <script src="./assets/js/jquery.form.js"></script>
    <script src="./assets/js/jquery.validate.min.js"></script>
    <script src="./assets/js/mail-script.js"></script>
    <script src="./assets/js/jquery.ajaxchimp.min.js"></script>

    <!-- Jquery Plugins, main Jquery -->
    <script src="./assets/js/plugins.js"></script>
    <script src="./assets/js/main.js"></script>

    <script type="text/javascript">
        document.getElementById("prodPrice").addEventListener("blur", function () {
            
            var text = document.getElementById("prodPrice").value;
            if (isNaN(text)) {
                document.getElementById("priceFlag").style.visibility = "visible";
                //debugger;
            }
            
        })


    </script>
     <script type="text/javascript">
         document.getElementById("prodStock").addEventListener("blur", function () {
             var text = document.getElementById("prodStock").value;
             if (isNaN(text)) {
                 document.getElementById("stockFlag").style.visibility = "visible";
             }

         })


     </script>

</body>
</html>


