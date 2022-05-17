using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetIntegrationKit;

public partial class ProvisionalRegistration : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    DataSecurity Isecrity = new DataSecurity();
    APIProcedure objdb = new APIProcedure(); string path2, path3, path4;
    string mbNo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            getResDistrict();
            DateTime myDate = DateTime.Now;
            DateTime backDays = myDate.AddDays(-45);
            HdnDate.Value = Convert.ToDateTime(backDays).ToString("MM/dd/yyyy");
            // FieldFill(sender, e);
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
                ddl1.Items.Insert(0, LiItem1);
                ddl1.SelectedValue = "29";
                ddl1_SelectedIndexChanged(sender, e);
            }
            fnPerState();
            GetCurrentFinancialYear();
        }
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
       // return FinYear.Trim();

        ListItem LiItem1 = new ListItem();
        LiItem1.Text = FinYear;
        LiItem1.Value = FinYear;
        ddlY1.Items.Insert(0, LiItem1);
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
    protected void getResDistrict()
    {
        try
        {
            DataSet dt3 = objdb.ByDataSet("select * from Districts where StateId=" + ddlResState.SelectedValue + "");
            if (dt3.Tables[0].Rows.Count > 0)
            {
                ddlResDistrict.DataTextField = "DistrictName";
                ddlResDistrict.DataValueField = "DistrictId";
                ddlResDistrict.DataSource = dt3.Tables[0];
                ddlResDistrict.DataBind();
                ddlResDistrict.Items.Insert(0, "Select");
            }
        }
        catch { }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
         
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
            //string file4path = "";
            //string file5path = "";
            string isOnline = "";
            string ApplicationNo = "";

            DateTime DteCheck;
            string Appdate = Convert.ToDateTime(DateTime.Now, cult).ToString("yyyy/MM/dd");
            string DOB = "";
            
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

                if (FileUpload1.HasFile)
                {
                    file1path = Guid.NewGuid() + "-" + FileUpload1.FileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file1path));
                }
                if (FileUpload2.HasFile)
                {
                    file2path = Guid.NewGuid() + "-" + FileUpload2.FileName;
                    FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file2path));
                }
                if (FileUpload3.HasFile)
                {
                    file3path = Guid.NewGuid() + "-" + FileUpload3.FileName;
                    FileUpload3.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file3path));
                }
                else
                {
                    file3path = null;
                }

                DataSet dsapp = objdb.ByDataSet(@"select max(ApplicationNo) as ApplicationNo from tblNewRegistration");
                if (dsapp.Tables[0].Rows[0]["ApplicationNo"].ToString() == "")
                {
                    ApplicationNo = "100001";
                }
                else
                {
                    ApplicationNo = (Convert.ToInt64(dsapp.Tables[0].Rows[0]["ApplicationNo"].ToString()) + 1).ToString();
                }

                if (rboffline.Checked == true)  //If payment details  inserted null
                {
                    objdb.ByText(@"insert into tblNewRegistration(ApplicationNo,ApplicationDate,FName,MName,LName,FatherName,DOB,Gender,ResAdd,ResCity,ResDistrict,ResPost,ResTehsil,ResPinCode,ResState,PerAdd,PerCity,PerDistrict,PerPost,PerTehsil,PerPinCode,PerState,PreferedAdd,MobileNo,EmailId,PreferedPhoneNo,RollNo, UniversityEnrollmentNo,University1,CollegeID1,Year1,File1,File2,File3,Isonline,ChequeNo,BankName,ChequeDate,RegistrationStatus,ApplicationRequestId,Validupto,MobileNo2)
                        values('" + ApplicationNo + "','" + Appdate + "','" + txtFName.Text + "','" + txtMName.Text + "','" + txtLastName.Text + "','" + txtFatherName.Text + "','" + Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd") + "','" + ddlGender.SelectedItem.Text + "','" + txtResAdd.Text + "','" + txtResCity.Text + "','" + ddlResDistrict.SelectedItem.Text + "','" + txtResPost.Text + "','" + txtResTehsil.Text + "','" + txtResPinCode.Text + "','" + ddlResState.SelectedValue + "','" + txtPerAdd.Text + "','" + txtPerCity.Text + "','" + ddlPerDistrict.SelectedItem.Text + "','" + txtPerPost.Text + "','" + txtPerTehsil.Text + "','" + txtPerPinCode.Text + "','" + ddlPerState.SelectedValue + "','" + ddlPreffAddress.SelectedValue + "','" + txtMobileNo1.Text + "','" + txtEmailId.Text.Trim() + "','" + rbmobileprefered + "','"+ txtRollNo.Text +"','"+ txtUniversityEnrollNo.Text +"','" + ddl1.SelectedValue + "','" + ddlc1.SelectedValue + "','" + ddlY1.SelectedValue + "','" + file1path + "','" + file2path + "','" + file3path + "','" + isOnline + "','" + txtcheque.Text + "','" + txtbank.Text + "','" + Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd") + "',1,7,'','" + txtMobileNo2.Text + "')");


                    objdb.ByText(@"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                        values('" + ApplicationNo + "', 7 ,'" + Appdate + "','" + isOnline + "',15,1,'" + txtcheque.Text + "','" + txtbank.Text + "','" + Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd") + "',15,0,0,0,0,0,1,'')");

                    DataSet dsSentMail = objdb.ByDataSet("Select * from tblNewRegistration where ApplicationNo='" + ApplicationNo + "'");
                    if (rbmobileprefered == "1")
                    {
                        mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo"].ToString();
                    }
                    else
                    {
                        mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo2"].ToString();
                    }
                    string mail = dsSentMail.Tables[0].Rows[0]["EmailId"].ToString();
                    string subject = "MPSVC Registration Mail";
                    string body = objdb.CreateEmailBody(7, ApplicationNo); //Email body function
                    string mbMessage = objdb.CreateMessageBody(7, ApplicationNo); // Message Body Function

                    objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.

                    lblMsg.Text = objdb.SaveAlert("Application submitted successfully, Please check your email for further details.");
                    obCommonFuction.EmptyTextBoxes(this);
                }
                else // If Payment details inserted
                {
                    objdb.ByText(@"insert into tblNewRegistration(ApplicationNo,ApplicationDate,FName,MName,LName,FatherName,DOB,Gender,ResAdd,ResCity,ResDistrict,ResPost,ResTehsil,ResPinCode,ResState,PerAdd,PerCity,PerDistrict,PerPost,PerTehsil,PerPinCode,PerState,PreferedAdd,MobileNo,EmailId,PreferedPhoneNo,RollNo, UniversityEnrollmentNo,University1,CollegeID1,Year1,File1,File2,File3,Isonline,ChequeNo,BankName,ChequeDate,RegistrationStatus,ApplicationRequestId,Validupto,MobileNo2)
                        values('" + ApplicationNo + "','" + Appdate + "','" + txtFName.Text + "','" + txtMName.Text + "','" + txtLastName.Text + "','" + txtFatherName.Text + "','" + Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd") + "','" + ddlGender.SelectedItem.Text + "','" + txtResAdd.Text + "','" + txtResCity.Text + "','" + ddlResDistrict.SelectedItem.Text + "','" + txtResPost.Text + "','" + txtResTehsil.Text + "','" + txtResPinCode.Text + "','" + ddlResState.SelectedValue + "','" + txtPerAdd.Text + "','" + txtPerCity.Text + "','" + ddlPerDistrict.SelectedItem.Text + "','" + txtPerPost.Text + "','" + txtPerTehsil.Text + "','" + txtPerPinCode.Text + "','" + ddlPerState.SelectedValue + "','" + ddlPreffAddress.SelectedValue + "','" + txtMobileNo1.Text + "','" + txtEmailId.Text.Trim() + "','" + rbmobileprefered + "','" + txtRollNo.Text + "','" + txtUniversityEnrollNo.Text + "','" + ddl1.SelectedValue + "','" + ddlc1.SelectedValue + "','" + ddlY1.SelectedValue + "','" + file1path + "','" + file2path + "','" + file3path + "','" + isOnline + "','" + txtcheque.Text + "','" + txtbank.Text + "','" + txtPaymentDate.Text + "',1,7,'','" + txtMobileNo2.Text + "')");

                    string str1 = @"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                        values('" + ApplicationNo + "', 7 ,'" + Appdate + "','" + isOnline + "',15,1,'" + txtcheque.Text + "','" + txtbank.Text + "','" + Appdate + "',15,0,0,0,0,0,0,'')";

                    ds = objdb.ByProcedure("InsertTempTransction", new string[] { "ApplicationNo", "TblMaster", "TblTran" }, new string[] { ApplicationNo, str1, "" }, "dataset");
                    string TempTranId = ds.Tables[0].Rows[0]["id"].ToString();

                    lblMsg.Text = objdb.SaveAlert("Application submitted successfully, Please check your email for further details.");
                    RedirectonPaymentGatewayPage("7", ApplicationNo, TempTranId);
                }
            }
        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }
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
                //txtPerTown.Text = "";
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
    public void RedirectonPaymentGatewayPage(string ApplicationType, string ApplicationNo,string TempId)
    {
        string var = ApplicationNo + "*" + lblAmount.Text + "*" + txtEmailId.Text + "*" + txtMobileNo1.Text + "*" + txtFName.Text + "*" + ApplicationType + "*" + TempId;
        string EncryptedStr = Isecrity.Encrypt(var);
        obCommonFuction.EmptyTextBoxes(this);
        Response.Redirect("~/frmRequest.aspx?TRequest=" + Server.UrlEncode(EncryptedStr));
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
            else {
                ddlPerDistrict.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
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
}