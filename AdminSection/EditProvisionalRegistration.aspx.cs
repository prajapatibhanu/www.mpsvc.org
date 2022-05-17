using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Globalization;

public partial class AdminSection_EditProvisionalRegistration : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    APIProcedure objdb = new APIProcedure(); string path2, path3, path4;
    string mbNo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {          
            fnPerState();
            getResDistrict();
            DateTime myDate = DateTime.Now;
            DateTime backDays = myDate.AddDays(-45);
            HdnDate.Value = Convert.ToDateTime(backDays).ToString("MM/dd/yyyy");
            DataSet dd1 = objdb.ByDataSet("select * from Tbl_UniversityMaster");
            if (dd1.Tables[0].Rows.Count > 0)
            {
                ddl1.DataTextField = "UniversityName";
                ddl1.DataValueField = "id";
                ddl1.DataSource = dd1.Tables[0];
                ddl1.DataBind();
                ListItem LiItem1 = new ListItem();
                LiItem1.Text = "Select";
                LiItem1.Value = "0";
            }          
            FieldFill(sender, e);
        }
    }

    protected void Ok_Click(object sender, EventArgs e)
    {
        if (Session["IsVerify"] != null)
        {
            if (Session["IsVerify"].ToString() == "1")
            {
                Response.Redirect("FrmSecondLevelValid.aspx");
            }
            else
            {
                Response.Redirect("ActionRegistration.aspx");
            }
        }
    }

    public void FieldFill(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["editProvisional"] != null)
            {
                string[] arr = Request.QueryString["editProvisional"].ToString().Split("*".ToCharArray());
                string applicationNo = arr[1];
                string Tid = arr[0];
                ds = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");              
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtRegNo.Enabled = false;
                    txtRegNo.Text = ds.Tables[1].Rows[0]["ApplicationNo"].ToString();
                    txtRegDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ApplicationDate"]).ToString("yyyy/MM/dd");
                    txtFName.Text = ds.Tables[0].Rows[0]["FName"].ToString();
                    txtMName.Text = ds.Tables[0].Rows[0]["MName"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["LName"].ToString();
                    txtFatherName.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                    txtDOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]).ToString("dd/MM/yyyy");
                    try
                    {
                        ddlGender.ClearSelection();
                        ddlGender.Items.FindByText(ds.Tables[0].Rows[0]["Gender"].ToString()).Selected = true;
                    }
                    catch { }
                    txtResAdd.Text = ds.Tables[0].Rows[0]["ResAdd"].ToString();
                    txtResCity.Text = ds.Tables[0].Rows[0]["ResCity"].ToString();
                    txtResPost.Text = ds.Tables[0].Rows[0]["ResPost"].ToString();
                    txtResTehsil.Text = ds.Tables[0].Rows[0]["ResTehsil"].ToString();
                    txtResPinCode.Text = ds.Tables[0].Rows[0]["ResPinCode"].ToString();
                    try
                    {
                        ddlResState.ClearSelection();
                        ddlResState.Items.FindByValue(ds.Tables[0].Rows[0]["ResState"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        ddlResDistrict.ClearSelection();
                        ddlResDistrict.Items.FindByText(ds.Tables[0].Rows[0]["ResDistrict"].ToString()).Selected = true;
                    }
                    catch { }

                    txtPerAdd.Text = ds.Tables[0].Rows[0]["PerAdd"].ToString();
                    txtPerCity.Text = ds.Tables[0].Rows[0]["PerCity"].ToString();                 
                    txtPerPost.Text = ds.Tables[0].Rows[0]["PerPost"].ToString();
                    txtPerTehsil.Text = ds.Tables[0].Rows[0]["PerTehsil"].ToString();
                    txtPerPinCode.Text = ds.Tables[0].Rows[0]["PerPinCode"].ToString();
                    try
                    {
                        ddlPerState.ClearSelection();
                        ddlPerState.Items.FindByValue(ds.Tables[0].Rows[0]["PerState"].ToString()).Selected = true;
                    }
                    catch { }

                    try
                    {
                        ddlPerState_SelectedIndexChanged(sender, e);
                        ddlPerDistrict.ClearSelection();
                        ddlPerDistrict.Items.FindByText(ds.Tables[0].Rows[0]["PerDistrict"].ToString()).Selected = true;
                    }
                    catch { }

                    try
                    {
                        ddlPreffAddress.ClearSelection();
                        ddlPreffAddress.Items.FindByValue(ds.Tables[0].Rows[0]["PreferedAdd"].ToString()).Selected = true;
                    }
                    catch { }
                    txtMobileNo1.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    txtMobileNo2.Text = ds.Tables[0].Rows[0]["MobileNo2"].ToString();
                    txtEmailId.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                    txtRollNo.Text = ds.Tables[0].Rows[0]["RollNo"].ToString();
                    txtUniversityEnrollNo.Text = ds.Tables[0].Rows[0]["UniversityEnrollmentNo"].ToString();
                    string str = "";
                    str = ds.Tables[0].Rows[0]["PreferedPhoneNo"].ToString();
                    if (str == "1")
                    {
                        rbmobile1.Checked = true;
                    }
                    else
                    {
                        rbmobile2.Checked = true;
                    }
                    try
                    {
                        ddl1.ClearSelection();
                        ddl1.Items.FindByValue(ds.Tables[0].Rows[0]["University1"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        if (ddl1.SelectedIndex > 0)
                        {
                            ddl1_SelectedIndexChanged(sender, e);
                            ddlc1.ClearSelection();
                            ddlc1.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID1"].ToString()).Selected = true;
                        }
                    }
                    catch { }

                    try
                    {
                        GetCurrentFinancialYear();
                        ddlY1.ClearSelection();
                        ddlY1.Items.FindByValue(ds.Tables[0].Rows[0]["Year1"].ToString()).Selected = true;
                    }
                    catch { }

                    string str1 = "";
                    str1 = ds.Tables[1].Rows[0]["Isonline"].ToString();
                    if (str1 == "1")
                    {
                        rbOnline.Checked = true;
                        tr_payment.Visible = false;
                        tr_cheque.Visible = false;
                        tr_Pdate.Visible = false;
                    }
                    else
                    {
                        rboffline.Checked = true;
                    }

                    if (rboffline.Checked == true)
                    {
                        txtcheque.Text = ds.Tables[1].Rows[0]["ChequeNo"].ToString();
                        txtbank.Text = ds.Tables[1].Rows[0]["BankName"].ToString();
                        txtPaymentDate.Text = Convert.ToDateTime(ds.Tables[1].Rows[0]["ChequeDate"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                    }
                    HF_DomicileCert.Value = ds.Tables[0].Rows[0]["File1"].ToString();
                    HF_Photo.Value = ds.Tables[0].Rows[0]["File2"].ToString();
                    HF_OtherCert.Value = ds.Tables[0].Rows[0]["File3"].ToString();
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Invalid registration no.";
                }
            }
        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }
    }

    public void GetCurrentFinancialYear()
    {
        int CurrentYear = DateTime.Today.Year;
        int PreviousYear = DateTime.Today.Year - 1;
        int NextYear = DateTime.Today.Year + 1;
        string PreYear = PreviousYear.ToString();
        string NexYear = NextYear.ToString();
        string CurYear = CurrentYear.ToString();
        string FinYear = null;
        if (DateTime.Today.Month > 3)
            FinYear = CurYear + "-" + NexYear;
        else
            FinYear = PreYear + "-" + CurYear;       
        ListItem LiItem1 = new ListItem();
        LiItem1.Text = FinYear;
        LiItem1.Value = FinYear;
        ddlY1.Items.Insert(0, LiItem1);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string RegistrationStatusBit = "2";
            if (Session["IsVerify"] != null)
            {
                if (Session["IsVerify"].ToString() == "1")
                {
                    RegistrationStatusBit = "3";
                }
            }
            string rbmobileprefered = "";

            if (rbmobile1.Checked == true)
            {
                rbmobileprefered = "1";
            }
            else
            {
                rbmobileprefered = "0";
            }
            string FileName = "";
            string file1path = "";
            string file2path = "";
            string file3path = "";          
            DataSet ds = new DataSet();
            string ImgStatus = "";
            string FileName1 = "";
            string ImgStatus1 = "";
            string FileName2 = "";
            string ImgStatus2 = "";
            string FileName3 = "";
            string ImgStatus3 = "";
            string isOnline = "";
            DateTime DteCheck;
            string RegDate = Convert.ToDateTime(DateTime.Now, cult).ToString("yyyy/MM/dd");
            DateTime mydate = DateTime.Now;
            //DateTime sixMonthsbackDate = mydate.AddMonths(6);
			DateTime sixMonthsbackDate = mydate.AddYears(1);
            string ValidupTo = Convert.ToDateTime(sixMonthsbackDate, cult).ToString("yyyy/MM/dd");
            string[] arr = Request.QueryString["editProvisional"].ToString().Split("*".ToCharArray());
            string applicationNo = arr[1];
            string Tid = arr[0];
            DataSet dsDetails = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");          
            string DOB = "";
            if (txtDOB.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtDOB.Text, cult);
                }
                catch { DOB = "NoDate"; }
            }
            if (txtRegDate.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtRegDate.Text, cult);
                }
                catch { RegDate = "NoDate"; }
            }
            if (DOB != "")
            {
                lblMsg.Text = objdb.ErrorAlert("Please enter correct Date Of Birth.");
            }
            else
            {
                if (rboffline.Checked == true)
                {
                    isOnline = "0";
                }
                else
                {
                    isOnline = "1";
                }
                if (rbDecline.Checked == true)
                {
                    if (FileUpload1.HasFile)
                    {
                        file1path = Guid.NewGuid() + "-" + FileUpload1.FileName;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file1path));
                    }
                }
                else
                {
                    file1path = HF_DomicileCert.Value;
                }
                if (rbDecline2.Checked == true)
                {
                    if (FileUpload2.HasFile)
                    {
                        file2path = Guid.NewGuid() + "-" + FileUpload2.FileName;
                        FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file2path));
                    }
                }
                else
                {
                    file2path = HF_Photo.Value;
                }
                if (rbDecline3.Checked == true)
                {
                    if (FileUpload3.HasFile)
                    {
                        file3path = Guid.NewGuid() + "-" + FileUpload3.FileName;
                        FileUpload3.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file3path));
                    }
                }
                else
                {
                    file3path = HF_OtherCert.Value;
                }
                if (Request.QueryString["editProvisional"] != null)
                {
                    string ApplicationReqestId = dsDetails.Tables[1].Rows[0]["ApplicationRequestId"].ToString();
                    string tranStatus = dsDetails.Tables[1].Rows[0]["TransactionStatus"].ToString();
                    string tranId = dsDetails.Tables[1].Rows[0]["TransactionId"].ToString();
                    if (rboffline.Checked == true)
                    {
                        ds = objdb.ByProcedure("ProcProvisionalRegistration", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "ResAdd", "ResCity", "ResDistrict", "ResPost", "ResTehsil", "ResPinCode", "ResState", "PerAdd", "PerCity", "PerDistrict", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PreferedAdd", "MobileNo", "EmailId", "PreferedPhoneNo", "RollNo", "UniversityEnrollmentNo", "University1", "CollegeID1", "Year1", "Isonline", "ChequeNo", "BankName", "ChequeDate", "File1", "File2", "File3", "ApplicationRequestId", "RegistrationStatus", "type", "Validupto", "MobileNo2" },
                                                 new string[] { txtRegNo.Text, txtRegDate.Text, RegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, txtEmailId.Text, rbmobileprefered, txtRollNo.Text.Trim(), txtUniversityEnrollNo.Text.Trim(), ddl1.SelectedValue, ddlc1.SelectedValue, ddlY1.SelectedValue, isOnline, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), file1path, file2path, file3path, "7", RegistrationStatusBit, "1", ValidupTo, txtMobileNo2.Text }, "dataset");
                    }
                    else
                    {
                        ds = objdb.ByProcedure("ProcProvisionalRegistration", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "ResAdd", "ResCity", "ResDistrict", "ResPost", "ResTehsil", "ResPinCode", "ResState", "PerAdd", "PerCity", "PerDistrict", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PreferedAdd", "MobileNo", "EmailId", "PreferedPhoneNo", "RollNo", "UniversityEnrollmentNo", "University1", "CollegeID1", "Year1", "Isonline", "ChequeNo", "BankName", "ChequeDate", "File1", "File2", "File3", "ApplicationRequestId", "RegistrationStatus", "type", "Validupto", "MobileNo2" },
                         new string[] { txtRegNo.Text, txtRegDate.Text, RegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, txtEmailId.Text, rbmobileprefered, txtRollNo.Text.Trim(), txtUniversityEnrollNo.Text.Trim(), ddl1.SelectedValue, ddlc1.SelectedValue, ddlY1.SelectedValue, isOnline, txtcheque.Text, txtbank.Text, RegDate, file1path, file2path, file3path, "7", RegistrationStatusBit, "1", ValidupTo, txtMobileNo2.Text }, "dataset");
                    }
                    objdb.ByText(@"Update tbl_Transactiondetails set RegistrationStatus = '" + RegistrationStatusBit + "' where id ='" + Tid + "'");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (RegistrationStatusBit == "3")
                        {
                           DataSet dsValid = objdb.ByDataSet("Select * from tblNewRegistration where ApplicationNo = '" + applicationNo + "'");
                            //if (rbmobileprefered == "1")
                            //{
                            //    mbNo = dsValid.Tables[0].Rows[0]["MobileNo"].ToString();
                            //}
                            //else
                            //{
                            //    mbNo = dsValid.Tables[0].Rows[0]["MobileNo2"].ToString();
                            //}
                            string regno = dsValid.Tables[0].Rows[0]["RegiNo"].ToString();
                            string val = getDate(dsValid.Tables[0].Rows[0]["Validupto"].ToString());

                            //string mail = dsValid.Tables[0].Rows[0]["EmailId"].ToString();
                            //string subject = "MPSVC Verification Mail";
                            //string body = objdb.CreateAdminEmailBody(Convert.ToInt32(ApplicationReqestId), regno);
                            //string mbMessage = objdb.CreateAdminMessageBody(Convert.ToInt32(ApplicationReqestId), regno); // Message Body Function
                            //objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.
                            lblMSgAlert.Text = "Registration no. '" + regno + "' verified successfully valid upto '" + val + "' ";
                        }
                        else
                        {
                            lblMSgAlert.Text = "Application forwarded for second level verification.";
                        }
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopTemAndCondition();", true);
                            obCommonFuction.EmptyTextBoxes(this);
                        }
                    else
                    {
                        lblMsg.Text = objdb.ErrorAlert(ds.Tables[0].Rows[0]["Msg"].ToString());

                    }
                }
                else
                {

                }
            }
        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }
    }

    private string getDate(string InComingDate)
    {
        string[] slipDate = InComingDate.Split("".ToCharArray());
        string FinalDate = slipDate[0];
        string[] FDate = FinalDate.Split("/".ToCharArray());
        string Date_Final = FDate[1] + "/" + FDate[0] + "/" + FDate[2];
        return Date_Final;

    }
    public DataSet StateFill()
    {
        return objdb.ByProcedure("ProcStateFill", "BYdataset");
    }
    protected void fnPerState()
    {
        try
        {
            ddlPerState.DataSource = StateFill();
            ddlPerState.DataTextField = "StateName";
            ddlPerState.DataValueField = "StateId";
            ddlPerState.DataBind();
            ddlPerState.Items.Insert(0, "Select");
        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }
    }
    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl1.SelectedIndex > 0)
        {
            DataSet dd1 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl1.SelectedValue + "");
            if (dd1.Tables[0].Rows.Count > 0)
            {
                ddlc1.DataTextField = "CollegeName";
                ddlc1.DataValueField = "id";
                ddlc1.DataSource = dd1.Tables[0];
                ddlc1.DataBind();
                ListItem LiItemc1 = new ListItem();
                LiItemc1.Text = "Select";
                LiItemc1.Value = "0";
                ddlc1.Items.Insert(0, LiItemc1);
                ddl1.Focus();
            }
        }
    }
    protected void getResDistrict()
    {
        try
        {
            DataSet dt3 = objdb.ByDataSet("select * from Districts where StateId=" + ddlResState.SelectedValue + "");
            ddlResDistrict.DataTextField = "DistrictName";
            ddlResDistrict.DataValueField = "DistrictId";
            ddlResDistrict.DataSource = dt3.Tables[0];
            ddlResDistrict.DataBind();
            ddlResDistrict.Items.Insert(0, "Select");
        }
        catch { }
    }
    protected void chkPermanent_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkPermanent.Checked == true)
            {
                txtPerAdd.Text = txtResAdd.Text.Trim();
                txtPerCity.Text = txtResCity.Text.Trim();
                ddlPerState.SelectedValue = ddlResState.SelectedValue;
                ddlPerState_SelectedIndexChanged(sender, e);
                ddlPerDistrict.SelectedValue = ddlResDistrict.SelectedValue;
                txtPerPost.Text = txtResPost.Text.Trim();
                txtPerTehsil.Text = txtResTehsil.Text.Trim();
                txtPerPinCode.Text = txtResPinCode.Text.Trim();
            }
            else
            {
                txtPerAdd.Text = "";
                txtPerCity.Text = "";
                ddlPerDistrict.SelectedIndex = 0;
                txtPerPost.Text = "";
                txtPerTehsil.Text = "";
                ddlPerState.SelectedIndex = 0;
                txtPerPinCode.Text = "";
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void ddlPerState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPerState.SelectedIndex > 0)
            {
                DataSet dt1 = objdb.ByDataSet("select * from Districts where StateId='" + ddlPerState.SelectedValue + "'");
                if (dt1.Tables[0].Rows.Count > 0)
                {
                    ddlPerDistrict.DataTextField = "DistrictName";
                    ddlPerDistrict.DataValueField = "DistrictId";
                    ddlPerDistrict.DataSource = dt1.Tables[0];
                    ddlPerDistrict.DataBind();
                    ddlPerDistrict.Items.Insert(0, "Select");
                    ddlPerDistrict.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }

    protected void lnkdisApprove_Click(object sender, EventArgs e)
    {
        if (Session["IsVerify"] != null)
        {
            if (Session["IsVerify"].ToString() == "1")
            {
                Response.Redirect("~/AdminSection/FrmSecondLevelValid.aspx");
            }
            else
            {
                Response.Redirect("~/AdminSection/ActionRegistration.aspx");
            }
        }
    }
}