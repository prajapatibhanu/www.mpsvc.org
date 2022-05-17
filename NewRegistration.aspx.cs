using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetIntegrationKit;
using System.Security;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Web;
public partial class AdminSection_NewRegistration : System.Web.UI.Page
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
            Session["Query"] = "";
            getResDistrict();
            getProDistrict();
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
            fnPerState();
            fnOtherPassingYear();
        }
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
            DataSet dt3 = objdb.ByDataSet("select * from Districts where StateId=" + ddlResState.SelectedValue + " order by DistrictName");
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
    protected void getProDistrict()
    {
        try
        {
            DataSet dt3 = objdb.ByDataSet("select * from Districts where StateId=" + ddlProState.SelectedValue + " order by DistrictName");
            if (dt3.Tables[0].Rows.Count > 0)
            {
                ddlProDistrict.DataTextField = "DistrictName";
                ddlProDistrict.DataValueField = "DistrictId";
                ddlProDistrict.DataSource = dt3.Tables[0];
                ddlProDistrict.DataBind();
                ddlProDistrict.Items.Insert(0, "Select");
            }
        }
        catch { }
    }
    protected void fnOtherPassingYear()
    {
        int Year = DateTime.Now.Year;

        ListItem LiItemPY1 = new ListItem();
        LiItemPY1.Text = "Select";
        LiItemPY1.Value = "0";

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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
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

            string FileName = "";
            string noc_Upload = "";
            string file1path = "";
            string file2path = "";
            string file3path = "";
            string file4path = "";
            string file5path = "";
            string isOnline = "";
            string ApplicationNo = "";
            string Appdate = Convert.ToDateTime(DateTime.Now, cult).ToString("yyyy/MM/dd");
            string NocRegDate = Convert.ToDateTime(DateTime.Now, cult).ToString("yyyy/MM/dd");
            //string Dob = Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd");
            //string Degree = Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd");           
            //string Payment = Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd");
            string NOC =""; 
            DateTime DteCheck;
           
            string DOB = "", RegDate = "";
           
            if (txtNocDate.Text != "")
            {
                NOC = Convert.ToDateTime(txtNocDate.Text, cult).ToString("yyyy/MM/dd");
            }
            else
            {
                NOC = "";
            }

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
            else if (RegDate != "")
            {
                lblMsg.Text = objdb.ErrorAlert("Please enter correct Registration Date.");
            }
            else
            {
                if (Request.QueryString["Id"] != null)
                {
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
                    if (FU_NocCetificate.HasFile)
                    {
                        noc_Upload = Guid.NewGuid() + "-" + FU_NocCetificate.FileName;
                        FU_NocCetificate.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + noc_Upload));
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
                    if (FileUpload4.HasFile)
                    {
                        file4path = Guid.NewGuid() + "-" + FileUpload4.FileName;
                        FileUpload4.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file4path));
                    }
                    else
                    {
                        file4path = null;
                    }
                    if (FileUpload5.HasFile)
                    {
                        file5path = Guid.NewGuid() + "-" + FileUpload5.FileName;
                        FileUpload5.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file5path));
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
                    if (chkNocDetails.Checked == true) // If Noc details inserted by user
                    {
                        if (rboffline.Checked == true)  //If payment details  inserted null
                        {
                            objdb.ByText(@"insert into tblNewRegistration(ApplicationNo,ApplicationDate,RegiNo,RegiDate,FName,MName,LName,FatherName,DOB,Gender,PresentOccuption,OrganizationId,OrganizationText,DepartmentId,DepartmentText,Designationid,DesignationText,ResAdd,ResCity,ResDistrict,ResTown,ResPost,ResTehsil,ResPinCode,ResState,ProAdd,ProCity,ProDistrict,ProTown,ProPost,ProTehsil,ProPinCode,ProState,PerAdd,PerCity,PerDistrict,PerTown,PerPost,PerTehsil,PerPinCode,PerState,PhoneNo,PreferedAdd,MobileNo,Fax,EmailId,PreferedPhoneNo,University1,University2,University3,University4,CollegeID1,CollegeID2,CollegeID3,CollegeID4,Year1,Year2,Year3,Year4,File1,File2,File3,File4,File5,DegreeDate,DegreeId,Isonline,ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,NocCertificate,RegistrationStatus,CertificatePath,ApplicationRequestId,Validupto,MobileNo2)
                        values('" + ApplicationNo + "','" + Appdate + "','','" + Convert.ToDateTime(txtRegistrationDate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtFName.Text + "','" + txtMName.Text + "','" + txtLastName.Text + "','" + txtFatherName.Text + "','" + Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd") + "','" + ddlGender.SelectedItem.Text + "','" + ddlPresentOcc.SelectedItem.Text + "','" + ddlorg.SelectedValue + "','" + txtOrg.Text + "','" + ddldept.SelectedValue + "','" + txtDept.Text + "','" + ddldesig.SelectedValue + "','" + txtDesig.Text + "','" + txtResAdd.Text + "','" + txtResCity.Text + "','" + ddlResDistrict.SelectedItem.Text + "','" + "" + "','" + txtResPost.Text + "','" + txtResTehsil.Text + "','" + txtResPinCode.Text + "','" + ddlResState.SelectedValue + "','" + txtProAdd.Text + "','" + txtProCity.Text + "','" + ddlProDistrict.SelectedItem.Text + "','" + "" + "','" + txtProPost.Text + "','" + txtProTehsil.Text + "','" + txtProPinCode.Text + "','" + ddlProState.SelectedValue + "','" + txtPerAdd.Text + "','" + txtPerCity.Text + "','" + ddlPerDistrict.SelectedItem.Text + "','" + "" + "','" + txtPerPost.Text + "','" + txtPerTehsil.Text + "','" + txtPerPinCode.Text + "','" + ddlPerState.SelectedValue + "','" + PreferedNo + "','" + ddlPreffAddress.SelectedValue + "','" + txtMobileNo1.Text + "','" + stdFax + "','" + txtEmailId.Text.Trim() + "','" + rbmobileprefered + "','" + ddl1.SelectedValue + "','" + ddl2.SelectedValue + "','" + ddl3.SelectedValue + "','" + ddl4.SelectedValue + "','" + ddlc1.SelectedValue + "','" + ddlc2.SelectedValue + "','" + ddlc3.SelectedValue + "','" + ddlc4.SelectedValue + "','" + ddlY1.SelectedValue + "','" + ddlY2.SelectedValue + "','" + ddlY3.SelectedValue + "','" + ddlY4.SelectedValue + "','" + file1path + "','" + file2path + "','" + file3path + "','" + file4path + "','" + file5path + "','" + Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtDegid.Text + "','" + isOnline + "','" + txtcheque.Text + "','" + txtbank.Text + "','" + Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtNocNumber.Text + "','" + txtNocDate.Text + "','" + txtNocState.Text + "','" + noc_Upload + "',1,'',3,'','" + txtMobileNo2.Text + "')");

                            objdb.ByText(@"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                                            values('" + ApplicationNo + "',3,'" + Appdate + "','" + isOnline + "',2025,1,'" + txtcheque.Text + "','" + txtbank.Text + "','" + Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtNocNumber.Text + "','" + Convert.ToDateTime(txtNocDate.Text, cult).ToString("yyyy/MM/dd") + "', '" + txtNocState.Text + "' ,'25','0','0','2000','0','0', '1', '')");

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
                            string body = objdb.CreateEmailBody(3, ApplicationNo); //Email body function
                            string mbMessage = objdb.CreateMessageBody(3, ApplicationNo); // Message Body Function

                            objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.

                            lblMsg.Text = objdb.SaveAlert("Application submitted successfully, Please check your email for further details.");
                            obCommonFuction.EmptyTextBoxes(this);
                        }
                        else // If Payment details inserted
                        {
                            objdb.ByText(@"insert into tblNewRegistration(ApplicationNo,ApplicationDate,RegiNo,RegiDate,FName,MName,LName,FatherName,DOB,Gender,PresentOccuption,OrganizationId,OrganizationText,DepartmentId,DepartmentText,Designationid,DesignationText,ResAdd,ResCity,ResDistrict,ResTown,ResPost,ResTehsil,ResPinCode,ResState,ProAdd,ProCity,ProDistrict,ProTown,ProPost,ProTehsil,ProPinCode,ProState,PerAdd,PerCity,PerDistrict,PerTown,PerPost,PerTehsil,PerPinCode,PerState,PhoneNo,PreferedAdd,MobileNo,Fax,EmailId,PreferedPhoneNo,University1,University2,University3,University4,CollegeID1,CollegeID2,CollegeID3,CollegeID4,Year1,Year2,Year3,Year4,File1,File2,File3,File4,File5,DegreeDate,DegreeId,Isonline,ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,NocCertificate,RegistrationStatus,CertificatePath,ApplicationRequestId,Validupto,MobileNo2)
                        values('" + ApplicationNo + "','" + Appdate + "','','" + Convert.ToDateTime(txtRegistrationDate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtFName.Text + "','" + txtMName.Text + "','" + txtLastName.Text + "','" + txtFatherName.Text + "','" + Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd") + "','" + ddlGender.SelectedItem.Text + "','" + ddlPresentOcc.SelectedItem.Text + "','" + ddlorg.SelectedValue + "','" + txtOrg.Text + "','" + ddldept.SelectedValue + "','" + txtDept.Text + "','" + ddldesig.SelectedValue + "','" + txtDesig.Text + "','" + txtResAdd.Text + "','" + txtResCity.Text + "','" + ddlResDistrict.SelectedItem.Text + "','" + "" + "','" + txtResPost.Text + "','" + txtResTehsil.Text + "','" + txtResPinCode.Text + "','" + ddlResState.SelectedValue + "','" + txtProAdd.Text + "','" + txtProCity.Text + "','" + ddlProDistrict.SelectedItem.Text + "','" + "" + "','" + txtProPost.Text + "','" + txtProTehsil.Text + "','" + txtProPinCode.Text + "','" + ddlProState.SelectedValue + "','" + txtPerAdd.Text + "','" + txtPerCity.Text + "','" + ddlPerDistrict.SelectedItem.Text + "','" + "" + "','" + txtPerPost.Text + "','" + txtPerTehsil.Text + "','" + txtPerPinCode.Text + "','" + ddlPerState.SelectedValue + "','" + PreferedNo + "','" + ddlPreffAddress.SelectedValue + "','" + txtMobileNo1.Text + "','" + stdFax + "','" + txtEmailId.Text.Trim() + "','" + rbmobileprefered + "','" + ddl1.SelectedValue + "','" + ddl2.SelectedValue + "','" + ddl3.SelectedValue + "','" + ddl4.SelectedValue + "','" + ddlc1.SelectedValue + "','" + ddlc2.SelectedValue + "','" + ddlc3.SelectedValue + "','" + ddlc4.SelectedValue + "','" + ddlY1.SelectedValue + "','" + ddlY2.SelectedValue + "','" + ddlY3.SelectedValue + "','" + ddlY4.SelectedValue + "','" + file1path + "','" + file2path + "','" + file3path + "','" + file4path + "','" + file5path + "','" + Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtDegid.Text + "','" + isOnline + "','" + txtcheque.Text + "','" + txtbank.Text + "','" + Appdate + "','" + txtNocNumber.Text + "','" + txtNocDate.Text + "','" + txtNocState.Text + "','" + noc_Upload + "',1,'',3,'','" + txtMobileNo2.Text + "')");

                            //                            objdb.ByText(@"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                            //                                            values('" + ApplicationNo + "',3,'" + Appdate + "','" + isOnline + "','2025','1','" + txtcheque.Text + "','" + txtbank.Text + "','" + txtPaymentDate.Text + "','" + txtNocNumber.Text + "','" + txtNocDate.Text + "', '" + txtNocState.Text + "' ,'25','0','0','2000','0','0', '0', '')");

                            string str1 = @"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                                            values('" + ApplicationNo + "',3,'" + Appdate + "','" + isOnline + "','2025','1','" + txtcheque.Text + "','" + txtbank.Text + "','" + txtPaymentDate.Text + "','" + txtNocNumber.Text + "','" + Convert.ToDateTime(txtNocDate.Text, cult).ToString("yyyy/MM/dd") + "', '" + txtNocState.Text + "' ,'25','0','0','2000','0','0', '1', '')";

                            ds = objdb.ByProcedure("InsertTempTransction", new string[] { "ApplicationNo", "TblMaster", "TblTran" }, new string[] { ApplicationNo, str1, "" }, "dataset");
                            string TempTranId = ds.Tables[0].Rows[0]["id"].ToString();


                            lblMsg.Text = objdb.SaveAlert("Application submitted successfully, Please check your email for further details.");
                            RedirectonPaymentGatewayPage("3", ApplicationNo, TempTranId);
                        }
                    }
                    else // If Noc details not inserted by user
                    {
                        if (rboffline.Checked == true)  //If payment details  inserted null
                        {
                           

//                            objdb.ByText(@"insert into tblNewRegistration(ApplicationNo,ApplicationDate,RegiNo,RegiDate,FName,MName,LName,FatherName,DOB,Gender,PresentOccuption,OrganizationId,OrganizationText,DepartmentId,DepartmentText,Designationid,DesignationText,ResAdd,ResCity,ResDistrict,ResTown,ResPost,ResTehsil,ResPinCode,ResState,ProAdd,ProCity,ProDistrict,ProTown,ProPost,ProTehsil,ProPinCode,ProState,PerAdd,PerCity,PerDistrict,PerTown,PerPost,PerTehsil,PerPinCode,PerState,PhoneNo,PreferedAdd,MobileNo,Fax,EmailId,PreferedPhoneNo,University1,University2,University3,University4,CollegeID1,CollegeID2,CollegeID3,CollegeID4,Year1,Year2,Year3,Year4,File1,File2,File3,File4,File5,DegreeDate,DegreeId,Isonline,ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationStatus,CertificatePath,ApplicationRequestId,Validupto,MobileNo2)
//                                values('" + ApplicationNo + "','" + Appdate + "','','','" + txtFName.Text + "','" + txtMName.Text + "','" + txtLastName.Text + "','" + txtFatherName.Text + "','" + Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd") + "','" + ddlGender.SelectedItem.Text + "','" + ddlPresentOcc.SelectedItem.Text + "','" + ddlorg.SelectedValue + "','" + txtOrg.Text + "','" + ddldept.SelectedValue + "','" + txtDept.Text + "','" + ddldesig.SelectedValue + "','" + txtDesig.Text + "','" + txtResAdd.Text + "','" + txtResCity.Text + "','" + ddlResDistrict.SelectedItem.Text + "','" + "" + "','" + txtResPost.Text + "','" + txtResTehsil.Text + "','" + txtResPinCode.Text + "','" + ddlResState.SelectedValue + "','" + txtProAdd.Text + "','" + txtProCity.Text + "','" + ddlProDistrict.SelectedItem.Text + "','" + "" + "','" + txtProPost.Text + "','" + txtProTehsil.Text + "','" + txtProPinCode.Text + "','" + ddlProState.SelectedValue + "','" + txtPerAdd.Text + "','" + txtPerCity.Text + "','" + ddlPerDistrict.SelectedItem.Text + "','" + "" + "','" + txtPerPost.Text + "','" + txtPerTehsil.Text + "','" + txtPerPinCode.Text + "','" + ddlPerState.SelectedValue + "','" + PreferedNo + "','" + ddlPreffAddress.SelectedValue + "','" + txtMobileNo1.Text + "','" + stdFax + "','" + txtEmailId.Text.Trim() + "','" + rbmobileprefered + "','" + ddl1.SelectedValue + "','" + ddl2.SelectedValue + "','" + ddl3.SelectedValue + "','" + ddl4.SelectedValue + "','" + ddlc1.SelectedValue + "','" + ddlc2.SelectedValue + "','" + ddlc3.SelectedValue + "','" + ddlc4.SelectedValue + "','" + ddlY1.SelectedValue + "','" + ddlY2.SelectedValue + "','" + ddlY3.SelectedValue + "','" + ddlY4.SelectedValue + "','" + file1path + "','" + file2path + "','" + file3path + "','" + file4path + "','" + file5path + "','" + Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtDegid.Text + "','" + isOnline + "','" + txtcheque.Text + "','" + txtbank.Text + "','" + Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtNocNumber.Text + "','" + txtNocDate.Text + "','" + txtNocState.Text + "',1,'',0,'','" + txtMobileNo2.Text + "')");

//                            objdb.ByText(@"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
//                                            values('" + ApplicationNo + "',0,'" + Appdate + "','" + isOnline + "','2025','1','" + txtcheque.Text + "','" + txtbank.Text + "','" + Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtNocNumber.Text + "','" + Convert.ToDateTime(txtNocDate.Text, cult).ToString("yyyy/MM/dd") + "', '" + txtNocState.Text + "' ,'25','0','0','2000','0','0', '1', '')");

                            //start by bhanu on 02-03/2022
                            objdb.ByText(@"insert into tblNewRegistration(ApplicationNo,ApplicationDate,RegiNo,RegiDate,FName,MName,LName,FatherName,DOB,Gender,PresentOccuption,OrganizationId,OrganizationText,DepartmentId,DepartmentText,Designationid,DesignationText,ResAdd,ResCity,ResDistrict,ResTown,ResPost,ResTehsil,ResPinCode,ResState,ProAdd,ProCity,ProDistrict,ProTown,ProPost,ProTehsil,ProPinCode,ProState,PerAdd,PerCity,PerDistrict,PerTown,PerPost,PerTehsil,PerPinCode,PerState,PhoneNo,PreferedAdd,MobileNo,Fax,EmailId,PreferedPhoneNo,University1,University2,University3,University4,CollegeID1,CollegeID2,CollegeID3,CollegeID4,Year1,Year2,Year3,Year4,File1,File2,File3,File4,File5,DegreeDate,DegreeId,Isonline,ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationStatus,CertificatePath,ApplicationRequestId,Validupto,MobileNo2)
                                     values('" + ApplicationNo + "','" + Appdate + "','','','" + txtFName.Text + "','" + txtMName.Text + "','" + txtLastName.Text + "','" + txtFatherName.Text + "','" + Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd") + "','" + ddlGender.SelectedItem.Text + "','" + ddlPresentOcc.SelectedItem.Text + "','" + ddlorg.SelectedValue + "','" + txtOrg.Text + "','" + ddldept.SelectedValue + "','" + txtDept.Text + "','" + ddldesig.SelectedValue + "','" + txtDesig.Text + "','" + txtResAdd.Text + "','" + txtResCity.Text + "','" + ddlResDistrict.SelectedItem.Text + "','" + "" + "','" + txtResPost.Text + "','" + txtResTehsil.Text + "','" + txtResPinCode.Text + "','" + ddlResState.SelectedValue + "','" + txtProAdd.Text + "','" + txtProCity.Text + "','" + ddlProDistrict.SelectedItem.Text + "','" + "" + "','" + txtProPost.Text + "','" + txtProTehsil.Text + "','" + txtProPinCode.Text + "','" + ddlProState.SelectedValue + "','" + txtPerAdd.Text + "','" + txtPerCity.Text + "','" + ddlPerDistrict.SelectedItem.Text + "','" + "" + "','" + txtPerPost.Text + "','" + txtPerTehsil.Text + "','" + txtPerPinCode.Text + "','" + ddlPerState.SelectedValue + "','" + PreferedNo + "','" + ddlPreffAddress.SelectedValue + "','" + txtMobileNo1.Text + "','" + stdFax + "','" + txtEmailId.Text.Trim() + "','" + rbmobileprefered + "','" + ddl1.SelectedValue + "','" + ddl2.SelectedValue + "','" + ddl3.SelectedValue + "','" + ddl4.SelectedValue + "','" + ddlc1.SelectedValue + "','" + ddlc2.SelectedValue + "','" + ddlc3.SelectedValue + "','" + ddlc4.SelectedValue + "','" + ddlY1.SelectedValue + "','" + ddlY2.SelectedValue + "','" + ddlY3.SelectedValue + "','" + ddlY4.SelectedValue + "','" + file1path + "','" + file2path + "','" + file3path + "','" + file4path + "','" + file5path + "','" + Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtDegid.Text + "','" + isOnline + "','" + txtcheque.Text + "','" + txtbank.Text + "','" + Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtNocNumber.Text + "','" + NOC + "','" + txtNocState.Text + "',1,'',0,'','" + txtMobileNo2.Text + "')");

                                objdb.ByText(@"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)                      
                                              values('" + ApplicationNo + "',0,'" + Appdate + "','" + isOnline + "','2025','1','" + txtcheque.Text + "','" + txtbank.Text + "','" + Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtNocNumber.Text + "','" + NOC+ "', '" + txtNocState.Text + "' ,'25','0','0','2000','0','0', '1', '')");
                          //start by bhanu on 02-03/2022

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
                            string body = objdb.CreateEmailBody(0, ApplicationNo); //Email body function
                            string mbMessage = objdb.CreateMessageBody(0, ApplicationNo); // Message Body Function
                            objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.
                            lblMsg.Text = objdb.SaveAlert("Application submitted successfully, Please check your email for further details.");
                            obCommonFuction.EmptyTextBoxes(this);
                        }
                        else // If Payment details inserted
                        {
//                            objdb.ByText(@"insert into tblNewRegistration(ApplicationNo,ApplicationDate,RegiNo,RegiDate,FName,MName,LName,FatherName,DOB,Gender,PresentOccuption,OrganizationId,OrganizationText,DepartmentId,DepartmentText,Designationid,DesignationText,ResAdd,ResCity,ResDistrict,ResTown,ResPost,ResTehsil,ResPinCode,ResState,ProAdd,ProCity,ProDistrict,ProTown,ProPost,ProTehsil,ProPinCode,ProState,PerAdd,PerCity,PerDistrict,PerTown,PerPost,PerTehsil,PerPinCode,PerState,PhoneNo,PreferedAdd,MobileNo,Fax,EmailId,PreferedPhoneNo,University1,University2,University3,University4,CollegeID1,CollegeID2,CollegeID3,CollegeID4,Year1,Year2,Year3,Year4,File1,File2,File3,File4,File5,DegreeDate,DegreeId,Isonline,ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationStatus,CertificatePath,ApplicationRequestId,Validupto,MobileNo2)
//                        values('" + ApplicationNo + "','" + Appdate + "','','','" + txtFName.Text + "','" + txtMName.Text + "','" + txtLastName.Text + "','" + txtFatherName.Text + "','" + Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd") + "','" + ddlGender.SelectedItem.Text + "','" + ddlPresentOcc.SelectedItem.Text + "','" + ddlorg.SelectedValue + "','" + txtOrg.Text + "','" + ddldept.SelectedValue + "','" + txtDept.Text + "','" + ddldesig.SelectedValue + "','" + txtDesig.Text + "','" + txtResAdd.Text + "','" + txtResCity.Text + "','" + ddlResDistrict.SelectedItem.Text + "','" + "" + "','" + txtResPost.Text + "','" + txtResTehsil.Text + "','" + txtResPinCode.Text + "','" + ddlResState.SelectedValue + "','" + txtProAdd.Text + "','" + txtProCity.Text + "','" + ddlProDistrict.SelectedItem.Text + "','" + "" + "','" + txtProPost.Text + "','" + txtProTehsil.Text + "','" + txtProPinCode.Text + "','" + ddlProState.SelectedValue + "','" + txtPerAdd.Text + "','" + txtPerCity.Text + "','" + ddlPerDistrict.SelectedItem.Text + "','" + "" + "','" + txtPerPost.Text + "','" + txtPerTehsil.Text + "','" + txtPerPinCode.Text + "','" + ddlPerState.SelectedValue + "','" + PreferedNo + "','" + ddlPreffAddress.SelectedValue + "','" + txtMobileNo1.Text + "','" + stdFax + "','" + txtEmailId.Text.Trim() + "','" + rbmobileprefered + "','" + ddl1.SelectedValue + "','" + ddl2.SelectedValue + "','" + ddl3.SelectedValue + "','" + ddl4.SelectedValue + "','" + ddlc1.SelectedValue + "','" + ddlc2.SelectedValue + "','" + ddlc3.SelectedValue + "','" + ddlc4.SelectedValue + "','" + ddlY1.SelectedValue + "','" + ddlY2.SelectedValue + "','" + ddlY3.SelectedValue + "','" + ddlY4.SelectedValue + "','" + file1path + "','" + file2path + "','" + file3path + "','" + file4path + "','" + file5path + "','" + Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtDegid.Text + "','" + isOnline + "','" + txtcheque.Text + "','" + txtbank.Text + "','" + Appdate + "','" + txtNocNumber.Text + "','" + txtNocDate.Text + "','" + txtNocState.Text + "',1,'',0,'','" + txtMobileNo2.Text + "')");

//                            string str2 = @"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
//                                            values('" + ApplicationNo + "',0,'" + Appdate + "','" + isOnline + "','2025','1','" + txtcheque.Text + "','" + txtbank.Text + "','" + txtPaymentDate.Text + "','" + txtNocNumber.Text + "','" + Convert.ToDateTime(txtNocDate.Text, cult).ToString("yyyy/MM/dd") + "', '" + txtNocState.Text + "' ,'25','0','0','2000','0','0', '1', '')";

                            //start by bhanu on 02-03/2022
                            objdb.ByText(@"insert into tblNewRegistration(ApplicationNo,ApplicationDate,RegiNo,RegiDate,FName,MName,LName,FatherName,DOB,Gender,PresentOccuption,OrganizationId,OrganizationText,DepartmentId,DepartmentText,Designationid,DesignationText,ResAdd,ResCity,ResDistrict,ResTown,ResPost,ResTehsil,ResPinCode,ResState,ProAdd,ProCity,ProDistrict,ProTown,ProPost,ProTehsil,ProPinCode,ProState,PerAdd,PerCity,PerDistrict,PerTown,PerPost,PerTehsil,PerPinCode,PerState,PhoneNo,PreferedAdd,MobileNo,Fax,EmailId,PreferedPhoneNo,University1,University2,University3,University4,CollegeID1,CollegeID2,CollegeID3,CollegeID4,Year1,Year2,Year3,Year4,File1,File2,File3,File4,File5,DegreeDate,DegreeId,Isonline,ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationStatus,CertificatePath,ApplicationRequestId,Validupto,MobileNo2)
                                          values('" + ApplicationNo + "','" + Appdate + "','','','" + txtFName.Text + "','" + txtMName.Text + "','" + txtLastName.Text + "','" + txtFatherName.Text + "','" + Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd") + "','" + ddlGender.SelectedItem.Text + "','" + ddlPresentOcc.SelectedItem.Text + "','" + ddlorg.SelectedValue + "','" + txtOrg.Text + "','" + ddldept.SelectedValue + "','" + txtDept.Text + "','" + ddldesig.SelectedValue + "','" + txtDesig.Text + "','" + txtResAdd.Text + "','" + txtResCity.Text + "','" + ddlResDistrict.SelectedItem.Text + "','" + "" + "','" + txtResPost.Text + "','" + txtResTehsil.Text + "','" + txtResPinCode.Text + "','" + ddlResState.SelectedValue + "','" + txtProAdd.Text + "','" + txtProCity.Text + "','" + ddlProDistrict.SelectedItem.Text + "','" + "" + "','" + txtProPost.Text + "','" + txtProTehsil.Text + "','" + txtProPinCode.Text + "','" + ddlProState.SelectedValue + "','" + txtPerAdd.Text + "','" + txtPerCity.Text + "','" + ddlPerDistrict.SelectedItem.Text + "','" + "" + "','" + txtPerPost.Text + "','" + txtPerTehsil.Text + "','" + txtPerPinCode.Text + "','" + ddlPerState.SelectedValue + "','" + PreferedNo + "','" + ddlPreffAddress.SelectedValue + "','" + txtMobileNo1.Text + "','" + stdFax + "','" + txtEmailId.Text.Trim() + "','" + rbmobileprefered + "','" + ddl1.SelectedValue + "','" + ddl2.SelectedValue + "','" + ddl3.SelectedValue + "','" + ddl4.SelectedValue + "','" + ddlc1.SelectedValue + "','" + ddlc2.SelectedValue + "','" + ddlc3.SelectedValue + "','" + ddlc4.SelectedValue + "','" + ddlY1.SelectedValue + "','" + ddlY2.SelectedValue + "','" + ddlY3.SelectedValue + "','" + ddlY4.SelectedValue + "','" + file1path + "','" + file2path + "','" + file3path + "','" + file4path + "','" + file5path + "','" + Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd") + "','" + txtDegid.Text + "','" + isOnline + "','" + txtcheque.Text + "','" + txtbank.Text + "','" + Appdate + "','" + txtNocNumber.Text + "','" + NOC + "','" + txtNocState.Text + "',1,'',0,'','" + txtMobileNo2.Text + "')");
                           
                            string str2 = @"insert into tbl_Transactiondetails(ApplicationNo,ApplicationRequestId,Applydate,Isonline,TotalAmount,RegistrationStatus, ChequeNo,BankName,ChequeDate,NocNumber,NocDate,NocState,RegistrationFees,RenewalFees,Transferfees,ServiceCharge,LateFees,ReEstablishmentFees, TransactionStatus, TransactionId)
                                            values('" + ApplicationNo + "',0,'" + Appdate + "','" + isOnline + "','2025','1','" + txtcheque.Text + "','" + txtbank.Text + "','" + txtPaymentDate.Text + "','" + txtNocNumber.Text + "','" + NOC + "', '" + txtNocState.Text + "' ,'25','0','0','2000','0','0', '1', '')";
                            //end by bhanu on 02-03/2022

                            ds = objdb.ByProcedure("InsertTempTransction", new string[] { "ApplicationNo", "TblMaster", "TblTran" }, new string[] { ApplicationNo, str2, "" }, "dataset");
                            string TempTranId = ds.Tables[0].Rows[0]["id"].ToString();
                            RedirectonPaymentGatewayPage("0", ApplicationNo, TempTranId);

                        }
                    }

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
        else {
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
        else {
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
        else {
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
            else {
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
    protected void chkNocDetails_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkNocDetails.Checked == true)
            {
                tr_NocNumber.Visible = true;
                tr_NocState.Visible = true;
            }
            else
            {
                tr_NocNumber.Visible = false;
                tr_NocState.Visible = false;
            }
            chkNocDetails.Focus();
        }
        catch (Exception ex)
        {
            lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString());
        }
    }
    public void RedirectonPaymentGatewayPage(string ApplicationType, string ApplicationNo, string Tmpid)
    {
        string var = ApplicationNo + "*" + lblAmount.Text + "*" + txtEmailId.Text + "*" + txtMobileNo1.Text + "*" + txtFName.Text + "*" + ApplicationType + "*" + Tmpid;
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
}