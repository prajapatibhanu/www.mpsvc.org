using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class AdminSection_ComplaintVerification : System.Web.UI.Page
{
    APIProcedure obj = new APIProcedure();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["editComplaint"] != null)
            {

                BindComplaintData();
            }

            else
            {
                if (Request.QueryString["StatusID"] != null)
                {
                    BindComplaintData();
                }
            }

        }
    }

    protected void BindComplaintData()
    {

        if (Request.QueryString["editComplaint"] != null)
        {
            string[] myCompliant = Request.QueryString["editComplaint"].ToString().Split("*".ToCharArray());
            string complaint_ID = myCompliant[0];
            hfComplaintID.Value = complaint_ID;
            ds = obj.ByProcedure("SpComplainantRegistration", new String[] { "flag", "ComplaintID" }, new string[] { "7", complaint_ID }, "dataset");
        }
        else
        {
            if (Request.QueryString["StatusID"] != null)
            {

                string[] View = Request.QueryString["StatusID"].ToString().Split("*".ToCharArray());
                string ID = View[0];
                string complaint_ID = ID;
                hfComplaintID.Value = complaint_ID;

                ds = obj.ByProcedure("SpComplainantRegistration", new String[] { "flag", "ComplaintID" }, new string[] { "7", complaint_ID }, "dataset");
            }
        }

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            //Start Here Complainant Details
            txtComplainantName.Text = ds.Tables[0].Rows[0]["NameOfComplainant"].ToString();
            txtFathername.Text = ds.Tables[0].Rows[0]["FatherHusbandName"].ToString();
            txtGender.Text = ds.Tables[0].Rows[0]["GenderOfComplainant"].ToString();
            txtEmailofComplainant.Text = ds.Tables[0].Rows[0]["EmailOfComplainant"].ToString();
            txtMobileNOofComplainant.Text = ds.Tables[0].Rows[0]["MobileNoOfComplainant"].ToString();
            txtAddressOfComplainant.Text = ds.Tables[0].Rows[0]["AddressOfComplainant"].ToString();
            txtIdentityType.Text = ds.Tables[0].Rows[0]["Identity_Type"].ToString();
            txtIdentityNo.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();
            //End Here Complainant Details

            //Start Here  Details Against of Complaint
            txtnameAgainstComplaint.Text = ds.Tables[0].Rows[0]["NameAgainstComplaint"].ToString();
            txtMobilenoAgainstComplaint.Text = ds.Tables[0].Rows[0]["MobileNoAgainstComplaint"].ToString();
            txtEmailIDAgainstComplaint.Text = ds.Tables[0].Rows[0]["EmailofAgainstComplaint"].ToString();
            txtAddressAgainstComplaint.Text = ds.Tables[0].Rows[0]["ResidentialAddressofAgainstCompalint"].ToString();
            txtSVCname.Text = ds.Tables[0].Rows[0]["StateVerinaryCouncilName"].ToString();
            txtComplaintType.Text = ds.Tables[0].Rows[0]["ComplaintType"].ToString();
            txtAnimalType.Text = ds.Tables[0].Rows[0]["TypeOfAnimal"].ToString();
            txtAninmalAge.Text = ds.Tables[0].Rows[0]["AgeOfAnimal"].ToString();
            txtPlaceOfEvent.Text = ds.Tables[0].Rows[0]["PlaceOfEvent"].ToString();
            txtHospitalAddress.Text = ds.Tables[0].Rows[0]["HospitalAddress"].ToString();
            txtDetailofComplaint.Text = ds.Tables[0].Rows[0]["DetailOfComplaint"].ToString();
            //End Here  Details Against of Complaint

            //Attached Document
            hyperComplainant_IdentityDoc.NavigateUrl = ds.Tables[0].Rows[0]["Identity_Document"].ToString();
            hYprDoc1.NavigateUrl = ds.Tables[0].Rows[0]["FU_Doc1"].ToString();
            hYprDoc2.NavigateUrl = ds.Tables[0].Rows[0]["FU_Doc2"].ToString();
            hYprDoc3.NavigateUrl = ds.Tables[0].Rows[0]["Complaint_Documnet1"].ToString();
            hYprDoc4.NavigateUrl = ds.Tables[0].Rows[0]["Complaint_Documnet2"].ToString();
            hyperFeedbackDoc.NavigateUrl = ds.Tables[0].Rows[0]["Feedback_Documnet"].ToString();
            txtRegistraionType.Text = ds.Tables[0].Rows[0]["RegistrationType"].ToString();
            txtRegistrationNo.Text = ds.Tables[0].Rows[0]["RegistraionNumberAgainstComplaint"].ToString();

            if (ds.Tables[0].Rows[0]["RegistrationType"].ToString() == "हां")
            {
                DivRegistration.Visible = true;
            }
            if (ds.Tables[0].Rows[0]["Status"].ToString() != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
            {
                ddlStatus.ClearSelection();
                ddlStatus.Items.FindByText(ds.Tables[0].Rows[0]["Status"].ToString()).Selected = true;

                if (ds.Tables[0].Rows[0]["Status"].ToString() != "Pending")
                {
                    btnFeedback.Visible = true;
                }

                //if (ds.Tables[0].Rows[0]["Status"].ToString() == "Closed")
                //{
                //    btnSave.Visible = false;
                //    txtFeedback.Text = ds.Tables[0].Rows[0]["Feedback"].ToString();
                //    txtFeedback.Enabled = false;
                //    fileupFeedback.Visible = false;
                //    ddlStatus.Enabled = false;
                //}

                if(Request.QueryString["StatusID"] != null)
                {
                    txtFeedback.Text = ds.Tables[0].Rows[0]["Feedback"].ToString();
                    txtFeedback.Enabled = false;
                    ddlStatus.Enabled = false;
                    btnSave.Visible = false;
                    fileupFeedback.Visible = false;
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string FeedbackDocument = "";
            if (fileupFeedback.HasFile)
            {
                FeedbackDocument = "~/ComplaintDoc/" + Guid.NewGuid() + "-" + fileupFeedback.FileName;
                fileupFeedback.PostedFile.SaveAs(Server.MapPath(FeedbackDocument));
            }

            if (Request.QueryString["editComplaint"] != null)
            {
                if (ddlStatus.SelectedValue != "1")
                {

                    ds = obj.ByProcedure("SP_VerifyComplaints", new string[] { "flag", "ComplainantID", "Feedback", "Feedback_Documnet", "Complaint_Status", "Status" }
                        , new string[] { "1", hfComplaintID.Value, txtFeedback.Text.Trim(), FeedbackDocument, ddlStatus.SelectedItem.Text.Trim(), ddlStatus.SelectedItem.Text.Trim() }, "dataset");

                }

                if (ddlStatus.SelectedValue == "2")
                {
                    ds = obj.ByProcedure("SpComplainantRegistration", new string[] { "flag", "ComplaintID", "Feedback", "FeedbackDocument" }
                        , new string[] { "2", hfComplaintID.Value, txtFeedback.Text.Trim(), FeedbackDocument }, "dataset");
                }
            }
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string OkMsg = ds.Tables[0].Rows[0]["Msg"].ToString();
                string ErrMsg = ds.Tables[0].Rows[0]["Errormsg"].ToString();


                if (OkMsg == "OK")
                {
                    lblMsg.Text = obj.SaveAlert(ErrMsg);
                    ddlStatus.ClearSelection();
                    txtFeedback.Text = "";
                    Session["lblMsg"] = lblMsg.Text;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true); // Confirm Button
                Response.AddHeader("REFRESH", "2;URL=ActionRegistration.aspx"); // Redirect after 2 second on given url 
                
            }
            else
            {
                lblMsg.Text = obj.ErrorAlert(ds.Tables[0].Rows[0]["Errormsg"].ToString()).ToString();
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }

    protected void BindFeedback()
    {
        try
        {
            ds = obj.ByProcedure("SP_VerifyComplaints", new string[] { "flag", "ComplainantID" }, new string[] { "2", hfComplaintID.Value }, "dataset");

            if (ds.Tables[0].Rows.Count > 0)
            {
                rptFeedback.DataSource = ds;
                rptFeedback.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }

    protected void btnFeedback_Click(object sender, EventArgs e)
    {
        BindFeedback();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "openForm();", true);
    }
}