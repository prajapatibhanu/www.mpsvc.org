using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetIntegrationKit;
using System.Net;

public partial class frmRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequestURL objRequestURL = new RequestURL();
         DataSecurity Isecrity = new DataSecurity();

        var DecryptedValue = Request.QueryString["TRequest"].ToString();
        var RquestParameter = Isecrity.Decrypt(DecryptedValue);
        string[] ItemValue = RquestParameter.Split("*".ToCharArray());
        string MerchantRefNo = GenerateUniqueCustid();
        string Amount = ItemValue[1]; 
        string UniqueCustId = ItemValue[0];
        string ShopingCardDetail = "Council_" + ItemValue[1] + ".0_0.0"; 
        string TransactionDate = DateTime.Now.ToString("dd-MM-yyyy");
        string EmailId = ItemValue[2];
        string MobileNo = ItemValue[3];
        string CustomerName = ItemValue[4];
        string ApplicationType = ItemValue[0] + "*" + ItemValue[5] + "*" + ItemValue[6];

		 ServicePointManager.Expect100Continue = true;
         ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
       // String response = objRequestURL.SendRequest("T", "T6112", "06032014032677", "NA", "1", "INR", "1001", "http://www.mpsvc.org/frmResponse.aspx", "NA", "NA", "MPPCP_120.0_0.0", "18-11-2015", "akhandpratap2006@gmail.com", "7415336311", "470", "Abhay", Server.MapPath("Merchant.property"));      
        String response = objRequestURL.SendRequest("T", "L47613", MerchantRefNo, "NA", Amount, "INR", UniqueCustId, "http://www.mpsvc.org/frmResponse.aspx?Type=" + ApplicationType, "NA", "NA", ShopingCardDetail , TransactionDate, EmailId, MobileNo, "470", CustomerName, Server.MapPath("Merchant.property"));
        String strResponse = response.ToUpper();

        if (strResponse.StartsWith("ERROR"))
        {
            lblError.Text = response;
        }
        else
        {
            Response.Write("<form name='s1_2' id='s1_2' action='" + response + "' method='post'> ");
            Response.Write("<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();");
            Response.Write("</script>");
            Response.Write("<script language='javascript' >");
            Response.Write("</script>");
            Response.Write("</form> ");

        }
    }
    public string GenerateUniqueCustid()
    {
        string str = string.Empty;
        long x = 0;
        Random random = new Random();
        for (int i = 0; i < 14; i++)
        {
            x += (long)(Math.Pow(10, i) * random.Next(1, 10));
        }
        str = x.ToString();
        return str;
    }
}