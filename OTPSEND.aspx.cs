using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OTPSEND : System.Web.UI.Page
{

    APIProcedure obj = new APIProcedure();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOtp_Click(object sender, EventArgs e)
    {
        try
        {
            string SendOtp;
            if(txtOtp.Text.Trim() != null)
            {
                SendOtp = obj.Send_OTP(txtOtp.Text);
            
           
                lblMSg.Text = "OTP Send Succesfully On Your mobile number";
            }
        }
        catch(Exception ex)
        {
            lblMSg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
}