using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.IO;
using System.Drawing;
/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    SqlConnection con = new SqlConnection(@"Data Source=SFATECHN30903;Initial Catalog=MPSVC;User ID=sa;Password=CPHTNYfsa4c$");
    string securityKey = "SFA_MPSVC";
    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetStatus(string Key, string RegiNo)
    {
        this.Context.Response.ContentType = "application/json; charset=utf-8";
        if (Key == securityKey)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select RegiNo,FName +' '+ MName + ' '+ LName as FullName,EmailId,MobileNo,CONVERT(VARCHAR(19),Validupto,106) as Validupto  from dbo.tblNewRegistration where RegiNo = '" + RegiNo + "'";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.Connection = con;

            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 0)
            {
                this.Context.Response.Write(serializer.Serialize(new { List = "", status = "0", Error = "Enter Valid Registraion No" }));
            }
            else
            {


                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row = null;
                foreach (DataRow rs in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, rs[col]);
                    }
                    rows.Add(row);
                }

                this.Context.Response.Write(serializer.Serialize(new { List = rows, status = "1", Error = "" }));
            }

        }
        else
        {
            this.Context.Response.Write(serializer.Serialize(new { List = "", status = "0", Error = "Enter valid Key" }));
        }
    }
}
