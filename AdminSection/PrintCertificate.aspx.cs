using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Text;

public partial class AdminSection_PrintCertificate : System.Web.UI.Page
{
    DataTable Dt;
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objReports = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UId"] != null)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    Regstration_Certificate();
                }

            }
        }
        else
        {
            Response.Redirect("../index.html");
        }
    }
  

    private void Regstration_Certificate()
    {
        string Rpt = "";
        StringBuilder sbReceipt = new StringBuilder();

        sbReceipt.Append("<table width='700px'   style='border-style:solid; border-color:Black' height='900px'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("<table width='650px' border='0' height='900px' >");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color:steelblue;'>");
        sbReceipt.Append("<b>FORM-X</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color:steelblue;'>");
        sbReceipt.Append("<b>[See rule 10(3)]</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color:steelblue; font-size:x-large'>");
        sbReceipt.Append("<b>CERTIFICATE OF REGISTRATION</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td colspan='2'>");
        sbReceipt.Append("");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color:steelblue;font-size:small'>");
        sbReceipt.Append("Madhya Pradesh State Veterinary Council established under Section 32");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color:steelblue;font-size:small'>");
        sbReceipt.Append("of the Indian Veterinary Council Act, 1984 (No. 52 of 1984) ");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("<table width='550px' border='0'  style='border-style:solid;'>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'right' width='60%'>");
        sbReceipt.Append("<img height='100px' width='100px' src='../images/Vet-Council-Logo.bmp' />");
        sbReceipt.Append("</td>");
        sbReceipt.Append("<td align= 'center'>");
        sbReceipt.Append("<img height='100px' width='100px' src='../images/ashish_kundra_IAS.jpg' />");

        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");
        sbReceipt.Append("<table>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left'>");
        sbReceipt.Append("<table width= '65%' style='border-style:solid; border-color:steelblue'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' style='color:steelblue; font-weight:bold'>");
        sbReceipt.Append("No. MPSVC &nbsp;&nbsp;&nbsp;<span style='color:maroon;'> 2567/2008 </span>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");

        sbReceipt.Append("<td align= 'right'>");
        sbReceipt.Append("<table width= '80%' style='border-style:solid; border-color:steelblue'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' style='color:steelblue; font-weight:bold'>");
        sbReceipt.Append("Date &nbsp;&nbsp;&nbsp;<span style='color:maroon;'> 26/11/2008</span>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");



        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='color:steelblue; font-weight:bold'>");
        sbReceipt.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This is to certify that <span style='color:maroon;'> Dr. Manoj Kumar Gautam  </span> resident of  <span style='color:maroon;'> Madhya</span>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='color:steelblue; font-weight:bold'>");
        sbReceipt.Append("<span style='color:maroon;'>Pradesh </span>   have been  duly  registered  as  &nbsp; Registered Veterinary &nbsp; Practitioner");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='color:steelblue; font-weight:bold'>");
        sbReceipt.Append("and is entitled to all the  privileges Granted   to such practitioners   under the");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='color:steelblue; font-weight:bold'>");
        sbReceipt.Append("Indian Veterinary   Council Act,   1984 (No. 52 of 1984). This Registration    has");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='color:steelblue; font-weight:bold'>");
        sbReceipt.Append("been effected  with &nbsp; the  Madhya  Pradesh  State Veterinary   Council,  &nbsp;   under    ");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='color:steelblue; font-weight:bold'>");
        sbReceipt.Append("the said act.");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");



        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='color:steelblue; font-weight:bold'>");
        sbReceipt.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In witness   where of  are  here &nbsp;&nbsp; with  affixed  &nbsp;&nbsp; the seal of  the &nbsp;&nbsp; Madhya");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='color:steelblue; font-weight:bold'>");
        sbReceipt.Append("Pradesh State Veterinary Council and Signature of the Registrar of the ");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color:steelblue; font-weight:bold'>");
        sbReceipt.Append("said State Council.");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' >");
        sbReceipt.Append("Date of issue");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' >");
        sbReceipt.Append("11/09/2015");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");



        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'right' colspan='2' style='color:steelblue; font-weight:bold' >");
        sbReceipt.Append("Signature of Registrar");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color:steelblue; '>");
        sbReceipt.Append("<hr/>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");



        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='font-size:small; color:steelblue;'>");
        sbReceipt.Append("(This Certificate is the property of the Madhya Pradesh State Veterinary Council, and is issued to  the ");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='font-size:small; color:steelblue;''>");
        sbReceipt.Append(" Registered  Veterinary Practitioner  mentioned above under rule 10 (3) of the  Madhya Pradesh State ");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='font-size:small; color:steelblue;''>");
        sbReceipt.Append("Veterinary Council rules, 1993)");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");
        sbReceipt.Append("</table>");

        dvReceipt.InnerHtml = sbReceipt.ToString();
    }
}
