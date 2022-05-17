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

public partial class AdminSection_CancelRegistrationReport : System.Web.UI.Page
{
    APIProcedure objdb = new APIProcedure();
    CommonFuction objcf = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UId"] != null)
        {
            if (!Page.IsPostBack)
            {
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
            GrdInvalidReg.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "9", "9" }, "dataset");
            GrdInvalidReg.DataBind();

        }
        catch { }

    }
    protected void GrdPaperMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdInvalidReg.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //String popScript;
        //Session["PrintSTR"] = HF_GridData.Value;
        //popScript = "<script language='javascript' type='text/javascript'>window.open('PrintHTMLReport.aspx','_blank','addressbar=yes,resizable=yes,toolbar=no,status=no,menubar=no,location=center,scrollbars=yes,width=950,height=520')</script>";
        //Page.RegisterStartupScript("popScript", popScript);

    }
}