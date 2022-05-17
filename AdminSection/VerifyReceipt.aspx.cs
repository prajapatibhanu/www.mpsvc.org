using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSection_VerifyReceipt : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DataSet ds;
    APIProcedure objdb = new APIProcedure(); string path2, path3, path4;
    string mbNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["editR"] != null)
        {
            string[] arr = Request.QueryString["editR"].ToString().Split("*".ToCharArray());
            string applicationNo = arr[1];
            string Tid = arr[0];
            ds = objdb.ByProcedure("GetUSerDetails", new string[] { "ApplicationNo", "Id" }, new string[] { applicationNo, Tid }, "dataset");
            if (ds.Tables[0].Rows.Count != 0)
            {
                DetailsView1.DataSource = ds.Tables[0];
                DetailsView1.DataBind();
                DetailsView2.DataSource = ds.Tables[0];
                DetailsView2.DataBind();
                DetailsView3.DataSource = ds.Tables[0];
                DetailsView3.DataBind();
                DetailsView4.DataSource = ds.Tables[1];
                DetailsView4.DataBind();
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                GridView2.DataSource = ds.Tables[0];
                GridView2.DataBind();
                GridView3.DataSource = ds.Tables[0];
                GridView3.DataBind();
                GridView4.DataSource = ds.Tables[0];
                GridView4.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "print", "window.print();", true);
            }


        }

    }
}