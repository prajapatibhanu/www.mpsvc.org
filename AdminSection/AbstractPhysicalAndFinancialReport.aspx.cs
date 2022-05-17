using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Globalization;

public partial class AdminSection_AbstractPhysicalAndFinancialReport : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnPrint.Visible = false;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        APIProcedure api = new APIProcedure();
        string Fromdate = Convert.ToDateTime(txtFDate.Text, cult).ToString("yyyy/MM/dd");
        string Todate = Convert.ToDateTime(txtToDate.Text, cult).ToString("yyyy/MM/dd");
        DataSet ds = api.ByProcedure("proc_get_abstract_PF_report_New", new string[] { "FrmDate", "ToDate" }, new string[] { Fromdate, Todate }, "dataset");
        if (ds.Tables[0].Rows.Count > 0)
        {
            divreport.InnerHtml = PrintHTML(ds.Tables[0]);
            btnPrint.Visible = true;
        }
    }
    private string PrintHTML(DataTable dt)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<table width='100%' border='1' cellpadding='0' cellspacing='0'> <tr> <td> Type of Fees </td> <td colspan='2' align='center'> Registration </td><td colspan='2' align='center'> Renewal fees </td> <td colspan='2' align='center'> Service tax </td> <td colspan='2' align='center'> Late Fees </td> <td colspan='2' align='center'> Re-Establishment </td> <td colspan='2' align='center'> Transfer </td> <td colspan='2' align='center'>  Total </td> </tr> <tr><td align='center'> </td> <td align='center'> Amount </td> <td align='center'> Number </td> <td align='center'> Amount </td> <td align='center'> Number</td> <td align='center'> Amount </td> <td align='center'> Number </td><td align='center'> Amount </td> <td align='center'> Number </td> <td align='center'> Amount</td> <td align='center'>  Number </td> <td align='center'> Amount </td> <td align='center'> Number </td> <td align='center'> Amount </td> <td align='center'>  Number </td> </tr>");
        for (int i=0 ; i<=dt.Rows.Count-1 ; i++)
        {
            sb.Append("<tr>");
            sb.Append("<td align='center'> " + dt.Rows[i]["TypeOfFee"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["RegAmt"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["RegNo"].ToString() + " </td>");

            sb.Append("<td align='center'> " + dt.Rows[i]["renewalAmt"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["RenewalNo"].ToString() + " </td>");

            sb.Append("<td align='center'> " + dt.Rows[i]["STAmt"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["STNo"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["LFAmt"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["LFNo"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["ReEstAmt"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["ReEstNo"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["TranAmt"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["TranNo"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["TotalAmt"].ToString() + " </td>");
            sb.Append("<td align='center'> " + dt.Rows[i]["TotalNo"].ToString() + " </td>");
            sb.Append("</tr>");
        }
        sb.Append(" </table>");
        return sb.ToString();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        String popScript;
        Session["PrintStr"] = divreport.InnerHtml;
        popScript = "<script language='javascript' type='text/javascript'>window.open('PrintHTMLReport.aspx','_blank','addressbar=yes,resizable=yes,toolbar=no,status=no,menubar=no,location=center,scrollbars=yes,width=950,height=520')</script>";
        Page.RegisterStartupScript("popScript", popScript);

    }
}
