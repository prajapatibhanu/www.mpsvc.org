using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;


public partial class RegistrationLinkNew : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    APIProcedure objdb = new APIProcedure();
    APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        // AjaxPro.Utility.RegisterTypeForAjax(typeof(RegistrationLinkNew));
        //   btnSubmit.Attributes.Add("onclick", "btnSave_Click");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string x = "";
        string dob = HF_DOB.Value;
        string regino = HF_Reg.Value;
        string name = HF_Name.Value;
        string mail = HF_Email.Value;
        string mobile = HF_Mob.Value;
        //string popScript;


        DateTime currentDate = DateTime.Now;
        string searchdate = "";
        if (dob != "")
        {
            searchdate = Convert.ToDateTime(dob).ToString("yyyy/MM/dd");
            searchdate = searchdate.Replace("/", "-").Replace("/", "-");
        }
        DataSet dd = api.ByDataSet(@"SELECT FName, RegiNo, Validupto ,ApplicationRequestId FROM dbo.tblNewRegistration  where RegiNo ='" + regino + "' or   Fname='" + name + "' or emailid='" + mail + "'  or mobileno='" + mobile + "' or Dob='" + searchdate + "' ");

        if (dd.Tables.Count != 0)
        {
            if (dd.Tables[0].Rows.Count != 0)
            {
                HF_Msg.Value = "";
                for (int i = 0; i <= dd.Tables[0].Rows.Count - 1; i++)
                {
                    DateTime validUpTo = Convert.ToDateTime(dd.Tables[0].Rows[i]["Validupto"]);
                    string fname = dd.Tables[0].Rows[i]["FName"].ToString();
                    string rno = dd.Tables[0].Rows[i]["RegiNo"].ToString();
                    if (dd.Tables[0].Rows[i]["ApplicationRequestId"].ToString() == "9")
                    {
                        // x = "Your Registration is cancelled. Please contact to MPSVC office ";
                        x = "Your Name is '" + fname + "' ,  Registration no is '" + rno + "',  Valid Upto '" + validUpTo.ToString("dd/MM/yyyy") + "', Your Registration is cancelled. Please contact to MPSVC office";


                    }
                    else if (currentDate < validUpTo)
                    {
                        x = "Your Name is '" + fname + "', Registration no is '" + rno + "',  Valid Upto '" + validUpTo.ToString("dd/MM/yyyy") + "'";
                        //x = "Your Registration is Valid till date " + Convert.ToDateTime(dd.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");

                    }
                    else
                    {
                        x = "Your Name is '" + fname + "',  Registration no is '" + rno + "',  Valid Upto '" + validUpTo.ToString("dd/MM/yyyy") + "', Your Registration is expired Please apply for renewal registration";
                        //x = "Your Registration is expired Please apply for renewal registration";

                    }
                    HF_Msg.Value = HF_Msg.Value + x + "\n";
                }
                if (HF_Msg.Value != "")
                {
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "key2", "javascript:alert('" + HF_Msg.Value.ToString() + "');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "GiveAlert();", true);
                }

            }
            else
            {
                x = "Invalid Registration No.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "key1", "javascript:alert('" + x + "')", true);
                HF_Msg.Value = x;
            }
        }
        else
        {
            x = "No record found.";
            //popScript = "<script language='javascript' type='text/javascript'>alert(" + x + ")</script>";
            //Page.RegisterStartupScript("popScript", popScript);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "key1", "javascript:alert('" + x + "')", true);
            HF_Msg.Value = x;
        }
    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    string x = "";
    //    string dob = HF_DOB.Value;
    //    string regino = HF_Reg.Value;
    //    string name = HF_Name.Value;
    //    string mail = HF_Email.Value;
    //    string mobile = HF_Mob.Value;
    //    //string popScript;

    //    DateTime currentDate = DateTime.Now;
    //    string searchdate = "";
    //    if (dob != "")
    //    {
    //        searchdate = dob;
    //    }
    //    DataSet dd = api.ByDataSet(@"SELECT Validupto ,ApplicationRequestId FROM dbo.tblNewRegistration  where RegiNo ='" + regino + "' or   Fname='" + name + "' or emailid='" + mail + "'  or mobileno='" + mobile + "' or Dob='" + searchdate + "' ");

    //    if (dd.Tables.Count != 0)
    //    {
    //        DateTime validUpTo = Convert.ToDateTime(dd.Tables[0].Rows[0]["Validupto"]);
    //        if (dd.Tables[0].Rows[0]["ApplicationRequestId"].ToString() == "9")
    //        {
    //            x = "Your Registration is cancelled. Please contact to MPSVC office ";

    //        }
    //        if (currentDate < validUpTo)
    //        {
    //            x = "Your Registration is Valid till date " + Convert.ToDateTime(dd.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");

    //        }
    //        else
    //        {
    //            x = "Your Registration is expired Please apply for renewal registration";

    //        }
    //        HF_Msg.Value = x;
    //        //popScript = "<script language='javascript' type='text/javascript'>alert(" + x + ")</script>";
    //        // Page.RegisterStartupScript("popScript", popScript);
    //        Page.ClientScript.RegisterStartupScript(this.GetType(), "key1", "javascript:alert('" + x + "')", true);
    //    }
    //    else
    //    {
    //        x = "Invalid Registration No.";
    //        //popScript = "<script language='javascript' type='text/javascript'>alert(" + x + ")</script>";
    //        //Page.RegisterStartupScript("popScript", popScript);
    //        Page.ClientScript.RegisterStartupScript(this.GetType(), "key1", "javascript:alert('" + x + "')", true);
    //        HF_Msg.Value = x;
    //    }
    //}
    //[AjaxPro.AjaxMethod()]
    //public string GridFillLoad(string regino, string name, string mail, string mobile, string dob)
    //{
    //    string x = "";
    //    DateTime currentDate = DateTime.Now;
    //    string searchdate = "";
    //    if (dob != "")
    //    {
    //        searchdate = dob;
    //    }
    //    DataSet dd = api.ByDataSet(@"SELECT Validupto ,ApplicationRequestId FROM dbo.tblNewRegistration  where RegiNo ='" + regino + "' or   Fname='" + name + "' or emailid='" + mail + "'  or mobileno='" + mobile + "' or Dob='" + searchdate + "' ");
    //    if (dd.Tables[0].Rows.Count != 0)
    //    {
    //        DateTime validUpTo = Convert.ToDateTime(dd.Tables[0].Rows[0]["Validupto"]);
    //        if (dd.Tables[0].Rows[0]["ApplicationRequestId"].ToString() =="9")
    //        {
    //            x = "Your Registration is cancelled. Please contact to MPSVC office ";
    //            return x;
    //        }
    //        if (currentDate < validUpTo)
    //        {
    //            x = "Your Registration is Valid till date " + Convert.ToDateTime(dd.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");
    //            return x;
    //        }
    //        else
    //        {
    //            x = "Your Registration is expired Please apply for renewal registration";
    //            return x;
    //        }
    //    }
    //    else
    //    {
    //        x = "Invalid Registration No.";
    //        return x;
    //    }
    //}
}