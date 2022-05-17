using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;

public partial class AdminSection_SendEmailOrSms : System.Web.UI.Page
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
            
            GridFillLoad();

        }
    }
    public void GridFillLoad()
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
        if (Dt.Rows.Count > 0)
        {
            tr1.Visible = true;
            tr2.Visible = true;
            tr3.Visible = true;

            GrdPaperMaster.DataSource = Dt;
            GrdPaperMaster.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OnChange();</script>");
        }
        else
        {
            GrdPaperMaster.DataSource = null;
            GrdPaperMaster.DataBind();
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');OnChange();</script>");
        }
    }
    protected void GrdPaperMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPaperMaster.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadReport("LabInspection");
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (rbEmail.Checked == true)
        {
            foreach (GridViewRow gv in GrdPaperMaster.Rows)
            {
                Label lblMobileNo = (Label)gv.FindControl("lblMobileNo");
                Label lblEmailId = (Label)gv.FindControl("lblEmailId");
                Label lblMemStatus = (Label)gv.FindControl("lblMemStatus");
                
                CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                if (chkSelect.Checked == true && lblMemStatus.Text.Trim().ToLower() != "dead")
                {

                }
            }
        }
        else if (rbSMS.Checked == true)
        {

        }
    }
}