using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class AdminSection_CancelRegistration : System.Web.UI.Page
{
    APIProcedure objdb = new APIProcedure();
    CommonFuction objcf = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UId"] != null)
        {
            if (!Page.IsPostBack)
            {
                GrdPendingReg.Visible = true;              
            }
        }
        else
        {
            Response.Redirect("../index.html");
        }
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
                DateTime mydate1 = DateTime.Now;
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { (mydate1).ToString("yyyy/MM/dd"), "6" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "ApplicationNo like '" + txtSearch.Text.Trim() + "' or RegiNo like  '" + txtSearch.Text.Trim() + "' or FName like '" + txtSearch.Text.Trim().ToUpper() + "' or MobileNo like '" + txtSearch.Text.Trim() + "'  or EmailId like'" + txtSearch.Text.Trim() + "'";
                dt.DefaultView.ToTable();
                GrdPendingReg.DataSource = dt;
                GrdPendingReg.DataBind();
                // ViewState["data"] = dt;                

        }
        catch { }
    }
    protected void GrdPaperMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {    
        GrdPendingReg.PageIndex = e.NewPageIndex;
        Filtergrid();
      
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        objdb.ByText("update tblNewRegistration set ApplicationRequestId = 9 , RegistrationStatus = 5, Remark = '"+ txtRemark.Text.Trim() +"'   where id =" + hdnGetId.Value + "");
        ScriptManager.RegisterStartupScript(this, this.GetType(), " ", "MessageAlert();", true);
        GrdPendingReg.DataSource = null;
        GrdPendingReg.DataBind();
    }

    protected void GrdPendingReg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hf = new HiddenField();
            hf = e.Row.FindControl("hdn_Id") as HiddenField;
            hdnGetId.Value = hf.Value;
        }
    }
}