using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Drawing;

public partial class frm_userupdateddetails : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DataSet ds;
    APIProcedure objdb = new APIProcedure(); string path2, path3, path4;
    CultureInfo cult = new CultureInfo("gu-IN", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fnPrefState();

            if (Request.QueryString["editUPD"] != null)
            {
                btnUpdate.Text = "Verify";
                fillfield(sender, e);
                tr_Reg.Visible = false;
                btnNotApprove.Visible = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                tr_Reg.Visible = true;
                btnNotApprove.Visible = false;
            }
        }
    }

    protected void fillfield(object sender, EventArgs e)
    {
        if (Request.QueryString["editUPD"] != null)
        {
            ds = objdb.ByDataSet("select * from tbl_UserRequest where id ='" + Request.QueryString["editUPD"].ToString() + "'");
        }
        if (ds.Tables[0].Rows.Count > 0)
        {

            btnUpdate.Enabled = true;
            hf_regno.Value = ds.Tables[0].Rows[0]["RegiNo"].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
            txtEmailId.Text = ds.Tables[0].Rows[0]["Emailid"].ToString();
            hf_appno.Value = ds.Tables[0].Rows[0]["ApplicationNo"].ToString();

            if (Request.QueryString["editUPD"] != null)
            {
                tr_idtype.Visible = false;
                tr_idProof.Visible = false;
            }

            if (Request.QueryString["editUPD"] != null)
            {
                txtPrefAdd.Text = ds.Tables[0].Rows[0]["PrefAdd"].ToString();
                txtPrefCity.Text = ds.Tables[0].Rows[0]["PrefCity"].ToString();
                txtPrefPost.Text = ds.Tables[0].Rows[0]["PrefPost"].ToString();
                txtPrefTehsil.Text = ds.Tables[0].Rows[0]["PrefTehsil"].ToString();
                txtPrefPinCode.Text = ds.Tables[0].Rows[0]["PrefPincode"].ToString();
                try
                {
                    ddlPrefState.ClearSelection();
                    ddlPrefState.Items.FindByValue(ds.Tables[0].Rows[0]["PrefState"].ToString()).Selected = true;
                }
                catch { }
                try
                {
                    ddlPrefState_SelectedIndexChanged(sender, e);
                    ddlPrefDistrict.ClearSelection();
                    ddlPrefDistrict.Items.FindByValue(ds.Tables[0].Rows[0]["PrefDistrict"].ToString()).Selected = true;
                }
                catch { }



            }
        }
        else
        {
            string getPrefAdd = ds.Tables[0].Rows[0]["PreferedAdd"].ToString();
            hf_pAddress.Value = getPrefAdd;
            if (getPrefAdd == "Residential")
            {
                txtPrefAdd.Text = ds.Tables[0].Rows[0]["ResAdd"].ToString();
                txtPrefCity.Text = ds.Tables[0].Rows[0]["ResCity"].ToString();
                txtPrefPost.Text = ds.Tables[0].Rows[0]["ResPost"].ToString();
                txtPrefTehsil.Text = ds.Tables[0].Rows[0]["ResTehsil"].ToString();
                txtPrefPinCode.Text = ds.Tables[0].Rows[0]["ResPinCode"].ToString();
                try
                {
                    ddlPrefState.ClearSelection();
                    ddlPrefState.Items.FindByValue(ds.Tables[0].Rows[0]["ResState"].ToString()).Selected = true;
                }
                catch { }
                try
                {
                    ddlPrefState_SelectedIndexChanged(sender, e);
                    ddlPrefDistrict.ClearSelection();
                    ddlPrefDistrict.Items.FindByText(ds.Tables[0].Rows[0]["ResDistrict"].ToString()).Selected = true;
                }
                catch { }
            }
            else if (getPrefAdd == "Professional")
            {
                txtPrefAdd.Text = ds.Tables[0].Rows[0]["ProAdd"].ToString();
                txtPrefCity.Text = ds.Tables[0].Rows[0]["ProCity"].ToString();
                txtPrefPost.Text = ds.Tables[0].Rows[0]["ProPost"].ToString();
                txtPrefTehsil.Text = ds.Tables[0].Rows[0]["ProTehsil"].ToString();
                txtPrefPinCode.Text = ds.Tables[0].Rows[0]["ProPinCode"].ToString();
                try
                {
                    ddlPrefState.ClearSelection();
                    ddlPrefState.Items.FindByValue(ds.Tables[0].Rows[0]["ProState"].ToString()).Selected = true;
                }
                catch { }
                try
                {
                    ddlPrefState_SelectedIndexChanged(sender, e);
                    ddlPrefDistrict.ClearSelection();
                    ddlPrefDistrict.Items.FindByText(ds.Tables[0].Rows[0]["ProDistrict"].ToString()).Selected = true;
                }
                catch { }
            }
            else
            {
                txtPrefAdd.Text = ds.Tables[0].Rows[0]["PerAdd"].ToString();
                txtPrefCity.Text = ds.Tables[0].Rows[0]["PerCity"].ToString();
                txtPrefPost.Text = ds.Tables[0].Rows[0]["PerPost"].ToString();
                txtPrefTehsil.Text = ds.Tables[0].Rows[0]["PerTehsil"].ToString();
                txtPrefPinCode.Text = ds.Tables[0].Rows[0]["PerPinCode"].ToString();
                try
                {
                    ddlPrefState.ClearSelection();
                    ddlPrefState.Items.FindByValue(ds.Tables[0].Rows[0]["PerState"].ToString()).Selected = true;
                }
                catch { }
                try
                {
                    ddlPrefState_SelectedIndexChanged(sender, e);
                    ddlPrefDistrict.ClearSelection();
                    ddlPrefDistrict.Items.FindByText(ds.Tables[0].Rows[0]["PerDistrict"].ToString()).Selected = true;
                }
                catch { }
            }

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string chkCancel = "";

        if (txtSearchRegistrationNo.Text.Trim() != "")
        {
            ds = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + txtSearchRegistrationNo.Text + "' and ApplicationRequestId <> 7  and ApplicationRequestId <> 8 and ApplicationRequestId <> 9");

            if (ds.Tables[0].Rows.Count != 0)
            {
                chkCancel = ds.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
                //chkOTP = ds.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
                if (chkCancel == "9")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "CancelRegistration();", true);
                    return;
                }

                //DateTime Lvalue = DateTime.Now;
                //DateTime rValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"].ToString());
                //if (Lvalue > rValue)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "key2", "PopTemAndConditionRenew();", true);
                //    lblMSgAlert.Text = "Your registration is expired first apply for renewal registration ";
                //    return;
                //}
                btnUpdate.Enabled = true;
                hf_regno.Value = ds.Tables[0].Rows[0]["RegiNo"].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                txtEmailId.Text = ds.Tables[0].Rows[0]["Emailid"].ToString();
                hf_appno.Value = ds.Tables[0].Rows[0]["ApplicationNo"].ToString();

                if (Request.QueryString["editUPD"] != null)
                {
                    tr_idtype.Visible = false;
                    tr_idProof.Visible = false;
                }

                string getPrefAdd = ds.Tables[0].Rows[0]["PreferedAdd"].ToString();
                hf_pAddress.Value = getPrefAdd;
                if (getPrefAdd == "Residential")
                {
                    txtPrefAdd.Text = ds.Tables[0].Rows[0]["ResAdd"].ToString();
                    txtPrefCity.Text = ds.Tables[0].Rows[0]["ResCity"].ToString();
                    txtPrefPost.Text = ds.Tables[0].Rows[0]["ResPost"].ToString();
                    txtPrefTehsil.Text = ds.Tables[0].Rows[0]["ResTehsil"].ToString();
                    txtPrefPinCode.Text = ds.Tables[0].Rows[0]["ResPinCode"].ToString();
                    try
                    {
                        ddlPrefState.ClearSelection();
                        ddlPrefState.Items.FindByValue(ds.Tables[0].Rows[0]["ResState"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        ddlPrefState_SelectedIndexChanged(sender, e);
                        ddlPrefDistrict.ClearSelection();
                        ddlPrefDistrict.Items.FindByText(ds.Tables[0].Rows[0]["ResDistrict"].ToString()).Selected = true;
                    }
                    catch { }
                }
                else if (getPrefAdd == "Professional")
                {
                    txtPrefAdd.Text = ds.Tables[0].Rows[0]["ProAdd"].ToString();
                    txtPrefCity.Text = ds.Tables[0].Rows[0]["ProCity"].ToString();
                    txtPrefPost.Text = ds.Tables[0].Rows[0]["ProPost"].ToString();
                    txtPrefTehsil.Text = ds.Tables[0].Rows[0]["ProTehsil"].ToString();
                    txtPrefPinCode.Text = ds.Tables[0].Rows[0]["ProPinCode"].ToString();
                    try
                    {
                        ddlPrefState.ClearSelection();
                        ddlPrefState.Items.FindByValue(ds.Tables[0].Rows[0]["ProState"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        ddlPrefState_SelectedIndexChanged(sender, e);
                        ddlPrefDistrict.ClearSelection();
                        ddlPrefDistrict.Items.FindByText(ds.Tables[0].Rows[0]["ProDistrict"].ToString()).Selected = true;
                    }
                    catch { }
                }
                else
                {
                    txtPrefAdd.Text = ds.Tables[0].Rows[0]["PerAdd"].ToString();
                    txtPrefCity.Text = ds.Tables[0].Rows[0]["PerCity"].ToString();
                    txtPrefPost.Text = ds.Tables[0].Rows[0]["PerPost"].ToString();
                    txtPrefTehsil.Text = ds.Tables[0].Rows[0]["PerTehsil"].ToString();
                    txtPrefPinCode.Text = ds.Tables[0].Rows[0]["PerPinCode"].ToString();
                    try
                    {
                        ddlPrefState.ClearSelection();
                        ddlPrefState.Items.FindByValue(ds.Tables[0].Rows[0]["PerState"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        ddlPrefState_SelectedIndexChanged(sender, e);
                        ddlPrefDistrict.ClearSelection();
                        ddlPrefDistrict.Items.FindByText(ds.Tables[0].Rows[0]["PerDistrict"].ToString()).Selected = true;
                    }
                    catch { }
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Invalid registration no.";
            }
        }
        else
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Please enter registration no.";
        }
    }

    public void Button1_Click(object sender, EventArgs e)
    {
        if (HF_IsRedirect.Value == "0")
        {
            Response.Redirect("AdminSection/ViewQualification.aspx");
        }
        else {
            Response.Redirect("RegistrationLinkNew.aspx");
        }
       
    }
    protected void ddlPrefState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // DataSet dt1 = objdb.ByDataSet("select * from tbl_Departmentmaster where Organaizationid='" + ddlorg.SelectedValue + "'");
            DataSet dt1 = objdb.ByDataSet("select * from Districts where StateId='" + ddlPrefState.SelectedValue + "'");
            //DataSet dt1 = objdb.ByDataSet("select * from tbl_Departmentmaster where OrganaizationId='1'");
            //lblMsg.Text = dt1.Tables[0].Rows[0]["DepaertmentName"].ToString();

            ddlPrefDistrict.DataTextField = "DistrictName";
            ddlPrefDistrict.DataValueField = "DistrictId";

            ddlPrefDistrict.DataSource = dt1.Tables[0];
            ddlPrefDistrict.DataBind();
            ddlPrefDistrict.Items.Insert(0, "Select");
            ddlPrefDistrict.Focus();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }

    public DataSet StateFill()
    {
        return objdb.ByProcedure("ProcStateFill", "BYdataset");
    }

    protected void fnPrefState()
    {
        try
        {
            ddlPrefState.DataSource = StateFill();
            ddlPrefState.DataTextField = "StateName";
            ddlPrefState.DataValueField = "StateId";
            ddlPrefState.DataBind();
            ddlPrefState.Items.Insert(0, "Select");
        }
        catch (Exception ex) { lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString()); }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string file1path = "";
            if (FileUpload1.HasFile)
            {
                file1path = Guid.NewGuid() + "-" + FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file1path));
            }

            string dateofRequest = Convert.ToDateTime(DateTime.Now, cult).ToString("yyyy/MM/dd");


            ds = objdb.ByDataSet("select * from tblNewRegistration where RegiNo='" + hf_regno.Value + "'");
            if (ds.Tables[0].Rows.Count != 0)
            {
                string getPrefAdd = ds.Tables[0].Rows[0]["PreferedAdd"].ToString();
                hf_pAddress.Value = getPrefAdd;
            }



            if (Request.QueryString["editUPD"] != null)
            {
                if (hf_pAddress.Value == "Residential")
                {
                    objdb.ByText(@"update tblNewRegistration set MobileNo='" + txtMobile.Text + "', EmailId='" + txtEmailId.Text + "', ResAdd= '" + txtPrefAdd.Text + "', ResCity='" + txtPrefCity.Text + "', ResDistrict='" + ddlPrefDistrict.SelectedValue + "', ResPost='" + txtPrefPost.Text + "', ResTehsil='" + txtPrefTehsil.Text + "', ResPinCode='" + txtPrefPinCode.Text + "', ResState='" + ddlPrefState.SelectedValue + "' where RegiNo='" + hf_regno.Value + "'");
                }
                else if (hf_pAddress.Value == "Professional")
                {
                    objdb.ByText(@"update tblNewRegistration set MobileNo='" + txtMobile.Text + "', EmailId='" + txtEmailId.Text + "', ProAdd= '" + txtPrefAdd.Text + "', ProCity='" + txtPrefCity.Text + "', ProDistrict='" + ddlPrefDistrict.SelectedValue + "', ProPost='" + txtPrefPost.Text + "', ProTehsil='" + txtPrefTehsil.Text + "', ProPinCode='" + txtPrefPinCode.Text + "', ProState='" + ddlPrefState.SelectedValue + "' where RegiNo='" + hf_regno.Value + "'");
                }
                else
                {
                    objdb.ByText(@"update tblNewRegistration set MobileNo='" + txtMobile.Text + "', EmailId='" + txtEmailId.Text + "', PerAdd= '" + txtPrefAdd.Text + "', PerCity='" + txtPrefCity.Text + "', PerDistrict='" + ddlPrefDistrict.SelectedValue + "', PerPost='" + txtPrefPost.Text + "', PerTehsil='" + txtPrefTehsil.Text + "', PerPinCode='" + txtPrefPinCode.Text + "', PerState='" + ddlPrefState.SelectedValue + "' where RegiNo='" + hf_regno.Value + "'");
                }
                HF_IsRedirect.Value = "0";
                objdb.ByText(@"Update tbl_UserRequest set UserRequest = 0 where id ='" + Request.QueryString["editUPD"].ToString() + "'");
                objdb.sendOTPSms(txtMobile.Text, "Your information updated successfully");
                lblMSgAlert.Text = "Registration no. '" + hf_regno.Value + "' verified successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key2", "PopTemAndConditionRenew();", true);
            }
            else
            {
                ds = objdb.ByProcedure("ProcUserRequest", new string[] { "RegiNo", "ApplicationNo", "MobileNo", "EmailId", "PrefAdd", "PrefCity", "PrefPost", "PrefTehsil", "PrefState", "PrefDistrict", "PrefPincode", "IdentityType", "IdentityNo", "File1", "DateOfRequest", "DateOfResolveRequest", "UserRequest" },
                 new string[] { hf_regno.Value, hf_appno.Value, txtMobile.Text, txtEmailId.Text, txtPrefAdd.Text, txtPrefCity.Text, txtPrefPost.Text, txtPrefTehsil.Text, ddlPrefState.SelectedValue, ddlPrefDistrict.SelectedValue, txtPrefPinCode.Text, ddlIdentityType.SelectedItem.Text, txtIdentityNo.Text, file1path, dateofRequest, "", "1" }, "dataset");
                HF_IsRedirect.Value = "1";
               
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true);
            }
            obCommonFuction.EmptyTextBoxes(this);
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
    protected void btnNotApprove_Click(object sender, EventArgs e)
    {
        try
        {
            HF_IsRedirect.Value = "0";
            objdb.ByText(@"Update tbl_UserRequest set UserRequest = 0 where id ='" + Request.QueryString["editUPD"].ToString() + "'");
            objdb.sendOTPSms(txtMobile.Text, "Your information is not updated.plz contact MPVCI office to update information");
            lblMSgAlert.Text = "Registration no. '" + hf_regno.Value + "' verified successfully";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key2", "PopTemAndConditionRenew();", true);
        }
        catch (Exception ex)
        { 
        
        }
    }
}