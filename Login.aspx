<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <title>Madhya Pradesh State Veterinary Council</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/news.css" rel="stylesheet" type="text/css" />
    <link href="css/slider.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function checkDateFormat(that) {

            var mo, day, yr;
            var entry = that.value;
            var re = /\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/;
            if (re.test(entry)) {
                var delimChar = (entry.indexOf("/") != -1) ? "/" : "-";
                var delim1 = entry.indexOf(delimChar);
                var delim2 = entry.lastIndexOf(delimChar);

                day = parseInt(entry.substring(0, delim1), 10);
                mo = parseInt(entry.substring(delim1 + 1, delim2), 10);
                yr = parseInt(entry.substring(delim2 + 1), 10);
                var testDate = new Date(yr, mo - 1, day);

                if (testDate.getDate() == day) {
                    if (testDate.getMonth() + 1 == mo) {
                        if (testDate.getFullYear() == yr) {
                            return true;
                        } else {
                            that.value = "";
                            alert("Invalid date.");
                        }
                    }
                    else {
                        that.value = "";
                        alert("Invalid date.");

                    }
                }
                else {
                    that.value = "";
                    alert("Invalid date.");
                }
            }
            else {
                if (entry != "") {
                    that.value = "";
                    alert("Incorrect date format. Enter as (dd/MM/yyyy).");
                }
            }
            return false;
        }
    </script>

    <script type="text/javascript">

        function test() {
            try {
                var reginos = document.getElementById('txtregNo').value;
                var name = document.getElementById('txtName').value;
                var email = document.getElementById('txtEmail').value;
                var mobile = document.getElementById('txtMobile').value;
                var DOb = document.getElementById('txtDob').value;
                if (reginos == "" && name == "" && email == "" && mobile == "" && DOb == "") {
                    alert("Please enter any keyword for search");
                    return false;
                }
                AjaxPro.timeoutPeriod = 9000000;
                var str = Login.GridFillLoad(reginos, name, email, mobile, DOb);
                alert(str.value)
            }
            catch (e) {
                alert(e);

            }

        }
    </script>
    <style>
        .txtbox {
            border: 1px solid #b4b4b4;
            padding: 5px;
            background: transparent;
            -webkit-border-radius: 2px;
            border-radius: 2px;
            -moz-border-radius: 2px;
        }

        input[type="text"], input[type="password"] {
            padding: 5px !important;
            width: 200px;
        }

        select, input {
            border: 1px solid #b4b4b4;
            padding: 5px;
            background: transparent;
            -webkit-border-radius: 2px;
            border-radius: 2px;
            -moz-border-radius: 2px;
        }

        .alert {
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid transparent;
            border-radius: 4px;
        }


        .alert-danger {
            color: #a94442;
            background-color: #f2dede;
            border-color: #eab2bb;
        }

            .alert-danger hr {
                border-top-color: #e4b9c0;
            }

            .alert-danger .alert-link {
                color: #843534;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top-bar" id="changeFont">
            <a href="#wrapper" title="Skip to main content">Skip to main content / Screen Reader
            Access</a> &nbsp; <a href="#" class="resetFont">A</a> <a href="#" class="increaseFont">A<sup>+</sup></a> <a href="#" class="increaseFont2"><b>A<sup>+</sup></b></a>
            &nbsp; <a href="#" class="whtbg">A</a> <a href="#" class="blkbg">A</a>
            <img src="images/top-icon.png" border="0" usemap="#Map" />
            <map name="Map">
                <area shape="rect" coords="0,1,12,12" title="Home" href="#">
                <area shape="rect" coords="28,1,40,12" href="#">
                <area shape="rect" coords="54,1,65,12" title="Contact Us" href="#">
            </map>
            <span class="ML12" id="menu">English
            <div class="flyout">
                <a href="#">Hindi</a><br>
                <a href="#">English</a>
            </div>
            </span>
        </div>
        <div class="wrapper" id="wrapper">
            <%--<div class="logo">
                <h2>Madhya Pradesh State<br>
                    Veterinary Council</h2>
            </div>
            <div class="FR">
                <a href="Login.aspx" class="button"><span class="icon-login"></span>
                    <p>
                        Login
                    </p>
                </a>&nbsp; <a href="#" class="button"><span class="icon-register"></span>
                    <p>
                        Registration
                    </p>
                </a>
                <p>
                    <input type="text" class="search" placeholder="Search" />
            </div>--%>
			<a href="index.aspx">
				<img style="width: 100%;" src="images/header.jpg" />
			</a>
			
            <div class="CL">
            </div>
            <div class="menu">
                <ul>
                    <li class="active"><a href="index.aspx" title="Home">Home</a></li>
                    <li><a href="#" title="About Us">About Us</a>
                        <ul>
                            <li><a href="StateVeterinaryCouncil.html">State Veterinary Council </a></li>
                            <li><a href="OfficialBearers.html">Official Bearers</a></li>
                            <li><a href="SubCommittees.html">Sub Committees</a></li>
                        </ul>
                    </li>
                    <li><a href="#" title="Act & Rules">Act & Rules</a>
                        <ul>
                            <li><a href="Act_Rules.html">Council</a></li>
                            <li><a href="#">General</a></li>
                        </ul>
                    </li>
                    <li><a href="#" title="MPVPR">MPVPR</a></li>
                    <li><a href="#" title="CVE">CVE</a></li>
                    <li><a href="PhotoGallery.html" title="Photo Gallery">Photo Gallery</a></li>
                    <li><a href="contectus.html" title="Contct Us" class="last">Contact Us</a></li>
                </ul>
                <div class="CL">
                </div>
            </div>
            <div class="MT10">
                <!-- Breadcrumb Example Here -->
                <div id="breadcrumb">
                    <ul class="crumbs">
                        <li><a href="#" class="first">Home</a></li>
                        <li>Login</li>
                    </ul>
                </div>
            </div>
            <div class="MT20" style="min-height: 500px;">
                <div class="MT20">
                    <b>Member Login</b>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    <table width="50%" cellpadding="5">
                        <tr>
                            <td>Login Id :
                            </td>
                            <td>
                                <asp:TextBox ID="txtLoginId" runat="server" MaxLength="20" CssClass="textbox reqirerd"
                                    placeholder="Login Id"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginId"
                                    ErrorMessage="Please Enter Login Id.">*</asp:RequiredFieldValidator>
									<asp:TextBox ID="txtregino" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Password :
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" placeholder="Password" TextMode="Password"
                                    CssClass="textbox reqirerd"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                    ErrorMessage="Please Enter Password.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn" Text="Login" OnClick="btnLogin_Click" />
                            </td>
                            <td>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ShowSummary="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="ftr_logo">
            <a href="http://india.gov.in" target="_blank">
                <img src="images/india_gov_logo.jpg" alt="National Portal of India" title="National Portal of India" /></a>
            <a href="http://mygov.in" target="_blank">
                <img src="images/my_gov_logo.jpg" alt="My Gov" title="My Gov" /></a>
        </div>
        <div class="footer">
            <div class="footer-cnt">
                <div class="FL">
                    <a href="#">Accessibility Statement</a> | <a href="#">Terms of Use</a> | <a href="#">Disclaimer</a> | <a href="#">Privacy Policy</a>
                </div>
                <div class="FR">
                    2015 &copy; Content Owned by Madhya Pradesh State Veterinary Council.
                </div>
                <div class="CL">
                </div>
            </div>
        </div>
        <script type="text/javascript" src="js/jquery.min.js"></script>
        <script type="text/javascript" src="js/jquery-1.6.1.min.js"></script>
        <script type="text/javascript" src="js/jquery.reveal.js"></script>
        <script type="text/javascript" src="js/news.js"></script>
        <script type="text/javascript" language="javascript">


            $(document).ready(function () {
                // Reset Font Size
                var originalFontSize = $('html').css('font-size');
                $(".resetFont").click(function () {
                    $('html').css('font-size', originalFontSize);
                });
                // Increase Font Size
                $(".increaseFont").click(function () {
                    var currentFontSize = $('html').css('font-size');
                    var currentFontSizeNum = parseFloat(currentFontSize, 10);
                    var newFontSize = 13;
                    $('html').css('font-size', newFontSize);
                    return false;
                });

                $(".increaseFont2").click(function () {
                    var currentFontSize = $('html').css('font-size');
                    var currentFontSizeNum = parseFloat(currentFontSize, 10);
                    var newFontSize = 14;
                    $('html').css('font-size', newFontSize);
                    return false;
                });
            });
            $(document).ready(function () {
                $("#breakingnews1").BreakingNews();

                $("#breakingnews2").BreakingNews({
                    background: '#e9e9df',
                    //title			:'NEWS',
                    //titlecolor		:'#FFF',
                    titlebgcolor: '#01baf2',
                    linkcolor: '#0f0f0f',
                    linkhovercolor: '#01baf2',
                    fonttextsize: 14,
                    isbold: false,
                    //border			:'solid 1px #099',
                    width: '100%',
                    timer: 2000,
                    autoplay: true,
                    effect: 'slide'

                });

                $('#apply').click(function (e) {
                    addValues();
                });
                addValues();
            });

            $(window).load(function () {

                $('#slider').nivoSlider();

            });

            $('.popup-opener').bind('click', function (e) {
                e.preventDefault();
                $($(this).attr('popup-element')).bPopup();
            });

            $("#menu").click(function () {

                $(".flyout").toggle();

            });

        </script>

        <script type="text/javascript">
            (function (jQuery) {

                $.fn.BreakingNews = function (settings) {
                    var defaults = {
                        background: '#FFF',
                        //title			:'NEWS',
                        //titlecolor		:'#FFF',
                        //titlebgcolor	:'#5aa628',
                        linkcolor: '#333',
                        linkhovercolor: '#5aa628',
                        fonttextsize: 14,
                        isbold: false,
                        border: 'none',
                        width: '100%',
                        autoplay: true,
                        timer: 3000,
                        modulid: 'brekingnews',
                        effect: 'fade'	//or slide	
                    };
                    var settings = $.extend(defaults, settings);

                    return this.each(function () {
                        settings.modulid = "#" + $(this).attr("id");
                        var timername = settings.modulid;
                        var activenewsid = 1;

                        if (settings.isbold == true)
                            fontw = 'bold';
                        else
                            fontw = 'normal';

                        if (settings.effect == 'slide')
                            $(settings.modulid + ' ul li').css({ 'display': 'block' });
                        else
                            $(settings.modulid + ' ul li').css({ 'display': 'none' });

                        $(settings.modulid + ' .bn-title').html(settings.title);
                        $(settings.modulid).css({ 'width': settings.width, 'background': settings.background, 'border': settings.border, 'font-size': settings.fonttextsize });
                        $(settings.modulid + ' ul').css({ 'left': $(settings.modulid + ' .bn-title').width() + 40 });
                        $(settings.modulid + ' .bn-title').css({ 'background': settings.titlebgcolor, 'color': settings.titlecolor, 'font-weight': fontw });
                        $(settings.modulid + ' ul li a').css({ 'color': settings.linkcolor, 'font-weight': fontw, 'height': parseInt(settings.fonttextsize) + 6 });
                        $(settings.modulid + ' ul li').eq(parseInt(activenewsid - 1)).css({ 'display': 'block' });

                        // Links hover events ......
                        $(settings.modulid + ' ul li a').hover(function () {
                            $(this).css({ 'color': settings.linkhovercolor });
                        },
                            function () {
                                $(this).css({ 'color': settings.linkcolor });
                            }
                        );


                        // Arrows Click Events ......
                        $(settings.modulid + ' .bn-arrows span').click(function (e) {
                            if ($(this).attr('class') == "bn-arrows-left")
                                BnAutoPlay('prev');
                            else
                                BnAutoPlay('next');
                        });

                        // Timer events ...............
                        if (settings.autoplay == true) {
                            timername = setInterval(function () { BnAutoPlay('next') }, settings.timer);
                            $(settings.modulid).hover(function () {
                                clearInterval(timername);
                            },
                                function () {
                                    timername = setInterval(function () { BnAutoPlay('next') }, settings.timer);
                                }
                            );
                        }
                        else {
                            clearInterval(timername);
                        }

                        //timer and click events function ...........
                        function BnAutoPlay(pos) {
                            if (pos == "next") {
                                if ($(settings.modulid + ' ul li').length > activenewsid)
                                    activenewsid++;
                                else
                                    activenewsid = 1;
                            }
                            else {
                                if (activenewsid - 2 == -1)
                                    activenewsid = $(settings.modulid + ' ul li').length;
                                else
                                    activenewsid = activenewsid - 1;
                            }

                            if (settings.effect == 'fade') {
                                $(settings.modulid + ' ul li').css({ 'display': 'none' });
                                $(settings.modulid + ' ul li').eq(parseInt(activenewsid - 1)).fadeIn();
                            }
                            else {
                                $(settings.modulid + ' ul').animate({ 'marginTop': -($(settings.modulid + ' ul li').height() + 20) * (activenewsid - 1) });
                            }
                        }

                        // links size calgulating function ...........
                        $(window).resize(function (e) {
                            if ($(settings.modulid).width() < 360) {
                                $(settings.modulid + ' .bn-title').html('&nbsp;');
                                $(settings.modulid + ' .bn-title').css({ 'width': '4px' });
                                $(settings.modulid + ' ul').css({ 'left': 4 });
                            } else {
                                $(settings.modulid + ' .bn-title').html(settings.title);
                                $(settings.modulid + ' .bn-title').css({ 'width': 'auto' });
                                $(settings.modulid + ' ul').css({ 'left': $(settings.modulid + ' .bn-title').width() + 40 });
                            }
                        });
                    });

                };

            })(jQuery);

            var sliderFlotme = '<div class=\"hidesidebar flotedslider\"><div class=\"togglebtn\" onClick=\"$(\'.flotedslider\').toggleClass(\'showsidebar\',\'slow\')\">Check Your Status</div><div class=\"panel\"><h2>Check Your Status</h2><table style=\"color: #fff;\"><tr><td>Reg. No.</td><td> <asp:TextBox ID="txtregNo" runat="server"></asp:TextBox> </td></tr><tr><td>Name</td><td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr><tr><td>Email</td><td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td></tr><tr><td>Mobile</td><td><asp:TextBox ID="txtMobile" runat="server"></asp:TextBox></td></tr><tr><td>DOB</td><td><asp:TextBox ID="txtDob" runat="server" onchange="checkDateFormat(this)"></asp:TextBox></td></tr><tr><td></td><td> <asp:button id="btnShow" CssClass="btn" runat="server" text="Submit" onClientClick="test()" ></asp:button></td></tr></table></div></div>';
            $(document).ready(function (e) {
                $("body").append(sliderFlotme);
            });
        </script>
    </form>
</body>
</html>
