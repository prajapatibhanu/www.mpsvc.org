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
//        DataSet dd = api.ByDataSet(@"SELECT RegiNo , 
//                                            convert(varchar, RegiDate,103)RegiDate,
//                                            EmailId,
//                                            MobileNo, case when id in (11,12,13) then 'invalid' else  'Valid' end  aa ,
//                                            FName+''+isnull(MName,'')+''+LName as name ,
//                                            FatherName,convert(varchar,DOB,103) DOB ,
//                                            Gender ,
//                                            ResAdd ,
//                                            ResCity ,
//                                            ResDistrict 
//                                FROM dbo.tblNewRegistration
//                            where (FName like'%" + txtname.Text.Trim() + "%' or EmailId ='" + TextBox1.Text + "' or MobileNo='" + txMobile.Text + "')");
        string fname  = txtname.Text;
        string email = TextBox1.Text;
        string MobileNo = txMobile.Text;
        DateTime mydate1 = DateTime.Now;
        string mydate = (mydate1).ToString("yyyy/MM/dd");
        string Query = "SELECT RegiNo ,"
                        + "convert(varchar, RegiDate,103)RegiDate,"
                        + "EmailId,"
                        + "MobileNo, case when Validupto < '" + mydate + "' then 'Invalid' else  'Valid' end  aa ,"
                        + "FName+' '+isnull(MName,'')+' '+LName as name ,"
                        + "FatherName,convert(varchar,DOB,103) DOB ,"
                        + "Gender ,"
                        + "ResAdd ,"
                        + "ResCity ,"
                        + "ResDistrict "
                        + "FROM dbo.tblNewRegistration"
                        + " Where isnull(RegiNo,'') <> '' and ApplicationRequestId not in (2,8,9)";
        if (fname != "")
        {
            Query = Query + " and FName like   '%" + fname + "%'";
        }
        if (email != "")
        {
            Query = Query + " and EmailId like   '%" + email + "%'";
        }
        if (MobileNo != "")
        {
            Query = Query + " and MobileNo like   '%" + MobileNo + "%'";
        }



        DataSet dd = api.ByDataSet(Query);


//        DataSet dd = api.ByDataSet(@"SELECT RegiNo , 
//                                            convert(varchar, RegiDate,103)RegiDate,
//                                            EmailId,"
//                                            +"MobileNo, case when Validupto < '"+mydate+"' then 'Invalid' else  'Valid' end  aa ,"
//                                            +"FName+''+isnull(MName,'')+''+LName as name ,"
//                                            +"FatherName,convert(varchar,DOB,103) DOB ,"
//                                            +"Gender ,"
//                                            +"ResAdd ,"
//                                            +"ResCity ,"
//                                            +"ResDistrict "
//                                + "FROM dbo.tblNewRegistration"
//                                +" where   FName    like   CASE WHEN isnull('%" + fname + "%','') != '' then  '%" + fname + "%' else FName  end "
//                                + "AND     EmailId  like   CASE WHEN isnull('%" + email + "%','') != '' then  '%" + email + "%' else EmailId  end "
//                                + "AND     MobileNo like   CASE WHEN isnull('%" + MobileNo + "%','') != '' then  '%" + MobileNo + "%' else MobileNo  end "
//                                +" AND ApplicationRequestId not in (2,8,9)"
//                                + "AND isnull(RegiNo,'') <> ''");

    GridView1.DataSource = dd;
    GridView1.DataBind();
    }
}
