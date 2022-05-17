using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.xml;
using iTextSharp.text;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using System.Text;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class VerifyForm_Default2 : System.Web.UI.Page
{

    APIProcedure obj = new APIProcedure();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet dsprint = obj.ByProcedure("UpdateVerication", new string[] { "flag" }
                            , new string[] { "1" }, "dataset");


        if (dsprint.Tables[0].Rows.Count > 0)
        {


            string applicantname = dsprint.Tables[0].Rows[0]["Name"].ToString();
            string fathername = dsprint.Tables[0].Rows[0]["FatherName"].ToString();
            string DOB = Convert.ToDateTime(dsprint.Tables[0].Rows[0]["DOB"]).ToString("dd/MM/yyyy");
            string GENDER = dsprint.Tables[0].Rows[0]["Gender"].ToString();
            string residntialAddress = dsprint.Tables[0].Rows[0]["PreferedAdd"].ToString();
            string lblNO = dsprint.Tables[0].Rows[0]["MobileNo"].ToString();
            string lblemail = dsprint.Tables[0].Rows[0]["EmailId"].ToString();
            string lblPR = dsprint.Tables[0].Rows[0]["State_Veterinary_Council_namepresent"].ToString();
            string lblRn = dsprint.Tables[0].Rows[0]["RegiNo"].ToString();
            string lblAppli = dsprint.Tables[0].Rows[0]["StateName"].ToString();
            string lblddno = dsprint.Tables[0].Rows[0]["ChequeNo"].ToString();
            string lblDddrname = dsprint.Tables[0].Rows[0]["Drawn_name_DD"].ToString();
            string lblDate = dsprint.Tables[0].Rows[0]["alDate"].ToString();
            string lblIssuebank = dsprint.Tables[0].Rows[0]["BankName"].ToString();
            string lblIssueBranch = dsprint.Tables[0].Rows[0]["Bank_Branch_Name"].ToString();
            string Lblrison = dsprint.Tables[0].Rows[0]["Remark"].ToString();
            string lblVetenaryCouncil = dsprint.Tables[0].Rows[0]["Registrar_Name"].ToString();
            string lblRAddresst = dsprint.Tables[0].Rows[0]["Registrar_Adresse"].ToString();
            string lblAmount = dsprint.Tables[0].Rows[0]["TotalAmount"].ToString();
            string lblCollegeName = dsprint.Tables[0].Rows[0]["CollegeName"].ToString();
            string lblUniversity = dsprint.Tables[0].Rows[0]["UniversityName"].ToString();
            string lblVr = Convert.ToDateTime(dsprint.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");




            StringBuilder Sb = new StringBuilder();


            Sb.Append("<div class='row col-md-12'>");
            Sb.Append("<h3 style='text-align: center;'> - 110066 </h3>");
            Sb.Append("<h3 style='text-align: center;'>Veterinary Council of India, New Delhi – 110066</h3>");
            Sb.Append("<h3 style='text-align: center;'> APPLICATION FORM</h3>");
            Sb.Append("<h4 style='text-align: center;'>TRANSFER OF REGISTRATION FROM ONE STATE VETERINARY <br />REGISTER TO ANOTHER STATE VETERINARY REGISTER</h4>");
            Sb.Append("<h4 style='text-align:center; '><b>(Under IVC Act 1984, Rule 55)</b></h4>");
            Sb.Append("<h3 style='text-align: center'>PART 1</h3>");

            Sb.Append("<table border='1'>");
            Sb.Append("<tr>");
            Sb.Append("<th> S.No.</th>");
            Sb.Append("<th>Particulars</th>");
            Sb.Append("<td></td>");
            Sb.Append("</tr>");
            Sb.Append("<tr>");
            Sb.Append("<td width='8%'>1.</td>");
            Sb.Append("<td>");
            Sb.Append("Photograph of the Applicant:</td>");
            Sb.Append("<td style='width:500px; height:150px'> HEllo</td>");
            Sb.Append("</tr>");
            Sb.Append("<tr>");
            Sb.Append("<td>2.</td>");
            Sb.Append("<td>");
            Sb.Append("Name of Applicant(in Capital Letter):</td>");
            Sb.Append("<td>" + applicantname + "</td>");
            Sb.Append("</tr>");
            Sb.Append("<tr>");
            Sb.Append("<td>3.</td>");
            Sb.Append("<td>Father’s/Husband Name</td>");
            Sb.Append("<td>" + fathername + "</td>");
            Sb.Append("</tr>");
            Sb.Append("<tr>");
            Sb.Append("<td>4.</td>");
            Sb.Append("<td>Date of Birth</td>");
            Sb.Append("<td>" + DOB + "</td>");
            Sb.Append("</tr>");
            Sb.Append("<tr>");
            Sb.Append("<td>5.</td>");
            Sb.Append("<td>Gender</td>");
            Sb.Append("<td>" + GENDER + "</td>");
            Sb.Append("</tr>");
            Sb.Append("<tr>");
            Sb.Append("<td rowspan='4'>6.</td>");
            Sb.Append("<td colspan='2' style='height: 50px'>Details of recognized Veterinary Qualification:</td>");
            Sb.Append("</tr>");
            Sb.Append("<tr>");
            Sb.Append("<td>A. Degree Nomenclature</td>");
            Sb.Append("<td>Bachelor of Veterinary Science And A.H</td>");
            Sb.Append("</tr>");
            Sb.Append("<tr>");
            Sb.Append("<td>B. Name of College</td>");
            Sb.Append("<td>" + lblCollegeName + "</td>");
            Sb.Append(" </tr>");
            Sb.Append("<tr>");
            Sb.Append("<td>C.Name of Institution awarded Recognized veterinary qualification</td>");

            Sb.Append("<td>" + lblUniversity + "</td>");
            Sb.Append("</tr>");
            Sb.Append("<tr>");
            Sb.Append("<td>7.</td>");
            Sb.Append("<td>Full Correspondence/Residential Address</td>");
            Sb.Append("<td>" + lblRAddresst + " </td>");
            Sb.Append("</tr>");
            Sb.Append("<tr>");
            Sb.Append("<td rowspan='3'>8.</td>");
            Sb.Append("<td colspan='2');> Mobile Number and Email-ID of applicant</td>");
            Sb.Append("</tr>");
            Sb.Append("<tr>");
            Sb.Append("<td>A. Mobile Number of applicant:</td>");
            Sb.Append("<td>" + lblNO + "</tr>");
            Sb.Append(" <tr>");
            Sb.Append(" <td>B. Email-ID of applicant:</td>");
            Sb.Append(" <td>" + lblemail + " </td>");
            Sb.Append("</tr>");
            Sb.Append("</table>");

            //       <div style="page-break-before:always">&nbsp;</div>
            //        <h3 style="text-align: center; color: #0094ff">PART 2</h3> <%-- Start PART-2 HERE ----%>
            //        <div class="row">
            //            <div class="col-md-12">
            //                <h3 style="text-align: center; margin-bottom: 30PX; border:solid">Details of Registration and Transfer applied</h3>
            //            </div>
            //        </div>
            //        <table border="1" class="table table-bordered">
            //            <tr>
            //                <td width="8%">9.</td>
            //                <td>Name of the State Veterinary Council wherein, candidate is presently registered</td>
            //                <td>
            //                    <asp:Label ID="lblPR" runat="server" Text='<%# Eval("State_Veterinary_Council_namepresent")%>'></asp:Label>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td>10.</td>
            //                <td>
            //                    State Veterinary Council Registration Number</td>
            //                <td>
            //                    <asp:Label ID="lblRn" runat="server" Text='<%# Eval("RegiNo")%>'></asp:Label>

            //                </td>
            //            </tr>
            //            <tr>
            //                <td>11.</td>
            //                <td>
            //                    Validity of Registration (dd/mm/yyyy)</td>
            //                <td>
            //                    <asp:Label ID="lblVr" runat="server" Text='<%# Eval("Validupto")%>'></asp:Label>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td>12.</td>
            //                <td>
            //                    Name of the State Veterinary Council wherein, the transfer of registration is applied</td>
            //                <td>
            //                    <asp:Label ID="lblAppli" runat="server" Text='<%# Eval("StateName")%>'></asp:Label>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td rowspan="7">13.</td>
            //                <td colspan="2">
            //                    Payment details of transfer Fee of Rs 15/-. </td>
            //            </tr>
            //            <tr>
            //                <td>1.DD No</td>
            //                <td>
            //                    <asp:Label ID="lblddno" runat="server" Text='<%# Eval("ChequeNo")%>'></asp:Label>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td>2.
            //                    Drawn in the name of</td>
            //                <td>
            //                    <asp:Label ID="lblDddrname" runat="server" Text='<%# Eval("Drawn_name_DD")%>'></asp:Label>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td>3. Date:</td>
            //                <td>
            //                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("alDate")%>'></asp:Label>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td>4. Amount</td>
            //                <td>
            //                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("TotalAmount") %>'></asp:Label>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td>5. Name of issuing Bank</td>
            //                <td>
            //                    <asp:Label ID="lblIssuebank" runat="server" Text='<%# Eval("BankName")%>'></asp:Label>
            //                </td>
            //            </tr>
            //            <tr>

            //                <td>6. Name of issuing Branch</td>
            //                <td>
            //                    <asp:Label ID="lblIssueBranch" runat="server" Text='<%# Eval("Bank_Branch_Name")%>'></asp:Label>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td>14.</td>
            //                <td>
            //                    Reason for seeking transfer of registration:</td>
            //                <td>
            //                    <asp:Label ID="Lblrison" runat="server" Text='<%# Eval("Remark")%>'></asp:Label>
            //                </td>
            //            </tr>
            //            <tr>
            //                <td rowspan="5">15.</td>
            //                <td colspan="2">List of documents enclosed: 
            //                    <%-- <br />
            //                    <br />
            //                    Note-: <b style="color:red;">Strike out which is not applicable</b>--%></td>
            //            </tr>
            //            <tr>
            //                <td>1. DD in original</td>
            //                <td>Yes</td>
            //            </tr>
            //            <tr>
            //                <td>2. Aadhar / Passport / DL/SSLC :
            //                </td>
            //                <td>Yes</td>
            //            </tr>
            //            <tr>
            //                <td>3. Degree certificate (BVSc&AH/MVSc/ PhD/ Other):
            //                </td>
            //                <td>Yes</td>
            //            </tr>
            //            <tr>
            //                <td>4. 
            //                    Copy of the State Veterinary Council Registration Certificate:
            //                </td>
            //                <td>Yes</td>
            //            </tr>
            //        </table> <%-- END PART-2 HERE ----%>
            //       <span style="margin-left: 60px;">Signature of the Applicant:________________________     Submitted to:</span>
            //        <br />
            //        <br />
            //        <span style="margin-left: 60px;">The Registrar: --<b><asp:Label ID="lblVetenaryCouncil" runat="server" Text='<%# Eval("Registrar_Name")%>'></asp:Label></b>
            //           Name of State Veterinary Council</span><br />
            //        <br />
            //       <span>Address:-- 
            //         <b>
            //             <asp:Label ID="lblRAddress" runat="server" Text='<%# Eval("Registrar_Adresse")%>'></asp:Label></b></span>


            //    </div>
            //</div>
            Sb.Append("</div>");

            Divprint.InnerHtml = Sb.ToString();
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("Divprint", "attachment; filename=" + lblNO + ".pdf");
            //Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            //StringWriter str = new StringWriter();
            //HtmlTextWriter html = new HtmlTextWriter(str);
            //Divprint.RenderControl(html);
            //StringReader strRdr = new StringReader(str.ToString());
            //Document Doc = new Document(PageSize.A4, 25f, 25f, 25f, 100f);
            //PdfWriter.GetInstance(Doc, Response.OutputStream);
            //HTMLWorker htmlwrkr = new HTMLWorker(Doc);
            //Doc.Open();
            //htmlwrkr.Parse(strRdr);
            //Doc.NewPage();
            //Doc.Close();
            //Response.Write(Doc);
            //Response.End();


           // HtmlForm form = new HtmlForm();
            //StringReader str = new StringReader(Sb.ToString());
            string mystring = Sb.ToString();
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            System.Xml.XmlTextReader _xmlr = new System.Xml.XmlTextReader(new StringReader(mystring));
            HtmlParser.Parse(pdfDoc, _xmlr);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Table.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
}
}