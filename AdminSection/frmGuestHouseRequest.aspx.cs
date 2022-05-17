using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSection_frmGuestHouseRequest : System.Web.UI.Page
{
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGrid();
        }
    }
    public void FillGrid()
    {
        grdRoomBookRequest.DataSource = objdb.ByProcedure("Proc_GetGusetHouseRequest", new string[] {"KeyBoard","Type" }, new string[] {"","1"}, "dataset").Tables [0];
        grdRoomBookRequest.DataBind();
    }
    protected void grdRoomBookRequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)grdRoomBookRequest.Rows[grdRoomBookRequest.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("Frm_EditGuestHouse.aspx?editGH=" + Server.UrlEncode(var));
    }
    protected void grdRoomBookRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdRoomBookRequest.PageIndex = e.NewPageIndex;
        FillGrid();
    }
}