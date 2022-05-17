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

public partial class AdminSection_ViewQualification : System.Web.UI.Page
{
    APIProcedure objdb = new APIProcedure();
    CommonFuction objcf = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UId"] != null)
        {
            if (!Page.IsPostBack)
            {
                GrdQualificationUpdate.Visible = true;
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
            if (rbIDCard.Checked == true)
            {
                GrdDupicateReg.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "4", "2" }, "dataset");
                GrdDupicateReg.DataBind();
            }
            if (rbQualification .Checked == true)
            {
                GrdQualificationUpdate.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "6", "2" }, "dataset");
                GrdQualificationUpdate.DataBind();
            }
            if (rbUpdateinfo.Checked == true)
            {
                GrdProfileUpdatetion.DataSource = objdb.ByProcedure("Proc_GetUserProfileUpdateRequest", new string[] { }, new string[] { }, "dataset");
                GrdProfileUpdatetion.DataBind();
            }
        }
        catch { }

    }

    protected void GrdQualificationUpdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdQualificationUpdate.Rows[GrdQualificationUpdate.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("EditQualification.aspx?editQ=" + Server.UrlEncode(var));
    }
    protected void GrdDupicateReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdDupicateReg.Rows[GrdDupicateReg.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("~/DuplicateCertificate.aspx?editDuplicate=" + Server.UrlEncode(var));
    }
    protected void GrdProfileUpdatetion_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdProfileUpdatetion.Rows[GrdProfileUpdatetion.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("~/frm_userupdateddetails.aspx?editUPD=" + Server.UrlEncode(var));
    }
    protected void GrdQualificationUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdQualificationUpdate.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void rbIDCard_CheckedChanged(object sender, EventArgs e)
    {
        if (rbIDCard.Checked == true)
        {
            GrdDupicateReg.Visible = true;
            GrdProfileUpdatetion.Visible = false;
            GrdQualificationUpdate.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbQualification_CheckedChanged(object sender, EventArgs e)
    {
        if (rbQualification.Checked == true)
        {
            GrdDupicateReg.Visible = false ;
            GrdProfileUpdatetion.Visible = false;
            GrdQualificationUpdate.Visible = true;
            GridFillLoad();
        }
    }
    protected void rbUpdateinfo_CheckedChanged(object sender, EventArgs e)
    {
        if (rbUpdateinfo.Checked == true)
        {
            GrdProfileUpdatetion.Visible = true;
            GrdQualificationUpdate.Visible = false;
            GrdDupicateReg.Visible = false;
            GridFillLoad();
        }
    }
}