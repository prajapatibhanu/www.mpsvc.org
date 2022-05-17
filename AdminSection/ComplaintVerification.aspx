<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSection/MasterPage.master" AutoEventWireup="true" CodeFile="ComplaintVerification.aspx.cs" Inherits="AdminSection_ComplaintVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../poplink/POPMODAL2bootstrap.min.js" type="text/javascript"></script>
    <link href="../poplink/POPMODAL3bootstrap.min.css" rel="stylesheet" media="screen" />
    <script src="../poplink/POPUPMODAL1jquery.min.js" type="text/javascript"></script>

    <style>
        fieldset {
            border: 1px solid #01baf2;
            padding: 10px;
            margin-bottom: 10px;
            width: 100%;
        }

        .form-control {
            width: 100% !important;
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

        * {
            box-sizing: border-box;
        }

        /* Button used to open the chat form - fixed at the bottom of the page */
        open-button {
            background-color: #555;
            color: white;
            padding: 6px 14px;
            border: none;
            cursor: pointer;
            opacity: 0.8;
            position: fixed;
            bottom: -12px;
            /* right: 28px; */
            width: 139px;
        }

        /* The popup chat - hidden by default */
        .chat-popup {
            display: none;
            position: fixed;
            bottom: 18px;
            right: 15px;
            border: 3px solid #fdf1f1;
            z-index: 9;
            overflow: scroll;
            height: 60%;
        }


        /* Add styles to the form container */
        .form-container {
            max-width: 500px;
            padding: 10px;
            /*background-color:#1c5281;*/
            background-color: #337ab7;
            border-radius: 1%;
        }

            /* Full-width textarea */
            .form-container textarea {
                width: 100%;
                padding: 15px;
                margin: 5px 0 22px 0;
                border: none;
                background: #f1f1f1;
                resize: none;
                min-height: 200px;
            }

                /* When the textarea gets focus, do something */
                .form-container textarea:focus {
                    background-color: #ddd;
                    outline: none;
                }

            /* Set a style for the submit/send button */
            .form-container .btn {
                background-color: #04AA6D;
                color: white;
                padding: 3px 1px;
                border: none;
                cursor: pointer;
                width: 20%;
                margin-bottom: 10px;
                opacity: 0.8;
            }

            /* Add a red background color to the cancel button */
            .form-container .cancel {
                background-color: #11405C;
            }

            /* Add some hover effects to buttons */
            .form-container .btn:hover, .open-button:hover {
                opacity: 0.5;
            }
    </style>

    <script type="text/javascript">
        function openForm() {
            document.getElementById('<%=myForm.ClientID%>').style.display = "block";
            return true;
        }

        function closeForm() {
            document.getElementById('<%=myForm.ClientID%>').style.display = "none";
        }

        function MessageVerify() {
            alert("Application forwarded successfully");
        }

    </script>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <fieldset>
                    <legend>शिकायतकर्ता</legend>

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>शिकायतकर्ता का नाम</label>
                                <asp:TextBox ID="txtComplainantName" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>पिता / पति का नाम</label>
                                <asp:TextBox ID="txtFathername" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>लिंग</label>
                                <asp:TextBox ID="txtGender" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>मोबाइल नं</label>
                                <asp:TextBox ID="txtMobileNOofComplainant" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>ई-मेल</label>
                                <asp:TextBox ID="txtEmailofComplainant" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>शिकायतकर्ता की पहचान का प्रकार</label>
                                <asp:TextBox ID="txtIdentityType" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>शिकायतकर्ता का पहचान क्रंमाक</label>
                                <asp:TextBox ID="txtIdentityNo" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-8">
                            <div class="form-group">
                                <label>शिकायतकर्ता का पूरा पता</label>
                                <asp:TextBox ID="txtAddressOfComplainant" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>शिकायतकर्ता  के पहचान दस्तावेज</label><br />
                                &nbsp;
                                <asp:HyperLink ID="hyperComplainant_IdentityDoc" Target="_blank" runat="server" CssClass="label label-primary" Text="View"></asp:HyperLink>
                            </div>
                        </div>
                    </div>
                </fieldset>
                &nbsp;
                <fieldset>
                    <legend>शिकायत</legend>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>जिसके विरुद्ध शिकायत करना है उसका नाम</label>
                                <asp:TextBox ID="txtnameAgainstComplaint" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>मोबाइल नं (यदि हो तो)</label>
                                <asp:TextBox ID="txtMobilenoAgainstComplaint" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>क्या वह रजिस्टर्ड डॉक्टर है</label>
                                <asp:TextBox ID="txtRegistraionType" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3" id="DivRegistration" visible="false" runat="server">
                            <div class="form-group">
                                <label>डॉक्टर का रजिस्ट्रेशन नंबर</label>
                                <asp:TextBox ID="txtRegistrationNo" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>ईमेल आईडी</label>
                                <asp:TextBox ID="txtEmailIDAgainstComplaint" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>घर का पता</label>
                                <asp:TextBox ID="txtAddressAgainstComplaint" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>राज्य पशु चिकित्सा परिषद का नाम</label>
                                <asp:TextBox ID="txtSVCname" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>शिकायत का प्रकार</label>
                                <asp:TextBox ID="txtComplaintType" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>पशु/पक्षी का प्रकार</label>
                                <asp:TextBox ID="txtAnimalType" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1">
                            <div class="form-group">
                                <label>पशु की उम्र</label>
                                <asp:TextBox ID="txtAninmalAge" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <div class="form-group">
                                <label>घटना का स्थान</label>
                                <asp:TextBox ID="txtPlaceOfEvent" runat="server" ReadOnly="true" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>पशु चिकित्सक के अस्पताल का पता</label>
                                <asp:TextBox ID="txtHospitalAddress" runat="server" ReadOnly="true" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>शिकायत का संक्षिप्त विवरण</label>
                                <asp:TextBox ID="txtDetailofComplaint" runat="server" ReadOnly="true" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>दस्तावेज 1</label>
                                &nbsp;  &nbsp;
                                <asp:HyperLink ID="hYprDoc1" Target="_blank" runat="server" CssClass="label label-primary" Text="View"></asp:HyperLink>
                                &nbsp;
                                <asp:HyperLink ID="hYprDoc2" Target="_blank" runat="server" CssClass="label label-primary" Text="View"></asp:HyperLink>
                                &nbsp;
                                <asp:HyperLink ID="hYprDoc3" Target="_blank" runat="server" CssClass="label label-primary" Text="View"></asp:HyperLink>
                                &nbsp;
                                <asp:HyperLink ID="hYprDoc4" Target="_blank" runat="server" CssClass="label label-primary" Text="View"></asp:HyperLink>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>प्रतिक्रिया/ FeedBack</legend>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Status</label>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                    <asp:ListItem Value="2">Closed</asp:ListItem>
                                    <asp:ListItem Value="3">In Progress</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Document</label>
                                <asp:FileUpload ID="fileupFeedback" runat="server" CssClass="" />&nbsp;&nbsp;
                                <asp:HyperLink ID="hyperFeedbackDoc" runat="server" CssClass="label label-primary" Target="_blank" Style="margin: 0 5px;" Text="View"></asp:HyperLink>
                            </div>
                        </div>

                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:Button ID="btnFeedback" runat="server" Visible="false" CssClass="btn btn-primary open-button" Style="margin: 25px;" Text="Feedback" OnClick="btnFeedback_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>FeedBack</label>
                                <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                <div class="form-group">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfComplaintID" runat="server" />

    <div class="chat-popup" id="myForm" runat="server">
        <div id="formid" runat="server" class="form-container">
            <strong style="color: white;">Previous Feedback</strong>
            <asp:Repeater ID="rptFeedback" runat="server">
                <ItemTemplate>
                    <table style="width: 100%" class="table table-bordered">


                        <thead>
                            <th>S.NO.</th>
                            <th>FeedBack Date</th>
                            <th>Feedback</th>
                        </thead>
                        <td>
                            <asp:Label ID="lblid" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>
                        </td>


                        <td>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Feedback_Date") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFeedback" runat="server" Text='<%# Eval("Feedback") %>'></asp:Label>
                        </td>


                    </table>
                </ItemTemplate>
            </asp:Repeater>

            <%-- <button type="submit" class="btn">Send</button>--%>
            <button type="button" class="btn cancel" onclick="closeForm()">Close</button>
        </div>
    </div>

</asp:Content>

