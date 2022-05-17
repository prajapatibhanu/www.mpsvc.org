using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class AdminSection_FrmSecondLevelValid : System.Web.UI.Page
{

    APIProcedure objdb = new APIProcedure();
    CommonFuction objcf = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    string mbNo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsVerify"] != null)
        {
            if (Session["IsVerify"].ToString() == "0")
            {
                Response.Redirect("../index.html");
            }
        }
        else
        {
            Response.Redirect("../index.html");
        }

        if (Session["UId"] != null)
        {
            if (!Page.IsPostBack)
            {
                GrdPendingReg.Visible = true;

                //GrdTransfer.Visible = false;
                GridFillLoad();
            }
        }
        else
        {
            Response.Redirect("../index.html");
        }
    }
    public void GridFillLoad()
    {
        try
        {
            if (rbPending.Checked == true)
            {
                GrdPendingReg.DataSource = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "0" }, "dataset");
                GrdPendingReg.DataBind();
            }
            if (rbRenew.Checked == true)
            {
                GrdRenew.DataSource = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "1" }, "dataset");
                GrdRenew.DataBind();
            }
            if (rbTransfer.Checked == true)
            {
               GrdTransfer.DataSource = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "2" }, "dataset");
               GrdTransfer.DataBind();
            }
            // if (rbTransfer.Checked == true)
            // {
                // GrdTransfer.DataSource = objdb.ByProcedure("UpdateVerication", new string[] { "flag", "RegistrationStatus" }, new string[] { "3", "2" }, "dataset");
                // GrdTransfer.DataBind();
            // }
            if (rbOutsideTransfer.Checked == true)
            {
                GrdTransferOutside.DataSource = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "3" }, "dataset");
                GrdTransferOutside.DataBind();
            }
            if (rbIDCard.Checked == true)
            {
                GridDupIDCard.DataSource = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "4" }, "dataset");
                GridDupIDCard.DataBind();
            }         
            if (rbDuplicate.Checked == true)
            {
                GrdDupicateReg.DataSource = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "5" }, "dataset");
                GrdDupicateReg.DataBind();
            }
            if (rbQualification.Checked == true)
            {
                GrdQualificationUpdate.DataSource = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "6" }, "dataset");
                GrdQualificationUpdate.DataBind();
            }
            if (rbProvisional.Checked == true)
            {
                GrdProvisional.DataSource = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "7" }, "dataset");
                GrdProvisional.DataBind();
            }

        }
        catch { }
    }

    protected void GrdProvisional_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdProvisional.Rows[GrdProvisional.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("EditProvisionalRegistration.aspx?editProvisional=" + Server.UrlEncode(var));
    }

    protected void GrdPaperMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDupicateReg.PageIndex = e.NewPageIndex;
        GrdTransferOutside.PageIndex = e.NewPageIndex;
        GrdPendingReg.PageIndex = e.NewPageIndex;
        GrdTransfer.PageIndex = e.NewPageIndex;
        GrdRenew.PageIndex = e.NewPageIndex;
        GrdProvisional.PageIndex = e.NewPageIndex;
        GrdQualificationUpdate.PageIndex = e.NewPageIndex;
        GridDupIDCard.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSearch.Text.Trim() != "")
            {
                Filtergrid();
            }
        }
        catch { }
    }
    public void Filtergrid()
    {
        try
        {
            if (rbPending.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "0" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '" + txtSearch.Text.Trim() + "' or FName like '" + txtSearch.Text.Trim() + "' or MobileNo like '" + txtSearch.Text.Trim() + "'  or EmailId like'" + txtSearch.Text.Trim() + "'";
                dt.DefaultView.ToTable();
                GrdPendingReg.DataSource = dt;
                GrdPendingReg.DataBind();
            }
            if (rbRenew.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "1" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '" + txtSearch.Text.Trim() + "' or FName like '" + txtSearch.Text.Trim() + "' or MobileNo like '" + txtSearch.Text.Trim() + "'  or EmailId like'" + txtSearch.Text.Trim() + "'";
                dt.DefaultView.ToTable();
                GrdRenew.DataSource = dt;
                GrdRenew.DataBind();
            }
            if (rbTransfer.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "2" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '" + txtSearch.Text.Trim() + "' or FName like '" + txtSearch.Text.Trim() + "' or MobileNo like '" + txtSearch.Text.Trim() + "'  or EmailId like'" + txtSearch.Text.Trim() + "'";
                dt.DefaultView.ToTable();
                GrdTransfer.DataSource = dt;
                GrdTransfer.DataBind();
            }
            if (rbOutsideTransfer.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "3" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '" + txtSearch.Text.Trim() + "' or FName like '" + txtSearch.Text.Trim() + "' or MobileNo like '" + txtSearch.Text.Trim() + "'  or EmailId like'" + txtSearch.Text.Trim() + "'";
                dt.DefaultView.ToTable();
                GrdTransferOutside.DataSource = dt;
                GrdTransferOutside.DataBind();
            }
            if (rbIDCard.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "4" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '" + txtSearch.Text.Trim() + "' or FName like '" + txtSearch.Text.Trim() + "' or MobileNo like '" + txtSearch.Text.Trim() + "'  or EmailId like'" + txtSearch.Text.Trim() + "'";
                dt.DefaultView.ToTable();
                GridDupIDCard.DataSource = dt;
                GridDupIDCard.DataBind();
            }
            if (rbDuplicate.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "5" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '" + txtSearch.Text.Trim() + "' or FName like '" + txtSearch.Text.Trim() + "' or MobileNo like '" + txtSearch.Text.Trim() + "'  or EmailId like'" + txtSearch.Text.Trim() + "'";
                dt.DefaultView.ToTable();
                GrdDupicateReg.DataSource = dt;
                GrdDupicateReg.DataBind();
            }
            if (rbQualification.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "6" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '" + txtSearch.Text.Trim() + "' or FName like '" + txtSearch.Text.Trim() + "' or MobileNo like '" + txtSearch.Text.Trim() + "'  or EmailId like'" + txtSearch.Text.Trim() + "'";
                dt.DefaultView.ToTable();
                GrdQualificationUpdate.DataSource = dt;
                GrdQualificationUpdate.DataBind();
            }

            if (rbProvisional.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcVerificationSecondLevel", new string[] { "ApplicationRequestId" }, new string[] { "7" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '" + txtSearch.Text.Trim() + "' or FName like '" + txtSearch.Text.Trim() + "' or MobileNo like '" + txtSearch.Text.Trim() + "'  or EmailId like'" + txtSearch.Text.Trim() + "'";
                dt.DefaultView.ToTable();
                GrdProvisional.DataSource = dt;
                GrdProvisional.DataBind();
            }


        }
        catch { }
    }

    protected void rbDuplicate_CheckedChanged(object sender, EventArgs e)
    {
        if (rbDuplicate.Checked == true)
        {
            GrdDupicateReg.Visible = true;
            GrdTransferOutside.Visible = false;
            GrdPendingReg.Visible = false;
            GrdTransfer.Visible = false;
            GrdRenew.Visible = false;
            GrdProvisional.Visible = false;
            GridDupIDCard.Visible = false;
            GrdQualificationUpdate.Visible = false;
            GridFillLoad();
        }
    }

    protected void rbOutsideTransfer_CheckedChanged(object sender, EventArgs e)
    {
        if (rbOutsideTransfer.Checked == true)
        {
            GrdTransferOutside.Visible = true;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdTransfer.Visible = false;
            GrdRenew.Visible = false;
            GrdProvisional.Visible = false;
            GridDupIDCard.Visible = false;
            GrdQualificationUpdate.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbRenew_CheckedChanged(object sender, EventArgs e)
    {
        if (rbRenew.Checked == true)
        {
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdTransfer.Visible = false;
            GrdRenew.Visible = true;
            GrdProvisional.Visible = false;
            GridDupIDCard.Visible = false;
            GrdQualificationUpdate.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbTransfer_CheckedChanged(object sender, EventArgs e)
    {
        if (rbTransfer.Checked == true)
        {
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdRenew.Visible = false;
            GrdTransfer.Visible = true;
            GrdProvisional.Visible = false;
            GridDupIDCard.Visible = false;
            GrdQualificationUpdate.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbPending_CheckedChanged(object sender, EventArgs e)
    {
        if (rbPending.Checked == true)
        {
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = true;
            GrdRenew.Visible = false;
            GrdTransfer.Visible = false;
            GrdProvisional.Visible = false;
            GridDupIDCard.Visible = false;
            GrdQualificationUpdate.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbProvisional_CheckedChanged(object sender, EventArgs e)
    {
        if (rbProvisional.Checked == true)
        {
            GrdProvisional.Visible = true;
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdRenew.Visible = false;
            GrdTransfer.Visible = false;
            GridDupIDCard.Visible = false;
            GrdQualificationUpdate.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbIDCard_CheckedChanged(object sender, EventArgs e)
    {
        if (rbIDCard.Checked == true)
        {
            GridDupIDCard.Visible = true;
            GrdQualificationUpdate.Visible = false;
            GrdProvisional.Visible = false;
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdRenew.Visible = false;
            GrdTransfer.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbQualification_CheckedChanged(object sender, EventArgs e)
    {
        if (rbQualification.Checked == true)
        {
            GridDupIDCard.Visible = false;
            GrdQualificationUpdate.Visible = true;
            GrdProvisional.Visible = false;
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdRenew.Visible = false;
            GrdTransfer.Visible = false;
            GridFillLoad();
        }
    }
    protected void GrdPendingReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        // string RegNo = GrdPendingReg.Rows[0].Cells[2]
        Button btn = new Button();
        btn = (Button)GrdPendingReg.Rows[GrdPendingReg.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("EditRegistration.aspx?editR=" + Server.UrlEncode(var));
    }
    protected void GrdRenew_SelectedIndexChanged(object sender, EventArgs e)
    {
        // string RegNo = GrdPendingReg.Rows[0].Cells[2]
        Button btn = new Button();
        btn = (Button)GrdRenew.Rows[GrdRenew.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("EditRegistration.aspx?editR=" + Server.UrlEncode(var));
    }
    protected void GrdTransfer_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdTransfer.Rows[GrdTransfer.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        //Response.Redirect("~/TransferRegistration.aspx?editTransfer=" + Server.UrlEncode(var));
       // Response.Redirect("../VerifyForm/VerifyTransferregistrationMP.aspx?var=" + Server.UrlEncode(var));
	   Response.Redirect("../TransferRegistrationoutofMP.aspx?editTransfer=" + Server.UrlEncode(var));
       
    }
    protected void GrdTransferOutside_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdTransferOutside.Rows[GrdTransferOutside.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("EditRegistration.aspx?editR=" + Server.UrlEncode(var));
    }
    protected void GrdDupicateReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdDupicateReg.Rows[GrdDupicateReg.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("~/DuplicateCertificate.aspx?editDuplicate=" + Server.UrlEncode(var));
    }
    protected void GrdQualificationUpdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdQualificationUpdate.Rows[GrdQualificationUpdate.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("EditQualification.aspx?editQ=" + Server.UrlEncode(var));
    }
    protected void GridDupIDCard_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GridDupIDCard.Rows[GridDupIDCard.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("~/DuplicateCertificate.aspx?editDuplicate=" + Server.UrlEncode(var));
    }

}