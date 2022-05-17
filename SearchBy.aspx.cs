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
using System.Data;

public partial class AdminSection_SearchBy : System.Web.UI.Page
{
    APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
    DataSet dd= api.ByDataSet(@"SELECT RegiNo ,convert(varchar, RegiDate,103)RegiDate,EmailId,MobileNo, 'Valid'as aa
      ,FName+''+isnull(MName,'')+''+LName as name ,FatherName,convert(varchar,DOB,103) DOB ,Gender ,ResAdd ,ResCity ,ResDistrict FROM dbo.tblNewRegistration where (FName='"+txtname.Text.Trim ()+"' or EmailId ='"+TextBox1.Text+"' or MobileNo='"+txMobile.Text+"')");

    GridView1.DataSource = dd;
    GridView1.DataBind();
    }
}
