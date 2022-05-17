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
    protected void Page_Load(object sender, EventArgs e)
    {
            DataTable dtDatasource  = new DataTable() ;
            DataTable dt = new DataTable ();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = ("Renew_Cirtificate.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            Response.AddHeader("RDLC REport", "0");
            ReportViewer1.LocalReport.EnableExternalImages = true ;
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Datasource", dtDatasource));
            ReportViewer1.DataBind();
    }
}
