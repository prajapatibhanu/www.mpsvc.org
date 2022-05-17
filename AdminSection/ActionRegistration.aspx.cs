using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class AdminSection_ActionRegistration : System.Web.UI.Page
{
    APIProcedure objdb = new APIProcedure();
    CommonFuction objcf = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds = new DataSet();
    string mbNo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UId"] != null)
        {
            if (!Page.IsPostBack)
            {
                GrdPendingReg.Visible = true;
                GrdValidReg.Visible = false;
                //GrdTransfer.Visible = false;
                GridFillLoad();

                //if (Session["lblMsg"] != null)
                //{
                //    lblmsg.Text = Session["lblMsg"].ToString();

                //}
              
            }
        }
        else
        {
            Response.Redirect("../index.html");
        }


    }
    public void GridFillLoad()
    {
        try
        {
            if(rbComplaint.Checked == true)
            {
                GrdComplaint.DataSource = objdb.ByProcedure("SpComplainantRegistration", new string[] { "flag" }, new string[] { "6" }, "dataset");
                GrdComplaint.DataBind();
            }
            if (rbPending.Checked == true)
            {
                GrdPendingReg.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "0", "2" }, "dataset");
                GrdPendingReg.DataBind();
            }
            if (rbRenew.Checked == true)
            {
                GrdRenew.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "1", "2" }, "dataset");
                GrdRenew.DataBind();
            }
            if (rbTransfer.Checked == true)
            {
                GrdTransfer.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "2", "2" }, "dataset");
                GrdTransfer.DataBind();
            }
            // if (rbTransfer.Checked == true)
            // {

                // GrdTransfer.DataSource = objdb.ByProcedure("USP_TransferRegistrationOutMP_Update", new string[] { "flag", "ApplicationRequestId" }, new string[] { "3", "2" }, "dataset");
                // GrdTransfer.DataBind();
            // }
            if (rbOutsideTransfer.Checked == true)
            {
                GrdTransferOutside.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "3", "2" }, "dataset");
                GrdTransferOutside.DataBind();
            }
            if (rbDuplicate.Checked == true)
            {
                GrdDupicateReg.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "5", "2" }, "dataset");
                GrdDupicateReg.DataBind();
            }
            if (rbProvisional.Checked == true)
            {
                GrdProvisional.DataSource = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "7", "2" }, "dataset");
                GrdProvisional.DataBind();
            }
            if (rbValid.Checked == true)
            {
                DateTime mydate1 = DateTime.Now;
               DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { (mydate1).ToString("yyyy/MM/dd"), "5" }, "dataset").Tables[0];
                GrdValidReg.DataSource = dt;
                GrdValidReg.DataBind();
               // ViewState["data"] = dt;
            }

            //if (rbValid.Checked == true) //new valid Query
            //{
            //    DateTime mydate1 = DateTime.Now;
            //    DataTable dt = objdb.ByProcedure("USP_TransferRegistrationOutMP_Update", new string[] { "KeyBoard", "flag" //}, new string[] { (mydate1).ToString("yyyy/MM/dd"), "5" }, "dataset").Tables[0];
            //    GrdValidReg.DataSource = dt;
            //    GrdValidReg.DataBind();
            //}

        }
        catch { }
    }

    protected void GrdProvisional_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdProvisional.Rows[GrdProvisional.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("EditProvisionalRegistration.aspx?editProvisional=" + Server.UrlEncode(var));
    }

    protected void GrdPaperMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDupicateReg.PageIndex = e.NewPageIndex;
        GrdTransferOutside.PageIndex = e.NewPageIndex;
        GrdValidReg.PageIndex = e.NewPageIndex;
        GrdPendingReg.PageIndex = e.NewPageIndex;
        GrdTransfer.PageIndex = e.NewPageIndex;
        GrdRenew.PageIndex = e.NewPageIndex;
        GrdProvisional.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }

    protected void GrdTransfer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDupicateReg.PageIndex = e.NewPageIndex;
        GrdTransferOutside.PageIndex = e.NewPageIndex;
        GrdValidReg.PageIndex = e.NewPageIndex;
        GrdPendingReg.PageIndex = e.NewPageIndex;
        GrdTransfer.PageIndex = e.NewPageIndex;
        GrdRenew.PageIndex = e.NewPageIndex;
        GrdProvisional.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSearch.Text.Trim() != "")
            {
                Filtergrid();
            }
        }
        catch { }
    }
    public void Filtergrid()
    {
        try
        {


            if (rbOutsideTransfer.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "3", "2" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '%" + txtSearch.Text.Trim() + "%' or FName like '%" + txtSearch.Text.Trim() + "%' or MobileNo like '%" + txtSearch.Text.Trim() + "%'  or EmailId like'%" + txtSearch.Text.Trim() + "%'";
                dt.DefaultView.ToTable();
                GrdTransferOutside.DataSource = dt;
                GrdTransferOutside.DataBind();
            }
            if (rbRenew.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "1", "2" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '%" + txtSearch.Text.Trim() + "%' or FName like '%" + txtSearch.Text.Trim() + "%' or MobileNo like '%" + txtSearch.Text.Trim() + "%'  or EmailId like'%" + txtSearch.Text.Trim() + "%'";
                dt.DefaultView.ToTable();
                GrdRenew.DataSource = dt;
                GrdRenew.DataBind();
            }
            if (rbTransfer.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "2", "2" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '%" + txtSearch.Text.Trim() + "%' or FName like '%" + txtSearch.Text.Trim() + "%' or MobileNo like '%" + txtSearch.Text.Trim() + "%'  or EmailId like'%" + txtSearch.Text.Trim() + "%'";
                dt.DefaultView.ToTable();
                GrdTransfer.DataSource = dt;
                GrdTransfer.DataBind();
            }
            if (rbPending.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "0", "2" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '%" + txtSearch.Text.Trim() + "%' or FName like '%" + txtSearch.Text.Trim() + "%' or MobileNo like '%" + txtSearch.Text.Trim() + "%'  or EmailId like'%" + txtSearch.Text.Trim() + "%'";
                dt.DefaultView.ToTable();
                GrdPendingReg.DataSource = dt;
                GrdPendingReg.DataBind();
            }
            if (rbValid.Checked == true)
            {
                DateTime mydate1 = DateTime.Now;
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { (mydate1).ToString("yyyy/MM/dd"), "5" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '%" + txtSearch.Text.Trim() + "%' or Name like '%" + txtSearch.Text.Trim() + "%' or MobileNo like '%" + txtSearch.Text.Trim() + "%'  or EmailId like'%" + txtSearch.Text.Trim() + "%'";
                dt.DefaultView.ToTable();
                GrdValidReg.DataSource = dt;
                GrdValidReg.DataBind();
            }
            if (rbDuplicate.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "5", "2" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '%" + txtSearch.Text.Trim() + "%' or FName like '%" + txtSearch.Text.Trim() + "%' or MobileNo like '%" + txtSearch.Text.Trim() + "%'  or EmailId like'%" + txtSearch.Text.Trim() + "%'";
                GrdDupicateReg.DataSource = dt;
                GrdDupicateReg.DataBind();
            }
            if (rbProvisional.Checked == true)
            {
                DataTable dt = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { "7", "2" }, "dataset").Tables[0];
                dt.DefaultView.RowFilter = "RegiNo like  '%" + txtSearch.Text.Trim() + "%' or FName like '%" + txtSearch.Text.Trim() + "%' or MobileNo like '%" + txtSearch.Text.Trim() + "%'  or EmailId like'%" + txtSearch.Text.Trim() + "%'";
                GrdProvisional.DataSource = dt;
                GrdProvisional.DataBind();
            }

        }
        catch { }
    }

    protected void rbDuplicate_CheckedChanged(object sender, EventArgs e)
    {
        if (rbDuplicate.Checked == true)
        {
            GrdDupicateReg.Visible = true;
            GrdTransferOutside.Visible = false;
            GrdPendingReg.Visible = false;
            GrdValidReg.Visible = false;
            GrdTransfer.Visible = false;
            GrdRenew.Visible = false;
            GrdProvisional.Visible = false;
            GrdComplaint.Visible = false;
            GridFillLoad();
        }
    }

    protected void rbOutsideTransfer_CheckedChanged(object sender, EventArgs e)
    {
        if (rbOutsideTransfer.Checked == true)
        {
            GrdTransferOutside.Visible = true;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdValidReg.Visible = false;
            GrdTransfer.Visible = false;
            GrdRenew.Visible = false;
            GrdProvisional.Visible = false;
            GrdComplaint.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbRenew_CheckedChanged(object sender, EventArgs e)
    {
        if (rbRenew.Checked == true)
        {
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdValidReg.Visible = false;
            GrdTransfer.Visible = false;
            GrdRenew.Visible = true;
            GrdProvisional.Visible = false;
            GrdComplaint.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbTransfer_CheckedChanged(object sender, EventArgs e)
    {
        if (rbTransfer.Checked == true)
        {
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdValidReg.Visible = false;
            GrdRenew.Visible = false;
            GrdTransfer.Visible = true;
            GrdProvisional.Visible = false;
            GrdComplaint.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbPending_CheckedChanged(object sender, EventArgs e)
    {
        if (rbPending.Checked == true)
        {
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = true;
            GrdValidReg.Visible = false;
            GrdRenew.Visible = false;
            GrdTransfer.Visible = false;
            GrdProvisional.Visible = false;
            GrdComplaint.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbValid_CheckedChanged(object sender, EventArgs e)
    {
        if (rbValid.Checked == true)
        {
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdValidReg.Visible = true;
            GrdRenew.Visible = false;
            GrdTransfer.Visible = false;
            GrdProvisional.Visible = false;
            GrdComplaint.Visible = false;
            GridFillLoad();
        }
    }
    protected void rbProvisional_CheckedChanged(object sender, EventArgs e)
    {
        if (rbProvisional.Checked == true)
        {
            GrdProvisional.Visible = true;
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdValidReg.Visible = false;
            GrdRenew.Visible = false;
            GrdTransfer.Visible = false;
            GrdComplaint.Visible = false;
            GridFillLoad();
        }
    }
    protected void GrdPendingReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdPendingReg.Rows[GrdPendingReg.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("EditRegistration.aspx?editR=" + Server.UrlEncode(var));
    }

    protected void GrdRenew_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdRenew.Rows[GrdRenew.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("EditRegistration.aspx?editR=" + Server.UrlEncode(var));
    }
    protected void GrdValidReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsNew = new DataSet();
        DateTime outwardDate = DateTime.Now;
        string getId = hf_Gettappid.Value;
        string getpid = hf_GetPid.Value;

        string mailSubject = "";
        string mailBody = "";
        string uploaddocpath = "";
        Button btn = new Button();
        btn = (Button)GrdValidReg.Rows[GrdValidReg.SelectedIndex].FindControl("btnsave");
        string regid = btn.ToolTip;

        string[] arr = regid.Split("*".ToCharArray());
        string applicationNo = arr[1];
        string Tid = arr[0];
        FileUpload fuUpload = new FileUpload();
        fuUpload = (FileUpload)GrdValidReg.Rows[GrdValidReg.SelectedIndex].FindControl("FileUploadcert");
        TextBox txtOutNo = new TextBox();
        txtOutNo = (TextBox)GrdValidReg.Rows[GrdValidReg.SelectedIndex].FindControl("txtOutwardNo");

        dsNew = objdb.ByDataSet("select * from tblNewRegistration where ApplicationNo='" + applicationNo + "'");
        string appreqid = dsNew.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
        string paramaddress = dsNew.Tables[0].Rows[0]["ResAdd"].ToString();

        if (txtOutNo.Text != "")
        {
            if (fuUpload.HasFile)
            {
                uploaddocpath = Guid.NewGuid() + "-" + fuUpload.FileName;
                fuUpload.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + uploaddocpath));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageAlert();", true);
                return;
            }
            if (appreqid != "2")
            {
                objdb.ByText("update tbl_Transactiondetails set   RegistrationStatus = 4, OutwardNumber = '" + txtOutNo.Text + "', OutwardDate='" + Convert.ToDateTime(outwardDate, cult).ToString("yyyy/MM/dd") + "' where Id='" + Tid + "'");
                objdb.ByText("update tblNewRegistration set CertificatePath = '" + uploaddocpath.ToString() + "' , RegistrationStatus = 4   where ApplicationNo =" + applicationNo + "");
            }
            else
            {
                objdb.ByText("update tbl_Transactiondetails set   RegistrationStatus = 4, ApplicationRequestId=2, OutwardNumber = '" + txtOutNo.Text + "', OutwardDate='" + Convert.ToDateTime(outwardDate, cult).ToString("yyyy/MM/dd") + "' where Id='" + Tid + "'");
                objdb.ByText("update tblNewRegistration set CertificatePath = '" + uploaddocpath.ToString() + "' , RegistrationStatus = 4, ApplicationRequestId=8   where ApplicationNo =" + applicationNo + "");
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), " ", "MessageUpload();", true);


            DataSet ds = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string rbmobileprefered = ds.Tables[0].Rows[0]["PreferedPhoneNo"].ToString();
                if (rbmobileprefered == "1")
                {
                    mbNo = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                }
                else
                {
                    mbNo = ds.Tables[0].Rows[0]["MobileNo2"].ToString();
                }
                string appRequestId = ds.Tables[1].Rows[0]["ApplicationRequestId"].ToString();
                //string paramAddress = ds.Tables[0].Rows[0]["PerAdd"].ToString() + " " + ds.Tables[0].Rows[0]["PerCity"].ToString() + " " + ds.Tables[0].Rows[0]["PerDistrict"].ToString() + " " + ds.Tables[0].Rows[0]["PerPinCode"].ToString();
                //string paramAddress = ds.Tables[0].Rows[0]["ResAdd"].ToString() + "," + ds.Tables[0].Rows[0]["ResCity"].ToString() + "," + ds.Tables[0].Rows[0]["ResDistrict"].ToString() + "," + ds.Tables[0].Rows[0]["ResPinCode"].ToString();
                //string paramAddress = "";
                //if (ds.Tables[0].Rows[0]["PreferedAdd"].ToString() == "Residential")
                //{
                //    paramAddress = ds.Tables[0].Rows[0]["ResAdd"].ToString() + "," + ds.Tables[0].Rows[0]["ResCity"].ToString() + "," + ds.Tables[0].Rows[0]["ResDistrict"].ToString() + "," + ds.Tables[0].Rows[0]["ResPinCode"].ToString();
                //}
                //else if (ds.Tables[0].Rows[0]["PreferedAdd"].ToString() == "Professional")
                //{
                //    paramAddress = ds.Tables[0].Rows[0]["ProAdd"].ToString() + " " + ds.Tables[0].Rows[0]["ProCity"].ToString() + " " + ds.Tables[0].Rows[0]["ProDistrict"].ToString() + " " + ds.Tables[0].Rows[0]["ProPinCode"].ToString();
                //}
                //else if (ds.Tables[0].Rows[0]["PreferedAdd"].ToString() == "Permanent")
                //{
                //    paramAddress = ds.Tables[0].Rows[0]["PerAdd"].ToString() + " " + ds.Tables[0].Rows[0]["PerCity"].ToString() + " " + ds.Tables[0].Rows[0]["PerDistrict"].ToString() + " " + ds.Tables[0].Rows[0]["PerPinCode"].ToString();
                //}
                if (appRequestId == "0")
                {
                    mailSubject = "MPSVC:- New registration certificate ";
                }
                if (appRequestId == "1")
                {
                    mailSubject = "MPSVC:- Renewal certificate ";
                }
                if (appRequestId == "2")
                {
                    mailSubject = "MPSVC:- Transfer certificate ";
                }
                if (appRequestId == "3")
                {
                    mailSubject = "MPSVC:- New registration certificate ";
                }
                if (appRequestId == "4")
                {
                    mailSubject = "MPSVC:- Duplicate registration Id Card ";
                }
                if (appRequestId == "5")
                {
                    mailSubject = "MPSVC:- Duplicate registration certificate ";
                }
                if (appRequestId == "7")
                {
                    mailSubject = "MPSVC:- Provisional registration certificate ";
                }


                //mailBody = objdb.CreateAdminCertificateEmailBody(Convert.ToInt32(appRequestId), paramAddress);
                //string mbMessage = objdb.CreateMessageCertificateEmailBody(Convert.ToInt32(appRequestId), paramAddress); // Message Body Function
                mailBody = objdb.CreateAdminCertificateEmailBody(Convert.ToInt32(appRequestId), paramaddress);//change with old
                string mbMessage = objdb.CreateMessageCertificateEmailBody(Convert.ToInt32(appRequestId), paramaddress); //change with old
                string emailid = ds.Tables[0].Rows[0]["EmailId"].ToString();
                string uDoc = "Upload_Certificate/" + ds.Tables[0].Rows[0]["CertificatePath"].ToString();
                objdb.SendMailMPSVC(emailid, mailSubject, mailBody, uDoc, mbNo, mbMessage);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "ValidateOutwardNo();", true);
            return;
        }

        GridFillLoad();
    }

    protected void GrdValidReg_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hfRegStatus = new HiddenField();
            hfRegStatus = e.Row.FindControl("hf_RequestIdBit") as HiddenField;

            if (hfRegStatus.Value == "4")
            {
                e.Row.FindControl("FileUploadcert").Visible = false;
            }

            HiddenField hf = new HiddenField();
            hf = e.Row.FindControl("hf_ApplicationStatus") as HiddenField;


            HiddenField hfid = new HiddenField();
            hfid = e.Row.FindControl("hf_Pid") as HiddenField;
            hf_GetPid.Value = hfid.Value;


            hf_Gettappid.Value = hf.Value;

            if (hf.Value == "0")
            {
                e.Row.CssClass = "newgrd";

            }
            else if (hf.Value == "1")
            {
                e.Row.CssClass = "renewgrd";
            }
            else if (hf.Value == "2")
            {
                e.Row.CssClass = "transfergrd";
            }
            else if (hf.Value == "5")
            {
                e.Row.CssClass = "DuplicateGrd";
            }
            else if (hf.Value == "7")
            {
                e.Row.CssClass = "ProvisionalGrd";
            }
        }
    }

    protected void GrdTransfer_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdTransfer.Rows[GrdTransfer.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid; 
        //Response.Redirect("~/TransferRegistration.aspx?editTransfer=" + Server.UrlEncode(var));
       // Response.Redirect("../VerifyForm/VerifyTransferregistrationMP.aspx?var=" + Server.UrlEncode(var));
	   Response.Redirect("../TransferRegistrationoutofMP.aspx?editTransfer=" + Server.UrlEncode(var));
       
    }


    protected void GrdTransferOutside_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdTransferOutside.Rows[GrdTransferOutside.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("EditRegistration.aspx?editR=" + Server.UrlEncode(var));
    }

    protected void GrdDupicateReg_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdDupicateReg.Rows[GrdDupicateReg.SelectedIndex].FindControl("btnverify");
        string regid = btn.ToolTip;
        string var = regid;
        Response.Redirect("~/DuplicateCertificate.aspx?editDuplicate=" + Server.UrlEncode(var));
    }

    protected void rbComplaint_CheckedChanged(object sender, EventArgs e)
    {
        if (rbComplaint.Checked == true)
        {
            GrdProvisional.Visible = false;
            GrdTransferOutside.Visible = false;
            GrdDupicateReg.Visible = false;
            GrdPendingReg.Visible = false;
            GrdValidReg.Visible = false;
            GrdRenew.Visible = false;
            GrdTransfer.Visible = false;
            GrdComplaint.Visible = true;
            GridFillLoad();
        }
    }
    protected void GrdComplaint_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDupicateReg.PageIndex = e.NewPageIndex;
        GrdTransferOutside.PageIndex = e.NewPageIndex;
        GrdValidReg.PageIndex = e.NewPageIndex;
        GrdPendingReg.PageIndex = e.NewPageIndex;
        GrdTransfer.PageIndex = e.NewPageIndex;
        GrdRenew.PageIndex = e.NewPageIndex;
        GrdProvisional.PageIndex = e.NewPageIndex;
        GrdComplaint.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void GrdComplaint_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn = (Button)GrdComplaint.Rows[GrdComplaint.SelectedIndex].FindControl("btnverify");
        string btnComplaintVerify = btn.ToolTip;
        string ComplaintVerify = btnComplaintVerify;
        Response.Redirect("~/AdminSection/ComplaintVerification.aspx?editComplaint=" + Server.UrlEncode(ComplaintVerify));
    }
}
