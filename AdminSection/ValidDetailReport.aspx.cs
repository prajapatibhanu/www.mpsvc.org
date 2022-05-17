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

public partial class AdminSection_ValidDetailReport : System.Web.UI.Page
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
                GrdValidReg.Visible = true;
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
            if (rbValid.Checked == true)
            {
                DateTime mydate1 = DateTime.Now;
                GrdValidReg.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { (mydate1).ToString("yyyy/MM/dd"), "11" }, "dataset");
                GrdValidReg.DataBind();
                GrdInvalidReg.DataSource = null;
            }
            if (rbInvalid.Checked == true)
            {
                DateTime mydate = DateTime.Now;
                DateTime Fiveyearbackdate = mydate.AddYears(-5);
                GrdInvalidReg.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { (mydate).ToString("yyyy/MM/dd"), "3" }, "dataset");
                GrdInvalidReg.DataBind();
                GrdValidReg.DataSource = null;
            }
            if (rbTransOut.Checked == true)
            {
                DateTime mydate = DateTime.Now;
                DateTime Fiveyearbackdate = mydate.AddYears(-5);
                GrdTransferOut.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { (mydate).ToString("yyyy/MM/dd"), "Out" }, "dataset");
                GrdTransferOut.DataBind();
                GrdValidReg.DataSource = null;
            }
            // if (rbTransOut.Checked == true)
            // {
                // DateTime mydate = DateTime.Now;
                // DateTime Fiveyearbackdate = mydate.AddYears(-5);
                // GrdTransferOut.DataSource = objdb.ByProcedure("USP_TransferRegistrationOutMP_Update", new string[] { "KeyBoard", "flag" }, new string[] { (mydate).ToString("yyyy/MM/dd"), "6" }, "dataset");
                // GrdTransferOut.DataBind();
                // GrdValidReg.DataSource = null;
            // }
            if (rbCancel.Checked == true)
            {
                DateTime mydate = DateTime.Now;
                DateTime Fiveyearbackdate = mydate.AddYears(-5);
                GridCancel.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { (mydate).ToString("yyyy/MM/dd"), "Can" }, "dataset");
                GridCancel.DataBind();
                GrdValidReg.DataSource = null;
            }
        }
        catch { }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        String popScript;
        Session["PrintSTR"] = HF_GridData.Value;
        popScript = "<script language='javascript' type='text/javascript'>window.open('PrintHTMLReport.aspx','_blank','addressbar=yes,resizable=yes,toolbar=no,status=no,menubar=no,location=center,scrollbars=yes,width=950,height=520')</script>";
        Page.RegisterStartupScript("popScript", popScript);

    }
    protected void rbValid_CheckedChanged(object sender, EventArgs e)
    {
        if (rbValid.Checked == true)
        {
            GrdValidReg.Visible = true;
            GrdInvalidReg.Visible = false;
            GrdTransferOut.Visible = false;
            GridCancel.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbInvalid_CheckedChanged(object sender, EventArgs e)
    {
        if (rbInvalid.Checked == true)
        {
            GrdValidReg.Visible = false;
            GrdInvalidReg.Visible = true;
            GrdTransferOut.Visible = false;
            GridCancel.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbTransOut_CheckedChanged(object sender, EventArgs e)
    {
        if (rbTransOut.Checked == true)
        {
            GrdTransferOut.Visible = true;
            GrdValidReg.Visible = false;
            GrdInvalidReg.Visible = false;
            GridCancel.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbCancel_CheckedChanged(object sender, EventArgs e)
    {
        if (rbCancel.Checked == true)
        {
            GrdTransferOut.Visible = false;
            GrdValidReg.Visible = false;
            GrdInvalidReg.Visible = false;
            GridCancel.Visible = true;
            GridFillLoad();
        }
    }
    protected void GrdValidReg_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdValidReg.PageIndex = e.NewPageIndex;
        GrdInvalidReg.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Filtergrid();
        }
        catch { }
    }

    public void Filtergrid()
    {
        try
        {
            if (rbValid.Checked == true)
            {
                DateTime mydate1 = DateTime.Now;
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { (mydate1).ToString("yyyy/MM/dd"), "11" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '%" + txtSearch.Text.Trim() + "%' or Name like '%" + txtSearch.Text.Trim() + "%' or MobileNo like '%" + txtSearch.Text.Trim() + "%'  or EmailId like'%" + txtSearch.Text.Trim() + "%'";
                dt.DefaultView.ToTable();
                GrdValidReg.DataSource = dt;
                GrdValidReg.DataBind();
                // ViewState["data"] = dt;

            }
            if (rbInvalid.Checked == true)
            {
                DateTime mydate = DateTime.Now;
                DateTime Fiveyearbackdate = mydate.AddYears(-5);
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { (mydate).ToString("yyyy/MM/dd"), "3" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '%" + txtSearch.Text.Trim() + "%' or Name like '%" + txtSearch.Text.Trim() + "%' or MobileNo like '%" + txtSearch.Text.Trim() + "%'  or EmailId like'%" + txtSearch.Text.Trim() + "%'";
                dt.DefaultView.ToTable();
                GrdInvalidReg.DataSource = dt;
                GrdInvalidReg.DataBind();
                // ViewState["data"]=dt;
            }
            if (rbTransOut.Checked == true)
            {
                DateTime mydate = DateTime.Now;
                DateTime Fiveyearbackdate = mydate.AddYears(-5);
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { (mydate).ToString("yyyy/MM/dd"), "Out" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '%" + txtSearch.Text.Trim() + "%' or Name like '%" + txtSearch.Text.Trim() + "%' or MobileNo like '%" + txtSearch.Text.Trim() + "%'  or EmailId like'%" + txtSearch.Text.Trim() + "%' Or StateName like '%" + txtSearch.Text.Trim() + "%'";
                dt.DefaultView.ToTable();
                GrdTransferOut.DataSource = dt;
                GrdTransferOut.DataBind();
            }
            if (rbCancel.Checked == true)
            {
                DateTime mydate = DateTime.Now;
                DateTime Fiveyearbackdate = mydate.AddYears(-5);
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { (mydate).ToString("yyyy/MM/dd"), "Can" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '%" + txtSearch.Text.Trim() + "%' or Name like '%" + txtSearch.Text.Trim() + "%' or MobileNo like '%" + txtSearch.Text.Trim() + "%'  or EmailId like'%" + txtSearch.Text.Trim() + "%'";
                dt.DefaultView.ToTable();
                GridCancel.DataSource = dt;
                GridCancel.DataBind();
            }

        }
        catch { }
    }
}