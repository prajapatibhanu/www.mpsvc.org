using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmailTest : System.Web.UI.Page
{
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        objdb.SendMailMPSVC(TextBox1.Text.ToString(), "Email Subject", "Email test body", "", "7723003660", "MPSVC test msg");
    }
}