<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerifyReceipt.aspx.cs" Inherits="AdminSection_VerifyReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .header {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="form-group">
                        <div class="page-header">
                            <div class="header">
                                <h3>MADHYA PRADESH STATE VERERINARY COUNCIL</h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-6">
                    <div class="form-group">
                        <label>Basic Infromation</label>
                        <asp:DetailsView ID="DetailsView1" runat="server" CssClass="table table-bordered" AutoGenerateRows="False">
                            <Fields>
                                <asp:BoundField DataField="RegiNo" HeaderText="RegiNo" />
                                <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                                <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
                                <asp:BoundField DataField="DOB" HeaderText="Date of Birth" />
                                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                <asp:BoundField DataField="PresentOccuption" HeaderText="Present Occuption" />
                                <asp:BoundField DataField="OrganaizationName" HeaderText="Organaization Name" />
                                <asp:BoundField DataField="DepaertmentName" HeaderText="Depaertment Name" />
                                <asp:BoundField DataField="DesinationName" HeaderText="Desination" />
                                <asp:BoundField DataField="PhoneNo" HeaderText="PhoneNo" />
                                <asp:BoundField DataField="MobileNo" HeaderText="Mobile No 1" />
                                <asp:BoundField DataField="MobileNo2" HeaderText="Mobile No 2" />
                                <asp:BoundField DataField="PreferedPhoneNo" HeaderText="Prefered Phone No" />
                                <asp:BoundField DataField="Fax" HeaderText="Fax" />
                                <asp:BoundField DataField="EmailId" HeaderText="Email Address" />

                            </Fields>
                        </asp:DetailsView>
                    </div>
                    <div class="form-group">
                        <label>Address</label>
                        <asp:DetailsView ID="DetailsView2" runat="server" CssClass="table table-bordered" AutoGenerateRows="False">
                            <Fields>
                                <asp:BoundField DataField="ResidentialAddress" HeaderText="Residential Address" />
                                <asp:BoundField DataField="ProfessionalAddress" HeaderText="Professional Address" />
                                <asp:BoundField DataField="PermanentAddress" HeaderText="Permanent Address" />
                                <asp:BoundField DataField="PreferedAdd" HeaderText="PreferedAdd" />
                            </Fields>
                        </asp:DetailsView>
                    </div>
                     <div class="form-group">
                        <label>In Case of NOC</label>
                        <asp:DetailsView ID="DetailsView3" runat="server" CssClass="table table-bordered" AutoGenerateRows="False">
                            <Fields>
                                <asp:BoundField DataField="NocNumber" HeaderText="Noc Number" />
                                <asp:BoundField DataField="NocDate" HeaderText="NocDate" />
                                <asp:BoundField DataField="NocState" HeaderText="Noc State" />
                            </Fields>
                        </asp:DetailsView>
                    </div>

                </div>
                <div class="col-xs-6">
                    <div class="form-group">
                        <label>Qualification [B.V.SC.& A.H.]</label>
                        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" CssClass="table table-bordered">
                            <Columns>
                                <asp:BoundField DataField="University1" HeaderText="Name of University" />
                                <asp:BoundField DataField="CollegeID1" HeaderText="Name of College" />
                                <asp:BoundField DataField="Year1" HeaderText="Passing Year" />
                            </Columns>
                        </asp:GridView>

                        <label>Qualification [M.V.SC.]</label>
                        <asp:GridView runat="server" ID="GridView2" ShowHeader="False" AutoGenerateColumns="False" CssClass="table table-bordered">
                            <Columns>
                                <asp:BoundField DataField="University2" HeaderText="Name of University" />
                                <asp:BoundField DataField="CollegeID2" HeaderText="Name of College" />
                                <asp:BoundField DataField="Year2" HeaderText="Passing Year" />
                            </Columns>
                        </asp:GridView>
                        <label>Qualification [PHD]</label>
                        <asp:GridView runat="server" ID="GridView3" ShowHeader="False" AutoGenerateColumns="False" CssClass="table table-bordered">
                            <Columns>
                                <asp:BoundField DataField="University3" HeaderText="Name of University" />
                                <asp:BoundField DataField="CollegeID3" HeaderText="Name of College" />
                                <asp:BoundField DataField="Year3" HeaderText="Passing Year" />
                            </Columns>
                        </asp:GridView>

                        <label>Qualification [Other]</label>
                        <asp:GridView runat="server" ID="GridView4" ShowHeader="False" AutoGenerateColumns="False" CssClass="table table-bordered">
                            <Columns>
                                <asp:BoundField DataField="University4" HeaderText="Name of University" />
                                <asp:BoundField DataField="CollegeID4" HeaderText="Name of College" />
                                <asp:BoundField DataField="Year4" HeaderText="Passing Year" />
                            </Columns>

                        </asp:GridView>
                    </div>
                   
                    <div class="form-group">
                        <label>Payment Detail</label>
                        <asp:DetailsView ID="DetailsView4" runat="server" CssClass="table table-bordered" AutoGenerateRows="False">
                            <Fields>
                                <asp:BoundField DataField="Isonline" HeaderText="Isonline" />
                                <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                <asp:BoundField DataField="ChequeDate" HeaderText="Cheque Date" />
                                <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No" />
                                <asp:BoundField DataField="RegistrationFees" HeaderText="Registration Fees" />
                                <asp:BoundField DataField="RenewalFees" HeaderText="Renewal Fees" />
                                <asp:BoundField DataField="Transferfees" HeaderText="Transfer Fees" />
                                <asp:BoundField DataField="ServiceCharge" HeaderText="Service Charge" />
                                <asp:BoundField DataField="LateFees" HeaderText="Late Fees" />
                                <asp:BoundField DataField="ReEstablishmentFees" HeaderText="ReEstablishment Fees" />
                                <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                            </Fields>
                        </asp:DetailsView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
