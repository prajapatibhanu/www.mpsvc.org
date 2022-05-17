using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSection_ViewNewRegistration : System.Web.UI.Page
{
    APIProcedure objdb = new APIProcedure();
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

            GrdPaperMaster.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { txtSearch.Text ,"0"}, "dataset");
            GrdPaperMaster.DataBind();
        }
        catch { }

    }
   
    protected void GrdPaperMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPaperMaster.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GridFillLoad();
        }
        catch { }
    }
    
}