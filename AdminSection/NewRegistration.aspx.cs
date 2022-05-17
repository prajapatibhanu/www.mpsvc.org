using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class AdminSection_NewRegistration : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    APIProcedure objdb = new APIProcedure(); string path2, path3, path4;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FieldFill();
            DataSet dd1 = objdb.ByDataSet("select * from Tbl_UniversityMaster");
            ddl1.DataTextField = "UniversityName";
            ddl1.DataValueField = "id";
            ddl1.DataSource = dd1.Tables[0];
            ddl1.DataBind();
            ddl1.Items.Insert(0, "Select..");

            ddl2.DataTextField = "UniversityName";
            ddl2.DataValueField = "id";
            ddl2.DataSource = dd1.Tables[0];
            ddl2.DataBind();
            ddl2.Items.Insert(0, "Select..");

            ddl3.DataTextField = "UniversityName";
            ddl3.DataValueField = "id";
            ddl3.DataSource = dd1.Tables[0];
            ddl3.DataBind();
            ddl3.Items.Insert(0, "Select..");

            ddl4.DataTextField = "UniversityName";
            ddl4.DataValueField = "id";
            ddl4.DataSource = dd1.Tables[0];
            ddl4.DataBind();
            ddl4.Items.Insert(0, "Select..");

            //************new code
            DataSet dt1 = objdb.ByDataSet("select * from tbl_Departmentmaster");
            ddldept.DataTextField = "DepaertmentName";
            ddldept.DataValueField = "DepaertmentName";
            ddldept.DataSource = dt1.Tables[0];
            ddldept.DataBind();

            DataSet dt2 = objdb.ByDataSet("select * from tbl_OrganizationMaster");
            ddlorg.DataTextField = "OrganaizationName";
            ddlorg.DataValueField = "OrganaizationName";
            ddlorg.DataSource = dt2.Tables[0];
            ddlorg.DataBind();

            DataSet dt3 = objdb.ByDataSet("select * from tbl_Designationmaster");
            ddldesig.DataTextField = "DesinationName";
            ddldesig.DataValueField = "DesinationName";
            ddldesig.DataSource = dt3.Tables[0];
            ddldesig.DataBind();
        }



    }
    public void FieldFill()
    {
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                ds = objdb.ByProcedure("ProcNewRegistrationDtl", new string[] { "KeyBoard", "type" }, new string[] { Request.QueryString["Id"].ToString(), "1" }, "dataset");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtRegNo.Enabled = false;
                    txtRegNo.Text = ds.Tables[0].Rows[0]["RegiNo"].ToString();
                    txtRegDate.Text = ds.Tables[0].Rows[0]["RegiDate"].ToString();
                    txtFName.Text = ds.Tables[0].Rows[0]["FName"].ToString();
                    txtMName.Text = ds.Tables[0].Rows[0]["MName"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["LName"].ToString();
                    txtFatherName.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                    txtDOB.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                    ddlGender.ClearSelection();
                    try
                    {
                        ddlGender.Items.FindByText(ds.Tables[0].Rows[0]["Gender"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        ddlPresentOcc.ClearSelection();
                        ddlPresentOcc.Items.FindByText(ds.Tables[0].Rows[0]["PresentOccuption"].ToString()).Selected = true;
                    }
                    catch { }
                    txtResAdd.Text = ds.Tables[0].Rows[0]["ResAdd"].ToString();
                    txtResCity.Text = ds.Tables[0].Rows[0]["ResCity"].ToString();
                    txtResDistrict.Text = ds.Tables[0].Rows[0]["ResDistrict"].ToString();
                    try
                    {
                        ddlResState.ClearSelection();
                        ddlResState.Items.FindByValue(ds.Tables[0].Rows[0]["ResState"].ToString()).Selected = true;
                    }
                    catch { }
                    txtResPinCode.Text = ds.Tables[0].Rows[0]["ResPinCode"].ToString();
                    txtProAdd.Text = ds.Tables[0].Rows[0]["ProAdd"].ToString();
                    try
                    {
                        ddlProState.ClearSelection();
                        ddlProState.Items.FindByValue(ds.Tables[0].Rows[0]["ProState"].ToString()).Selected = true;
                    }
                    catch { }
                    txtProCity.Text = ds.Tables[0].Rows[0]["ProCity"].ToString();
                    txtProDistrict.Text = ds.Tables[0].Rows[0]["ProDistrict"].ToString();
                    txtProPinCode.Text = ds.Tables[0].Rows[0]["ProPinCode"].ToString();
                    txtPerAdd.Text = ds.Tables[0].Rows[0]["PerAdd"].ToString();
                    txtPerCity.Text = ds.Tables[0].Rows[0]["PerCity"].ToString();
                    txtPerDistrict.Text = ds.Tables[0].Rows[0]["PerDistrict"].ToString();
                    try
                    {
                        ddlPerState.ClearSelection();
                        ddlPerState.Items.FindByValue(ds.Tables[0].Rows[0]["PerState"].ToString()).Selected = true;
                    }
                    catch { }
                    txtPerPinCode.Text = ds.Tables[0].Rows[0]["PerPinCode"].ToString();
                    try
                    {
                        ddlPreffAddress.ClearSelection();
                        ddlPreffAddress.Items.FindByText(ds.Tables[0].Rows[0]["PreferedAdd"].ToString()).Selected = true;
                    }
                    catch { }
                    txtPhoneNo.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    txtPreffPhoneNo.Text = ds.Tables[0].Rows[0]["PreferedPhoneNo"].ToString();
                    txtFaxNo.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
                    txtQualification.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
                    try
                    {
                        ddlPassingYear.ClearSelection();
                        ddlPassingYear.Items.FindByValue(ds.Tables[0].Rows[0]["PassingYear"].ToString()).Selected = true;
                    }
                    catch { }
                    txtUniversity.Text = ds.Tables[0].Rows[0]["UniversityInstitute"].ToString();
                    txtOtherQualification.Text = ds.Tables[0].Rows[0]["OtherQualification"].ToString();
                    try
                    {
                        ddlOtherPassingYear.ClearSelection();
                        ddlOtherPassingYear.Items.FindByValue(ds.Tables[0].Rows[0]["OthPassingYear"].ToString()).Selected = true;
                    }
                    catch { }
                    txtOtherUniversity.Text = ds.Tables[0].Rows[0]["OthUniversityInstitute"].ToString();
                    txtEmailId.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                    try
                    {
                        ddlRegiStatus.ClearSelection();
                        ddlRegiStatus.Items.FindByValue(ds.Tables[0].Rows[0]["MemStatus"].ToString()).Selected = true;
                    }
                    catch { }
                    hdnFile.Value = ds.Tables[0].Rows[0]["FilePath"].ToString();

                }
            }
        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }
    }
    public DataSet StateFill()
    {
        return objdb.ByProcedure("ProcStateFill", "BYdataset");
    }
    protected void ddlResState_Init(object sender, EventArgs e)
    {
        try
        {
            ddlResState.DataSource = StateFill();
            ddlResState.DataTextField = "StateName";
            ddlResState.DataValueField = "StateId";
            ddlResState.DataBind();
            ddlResState.Items.Insert(0, "Select");
        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }

    }
    protected void ddlProState_Init(object sender, EventArgs e)
    {
        try
        {
            ddlProState.DataSource = StateFill();
            ddlProState.DataTextField = "StateName";
            ddlProState.DataValueField = "StateId";
            ddlProState.DataBind();
            ddlProState.Items.Insert(0, "Select");
        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }

    }
    protected void ddlPerState_Init(object sender, EventArgs e)
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


    protected void ddlPassingYear_Init(object sender, EventArgs e)
    {
        int Year = DateTime.Now.Year;

        ddlPassingYear.DataSource = string.Empty;
        ddlPassingYear.DataBind();

        for (int i = 1975; i <= Year; i++)
        {
            ddlPassingYear.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
        }
        ddlPassingYear.Items.Insert(0, "Select");

    }
    protected void ddlOtherPassingYear_Init(object sender, EventArgs e)
    {
        int Year = DateTime.Now.Year;
        ddlOtherPassingYear.DataSource = string.Empty;
        ddlOtherPassingYear.DataBind();
        //for (int i = 1975; i <= Year; i++)
        //{
        //    ddlOtherPassingYear.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
        //    ddlY1.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
        //    ddlY2.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
        //    ddlY3.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
        //    ddlY4.Items.Insert(0, new ListItem(i.ToString(), i.ToString()));
        //}
        ddlOtherPassingYear.Items.Insert(0, "Select");











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
        ddlY1.Items.Insert(0, "Select");
        ddlY2.Items.Insert(0, "Select");
        ddlY3.Items.Insert(0, "Select");
        ddlY4.Items.Insert(0, "Select");

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string FileName = "";
            string ImgStatus = "";
            string FileName1 = "";
            string ImgStatus1 = "";
            string FileName2 = "";
            string ImgStatus2 = "";
            string FileName3 = "";
            string ImgStatus3 = "";
            DateTime DteCheck;
            string DOB = "", RegDate = "";
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
                //if (FileUpload1.FileName == "")
                //{
                //    ImgStatus = "Ok";
                //    FileName = hdnFile.Value.ToString();
                //}
                //else
                //{
                //    ImgStatus = objdb.uploadFile(FileUpload1, "RegistrationDoc", 1000);
                //    if (ImgStatus == "Ok")
                //    {
                //        FileName = objdb.FullFileName;
                //    }
                //}
                if (Request.QueryString["Id"] != null)
                {
                    ds = objdb.ByProcedure("ProcNewRegistration", new string[] { "RegiNo", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "ResAdd", "ResCity", "ResDistrict", "ResState", "ResPinCode", "ProAdd", "ProState", "ProCity", "ProDistrict", "ProPinCode", "PerAdd", "PerCity", "PerDistrict", "PerState", "PerPinCode", "PreferedAdd", "PhoneNo", "MobileNo", "PreferedPhoneNo", "Fax", "Qualification", "PassingYear", "UniversityInstitute", "OtherQualification", "OthPassingYear", "OthUniversityInstitute", "EmailId", "MemStatus", "FilePath", "type" },
                                      new string[] { txtRegNo.Text, txtRegDate.Text, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, txtDOB.Text, ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, txtResAdd.Text, txtResCity.Text, txtResDistrict.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtResPinCode.Text, txtProAdd.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtProCity.Text, txtProDistrict.Text, txtProPinCode.Text, txtPerAdd.Text, txtPerCity.Text, txtPerDistrict.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), txtPerPinCode.Text, ddlPreffAddress.SelectedItem.Text, txtPhoneNo.Text, txtMobileNo.Text, txtPreffPhoneNo.Text, txtFaxNo.Text, txtQualification.Text, ddlPassingYear.SelectedItem.Text, txtUniversity.Text, txtOtherQualification.Text, ddlOtherPassingYear.SelectedItem.Text, txtOtherUniversity.Text, txtEmailId.Text, ddlRegiStatus.SelectedItem.Text, FileName, "1" }, "Save");
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "Ok")
                    {
                        lblMsg.Text = objdb.SaveAlert("Record updated successfully.");
                        obCommonFuction.EmptyTextBoxes(this);
                        Response.Redirect("ViewNewRegistration.aspx");
                    }
                    else
                    {
                        lblMsg.Text = objdb.ErrorAlert(ds.Tables[0].Rows[0]["Msg"].ToString());

                    }
                }
                else
                {

                    //if (FileUpload2.HasFile)
                    //{
                    //    path2 = Server.MapPath("~/RegistrationDoc/");
                    //    FileName1 = FileUpload2.FileName;
                    //    FileUpload2.PostedFile.SaveAs(path2 + FileUpload2.FileName);
                    //}
                    //if (FileUpload3.HasFile)
                    //{
                    //    path3 = Server.MapPath("~/RegistrationDoc/");
                    //    FileName2 = FileUpload3.FileName;
                    //    FileUpload3.PostedFile.SaveAs(path3 + FileUpload3.FileName);
                    //}
                    //if (FileUpload4.HasFile)
                    //{
                    //    path3 = Server.MapPath("~/RegistrationDoc/");
                    //    FileName3 = FileUpload4.FileName;
                    //    FileUpload4.PostedFile.SaveAs(path4 + FileUpload4.FileName);
                    //}
                    //mgStatus1 = objdb.uploadFile(FileUpload2, "RegistrationDoc", 1000);
                    //if (ImgStatus1 == "Ok")
                    //{
                    //    FileName1 = objdb.FullFileName;
                    //}
                    //ImgStatus2 = objdb.uploadFile(FileUpload3, "RegistrationDoc", 1000);
                    //if (ImgStatus2 == "Ok")
                    //{
                    //    FileName2 = objdb.FullFileName;
                    //}
                    //ImgStatus3 = objdb.uploadFile(FileUpload4, "RegistrationDoc", 1000);
                    //if (ImgStatus3 == "Ok")
                    //{
                    //    FileName3 = objdb.FullFileName;
                    //}
                    //ds = objdb.ByProcedure("ProcNewRegistration", new string[] { "RegiNo", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "ResAdd", "ResCity", "ResDistrict", "ResState", "ResPinCode", "ProAdd", "ProState", "ProCity", "ProDistrict", "ProPinCode", "PerAdd", "PerCity", "PerDistrict", "PerState", "PerPinCode", "PreferedAdd", "PhoneNo", "MobileNo", "PreferedPhoneNo", "Fax", "Qualification", "PassingYear", "UniversityInstitute", "OtherQualification", "OthPassingYear", "OthUniversityInstitute", "EmailId", "MemStatus", "FilePath", "type", "File2", "File3", "File4" },
                    //                  new string[] { , FileName, "0" ,FileName1,FileName2,FileName3}, "Save");
                    objdb.ByText(@"insert into tblNewRegistration(FilePath, RegiNo,FName, MName, LName, FatherName, DOB, Gender, PresentOccuption, ResAdd, ResCity, ResDistrict, ResState, ResPinCode, 
	ProAdd, ProState, ProCity, ProDistrict, ProPinCode, PerAdd, PerCity, PerDistrict, PerState, PerPinCode, PreferedAdd, PhoneNo, MobileNo, 
	PreferedPhoneNo, Fax, Qualification, PassingYear, UniversityInstitute, OtherQualification, OthPassingYear, OthUniversityInstitute, EmailId, MemStatus,
	File2,File3,File4,UNI,CollegeID,Year,UNI1,CollegeID1,Year1,UNI2 ,CollegeID2,Year2,UNI3 ,CollegeID3
      ,Year3)values ('" + FileName + "',0,'" + txtFName.Text + "', '" + txtMName.Text + "','" + txtLastName.Text + "','" + txtFatherName.Text + "','" + Convert.ToDateTime(txtDOB.Text, cult).ToString("MM/dd/yyyy") + "','" + ddlGender.SelectedItem.Text + "','" + ddlPresentOcc.SelectedItem.Text + "', '" + txtResAdd.Text + "','" + txtResCity.Text + "', '" + txtResDistrict.Text + "','" + ddlResState.SelectedValue.ToString().Replace("Select", "0") + "','" + txtResPinCode.Text + "','" + txtProAdd.Text + "','" + ddlProState.SelectedValue.ToString().Replace("Select", "0") + "', '" + txtProCity.Text + "', '" + txtProDistrict.Text + "', '" + txtProPinCode.Text + "','" + txtPerAdd.Text + "','" + txtPerCity.Text + "','" + txtPerDistrict.Text + "', '" + ddlPerState.SelectedValue.ToString().Replace("Select", "0") + "', '" + txtPerPinCode.Text + "','" + ddlPreffAddress.SelectedItem.Text + "','" + txtPhoneNo.Text + "','" + txtMobileNo.Text + "','" + txtPreffPhoneNo.Text + "', '" + txtFaxNo.Text + "','" + txtQualification.Text + "', '" + ddlPassingYear.SelectedItem.Text + "','" + txtUniversity.Text + "', '" + txtOtherQualification.Text + "','" + ddlOtherPassingYear.SelectedItem.Text + "', '" + txtOtherUniversity.Text + "','" + txtEmailId.Text + "', '" + ddlRegiStatus.SelectedItem.Text + "','" + FileName1 + "','" + FileName2 + "','" + FileName3 + "','" + ddl1.SelectedValue + "','" + ddlc1.SelectedValue + "','" + ddlY1.SelectedValue + "','" + ddl2.SelectedValue + "','" + ddlc2.SelectedValue + "','" + ddlY2.SelectedValue + "','" + ddl3.SelectedValue + "','" + ddlc3.SelectedValue + "','" + ddlY3.SelectedValue + "','" + ddl4.SelectedValue + "','" + ddlc4.SelectedValue + "','" + ddlY4.SelectedValue + "')");

                    lblMsg.Text = objdb.SaveAlert("Registration Confirmation is send on your Mail, Kindly Carry Your Originals documents while visiting Madhya Pradesh Veterinary Office.");
                    obCommonFuction.EmptyTextBoxes(this);


                }
            }
        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }
    }
    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd1 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl1.SelectedValue + "");
        ddlc1.DataTextField = "CollegeName";
        ddlc1.DataValueField = "id";
        ddlc1.DataSource = dd1.Tables[0];
        ddlc1.DataBind();
        ddlc1.Items.Insert(0, "Select..");
    }
    protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd3 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl2.SelectedValue + "");
        ddlc2.DataTextField = "CollegeName";
        ddlc2.DataValueField = "id";
        ddlc2.DataSource = dd3.Tables[0];
        ddlc2.DataBind();
        ddlc2.Items.Insert(0, "Select..");
    }
    protected void ddl3_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd33 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl3.SelectedValue + "");
        ddlc3.DataTextField = "CollegeName";
        ddlc3.DataValueField = "id";
        ddlc3.DataSource = dd33.Tables[0];
        ddlc3.DataBind();
        ddlc3.Items.Insert(0, "Select..");
    }
    protected void ddl4_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd333 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl4.SelectedValue + "");
        ddlc4.DataTextField = "CollegeName";
        ddlc4.DataValueField = "id";
        ddlc4.DataSource = dd333.Tables[0];
        ddlc4.DataBind();
        ddlc4.Items.Insert(0, "Select..");
    }
}