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

public partial class AdminSection_PrintHTMLReport : System.Web.UI.Page
{
    public String PrintSTR = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["PrintSTR"] != "")
        {
            PrintSTR = Session["PrintSTR"].ToString();
        }
    }
}
