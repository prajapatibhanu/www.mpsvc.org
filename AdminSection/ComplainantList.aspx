<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/AdminMaster.master" AutoEventWireup="true" CodeFile="ComplainantList.aspx.cs" Inherits="AdminSection_ComplainantList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />--%>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-datepicker.css" rel="stylesheet" />
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>



    <style>
        fieldset {
            border: 1px solid #01baf2;
            padding: 10px;
            margin-bottom: 10px;
            width: 100%;
        }

        legend {
            display: block;
            white-space: normal;
            width: initial;
            padding: 5px 15px;
            margin: 0;
            font-size: 12px;
            color: #011ff2;
            text-transform: uppercase;
            /*background-color: #d72d4c;*/
            border: 1px solid #01baf2;
            font-weight: 600;
        }


        .form-control {
            width: 100% !important;
        }

        a {
            color: blue;
        }

        @media print {

            .hide_print, .main-footer, .dt-buttons, .dataTables_filter, .crumbs, .menu, .wrapper {
                display: none;
            }

            tfoot, thead {
                display: table-row-group;
                bottom: 0;
            }
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3><b>शिकायत की स्थिति </b></h3>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row hide_print">
            <div class="col-md-2">
                <div class="form-group">
                    <label>Status<span style="color: red;">*</span></label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                        <asp:ListItem Value="All">All</asp:ListItem>
                        <asp:ListItem Value="Pending">Pending</asp:ListItem>
                        <asp:ListItem Value="Closed">Closed</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-2">
                <div class="form-group">
                    <label>From Date<span style="color: red;">*</span></label>
                    <asp:TextBox ID="txtFromDate" runat="server" placeholder="Select From Date.." class="form-control DateAdd" autocomplete="off" data-provide="datepicker" onpaste="return false" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-2">
                <div class="form-group">
                    <label>To Date</label><span style="color: red">*</span>
                    <asp:TextBox ID="txtToDate" runat="server" placeholder="Select To Date.." class="form-control DateAdd" autocomplete="off" data-provide="datepicker" onpaste="return false" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-2">
                <div class="form-group">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-block btn-success" Style="margin-top: 23px;" Text="खोजें" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="col-md-2">
                <div class="form-group">
                    <a class="btn btn-block btn-info" style="margin-top: 23px;" href="ComplainantList.aspx">Cancel</a>
                </div>
            </div>
        </div>
        <div class="form-group"></div>
        <div class="form-group"></div>
        <div class="row">
            <div class="col-md-12">
                <div class=" table-responsive">
                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="ComplainantID" ClientIDMode="Static" AutoGenerateColumns="false" class="lastdatatable table table-hover table-bordered table-striped" OnRowCommand="GridView1_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="SNo." ItemStyle-Width="10" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    <asp:Label ID="lblComplainantID" CssClass="hidden" Visible="false" Text='<%# Eval("ComplainantID").ToString() %>' runat="server" />
                                    <asp:Label ID="lblFStatus" Text='<%# Eval("FStatus").ToString() %>' runat="server" Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="btnFeedBack" runat="server" CausesValidation="False" CommandName="Select" Text='<%# Eval("FStatus").ToString()=="Pending"?"Feedback":"" %>' CssClass="label label-info"  Style="margin-top:3px;"></asp:LinkButton>--%>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:HyperLink ID="hpPrint" runat="server" Target="_blank" CssClass="label label-warning">Print</asp:HyperLink>
                                    <%--<asp:LinkButton ID="hpView" runat="server" CssClass="hideCss label label-info" CommandArgument='Print' CommandName="View" Text='<%# Eval("FStatus").ToString()=="Pending"?"":"Print" %>' ></asp:LinkButton>--%>
                                     &nbsp;
                                     &nbsp;
                                   <asp:LinkButton ID="btnDetail" runat="server" CssClass="label label-primary" Style="margin: 14px;" Text="View" CommandName="btnView" CommandArgument='<%# Eval("ComplainantID") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" Text='<%# Eval("Status").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="शिकायत क्रमांक">
                                <ItemTemplate>
                                    <asp:Label ID="lblComplaintNo" Text='<%# Eval("ComplaintNo").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="दिनांक">
                                <ItemTemplate>
                                    <asp:Label ID="lblComplaintDate" Text='<%# Eval("ComplaintDate").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="शिकायतकर्ता का नाम">
                                <ItemTemplate>
                                    <asp:Label ID="lblNameOfComplainant" Text='<%# Eval("NameOfComplainant").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="पिता / पति का नाम">  Thise Line Commnented By Bhanu on 05-05-2022 As Change Request 
                                <ItemTemplate>
                                    <asp:Label ID="lblFatherHusbandName" Text='<%# Eval("FatherHusbandName").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="लिंग">
                                <ItemTemplate>
                                    <asp:Label ID="lblGenderOfComplainant" Text='<%# Eval("GenderOfComplainant").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="मोबाइल नं.">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobileNoOfComplainant" Text='<%# Eval("MobileNoOfComplainant").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="ई - मेल"> Thise Line Commnented By Bhanu on 05-05-2022 As Change Request
                                <ItemTemplate>
                                    <asp:Label ID="lblEmailOfComplainant" Text='<%# Eval("EmailOfComplainant").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="शिकायतकर्ता का पूरा पता">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddressOfComplainant" Text='<%# Eval("AddressOfComplainant").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="शिकायत का प्रकार">  Thise Line Commnented By Bhanu on 05-05-2022 As Change Request
                                <ItemTemplate>
                                    <asp:Label ID="lblComplaintType" Text='<%# Eval("ComplaintType").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="पशु का प्रकार">   Thise Line Commnented By Bhanu on 05-05-2022 As Change Request
                                <ItemTemplate>
                                    <asp:Label ID="lblTypeOfAnimal" Text='<%# Eval("TypeOfAnimal").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="पशु की उम्र">   Thise Line Commnented By Bhanu on 05-05-2022 As Change Request
                                <ItemTemplate>--%>
                            <%--   <asp:Label ID="lblAgeOfAnimal" Text='<%# Eval("AgeOfAnimal").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="घटना का स्थान">  Thise Line Commnented By Bhanu on 05-05-2022 As Change Request
                                <ItemTemplate>
                                    <asp:Label ID="lblPlaceOfEvent" Text='<%# Eval("PlaceOfEvent").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="पशु चिकित्सक के अस्पताल का पता">   Thise Line Commnented By Bhanu on 05-05-2022 As Change Request
                                <ItemTemplate>
                                    <asp:Label ID="lblHospitalAddress" Text='<%# Eval("HospitalAddress").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="शिकायत का संक्षिप्त विवरण">   Thise Line Commnented By Bhanu on 05-05-2022 As Change Request
                                <ItemTemplate>
                                    <asp:Label ID="lblDetailOfComplaint" Text='<%# Eval("DetailOfComplaint").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="जिसके विरुद्ध शिकायत की जा रही है उसका नाम">
                                <ItemTemplate>
                                    <asp:Label ID="lblNameAgainstComplaint" Text='<%# Eval("NameAgainstComplaint").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--  <asp:TemplateField HeaderText="मोबाइल नं">  // START HERE Thise Line Commnented By Bhanu on 05-05-2022 As Change Request
                                <ItemTemplate>
                                    <asp:Label ID="lblMobileNoAgainstComplaint" Text='<%# Eval("MobileNoAgainstComplaint").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="जिसके विरुद्ध शिकायत की जा रही उसकी ईमेल">  
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EmailofAgainstComplaint").ToString() %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="क्या वह रजिस्टर्ड डॉक्टर है">  
                                <ItemTemplate>
                                    <asp:Label ID="lblRegistrationType" Text='<%# Eval("RegistrationType").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="रजिस्ट्रेशन नंबर">   
                                <ItemTemplate>
                                    <asp:Label ID="lblRegistration" runat="server" Text='<%# Eval("RegistraionNumberAgainstComplaint").ToString() %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="राज्य पशु चिकित्सा परिषद">
                                <ItemTemplate>
                                    <asp:Label ID="lblSVC" runat="server" Text='<%# Eval("StateVerinaryCouncilName").ToString() %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="घर का पता">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("ResidentialAddressofAgainstCompalint").ToString() %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                
                            <asp:TemplateField HeaderText="Documents">
                                <ItemTemplate>
                                    <a href='<%# "../" + Eval("FU_Doc1").ToString() %>' class="label label-primary" target="_blank"><%# Eval("FU_Doc1").ToString()==""?"":"View" %></a>
                                    &nbsp;
                                    <a href='<%# "../" + Eval("FU_Doc2").ToString() %>' class="label label-primary" target="_blank"><%# Eval("FU_Doc2").ToString()==""?"":"View" %></a>
                                     &nbsp;
                                    <a href='<%# "../" + Eval("Complaint_Documnet1").ToString() %>' class="label label-primary" target="_blank"><%# Eval("Complaint_Documnet1").ToString()==""?"":"View" %></a>
                                     &nbsp;
                                     <a href='<%# "../" + Eval("Complaint_Documnet2").ToString() %>' class="label label-primary" target="_blank"><%# Eval("Complaint_Documnet2").ToString()==""?"":"View" %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="अन्य विवरण">
                                <ItemTemplate>
                                    <asp:Label ID="lblOtherRemark" Text='<%# Eval("OtherRemark").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Feedback">
                                <ItemTemplate>
                                    <asp:Label ID="lblFeedback" Text='<%# Eval("Feedback").ToString() %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Feedback Doc">
                                <ItemTemplate>
                                    <a href='<%# "../" + Eval("FeedbackDocument").ToString() %>' class="label label-primary" target="_blank"><%# Eval("FeedbackDocument").ToString()==""?"":"View" %></a> &nbsp;&nbsp;
                                </ItemTemplate>        
                            </asp:TemplateField> // START HERE Thise Line Commnented By Bhanu on 05-05-2022 As Change Request  --%>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <!--Start View BillByBillDetail Modal   Comment Thise Gridview on 5-May-2022 by bhanu As per Change Request.-->
        <%--    <div class="modal fade" id="FeedbackModal" role="dialog">
                <div class="modal-dialog modal-lg">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Feedback</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>शिकायत क्रमांक</label>
                                        <asp:Label ID="lblMComplaintNo" runat="server" CssClass="form-control" Style="background-color: #d7d7d7;" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>दिनांक</label>
                                        <asp:Label ID="lblMComplaintDate" runat="server" CssClass="form-control" Style="background-color: #d7d7d7;" Text=""></asp:Label>

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>शिकायतकर्ता का नाम</label>
                                        <asp:Label ID="lblMNameOfComplainant" runat="server" CssClass="form-control" Style="background-color: #d7d7d7;" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>पिता / पति का नाम</label>
                                        <asp:Label ID="lblMFatherHusbandName" runat="server" CssClass="form-control" Style="background-color: #d7d7d7;" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>जिसके विरुद्ध शिकायत की जा रही है उसका नाम</label>
                                        <asp:Label ID="lblMagainstofComplaint" runat="server" CssClass="form-control" Style="background-color: #d7d7d7;" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>शिकायत</label>
                                        <asp:Label ID="lblMcompalaint" runat="server" CssClass="form-control" Style="background-color: #d7d7d7; height: 70px"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Feedback<span style="color: red;">*</span></label>
                                        <asp:TextBox ID="txtFeedback" runat="server" placeholder="Enter Feedback..." class="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Feedback Document</label>
                                        <asp:FileUpload ID="FU_FeedbackDocument" runat="server" CssClass="form-control" onchange="UploadControlValidationForLenthAndFileFormat(100, 'JPEG*PNG*JPG*GIF*PDF*DOC*DOCX', this),ValidateFileSize(this)" />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="return validateSubitem();" />
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div> --%>
 <!--Start View BillByBillDetail Modal   Comment Thise Gridview on 5-May-2022 by bhanu As per Change Request.-->
        </div>
        </div>


        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js" type="text/javascript"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js" type="text/javascript"></script>

        <script src="../js/bootstrap-datepicker.js" type="text/javascript"></script>


        <link href="css/dataTables.bootstrap.min.css" rel="stylesheet" />
        <link href="css/buttons.dataTables.min.css" rel="stylesheet" />
        <link href="css/jquery.dataTables.min.css" rel="stylesheet" />
        <script src="js/jquery.dataTables.min.js" type="text/javascript"></script>
        <script src="js/jquery.dataTables.min.js" type="text/javascript"></script>
        <script src="js/dataTables.bootstrap.min.js" type="text/javascript"></script>
        <script src="js/dataTables.buttons.min.js" type="text/javascript"></script>
        <script src="js/buttons.flash.min.js" type="text/javascript"></script>
        <script src="js/jszip.min.js" type="text/javascript"></script>
        <script src="js/pdfmake.min.js" type="text/javascript"></script>
        <script src="js/vfs_fonts.js" type="text/javascript"></script>
        <script src="js/buttons.html5.min.js" type="text/javascript"></script>
        <script src="js/buttons.print.min.js" type="text/javascript"></script>
        <script src="js/buttons.colVis.min.js" type="text/javascript"></script>
        <script src="js/fromkeycode.js" type="text/javascript"></script>
        <script type="text/javascript">

            $('.lastdatatable').DataTable({
                // paging: false,
                dom: 'Bfrtip',
                ordering: false,
                buttons: [
                    {
                        extend: 'colvis',
                        collectionLayout: 'fixed two-column',
                        text: '<i class="fa fa-eye"></i> Columns'
                    },
                    //{
                    //    extend: 'print',
                    //    text: '<i class="fa fa-print"></i> Print',
                    //    title: $('h1').text(),
                    //    footer: true,
                    //    autoPrint: true
                    //},
                    {
                        extend: 'excel',
                        text: '<i class="fa fa-file-excel-o"></i> Excel',
                        title: $('h3').text(),
                        exportOptions: {
                            columns: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 17]
                        },
                        footer: true
                    }

                ]
            });



            $(document).ready(function () {
                $('#GridView1').DataTable();
            });

            $('.DateAdd').datepicker({
                autoclose: true,
                format: 'dd/mm/yyyy'
            })

            function ShowFeedbackModalModal() {
                $('#FeedbackModal').modal('show');
            }

           <%-- function validateSubitem() { // thise Function Comment on 5-MAy-2022 by bhanu as per change request.


                if (document.getElementById('<%=txtFeedback.ClientID%>').value.trim() == "") {
                    alert("Enter Feedback.");
                    return false;
                }
                else {
                    return true;
                }
            }--%>
        </script>
        <script type="text/javascript">
            function UploadControlValidationForLenthAndFileFormat(maxLengthFileName, validFileFormaString, that) {
                //ex---------------
                //maxLengthFileName=50;
                //validFileFormaString=JPG*JPEG*PDF*DOCX
                //uploadControlId=upSaveBill
                //ex---------------

                var msg = '';
                if (document.getElementById(that.id).value != '') {
                    var size = document.getElementById(that.id);

                    var fileName = document.getElementById(that.id).value;
                    var lengthFileName = parseInt(document.getElementById(that.id).value.length)

                    var fileExtacntionArray = new Array();
                    fileExtacntionArray = fileName.split('.');

                    if (fileExtacntionArray.length == 2) {

                        var fileExtacntion = fileExtacntionArray[fileExtacntionArray.length - 1];


                        if (lengthFileName >= parseInt(maxLengthFileName) + parseInt(1)) {
                            msg += '- File Name Should be less than ' + maxLengthFileName + ' characters. \n';
                        }
                        for (i = 0; i <= (fileName.length - 1) ; i++) {
                            var charFileName = '';

                            charFileName = fileName.substring(i, i + 1);

                            if ((charFileName == '~') || (charFileName == '!') || (charFileName == '@') || (charFileName == '#') || (charFileName == '$') || (charFileName == '%') || (charFileName == '&') || (charFileName == '*') || (charFileName == '{') || (charFileName == '}') || (charFileName == '|') || (charFileName == '<') || (charFileName == '>') || (charFileName == '?')) {

                                msg += '- Special character not allowed in file name. \n';
                                break;
                            }

                        }
                        var isFileFormatCorrect = false;
                        var strValidFormates = '';

                        if (validFileFormaString != "") {

                            var fileFormatArray = new Array();
                            fileFormatArray = validFileFormaString.split('*');

                            for (var j = 0; j < fileFormatArray.length; j++) {
                                if (fileFormatArray[j].toUpperCase() == fileExtacntion.toUpperCase()) {
                                    isFileFormatCorrect = true;
                                }

                                if (j == fileFormatArray.length - 1) {
                                    strValidFormates += '.' + fileFormatArray[j].toLowerCase();

                                }
                                else {
                                    strValidFormates += '.' + fileFormatArray[j].toLowerCase() + '/';

                                }
                            }

                            if (isFileFormatCorrect == false) {
                                msg += 'File Format Is Not Correct (Only ' + strValidFormates + ').\n';
                            }
                        }

                    }
                    else {
                        msg += '- File Name is incorrect';
                    }
                    if (msg != '') {
                        document.getElementById(that.id).value = "";
                        alert(msg);
                        return false;
                    }
                    else {
                        return true;
                    }

                }
            }
            function ValidateFileSize(a) {

                var uploadcontrol = document.getElementById(a.id);
                if (uploadcontrol.files[0].size > 20971520) {
                    alert('File size should not greater than 5 mb.');
                    document.getElementById(a.id).value = '';
                    return false;
                }
                else {
                    return true;
                }

            }
        </script>
</asp:Content>

