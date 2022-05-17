using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSection_GuestHouseMaster : System.Web.UI.MasterPage
{
    public string UlAddress = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Role"] != null)
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
        Response.Redirect("../index.html");
    }
}
