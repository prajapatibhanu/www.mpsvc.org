using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Globalization;
using System.Data;

public partial class AdminSection_RegistrationDetails : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt;
    CultureInfo cult = new CultureInfo("gu-IN", true);
   
    CommonFuction obCommonFuction = new CommonFuction();
   

    APIProcedure objReports = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UId"] != null)
        {
            if (!Page.IsPostBack)
            {
              
            }
        }
        else
        {
            Response.Redirect("../index.html");
        }
    }
    public void LoadReport(string Flag)
    {
        DateTime DteCheck;
        string RptDate = "", GrDate = "";
        if (txtFDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtFDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }
        if (txtToDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtToDate.Text, cult);
            }
            catch { GrDate = "NoDate"; }
        }

        if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct From Date.');</script>");
        }
        else if (GrDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct End Date.');</script>");
        }
        else
        {
            string val = "";
            if (ddlType.SelectedItem.Text == "Registration Status")
            {
                val = ddlMemType.SelectedItem.Text;
            }
            else
            {
                val = txtValue.Text;
            }
            Dt = objReports.ByProcedure("ProcRegistrationDtl", new string[] { "Flag", "Values", "FromDate", "ToDate" },
                new string[] { ddlType.SelectedItem.Text, val, txtFDate.Text, txtToDate.Text }, "DataTable", "");
            GridView1.DataSource = Dt;
            GridView1.DataBind();
            //if (Dt.Rows.Count > 0)
            //{
            //    ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/AdminSection/RegiReport.rdlc");
            //    ReportViewer1.LocalReport.DataSources.Clear();
            //    ReportViewer1.LocalReport.DataSources.Add(rds);
            //    ReportViewer1.ShowPrintButton = true;
            //    ReportViewer1.LocalReport.Refresh();
            //    ReportViewer1.Visible = true;
            //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OnChange();</script>");
            //}
            //else
            //{
            //    ReportViewer1.Visible = false;
            //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');OnChange();</script>");
            //}
          
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadReport("LabInspection");
    }
  
}