<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

    <script type="text/javascript" src="/js/jquery.min.js">
    </script>
    <script type="text/javascript" src="/js/jquery-1.6.1.min.js">
    </script>
    <script type="text/javascript" src="/js/jquery.reveal.js">
    </script>
    <script type="text/javascript" src="/js/news.js">
    </script>
    <script type="text/javascript">
        var sliderFlotme = '<div class=\"hidesidebar flotedslider\"><div class=\"togglebtn\" onClick=\"$(\'.flotedslider\').toggleClass(\'showsidebar\',\'slow\')\">Check Your Status</div><div class=\"panel\"><h2>Check Your Status</h2><table style=\"color: #fff;\"><tr><td>Reg. No.</td><td><input type=\"text\"></td></tr><tr><td>Name</td><td><input type=\"text\"></td></tr><tr><td>Email</td><td><input type=\"text\"></td></tr><tr><td>Mobile</td><td><input type=\"text\"></td></tr><tr><td>DOB</td><td><input type=\"text\"></td></tr><tr><td></td><td><button type=\"button\"><i class\"fa fa-search\"></i> Submit</button></td></tr></table></div></div>';
        $(document).ready(function (e) {
            $("body").append(sliderFlotme);
        });
    </script>
    <script type="text/javascript" src="/js/jquery.nivo.slider.pack.js">
    </script>
    <script type="text/javascript" src="../js/CommonCtrl.js"></script>
    <script type="text/javascript" language="javascript">
        function test() {
            try {
                document.getElementById('HF_Reg').value = document.getElementById('txtregNo').value.trim();
                document.getElementById('HF_Name').value = document.getElementById('txtName').value.trim();
                document.getElementById('HF_Email').value = document.getElementById('txtEmail').value.trim();
                document.getElementById('HF_Mob').value = document.getElementById('txtMobile').value.trim();
                document.getElementById('HF_DOB').value = document.getElementById('txtDob').value.trim();
                if (document.getElementById('txtregNo').value.trim() == "" && document.getElementById('txtName').value.trim() == "" && document.getElementById('txtEmail').value.trim() == "" && document.getElementById('txtMobile').value.trim() == "" && document.getElementById('txtDob').value.trim() == "") {
                    alert("Please enter any keyword for search");
                    return false;
                }
                document.getElementById('Button1').click();
                //var msg = document.getElementById('HF_Msg').value;
                //alert(msg);
            }
            catch (e) {
                alert(e);

            }
        }
    </script>

    <link href="https://fonts.googleapis.com/css?family=Arvo&display=swap" rel="stylesheet" />
    <style type="text/css">
        .swal-modal {
            font-family: 'Arvo', serif;
            width: 75%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" name="DemoForm">
        <div id="changeFont" class="top-bar">
            <a title="Skip to main content" href="#wrapper">Skip to main content / Screen Reader Access</a> &nbsp; <a class="resetFont" href="#">A</a> <a class="increaseFont" href="#">A<sup>+</sup></a> <a class="increaseFont2" href="#"><b>A<sup>+</sup></b></a> &nbsp; <a class="whtbg" href="#">A</a> <a class="blkbg" href="#">A</a>
            <img border="0" usemap="#Map" src="images/top-icon.png" />
            <map name="Map">
                <area title="Home" href="#" coords="0,1,12,12" shape="rect"></area>
                <area href="#" coords="28,1,40,12" shape="rect"></area>
                <area title="Contact Us" href="#" coords="54,1,65,12" shape="rect"></area>
            </map>
            <span id="menu" class="ML12">ENGLISH
                <div class="flyout">
                    <a href="#">Hindi</a><br />
                    <a href="#">English</a>
                </div>
            </span>
        </div>
        <div id="wrapper" class="wrapper">
            <a href="index.aspx">
                <img style="width: 100%;" src="images/header.jpg" />
            </a>
            <div class="CL"></div>
            <div class="menu">
                <ul>
                    <li class="active"><a title="Home" href="index.aspx">Home</a></li>
                    <li>
                        <a title="About Us" href="#">About Us</a>
                        <ul>
                            <li><a href="StateVeterinaryCouncil.html">Present Council</a></li>
                            <!--

                            <li><a href="OfficialBearers.html">Official Bearers</a></li>-->


                            <li><a href="SubCommittees.html">Sub Committees</a></li>
                        </ul>
                    </li>
                    <li>
                        <a title="Act & Rules" href="#">Act &amp; Rules</a>
                        <ul>
                            <li><a href="Act_Rules.html">Council</a></li>
                            <li><a href="#">Others</a></li>
                        </ul>
                    </li>
                    <!--

                    <li><a title="MPVPR" href="#">MPVPR</a></li>-->



                    <li><a title="Annual Report" href="AnnualReport.html">Annual Report</a></li>
                    <li><a title="Photo Gallery" href="PhotoGallery.html">Photo Gallery</a></li>
                    <li><a title="Contct Us" class="last" href="contectus.html">Contact Us</a></li>
                    <li><a title="help" href="help.html">help </a></li>
                    <li><a title="help" href="Login.aspx">Login </a></li>
                    <li>
                        <asp:HyperLink ID="lnkdwnload" title="help" runat="server" NavigateUrl="~/MobileApp\mpsvc_v1.0.apk">Download Mobile App</asp:HyperLink></li>
                    <li>
                        	<%--START HERE_ Comment by bhanu on 23 APR 2022 As per Change Request --%>
                        <a title="Act & Rules" href="#">Complaint Management</a>
                        <ul>
                            <li><a href="ComplaintRegistration.aspx">Complaint Registration</a></li>
                            <li><a href="ComplaintStatus.aspx">Complaint Status</a></li>                           
                        </ul>
                        	<%--START HERE_ Comment by bhanu on 23 APR 2022 As per Change Request --%>
                    </li>
                    <%-- Add by bhanu on 22-03-2022 --%>
                </ul>
                <div class="CL"></div>
            </div>
            <div class="MT10">
                <div class="slider-wrapper theme-default">
                    <div class="ribbon"></div>
                    <div id="slider" class="nivoSlider">
                        <a href="#">
                            <img alt="" title="Madhya Pradesh State Veterinary Council" style="max-width: 100% !important; height: 345px !important;" src="images/banner03.jpg" /></a> <a href="#">
                                <img alt="" title="Madhya Pradesh State Veterinary Council" style="max-width: 100% !important; height: 345px !important;" src="images/banner06.jpg" /></a> <a href="#">
                                    <img alt="" title="Madhya Pradesh State Veterinary Council" style="max-width: 100% !important; height: 345px !important;" src="images/banner01.jpg" /></a> <a href="#">
                                        <img alt="" title="Madhya Pradesh State Veterinary Council" style="max-width: 100% !important; height: 345px !important;" src="images/banner02.jpg" /></a> <a href="#">
                                            <img alt="" title="Madhya Pradesh State Veterinary Council" style="max-width: 100% !important; height: 345px !important;" src="images/banner05.jpg" /></a> <a href="#">
                                                <img alt="" title="Madhya Pradesh State Veterinary Council" style="max-width: 100% !important; height: 345px !important;" src="images/banner07.jpg" /></a>
                    </div>
                </div>
                <div class="CL"></div>
            </div>

            <div class="MT10">
                <div id="breakingnews2" class="BreakingNewsController easing">
                    <div class="bn-title">
                        <img alt="Dadra and Nagar Haveli" src="images/news-icon.png" />
                    </div>
                    <ul class="UlCSS">
                        <li style="padding-top: 8px;">
                            <marquee direction="left" style="width: 100%;">
						
                                <%-- <a href="images/Draft-Elec-Roll-2020.pdf" target="_blank" ><span style="color:red;"> <img src="images/new.png" style="height:13px; width:20px;" />Draft-Elec-Roll-2020</span> &nbsp;&nbsp;|&nbsp;&nbsp;</a>
                                <a href="images/Formats.pdf" target="_blank" ><span style="color:red;"> <img src="images/new.png" style="height:13px; width:20px;" />Formats</span> &nbsp;&nbsp;|&nbsp;&nbsp;</a>
                              <a href="images/Election-Notice.pdf" target="_blank" ><span style="color:red;"> <img src="images/new.png" style="height:13px; width:20px;" />Election-Notice</span> &nbsp;&nbsp;|&nbsp;&nbsp;</a>--%>
							  <a href="images/Final-Electoral-Roll-MPSVCnew.pdf" target="_blank" ><span style="color:red;"> <img src="images/new.png" style="height:13px; width:20px;" />Final Electoral Roll 2020</span> &nbsp;&nbsp;|&nbsp;&nbsp;</a>
                               <a href="images/MPGazz2020101642part1.pdf" target="_blank" ><span style="color:red;"> Publication of the list of defaulters, whose names have been removed from the M.P.S.V.P.R. as on 01-04-2020</span></a>
                        </marquee>
                        </li>

                        <%-- <li style="padding-top: 8px;">
						  <img src="images/new.png" style="height:18px; width:25px;" />
						 <a href="images/MPSVPR.pdf" target="_blank" ><span style="color:red;">Madhya Pradesh State Veterinary Practitioner Register (As on 05-12-2019)</span></a></li>
						 
						 <li style="padding-top: 8px;">
						  <img src="images/new.png" style="height:18px; width:25px;" />
						 <a href="images/Press-Note_New.pdf" target="_blank" ><span style="color:red;">VCI Election 2020 Press-Note</span></a></li>
						 
						  <li style="padding-top: 8px;">
						  <img src="images/new.png" style="height:18px; width:25px;" />
						 <a href="images/Draft-Electoral-Roll.pdf" target="_blank" ><span style="color:red;">VCI Election 2020 Draft-Electoral-Roll</span></a></li>
						 
						 <li style="padding-top: 8px;">
						  <img src="images/new.png" style="height:18px; width:25px;" />
						 <a href="images/Form-A-to-D.pdf" target="_blank" ><span style="color:red;">VCI Election 2020 Form A to D</span></a></li>
                        --%>


                        <%--  <li style="padding-top: 8px;"><a href="images/Electoral-Roll-VCI.pdf" target="_blank" ><span style="color:red;">Final Electoral Roll for VCI Election 2020</span></a></li>
						 <li style="padding-top: 8px;"><a href="images/Advisory_for_updation_of_mobile_numbers.pdf" target="_blank" ><span style="color:red;">Advisory for updation of mobile numbers </span></a></li>--%>

                        <%-- <li style="padding-top: 8px;">
						 <marquee direction="left" style="width:100%;"> --%>
                        <!--
								<a href="images/Electoral-Roll-VCI.pdf" target="_blank" ><span style="color:red;">Final Electoral Roll for VCI Election 2020</span></a>
								<a>&nbsp;&nbsp;|&nbsp;&nbsp;</a>
								<img src="images/new.png" style="height:18px; width:25px;" />
								<a href="images/Advisory_for_updation_of_mobile_numbers_New.pdf" target="_blank" style="color: rgb(15, 15, 15); font-weight: normal; height: 20px;"><span style="color:red;">Advisory & format for updation of mobile number and email id for VCI Election 2020 </span></a>
								--->

                        <%--</marquee>
						 
						 </li>--%>
                    </ul>
                    <div class="readmore" style="background-color: #e9e9df;">
                        <a href="images/Electoral-Roll-VCI.pdf" target="_blank">Read All </a>
                    </div>
                </div>
            </div>
            <div class="MT20">
                <div class="leftside">
                    <b>Welcome to Madhya Pradesh State Veterinary Council</b><br />
                    <p class="PT10">Veterinary Council of Indian Act 1984 (52 of 1984) was enacted in year 1984 to regulate veterinary education &amp; practices, &amp; establishment of a statuary body named as veterinary council of india Under which every state (except Jammu &amp; kashmir) enacted this law to register all the veterinary practitioners of the state. </p>
                    <p class="PT10">
                        Subsequent to the enactment of the Act, the central government (Ministry of Agriculture) in 1989, for the first time constituted the veterinary council of India by nominating the members as per the provisions of section 4 read with section 3 of the act.
                        The first election of members of the council under section 3(3)(g) of the act was conducted by the central government in 1999 which consists of 27 members (14 nominated, 11 elected &amp; 2 ex-officio)
                    </p>
                    <p class="MT20 MB20"><a class="RM" href="aboutus.html">Read More</a></p>
                    <hr />
                    <%--<strong>Message from the President</strong>
                    <img width="204px" style="float: right; border: 1px dashed rgb(204, 204, 204); padding: 10px; margin: 5px 11px;" src="images/President.jpg" />
                    <p class="PT10">
                        Namaskar,<br />
                        I heartily congratulate efforts of Veterinary council of Madhya Pradesh to develop this website. In my opinion purpose of this website is simple i.e. to serve as the vehicle between a veterinarian and farmer. Council should primarily focus to be in live contact with all of its members and should make all possible efforts to sharpen their skills. Council should make efforts to strengthen our colleges so that they can produce young skilled professionals.

                        .
                    </p>
                    <p class="MT20 MB20"><a class="RM" href="PresidentMessage.html">Read More</a></p>
                    <hr />--%>
					</br>
					</br>
					</br>
					
                    <div>
                        <div class="btm_box bx02">
                            <h2>How to Apply ?</h2>
                            <ul>
                                <li><a href="#">Guest House</a></li>
                                <li><a href="#">Provisional Registration</a></li>
                                <li><a href="#">Renewal Registration</a></li>
                            </ul>
                        </div>
                        <div class="btm_box bx03 ML12">
                            <h2>Suggestion and Grievances</h2>
                            <ul>
                                <li><a href="#">Click here to Comment</a></li>
                            </ul>
                        </div>
                        <div class="btm_box bx04 ML12">
                            <h2>Reports</h2>
                            <ul>
                                <li><a href="#">Click here to view</a></li>
                            </ul>
                        </div>
                        <div class="CL"></div>
                    </div>
                </div>
                <div class="rightside">
                    <div style="min-height: 150px;" class="wht270">
                        <p class="ghbox"><a href="GuestHouse.aspx">Guest House</a></p>
                        <p class="regisbox"><a href="RegistrationLinkNew.aspx">Registration</a></p>
                        <div style="margin: 10px 0px; width: 100%; border-radius: 10px;" class="b_right FR">
                            <div class="atglance">
                                <h3>Important Links</h3>
                                <ul>
                                    <li><a target="_blank" href="frm_userupdateddetails.aspx">click here to update information</a></li>
                                    <li><a target="_blank" href="Recognized_Institutions.PDF">Recognized Institutes</a></li>
                                    <!--  <li><a href="#">Veterinary Practitioners</a></li>
                                    <li><a href="#">Due For Registration</a></li>-->
                                </ul>
                            </div>
                        </div>
                        <div>
                            <a href="images/Electoral-Roll.xlsx">
                                <img style="width: 100%;" src="images/draftelectoralroll.jpg" /></a>
                        </div>
                    </div>
                </div>
                <div class="CL"></div>
            </div>
            <div class="MT10 implinks">
                <h3 style="border-bottom-width: 1px; border-bottom-style: solid; border-bottom-color: rgb(204, 204, 204); padding-bottom: 5px; margin-bottom: 15px;" class="bluefnt">OTHER LINK'S</h3>
                <ul class="FL">
                    <li><a href="Act_Rules.html">Act And Regulation</a></li>
                    <li><a href="Act_Rules.html">MPSVC Rules</a></li>
                    <li><a href="#">The List of Veterinarians</a></li>
                    <li><a href="#">Tenders</a></li>
                </ul>
                <ul class="FL">
                    <li><a href="PhotoGallery.html">Media Gallery</a></li>
                    <li><a href="#">Terms &amp; Conditions</a></li>
                    <li><a href="#">Copyright Policy</a></li>
                    <li><a href="#">Useful Links</a></li>
                </ul>
                <ul class="FL">
                    <li><a href="#">Hyperlinking Policy</a></li>
                    <li><a href="#">Accessibility Statement</a></li>
                    <li><a href="#">FAQs</a></li>
                    <li><a href="#">Feedback</a></li>
                </ul>
                <ul class="FL">
                    <li><a href="#">Help</a></li>
                    <li><a href="#">Site Map</a></li>
                </ul>
                <div class="CL"></div>
            </div>
        </div>
        <div class="ftr_logo">
            <a target="_blank" href="http://india.gov.in">
                <img alt="National Portal of India" title="National Portal of India" src="images/india_gov_logo.jpg" /></a> <a target="_blank" href="http://mygov.in">
                    <img alt="My Gov" title="My Gov" src="images/my_gov_logo.jpg" /></a>
        </div>
        <div id="myModal" class="reveal-modal">
            <h1>Provisional Registration</h1>
            <ul class="list">
                <li><a href="Provisiona_Registration.html">Online Form</a></li>
                <li><a target="_blank" href="Provisional_Registration.pdf">Offline Form</a></li>
            </ul>
            <a class="close-reveal-modal">×</a>
        </div>
        <div id="myModal2" class="reveal-modal">
            <h1>New Registration</h1>
            <ul class="list">
                <li><a href="Provisiona_Registration.html">Online Form</a></li>
                <li><a target="_blank" href="Registration_Form.pdf">Offline Form</a></li>
            </ul>
            <a class="close-reveal-modal">×</a>
        </div>
        <div id="myModal3" class="reveal-modal">
            <h1>New Registration</h1>
            <ul class="list">
                <li><a href="Provisiona_Registration.html">Online Form</a></li>
                <li><a target="_blank" href="Transfer_For_Registration.pdf">Offline Form</a></li>
            </ul>
            <a class="close-reveal-modal">×</a>
        </div>
        <div class="footer">
            <div class="footer-cnt">
                <div class="FL">
                    <p class="footer-links">
                        <a class="text-uppercase" href="Disclaimer.html">Disclaimer</a> |
                        <a class="text-uppercase" href="PrivacyPolicy.html">Privacy Policy</a> |
                        <a class="text-uppercase" href="Refund.html">Refund / Cancellation Policy</a> |
                        <a class="text-uppercase" href="TermsandConditions.html">Terms &amp; Conditions</a>
                    </p>
                </div>
                <div style="text-align: right;" class="FR">
                    2015 © Content Owned by Madhya Pradesh State Veterinary Council.<br />
                    Powered By : SFA Technologies



                </div>
                <div class="CL"></div>
            </div>
        </div>
        <img onclick="$(this).hide()" style="width: 100%; height: 100%; display: none; position: fixed; top: 0px; left: 0px; z-index: 2147483647;" src="images/back.png" />

        <script type="text/javascript">
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
                    timer: 20000,
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

            var sliderFlotme = '<div class=\"hidesidebar flotedslider\"><div class=\"togglebtn\" onClick=\"$(\'.flotedslider\').toggleClass(\'showsidebar\',\'slow\')\">Check Your Status</div><div class=\"panel\"><h2>Check Your Status</h2><table style=\"color: #fff;\"><tr><td>Reg. No.</td><td> <asp:TextBox ID="txtregNo" placeholder="0000/2015" runat="server"></asp:TextBox> </td></tr><tr><td>Name</td><td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr><tr><td>Email</td><td><asp:TextBox ID="txtEmail" placeholder="example@gmail.com" runat="server"></asp:TextBox></td></tr><tr><td>Mobile</td><td><asp:TextBox ID="txtMobile" runat="server"></asp:TextBox></td></tr><tr style = "display: none;"><td>DOB</td><td><asp:TextBox ID="txtDob" runat="server" placeholder="dd/MM/yyyy" onchange="checkDateFormat(this)"></asp:TextBox></td></tr><tr><td></td><td> <asp:button id="btnShow" CssClass="btn" runat="server" text="Submit" onClientClick="test()"  ></asp:button><asp:Label ID="lblMsg" runat="server" ></asp:Label></td></tr></table></div></div>';
            $(document).ready(function (e) {
                $("body").append(sliderFlotme);
            });
            function GiveAlert() {
                if (document.getElementById('HF_Msg').value.trim() != "") {
                    swal("Search Detail", document.getElementById('HF_Msg').value);
                }
                else {
                    swal("No Record Found.");
                }

            }
        </script>
        <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js" type="text/javascript"></script>
        <asp:Button Style="display: none;" ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:HiddenField ID="HF_Reg" runat="server" />
        <asp:HiddenField ID="HF_Name" runat="server" />
        <asp:HiddenField ID="HF_Mob" runat="server" />
        <asp:HiddenField ID="HF_Email" runat="server" />
        <asp:HiddenField ID="HF_DOB" runat="server" />
        <asp:HiddenField ID="HF_Msg" runat="server" />
    </form>
</body>
</html>
