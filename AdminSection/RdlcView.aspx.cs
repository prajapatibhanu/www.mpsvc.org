using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Collections.Generic;
using Microsoft.ReportingServices.Library;
using Microsoft.ReportingServices.ReportProcessing;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class RdlcView : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtDatasource = new DataTable();
       
        DataTable dt = new DataTable();
        APIProcedure objdb = new APIProcedure();

        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        DataSet ds = objdb.ByDataSet("select * from tblNewRegistration where id='" + Request.QueryString["ID"].ToString() + "'");

        dtDatasource = CreateTableForReprot(ds);

        if (ds.Tables[0].Rows[0]["ApplicationRequestId"].ToString() == "0")
        {
            ReportViewer1.LocalReport.ReportPath = ("AdminSection/Certificate.rdlc");
        }
        else
        {
            ReportViewer1.LocalReport.ReportPath = ("AdminSection/Renew_Cirtificate.rdlc");
        }
        ReportViewer1.LocalReport.DataSources.Clear();
        Response.AddHeader("RDLC REport", "0");
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ReportDataSet_Registration", dtDatasource));
        ReportViewer1.DataBind();
    }

    public DataTable CreateTableForReprot(DataSet dsdetails)
    {
        DataTable dt = new DataTable("Registration");
        DataColumn Column1 = new DataColumn("Logo");
        Column1.DataType = System.Type.GetType("System.Byte[]");
        Column1.AllowDBNull = true;
        Column1.Caption = "My logo";
        dt.Columns.Add(Column1);

        DataColumn Column2 = new DataColumn("UserPic");
        Column2.DataType = System.Type.GetType("System.Byte[]");
        Column2.AllowDBNull = true;
        Column2.Caption = "My Pic";
        dt.Columns.Add(Column2);

        DataColumn Column3 = new DataColumn("RegNo");
        dt.Columns.Add(Column3);
        DataColumn Column4 = new DataColumn("RegDate");
        dt.Columns.Add(Column4);
        DataColumn Column5 = new DataColumn("UserName");
        dt.Columns.Add(Column5);
        DataColumn Column6 = new DataColumn("Validupto");
        dt.Columns.Add(Column6);

        Server.MapPath("");

        DataRow row = dt.NewRow();
        string Logopath = Server.MapPath("~/images/Vet-Council-Logo.bmp");
        row["Logo"] = ImageTobyte(Logopath);
        if (dsdetails.Tables[0].Rows[0]["File3"].ToString() != "")
        {
            string Picpath = Server.MapPath("~/Upload_Certificate/" + dsdetails.Tables[0].Rows[0]["File3"].ToString());
            row["UserPic"] = ImageTobyte(Picpath);
        }
        
        row["RegNo"] = dsdetails.Tables[0].Rows[0]["RegiNo"].ToString();
        row["RegDate"] = Convert.ToDateTime(dsdetails.Tables[0].Rows[0]["RegiDate"].ToString(), cult).ToString("dd/MM/yyyy");    
        row["UserName"] = dsdetails.Tables[0].Rows[0]["FName"].ToString() + " " + dsdetails.Tables[0].Rows[0]["MName"].ToString() + " " + dsdetails.Tables[0].Rows[0]["LName"].ToString();
        row["Validupto"] = Convert.ToDateTime(dsdetails.Tables[0].Rows[0]["Validupto"].ToString(), cult).ToString("dd/MM/yyyy");    
        dt.Rows.Add(row);
        return dt;
    }
    public static byte[] ImageTobyte(string filePath)
    {
        byte[] Imagearray = File.ReadAllBytes(filePath);
        return Imagearray;
    }
}
