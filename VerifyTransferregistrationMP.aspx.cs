using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class VerifyTransferregistrationMP : System.Web.UI.Page
{
  
    CultureInfo cult = new CultureInfo("gu-IN", true);
    APIProcedure obj = new APIProcedure();
    DataSet ds,ds1,ds2 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack)
       {
          verifyForm();
           string validaity = DateTime.Now.ToString("dd/MM/yyyy");
           string dd = DateTime.Now.ToString("dd/MM/yyyy");
           string ddate = DateTime.Now.ToString("dd/MM/yyyy");
           string sd = ddate.Replace("-", "/");
           string bs = dd.Replace("-", "/");
           string ms = validaity.Replace("-", "/");
           txtDOBb.Text = sd;
           txtdate.Text = bs;
           txtValidity.Text = ms;
       }
    }

    protected void verifyForm()
    {
        try
        {
            
            string arr = Request.QueryString["var"].ToString();
                string Tid = arr;
                //string tblid = Request.QueryString["var"];
                ds = obj.ByProcedure("USP_TransferRegistrationOutMP_Update", new string[] { "flag", "id" }
                                , new string[] { "4", Tid }, "dataset");


                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    //lblID.Text = ds.Tables[0].Rows[0]["id"].ToString();
                    txtApplicant.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtFHname.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                    txtDOBb.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                    txtgenderName.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                    txtDegree.Text = ds.Tables[0].Rows[0]["DegreeName"].ToString();
                    txtCollegeName.Text = ds.Tables[0].Rows[0]["CollegeName"].ToString();
                    txtuniversityName.Text = ds.Tables[0].Rows[0]["UniversityName"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["ResAdd"].ToString();
                    txtMobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    txtEmailID.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                    txtNameofsvp.Text = ds.Tables[0].Rows[0]["State_Veterinary_Council_namepresent"].ToString();
                    txtReginumber.Text = ds.Tables[0].Rows[0]["RegiNo"].ToString();
                    txtValidity.Text = ds.Tables[0].Rows[0]["Validity_Registration"].ToString();
                    txtState.Text = ds.Tables[0].Rows[0]["PreferedAdd"].ToString();
                    txtDDno.Text = ds.Tables[0].Rows[0]["ChequeNo"].ToString();
                    txtDrwan.Text = ds.Tables[0].Rows[0]["Drawn_name_DD"].ToString();
                    txtdate.Text = ds.Tables[0].Rows[0]["ChequeDate"].ToString();
                    txtBank.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                    txtBranch.Text = ds.Tables[0].Rows[0]["Bank_Branch_Name"].ToString();
                    txtreason.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                    txtNameofCouncil.Text = ds.Tables[0].Rows[0]["Registrar_Name"].ToString();
                    txtaddressd.Text = ds.Tables[0].Rows[0]["Registrar_Adresse"].ToString();
                    ApplicantIMG.ImageUrl = ds.Tables[0].Rows[0]["File3"].ToString();
                    ApplicantBirthProof.ImageUrl = ds.Tables[0].Rows[0]["File5"].ToString();
                    ApplicantDD.ImageUrl = ds.Tables[0].Rows[0]["File1"].ToString();
                    ApplicantDegree.ImageUrl = ds.Tables[0].Rows[0]["File2"].ToString();
                    ApplicantSign.ImageUrl = ds.Tables[0].Rows[0]["FileRenew1"].ToString();
                    ApplicantRegistrationCert.ImageUrl = ds.Tables[0].Rows[0]["File4"].ToString();

                }
            }

      
        catch (Exception ex)
        {

            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }

    //protected void VerifyUpdate()
    //{
    //    try
    //    {
    //        string isOnline = "";
    //        string regStatus = "";
    //        if (rboffline.Checked == true)
    //        {
    //            isOnline = "0";
    //        }
    //        else
    //        {
    //            isOnline = "1";
    //        }
    //        if (Request.QueryString["var"] != null)
    //        {
    //            regStatus = "2";
    //            if (Session["IsVerify"] != null)
    //            {
    //                if (Session["var"].ToString() == "1")
    //                {
    //                    regStatus = "3";
    //                }
    //            }
    //        }
    //        else
    //        {
    //            regStatus = "1";
    //        }

    //        if (Request.QueryString["var"] != null)
    //        {
    //             if (rboffline.Checked == true)
    //             {
    //                 ds = obj.ByProcedure("USP_registrationOutofMPAdmin1", new string[] { "flag","FName","FatherName","DOB","Gender","ResAdd","MobileNo","EmailId",
    //                            "University1","CollegeID1", "DegreeName", "Isonline", "ChequeNo" , "BankName", "ChequeDate" , "RegistrationStatus" , "ApplicationRequestId", "Transferstateid"  , "Remark"  , "State_Veterinary_Council_namepresent", "Drawn_name_DD" , "Registrar_Name", "Registrar_Adresse" , "Bank_Branch_Name" , "Validity_Registration"  }
    //                               , new string[] { "1", txtApplicant.Text.Trim(), txtFHname.Text.Trim(),Convert.ToDateTime(txtDOBb.Text, cult).ToString("yyyy/MM/dd"), txtgenderName.Text.Trim(), txtAddress.Text.Trim(), txtMobileno.Text.Trim(), txtEmailID.Text.Trim(), txtuniversityName.Text.Trim(), txtCollegeName.Text.Trim(), txtDegree.Text.Trim(), isOnline, txtDDno.Text.Trim(), txtBank.Text.Trim(),
    //                                    Convert.ToDateTime(txtdate.Text, cult).ToString("yyyy/MM/dd"), regStatus, "1",txtState.Text.Trim(),txtreason.Text.Trim(),txtNameofsvp.Text.Trim(), txtDrwan.Text.Trim(), txtNameofCouncil.Text.Trim(), txtaddressd.Text.Trim(), txtBranch.Text.Trim(), Convert.ToDateTime(txtValidity.Text, cult).ToString("yyyy/MM/dd") }, "dataset");
    //             }
    //             else
    //             {
    //                 ds = obj.ByProcedure("USP_registrationOutofMPAdmin1", new string[] { "flag","FName","FatherName","DOB","Gender","ResAdd","MobileNo","EmailId",
    //                            "University1","CollegeID1", "DegreeName", "Isonline", "ChequeNo" , "BankName", "ChequeDate" , "RegistrationStatus" , "ApplicationRequestId", "Transferstateid"  , "Remark"  , "State_Veterinary_Council_namepresent", "Drawn_name_DD" , "Registrar_Name", "Registrar_Adresse" , "Bank_Branch_Name" , "Validity_Registration"  }
    //                               , new string[] { "1", txtApplicant.Text.Trim(), txtFHname.Text.Trim(),Convert.ToDateTime(txtDOBb.Text, cult).ToString("yyyy/MM/dd"), txtgenderName.Text.Trim(), txtAddress.Text.Trim(), txtMobileno.Text.Trim(), txtEmailID.Text.Trim(), txtuniversityName.Text.Trim(), txtCollegeName.Text.Trim(), txtDegree.Text.Trim(), isOnline, txtDDno.Text.Trim(), txtBank.Text.Trim(),
    //                                    Convert.ToDateTime(txtdate.Text, cult).ToString("yyyy/MM/dd"), regStatus, "1",txtState.Text.Trim(),txtreason.Text.Trim(),txtNameofsvp.Text.Trim(), txtDrwan.Text.Trim(), txtNameofCouncil.Text.Trim(), txtaddressd.Text.Trim(), txtBranch.Text.Trim(), Convert.ToDateTime(txtValidity.Text, cult).ToString("yyyy/MM/dd") }, "dataset");
    //             }
    //             if (ds != null && ds.Tables[0].Rows.Count > 0)
    //             {
    //                 string MSg = ds.Tables[0].Rows[0]["Msg"].ToString();
    //                 string ErrMsg = ds.Tables[0].Rows[0]["ErrMSg"].ToString();

    //                 if(MSg == "")
    //                 {
    //                     lblMsg.Text = obj.SaveAlert(ds.Tables[0].Rows[0]["ErrMSg"].ToString());
    //                 }
    //                 else
    //                 {
    //                     lblMsg.Text = obj.SaveAlert(ds.Tables[0].Rows[0]["ErrMSg"].ToString());
    //                 }
    //             }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //    }
    //}


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
     
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {

            string isOnline = "";
            string regStatus = "";
            string Validity = Convert.ToDateTime(txtValidity.Text, cult).ToString("yyyy/MM/dd");
            string dob = Convert.ToDateTime(txtDOBb.Text, cult).ToString("yyyy/MM/dd");
            string mydate = Convert.ToDateTime(txtdate.Text, cult).ToString("yyyy/MM/dd");
            

            if (rboffline.Checked == true)
            {
                isOnline = "0";
            }
            else
            {
                isOnline = "1";
            }
            if (Request.QueryString["var"] != null)
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

            if (Request.QueryString["var"] != null)
            {
                
                string arr = Request.QueryString["var"].ToString();
                string Tid = arr;
                //DataSet ds1 = obj.ByProcedure("UpdateVerication", new string[] { "flag", "id" }, new string[] { "2", Tid }, "dataset");
              

                if (rboffline.Checked == true)
                {
                    ds = obj.ByProcedure("UpdateVerication", new string[] { "flag", "RegistrationStatus", "id" }, new string[] { "1", regStatus, Tid }, "dataset");
                   
                    ds2 = obj.ByProcedure("USP_TransferRegisMP_trasanctiondtl", new string[] { "flag", "RegistrationStatus", "Id" }, new string[] { "2", regStatus, Tid }, "dataset");
                }
                else
                {
                    ds = obj.ByProcedure("UpdateVerication", new string[] { "flag", "RegistrationStatus", "id" }, new string[] { "1", regStatus, Tid }, "dataset");
                   
                    ds2 = obj.ByProcedure("USP_TransferRegisMP_trasanctiondtl", new string[] { "flag", "RegistrationStatus", "Id" }, new string[] { "2", regStatus, Tid }, "dataset");
                }
            }
                if (ds.Tables[0].Rows[0]["Msg"].ToString() == "Ok")
                {
                    string ErrMSg = ds.Tables[0].Rows[0]["ErrMSg"].ToString();
                    //lblMsg.Text = obj.SaveAlert(ErrMSg);

                    if (Request.QueryString["var"] != null)
                    {
                        string arr = Request.QueryString["var"].ToString();
                        string Tid = arr;

                        if (regStatus == "3")
                        {
                            DataSet dsMail = obj.ByProcedure("UpdateVerication", new string[] { "flag", "id" }, new string[] { "2", Tid }, "dataset");
                            string regno = dsMail.Tables[0].Rows[0]["RegiNo"].ToString();
                            string validity = Convert.ToDateTime(dsMail.Tables[0].Rows[0]["Validity_Registration"], cult).ToString("dd/MM/yyyy"); 

                            lblalert.Text = "Registration no. '" + regno + "' verified successfully valid upto '" + validity + "' ";
                        }

                        else
                        {
                            lblalert.Text = "Application forwarded for second level verification.";

                        }
                        HFOK.Value = "0";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopTemAndConditionOnSave();", true);
                    }

                    //else
                    //{
                    //    lblMsg.Text = obj.SaveAlert(ds.Tables[0].Rows[0]["ErrMSg"].ToString());
                    //}
                }
                else
                {
                    lblMsg.Text = obj.ErrorAlert(ds.Tables[0].Rows[0]["ErrMSg"].ToString());
                }

        }

        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }

    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        if(HFOK.Value == "0")
        {
            if (Session["IsVerify"] != null)
            {

                if (Session["IsVerify"].ToString() == "1")
                {
                    Response.Redirect("~/AdminSection/FrmSecondLevelValid.aspx", false);

                }

                else
                {

                    Response.Redirect("~/AdminSection/ActionRegistration.aspx", false);
                }
            }
        }
    }
}