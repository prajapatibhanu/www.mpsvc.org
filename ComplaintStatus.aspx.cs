using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ComplaintStatus : System.Web.UI.Page
{
    APIProcedure obj = new APIProcedure();
    DataSet ds = new DataSet();
         
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           
            
        }
       
    }
   
    protected void binddetails()
    {
        try
        {
            lblMsg.Text = "";
            dtlcomplaitnant.DataSource = null;
            dtlcomplaitnant.DataBind();

            ds = obj.ByProcedure("SpComplainantRegistration", new string[] { "flag", "ComplaintNo", "MobileNoOfComplainant" }
                , new string[] { "4", txtcomplaintno.Text, txtmobileno.Text }, "dataset");

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
             
                if (ds != null && ds.Tables[0].Rows.Count > 0) //Bind शिकायतकर्ता की जानकारी in (Details View one)
                {
                    dtlcomplaitnant.DataSource = ds;
                    dtlcomplaitnant.DataBind();

                }

                dtlagainstofComplaint.DataSource = null;
                dtlagainstofComplaint.DataBind();
                if (ds != null && ds.Tables[0].Rows.Count > 0) // Bind जिसके बिरुद्ध शिकायत की गई उसकी जानकारी in (Details View Two)
                {
                    dtlagainstofComplaint.DataSource = ds;
                    dtlagainstofComplaint.DataBind();
                }

                //Dtlfeedback.DataSource = null; // START Here Comment this As per change request on 6-may-22
                //Dtlfeedback.DataBind();
                //DivFeedback.Visible = false;
                //if (ds.Tables[0].Rows[0]["Feedback"].ToString() != "" && ds.Tables[0].Rows[0]["FeedbackDocument"].ToString() != "") // Bind निराकरण अधिकारी द्वारा की गई कार्यवाही in (Details View Three)
                //{
                //    Dtlfeedback.DataSource = ds;
                //    Dtlfeedback.DataBind();
                //    DivFeedback.Visible = true;
                //}
                //else
                //{
                //    Dtlfeedback.DataSource = null;
                //    Dtlfeedback.DataBind();
                //    DivFeedback.Visible = false;
                //}   // START Here Comment this As per change request on 6-may-22

              
                grdLastFeedback.DataSource = null;
                grdLastFeedback.DataBind();

                if(ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    grdLastFeedback.DataSource = ds;
                    grdLastFeedback.DataBind();
                   
                }
            }
            else 
            {
               
                lblMsg.Text = obj.EmptyAlert("Data Not Found");
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
           binddetails();
        }
        catch(Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
   
}
