using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    DataSet ds;
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ComplainantID"] != null)
        {
            string ComplainantID = Decrypt(Request.QueryString["ComplainantID"].ToString());
            ds = objdb.ByProcedure("SpComplainantRegistration",
              new string[] { "flag", "ComplaintID" },
              new string[] { "3", ComplainantID }, "dataset");
            if (ds.Tables.Count > 0)
            {
                //lblComplaintNo.Text = ds.Tables[0].Rows[0]["ComplaintNo"].ToString();
                //lblComplaintDate.Text = ds.Tables[0].Rows[0]["ComplaintDate"].ToString();
                //lblNameOfComplainant.Text = ds.Tables[0].Rows[0]["NameOfComplainant"].ToString();
                //lblFatherHusbandName.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
                //lblGenderOfComplainant.Text = ds.Tables[0].Rows[0]["GenderOfComplainant"].ToString();
                //lblMobileNoOfComplainant.Text = ds.Tables[0].Rows[0]["MobileNoOfComplainant"].ToString();
                //lblEmailOfComplainant.Text = ds.Tables[0].Rows[0]["EmailOfComplainant"].ToString();
                ////  lblAadharNo.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();
                //lblAddressOfComplainant.Text = ds.Tables[0].Rows[0]["AddressOfComplainant"].ToString();
                //lblComplaintType.Text = ds.Tables[0].Rows[0]["ComplaintType"].ToString();
                //lblDetailOfComplaint.Text = ds.Tables[0].Rows[0]["DetailOfComplaint"].ToString();
                //lblNameAgainstComplaint.Text = ds.Tables[0].Rows[0]["NameAgainstComplaint"].ToString();
                //lblMobileNoAgainstComplaint.Text = ds.Tables[0].Rows[0]["MobileNoAgainstComplaint"].ToString();
                //lblRegistrationType.Text = ds.Tables[0].Rows[0]["RegistrationType"].ToString();
                //lblOtherRemark.Text = ds.Tables[0].Rows[0]["OtherRemark"].ToString();
                //lblStatus.Text = ds.Tables[0].Rows[0]["FStatus"].ToString();
                //lblTypeOfAnimal.Text = ds.Tables[0].Rows[0]["TypeOfAnimal"].ToString();
                //lblAgeOfAnimal.Text = ds.Tables[0].Rows[0]["AgeOfAnimal"].ToString();
                //lblPlaceOfEvent.Text = ds.Tables[0].Rows[0]["PlaceOfEvent"].ToString();
                //lblHospitalAddress.Text = ds.Tables[0].Rows[0]["HospitalAddress"].ToString();

                //START HERE Comment Old Code by bhanu on 23 Apr 22 And Start new as per Change requsest 
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
                lblIdtype.Text = ds.Tables[0].Rows[0]["Identity_Type"].ToString();
                lblIdProof.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();
                //END HERE Comment Old Code by bhanu on 23 Apr 22 And Start new as per Change requsest                                                 
            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }

       
          ds = objdb.ByProcedure("SpComplainantRegistration",new string[] { "flag" },new string[] { "5" }, "dataset");
                
        if(ds!= null &&ds.Tables[0].Rows.Count>0)
        {
            lblComplaintNO.Text = ds.Tables[0].Rows[0]["ComplaintNo"].ToString();
            lblapllicantname.Text = ds.Tables[0].Rows[0]["NameOfComplainant"].ToString();
            lblApplicantFH.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
            lblEmailIDofComplainant.Text = ds.Tables[0].Rows[0]["EmailOfComplainant"].ToString();
            lblMObileOFComplainant.Text = ds.Tables[0].Rows[0]["MobileNoOfComplainant"].ToString();
            lblFullAddressofComplainant.Text = ds.Tables[0].Rows[0]["AddressOfComplainant"].ToString();
            lblnameAgainstComplaint.Text = ds.Tables[0].Rows[0]["NameAgainstComplaint"].ToString();
            lblSVC.Text = ds.Tables[0].Rows[0]["RegistraionNumberAgainstComplaint"].ToString();
            lblresidentialAddress.Text = ds.Tables[0].Rows[0]["ResidentialAddressofAgainstCompalint"].ToString();
            lblhospitaladdress.Text = ds.Tables[0].Rows[0]["HospitalAddress"].ToString();
            lbltelephonmobile.Text = ds.Tables[0].Rows[0]["MobileNoAgainstComplaint"].ToString();
            lblEmailOfAgainstComplaint.Text = ds.Tables[0].Rows[0]["EmailofAgainstComplaint"].ToString();
            lblplaceofEvent.Text = ds.Tables[0].Rows[0]["PlaceOfEvent"].ToString();
            lblNatureofComplaint.Text = ds.Tables[0].Rows[0]["ComplaintType"].ToString();
            lblDetailofComplaint.Text = ds.Tables[0].Rows[0]["DetailOfComplaint"].ToString();
            lblcomplaintrelation.Text = ds.Tables[0].Rows[0]["TypeOfAnimal"].ToString();
            lblAnimalAge.Text = ds.Tables[0].Rows[0]["AgeOfAnimal"].ToString();
        }
        
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
}