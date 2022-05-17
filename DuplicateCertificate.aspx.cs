using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DuplicateCertificate : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    APIProcedure objdb = new APIProcedure(); string path2, path3, path4;
    DataSecurity Isecrity = new DataSecurity();
    string mbNo = "";
    string getReqNO = "";
    string SendOTP = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnUpdate.Enabled = false;
            DateTime myDate = DateTime.Now;
            DateTime backDays = myDate.AddDays(-45);
            HdnDate.Value = Convert.ToDateTime(backDays).ToString("MM/dd/yyyy");     
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
            if (Request.QueryString["editDuplicate"] != null)
            {
                string[] arr = Request.QueryString["editDuplicate"].ToString().Split("*".ToCharArray());
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
                btnUpdate.Text = "Save";
            }

        }
    }

    public void FieldFill(object sender, EventArgs e)
    {
        try
        {
            string chkCancel = "";
            if (Request.QueryString["editDuplicate"] != null)
            {
                string[] arr = Request.QueryString["editDuplicate"].ToString().Split("*".ToCharArray());
                string applicationNo = arr[1];
                string Tid = arr[0];
                ds = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
            }
            else
            {
                if (txtSearchRegistrationNo.Text.Trim() != "")
                {
                    ds = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + txtSearchRegistrationNo.Text + "' and ApplicationRequestId <> 7  and ApplicationRequestId <> 8");
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
                }
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
                }
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
        Response.Redirect("RegistrationLink.html");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSearchRegistrationNo.Text != "")
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
            DataSet dsDetails = new DataSet();
            string amount = "";
            string Tid = "";
            string editApplicationNo = "";
            string applicationno = "";
            string TempTranId = "";
            string pNo = txtPreffPhoneNo.Text.Trim();
            string std = txtSTDcode.Text.Trim();
            string PreferedNo = std + "-" + pNo;

            string faxNo = txtFaxNo.Text.Trim();
            string stdfaxCode = txtStdFaxCode.Text.Trim();
            string stdFax = stdfaxCode + "-" + faxNo;

            string getRequestId = "";
            if (ddlRequest.SelectedValue == "1")
            {
                getRequestId = "4"; // Duplicate Id card
               // amount = "550";
                amount = "50";
            }
            else
            {
                getRequestId = "5"; // Duplicate Certificate 
                amount = "510";
            }
            string FileName = "";
            string file1path = "";
            string file2path = "";
            string file3path = "";
            string file4path = "";
            string file5path = "";
            string isOnline = "";
            string rbmobileprefered = "";

            if (rbmobile1.Checked == true)
            {
                rbmobileprefered = "1";
            }
            else
            {
                rbmobileprefered = "0";
            }
            if (Request.QueryString["editDuplicate"] != null)
            {
                string[] arr = Request.QueryString["editDuplicate"].ToString().Split("*".ToCharArray());
                string applicationNo = arr[1];
                Tid = arr[0];
                dsDetails = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
                editApplicationNo = dsDetails.Tables[1].Rows[0]["ApplicationNo"].ToString();
            }
            else
            {
                DataSet dsApplication = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + hf_regno.Value + "'");
                applicationno = dsApplication.Tables[0].Rows[0]["ApplicationNo"].ToString();
            }
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
                if (Request.QueryString["editDuplicate"] != null)
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
                if (Request.QueryString["editDuplicate"] != null)
                {
                    if (rboffline.Checked == true)  //If payment details inserted null
                    {
                        ds = objdb.ByProcedure("ProcDuplicateRegistration", new string[] { "RegiNo", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "Isonline", "ChequeNo", "BankName", "ChequeDate", "ApplicationRequestId", "RegistrationStatus", "type", "MobileNo2" },
                             new string[] { hf_regno.Value, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedValue.ToString(), ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, isOnline, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), getRequestId, regStatus, "1", txtMobileNo2.Text }, "dataset");
                    }
                    else
                    {
                        ds = objdb.ByProcedure("ProcDuplicateRegistration", new string[] { "RegiNo", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "Isonline", "ChequeNo", "BankName", "ChequeDate", "ApplicationRequestId", "RegistrationStatus", "type", "MobileNo2" },
                             new string[] { hf_regno.Value, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedValue.ToString(), ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, isOnline, txtcheque.Text, txtbank.Text, Appdate, getRequestId, regStatus, "1", txtMobileNo2.Text }, "dataset");
                    }
                    objdb.ByText(@"Update tbl_Transactiondetails set RegistrationStatus = '" + regStatus + "' where id ='" + Tid + "'");
                }
                else
                {
                    if (rboffline.Checked == true)  //If payment details inserted null
                    {
                        ds = objdb.ByProcedure("ProcDuplicateRegistration", new string[] { "RegiNo", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "Isonline", "ChequeNo", "BankName", "ChequeDate", "ApplicationRequestId", "RegistrationStatus", "type", "MobileNo2" },
                             new string[] { hf_regno.Value, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedValue.ToString(), ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, isOnline, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), getRequestId, regStatus, "1", txtMobileNo2.Text }, "dataset");

                        objdb.ByText(@"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus,ChequeNo,BankName,ChequeDate,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                        values('" + applicationno + "', '" + getRequestId + "','" + Appdate + "','" + isOnline + "','" + amount + "',1,'" + txtcheque.Text + "','" + txtbank.Text + "','" + Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd") + "','" + amount + "',0,15,0,0,0,1,'')");
                    }
                    else
                    {
                        ds = objdb.ByProcedure("ProcDuplicateRegistration", new string[] { "RegiNo", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "Isonline", "ChequeNo", "BankName", "ChequeDate", "ApplicationRequestId", "RegistrationStatus", "type", "MobileNo2" },
                             new string[] { hf_regno.Value, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedValue.ToString(), ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, isOnline, txtcheque.Text, txtbank.Text, Appdate, getRequestId, regStatus, "1", txtMobileNo2.Text }, "dataset");
//                        objdb.ByText(@"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus,ChequeNo,BankName,ChequeDate,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
//                        values('" + applicationno + "', '" + getRequestId + "','" + Appdate + "','" + isOnline + "','" + amount + "',1,'" + txtcheque.Text + "','" + txtbank.Text + "','" + txtPaymentDate.Text + "','" + amount + "',0,15,0,0,0,0,'')");
                        string str1 = @"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus,ChequeNo,BankName,ChequeDate,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                        values('" + applicationno + "', '" + getRequestId + "','" + Appdate + "','" + isOnline + "','" + amount + "',1,'" + txtcheque.Text + "','" + txtbank.Text + "','" + txtPaymentDate.Text + "','" + amount + "',0,15,0,0,0,1,'')";

                       DataSet  dsNew = objdb.ByProcedure("InsertTempTransction", new string[] { "ApplicationNo", "TblMaster", "TblTran" }, new string[] { applicationno, str1, "" }, "dataset");
                       TempTranId = dsNew.Tables[0].Rows[0]["id"].ToString();
                    
                    }
                }           
                if (ds.Tables[0].Rows[0]["Msg"].ToString() == "Ok")
                {
                    if (Request.QueryString["editDuplicate"] != null)
                    {
                        if (regStatus == "3")
                        {
                            //string body = "";
                            //string mbMessage = "";
                            DataSet dsSentMail = objdb.ByDataSet("Select * from tblNewRegistration where RegiNo='" + hf_regno.Value + "' ");
                            //if (rbmobileprefered == "1")
                            //{
                            //    mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo"].ToString();
                            //}
                            //else
                            //{
                            //    mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo2"].ToString();
                            //}
                            string regno = dsSentMail.Tables[0].Rows[0]["RegiNo"].ToString();
                            string val = getDate(dsSentMail.Tables[0].Rows[0]["Validupto"].ToString());
                            //string appno = dsDetails.Tables[1].Rows[0]["ApplicationNo"].ToString();
                            //string mail = dsSentMail.Tables[0].Rows[0]["EmailId"].ToString();
                            //string subject = "MPSVC Verification Mail";
                            //string AppReqId = dsDetails.Tables[1].Rows[0]["ApplicationRequestId"].ToString();
                            //if (AppReqId == "4")
                            //{
                            //    body = objdb.CreateAdminEmailBody(4, hf_regno.Value);
                            //    mbMessage = objdb.CreateAdminMessageBody(4, hf_regno.Value); // Message Body Function
                            //}
                            //else
                            //{
                            //    body = objdb.CreateAdminEmailBody(5, hf_regno.Value);
                            //    mbMessage = objdb.CreateAdminMessageBody(5, hf_regno.Value); // Message Body Function
                            //}
                            //objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.
                            lblMSgAlert.Text = "Registration no. '" + regno + "' verified successfully valid upto '" + val + "' ";
                        }
                        else
                        {
                            lblMSgAlert.Text = "Application forwarded for second level verification.";
                        }
                        HF_Ok.Value = "0";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopTemAndConditionDuplicate();", true);
                        obCommonFuction.EmptyTextBoxes(this);
                    }
                    else
                    {
                        string appno = string.Empty;
                        string AppReqId = "";
                        string body = "";
                        string mbMessage = "";
                        DataSet dsSentMail = objdb.ByDataSet("Select * from tblNewRegistration where RegiNo='" + hf_regno.Value + "' ");
                        if (rbmobileprefered == "1")
                        {
                            mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo"].ToString();
                        }
                        else
                        {
                            mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo2"].ToString();
                        }
                        appno = dsSentMail.Tables[0].Rows[0]["ApplicationNo"].ToString();
                        AppReqId = dsSentMail.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
                        if (rboffline.Checked == true)
                        {
                            string mail = dsSentMail.Tables[0].Rows[0]["EmailId"].ToString();
                            string subject = "MPSVC Registration Mail";
                            
                            if (AppReqId == "4")
                            {
                                body = objdb.CreateEmailBody(4, appno);
                                mbMessage = objdb.CreateMessageBody(4, appno); // Message Body Function
                            }
                            else
                            {
                                body = objdb.CreateEmailBody(5, appno);
                                mbMessage = objdb.CreateMessageBody(5, appno); // Message Body Function
                            }
                            objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true);
                            obCommonFuction.EmptyTextBoxes(this);
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true);
                            RedirectonPaymentGatewayPage(AppReqId, appno, TempTranId);
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

    public DataSet StateFill()
    {
        return objdb.ByProcedure("ProcStateFill", "BYdataset");
    }

    private void FillHiddenCalculation(DataSet ds)
    {
        string ari = ds.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
        if (ari == "4")
        {
            HF_RenewalFees.Value = "0";
            HF_LateFees.Value = "0";
            HF_ReEstabilishmentFees.Value = "0";
           // HF_Totalamount.Value = "550";
            HF_Totalamount.Value = "50";
        }
        else
        {
            HF_RenewalFees.Value = "0";
            HF_LateFees.Value = "0";
            HF_ReEstabilishmentFees.Value = "0";
            HF_Totalamount.Value = "510";
        }
    }
    protected void ddlRequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRequest.SelectedValue == "1")
        {
           // lblAmount.Text = "550";
            lblAmount.Text = "50";
        }
        else
        {
            lblAmount.Text = "510";
        }

    }
    public void RedirectonPaymentGatewayPage(string ApplicationType, string ApplicationNo,string TempID)
    {
        string var = ApplicationNo + "*" + lblAmount.Text + "*" + txtEmailId.Text + "*" + txtMobileNo1.Text + "*" + txtFName.Text + "*" + ApplicationType + "*" + TempID;
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
        if (Request.QueryString["editDuplicate"] != null)
        {
            string[] arr = Request.QueryString["editDuplicate"].ToString().Split("*".ToCharArray());
            string applicationNo = arr[1];
            string Tid = arr[0];
            ds = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
        }
        else
        {
            ds = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + txtSearchRegistrationNo.Text + "'");
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            ////////////
            DateTime Lvalue = DateTime.Now;
            DateTime rValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"].ToString());
            int count = Math.Abs((Lvalue.Month - rValue.Month) + 12 * (Lvalue.Year - rValue.Year));
            if (Request.QueryString["editDuplicate"] == null)
            {
                if (Lvalue > rValue)
                {
                    // HF_Ok.Value = "1";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopTemAndConditionDuplicate();", true);
                    lblMSgAlert.Text = "Your registration is expired";

                }
                else
                {
                    HF_Ok.Value = "1";
                    lblMSgAlert.Text = "Registration no. '" + txtSearchRegistrationNo.Text + "' valid upto '" + Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy") + "' ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopTemAndConditionDuplicate();", true);
                    // return;
                }
            }
            if (Request.QueryString["editDuplicate"] == null)
            {
                string getTotal = "";
                string getAmount = ds.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
                if (getAmount == "4")
                {
                   // getTotal = "550";
                    getTotal = "50";
                }
                else
                {
                    getTotal = "510";
                }
                lblAmount.Text = getTotal;
            }
            else
            {
                string getTotal = "";
                string getAmount = ds.Tables[1].Rows[0]["ApplicationRequestId"].ToString();
                if (getAmount == "4")
                {
                  //  getTotal = "550";
                    getTotal = "50";
                }
                else
                {
                    getTotal = "510";
                }
                lblAmount.Text = getTotal;
            }

            hf_regno.Value = ds.Tables[0].Rows[0]["RegiNo"].ToString();
            txtSearchRegistrationNo.Enabled = false;
            txtSearchRegistrationNo.Text = ds.Tables[0].Rows[0]["RegiNo"].ToString();
            //txtRegDate.Text = ds.Tables[0].Rows[0]["RegiDate"].ToString();
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

            try
            {
                ddlPresentOcc.ClearSelection();
                ddlPresentOcc.Items.FindByText(ds.Tables[0].Rows[0]["PresentOccuption"].ToString()).Selected = true;
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
            catch { }
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
            if (Request.QueryString["editDuplicate"] != null)
            {
                //ddlRequest.ClearSelection();
                string appidr = "";
                //ddlRequest.Items.FindByValue(ds.Tables[0].Rows[0]["ApplicationRequestId"].ToString()).Selected = true;
                appidr = ds.Tables[1].Rows[0]["ApplicationRequestId"].ToString();
                if (appidr == "4")
                {
                    ddlRequest.SelectedValue = "1";
                }
                else
                {
                    ddlRequest.SelectedValue = "2";
                }
            }

            if (Request.QueryString["editDuplicate"] != null)
            {
                txtcheque.Text = ds.Tables[1].Rows[0]["ChequeNo"].ToString();
                txtbank.Text = ds.Tables[1].Rows[0]["BankName"].ToString();
                txtPaymentDate.Text = Convert.ToDateTime(ds.Tables[1].Rows[0]["ChequeDate"]).ToString("dd/MM/yyyy");

                string str1 = "";
                str1 = ds.Tables[1].Rows[0]["Isonline"].ToString();
                if (str1 == "1")
                {
                    rbOnline.Checked = true;
                    rboffline.Checked = false;
                    tr_payment.Visible = false;
                    tr_cheque.Visible = false;
                    tr_Pdate.Visible = false;
                }
                else
                {
                    rboffline.Checked = true;
                    rbOnline.Checked = false;
                }
            }
            else
            {
               
            }
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
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