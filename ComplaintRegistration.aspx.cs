using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class ComplaintRegistration : System.Web.UI.Page
{

    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ComplaintForm.Visible = false;
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            string msg = "";

            if (txtNameOfComplainant.Text == "")
            {
                msg += "शिकायतकर्ता का नाम दर्ज करें.<br/>";
            }
            if (txtFatherHusbandName.Text == "")
            {
                msg += "शिकायतकर्ता का पिता / पति का नाम दर्ज करें.<br/>";
            }
            if (ddlGenderOfComplainant.SelectedIndex == 0)
            {
                msg += "लिंग चुनें.<br/>";
            }
            if (txtMobileNoOfComplainant.Text == "")
            {
                msg += "शिकायतकर्ता का मोबाइल नं. दर्ज करें.<br/>";
            }
            if (txtAddressOfComplainant.Text == "")
            {
                msg += "शिकायतकर्ता का पूरा पता दर्ज करें.<br/>";
            }


            if (ddlComplaintType.SelectedIndex == 0)
            {
                msg += "शिकायत का प्रकार चुनें.<br/>";
            }
            if (txtDetailOfComplaint.Text == "")
            {
                msg += "शिकायत का संक्षिप्त विवरण दर्ज करें.<br/>";
            }
            if (txtNameAgainstComplaint.Text == "")
            {
                msg += "जिसके विरुद्ध शिकायत की जा रही है उसका नाम दर्ज करें.<br/>";
            }

            if (ddlRegistrationType.Text == "")
            {
                msg += "क्या वह रजिस्टर्ड डॉक्टर है  चुनें.<br/>";
            }
            if (ddlPersonalID.SelectedIndex == 0)
            {
                msg += "आवेदक पहचान पत्र.<br/>";
            }
            if (ddlPersonalID.SelectedIndex > 0)
            {
                if (txtIdentity.Text == "")
                {
                    msg += "कृपया अपना पहचान क्रमांक दर्ज करें.<br/> ";
                }
            }
            if (FileupIdentity_DOC.HasFile == false)
            {
                msg += "आवेदक पहचान पत्र दस्तावेज.<br/>";
            }
            if (msg == "")
            {

                string FU_Doc1Name = "";
                if (FU_Doc1.HasFile)
                {
                    FU_Doc1Name = "~/ComplaintDoc/" + Guid.NewGuid() + "-" + FU_Doc1.FileName;
                    FU_Doc1.PostedFile.SaveAs(Server.MapPath(FU_Doc1Name));
                }

                string FU_Doc2Name = "";
                if (FU_Doc2.HasFile)
                {
                    FU_Doc2Name = "~/ComplaintDoc/" + Guid.NewGuid() + "-" + FU_Doc2.FileName;
                    FU_Doc2.PostedFile.SaveAs(Server.MapPath(FU_Doc2Name));
                }
                string ComplaintDocument = "";
                if (filupDoc1.HasFile)
                {
                    ComplaintDocument = "~/ComplaintDoc/" + Guid.NewGuid() + "-" + filupDoc1.FileName;
                    filupDoc1.PostedFile.SaveAs(Server.MapPath(ComplaintDocument));
                }
                string ComplaintDocument2 = "";
                if (FilupDoc2.HasFile)
                {
                    ComplaintDocument2 = "~/ComplaintDoc/" + Guid.NewGuid() + "-" + FilupDoc2.FileName;
                    FilupDoc2.PostedFile.SaveAs(Server.MapPath(ComplaintDocument2));
                }
                string FileupIdentityDOC = "";
                if (FileupIdentity_DOC.HasFile)
                {
                    FileupIdentityDOC = "~/ComplaintDoc/" + Guid.NewGuid() + "-" + FileupIdentity_DOC.FileName;
                    FileupIdentity_DOC.PostedFile.SaveAs(Server.MapPath(FileupIdentityDOC));
                }
                string AadharNo = "";
                if (txtIdentity.Text != "")
                {
                    AadharNo = Encrypt(txtIdentity.Text);
                }
                //ds = objdb.ByProcedure("SpComplainantRegistration",
                //   new string[] { "flag", "NameOfComplainant","FatherHusbandName","GenderOfComplainant","MobileNoOfComplainant","EmailOfComplainant","AadharNo","AddressOfComplainant","ComplaintType"
                //       ,"DetailOfComplaint","NameAgainstComplaint","MobileNoAgainstComplaint","RegistrationType","FU_Doc1","FU_Doc2","OtherRemark" 
                //        ,"TypeOfAnimal","AgeOfAnimal","PlaceOfEvent","HospitalAddress"},
                //   new string[] { "0", txtNameOfComplainant.Text, txtFatherHusbandName.Text, ddlGenderOfComplainant.SelectedValue.ToString(), txtMobileNoOfComplainant.Text, txtEmailOfComplainant.Text,txtAadharNo.Text,txtAddressOfComplainant.Text, ddlComplaintType.SelectedValue.ToString()
                //       , txtDetailOfComplaint.Text, txtNameAgainstComplaint.Text, txtMobileNoAgainstComplaint.Text, ddlRegistrationType.SelectedValue.ToString(), FU_Doc1Name, FU_Doc2Name, txtOtherRemark.Text
                //        , ddlTypeOfAnimal.SelectedValue.ToString(), txtAgeOfAnimal.Text , txtPlaceOfEvent.Text , txtHospitalAddress.Text }, "dataset");
                ds = objdb.ByProcedure("SpComplainantRegistration",
                 new string[] { "flag", "NameOfComplainant","FatherHusbandName","GenderOfComplainant","MobileNoOfComplainant","EmailOfComplainant","AadharNo",
                                 "AddressOfComplainant","ComplaintType","DetailOfComplaint","NameAgainstComplaint","MobileNoAgainstComplaint","RegistrationType",
                                 "FU_Doc1","FU_Doc2","OtherRemark", "TypeOfAnimal","AgeOfAnimal","PlaceOfEvent","HospitalAddress","EmailofAgainstComplaint",
                                 "RegistraionNumberAgainstComplaint", "StateVerinaryCouncilName","ResidentialAddressofAgainstCompalint","Complaint_Documnet1"
                                 ,"Complaint_Documnet2","Identity_Type", "Identity_Document"},
                 new string[] { "0", txtNameOfComplainant.Text, txtFatherHusbandName.Text, ddlGenderOfComplainant.SelectedValue.ToString(), txtMobileNoOfComplainant.Text,
                                 txtEmailOfComplainant.Text,txtIdentity.Text,txtAddressOfComplainant.Text, ddlComplaintType.SelectedValue.ToString(), txtDetailOfComplaint.Text
                                 , txtNameAgainstComplaint.Text, txtMobileNoAgainstComplaint.Text, ddlRegistrationType.SelectedValue.ToString(), FU_Doc1Name, FU_Doc2Name,
                                 txtOtherRemark.Text, ddlTypeOfAnimal.SelectedValue.ToString(), txtAgeOfAnimal.Text , txtPlaceOfEvent.Text , txtHospitalAddress.Text,txtEmailID.Text.Trim()
                                 ,txtRegno.Text.Trim(), txtSVC.Text.Trim(),txtresidential.Text.Trim(), ComplaintDocument, ComplaintDocument2, ddlPersonalID.SelectedItem.Text, FileupIdentityDOC }, "dataset");

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alert('आपकी शिकायत सफलता पूर्वक दर्ज हुई| आपका शिकायत क्रमांक '" + ds.Tables[0].Rows[0]["ComplaintNo"].ToString() + "' है |');", true);

                    lblMsg.Text = "<span style='color:green; font-size:17px;font-weight: 600;'>आपकी शिकायत सफलता पूर्वक दर्ज हुई| आपका शिकायत क्रमांक '" + ds.Tables[0].Rows[0]["ComplaintNo"].ToString() + "'और आपका मोबाइल नंबर '" + ds.Tables[0].Rows[0]["MobileNoof_Complainant"].ToString() + "' है |</span>";

                    txtNameOfComplainant.Text = "";
                    txtFatherHusbandName.Text = "";
                    ddlGenderOfComplainant.ClearSelection();
                    txtMobileNoOfComplainant.Text = ""; txtEmailOfComplainant.Text = "";
                    txtIdentity.Text = "";
                    txtAddressOfComplainant.Text = "";
                    ddlComplaintType.ClearSelection();
                    txtDetailOfComplaint.Text = "";
                    txtNameAgainstComplaint.Text = ""; txtMobileNoAgainstComplaint.Text = "";
                    ddlRegistrationType.ClearSelection();
                    txtOtherRemark.Text = "";
                    txtEmailID.Text = "";
                    txtRegno.Text = "";
                    txtresidential.Text = "";
                    txtSVC.Text = "";
                    ddlTypeOfAnimal.ClearSelection();
                    txtAgeOfAnimal.Text = "";
                    txtPlaceOfEvent.Text = "";
                    txtHospitalAddress.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true);
                    btnprint_Click(sender, e);
                }

                ComplaintForm.Visible = false;
            }
            else
            {

                lblMsg.Text = "<span style='color:blue;'>" + msg + "</span>";

            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }
    protected string Encrypt(string sData)
    {

        string EncryptionKey = "%&$:";
        byte[] clearBytes = Encoding.Unicode.GetBytes(sData.Replace(" ", ""));
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64 });//, 0x76, 0x65, 0x64, 0x65, 0x76 
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                sData = Convert.ToBase64String(ms.ToArray());
            }
        }
        return sData;
    }
    protected string Decrypt(string sData)
    {

        string EncryptionKey = "%&$:";
        byte[] cipherBytes = Convert.FromBase64String(sData.Replace(" ", "+"));
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                sData = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return sData;
    }
    protected void btnOtpGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            string SendOTP = "";
            if (txtMobileNo.Text.Trim() != null)
            {
                SendOTP = objdb.Send_OTP(txtMobileNo.Text);
                lblMobilealert.Text = " Does " + txtMobileNo.Text + " really belong to you? ";
            }
            ViewState["OTPSend"] = SendOTP;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPVerification();", true);
        }
        catch (Exception ex)
        {
            lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void btnSaveotp_Click(object sender, EventArgs e)
    {
        try
        {
            string OTP = txtOTP.Text;
            string SendOTP;
            SendOTP = ViewState["OTPSend"].ToString();
            if (SendOTP == OTP)
            {
                ViewState["OTPSend"] = null;
                lblOTPInvalid.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPNotVerified();", true);
                ComplaintForm.Visible = true;
                txtMobileNoOfComplainant.Text = txtMobileNo.Text;
                hideotp.Visible = false;

            }
            else
            {
                lblOTPInvalid.Text = "* Invalid OTP.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPVerification();", true);
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString());
        }
    }

    protected void ddlRegistrationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRegistrationType.SelectedItem.Text == "हां")
        {
            regino.Visible = true;
        }
        else
        {
            regino.Visible = false;

        }
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {

            ds = objdb.ByProcedure("SpComplainantRegistration",
             new string[] { "flag" },
             new string[] { "5" }, "dataset");
            if (ds.Tables.Count > 0)
            {

                lblComplaintNO.Text = ds.Tables[0].Rows[0]["ComplaintNo"].ToString();
                lblapllicantname.Text = ds.Tables[0].Rows[0]["NameOfComplainant"].ToString();
                lblApplicantFH.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
                lblEmailIDofComplainant.Text = ds.Tables[0].Rows[0]["EmailOfComplainant"].ToString();
                lblMObileOFComplainant.Text = ds.Tables[0].Rows[0]["MobileNoOfComplainant"].ToString();
                lblFullAddressofComplainant.Text = ds.Tables[0].Rows[0]["AddressOfComplainant"].ToString();
                lblnameAgainstComplaint.Text = ds.Tables[0].Rows[0]["NameAgainstComplaint"].ToString();
                lblregino.Text = ds.Tables[0].Rows[0]["RegistraionNumberAgainstComplaint"].ToString();
                lblSVC.Text = ds.Tables[0].Rows[0]["StateVerinaryCouncilName"].ToString();
                lblresidentialAddress.Text = ds.Tables[0].Rows[0]["ResidentialAddressofAgainstCompalint"].ToString();
                lblhospitaladdress.Text = ds.Tables[0].Rows[0]["HospitalAddress"].ToString();
                lbltelephonmobile.Text = ds.Tables[0].Rows[0]["MobileNoAgainstComplaint"].ToString();
                lblEmailOfAgainstComplaint.Text = ds.Tables[0].Rows[0]["EmailofAgainstComplaint"].ToString();
                lblplaceofEvent.Text = ds.Tables[0].Rows[0]["PlaceOfEvent"].ToString();
                lblNatureofComplaint.Text = ds.Tables[0].Rows[0]["ComplaintType"].ToString();
                lblDetailofComplaint.Text = ds.Tables[0].Rows[0]["DetailOfComplaint"].ToString();
                lblcomplaintrelation.Text = ds.Tables[0].Rows[0]["TypeOfAnimal"].ToString();
                lblAnimalAge.Text = ds.Tables[0].Rows[0]["AgeOfAnimal"].ToString();
                lblIdProof.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();
                lblIDType.Text = ds.Tables[0].Rows[0]["Identity_Type"].ToString();
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "window.print('Divprint');", true);

        }
        catch (Exception ex)
        {

            lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void ddlPersonalID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPersonalID.SelectedValue == "0")
        {
            Identity.Visible = false;
        }
        else
        {
            Identity.Visible = true;
        }
    }
}