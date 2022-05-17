using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class UserApplicationStatus : System.Web.UI.Page
{
    APIProcedure api = new APIProcedure();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtname.Text.Trim() != "")
            {
                DateTime currentDate = DateTime.Now;

                DataSet dd = api.ByDataSet(@"SELECT RegiNo ,convert(varchar, RegiDate,103)RegiDate,EmailId,MobileNo
      ,FName+''+isnull(MName,'')+''+LName as name ,FatherName,convert(varchar,DOB,103) DOB ,Gender ,ResAdd ,ResCity ,ResDistrict, Validupto FROM dbo.tblNewRegistration where (RegiNo like'%" + txtname.Text.Trim() + "%')");

                if (dd.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dd;
                    GridView1.DataBind();

                    DateTime validUpTo = Convert.ToDateTime(dd.Tables[0].Rows[0]["Validupto"]);

                    if (currentDate < validUpTo)
                    {
                        LinkButton lnk1 = new LinkButton();
                        lnk1 = (LinkButton)GridView1.Rows[0].FindControl("ForTransafer");
                        lnk1.Visible = true;

                        Label lbl = new Label();
                        lbl = (Label)GridView1.Rows[0].FindControl("lblStatus");
                        lbl.Text = "Valid";
                    }
                    else
                    {
                        LinkButton lnk = new LinkButton();
                        lnk = (LinkButton)GridView1.Rows[0].FindControl("ForRenewal");
                        lnk.Visible = true;

                        Label lbl = new Label();
                        lbl = (Label)GridView1.Rows[0].FindControl("lblStatus");
                        lbl.Text = "Invalid";
                    }
                }
            }
            else
            {
                lblMsg.Text = "";
            }
        }
        catch { }

    }
}
