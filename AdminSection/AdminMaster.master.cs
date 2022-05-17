using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSection_AdminMaster : System.Web.UI.MasterPage
{
    public string UlAddress = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ////if (Request.QueryString["Mt"] != null)
        ////{
        ////    UlAddress = Request.QueryString["Mt"].ToString();
        ////}
        ////else
        ////{
        ////    UlAddress = "Admin Home";
        ////}
        if (Session["IsVerify"] != null)
        {
            if (Session["IsVerify"].ToString() == "0")
            {
                Adminverfiy.Visible = false;
            }
            else
            {
                Adminverfiy.Visible = true;
            }
        }
        else
        {
            Response.Redirect("../index.html");
        }
        if (Session["UId"] != null)
        {

        }
        else
        {
            Response.Redirect("../index.html");
        }

    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("../index.aspx");
    }
}
