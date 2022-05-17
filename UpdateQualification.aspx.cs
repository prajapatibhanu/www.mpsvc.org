using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateQualification : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    DataSecurity Isecrity = new DataSecurity();
    APIProcedure objdb = new APIProcedure(); string path2, path3, path4;
    string mbNo = "";
    string SendOTP = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnUpdate.Enabled = false;
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
                ddl1.Items.Insert(0, LiItem1);

                ddl2.DataTextField = "UniversityName";
                ddl2.DataValueField = "id";
                ddl2.DataSource = dd1.Tables[0];
                ddl2.DataBind();
                ListItem LiItem2 = new ListItem();
                LiItem2.Text = "Select";
                LiItem2.Value = "0";
                ddl2.Items.Insert(0, LiItem2);

                ddl3.DataTextField = "UniversityName";
                ddl3.DataValueField = "id";
                ddl3.DataSource = dd1.Tables[0];
                ddl3.DataBind();
                ListItem LiItem3 = new ListItem();
                LiItem3.Text = "Select";
                LiItem3.Value = "0";
                ddl3.Items.Insert(0, LiItem3);

                ddl4.DataTextField = "UniversityName";
                ddl4.DataValueField = "id";
                ddl4.DataSource = dd1.Tables[0];
                ddl4.DataBind();
                ListItem LiItem4 = new ListItem();
                LiItem4.Text = "Select";
                LiItem4.Value = "0";
                ddl4.Items.Insert(0, LiItem4);
            }
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
            btnUpdate.Text = "Save";
            fnOtherPassingYear();
        }
    }

    public void FieldFill(object sender, EventArgs e)
    {
        string chkCancel = "";
        try
        {
            if (Request.QueryString["editDuplicate"] != null)
            {
                ds = objdb.ByDataSet("select * from tblNewRegistration where id ='" + Request.QueryString["editDuplicate"].ToString() + "'");
            }
            else
            {
                if (txtSearchRegistrationNo.Text.Trim() != "")
                {
                    ds = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + txtSearchRegistrationNo.Text + "' and ApplicationRequestId <> 7 and ApplicationRequestId <> 8");
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
                //if (chkCancel != "6" || ds.Tables[0].Rows[0]["RegistrationStatus"].ToString() != "1")
                //{
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
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(string), "fnRpt", "alert('You registration is in process');", true);
                //}
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Invalid registration no.";
            }


        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }
    }
    public DataSet StateFill()
    {
        return objdb.ByProcedure("ProcStateFill", "BYdataset");
    }
    protected void fnOtherPassingYear()
    {
        int Year = DateTime.Now.Year;

        ListItem LiItemPY1 = new ListItem();
        LiItemPY1.Text = "Select";
        LiItemPY1.Value = "0";


        // Start Add Passing Year on 14-03-2022 by bhanu
        ddlY1.Items.Insert(0, "2024-25");
        ddlY2.Items.Insert(0, "2024-25");
        ddlY3.Items.Insert(0, "2024-25");
        ddlY4.Items.Insert(0, "2024-25");

        ddlY1.Items.Insert(0, "2023-24");
        ddlY2.Items.Insert(0, "2023-24");
        ddlY3.Items.Insert(0, "2023-24");
        ddlY4.Items.Insert(0, "2023-24");

        ddlY1.Items.Insert(0, "2022-23");
        ddlY2.Items.Insert(0, "2022-23");
        ddlY3.Items.Insert(0, "2022-23");
        ddlY4.Items.Insert(0, "2022-23");

        ddlY1.Items.Insert(0, "2021-22");
        ddlY2.Items.Insert(0, "2021-22");
        ddlY3.Items.Insert(0, "2021-22");
        ddlY4.Items.Insert(0, "2021-22");


        ddlY1.Items.Insert(0, "2020-21");
        ddlY2.Items.Insert(0, "2020-21");
        ddlY3.Items.Insert(0, "2020-21");
        ddlY4.Items.Insert(0, "2020-21");

        ddlY1.Items.Insert(0, "2019-20");
        ddlY2.Items.Insert(0, "2019-20");
        ddlY3.Items.Insert(0, "2019-20");
        ddlY4.Items.Insert(0, "2019-20");

        ddlY1.Items.Insert(0, "2018-19");
        ddlY2.Items.Insert(0, "2018-19");
        ddlY3.Items.Insert(0, "2018-19");
        ddlY4.Items.Insert(0, "2018-19");


        ddlY1.Items.Insert(0, "2017-18");
        ddlY2.Items.Insert(0, "2017-18");
        ddlY3.Items.Insert(0, "2017-18");
        ddlY4.Items.Insert(0, "2017-18");
        // End Add Passing Year on 14-03-2022 by bhanu

        ddlY1.Items.Insert(0, "2016-17");
        ddlY2.Items.Insert(0, "2016-17");
        ddlY3.Items.Insert(0, "2016-17");
        ddlY4.Items.Insert(0, "2016-17");

        ddlY1.Items.Insert(0, "2015-16");
        ddlY2.Items.Insert(0, "2015-16");
        ddlY3.Items.Insert(0, "2015-16");
        ddlY4.Items.Insert(0, "2015-16");

        ddlY1.Items.Insert(0, "2014-15");
        ddlY2.Items.Insert(0, "2014-15");
        ddlY3.Items.Insert(0, "2014-15");
        ddlY4.Items.Insert(0, "2014-15");

        ddlY1.Items.Insert(0, "2013-14");
        ddlY2.Items.Insert(0, "2013-14");
        ddlY3.Items.Insert(0, "2013-14");
        ddlY4.Items.Insert(0, "2013-14");

        ddlY1.Items.Insert(0, "2012-13");
        ddlY2.Items.Insert(0, "2012-13");
        ddlY3.Items.Insert(0, "2012-13");
        ddlY4.Items.Insert(0, "2012-13");

        ddlY1.Items.Insert(0, "2011-12");
        ddlY2.Items.Insert(0, "2011-12");
        ddlY3.Items.Insert(0, "2011-12");
        ddlY4.Items.Insert(0, "2011-12");

        ddlY1.Items.Insert(0, "2010-11");
        ddlY2.Items.Insert(0, "2010-11");
        ddlY3.Items.Insert(0, "2010-11");
        ddlY4.Items.Insert(0, "2010-11");

        ddlY1.Items.Insert(0, "2009-10");
        ddlY2.Items.Insert(0, "2009-10");
        ddlY3.Items.Insert(0, "2009-10");
        ddlY4.Items.Insert(0, "2009-10");

        ddlY1.Items.Insert(0, "2008-09");
        ddlY2.Items.Insert(0, "2008-09");
        ddlY3.Items.Insert(0, "2008-09");
        ddlY4.Items.Insert(0, "2008-09");

        ddlY1.Items.Insert(0, "2007-08");
        ddlY2.Items.Insert(0, "2007-08");
        ddlY3.Items.Insert(0, "2007-08");
        ddlY4.Items.Insert(0, "2007-08");

        ddlY1.Items.Insert(0, "2006-07");
        ddlY2.Items.Insert(0, "2006-07");
        ddlY3.Items.Insert(0, "2006-07");
        ddlY4.Items.Insert(0, "2006-07");

        ddlY1.Items.Insert(0, "2005-06");
        ddlY2.Items.Insert(0, "2005-06");
        ddlY3.Items.Insert(0, "2005-06");
        ddlY4.Items.Insert(0, "2005-06");

        ddlY1.Items.Insert(0, "2004-05");
        ddlY2.Items.Insert(0, "2004-05");
        ddlY3.Items.Insert(0, "2004-05");
        ddlY4.Items.Insert(0, "2004-05");

        ddlY1.Items.Insert(0, "2003-04");
        ddlY2.Items.Insert(0, "2003-04");
        ddlY3.Items.Insert(0, "2003-04");
        ddlY4.Items.Insert(0, "2003-04");

        ddlY1.Items.Insert(0, "2002-03");
        ddlY2.Items.Insert(0, "2002-03");
        ddlY3.Items.Insert(0, "2002-03");
        ddlY4.Items.Insert(0, "2002-03");

        ddlY1.Items.Insert(0, "2001-02");
        ddlY2.Items.Insert(0, "2001-02");
        ddlY3.Items.Insert(0, "2001-02");
        ddlY4.Items.Insert(0, "2001-02");

        ddlY1.Items.Insert(0, "2000-01");
        ddlY2.Items.Insert(0, "2000-01");
        ddlY3.Items.Insert(0, "2000-01");
        ddlY4.Items.Insert(0, "2000-01");

        ddlY1.Items.Insert(0, "1999-2000");
        ddlY2.Items.Insert(0, "1999-2000");
        ddlY3.Items.Insert(0, "1999-2000");
        ddlY4.Items.Insert(0, "1999-2000");

        ddlY1.Items.Insert(0, "1998-99");
        ddlY2.Items.Insert(0, "1998-99");
        ddlY3.Items.Insert(0, "1998-99");
        ddlY4.Items.Insert(0, "1998-99");

        ddlY1.Items.Insert(0, "1997-98");
        ddlY2.Items.Insert(0, "1997-98");
        ddlY3.Items.Insert(0, "1997-98");
        ddlY4.Items.Insert(0, "1997-98");

        ddlY1.Items.Insert(0, "1996-97");
        ddlY2.Items.Insert(0, "1996-97");
        ddlY3.Items.Insert(0, "1996-97");
        ddlY4.Items.Insert(0, "1996-97");

        ddlY1.Items.Insert(0, "1995-96");
        ddlY2.Items.Insert(0, "1995-96");
        ddlY3.Items.Insert(0, "1995-96");
        ddlY4.Items.Insert(0, "1995-96");

        ddlY1.Items.Insert(0, "1994-95");
        ddlY2.Items.Insert(0, "1994-95");
        ddlY3.Items.Insert(0, "1994-95");
        ddlY4.Items.Insert(0, "1994-95");

        ddlY1.Items.Insert(0, "1993-94");
        ddlY2.Items.Insert(0, "1993-94");
        ddlY3.Items.Insert(0, "1993-94");
        ddlY4.Items.Insert(0, "1993-94");

        ddlY1.Items.Insert(0, "1992-93");
        ddlY2.Items.Insert(0, "1992-93");
        ddlY3.Items.Insert(0, "1992-93");
        ddlY4.Items.Insert(0, "1992-93");

        ddlY1.Items.Insert(0, "1991-92");
        ddlY2.Items.Insert(0, "1991-92");
        ddlY3.Items.Insert(0, "1991-92");
        ddlY4.Items.Insert(0, "1991-92");

        ddlY1.Items.Insert(0, "1990-91");
        ddlY2.Items.Insert(0, "1990-91");
        ddlY3.Items.Insert(0, "1990-91");
        ddlY4.Items.Insert(0, "1990-91");

        ddlY1.Items.Insert(0, "1989-90");
        ddlY2.Items.Insert(0, "1989-90");
        ddlY3.Items.Insert(0, "1989-90");
        ddlY4.Items.Insert(0, "1989-90");

        ddlY1.Items.Insert(0, "1988-89");
        ddlY2.Items.Insert(0, "1988-89");
        ddlY3.Items.Insert(0, "1988-89");
        ddlY4.Items.Insert(0, "1988-89");

        ddlY1.Items.Insert(0, "1987-88");
        ddlY2.Items.Insert(0, "1987-88");
        ddlY3.Items.Insert(0, "1987-88");
        ddlY4.Items.Insert(0, "1987-88");

        ddlY1.Items.Insert(0, "1986-87");
        ddlY2.Items.Insert(0, "1986-87");
        ddlY3.Items.Insert(0, "1986-87");
        ddlY4.Items.Insert(0, "1986-87");

        ddlY1.Items.Insert(0, "1985-86");
        ddlY2.Items.Insert(0, "1985-86");
        ddlY3.Items.Insert(0, "1985-86");
        ddlY4.Items.Insert(0, "1985-86");

        ddlY1.Items.Insert(0, "1984-85");
        ddlY2.Items.Insert(0, "1984-85");
        ddlY3.Items.Insert(0, "1984-85");
        ddlY4.Items.Insert(0, "1984-85");

        ddlY1.Items.Insert(0, "1983-84");
        ddlY2.Items.Insert(0, "1983-84");
        ddlY3.Items.Insert(0, "1983-84");
        ddlY4.Items.Insert(0, "1983-84");

        ddlY1.Items.Insert(0, "1982-83");
        ddlY2.Items.Insert(0, "1982-83");
        ddlY3.Items.Insert(0, "1982-83");
        ddlY4.Items.Insert(0, "1982-83");

        ddlY1.Items.Insert(0, "1981-82");
        ddlY2.Items.Insert(0, "1981-82");
        ddlY3.Items.Insert(0, "1981-82");
        ddlY4.Items.Insert(0, "1981-82");

        ddlY1.Items.Insert(0, "1980-81");
        ddlY2.Items.Insert(0, "1980-81");
        ddlY3.Items.Insert(0, "1980-81");
        ddlY4.Items.Insert(0, "1980-81");


        ddlY1.Items.Insert(0, LiItemPY1);
        ddlY2.Items.Insert(0, LiItemPY1);
        ddlY3.Items.Insert(0, LiItemPY1);
        ddlY4.Items.Insert(0, LiItemPY1);

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string pNo = txtPreffPhoneNo.Text.Trim();
            string std = txtSTDcode.Text.Trim();
            string PreferedNo = std + "-" + pNo;
            string TempTranId = "";

            string faxNo = txtFaxNo.Text.Trim();
            string stdfaxCode = txtStdFaxCode.Text.Trim();
            string stdFax = stdfaxCode + "-" + faxNo;

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

            DataSet dsApp = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + hf_regno.Value + "'");
            string appno = dsApp.Tables[0].Rows[0]["ApplicationNo"].ToString();

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

                if (FileUpload1.HasFile)
                {
                    file1path = Guid.NewGuid() + "-" + FileUpload1.FileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file1path));
                }
                else
                {
                    file1path = HF_DomicileCert.Value;
                }
                if (FileUpload2.HasFile)
                {
                    file2path = Guid.NewGuid() + "-" + FileUpload2.FileName;
                    FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file2path));
                }
                else
                {
                    file2path = HF_DegreeCert.Value;
                }

                if (FileUpload4.HasFile)
                {
                    file3path = Guid.NewGuid() + "-" + FileUpload4.FileName;
                    FileUpload4.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file3path));
                }
                else
                {
                    file3path = HF_OtherCert.Value;
                }

                if (rboffline.Checked == true)  //If payment details inserted null
                {
                    ds = objdb.ByProcedure("ProcUpdateQualification", new string[] { "RegiNo", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Isonline", "ChequeNo", "BankName", "ChequeDate", "ApplicationRequestId", "RegistrationStatus", "type", "MobileNo2" },
                         new string[] { hf_regno.Value, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedValue.ToString(), ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, isOnline, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), "6", "1", "1", txtMobileNo2.Text }, "dataset");

                    objdb.ByText(@"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                        values('" + appno + "', 6 ,'" + Appdate + "','" + isOnline + "',10,1,'" + txtcheque.Text + "','" + txtbank.Text + "','" + Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd") + "','" + "" + "','" + "" + "', '" + "" + "' ,10,0,0,0,0,0,1,'')");
                }
                else
                {
                    ds = objdb.ByProcedure("ProcUpdateQualification", new string[] { "RegiNo", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Isonline", "ChequeNo", "BankName", "ChequeDate", "ApplicationRequestId", "RegistrationStatus", "type", "MobileNo2" },
                         new string[] { hf_regno.Value, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedValue.ToString(), ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, isOnline, txtcheque.Text, txtbank.Text, Appdate, "6", "1", "1", txtMobileNo2.Text }, "dataset");

                    //                    objdb.ByText(@"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                    //                        values('" + appno + "', 6 ,'" + Appdate + "','" + isOnline + "',10,1,'" + txtcheque.Text + "','" + txtbank.Text + "','" + txtPaymentDate.Text + "','" + "" + "','" + "" + "', '" + "" + "' ,10,0,0,0,0,0,0,'')");
                    string str1 = @"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                        values('" + appno + "', 6 ,'" + Appdate + "','" + isOnline + "',10,1,'" + txtcheque.Text + "','" + txtbank.Text + "','" + txtPaymentDate.Text + "','" + "" + "','" + "" + "', '" + "" + "' ,10,0,0,0,0,0,1,'')";

                    DataSet dsNew = objdb.ByProcedure("InsertTempTransction", new string[] { "ApplicationNo", "TblMaster", "TblTran" }, new string[] { appno, str1, "" }, "dataset");
                    TempTranId = dsNew.Tables[0].Rows[0]["id"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Msg"].ToString() == "Ok")
                {
                    if (Request.QueryString["editDuplicate"] != null)
                    {
                        //string body = "";
                        //string mbMessage = "";
                        //DataSet dsSentMail = objdb.ByDataSet("Select * from tblNewRegistration where RegiNo='" + hf_regno.Value + "' ");
                        //if (rbmobileprefered == "1")
                        //{
                        //    mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo"].ToString();
                        //}
                        //else
                        //{
                        //    mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo2"].ToString();
                        //}
                        //string mail = dsSentMail.Tables[0].Rows[0]["EmailId"].ToString();
                        //string subject = "MPSVC Verification Mail";
                        //string AppReqId = dsSentMail.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
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

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true);
                        obCommonFuction.EmptyTextBoxes(this);
                        Response.Redirect("AdminSection/ActionRegistration.aspx");
                    }
                    else
                    {
                        if (rboffline.Checked == true)
                        {
                            DataSet dsSentMail = objdb.ByDataSet("Select * from tblNewRegistration where RegiNo='" + hf_regno.Value + "' ");
                            string mail = dsSentMail.Tables[0].Rows[0]["EmailId"].ToString();
                            if (rbmobileprefered == "1")
                            {
                                mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo"].ToString();
                            }
                            else
                            {
                                mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo2"].ToString();
                            }
                            string subject = "MPSVC Registration Mail";
                            string AppReqId = dsSentMail.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
                            string body = objdb.CreateEmailBody(6, hf_regno.Value);
                            string mbMessage = objdb.CreateMessageBody(6, hf_regno.Value); // Message Body Function

                            objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true);
                            obCommonFuction.EmptyTextBoxes(this);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true);

                            RedirectonPaymentGatewayPage("6", appno, TempTranId);

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
        else
        {
            ddlc1.Items.Clear();
        }
    }
    protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl2.SelectedIndex > 0)
        {
            DataSet dd3 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl2.SelectedValue + "");
            if (dd3.Tables[0].Rows.Count > 0)
            {
                ddlc2.DataTextField = "CollegeName";
                ddlc2.DataValueField = "id";
                ddlc2.DataSource = dd3.Tables[0];
                ddlc2.DataBind();
                ListItem LiItemc2 = new ListItem();
                LiItemc2.Text = "Select";
                LiItemc2.Value = "0";
                ddlc2.Items.Insert(0, LiItemc2);
                ddl2.Focus();
            }
        }
        else
        {
            ddlc2.Items.Clear();
        }
    }
    protected void ddl3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl3.SelectedIndex > 0)
        {
            DataSet dd33 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl3.SelectedValue + "");
            if (dd33.Tables[0].Rows.Count > 0)
            {
                ddlc3.DataTextField = "CollegeName";
                ddlc3.DataValueField = "id";
                ddlc3.DataSource = dd33.Tables[0];
                ddlc3.DataBind();
                ListItem LiItemc3 = new ListItem();
                LiItemc3.Text = "Select";
                LiItemc3.Value = "0";
                ddlc3.Items.Insert(0, LiItemc3);
                ddl3.Focus();
            }
        }
        else
        {
            ddlc3.Items.Clear();
        }
    }
    protected void ddl4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl4.SelectedIndex > 0)
        {
            DataSet dd333 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl4.SelectedValue + "");
            if (dd333.Tables[0].Rows.Count > 0)
            {
                ddlc4.DataTextField = "CollegeName";
                ddlc4.DataValueField = "id";
                ddlc4.DataSource = dd333.Tables[0];
                ddlc4.DataBind();
                ListItem LiItemc4 = new ListItem();
                LiItemc4.Text = "Select";
                LiItemc4.Value = "0";
                ddlc4.Items.Insert(0, LiItemc4);
                ddl4.Focus();
            }
        }
        else
        {
            ddlc4.Items.Clear();
        }
    }
    protected void ddlorg_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlorg.SelectedIndex > 0)
            {
                string ddlOrgName = ddlorg.SelectedItem.Text;
                if (ddlOrgName == "Other")
                {
                    txtOrg.Visible = true;
                }
                else
                {
                    txtOrg.Visible = false;
                }
                DataSet dt1 = objdb.ByDataSet("select * from tbl_Departmentmaster where Organaizationid='" + ddlorg.SelectedValue + "'");
                if (dt1.Tables[0].Rows.Count > 0)
                {
                    ddldept.DataTextField = "DepaertmentName";
                    ddldept.DataValueField = "ID";
                    ddldept.DataSource = dt1.Tables[0];
                    ddldept.DataBind();
                    ddldept.Items.Insert(0, "Select");
                   
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
                DataSet dt3 = objdb.ByDataSet("select * from tbl_Designationmaster where OrganaizationId=" + ddlorg.SelectedValue + " and DepartmentID=" + ddldept.SelectedValue + "");
                if (dt3.Tables[0].Rows.Count > 0)
                {
                    ddldesig.DataTextField = "DesinationName";
                    ddldesig.DataValueField = "ID";
                    ddldesig.DataSource = dt3.Tables[0];
                    ddldesig.DataBind();
                    ddldesig.Items.Insert(0, "Select");          
                }
            }
            else
            {
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
        ds = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + txtSearchRegistrationNo.Text + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            /////////
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
                    //HF_Ok.Value = "0";
                    lblMSgAlert.Text = "Registration no. '" + txtSearchRegistrationNo.Text + "' valid upto '" + Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy") + "' ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopTemAndConditionDuplicate();", true);
                    // return;
                }
            }
            hf_regno.Value = ds.Tables[0].Rows[0]["RegiNo"].ToString();
            txtSearchRegistrationNo.Enabled = false;
            txtSearchRegistrationNo.Text = ds.Tables[0].Rows[0]["RegiNo"].ToString();
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
            // txtFaxNo.Text = ds.Tables[0].Rows[0]["Fax"].ToString();

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
                ddlY1.ClearSelection();
                ddlY1.Items.FindByValue(ds.Tables[0].Rows[0]["Year1"].ToString()).Selected = true;
            }
            catch { }
            if (ds.Tables[0].Rows[0]["CollegeID1"].ToString() != "0")
            {
                ddl1.Enabled = false;
                ddlc1.Enabled = false;
                ddlY1.Enabled = false;
            }
            try
            {
                ddl2.ClearSelection();
                ddl2.Items.FindByValue(ds.Tables[0].Rows[0]["University2"].ToString()).Selected = true;
            }
            catch { }
            try
            {
                if (ddl2.SelectedIndex > 0)
                {
                    ddl2_SelectedIndexChanged(sender, e);
                    ddlc2.ClearSelection();
                    ddlc2.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID2"].ToString()).Selected = true;
                }
            }
            catch { }
            try
            {               
                ddlY2.ClearSelection();
                ddlY2.Items.FindByValue(ds.Tables[0].Rows[0]["Year2"].ToString()).Selected = true;
            }
            catch { }
            if (ds.Tables[0].Rows[0]["CollegeID2"].ToString() != "0")
            {
                ddl2.Enabled = false;
                ddlc2.Enabled = false;
                ddlY2.Enabled = false;
                FileUpload1.Enabled = false;
            }
            try
            {
                ddl3.ClearSelection();
                ddl3.Items.FindByValue(ds.Tables[0].Rows[0]["University3"].ToString()).Selected = true;
            }
            catch { }
            try
            {
                if (ddl3.SelectedIndex > 0)
                {
                    ddl3_SelectedIndexChanged(sender, e);
                    ddlc3.ClearSelection();
                    ddlc3.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID3"].ToString()).Selected = true;
                }
            }
            catch { }

            try
            {
                ddlY3.ClearSelection();
                ddlY3.Items.FindByValue(ds.Tables[0].Rows[0]["Year3"].ToString()).Selected = true;
            }
            catch { }
            if (ds.Tables[0].Rows[0]["CollegeID3"].ToString() != "0")
            {
                ddl3.Enabled = false;
                ddlc3.Enabled = false;
                ddlY3.Enabled = false;
                FileUpload2.Enabled = false;
            }
            try
            {
                ddl4.ClearSelection();
                ddl4.Items.FindByValue(ds.Tables[0].Rows[0]["University4"].ToString()).Selected = true;
            }
            catch { }

            try
            {
                if (ddl4.SelectedIndex > 0)
                {
                    ddl4_SelectedIndexChanged(sender, e);
                    ddlc4.ClearSelection();
                    ddlc4.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID4"].ToString()).Selected = true;
                }
            }
            catch { }
            try
            {
                ddlY4.ClearSelection();
                ddlY4.Items.FindByValue(ds.Tables[0].Rows[0]["Year4"].ToString()).Selected = true;
            }
            catch { }

            if (ds.Tables[0].Rows[0]["CollegeID4"].ToString() != "0")
            {
                ddl4.Enabled = false;
                ddlc4.Enabled = false;
                ddlY4.Enabled = false;
                FileUpload4.Enabled = false;
            }

            if (Request.QueryString["editDuplicate"] != null)
            {
                txtcheque.Text = ds.Tables[0].Rows[0]["ChequeNo"].ToString();
                txtbank.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                txtPaymentDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ChequeDate"]).ToString("dd/MM/yyyy");
                string str1 = "";
                str1 = ds.Tables[0].Rows[0]["Isonline"].ToString();
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
            HF_DomicileCert.Value = ds.Tables[0].Rows[0]["File1"].ToString();
            HF_DegreeCert.Value = ds.Tables[0].Rows[0]["File2"].ToString();
            HF_OtherCert.Value = ds.Tables[0].Rows[0]["File3"].ToString();
        }
        else
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Invalid registration no.";
        }
    }
}