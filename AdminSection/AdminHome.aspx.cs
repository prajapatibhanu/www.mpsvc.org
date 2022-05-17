using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSection_AdminHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UId"] != null)
        {

        }
        else
        {
            Response.Redirect("../index.html");
        }
    }
}