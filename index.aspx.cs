using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;

public partial class index : System.Web.UI.Page
{
    APIProcedure api = new APIProcedure();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
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
        //DataSet dd = api.ByDataSet(@"SELECT FName, RegiNo, Validupto ,ApplicationRequestId FROM dbo.tblNewRegistration  where RegiNo ='" + regino + "' or   Fname='" + name + "' or emailid='" + mail + "'  or mobileno='" + mobile + "' or Dob='" + searchdate + "' ");
        DataSet dd = api.ByDataSet(@"SELECT FName,MName,LName, RegiNo, Validupto ,ApplicationRequestId FROM dbo.tblNewRegistration  where FName    	=   CASE WHEN ISNULL('" + name + "','') != '' then  '" + name + "' else FName  end AND   ISNULL(EmailId,'')  	=   CASE WHEN ISNULL('" + mail + "','') != '' then  '" + mail + "' else ISNULL(EmailId,'')  end AND   ISNULL(MobileNo,'') 	=   CASE WHEN ISNULL('" + mobile + "','') != '' then  '" + mobile + "' else ISNULL(MobileNo,'')  end AND   RegiNo	like   CASE WHEN ISNULL('" + regino + "','') != '' then  '%" + regino + "%' else RegiNo  end ");

        if (dd.Tables.Count != 0)
        {
            if (dd.Tables[0].Rows.Count != 0)
            {
                HF_Msg.Value = "";
                for (int i = 0; i <= dd.Tables[0].Rows.Count - 1; i++)
                {
                    DateTime validUpTo = Convert.ToDateTime(dd.Tables[0].Rows[i]["Validupto"]);
                    string fname = dd.Tables[0].Rows[i]["FName"].ToString() + " " + Convert.ToString(dd.Tables[0].Rows[i]["MName"].ToString()) + " " + Convert.ToString(dd.Tables[0].Rows[i]["LName"].ToString());
                    string rno = dd.Tables[0].Rows[i]["RegiNo"].ToString();
                    if (dd.Tables[0].Rows[i]["ApplicationRequestId"].ToString() == "9")
                    {
                        // x = "Your Registration is cancelled. Please contact to MPSVC office ";
                        x = "Your Name is '" + fname + "' ,  Registration no is '" + rno + "',  Valid Upto '" + validUpTo.ToString("dd/MM/yyyy") + "', Your Registration is cancelled. Please contact to MPSVC office\n";

                    }
                    else if (currentDate < validUpTo)
                    {
                        if (dd.Tables[0].Rows[i]["ApplicationRequestId"].ToString() != "7")
                        {
                            x = "Dr. '" + fname + "', Registration no is '" + rno + "',  Valid Upto '" + validUpTo.ToString("dd/MM/yyyy") + "'\n";
                        }

                        //x = "Your Registration is Valid till date " + Convert.ToDateTime(dd.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");

                    }
                    else
                    {
                        if (dd.Tables[0].Rows[i]["ApplicationRequestId"].ToString() != "7")
                        {
                            x = "Dr.'" + fname + "',  Registration no is '" + rno + "',  Valid Upto '" + validUpTo.ToString("dd/MM/yyyy") + "', Your Registration is expired Please apply for renewal registration\n";
                        }
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
}