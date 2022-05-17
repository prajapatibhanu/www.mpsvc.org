using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSection_ComplainantList : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            string msg = "";
            if (txtFromDate.Text == "")
            {
                msg += "elect From Date.\\n>";
            }
            if (txtToDate.Text == "")
            {
                msg += "Select To Date.\\n";
            }

            if (msg == "")
            {
                FillGrid();
                //ds = objdb.ByProcedure("SpComplainantRegistration",
                //new string[] { "flag", "Status", "FromDate", "ToDate" },
                //new string[] { "1", ddlStatus.SelectedValue.ToString(), Convert.ToDateTime(txtFromDate.Text, cult).ToString("yyyy/MM/dd"), Convert.ToDateTime(txtToDate.Text, cult).ToString("yyyy/MM/dd") }, "dataset");
                //if (ds.Tables.Count > 0)
                //{

                //    GridView1.DataSource = ds;
                //    GridView1.DataBind();
                //}
            }
            else
            {

                // lblMsg.Text = "<span style='color:blue;'>" + msg + "</span>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alert('" + msg + "');", true);
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
        }
    }
    protected void FillGrid()
    {
        try
        {
            ds = objdb.ByProcedure("SpComplainantRegistration",
            new string[] { "flag", "Status", "FromDate", "ToDate" },
            new string[] { "1", ddlStatus.SelectedValue.ToString(), Convert.ToDateTime(txtFromDate.Text, cult).ToString("yyyy/MM/dd"), Convert.ToDateTime(txtToDate.Text, cult).ToString("yyyy/MM/dd") }, "dataset");
            if (ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();

                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;


                foreach (GridViewRow rows in GridView1.Rows)
                {

                    Label lblComplainantID = (Label)rows.FindControl("lblComplainantID");
                    Label lblFStatus = (Label)rows.FindControl("lblFStatus");
                    HyperLink hpPrint = (HyperLink)rows.FindControl("hpPrint");
                    //if(lblFStatus.Text == "Pending")
                    //{

                    //}
                    //else
                    //{

                    //}
                    hpPrint.NavigateUrl = "../Print.aspx?ComplainantID=" + Encrypt(lblComplainantID.Text);


                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "";
        }
    }


    // comment Thise Code on 5-May-2022 by bhanu As per change Request  
    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    try
    //    {
            // comment Thise Code on 5-May-2022 by bhanu As per change Request  
            //string msg = "";
            //lblMComplaintDate.Text = "";
            //lblMNameOfComplainant.Text = "";
            //lblMFatherHusbandName.Text = "";
            //lblMcompalaint.Text = "";  // add by bhanu on 24-03-2022
            //lblMagainstofComplaint.Text = "";   // add by bhanu on 24-03-2022

            //string ComplainantID = GridView1.SelectedDataKey.Value.ToString();
            //int rowindex = int.Parse(GridView1.SelectedRow.RowIndex.ToString());
            //ViewState["ComplainantID"] = ComplainantID;

       

            //Label lblComplaintNo = (Label)GridView1.Rows[rowindex].Cells[3].FindControl("lblComplaintNo");
            //Label lblComplaintDate = (Label)GridView1.Rows[rowindex].Cells[4].FindControl("lblComplaintDate");
            //Label lblNameOfComplainant = (Label)GridView1.Rows[rowindex].Cells[5].FindControl("lblNameOfComplainant");
            //Label lblFatherHusbandName = (Label)GridView1.Rows[rowindex].Cells[6].FindControl("lblFatherHusbandName");
            //Label lblcompalaint = (Label)GridView1.Rows[rowindex].Cells[16].FindControl("lblDetailOfComplaint");
            //Label lblNameAgainstComplaint = (Label)GridView1.Rows[rowindex].Cells[17].FindControl("lblNameAgainstComplaint");

            //lblMComplaintNo.Text = lblComplaintNo.Text;
            //lblMComplaintDate.Text = lblComplaintDate.Text;
            //lblMNameOfComplainant.Text = lblNameOfComplainant.Text;
            //lblMFatherHusbandName.Text = lblFatherHusbandName.Text;

            //lblMcompalaint.Text = lblcompalaint.Text; // add by bhanu on 24-03-2022
            //lblMagainstofComplaint.Text = lblNameAgainstComplaint.Text; // add by bhanu on 24-03-2022

            //GridViewBillByBillViewDetail.DataSource = dsBillByBill.Tables[RowNo.ToString()]; // thise line Already Commneted
            //GridViewBillByBillViewDetail.DataBind(); // thise line Already Commneted
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowFeedbackModalModal();", true);
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = "";
    //    }
    //}

    // comment Thise Code on 5-May-2022 by bhanu As per change Request
    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        string msg = "";
    //        if (txtFeedback.Text != "")
    //        {
    //            string FeedbackDocument = "";
    //            if (FU_FeedbackDocument.HasFile)
    //            {
    //                FeedbackDocument = "ComplaintDoc/" + Guid.NewGuid() + "-" + FU_FeedbackDocument.FileName;
    //                FU_FeedbackDocument.PostedFile.SaveAs(Server.MapPath("~/" + FeedbackDocument));
    //            }

    //            ds = objdb.ByProcedure("SpComplainantRegistration",
    //              new string[] { "flag", "ComplaintID", "Feedback", "FeedbackDocument" },
    //              new string[] { "2", ViewState["ComplainantID"].ToString(), txtFeedback.Text, FeedbackDocument }, "dataset");

    //            FillGrid();

    //            lblMsg.Text = "<span style='color:green; font-size:17px;font-weight: 600;'>Feedback Succeessfully submitted.</span>";
    //        }
    //        else
    //        {
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ShowFeedbackModalModal();", true);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = "";
    //    }
    //}
    // comment Thise Code on 5-May-2022 by bhanu As per change Request
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
    //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {

    //        if (e.CommandName == "select")
    //        {
    //            string VoucherTx_ID = e.CommandArgument.ToString();

    //        }

    //        if (e.CommandName == "Print")
    //        {

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = "";
    //    }
    //}
    //protected void btnDetail_Click(object sender, EventArgs e) // Create Event for View All Details Of Complainant 
    //{                                                         // By bhanu on 5-May- 2022 due to Change Request.

    //    LinkButton lnkID = (LinkButton)(sender);
    //    int ID = 0;
    //    Int32.TryParse(lnkID.CommandArgument, out ID);
    //    Response.Redirect("~/AdminSection/ComplaintVerification.aspx?ID=" + ID);
    //}
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer); 

            if(e.CommandName == "btnView")
            {
                LinkButton btn = (LinkButton)row.FindControl("btnDetail");
                string StatusID = btn.CommandArgument;
                Response.Redirect("~/AdminSection/ComplaintVerification.aspx?StatusID=" + StatusID);
            }
        }
        catch(Exception ex)
        {
            lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString());
        }
    }
}