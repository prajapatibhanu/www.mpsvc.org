using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class AdminSection_MasterPage : System.Web.UI.MasterPage
{
    APIProcedure api = new APIProcedure();

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(AdminSection_MasterPage));
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("../index.html");
    }

    [AjaxPro.AjaxMethod()]
    public string GridFillLoad(string regino, string name, string mail, string mobile, string dob)
    {
        string x = "";
        DateTime currentDate = DateTime.Now;
        string searchdate = "";
        if (dob != "")
        {
            searchdate = dob;
        }

        DataSet dd = api.ByDataSet(@"SELECT Validupto FROM dbo.tblNewRegistration  where RegiNo ='" + regino + "' or   Fname='" + name + "' or emailid='" + mail + "'  or mobileno='" + mobile + "' or Dob='" + searchdate + "' ");
        if (dd.Tables[0].Rows.Count != 0)
        {   
            DateTime validUpTo = Convert.ToDateTime(dd.Tables[0].Rows[0]["Validupto"]);

            if (currentDate < validUpTo)
            {
                x = "Your Registration is Valid till date" + Convert.ToDateTime(dd.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");
            }
            else
            {
                x = "Your Registration is expired";
            }
        }
        else
        {
            x = "No Record Found";
        }
        return x;
    }
}
