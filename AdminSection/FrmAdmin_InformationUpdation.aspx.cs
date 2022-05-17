using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSection_FrmAdmin_InformationUpdation : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    APIProcedure objdb = new APIProcedure();
    string mbNo = "";
    string SendOTP = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UId"] != null)
        {
            if (!Page.IsPostBack)
            {
                fnProState();
                fnPerState();
                getResDistrict();
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
                    FieldFill(sender, e);
                }
            }
        }
        else
        {
            Response.Redirect("../index.html");
        }
    }

    public void FieldFill(object sender, EventArgs e)
    {
        try
        {
            if (txtRegNo.Text.Trim() != "")
            {
                ds = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + txtRegNo.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string chkCancel = ds.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
                    if (chkCancel == "9")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "CancelRegistration();", true);
                        return;
                    }
                    //These Lines are comments by SFA developer - 16/02/2016 
                    //DataSet dsloginuser = objdb.ByDataSet("select * from tblUserMaster where LoginId ='" + Session["UId"].ToString() + "'");
                    //SendOTP = objdb.Send_OTP(dsloginuser.Tables[0].Rows[0]["MobileNo"].ToString());
                    //lblMobilealert.Text = " Does " + dsloginuser.Tables[0].Rows[0]["MobileNo"].ToString() + " really belong to you? ";                   
                    //ViewState["OTPSended"] = SendOTP;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPVerification();", true);

                    //This line is added by to bypass otp code by SFA developer
                    FillUserDetails(sender, e);

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
        ds = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + txtRegNo.Text + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            hf_regno.Value = txtRegNo.Text;
            txtRegNo.Enabled = false;
            txtRegNo.Text = ds.Tables[0].Rows[0]["RegiNo"].ToString();
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
                if (ddlResState.SelectedIndex > 0)
                {
                    ddlResDistrict.ClearSelection();
                    ddlResDistrict.Items.FindByText(ds.Tables[0].Rows[0]["ResDistrict"].ToString()).Selected = true;
                }
            }
            catch { }
            txtProAdd.Text = ds.Tables[0].Rows[0]["ProAdd"].ToString();
            txtProCity.Text = ds.Tables[0].Rows[0]["ProCity"].ToString();
            txtProPost.Text = ds.Tables[0].Rows[0]["ProPost"].ToString();
            txtProTehsil.Text = ds.Tables[0].Rows[0]["ProTehsil"].ToString();
            txtProPinCode.Text = ds.Tables[0].Rows[0]["ProPinCode"].ToString();
            try
            {
                ddlProState.ClearSelection();
                ddlProState.Items.FindByValue(ds.Tables[0].Rows[0]["ProState"].ToString()).Selected = true;
            }
            catch { }
            try
            {
                if (ddlProState.SelectedIndex > 0)
                {
                    ddlProState_SelectedIndexChanged(sender, e);
                    ddlProDistrict.ClearSelection();
                    ddlProDistrict.Items.FindByText(ds.Tables[0].Rows[0]["ProDistrict"].ToString()).Selected = true;
                }
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
                if (ddlPerState.SelectedIndex > 0)
                {
                    ddlPerState_SelectedIndexChanged(sender, e);
                    ddlPerDistrict.ClearSelection();
                    ddlPerDistrict.Items.FindByText(ds.Tables[0].Rows[0]["PerDistrict"].ToString()).Selected = true;
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
        }
    }
    public DataSet StateFill()
    {
        return objdb.ByProcedure("ProcStateFill", "BYdataset");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
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
            if (txtDOB.Text == "")
            {
                lblMsg.Text = objdb.ErrorAlert("Please enter correct Date Of Birth.");
            }
            else
            {
                ds = objdb.ByProcedure("ProcUpdateUserInfo", new string[] { "RegiNo", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "type", "MobileNo2" },
                     new string[] {txtRegNo.Text, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedValue.ToString(), ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, "1", txtMobileNo2.Text }, "dataset");

                if (ds.Tables[0].Rows[0]["Msg"].ToString() == "Ok")
                {
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
                    //string subject = "MPSVC Registration Mail";
                    //string body = objdb.CreateEmailBody(1, hf_regno.Value);
                    //string mbMessage = objdb.CreateMessageBody(1, hf_regno.Value); // Message Body Function
                    //objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true);
                    obCommonFuction.EmptyTextBoxes(this);
                }
            }

        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }
    }

    protected void fnProState()
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
                ddlPerDistrict.SelectedItem.Text = "";             
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
    protected void ddlProState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProState.SelectedIndex > 0)
            {
                DataSet dt1 = objdb.ByDataSet("select * from Districts where StateId='" + ddlProState.SelectedValue + "'");
                if (dt1.Tables[0].Rows.Count > 0)
                {
                    ddlProDistrict.DataTextField = "DistrictName";
                    ddlProDistrict.DataValueField = "DistrictId";
                    ddlProDistrict.DataSource = dt1.Tables[0];
                    ddlProDistrict.DataBind();
                    ddlProDistrict.Items.Insert(0, "Select");
                    ddlProDistrict.Focus();
                }
            }
            else
            {
                ddlProDistrict.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
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
            else {
                ddlPerDistrict.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
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
}