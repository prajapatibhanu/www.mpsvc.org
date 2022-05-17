using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class Login : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    APIProcedure objdb = new APIProcedure();
    APIProcedure api = new APIProcedure();

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Login));
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        ds = objdb.ByProcedure("ProcLoginMaster", new string[] { "LoginId", "Pwd" }, new string[] { txtLoginId.Text, txtPassword.Text }, "BYdataset");
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Role"].ToString() == "admin")
            {
                Session["UId"] = txtLoginId.Text;
                Session["IsVerify"] = ds.Tables[0].Rows[0]["IsVerify"].ToString();
                checkDateforSms();
                if (Session["IsVerify"].ToString() == "1")
                {
                    Response.Redirect("AdminSection/FrmSecondLevelValid.aspx?Mt=New Registration");
                }
                else
                {
                    Response.Redirect("AdminSection/ActionRegistration.aspx?Mt=New Registration");
                }
            }
            else {
                Session["Role"] = ds.Tables[0].Rows[0]["Role"].ToString();
                Response.Redirect("AdminSection/frmGuestHouseRequest.aspx?Mt=Guest");
            }
          

        }
        else
        {
            lblMsg.Text = objdb.ErrorAlert("Invalid Login Id and Password");
        }
    }

    [AjaxPro.AjaxMethod()]
    public string GridFillLoad(string regino, string name, string mail, string mobile, string dob)
    {
        string x = "";
        DateTime currentDate = DateTime.Now;
        string searchdate = "";
        if (dob != "")
        {
            //searchdate = Convert.ToDateTime(dob).ToString("dd/MM/yyyy");
            //searchdate = Convert.ToDateTime(dob).ToString("yyyy/MM/dd");
            searchdate = dob;
        }

        DataSet dd = api.ByDataSet(@"SELECT Validupto FROM dbo.tblNewRegistration  where RegiNo ='" + regino + "' or   FName='" + name + "' or EmailId='" + mail + "'  or MobileNo='" + mobile + "' or DOB='" + searchdate + "' ");
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

    public void checkDateforSms()
    {
        string Jan = "01/01/" + DateTime.Now.Year;
        string Feb = "01/02/" + DateTime.Now.Year;
		//start changes by Bhanu on 17feb2022
		//string feb1  = "2022/02/18 12:30 PM";
		//end changes by Bhanu on 17feb2022
        string march = "01/03/" + DateTime.Now.Year;
		 string march16 = "16/03/" + DateTime.Now.Year;
        string TodayDate = DateTime.Now.ToString("dd/MM/yyyy");
        if (TodayDate == Jan)
        {
            SendSms_BeforeExpiry();
        }
        else if (TodayDate == Feb)
        {
            SendSms_BeforeExpiry();
        }
        else if (TodayDate == march)
        {
            SendSms_BeforeExpiry();
        }
		else if (TodayDate == march16)
        {
            SendSms_BeforeExpiry();
        }
		//start changes by Bhanu on 17feb2022
		// else if (TodayDate == feb1)
        // {
            // SendSms_BeforeExpiry();
        // }
		//end changes by Bhanu on 17feb2022
    }
    public void SendSms_BeforeExpiry()
    {
		string mbNo = "";    
        string msg = "";
        //ds = objdb.ByDataSet("select * from tblNewRegistration where ApplicationRequestId <> 9 and ApplicationRequestId <> 7");
        ds = objdb.ByProcedure("USP_SMSbeforeExpiry", new string[] { "flag" }, new string[] { "1" }, "BYdataset");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DateTime Lvalue = DateTime.Now;
                DateTime rValue = Convert.ToDateTime(ds.Tables[0].Rows[i]["Validupto"].ToString());                
                int count = Math.Abs((Lvalue.Month - rValue.Month) + 12 * (Lvalue.Year - rValue.Year));
				
                if (count == 0 || count == 1 || count == 2)
                {
					//start done changes by bhanu on 19feb 2022
                    // msg = "Your Registration no. '" + ds.Tables[0].Rows[i]["RegiNo"].ToString() + "' expire on date '" + Convert.ToDateTime(ds.Tables[0].Rows[i]["Validupto"]).ToString("dd/MM/yyyy") + "' Please apply for renewal as soon  as possible. ";
                    // if (ds.Tables[0].Rows[0]["PreferedPhoneNo"].ToString() == "1")
                    // {
                        // objdb.sendOTPSms(ds.Tables[0].Rows[i]["MobileNo"].ToString(), msg);
                    // }
                    // else
                    // {
                        // objdb.sendOTPSms(ds.Tables[0].Rows[i]["MobileNo2"].ToString(), msg);
                    // }
					if (ds.Tables[0].Rows[i]["PreferedPhoneNo"].ToString() == "1")
                    {
                        mbNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
                    }
                    else
                    {
                        mbNo = ds.Tables[0].Rows[i]["MobileNo2"].ToString();
                    }

                    string regino = ds.Tables[0].Rows[i]["RegiNo"].ToString();
                    txtregino.Text = regino;
                    string validity = Convert.ToDateTime(ds.Tables[0].Rows[i]["Validupto"]).ToString("dd/MM/yyyy");                    
                    string Messagebody = api.CreateSmSexpiry(0, txtregino.Text, validity); // Message Body Function                    
                    api.sendOTPSms(mbNo, Messagebody); 
					//end done changes by bhanu on 19feb 2022					
                }
            }
        }

    }
}