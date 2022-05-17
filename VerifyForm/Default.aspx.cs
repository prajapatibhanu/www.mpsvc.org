using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using System.Web.Configuration;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;

public partial class VerifyForm_Default : System.Web.UI.Page
{
    APIProcedure obj = new APIProcedure();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet dsprint = obj.ByProcedure("UpdateVerication", new string[] { "flag" }
                            , new string[] { "1" }, "dataset");

            if (dsprint.Tables[0].Rows.Count > 0)
            {

                //lblID.Text = dsprint.Tables[0].Rows[0]["RegiNo"].ToString();
                lblapllicant.Text = dsprint.Tables[0].Rows[0]["Name"].ToString();
                lblApplicantFH.Text = dsprint.Tables[0].Rows[0]["FatherName"].ToString();
                lblDOB.Text = Convert.ToDateTime(dsprint.Tables[0].Rows[0]["DOB"]).ToString("dd/MM/yyyy");
                lblGender.Text = dsprint.Tables[0].Rows[0]["Gender"].ToString();
                lblresidntialAddress.Text = dsprint.Tables[0].Rows[0]["PreferedAdd"].ToString();
                lblNO.Text = dsprint.Tables[0].Rows[0]["MobileNo"].ToString();
                lblemail.Text = dsprint.Tables[0].Rows[0]["EmailId"].ToString();
                lblPR.Text = dsprint.Tables[0].Rows[0]["State_Veterinary_Council_namepresent"].ToString();
                lblRn.Text = dsprint.Tables[0].Rows[0]["RegiNo"].ToString();
                lblAppli.Text = dsprint.Tables[0].Rows[0]["StateName"].ToString();
                lblddno.Text = dsprint.Tables[0].Rows[0]["ChequeNo"].ToString();
                lblDddrname.Text = dsprint.Tables[0].Rows[0]["Drawn_name_DD"].ToString();
                lblDate.Text = dsprint.Tables[0].Rows[0]["alDate"].ToString();
                lblIssuebank.Text = dsprint.Tables[0].Rows[0]["BankName"].ToString();
                lblIssueBranch.Text = dsprint.Tables[0].Rows[0]["Bank_Branch_Name"].ToString();
                Lblrison.Text = dsprint.Tables[0].Rows[0]["Remark"].ToString();
                lblVetenaryCouncil.Text = dsprint.Tables[0].Rows[0]["Registrar_Name"].ToString();
                lblRAddress.Text = dsprint.Tables[0].Rows[0]["Registrar_Adresse"].ToString();
                lblddno.Text = dsprint.Tables[0].Rows[0]["ChequeNo"].ToString();
                lblAmount.Text = dsprint.Tables[0].Rows[0]["TotalAmount"].ToString();
                lblCollegeName.Text = dsprint.Tables[0].Rows[0]["CollegeName"].ToString();
                lblUniversity.Text = dsprint.Tables[0].Rows[0]["UniversityName"].ToString();                      
                DateTime Lvalue = DateTime.Now;
                DateTime rValue = Convert.ToDateTime(dsprint.Tables[0].Rows[0]["Validupto"].ToString());
                if (Lvalue > rValue)
                {

                    lblVr.Text = "";
                }
                else
                {
                    lblVr.Text = Convert.ToDateTime(dsprint.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");
                }
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "window.print('Divprint')", true);
               GenratePDF(sender,  e);

            
        }

        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }

    protected void GenratePDF(object sender, System.EventArgs e)
    {
       // using (System.IO .MemoryStream ms = new System.IO.MemoryStream())
        //{

        Response.ContentType = "application/pdf";
        Response.AddHeader("Divprint", "attachment; filename=" + lblAppli.Text + ".pdf");
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        StringWriter str = new StringWriter();
        HtmlTextWriter html = new HtmlTextWriter(str);
        Divprint.RenderControl(html);
        StringReader strRdr = new StringReader(str.ToString());
        Document Doc = new Document(PageSize.A4, 25f, 25f, 25f, 100f);
        PdfWriter.GetInstance(Doc, Response.OutputStream);
        HTMLWorker htmlwrkr = new HTMLWorker(Doc);
        Doc.Open();


        htmlwrkr.Parse(strRdr);
        Doc.NewPage();
        Doc.Close();
        Response.Write(Doc);
        Response.End();
       // }
       
    }
    public override void VerifyRenderingInServerForm(Control control) { }
    
    }