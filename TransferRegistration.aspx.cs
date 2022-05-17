using System;
using System.Data;
using System.Globalization;
using System.Web.UI;

public partial class TransferRegistration : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSecurity Isecrity = new DataSecurity();
    DataSet ds;
    APIProcedure objdb = new APIProcedure(); string path2, path3, path4;
    string mbNo = "";
    string SendOTP = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DateTime myDate = DateTime.Now;
            DateTime backDays = myDate.AddDays(-45);
            HdnDate.Value = Convert.ToDateTime(backDays).ToString("MM/dd/yyyy");
            btnUpdate.Enabled = false;
            DataSet dt2 = objdb.ByDataSet("select * from tbl_OrganizationMaster");
            if (dt2.Tables[0].Rows.Count > 0)
            {
                ddlorg.DataTextField = "OrganaizationName";
                ddlorg.DataValueField = "ID";
                ddlorg.DataSource = dt2.Tables[0];
                ddlorg.DataBind();
                ddlorg.Items.Insert(0, "Select");
            }
            DataSet dt4 = objdb.ByDataSet("select * from Tbl_Sectormaster");
            if (dt4.Tables[0].Rows.Count > 0)
            {
                ddlPresentOcc.DataTextField = "SectorName";
                ddlPresentOcc.DataValueField = "ID";
                ddlPresentOcc.DataSource = dt4.Tables[0];
                ddlPresentOcc.DataBind();
                ddlPresentOcc.Items.Insert(0, "Select");
            }
            if (Request.QueryString["editTransfer"] != null)
            {
                string[] arr = Request.QueryString["editTransfer"].ToString().Split("*".ToCharArray());
                string applicationNo = arr[1];
                DataSet dscal = objdb.ByDataSet("select * from tblNewRegistration where ApplicationNo='" + applicationNo + "'");
                tr_Reg.Visible = false;
                btnUpdate.Text = "Verify";
                btnUpdate.Enabled = true;
                FillUserDetails(sender, e);
                lnkdisApprove.Visible = true;
            }
            else
            {
                tr_Reg.Visible = true;
                btnUpdate.Text = "Save & Pay";
            }
        }
    }

    public void FieldFill(object sender, EventArgs e)
    {
        string chkCancel = "";
        try
        {
            if (Request.QueryString["editTransfer"] != null)
            {
                string[] arr = Request.QueryString["editTransfer"].ToString().Split("*".ToCharArray());
                string applicationNo = arr[1];
                string Tid = arr[0];
                ds = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
            }
            else
            {
                if (txtRegNo.Text.Trim() != "")
                {
                    ds = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + txtRegNo.Text + "' and ApplicationRequestId <> 7 and ApplicationRequestId <> 8");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        chkCancel = ds.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
                        if (chkCancel == "9")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "CancelRegistration();", true);
                            return;
                        }
                    }
                }
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                    if (ds.Tables[0].Rows[0]["PreferedPhoneNo"].ToString() == "1")
                    {
                        SendOTP = objdb.Send_OTP(ds.Tables[0].Rows[0]["MobileNo"].ToString());
                        lblMobilealert.Text = " Does " + ds.Tables[0].Rows[0]["MobileNo"].ToString() + " really belong to you? ";
                    }
                    else
                    {
                        SendOTP = objdb.Send_OTP(ds.Tables[0].Rows[0]["MobileNo2"].ToString());
                        lblMobilealert.Text = " Does " + ds.Tables[0].Rows[0]["MobileNo2"].ToString() + " really belong to you? ";
                    }                
                    ViewState["OTPSended"] = SendOTP;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPVerification();", true);
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Invalid registration no.";
            }

        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }
    }

    protected void ddlorg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlorg.SelectedIndex > 0)
            {
                DataSet dt1 = objdb.ByDataSet("select * from tbl_Departmentmaster where Organaizationid='" + ddlorg.SelectedValue + "'");
                if (dt1.Tables[0].Rows.Count > 0)
                {
                    ddldept.DataTextField = "DepaertmentName";
                    ddldept.DataValueField = "ID";
                    ddldept.DataSource = dt1.Tables[0];
                    ddldept.DataBind();
                    ddldept.Items.Insert(0, "Select");
                    string ddlOrgName = ddlorg.SelectedItem.Text;
                    if (ddlOrgName == "Other")
                    {
                        txtOrg.Visible = true;
                    }
                    else
                    {
                        txtOrg.Visible = false;
                    }
                }
            }
            else
            {
                ddldept.Items.Clear();
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }

    protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddldept.SelectedIndex > 0)
            {
                DataSet dt3 = objdb.ByDataSet("select * from tbl_Designationmaster where OrganaizationId=" + ddlorg.SelectedValue + " and DepartmentID=" + ddldept.SelectedValue + "");
                if (dt3.Tables[0].Rows.Count > 0)
                {
                    ddldesig.DataTextField = "DesinationName";
                    ddldesig.DataValueField = "ID";
                    ddldesig.DataSource = dt3.Tables[0];
                    ddldesig.DataBind();
                    ddldesig.Items.Insert(0, "Select");
                    string ddlDeptName = ddldept.SelectedItem.Text;
                    string ddldeptNameOrg = ddldept.SelectedItem.Text;
                    if (ddlDeptName == "Other")
                    {
                        txtDept.Visible = true;
                    }
                    else if (ddldeptNameOrg == "Name of Organization & Address")
                    {
                        txtDept.Visible = true;
                    }
                    else
                    {
                        txtDept.Visible = false;
                    }
                }
            }
            else {
                ddldesig.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }

    protected void ddldesig_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ddldesigName = ddldesig.SelectedItem.Text;
        if (ddldesigName == "Other")
        {
            txtDesig.Visible = true;
        }
        else
        {
            txtDesig.Visible = false;
        }
    }

    protected void ddlPresentOcc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string ddlPDoc = ddlPresentOcc.SelectedItem.Text;
            if (ddlPDoc == "Other")
            {
                txtPresentOcc.Visible = true;
            }
            else
            {
                txtPresentOcc.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString());
        }
    }

    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/RegistrationLink.html");
        }
        catch (Exception ex)
        {
            lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString());
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtRegNo.Text != "")
            {
                btnUpdate.Enabled = true;
                FieldFill(sender, e);
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Please enter registration no.";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString());
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string Tid = "";
            string TempTranId = "";
            string editApplicationNo = "";
            string applicationno = "";
            string pNo = txtPreffPhoneNo.Text.Trim();
            string std = txtSTDcode.Text.Trim();
            string PreferedNo = std + "-" + pNo;
            string faxNo = txtFaxNo.Text.Trim();
            string stdfaxCode = txtStdFaxCode.Text.Trim();
            string stdFax = stdfaxCode + "-" + faxNo;
            string rbmobileprefered = "";
            if (rbmobile1.Checked == true)
            {
                rbmobileprefered = "1";
            }
            else
            {
                rbmobileprefered = "0";
            }
            if (Request.QueryString["editTransfer"] != null)
            {
                string[] arr = Request.QueryString["editTransfer"].ToString().Split("*".ToCharArray());
                string applicationNo = arr[1];
                Tid = arr[0];
                DataSet dsDetails = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
                editApplicationNo = dsDetails.Tables[1].Rows[0]["ApplicationNo"].ToString();
            }
            else
            {
                DataSet dsApplication = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + hf_regno.Value + "'");
                applicationno = dsApplication.Tables[0].Rows[0]["ApplicationNo"].ToString();
            }
            string FileName = "";
            string file1path = "";
            string file2path = "";
            string file3path = "";
            string file4path = "";
            string file5path = "";
            string isOnline = "";

            DateTime DteCheck;
            string Appdate = Convert.ToDateTime(DateTime.Now, cult).ToString("yyyy/MM/dd");
            string DOB = "", RegDate = "";
            if (txtDOB.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtDOB.Text, cult);
                }
                catch { DOB = "NoDate"; }
            }
            if (DOB != "")
            {
                lblMsg.Text = objdb.ErrorAlert("Please enter correct Date Of Birth.");
            }
            else if (RegDate != "")
            {
                lblMsg.Text = objdb.ErrorAlert("Please enter correct Registration Date.");
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
                string regStatus = "";
                if (Request.QueryString["editTransfer"] != null)
                {
                    regStatus = "2";
                    if (Session["IsVerify"] != null)
                    {
                        if (Session["IsVerify"].ToString() == "1")
                        {
                            regStatus = "3";
                        }
                    }
                }
                else
                {
                    regStatus = "1";
                }
                if (Request.QueryString["editTransfer"] != null)
                {
                    string Validupto;
                    string[] arr = Request.QueryString["editTransfer"].ToString().Split("*".ToCharArray());
                    string applicationNo = arr[1];
                    Tid = arr[0];
                    DataSet dsDetails = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
                    DateTime Lvalue = DateTime.Now;
                    DateTime rValue = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["Validupto"].ToString());
                    if (Lvalue > rValue)
                    {
                        DateTime mydate = DateTime.Now;
                        DateTime Fiveyearbackdate = mydate.AddYears(5);
                        Validupto = GetValidUpToDate(Convert.ToDateTime(Fiveyearbackdate, cult).ToString("yyyy/MM/dd"));
                    }
                    else
                    {
                        Validupto = dsDetails.Tables[0].Rows[0]["Validupto"].ToString();
                    } 
                    if (rboffline.Checked == true)
                    {
                        ds = objdb.ByProcedure("ProcTransferRegistration", new string[] { "RegiNo", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "Transferstateid", "Isonline", "ChequeNo", "BankName", "ChequeDate", "ApplicationRequestId", "RegistrationStatus", "type", "MobileNo2", "Validupto" },
                         new string[] { hf_regno.Value, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedValue.ToString(), ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddlTransferState.SelectedValue.ToString(), isOnline, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), "2", regStatus, "1", txtMobileNo2.Text, Validupto }, "dataset");
                    }
                    else
                    {
                        ds = objdb.ByProcedure("ProcTransferRegistration", new string[] { "RegiNo", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "Transferstateid", "Isonline", "ChequeNo", "BankName", "ChequeDate", "ApplicationRequestId", "RegistrationStatus", "type", "MobileNo2", "Validupto" },
                         new string[] { hf_regno.Value, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedValue.ToString(), ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddlTransferState.SelectedValue.ToString(), isOnline, txtcheque.Text, txtbank.Text, Appdate, "2", regStatus, "1", txtMobileNo2.Text, Validupto }, "dataset");
                    }
                    objdb.ByText(@"Update tbl_Transactiondetails set RegistrationStatus = '" + regStatus + "' where id ='" + Tid + "'");
                }
                else
                {
                    if (rboffline.Checked == true)
                    {
                        ds = objdb.ByProcedure("ProcTransferRegistration", new string[] { "RegiNo", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "Transferstateid", "Isonline", "ChequeNo", "BankName", "ChequeDate", "ApplicationRequestId", "RegistrationStatus", "type", "MobileNo2" },
                         new string[] { hf_regno.Value, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedValue.ToString(), ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddlTransferState.SelectedValue.ToString(), isOnline, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), "2", regStatus, "2", txtMobileNo2.Text }, "dataset");

                        objdb.ByText(@"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus,ChequeNo,BankName,ChequeDate,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                        values('" + applicationno + "', 2,'" + Appdate + "','" + isOnline + "','" + HF_Totalamount.Value + "',1,'" + txtcheque.Text + "','" + txtbank.Text + "','" + Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd") + "',0,'" + HF_RenewalFees.Value + "','" + HF_transferFees.Value + "','" + HF_ServiceChagre.Value + "','" + HF_LateFees.Value + "','" + HF_ReEstabilishmentFees.Value + "',1,'')");
                    }
                    else
                    {
                        ds = objdb.ByProcedure("ProcTransferRegistration", new string[] { "RegiNo", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "Transferstateid", "Isonline", "ChequeNo", "BankName", "ChequeDate", "ApplicationRequestId", "RegistrationStatus", "type", "MobileNo2" },
                         new string[] { hf_regno.Value, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedValue.ToString(), ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddlTransferState.SelectedValue.ToString(), isOnline, txtcheque.Text, txtbank.Text, Appdate, "2", regStatus, "2", txtMobileNo2.Text }, "dataset");
      
                        string str1 = @"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus,ChequeNo,BankName,ChequeDate,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                        values('" + applicationno + "', 2,'" + Appdate + "','" + isOnline + "','" + HF_Totalamount.Value + "',1,'" + txtcheque.Text + "','" + txtbank.Text + "','" + txtPaymentDate.Text + "',0,'" + HF_RenewalFees.Value + "','" + HF_transferFees.Value + "','" + HF_ServiceChagre.Value + "','" + HF_LateFees.Value + "','" + HF_ReEstabilishmentFees.Value + "',0,'')";

                        DataSet dsNew = objdb.ByProcedure("InsertTempTransction", new string[] { "ApplicationNo", "TblMaster", "TblTran" }, new string[] { applicationno, str1, "" }, "dataset");
                        TempTranId = dsNew.Tables[0].Rows[0]["id"].ToString();
                    }
                }
               
                if (ds.Tables[0].Rows[0]["Msg"].ToString() == "Ok")
                {
                    if (Request.QueryString["editTransfer"] != null)
                    {
                        if (regStatus == "3")
                        {
                            DataSet dsSentMail = objdb.ByDataSet("Select * from tblNewRegistration where RegiNo='" + hf_regno.Value + "' ");
                            string regno = dsSentMail.Tables[0].Rows[0]["RegiNo"].ToString();
                            string val = getDate(dsSentMail.Tables[0].Rows[0]["Validupto"].ToString());
                            //string mail = dsSentMail.Tables[0].Rows[0]["EmailId"].ToString();
                            //string subject = "MPSVC Verification Mail";
                            //string body = objdb.CreateAdminEmailBody(2, hf_regno.Value);
                            //string mbMessage = objdb.CreateAdminMessageBody(2, hf_regno.Value); // Message Body Function
                            //if (rbmobileprefered == "1")
                            //{
                            //    mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo"].ToString();
                            //}
                            //else
                            //{
                            //    mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo2"].ToString();
                            //}
                            //objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.
                            lblSaveAlert.Text = "Registration no. '" + regno + "' verified successfully valid upto '" + val + "' ";
                        }
                        else
                        {
                            lblSaveAlert.Text = "Application forwarded for second level verification.";
                        }

                        HF_Ok.Value = "0";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopTemAndConditionOnSave();", true);
                        obCommonFuction.EmptyTextBoxes(this);
                    }
                    else
                    {
                        if (rboffline.Checked == true)
                        {
                            DataSet dsSentMail = objdb.ByDataSet("Select * from tblNewRegistration where RegiNo='" + hf_regno.Value + "' ");
                            string mail = dsSentMail.Tables[0].Rows[0]["EmailId"].ToString();
                            string subject = "MPSVC Registration Mail";
                            string body = objdb.CreateEmailBody(2, hf_regno.Value);
                            string mbMessage = objdb.CreateMessageBody(2, hf_regno.Value); // Message Body Function
                            if (rbmobileprefered == "1")
                            {
                                mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo"].ToString();
                            }
                            else
                            {
                                mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo2"].ToString();
                            }
                            objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true);
                            obCommonFuction.EmptyTextBoxes(this);
                        }
                        else
                        {                       
                            RedirectonPaymentGatewayPage("2", applicationno, TempTranId);
                        }
                    }
                }
                else
                {
                    lblMsg.Text = objdb.ErrorAlert(ds.Tables[0].Rows[0]["Msg"].ToString());
                }
            }
        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }
    }

    private string GetValidUpToDate(string InComingDate)
    {
        string[] slipDate = InComingDate.Split("".ToCharArray());
        string FinalDate = slipDate[0];
        string[] FDate = FinalDate.Split("/".ToCharArray());
        int current_month = Convert.ToInt32(FDate[1]);
        if (current_month <= 3)
        {
            FDate[0] = (Convert.ToInt32(FDate[0]) - 1).ToString();
        }
        string Date_Final = FDate[0] + "/03/31";
        return Date_Final;
    }
    protected void Ok_Click(object sender, EventArgs e)
    {
        if (HF_Ok.Value == "0")
        {
            if (Session["IsVerify"] != null)
            {
                if (Session["IsVerify"].ToString() == "1")
                {
                    Response.Redirect("AdminSection/FrmSecondLevelValid.aspx");
                }
                else
                {
                    Response.Redirect("AdminSection/ActionRegistration.aspx");
                }
            }
        }
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
    protected void ddlTransferState_Init(object sender, EventArgs e)
    {
        try
        {
            ddlTransferState.DataSource = StateFill();
            ddlTransferState.DataTextField = "StateName";
            ddlTransferState.DataValueField = "StateId";
            ddlTransferState.DataBind();
            ddlTransferState.Items.Insert(0, "Select");
        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }

    }
    private void FillHiddenCalculation(DataSet ds)
    {

        if (ds.Tables[0].Rows.Count > 0)
        {
            DateTime Lvalue = DateTime.Now;
            DateTime rValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"].ToString());
            int count = Math.Abs((Lvalue.Month - rValue.Month) + 12 * (Lvalue.Year - rValue.Year));
            if (Lvalue > rValue)
            {
                HF_RegistationFees.Value = "0";
                if (count < 120)
                {
                    HF_RenewalFees.Value = "0";
                    HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
                    HF_ReEstabilishmentFees.Value = "0";
                    HF_Totalamount.Value = (15 + Convert.ToInt32(count) * 5 + 25).ToString();
                }
                else
                {
                    HF_RenewalFees.Value = "0";
                    HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
                    HF_ReEstabilishmentFees.Value = "0";
                    HF_Totalamount.Value = (15 + Convert.ToInt32(count) * 5 + 25).ToString();
                }

            }
            else
            {
                HF_RenewalFees.Value = "0";
                HF_LateFees.Value = "0";
                HF_ReEstabilishmentFees.Value = "0";
                HF_Totalamount.Value = "15";
            }
        }

    }
    public void RedirectonPaymentGatewayPage(string ApplicationType, string ApplicationNo, string TempId)
    {
        string var = ApplicationNo + "*" + lblAmount.Text + "*" + txtEmailId.Text + "*" + txtMobileNo1.Text + "*" + txtFName.Text + "*" + ApplicationType + "*" + TempId;
        string EncryptedStr = Isecrity.Encrypt(var);
        obCommonFuction.EmptyTextBoxes(this);
        Response.Redirect("~/frmRequest.aspx?TRequest=" + Server.UrlEncode(EncryptedStr));
    }
    public void Button1_Click(object sender, EventArgs e)
    {
        string OTP = txtOTP.Text;
        SendOTP = ViewState["OTPSended"].ToString();
        if (SendOTP == OTP)
        {
            ViewState["OTPSended"] = null;
            lblOTPInvalid.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPNotVerified();", true);
            FillUserDetails(sender, e);
        }
        else
        {
            lblOTPInvalid.Text = "* Invalid OTP";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPVerification();", true);
        }
    }
    public void FillUserDetails(object sender, EventArgs e)
    {
        if (Request.QueryString["editTransfer"] != null)
        {
            string[] arr = Request.QueryString["editTransfer"].ToString().Split("*".ToCharArray());
            string applicationNo = arr[1];
            string Tid = arr[0];
            ds = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
            //ds = objdb.ByDataSet("select * from tblNewRegistration where id ='" + Request.QueryString["editTransfer"].ToString() + "'");
        }
        else
        {
            ds = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + txtRegNo.Text + "'");
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            /////////
            DateTime Lvalue = DateTime.Now;
            DateTime rValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"].ToString());
            int count = Math.Abs((Lvalue.Month - rValue.Month) + 12 * (Lvalue.Year - rValue.Year));
            if (Request.QueryString["editTransfer"] == null)
            {
                if (Lvalue > rValue)
                {
                    if (count < 120)
                    {
                        lblTransferFees.Text = "Rs. 15";
                        HF_transferFees.Value = "15";
                        lblRenewalFees.Text = "Rs. 15";
                        HF_RenewalFees.Value = "15";
                        lbllateFees.Text = "Rs." + (Convert.ToInt32(count) * 5).ToString();
                        HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
                        lblrestablishmentCharge.Text = "Rs. 25";
                        HF_ReEstabilishmentFees.Value = "25";
                        lblServiceFees.Text = "Rs. 1000";
                        HF_ServiceChagre.Value = "1000";
                        lblTotalAmount.Text = "Rs." + (15 + 15 + Convert.ToInt32(count) * 5 + 25 + 1000).ToString();
                        HF_Totalamount.Value = (15 + 15 + Convert.ToInt32(count) * 5 + 25 + 1000).ToString();
                    }
                    else
                    {
                        lblTransferFees.Text = "Rs. 15";
                        HF_transferFees.Value = "15";
                        lblRenewalFees.Text = "Rs. 30";
                        HF_RenewalFees.Value = "30";
                        lbllateFees.Text = "Rs." + (Convert.ToInt32(count) * 5).ToString();
                        HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
                        lblrestablishmentCharge.Text = "Rs. 25";
                        HF_ReEstabilishmentFees.Value = "25";
                        lblServiceFees.Text = "Rs. 2000";
                        HF_ServiceChagre.Value = "2000";
                        lblTotalAmount.Text = "Rs." + (15 + 30 + Convert.ToInt32(count) * 5 + 25 +  2000).ToString();
                        HF_Totalamount.Value = (15 + 30 + Convert.ToInt32(count) * 5 + 25 + 2000).ToString();
                    }

                    //HF_Ok.Value = "1";
                    lblMSgAlert.Text = "Your registration is expired";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key2", "PopTemAndConditionTrans();", true);

                }
                else
                {
                    lblTransferFees.Text = "Rs. 15";
                    HF_transferFees.Value = "15";
                    lblRenewalFees.Text = "Rs. 0";
                    HF_RenewalFees.Value = "0";
                    lbllateFees.Text = "Rs. 0";
                    HF_LateFees.Value = "0";
                    lblrestablishmentCharge.Text = "Rs. 0";
                    HF_ReEstabilishmentFees.Value = "0";
                    lblServiceFees.Text = "Rs. 0";
                    HF_ServiceChagre.Value = "0";
                    lblTotalAmount.Text = "Rs. 15";
                    HF_Totalamount.Value = "15";

                    HF_Ok.Value = "1";
                    lblMSgAlert.Text = "Registration no. '" + txtRegNo.Text + "' valid upto '" + Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy") + "' ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key2", "PopTemAndConditionTrans();", true);
                    //return;
                }
            }

            hf_regno.Value = ds.Tables[0].Rows[0]["RegiNo"].ToString();
            txtRegNo.Enabled = false;
            txtRegNo.Text = ds.Tables[0].Rows[0]["RegiNo"].ToString();
            //txtRegDate.Text = ds.Tables[0].Rows[0]["RegiDate"].ToString();
            txtFName.Text = ds.Tables[0].Rows[0]["FName"].ToString();
            txtMName.Text = ds.Tables[0].Rows[0]["MName"].ToString();
            txtLastName.Text = ds.Tables[0].Rows[0]["LName"].ToString();
            txtFatherName.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
            lblAmount.Text = HF_Totalamount.Value;
            txtDOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]).ToString("dd/MM/yyyy");
            try
            {
                ddlGender.ClearSelection();
                ddlGender.Items.FindByText(ds.Tables[0].Rows[0]["Gender"].ToString()).Selected = true;
            }
            catch { }

            try
            {
                ddlPresentOcc.ClearSelection();
                ddlPresentOcc.Items.FindByValue(ds.Tables[0].Rows[0]["PresentOccuption"].ToString()).Selected = true;
            }
            catch { }
            try
            {

                ddlorg.ClearSelection();
                ddlorg.Items.FindByValue(ds.Tables[0].Rows[0]["OrganizationId"].ToString()).Selected = true;
                string org = ddlorg.SelectedItem.Text;
                if (org == "Other")
                {
                    txtOrg.Text = ds.Tables[0].Rows[0]["OrganizationText"].ToString();
                }
            }
            catch { }
            try
            {
                if (ddlorg.SelectedIndex > 0)
                {
                    ddlorg_SelectedIndexChanged(sender, e);
                    ddldept.ClearSelection();
                    ddldept.Items.FindByValue(ds.Tables[0].Rows[0]["DepartmentId"].ToString()).Selected = true;
                    string dpt = ddldept.SelectedItem.Text;
                    if (dpt == "Other")
                    {
                        txtDept.Text = ds.Tables[0].Rows[0]["DepartmentText"].ToString();
                    }
                }
            }
            catch { }
            try
            {
                if (ddldept.SelectedIndex > 0)
                {
                    ddldept_SelectedIndexChanged(sender, e);
                    ddldesig.ClearSelection();
                    ddldesig.Items.FindByValue(ds.Tables[0].Rows[0]["Designationid"].ToString()).Selected = true;
                    string des = ddldesig.SelectedItem.Text;
                    if (des == "Other")
                    {
                        txtDesig.Text = ds.Tables[0].Rows[0]["DesignationText"].ToString();
                    }
                }
            }
            catch
            { }
            string[] landline = new string[2];
            landline = ds.Tables[0].Rows[0]["PhoneNo"].ToString().Split("-".ToCharArray());
            if (landline.Length > 1)
            {
                txtSTDcode.Text = landline[0];
                txtPreffPhoneNo.Text = landline[1];
            }
            try
            {
                ddlPreffAddress.ClearSelection();
                ddlPreffAddress.Items.FindByValue(ds.Tables[0].Rows[0]["PreferedAdd"].ToString()).Selected = true;
            }
            catch { }

            txtMobileNo1.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
            txtMobileNo2.Text = ds.Tables[0].Rows[0]["MobileNo2"].ToString();        
            string[] faxLine = new string[2];
            faxLine = ds.Tables[0].Rows[0]["Fax"].ToString().Split("-".ToCharArray());
            if (faxLine.Length > 1)
            {
                txtStdFaxCode.Text = faxLine[0];
                txtFaxNo.Text = faxLine[1];
            }
            txtEmailId.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
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
                ddlTransferState.ClearSelection();
                ddlTransferState.Items.FindByValue(ds.Tables[0].Rows[0]["Transferstateid"].ToString()).Selected = true;
            }
            catch { }
            if (Request.QueryString["editTransfer"] != null)
            {
                txtcheque.Text = ds.Tables[1].Rows[0]["ChequeNo"].ToString();
                txtbank.Text = ds.Tables[1].Rows[0]["BankName"].ToString();
                txtPaymentDate.Text = Convert.ToDateTime(ds.Tables[1].Rows[0]["ChequeDate"]).ToString("dd/MM/yyyy");

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
            }
            else
            {
                rboffline.Checked = true;
            }
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
