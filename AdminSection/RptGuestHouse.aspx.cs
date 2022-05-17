using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;

public partial class AdminSection_RptGuestHouse : System.Web.UI.Page
{
    APIProcedure objdb = new APIProcedure();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    int total = 0;

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
    public void FillGrid()
    {
        string Fromdate = Convert.ToDateTime(txtFDate.Text, cult).ToString("yyyy/MM/dd");
        string Todate = Convert.ToDateTime(txtToDate.Text, cult).ToString("yyyy/MM/dd");
        grdRoomBookRequest.DataSource = objdb.ByProcedure("Proc_GetGusetHouseReport", new string[] { "Fromdate", "Todate" }, new string[] { Fromdate, Todate }, "dataset").Tables[0];
        grdRoomBookRequest.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            FillGrid();
        }
        catch (Exception ex)
        { 
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //String popScript;
        //Session["PrintSTR"] = HF_GridData.Value;
        //popScript = "<script language='javascript' type='text/javascript'>window.open('PrintHTMLReport.aspx','_blank','addressbar=yes,resizable=yes,toolbar=no,status=no,menubar=no,location=center,scrollbars=yes,width=950,height=520')</script>";
        //Page.RegisterStartupScript("popScript", popScript);

    }
    protected void grdRoomBookRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPrice = (Label)e.Row.FindControl("lblPrice");
            int price = int.Parse(lblPrice.Text);
            total += price; 
            //total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalPrice = (Label)e.Row.FindControl("lblTotal");
            lblTotalPrice.Text = total.ToString(); 

            //Label lblamount = (Label)e.Row.FindControl("lblTotal");
            //lblamount.Text = total.ToString();
        }
    }
}