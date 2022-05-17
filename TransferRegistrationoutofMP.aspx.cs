using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Drawing;
using System.Net.Mail;
using System.Net;

public partial class TransferRegistrationoutofMP : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds, ds1, ds2, ds3 = new DataSet();
    APIProcedure obj = new APIProcedure();
    string mbNo;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {
            
            //string validaity = DateTime.Now.ToString("dd/MM/yyyy");
            string dd = DateTime.Now.ToString("dd/MM/yyyy");
            //string ddate = DateTime.Now.ToString("dd/MM/yyyy");
            //string sd = ddate.Replace("-", "/");
            //txtDOBb.Text = sd;
            string bs = dd.Replace("-", "/");
            //string ms = validaity.Replace("-", "/");
            txtdate.Text = bs;
            //txtValidity.Text = ms;
            fnOtherPassingYear();
            BindUniversity();
            BindState();
            btnsubmit.Enabled = false;           
            hidefrom.Visible = false;
            DataSet dt2 = obj.ByDataSet("select * from tbl_OrganizationMaster");
            if (dt2 != null && dt2.Tables.Count > 0)
            {
                if (dt2 != null && dt2.Tables[0].Rows.Count > 0)
                {
                    ddlorg.DataTextField = "OrganaizationName";
                    ddlorg.DataValueField = "ID";
                    ddlorg.DataSource = dt2.Tables[0];
                    ddlorg.DataBind();
                    ddlorg.Items.Insert(0, "Select");
                }

            }

            DataSet dt4 = obj.ByDataSet("select * from Tbl_Sectormaster");
            if (dt4 != null && dt4.Tables.Count > 0)
            {
                if (dt4 != null && dt4.Tables[0].Rows.Count > 0)
                {
                    ddlPresentOcc.DataTextField = "SectorName";
                    ddlPresentOcc.DataValueField = "ID";
                    ddlPresentOcc.DataSource = dt4.Tables[0];
                    ddlPresentOcc.DataBind();
                    ddlPresentOcc.Items.Insert(0, "Select");
                }

            }
            if (Request.QueryString["editTransfer"] != null)
            {
                string applicationNo = "";
                if (Request.QueryString["editTransfer"].ToString().Contains("*"))
                {
                    string[] arr = Request.QueryString["editTransfer"].ToString().Split("*".ToCharArray());
                    applicationNo = arr[1];
                }
                else
                {
                    applicationNo = Request.QueryString["editTransfer"].ToString();
                }

                DataSet dscal = obj.ByDataSet("select * from tblNewRegistration where ApplicationNo='" + applicationNo + "'");
                trReg.Visible = false;
                btnsubmit.Text = "Verify";
                btnsubmit.Enabled = true;
                //FillUserDetails(sender, e);
                FillFormDetails(sender, e);
                if (Session["IsVerify"] != null)
                {
                    if (Session["IsVerify"].ToString() == "1")
                    {
                        filUploadImg.Visible = false;
                        filUploadDomicile.Visible = false;
                        filUploadDegree.Visible = false;
                        filUploadRegisCert.Visible = false;
                        filUploadDD.Visible = false;
                        filUploadBirthproof.Visible = false;
                        rfvfilUploadDD.Enabled = false;
                        rfvfilUploadRegisCert.Enabled = false;
                        // START HERE by bhanu on 26-03-2022
                        filupDD_forMPSVC.Visible = false;
                        rfvdd_forMPSVC.Enabled = false;
                        // END HERE
                        Formreadonly();

                    }
                    else
                    {
                        if (Session["IsVerify"].ToString() != "1")
                        {

                            filUploadImg.Visible = true;
                            filUploadDomicile.Visible = true;
                            filUploadDegree.Visible = true;
                            filUploadRegisCert.Visible = true;
                            filUploadDD.Visible = true;
                            filUploadBirthproof.Visible = true;
                            rfvfilUploadRegisCert.Enabled = false;
                            rfvfilUploadDD.Enabled = false;
                            // START HERE by bhanu on 26-03-2022
                            rfvdd_forMPSVC.Enabled = false;
                            // END HERE

                        }


                    }
                }
                hidefrom.Visible = true;
                lnkdisApprove.Visible = true;
            }
            else
            {
                trReg.Visible = true;
                btnsubmit.Text = "Save&Pay";
            }


        }

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
    protected void BindUniversity()
    {
        try
        {
            lblMsg.Text = "";
            ddlUniversity.Items.Clear();
            ddluniversity2.Items.Clear();
            ddluniversity3.Items.Clear();
            ddluniversity4.Items.Clear();
            DataSet dsset = obj.ByProcedure("USP_University", new string[] { "flag", }, new string[] { "1", }, "dataset");

            if (dsset != null && dsset.Tables[0].Rows.Count > 0)
            {
                ddlUniversity.DataTextField = "UniversityName";
                ddlUniversity.DataValueField = "ID";
                ddlUniversity.DataSource = dsset.Tables[0];
                ddlUniversity.DataBind();
                ddlUniversity.Items.Insert(0, new ListItem("Select", "0"));

                ddluniversity2.DataTextField = "UniversityName";
                ddluniversity2.DataValueField = "ID";
                ddluniversity2.DataSource = dsset.Tables[0];
                ddluniversity2.DataBind();
                ddluniversity2.Items.Insert(0, new ListItem("Select", "0"));

                ddluniversity3.DataTextField = "UniversityName";
                ddluniversity3.DataValueField = "ID";
                ddluniversity3.DataSource = dsset.Tables[0];
                ddluniversity3.DataBind();
                ddluniversity3.Items.Insert(0, new ListItem("Select", "0"));

                ddluniversity4.DataTextField = "UniversityName";
                ddluniversity4.DataValueField = "ID";
                ddluniversity4.DataSource = dsset.Tables[0];
                ddluniversity4.DataBind();
                ddluniversity4.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }

    protected void BindState()
    {
        try
        {
            ddlState.Items.Clear();

            DataSet dsBind = obj.ByProcedure("USP_University", new string[] { "flag", }, new string[] { "3", }, "dataset");

            if (dsBind != null && dsBind.Tables[0].Rows.Count > 0)
            {
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateId";
                ddlState.DataSource = dsBind.Tables[0];
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void SearchRegistration()
    {
        try
        {
            string chkCancel = "";
            string SendOTP = "";
            if (Request.QueryString["editTransfer"] != null)
            {
                string[] arr = Request.QueryString["editTransfer"].ToString().Split("*".ToCharArray());
                string applicationNo = arr[1];
                string Tid = arr[0];
                ds = obj.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
            }

            else
            {
                if (txtRegNo.Text.Trim() != "")
                {
                    ds = obj.ByDataSet("select * from tblNewRegistration where RegiNo ='" + txtRegNo.Text + "' and ApplicationRequestId <> 7 and ApplicationRequestId <> 8");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        chkCancel = ds.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
                        if (chkCancel == "9")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "CancelRegistration();", true);
                            return;
                        }
                    }

                }
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PreferedPhoneNo"].ToString() == "1")
                {
                    SendOTP = obj.Send_OTP(ds.Tables[0].Rows[0]["MobileNo"].ToString());
                    lblMobilealert.Text = " Does " + ds.Tables[0].Rows[0]["MobileNo"].ToString() + " really belong to you? ";
                }
                else
                {
                    SendOTP = obj.Send_OTP(ds.Tables[0].Rows[0]["MobileNo2"].ToString());
                    lblMobilealert.Text = " Does " + ds.Tables[0].Rows[0]["MobileNo2"].ToString() + " really belong to you? ";
                }
                ViewState["OTPSended"] = SendOTP;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPVerification();", true);
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Invalid registration no.";
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void Button2_Click(object sender, EventArgs e) // OTP button Event
    {
        string OTP = txtOTP.Text;
        string SendOTP = "";
        SendOTP = ViewState["OTPSended"].ToString();


        if (SendOTP == OTP)
        {
            ViewState["OTPSended"] = null;
            lblOTPInvalid.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPNotVerified();", true);
            //FillUserDetails(sender, e);
            FillFormDetails(sender, e);
            hidefrom.Visible = true;
        }
        else
        {
            lblOTPInvalid.Text = "* Invalid OTP";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPVerification();", true);
        }
    }

    //public void FillUserDetails(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["editTransfer"] != null)
    //    {
    //        string[] arr = Request.QueryString["editTransfer"].ToString().Split("*".ToCharArray());
    //        string applicationNo = arr[1];
    //        string Tid = arr[0];
    //        ds = obj.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");

    //    }
    //    else
    //    {

    //        ds = obj.ByProcedure("UpdateVerication", new string[] { "flag", "RegiNo" }, new string[] { "2", txtRegNo.Text.Trim() }, "dataset");
    //    }
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        DateTime Lvalue = DateTime.Now;
    //        DateTime rValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"].ToString());
    //        int count = Math.Abs((Lvalue.Month - rValue.Month) + 12 * (Lvalue.Year - rValue.Year));

    //        if (Request.QueryString["editTransfer"] == null)
    //        {
    //            if (Lvalue > rValue)
    //            {
    //                if (count < 120)
    //                {
    //                    lblTransferFees.Text = "Rs. 15";
    //                    HF_transferFees.Value = "15";
    //                    lblRenewalFees.Text = "Rs. 15";
    //                    HF_RenewalFees.Value = "15";
    //                    lbllateFees.Text = "Rs." + (Convert.ToInt32(count) * 5).ToString();
    //                    HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
    //                    lblrestablishmentCharge.Text = "Rs. 25";
    //                    HF_ReEstabilishmentFees.Value = "25";
    //                    lblServiceFees.Text = "Rs. 1000";
    //                    HF_ServiceChagre.Value = "1000";
    //                    lblTotalAmount.Text = "Rs." + (15 + 15 + Convert.ToInt32(count) * 5 + 25 + 1000).ToString();
    //                    HF_Totalamount.Value = (15 + 15 + Convert.ToInt32(count) * 5 + 25 + 1000).ToString();
    //                }
    //                else
    //                {
    //                    lblTransferFees.Text = "Rs. 15";
    //                    HF_transferFees.Value = "15";
    //                    lblRenewalFees.Text = "Rs. 30";
    //                    HF_RenewalFees.Value = "30";
    //                    lbllateFees.Text = "Rs." + (Convert.ToInt32(count) * 5).ToString();
    //                    HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
    //                    lblrestablishmentCharge.Text = "Rs. 25";
    //                    HF_ReEstabilishmentFees.Value = "25";
    //                    lblServiceFees.Text = "Rs. 2000";
    //                    HF_ServiceChagre.Value = "2000";
    //                    lblTotalAmount.Text = "Rs." + (15 + 30 + Convert.ToInt32(count) * 5 + 25 + 2000).ToString();
    //                    HF_Totalamount.Value = (15 + 30 + Convert.ToInt32(count) * 5 + 25 + 2000).ToString();
    //                }

    //                lblMSgAlert.Text = "Your registration is expired";
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "key2", "PopTemAndConditionTrans();", true);

    //            }

    //            else
    //            {
    //                lblTransferFees.Text = "Rs. 15";
    //                HF_transferFees.Value = "15";
    //                lblRenewalFees.Text = "Rs. 0";
    //                HF_RenewalFees.Value = "0";
    //                lbllateFees.Text = "Rs. 0";
    //                HF_LateFees.Value = "0";
    //                lblrestablishmentCharge.Text = "Rs. 0";
    //                HF_ReEstabilishmentFees.Value = "0";
    //                lblServiceFees.Text = "Rs. 0";
    //                HF_ServiceChagre.Value = "0";
    //                lblTotalAmount.Text = "Rs. 15";
    //                HF_Totalamount.Value = "15";


    //                lblMSgAlert.Text = "Registration no. '" + txtRegNo.Text + "' valid upto '" + Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy") + "' ";
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "key2", "PopTemAndConditionTrans();", true);

    //            }
    //        }

    //        txtRegNo.Enabled = false;
    //        regno.Visible = false;
    //        txtReginumber.Visible = false;
    //        HyperlinkDD.Visible = false;
    //        hyperlinkRegicert.Visible = false;
    //        txtRegNo.Text = ds.Tables[0].Rows[0]["RegiNo"].ToString();
    //        hf_regno.Value = ds.Tables[0].Rows[0]["RegiNo"].ToString();            
    //        txtApplicant.Text = ds.Tables[0].Rows[0]["FName"].ToString();
    //        txtMiddleName.Text = ds.Tables[0].Rows[0]["MName"].ToString();
    //        txtLastname.Text = ds.Tables[0].Rows[0]["LName"].ToString();         
    //        txtFHname.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();           
    //        txtDOBb.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]).ToString("dd/MM/yyyy");
    //        txtEmailID.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
    //        txtValidity.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");
    //        txtResAdd.Text = ds.Tables[0].Rows[0]["ResAdd"].ToString();
    //        txtRessPost.Text = ds.Tables[0].Rows[0]["ResPost"].ToString();
    //        txtRessTehsil.Text = ds.Tables[0].Rows[0]["ResTehsil"].ToString();
    //        txtResCity.Text = ds.Tables[0].Rows[0]["ResCity"].ToString();
    //        txtResDistrict.Text = ds.Tables[0].Rows[0]["ResDistrict"].ToString();
    //        txtResPinCode.Text = ds.Tables[0].Rows[0]["ResPinCode"].ToString();
    //        txtProAdd.Text = ds.Tables[0].Rows[0]["ProAdd"].ToString();
    //        txtProCity.Text = ds.Tables[0].Rows[0]["ProCity"].ToString();
    //        txtProPost.Text  = ds.Tables[0].Rows[0]["ProPost"].ToString();
    //        txtProPinCode.Text = ds.Tables[0].Rows[0]["ProPinCode"].ToString();
    //        txtProTehsil.Text = ds.Tables[0].Rows[0]["ProTehsil"].ToString();
    //        txtProDistrict.Text = ds.Tables[0].Rows[0]["ProDistrict"].ToString();
    //        txtPerAdd.Text = ds.Tables[0].Rows[0]["PerAdd"].ToString();
    //        txtPerCity.Text = ds.Tables[0].Rows[0]["PerCity"].ToString();
    //        txtPerDistrict.Text = ds.Tables[0].Rows[0]["PerDistrict"].ToString();
    //        txtPerPinCode.Text = ds.Tables[0].Rows[0]["PerPinCode"].ToString();
    //        txtPerPost.Text = ds.Tables[0].Rows[0]["PerPost"].ToString();
    //        txtPerTehsil.Text = ds.Tables[0].Rows[0]["PerTehsil"].ToString();
    //        if (ds.Tables[0].Rows[0]["File3"].ToString() != "")
    //        {
    //            string image;
    //            hyperliinkImage.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["File3"].ToString();
    //            hyperliinkImage.Text = "ViewImage";
    //            image = hyperliinkImage.NavigateUrl;
    //            ViewState["img"] = image;
    //        }
    //        else
    //        {
    //            hyperliinkImage.Text = "NA";
    //        }

    //        if (ds.Tables[0].Rows[0]["File1"].ToString() != "")
    //        {
    //            string DomicileCertificate;
    //            hyperLinkDomicile.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["File1"].ToString();
    //            hyperLinkDomicile.Text = "ViewDomicile";
    //            DomicileCertificate = hyperLinkDomicile.NavigateUrl;
    //            ViewState["DomicileCertificate"] = DomicileCertificate;

    //        }
    //        else
    //        {
    //            hyperLinkDomicile.Text = "NA";
    //        }
    //        if (ds.Tables[0].Rows[0]["File2"].ToString() != "")
    //        {
    //            string Degree;
    //            hyperlinkDegree.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["File2"].ToString();
    //            hyperlinkDegree.Text = "ViewDegree";
    //            Degree = hyperlinkDegree.NavigateUrl;
    //            ViewState["Degree"] = Degree;
    //        }
    //        else
    //        {
    //            hyperlinkDegree.Text = "NA";
    //        }
    //        if (ds.Tables[0].Rows[0]["File5"].ToString() != "")
    //        {
    //            string BirthCertificate;
    //            hyperlinkBirth.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["File5"].ToString();
    //            hyperlinkBirth.Text = "ViewBirthCertificate";
    //            BirthCertificate = hyperlinkBirth.NavigateUrl;
    //            ViewState["BirthCertificate"] = BirthCertificate;
    //        }
    //        else
    //        {
    //            hyperlinkBirth.Visible = false;
    //        }
    //        try
    //        {
    //            if (ds.Tables[0].Rows[0]["ProState"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["ProState"].ToString() != "0")
    //                {
    //                    ddlproState.ClearSelection();
    //                    ddlproState.Items.FindByValue(ds.Tables[0].Rows[0]["ProState"].ToString()).Selected = true;
    //                }
    //            }

    //        }
    //        catch(Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        try
    //        {
    //            if(ds.Tables[0].Rows[0]["PerState"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["PerState"].ToString() != "0")
    //                {
    //                    ddlPerState.ClearSelection();
    //                    ddlPerState.Items.FindByValue(ds.Tables[0].Rows[0]["PerState"].ToString()).Selected = true;
    //                }
    //            }               
    //        }
    //        catch (Exception ex)
    //        {
    //           //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        try
    //        {
    //            if(ds.Tables[0].Rows[0]["ResState"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["ResState"].ToString() != "0")
    //                {

    //                    ddlRestate.ClearSelection();
    //                    ddlRestate.Items.FindByValue(ds.Tables[0].Rows[0]["ResState"].ToString()).Selected = true;
    //                }
    //            }

    //        }
    //        catch(Exception ex)
    //        {
    //             //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        try
    //        {
    //            if(ds.Tables[0].Rows[0]["Gender"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["Gender"].ToString() != "0")
    //                {
    //                    ddlgender.ClearSelection();
    //                    ddlgender.Items.FindByText(ds.Tables[0].Rows[0]["Gender"].ToString()).Selected = true;
    //                }
    //            }              
    //        }
    //        catch(Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }

    //        try
    //        {
    //            if(ds.Tables[0].Rows[0]["PresentOccuption"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["PresentOccuption"].ToString() != "0")
    //                {
    //                    ddlPresentOcc.ClearSelection();
    //                    ddlPresentOcc.Items.FindByValue(ds.Tables[0].Rows[0]["PresentOccuption"].ToString()).Selected = true;
    //                }
    //            }                
    //        }
    //        catch(Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }

    //        try
    //        {
    //            if (ds.Tables[0].Rows[0]["OrganizationId"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["OrganizationId"].ToString() != "0")
    //                {
    //                    ddlorg.ClearSelection();
    //                    ddlorg.Items.FindByValue(ds.Tables[0].Rows[0]["OrganizationId"].ToString()).Selected = true;
    //                    //string org = ddlorg.SelectedItem.Text;
    //                    //if (org == "Other")
    //                    //{
    //                    //    txtOrg.Text = ds.Tables[0].Rows[0]["OrganizationText"].ToString();
    //                    //}
    //                }
    //            }
    //        }
    //        catch(Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        try
    //        {
    //            if (ds.Tables[0].Rows[0]["DepartmentId"].ToString() != null)
    //            {
    //                if (ddlorg.SelectedIndex > 0)
    //                {
    //                    ddlorg_SelectedIndexChanged1(sender, e);
    //                    ddldept.ClearSelection();
    //                    ddldept.Items.FindByValue(ds.Tables[0].Rows[0]["DepartmentId"].ToString()).Selected = true;
    //                    //string dpt = ddldept.SelectedItem.Text;
    //                    //if (dpt == "Other")
    //                    //{
    //                    //    txtDept.Text = ds.Tables[0].Rows[0]["DepartmentText"].ToString();
    //                    //}
    //                }
    //            }                
    //        }
    //        catch { }
    //        try
    //        {
    //            if (ds.Tables[0].Rows[0]["Designationid"].ToString() != null)
    //            {
    //                if (ddldept.SelectedIndex > 0)
    //                {
    //                    ddldept_SelectedIndexChanged(sender, e);
    //                    ddldesig.ClearSelection();
    //                    ddldesig.Items.FindByValue(ds.Tables[0].Rows[0]["Designationid"].ToString()).Selected = true;
    //                    //string des = ddldesig.SelectedItem.Text;
    //                    //if (des == "Other")
    //                    //{
    //                    //    txtDesig.Text = ds.Tables[0].Rows[0]["DesignationText"].ToString();
    //                    //}
    //                }
    //            }               
    //        }
    //        catch(Exception ex)
    //        { 
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }

    //        try
    //        {
    //            if(ds.Tables[0].Rows[0]["PreferedAdd"].ToString()!= null)
    //            {
    //                if (ds.Tables[0].Rows[0]["PreferedAdd"].ToString() != "0")
    //                {
    //                    ddlPreffAddress.ClearSelection();
    //                    ddlPreffAddress.Items.FindByValue(ds.Tables[0].Rows[0]["PreferedAdd"].ToString()).Selected = true;
    //                }
    //            }                           
    //        }
    //        catch(Exception ex)
    //        { 
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }

    //        txtMobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
    //        txtmobileother.Text = ds.Tables[0].Rows[0]["MobileNo2"].ToString();                            
    //        string str = "";
    //        str = ds.Tables[0].Rows[0]["PreferedPhoneNo"].ToString();
    //        if (str == "1")
    //        {
    //            rbmobile1.Checked = true;
    //        }
    //        else
    //        {
    //            rbmobile2.Checked = true;
    //        }

    //        try
    //        {
    //            if(ds.Tables[0].Rows[0]["University1"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["University1"].ToString() != "0")
    //                {
    //                    ddlUniversity.ClearSelection();
    //                    ddlUniversity.Items.FindByValue(ds.Tables[0].Rows[0]["University1"].ToString()).Selected = true;
    //                }
    //            }       
    //        }
    //        catch(Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }

    //        try
    //        {
    //            if(ds.Tables[0].Rows[0]["University2"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["University2"].ToString() != "0")
    //                {
    //                    ddluniversity2.ClearSelection();
    //                    ddluniversity2.Items.FindByValue(ds.Tables[0].Rows[0]["University2"].ToString()).Selected = true;
    //                } 
    //            }                       
    //        }
    //        catch (Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }

    //        try
    //        {
    //            if (ds.Tables[0].Rows[0]["University3"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["University3"].ToString() != "0")
    //                {
    //                    ddluniversity3.ClearSelection();
    //                    ddluniversity3.Items.FindByValue(ds.Tables[0].Rows[0]["University3"].ToString()).Selected = true;
    //                }
    //            }               
    //        }
    //        catch (Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        try
    //        {
    //            if (ds.Tables[0].Rows[0]["University4"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["University4"].ToString() != "0")
    //                {
    //                    ddluniversity4.ClearSelection();
    //                    ddluniversity4.Items.FindByValue(ds.Tables[0].Rows[0]["University4"].ToString()).Selected = true;
    //                }
    //            }                          
    //        }
    //        catch(Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        try
    //        {
    //            if(ds.Tables[0].Rows[0]["CollegeID1"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["CollegeID1"].ToString() != "0")
    //                {
    //                    ddlUniversity_SelectedIndexChanged(sender, e);
    //                    ddlCollege.ClearSelection();
    //                    ddlCollege.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID1"].ToString()).Selected = true;
    //                }
    //            }           
    //        }
    //        catch(Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        try
    //        {
    //            if(ds.Tables[0].Rows[0]["CollegeID2"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["CollegeID2"].ToString() != "0")
    //                {
    //                    ddluniversity2_SelectedIndexChanged(sender, e);
    //                    ddlcollege2.ClearSelection();
    //                    ddlcollege2.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID2"].ToString()).Selected = true;
    //                }
    //            }               
    //        }
    //        catch(Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }               
    //        try
    //        {
    //            if(ds.Tables[0].Rows[0]["CollegeID3"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["CollegeID3"].ToString() != "0")
    //                {
    //                    ddluniversity3_SelectedIndexChanged(sender, e);
    //                    ddlcollege3.ClearSelection();
    //                    ddlcollege3.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID3"].ToString()).Selected = true;
    //                } 
    //            }                                             
    //        }
    //        catch (Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }

    //        try
    //        {
    //            if(ds.Tables[0].Rows[0]["CollegeID4"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["CollegeID4"].ToString() != "0")
    //                {
    //                    ddluniversity4_SelectedIndexChanged(sender, e);
    //                    ddlcollege4.ClearSelection();
    //                    ddlcollege4.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID4"].ToString()).Selected = true;
    //                }
    //            }              
    //        }
    //        catch(Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        try
    //        {
    //            if (ds.Tables[0].Rows[0]["Year1"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["Year1"].ToString() != "0")
    //                {
    //                    fnOtherPassingYear();
    //                    ddlY1.ClearSelection();
    //                    ddlY1.Items.FindByText(ds.Tables[0].Rows[0]["Year1"].ToString()).Selected = true;
    //                }  
    //            }                                           
    //        }
    //        catch(Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        try
    //        {
    //            if (ds.Tables[0].Rows[0]["Year2"].ToString() != null)
    //            {
    //            if (ds.Tables[0].Rows[0]["Year2"].ToString() != "0")
    //            {

    //                fnOtherPassingYear();
    //                ddlY2.ClearSelection();
    //                ddlY2.Items.FindByValue(ds.Tables[0].Rows[0]["Year2"].ToString()).Selected = true;
    //            }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        try
    //        {
    //            if (ds.Tables[0].Rows[0]["Year3"].ToString() != null)
    //            {
    //                if(ds.Tables[0].Rows[0]["Year3"].ToString() != "0")
    //                {
    //                    fnOtherPassingYear();
    //                    ddlY3.ClearSelection();
    //                    ddlY3.Items.FindByValue(ds.Tables[0].Rows[0]["Year3"].ToString()).Selected = true;
    //                }
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        try
    //        {
    //            if (ds.Tables[0].Rows[0]["Year4"].ToString() != null)
    //            {
    //                if (ds.Tables[0].Rows[0]["Year4"].ToString() != "0")
    //                {
    //                    fnOtherPassingYear();
    //                    ddlY4.ClearSelection();
    //                    ddlY4.Items.FindByValue(ds.Tables[0].Rows[0]["Year4"].ToString()).Selected = true;
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //        }
    //        if (Request.QueryString["editTransfer"] != null)
    //        {
    //            txtReginumber.Visible = true;
    //            regno.Visible = true;
    //            hyperlinkRegicert.Visible = true;
    //            HyperlinkDD.Visible = true;
    //            txtDDno.Text = ds.Tables[0].Rows[0]["ChequeNo"].ToString();
    //            txtBank.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
    //            txtBranch.Text = ds.Tables[0].Rows[0]["Bank_Branch_Name"].ToString();
    //            txtDrwan.Text = ds.Tables[0].Rows[0]["Drawn_name_DD"].ToString();
    //            txtreason.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
    //            txtNameofCouncil.Text = ds.Tables[0].Rows[0]["Registrar_Name"].ToString();
    //            txtaddressd.Text = ds.Tables[0].Rows[0]["Registrar_Adresse"].ToString();
    //            txtdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ChequeDate"]).ToString("dd/MM/yyyy");
    //            txtReginumber.Text = ds.Tables[0].Rows[0]["RegiNo"].ToString();
    //            if (ds.Tables[0].Rows[0]["Demand_Draft"].ToString() != null)
    //            {
    //                string DD;
    //                HyperlinkDD.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["Demand_Draft"].ToString();
    //                HyperlinkDD.Text = "ViewDD";
    //                DD = HyperlinkDD.NavigateUrl;
    //                ViewState["DD"] = DD;

    //            }
    //            else
    //            {
    //                HyperlinkDD.Text = "NA";
    //            }
    //            if (ds.Tables[0].Rows[0]["RegistrationCertificate"].ToString() != null)
    //            {
    //                string regcertificate;
    //                hyperlinkRegicert.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["RegistrationCertificate"].ToString();
    //                hyperlinkRegicert.Text = "ViewDD";
    //                regcertificate = hyperlinkRegicert.NavigateUrl;
    //                ViewState["regcertificate"] = regcertificate;
    //            }
    //            else
    //            {
    //                hyperlinkRegicert.Text = "NA";
    //            }
    //            try
    //            {
    //                if (ds.Tables[0].Rows[0]["Transferstateid"].ToString()!= null)
    //                {
    //                    if (ds.Tables[0].Rows[0]["Transferstateid"].ToString() != "0")
    //                    {
    //                        ddlState.ClearSelection();
    //                        ddlState.Items.FindByValue(ds.Tables[0].Rows[0]["Transferstateid"].ToString()).Selected = true;
    //                    }
    //                }

    //            }
    //            catch (Exception ex)
    //            {
    //                lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //            }


    //            string str1 = "";
    //            str1 = ds.Tables[0].Rows[0]["Isonline"].ToString();
    //            if (str1 == "1")
    //            {
    //                //rbOnline.Checked = true;
    //                //tr_payment.Visible = false;
    //                //tr_cheque.Visible = false;
    //                //tr_Pdate.Visible = false;
    //            }
    //            else
    //            {
    //                rboffline.Checked = true;
    //            }
    //        }
    //        else
    //        {
    //            rboffline.Checked = true;
    //        }
    //    }

    //    }

    public void FillFormDetails(object sender, EventArgs e)
    {
        try
        {

            if (Request.QueryString["editTransfer"] != null)
            {
                string[] arr = Request.QueryString["editTransfer"].ToString().Split("*".ToCharArray());
                string applicationNo = arr[1];
                string Tid = arr[0];
                ds = obj.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");

            }
            else
            {

                ds = obj.ByProcedure("UpdateVerication", new string[] { "flag", "RegiNo" }, new string[] { "2", txtRegNo.Text.Trim() }, "dataset");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime Lvalue = DateTime.Now;
                DateTime rValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"].ToString());
                int count = Math.Abs((Lvalue.Month - rValue.Month) + 12 * (Lvalue.Year - rValue.Year));

                if (Request.QueryString["editTransfer"] == null)
                {
                    if (Lvalue > rValue)
                    {
                        if (count < 120)
                        {
                            lblTransferFees.Text = "Rs. 15";
                            HF_transferFees.Value = "15";
                            lblRenewalFees.Text = "Rs. 15";
                            HF_RenewalFees.Value = "15";
                            lbllateFees.Text = "Rs." + (Convert.ToInt32(count) * 5).ToString();
                            HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
                            lblrestablishmentCharge.Text = "Rs. 25";
                            HF_ReEstabilishmentFees.Value = "25";
                            lblServiceFees.Text = "Rs. 1000";
                            HF_ServiceChagre.Value = "1000";
                            lblTotalAmount.Text = "Rs." + (15 + 15 + Convert.ToInt32(count) * 5 + 25 + 1000).ToString();
                            HF_Totalamount.Value = (15 + 15 + Convert.ToInt32(count) * 5 + 25 + 1000).ToString();
                        }
                        else
                        {
                            lblTransferFees.Text = "Rs. 15";
                            HF_transferFees.Value = "15";
                            lblRenewalFees.Text = "Rs. 30";
                            HF_RenewalFees.Value = "30";
                            lbllateFees.Text = "Rs." + (Convert.ToInt32(count) * 5).ToString();
                            HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
                            lblrestablishmentCharge.Text = "Rs. 25";
                            HF_ReEstabilishmentFees.Value = "25";
                            lblServiceFees.Text = "Rs. 2000";
                            HF_ServiceChagre.Value = "2000";
                            lblTotalAmount.Text = "Rs." + (15 + 30 + Convert.ToInt32(count) * 5 + 25 + 2000).ToString();
                            HF_Totalamount.Value = (15 + 30 + Convert.ToInt32(count) * 5 + 25 + 2000).ToString();
                        }

                        lblMSgAlert.Text = "Your registration is expired";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key2", "PopTemAndConditionTrans();", true);

                    }

                    else
                    {
                        lblTransferFees.Text = "Rs. 15";
                        HF_transferFees.Value = "15";
                        lblRenewalFees.Text = "Rs. 0";
                        HF_RenewalFees.Value = "0";
                        lbllateFees.Text = "Rs. 0";
                        HF_LateFees.Value = "0";
                        lblrestablishmentCharge.Text = "Rs. 0";
                        HF_ReEstabilishmentFees.Value = "0";
                        lblServiceFees.Text = "Rs. 0";
                        HF_ServiceChagre.Value = "0";
                        lblTotalAmount.Text = "Rs. 15";
                        HF_Totalamount.Value = "15";


                        lblMSgAlert.Text = "Registration no. '" + txtRegNo.Text + "' valid upto '" + Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy") + "' ";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key2", "PopTemAndConditionTrans();", true);

                    }
                }


                txtRegNo.Enabled = false;
                regno.Visible = false;
                txtReginumber.Visible = false;
                HyperlinkDD.Visible = false;
                hyperlinkRegicert.Visible = false;
                hyperDD_forMPSVC.Visible = false;              
                txtRegNo.Text = ds.Tables[0].Rows[0]["RegiNo"].ToString();
                hf_regno.Value = ds.Tables[0].Rows[0]["RegiNo"].ToString();
                txtApplicant.Text = ds.Tables[0].Rows[0]["FName"].ToString();
                txtMiddleName.Text = ds.Tables[0].Rows[0]["MName"].ToString();
                txtLastname.Text = ds.Tables[0].Rows[0]["LName"].ToString();
                txtFHname.Text = ds.Tables[0].Rows[0]["FatherName"].ToString();
                txtTotalPayAmount.Text = HF_Totalamount.Value;
                
                if (ds.Tables[0].Rows[0]["DOB"] != "" && ds.Tables[0].Rows[0]["DOB"] != null)
                {
                    txtDOBb.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]).ToString("dd/MM/yyyy");
                }               
                
                if(ds.Tables[0].Rows[0]["Validupto"].ToString() != "" && ds.Tables[0].Rows[0]["Validupto"].ToString() != null)
                {
                    txtValidity.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");
                }
                txtEmailID.Text = ds.Tables[0].Rows[0]["EmailId"].ToString();
                txtResAdd.Text = ds.Tables[0].Rows[0]["ResAdd"].ToString();
                txtRessPost.Text = ds.Tables[0].Rows[0]["ResPost"].ToString();
                txtRessTehsil.Text = ds.Tables[0].Rows[0]["ResTehsil"].ToString();
                txtResCity.Text = ds.Tables[0].Rows[0]["ResCity"].ToString();
                txtResDistrict.Text = ds.Tables[0].Rows[0]["ResDistrict"].ToString();
                txtResPinCode.Text = ds.Tables[0].Rows[0]["ResPinCode"].ToString();
                txtProAdd.Text = ds.Tables[0].Rows[0]["ProAdd"].ToString();
                txtProCity.Text = ds.Tables[0].Rows[0]["ProCity"].ToString();
                txtProPost.Text = ds.Tables[0].Rows[0]["ProPost"].ToString();
                txtProPinCode.Text = ds.Tables[0].Rows[0]["ProPinCode"].ToString();
                txtProTehsil.Text = ds.Tables[0].Rows[0]["ProTehsil"].ToString();
                txtProDistrict.Text = ds.Tables[0].Rows[0]["ProDistrict"].ToString();
                txtPerAdd.Text = ds.Tables[0].Rows[0]["PerAdd"].ToString();
                txtPerCity.Text = ds.Tables[0].Rows[0]["PerCity"].ToString();
                txtPerDistrict.Text = ds.Tables[0].Rows[0]["PerDistrict"].ToString();
                txtPerPinCode.Text = ds.Tables[0].Rows[0]["PerPinCode"].ToString();
                txtPerPost.Text = ds.Tables[0].Rows[0]["PerPost"].ToString();
                txtPerTehsil.Text = ds.Tables[0].Rows[0]["PerTehsil"].ToString();

                if (ds.Tables[0].Rows[0]["File3"].ToString() != "")
                {
                    string image;
                    hyperliinkImage.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["File3"].ToString();
                    hyperliinkImage.Text = "ViewImage";
                    image = hyperliinkImage.NavigateUrl;
                    ViewState["img"] = image;
                }
                else
                {
                    hyperliinkImage.Text = "NA";
                }

                if (ds.Tables[0].Rows[0]["File1"].ToString() != "")
                {
                    string DomicileCertificate;
                    hyperLinkDomicile.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["File1"].ToString();
                    hyperLinkDomicile.Text = "ViewDomicile";
                    DomicileCertificate = hyperLinkDomicile.NavigateUrl;
                    ViewState["DomicileCertificate"] = DomicileCertificate;

                }
                else
                {
                    hyperLinkDomicile.Text = "NA";
                }
                if (ds.Tables[0].Rows[0]["File2"].ToString() != "")
                {
                    string Degree;
                    hyperlinkDegree.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["File2"].ToString();
                    hyperlinkDegree.Text = "ViewDegree";
                    Degree = hyperlinkDegree.NavigateUrl;
                    ViewState["Degree"] = Degree;
                }
                else
                {
                    hyperlinkDegree.Text = "NA";
                }
                if (ds.Tables[0].Rows[0]["File5"].ToString() != "")
                {
                    string BirthCertificate;
                    hyperlinkBirth.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["File5"].ToString();
                    hyperlinkBirth.Text = "ViewBirthCertificate";
                    BirthCertificate = hyperlinkBirth.NavigateUrl;
                    ViewState["BirthCertificate"] = BirthCertificate;
                }
                else
                {
                    hyperlinkBirth.Visible = false;
                }

                if (ds.Tables[0].Rows[0]["ProState"].ToString() != null && ds.Tables[0].Rows[0]["ProState"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["ProState"].ToString() != "0")
                    {
                        ddlproState.ClearSelection();
                        ddlproState.Items.FindByValue(ds.Tables[0].Rows[0]["ProState"].ToString()).Selected = true;
                    }
                }

                {
                    if (ds.Tables[0].Rows[0]["PerState"].ToString() != null && ds.Tables[0].Rows[0]["PerState"].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[0]["PerState"].ToString() != "0")
                        {
                            ddlPerState.ClearSelection();
                            ddlPerState.Items.FindByValue(ds.Tables[0].Rows[0]["PerState"].ToString()).Selected = true;
                        }
                    }
                }

                if (ds.Tables[0].Rows[0]["ResState"].ToString() != null && ds.Tables[0].Rows[0]["ResState"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["ResState"].ToString() != "0")
                    {

                        ddlRestate.ClearSelection();
                        ddlRestate.Items.FindByValue(ds.Tables[0].Rows[0]["ResState"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["Gender"].ToString() != null && ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["Gender"].ToString() != "0")
                    {
                        ddlgender.ClearSelection();
                        ddlgender.Items.FindByText(ds.Tables[0].Rows[0]["Gender"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["PresentOccuption"].ToString() != null && ds.Tables[0].Rows[0]["PresentOccuption"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["PresentOccuption"].ToString() != "0")
                    {
                        //ddlPresentOcc.ClearSelection();
                        //ddlPresentOcc.Items.FindByValue(ds.Tables[0].Rows[0]["PresentOccuption"].ToString()).Selected = true;
                        if (ddlPresentOcc.Items.FindByText(ds.Tables[0].Rows[0]["PresentOccuption"].ToString()) != null)
                        {
                            ddlPresentOcc.ClearSelection();
                            ddlPresentOcc.Items.FindByText(ds.Tables[0].Rows[0]["PresentOccuption"].ToString()).Selected = true;
                        }
                        else if (ddlPresentOcc.Items.FindByValue(ds.Tables[0].Rows[0]["PresentOccuption"].ToString()) != null)
                        {
                            ddlPresentOcc.ClearSelection();
                            ddlPresentOcc.Items.FindByValue(ds.Tables[0].Rows[0]["PresentOccuption"].ToString()).Selected = true;
                        }
                    }
                }

                if (ds.Tables[0].Rows[0]["OrganizationId"].ToString() != null && ds.Tables[0].Rows[0]["OrganizationId"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["OrganizationId"].ToString() != "0")
                    {
                        ddlorg.ClearSelection();
                        ddlorg.Items.FindByValue(ds.Tables[0].Rows[0]["OrganizationId"].ToString()).Selected = true;
                        //string org = ddlorg.SelectedItem.Text;
                        //if (org == "Other")
                        //{
                        //    txtOrg.Text = ds.Tables[0].Rows[0]["OrganizationText"].ToString();
                        //}
                    }
                }

                if (ds.Tables[0].Rows[0]["DepartmentId"].ToString() != null && ds.Tables[0].Rows[0]["DepartmentId"].ToString() != "")
                {
                    if (ddlorg.SelectedIndex > 0)
                    {

                        ddlorg_SelectedIndexChanged1(sender, e);
                        ddldept.ClearSelection();
                        ddldept.Items.FindByValue(ds.Tables[0].Rows[0]["DepartmentId"].ToString()).Selected = true;
                        //string dpt = ddldept.SelectedItem.Text;
                        //if (dpt == "Other")
                        //{
                        //    txtDept.Text = ds.Tables[0].Rows[0]["DepartmentText"].ToString();
                        //}
                    }
                }

                if (ds.Tables[0].Rows[0]["Designationid"].ToString() != null && ds.Tables[0].Rows[0]["Designationid"].ToString() != "")
                {
                    if (ddldept.SelectedIndex > 0)
                    {
                        ddldept_SelectedIndexChanged(sender, e);
                        ddldesig.ClearSelection();
                        ddldesig.Items.FindByValue(ds.Tables[0].Rows[0]["Designationid"].ToString()).Selected = true;
                        //string des = ddldesig.SelectedItem.Text;
                        //if (des == "Other")
                        //{
                        //    txtDesig.Text = ds.Tables[0].Rows[0]["DesignationText"].ToString();
                        //}
                    }
                }

                if (ds.Tables[0].Rows[0]["PreferedAdd"].ToString() != null && ds.Tables[0].Rows[0]["PreferedAdd"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["PreferedAdd"].ToString() != "0")
                    {
                        ddlPreffAddress.ClearSelection();
                        ddlPreffAddress.Items.FindByText(ds.Tables[0].Rows[0]["PreferedAdd"].ToString()).Selected = true;
                    }
                }

                txtMobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                txtmobileother.Text = ds.Tables[0].Rows[0]["MobileNo2"].ToString();
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

                if (ds.Tables[0].Rows[0]["University1"].ToString() != null && ds.Tables[0].Rows[0]["University1"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["University1"].ToString() != "0")
                    {
                        ddlUniversity.ClearSelection();
                        ddlUniversity.Items.FindByValue(ds.Tables[0].Rows[0]["University1"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["University2"].ToString() != null && ds.Tables[0].Rows[0]["University2"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["University2"].ToString() != "0")
                    {
                        ddluniversity2.ClearSelection();
                        ddluniversity2.Items.FindByValue(ds.Tables[0].Rows[0]["University2"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["University3"].ToString() != null && ds.Tables[0].Rows[0]["University3"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["University3"].ToString() != "0")
                    {
                        ddluniversity3.ClearSelection();
                        ddluniversity3.Items.FindByValue(ds.Tables[0].Rows[0]["University3"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["University4"].ToString() != null && ds.Tables[0].Rows[0]["University4"].ToString() !="")
                {
                    if (ds.Tables[0].Rows[0]["University4"].ToString() != "0")
                    {
                        ddluniversity4.ClearSelection();
                        ddluniversity4.Items.FindByValue(ds.Tables[0].Rows[0]["University4"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["CollegeID1"].ToString() != null && ds.Tables[0].Rows[0]["CollegeID1"].ToString() !="" )
                {
                    if (ds.Tables[0].Rows[0]["CollegeID1"].ToString() != "0")
                    {
                        ddlUniversity_SelectedIndexChanged(sender, e);
                        ddlCollege.ClearSelection();
                        ddlCollege.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID1"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["CollegeID2"].ToString() != null && ds.Tables[0].Rows[0]["CollegeID2"].ToString() !="")
                {
                    if (ds.Tables[0].Rows[0]["CollegeID2"].ToString() != "0")
                    {
                        ddluniversity2_SelectedIndexChanged(sender, e);
                        ddlcollege2.ClearSelection();
                        ddlcollege2.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID2"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["CollegeID3"].ToString() != null && ds.Tables[0].Rows[0]["CollegeID3"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["CollegeID3"].ToString() != "0")
                    {
                        ddluniversity3_SelectedIndexChanged(sender, e);
                        ddlcollege3.ClearSelection();
                        ddlcollege3.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID3"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["CollegeID4"].ToString() != null && ds.Tables[0].Rows[0]["CollegeID4"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["CollegeID4"].ToString() != "0")
                    {
                        ddluniversity4_SelectedIndexChanged(sender, e);
                        ddlcollege4.ClearSelection();
                        ddlcollege4.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID4"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["Year1"].ToString() != null && ds.Tables[0].Rows[0]["Year1"].ToString() !="")
                {
                    if (ds.Tables[0].Rows[0]["Year1"].ToString() != "0" && ds.Tables[0].Rows[0]["Year1"].ToString() != "Select")
                    {
                        fnOtherPassingYear();
                        ddlY1.ClearSelection();                       
                        ddlY1.Items.FindByValue(ds.Tables[0].Rows[0]["Year1"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["Year2"].ToString() != null && ds.Tables[0].Rows[0]["Year2"].ToString() !="")
                {
                    if (ds.Tables[0].Rows[0]["Year2"].ToString() != "0" && ds.Tables[0].Rows[0]["Year2"].ToString() != "Select")
                    {

                        fnOtherPassingYear();
                        ddlY2.ClearSelection();
                        ddlY2.Items.FindByValue(ds.Tables[0].Rows[0]["Year2"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["Year3"].ToString() != null && ds.Tables[0].Rows[0]["Year3"].ToString() !="")
                {
                    if (ds.Tables[0].Rows[0]["Year3"].ToString() != "0" && ds.Tables[0].Rows[0]["Year3"].ToString() != "Select")
                    {
                        fnOtherPassingYear();
                        ddlY3.ClearSelection();
                        ddlY3.Items.FindByValue(ds.Tables[0].Rows[0]["Year3"].ToString()).Selected = true;
                    }
                }

                if (ds.Tables[0].Rows[0]["Year4"].ToString() != null && ds.Tables[0].Rows[0]["Year4"].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["Year4"].ToString() != "0" && ds.Tables[0].Rows[0]["Year4"].ToString() != "Select")
                    {
                        fnOtherPassingYear();
                        ddlY4.ClearSelection();
                        ddlY4.Items.FindByValue(ds.Tables[0].Rows[0]["Year4"].ToString()).Selected = true;
                    }
                }
                
                if (Request.QueryString["editTransfer"] != null)
                {

                    txtReginumber.Visible = true;
                    regno.Visible = true;
                    hyperlinkRegicert.Visible = true;
                    HyperlinkDD.Visible = true;
                    txtDDno.Text = ds.Tables[0].Rows[0]["ChequeNo"].ToString();
                    txtBank.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                    txtBranch.Text = ds.Tables[0].Rows[0]["Bank_Branch_Name"].ToString();
                    txtDrwan.Text = ds.Tables[0].Rows[0]["Drawn_name_DD"].ToString();
                    txtreason.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                    //txtNameofCouncil.Text = ds.Tables[0].Rows[0]["Registrar_Name"].ToString();
                    txtReginumber.Text = ds.Tables[0].Rows[0]["RegiNo"].ToString();

                    if (ds.Tables[0].Rows[0]["ChequeDate"].ToString() != "" && ds.Tables[0].Rows[0]["ChequeDate"].ToString() !=null)
                    {
                        txtdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ChequeDate"]).ToString("dd/MM/yyyy");
                    }
    
                    // START by bhanu on 26-03-2022
                    hyperDD_forMPSVC.Visible = true;
                    txtCheckDD_forMPSVC.Text = ds.Tables[0].Rows[0]["CheckDDno_MPSVC"].ToString();
                    txtBankname_forMPSVC.Text = ds.Tables[0].Rows[0]["BankName_MPSVC"].ToString();
                    txtBranch_forMPSVC.Text = ds.Tables[0].Rows[0]["BranchName_MPSVC"].ToString();
                    if (ds.Tables[0].Rows[0]["PaymentDate_MPSVC"].ToString() != "" && ds.Tables[0].Rows[0]["PaymentDate_MPSVC"].ToString() != null)
                    {
                        txtpaymentdate_forMPSVC.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PaymentDate_MPSVC"]).ToString("dd/MM/yyyy");
                    }                    
                   // txtdrawnamedd_forMPSVC.Text = ds.Tables[0].Rows[0]["DrawnameDD_MPSVC"].ToString();

                    if (ds.Tables[0].Rows[0]["DemandDraft_MPSVC"].ToString() != "")
                    {
                        string DDMPSVC;
                        hyperDD_forMPSVC.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["DemandDraft_MPSVC"].ToString();
                        hyperDD_forMPSVC.Text = "ViewddMPSVC";
                        DDMPSVC = hyperDD_forMPSVC.NavigateUrl;
                        ViewState["DDMPSVC"] = DDMPSVC;
                    }
                    else
                    {
                        hyperDD_forMPSVC.Text = "NA";
                    }
                    // END  HERE

                    if (ds.Tables[0].Rows[0]["Demand_Draft"].ToString() != "")
                    {
                        string DD;
                        HyperlinkDD.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["Demand_Draft"].ToString();
                        HyperlinkDD.Text = "ViewDD";
                        DD = HyperlinkDD.NavigateUrl;
                        ViewState["DD"] = DD;

                    }
                    else
                    {
                        HyperlinkDD.Text = "NA";
                    }
                    if (ds.Tables[0].Rows[0]["RegistrationCertificate"].ToString() != "")
                    {
                        string regcertificate;
                        hyperlinkRegicert.NavigateUrl = "../Upload_Certificate/" + ds.Tables[0].Rows[0]["RegistrationCertificate"].ToString();
                        hyperlinkRegicert.Text = "Registration Certificate(SVC)";
                        regcertificate = hyperlinkRegicert.NavigateUrl;
                        ViewState["regcertificate"] = regcertificate;
                    }
                    else
                    {
                        hyperlinkRegicert.Text = "NA";
                    }

                    if (ds.Tables[0].Rows[0]["Transferstateid"].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[0]["Transferstateid"].ToString() != "0")
                        {
                            ddlState.ClearSelection();
                            ddlState.Items.FindByValue(ds.Tables[0].Rows[0]["Transferstateid"].ToString()).Selected = true;
                        }
                    }
                    if (ds.Tables[1].Rows[0]["TotalAmount"] != null && ds.Tables[1].Rows[0]["TotalAmount"] != "")
                    {
                        txtTotalPayAmount.Text = ds.Tables[1].Rows[0]["TotalAmount"].ToString();
                    }
                    string str1 = "";
                    str1 = ds.Tables[0].Rows[0]["Isonline"].ToString();
                    if (str1 == "1")
                    {
                        //rbOnline.Checked = true;
                        //tr_payment.Visible = false;
                        //tr_cheque.Visible = false;
                        //tr_Pdate.Visible = false;
                    }
                    else
                    {
                        rboffline.Checked = true;
                    }
                }
                else
                {
                    rboffline.Checked = true;
                }
            }

        }

        catch (Exception ex)
        {
            //lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {


            lblMsg.Text = "";
            string msg = "";
            if (txtApplicant.Text == "")
            {
                msg += "Enter Applicant Name. \\n";
            }

            if (txtFHname.Text == "")
            {
                msg += "Enter Father/Husband Name. \\n";
            }

            if (txtDOBb.Text == "")
            {
                msg += "Select Date of Birth. \\n";
            }

            if (ddlgender.SelectedIndex == 0)
            {
                msg += "Select Gender. \\n";
            }

            if (ddlUniversity.SelectedIndex == 0)
            {
                msg += "Enter University Name. \\n";
            }
            if (ddlCollege.SelectedIndex == 0)
            {
                msg += "Enter College Name. \\n";
            }

            if (ddlY1.SelectedIndex == 0)
            {
                msg += "Enter Passing Year. \\n";
            }

            if (txtMobileno.Text == "")
            {
                msg += "Enter Mobile No. \\n";
            }

            if (txtEmailID.Text == "")
            {
                msg += "Enter Email-Id. \\n";
            }

            if (txtNameofsvp.Text == "")
            {
                msg += " Name of the SVC Where in Candidate Presently Registered. \\n";
            }

            if (ddlPresentOcc.SelectedIndex == 0)
            {
                msg += "Select Sector. \\n";
            }
            if (ddlPreffAddress.SelectedIndex == 0)
            {
                msg += "Select Preffered Address. \\n";
            }

            if (txtValidity.Text == "")
            {
                msg += "Enter Validity Date of Registration Number. \\n";
            }

            if (ddlState.SelectedIndex == 0)
            {
                msg += "Enter State Name. \\n";
            }
            if (ddlproState.SelectedIndex == 0)
            {
                msg += "Select ProFessional State Name. \\n";
            }
            if (ddlPerState.SelectedIndex == 0)
            {
                msg += "Select Permanent State Name. \\n";
            }
            if (ddlRestate.SelectedIndex == 0)
            {
                msg += "Select Residential State Name. \\n";
            }
            if (ddlorg.SelectedIndex == 0)
            {
                msg += "Select Organization Name. \\n";
            }
            if (ddldept.SelectedIndex == 0)
            {
                msg += "Select Department Name. \\n";
            }
            if (ddldesig.SelectedIndex == 0)
            {
                msg += "Select Designation Name. \\n";
            }
            if (txtDDno.Text == "")
            {
                msg += "Enter DD NO. \\n";
            }

            if (txtDrwan.Text == "")
            {
                msg += "Enter Drawn in the name of(DD). \\n";
            }

            if (txtdate.Text == "")
            {
                msg += "Select Date. \\n";
            }

            if (txtBank.Text == "")
            {
                msg += "Enter Bank Name. \\n";
            }

            if (txtBranch.Text == "")
            {
                msg += "Enter Branch Name. \\n";
            }

            if (txtreason.Text == "")
            {
                msg += "Enter Reason of transfer. \\n";
            }

            if (txtNameofCouncil.Text == "")
            {
                msg += "Enter Council Name. \\n";
            }

            if (txtaddressd.Text == "")
            {
                msg += "Enter Address. \\n";
            }
            if (txtPerAdd.Text == "")
            {
                msg += "Enter Permanent Address. \\n";
            }
            if (txtPerCity.Text == "")
            {
                msg += "Enter Permanent Address City Name. \\n";
            }
            if (txtPerPinCode.Text == "")
            {
                msg += "Enter Permanent Address Pincode No. \\n";
            }
            if (txtPerDistrict.Text == "")
            {
                msg += "Enter Permanent Address District Name. \\n";
            }
            if (txtResAdd.Text == "")
            {
                msg += "Enter Resdidential Address. \\n";
            }
            if (txtResCity.Text == "")
            {
                msg += "Enter Residential Address City Name. \\n";
            }
            if (txtResDistrict.Text == "")
            {
                msg += "Enter Residential Address District Name. \\n";
            }
            if (txtResPinCode.Text == "")
            {
                msg += "Enter Residential Address Pincode No. \\n";
            }
            if (txtProAdd.Text == "")
            {
                msg += "Enter Professional Address. \\n";
            }
            if (txtProCity.Text == "")
            {
                msg += "Enter Professional Address City Name. \\n";
            }
            if (txtProDistrict.Text == "")
            {
                msg += "Enter Professional Address Distirct Name. \\n";
            }
            if (txtProPinCode.Text == "")
            {
                msg += "Enter Professional Address Pincode No. \\n";
            }
            if (msg == "")
            {
                string Validity = Convert.ToDateTime(txtValidity.Text, cult).ToString("yyyy/MM/dd");
                string dob = Convert.ToDateTime(txtDOBb.Text, cult).ToString("yyyy/MM/dd");
                string mydate = Convert.ToDateTime(txtdate.Text, cult).ToString("yyyy/MM/dd");
                string Appdate = Convert.ToDateTime(DateTime.Now, cult).ToString("yyyy/MM/dd");
                string Applicantimg = "";
                string ApplicantBirth = "";
                string Applicantdegree = "";
                string ApplicantDD = "";
                string Applicantregcert = "";
                string ApplicantSign = "";
                string DemandDraftMPSVC = "";

                if (filUploadImg.HasFile)
                {
                    Applicantimg = Guid.NewGuid() + "-" + filUploadImg.PostedFile.FileName;
                    filUploadImg.SaveAs(Server.MapPath("~/Upload_Certificate/" + Path.GetFileName(Applicantimg)));

                }
                else
                {
                    Applicantimg = ViewState["img"].ToString();
                }

                if (filUploadBirthproof.HasFile)
                {
                    ApplicantBirth = Guid.NewGuid() + "-" + filUploadBirthproof.PostedFile.FileName;
                    filUploadBirthproof.SaveAs(Server.MapPath("~/Upload_Certificate/" + Path.GetFileName(ApplicantBirth)));
                }
                else
                {
                    ApplicantBirth = ViewState["BirthCertificate"].ToString();
                }
                if (filUploadDegree.HasFile)
                {
                    Applicantdegree = Guid.NewGuid() + "-" + filUploadDegree.PostedFile.FileName;
                    filUploadDegree.SaveAs(Server.MapPath("~/Upload_Certificate/" + Path.GetFileName(Applicantdegree)));
                }
                else
                {
                    Applicantdegree = ViewState["Degree"].ToString();
                }
                if (filUploadDD.HasFile)
                {
                    ApplicantDD = Guid.NewGuid() + "-" + filUploadDD.PostedFile.FileName;
                    filUploadDD.SaveAs(Server.MapPath("~/Upload_Certificate/" + Path.GetFileName(ApplicantDD)));
                }
                else
                {
                    ApplicantDD = ViewState["DD"].ToString();
                   
                }

                if (filUploadRegisCert.HasFile)
                {
                    Applicantregcert = Guid.NewGuid() + "-" + filUploadRegisCert.PostedFile.FileName;
                    filUploadRegisCert.SaveAs(Server.MapPath("~/Upload_Certificate/" + Path.GetFileName(Applicantregcert)));
                }
                else
                {
                    Applicantregcert = ViewState["regcertificate"].ToString();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('Registration Certificate Not uploaded');", true);
                    //return;                   
                }

                if (filUploadDomicile.HasFile)
                {
                    ApplicantSign = Guid.NewGuid() + "-" + filUploadDomicile.PostedFile.FileName;
                    filUploadDomicile.SaveAs(Server.MapPath("~/Upload_Certificate/" + Path.GetFileName(ApplicantSign)));

                }
                else
                {
                    ApplicantSign = ViewState["DomicileCertificate"].ToString();
                }
                // start on 26-03-2022
                if (filupDD_forMPSVC.HasFile)
                {
                    DemandDraftMPSVC = Guid.NewGuid() + "-" + filupDD_forMPSVC.PostedFile.FileName;
                    filupDD_forMPSVC.SaveAs(Server.MapPath("~/Upload_Certificate/" + Path.GetFileName(DemandDraftMPSVC)));

                }
                else
                {
                    DemandDraftMPSVC = ViewState["DDMPSVC"].ToString();
                }
                // End on 26-03-2022
                string Tid = "";
                //string TempTranId = "";
                string editApplicationNo = "";
                string applicationno = "";
                string rbmobileprefered = "";
                if (rbmobile1.Checked == true)
                {
                    rbmobileprefered = "1";
                }
                else
                {
                    rbmobileprefered = "0";
                }
                if (Request.QueryString["editTransfer"] != null)
                {
                    string[] arr = Request.QueryString["editTransfer"].ToString().Split("*".ToCharArray());
                    string applicationNo = arr[1];
                    Tid = arr[0];
                    DataSet dsDetails = obj.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
                    editApplicationNo = dsDetails.Tables[1].Rows[0]["ApplicationNo"].ToString();
                }
                else
                {
                    DataSet dsregno = obj.ByProcedure("UpdateVerication", new string[] { "flag", "RegiNo" }, new string[] { "2", txtRegNo.Text.Trim() }, "dataset");
                    applicationno = dsregno.Tables[0].Rows[0]["ApplicationNo"].ToString();
                }


                string regStatus = "";
                if (Request.QueryString["editTransfer"] != null)
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
                string isOnline = "";
                if (rboffline.Checked == true)
                {
                    isOnline = "0";
                }
                else
                {
                    isOnline = "1";
                }
                if (Request.QueryString["editTransfer"] != null)
                {

                    string Validupto = "";
                    string[] arr = Request.QueryString["editTransfer"].ToString().Split("*".ToCharArray());
                    string applicationNo = arr[1];
                    Tid = arr[0];
                    DataSet dsDetails = obj.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
                    DateTime Lvalue = DateTime.Now;
                    DateTime rValue = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["Validupto"].ToString());
                    if (Lvalue > rValue)
                    {
                        DateTime nowdate = DateTime.Now;
                        DateTime Fiveyearbackdate = nowdate.AddYears(5);
                        Validupto = GetValidUpToDate(Convert.ToDateTime(Fiveyearbackdate, cult).ToString("yyyy/MM/dd"));
                    }
                    else
                    {
                        Validupto = dsDetails.Tables[0].Rows[0]["Validupto"].ToString();
                    }

                    if (rboffline.Checked == true)// update & verify by admin1,2. 
                    {
                        //START both procedure change by bhanu on 26-03-2022 due to Add aditional payment column
                        //ds = obj.ByProcedure("USP_TransferNewtoMP", new string[] { "flag", "RegiNo",  "FName", "MName", "LName", "FatherName","DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerPost", "PerTehsil", "PerPinCode", "PerState", 
                        //                     "PreferedAdd", "MobileNo", "EmailId", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "Demand_Draft", "File5",
                        //                     "Isonline", "ChequeNo", "BankName", "ChequeDate","RegistrationStatus", "ApplicationRequestId", "Transferstateid", "MobileNo2","PreferedPhoneNo", "Remark","State_Veterinary_Council_namepresent", "Drawn_name_DD", "Registrar_Name", "Registrar_Adresse", "Bank_Branch_Name","RegistrationCertificate","Validupto" },
                        //                     new string[] { "2",hf_regno.Value, txtApplicant.Text.Trim(),txtMiddleName.Text.Trim(),txtLastname.Text.Trim(), txtFHname.Text.Trim(),dob, ddlgender.SelectedValue, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text.Trim(), ddldept.SelectedValue, txtDept.Text.Trim(), ddldesig.SelectedValue, txtDesig.Text.Trim(), txtResAdd.Text.Trim(), txtResCity.Text.Trim(), txtResDistrict.Text.Trim(), txtRessPost.Text.Trim(),txtRessTehsil.Text.Trim(), txtResPinCode.Text.Trim(),ddlRestate.SelectedValue,txtProAdd.Text.Trim(),txtProCity.Text.Trim(), txtProDistrict.Text.Trim(), txtProPost.Text.Trim(), txtProTehsil.Text.Trim(), txtProPinCode.Text.Trim(),ddlproState.SelectedValue,txtPerAdd.Text.Trim(),txtPerCity.Text.Trim(), txtPerDistrict.Text.Trim(),txtPerPost.Text.Trim(), txtPerTehsil.Text.Trim(),txtPerPinCode.Text.Trim(),ddlPerState.SelectedValue,
                        //                     ddlPreffAddress.SelectedValue,txtMobileno.Text.Trim(), txtEmailID.Text.Trim(), ddlUniversity.SelectedValue,ddluniversity2.SelectedValue,ddluniversity3.SelectedValue,
                        //                     ddluniversity4.SelectedValue,ddlCollege.SelectedValue,ddlcollege2.SelectedValue,ddlcollege3.SelectedValue,ddlcollege4.SelectedValue,ddlY1.SelectedValue,ddlY2.SelectedValue,
                        //                     ddlY3.SelectedValue,ddlY4.SelectedValue, ApplicantSign, Applicantdegree, Applicantimg, ApplicantDD, ApplicantBirth,isOnline, txtDDno.Text.Trim(), txtBank.Text.Trim(),mydate, regStatus,"2",ddlState.SelectedValue,txtmobileother.Text.Trim(),rbmobileprefered, txtreason.Text.Trim(), txtNameofsvp.Text.Trim(),txtDrwan.Text.Trim(), txtNameofCouncil.Text.Trim(), txtaddressd.Text.Trim(),txtBranch.Text.Trim(),Applicantregcert,Validupto }, "dataset");

                        //ds = obj.ByProcedure("USP_TransferRegisMP_trasanctiondtl", new string[] { "flag", "RegistrationStatus", "id" }, new string[] { "2", regStatus, Tid }, "");
                        //END both procedure change by bhanu on 26-03-2022 due to Add aditional payment column


                        //START HERE---  Add new column in both procedure change by bhanu on 26-03-2022 due to Add aditional payment column
                        ds = obj.ByProcedure("USP_TransferNewtoMP", new string[] { "flag", "RegiNo",  "FName", "MName", "LName", "FatherName","DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerPost", "PerTehsil", "PerPinCode", "PerState", 
                                             "PreferedAdd", "MobileNo", "EmailId", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "Demand_Draft", "File5",
                                             "Isonline", "ChequeNo", "BankName", "ChequeDate","RegistrationStatus", "ApplicationRequestId", "Transferstateid", "MobileNo2","PreferedPhoneNo", "Remark","State_Veterinary_Council_namepresent", "Drawn_name_DD", "Registrar_Name", "Registrar_Adresse", "Bank_Branch_Name","RegistrationCertificate","Validupto","CheckDDno_MPSVC","DrawnameDD_MPSVC","PaymentDate_MPSVC","BankName_MPSVC","BranchName_MPSVC","DemandDraft_MPSVC","Pagename" },
                                             new string[] { "2",hf_regno.Value, txtApplicant.Text.Trim(),txtMiddleName.Text.Trim(),txtLastname.Text.Trim(), txtFHname.Text.Trim(),dob, ddlgender.SelectedValue, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text.Trim(), ddldept.SelectedValue, txtDept.Text.Trim(), ddldesig.SelectedValue, txtDesig.Text.Trim(), txtResAdd.Text.Trim(), txtResCity.Text.Trim(), txtResDistrict.Text.Trim(), txtRessPost.Text.Trim(),txtRessTehsil.Text.Trim(), txtResPinCode.Text.Trim(),ddlRestate.SelectedValue,txtProAdd.Text.Trim()
                                             ,txtProCity.Text.Trim(), txtProDistrict.Text.Trim(), txtProPost.Text.Trim(), txtProTehsil.Text.Trim(), txtProPinCode.Text.Trim(),ddlproState.SelectedValue,txtPerAdd.Text.Trim(),txtPerCity.Text.Trim(), txtPerDistrict.Text.Trim(),txtPerPost.Text.Trim(), txtPerTehsil.Text.Trim(),txtPerPinCode.Text.Trim(),ddlPerState.SelectedValue,
                                             ddlPreffAddress.SelectedValue,txtMobileno.Text.Trim(), txtEmailID.Text.Trim(), ddlUniversity.SelectedValue,ddluniversity2.SelectedValue,ddluniversity3.SelectedValue,ddluniversity4.SelectedValue,ddlCollege.SelectedValue,ddlcollege2.SelectedValue,ddlcollege3.SelectedValue,ddlcollege4.SelectedValue,ddlY1.SelectedValue,ddlY2.SelectedValue,
                                             ddlY3.SelectedValue,ddlY4.SelectedValue, ApplicantSign, Applicantdegree, Applicantimg, ApplicantDD, ApplicantBirth,isOnline, txtDDno.Text.Trim(), txtBank.Text.Trim(),mydate, regStatus,"2",ddlState.SelectedValue,txtmobileother.Text.Trim(),rbmobileprefered, txtreason.Text.Trim(), txtNameofsvp.Text.Trim(),txtDrwan.Text.Trim(), txtNameofCouncil.Text.Trim(),
                                             txtaddressd.Text.Trim(),txtBranch.Text.Trim(),Applicantregcert,Validupto, txtCheckDD_forMPSVC.Text.Trim(),txtdrawnamedd_forMPSVC.Text.Trim(), Convert.ToDateTime(txtpaymentdate_forMPSVC.Text, cult).ToString("yyyy/MM/dd"),txtBankname_forMPSVC.Text.Trim(),txtBranch_forMPSVC.Text.Trim(),DemandDraftMPSVC, "TransferRegistrationoutofMP.aspx" }, "dataset");

                        ds = obj.ByProcedure("USP_TransferRegisMP_trasanctiondtl", new string[] { "flag", "RegistrationStatus", "id" }, new string[] { "2", regStatus, Tid }, "");
                        // END HERE----  Add new column in both procedure change by bhanu on 26-03-2022 due to Add aditional payment column
                    }
                }

                else
                {
                    if (rboffline.Checked == true)// Candidate Fetch All Data By registration no. And Apply to Transfer. 
                    {
                        // both procedure change by bhanu on 26-03-2022 due to Add aditional payment column
                        //ds = obj.ByProcedure("USP_TransferNewtoMP", new string[] { "flag", "RegiNo",  "FName", "MName", "LName", "FatherName","DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerPost", "PerTehsil", "PerPinCode", "PerState", 
                        //                     "PreferedAdd", "MobileNo", "EmailId", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "Demand_Draft", "File5",
                        //                     "Isonline", "ChequeNo", "BankName", "ChequeDate","RegistrationStatus", "ApplicationRequestId", "Transferstateid", "MobileNo2","PreferedPhoneNo", "Remark","State_Veterinary_Council_namepresent", "Drawn_name_DD", "Registrar_Name", "Registrar_Adresse", "Bank_Branch_Name","RegistrationCertificate" },
                        //                     new string[] { "1",hf_regno.Value, txtApplicant.Text.Trim(),txtMiddleName.Text.Trim(),txtLastname.Text.Trim(), txtFHname.Text.Trim(),dob, ddlgender.SelectedValue, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text.Trim(), ddldept.SelectedValue, txtDept.Text.Trim(), ddldesig.SelectedValue, txtDesig.Text.Trim(), txtResAdd.Text.Trim(), txtResCity.Text.Trim(), txtResDistrict.Text.Trim(), txtRessPost.Text.Trim(),txtRessTehsil.Text.Trim(), txtResPinCode.Text.Trim(),ddlRestate.SelectedValue,txtProAdd.Text.Trim(),txtProCity.Text.Trim(), txtProDistrict.Text.Trim(), txtProPost.Text.Trim(), txtProTehsil.Text.Trim(), txtProPinCode.Text.Trim(),ddlproState.SelectedValue,txtPerAdd.Text.Trim(),txtPerCity.Text.Trim(), txtPerDistrict.Text.Trim(),txtPerPost.Text.Trim(), txtPerTehsil.Text.Trim(),txtPerPinCode.Text.Trim(),ddlPerState.SelectedValue,
                        //                     ddlPreffAddress.SelectedValue,txtMobileno.Text.Trim(), txtEmailID.Text.Trim(), ddlUniversity.SelectedValue,ddluniversity2.SelectedValue,ddluniversity3.SelectedValue,
                        //                     ddluniversity4.SelectedValue,ddlCollege.SelectedValue,ddlcollege2.SelectedValue,ddlcollege3.SelectedValue,ddlcollege4.SelectedValue,ddlY1.SelectedValue,ddlY2.SelectedValue,
                        //                     ddlY3.SelectedValue,ddlY4.SelectedValue, ApplicantSign, Applicantdegree, Applicantimg, ApplicantDD, ApplicantBirth,isOnline, txtDDno.Text.Trim(), txtBank.Text.Trim(),mydate, regStatus,"2",ddlState.SelectedValue,txtmobileother.Text.Trim(),rbmobileprefered, txtreason.Text.Trim(), txtNameofsvp.Text.Trim(),txtDrwan.Text.Trim(), txtNameofCouncil.Text.Trim(), txtaddressd.Text.Trim(),txtBranch.Text.Trim(),Applicantregcert }, "dataset");

                        //ds = obj.ByProcedure("USP_TransferRegisMP_trasanctiondtl", new string[] { "flag", "ApplicationNo", "ApplicationRequestId", "Applydate", "Isonline", "TotalAmount", "RegistrationFees", "RenewalFees", "ReEstablishmentFees", "Transferfees", "ServiceCharge", "LateFees", "ChequeNo", "BankName", "ChequeDate", "RegistrationStatus", "TransactionStatus", "TransactionId", "Bank_Branch_Name", "Drawn_name_DD" },
                        // new string[] { "1", applicationno, "2", Appdate, isOnline, HF_Totalamount.Value, "0", HF_RenewalFees.Value, HF_ReEstabilishmentFees.Value, HF_transferFees.Value, HF_ServiceChagre.Value, HF_LateFees.Value, txtDDno.Text.Trim(), txtBank.Text.Trim(), mydate, regStatus, "1", "", txtBranch.Text.Trim(), txtDrwan.Text.Trim() }, "dataset");

                        //Add new column in both procedure change by bhanu on 26-03-2022 due to Add aditional payment column
                        ds = obj.ByProcedure("USP_TransferNewtoMP", new string[] { "flag", "RegiNo",  "FName", "MName", "LName", "FatherName","DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerPost", "PerTehsil", "PerPinCode", "PerState", 
                                             "PreferedAdd", "MobileNo", "EmailId", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "Demand_Draft", "File5",
                                             "Isonline", "ChequeNo", "BankName", "ChequeDate","RegistrationStatus", "ApplicationRequestId", "Transferstateid", "MobileNo2","PreferedPhoneNo", "Remark","State_Veterinary_Council_namepresent", "Drawn_name_DD", "Registrar_Name", "Registrar_Adresse", "Bank_Branch_Name","RegistrationCertificate", "CheckDDno_MPSVC","DrawnameDD_MPSVC","PaymentDate_MPSVC","BankName_MPSVC","BranchName_MPSVC","DemandDraft_MPSVC","Pagename" },
                                             new string[] { "1",hf_regno.Value, txtApplicant.Text.Trim(),txtMiddleName.Text.Trim(),txtLastname.Text.Trim(), txtFHname.Text.Trim(),dob, ddlgender.SelectedValue, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text.Trim(), ddldept.SelectedValue, txtDept.Text.Trim(), ddldesig.SelectedValue, txtDesig.Text.Trim(), txtResAdd.Text.Trim(), txtResCity.Text.Trim(), txtResDistrict.Text.Trim(), txtRessPost.Text.Trim(),txtRessTehsil.Text.Trim(), txtResPinCode.Text.Trim(),ddlRestate.SelectedValue,txtProAdd.Text.Trim(),txtProCity.Text.Trim(), txtProDistrict.Text.Trim(), txtProPost.Text.Trim(), txtProTehsil.Text.Trim(), txtProPinCode.Text.Trim(),ddlproState.SelectedValue,txtPerAdd.Text.Trim(),txtPerCity.Text.Trim(), txtPerDistrict.Text.Trim(),txtPerPost.Text.Trim(), txtPerTehsil.Text.Trim(),txtPerPinCode.Text.Trim(),ddlPerState.SelectedValue,
                                             ddlPreffAddress.SelectedValue,txtMobileno.Text.Trim(), txtEmailID.Text.Trim(), ddlUniversity.SelectedValue,ddluniversity2.SelectedValue,ddluniversity3.SelectedValue,
                                             ddluniversity4.SelectedValue,ddlCollege.SelectedValue,ddlcollege2.SelectedValue,ddlcollege3.SelectedValue,ddlcollege4.SelectedValue,ddlY1.SelectedValue,ddlY2.SelectedValue,
                                             ddlY3.SelectedValue,ddlY4.SelectedValue, ApplicantSign, Applicantdegree, Applicantimg, ApplicantDD, ApplicantBirth,isOnline, txtDDno.Text.Trim(), txtBank.Text.Trim(),mydate, regStatus,"2",ddlState.SelectedValue,txtmobileother.Text.Trim(),rbmobileprefered, txtreason.Text.Trim(), txtNameofsvp.Text.Trim(),txtDrwan.Text.Trim(), txtNameofCouncil.Text.Trim(), txtaddressd.Text.Trim(),txtBranch.Text.Trim(),Applicantregcert, txtCheckDD_forMPSVC.Text.Trim(),txtdrawnamedd_forMPSVC.Text.Trim(), Convert.ToDateTime(txtpaymentdate_forMPSVC.Text, cult).ToString("yyyy/MM/dd"),txtBankname_forMPSVC.Text.Trim(),txtBranch_forMPSVC.Text.Trim(),DemandDraftMPSVC,"TransferRegistrationoutofMP.aspx" }, "dataset");

                        ds = obj.ByProcedure("USP_TransferRegisMP_trasanctiondtl", new string[] { "flag", "ApplicationNo", "ApplicationRequestId", "Applydate", "Isonline", "TotalAmount", "RegistrationFees", "RenewalFees", "ReEstablishmentFees", "Transferfees", "ServiceCharge", "LateFees", "ChequeNo", "BankName", "ChequeDate", "RegistrationStatus", "TransactionStatus", "TransactionId", "Bank_Branch_Name", "Drawn_name_DD", "chequeno_MPSVC", "DrawNameDD_MPSVC", "PaymentDate_MPSVC", "Bankname_MPSVC", "BranchName_MPSVC" },
                            new string[] { "1", applicationno, "2", Appdate, isOnline, HF_Totalamount.Value, "0", HF_RenewalFees.Value, HF_ReEstabilishmentFees.Value, HF_transferFees.Value, HF_ServiceChagre.Value, HF_LateFees.Value, txtDDno.Text.Trim(), txtBank.Text.Trim(), mydate, regStatus, "1", "", txtBranch.Text.Trim(), txtDrwan.Text.Trim(), txtCheckDD_forMPSVC.Text.Trim(), txtdrawnamedd_forMPSVC.Text.Trim(), Convert.ToDateTime(txtpaymentdate_forMPSVC.Text, cult).ToString("yyyy/MM/dd"), txtBankname_forMPSVC.Text.Trim(), txtBranch_forMPSVC.Text.Trim() }, "dataset");
                    }
                }

                if (ds.Tables[0].Rows[0]["Msg"].ToString() == "OK")
                {
                    string Msg = ds.Tables[0].Rows[0]["Msg"].ToString();
                    string ErrMsg = ds.Tables[0].Rows[0]["ErrMsg"].ToString();

                    if (Request.QueryString["editTransfer"] != null)
                    {
                        if (regStatus == "3")
                        {
                            DataSet dsmail = obj.ByProcedure("UpdateVerication", new string[] { "flag", "RegiNo" }, new string[] { "3", txtRegNo.Text.Trim() }, "dataset");
                            string regno = dsmail.Tables[0].Rows[0]["RegiNo"].ToString();
                            string val = Convert.ToDateTime(dsmail.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");
                            lblalert.Text = "Registration no. '" + regno + "' verified successfully valid upto '" + val + "' ";
                        }

                        else
                        {
                            lblalert.Text = "Application forwarded for second level verification.";
                        }

                        HF_Ok.Value = "0";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopTemAndConditionOnSave();", true);

                    }

                    else
                    {

                        if (rboffline.Checked == true)
                        {
                            DataSet dsSentMail = obj.ByProcedure("UpdateVerication", new string[] { "flag", "RegiNo" }, new string[] { "3", txtRegNo.Text.Trim() }, "dataset");
                            string mail = dsSentMail.Tables[0].Rows[0]["EmailId"].ToString();
                            string subject = "MPSVC Registration Mail";
                            string body = obj.CreateEmailBody(2, hf_regno.Value);
                            string mbMessage = obj.CreateMessageBody(2, hf_regno.Value); // Message Body Function
                            if (rbmobileprefered == "1")
                            {
                                mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo"].ToString();
                            }
                            else
                            {
                                mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo2"].ToString();
                            }
                            obj.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true);
                            obCommonFuction.EmptyTextBoxes(this);
                            lblMsg.Text = obj.SaveAlert(ErrMsg);
                        }
                    }

                }
                if (btnsubmit.Text == "Save&Pay")
                {
                    btnprint_Click(sender, e);
                }


                else
                {
                    lblMsg.Text = obj.ErrorAlert(ds.Tables[0].Rows[0]["ErrMsg"].ToString());
                }

                Cleartextbox();
                hidefrom.Visible = false;

            }

            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alert('" + msg + "');", true);
            }

        }

        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());

        }
    }

    private void FillHiddenCalculation(DataSet ds)
    {

        if (ds.Tables[0].Rows.Count > 0)
        {
            DateTime Lvalue = DateTime.Now;
            DateTime rValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"].ToString());
            int count = Math.Abs((Lvalue.Month - rValue.Month) + 12 * (Lvalue.Year - rValue.Year));
            if (Lvalue > rValue)
            {
                HF_RegistationFees.Value = "0";
                if (count < 120)
                {
                    HF_RenewalFees.Value = "0";
                    HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
                    HF_ReEstabilishmentFees.Value = "0";
                    HF_Totalamount.Value = (15 + Convert.ToInt32(count) * 5 + 25).ToString();
                }
                else
                {
                    HF_RenewalFees.Value = "0";
                    HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
                    HF_ReEstabilishmentFees.Value = "0";
                    HF_Totalamount.Value = (15 + Convert.ToInt32(count) * 5 + 25).ToString();
                }

            }
            else
            {
                HF_RenewalFees.Value = "0";
                HF_LateFees.Value = "0";
                HF_ReEstabilishmentFees.Value = "0";
                HF_Totalamount.Value = "15";
            }
        }

    }
    protected void Cleartextbox()
    {
        txtApplicant.Text = "";
        txtMiddleName.Text = "";
        txtLastname.Text = "";
        txtFHname.Text = "";
        txtDOBb.Text = "";
        ddlgender.ClearSelection();
        txtResAdd.Text = "";
        txtResCity.Text = "";
        txtResDistrict.Text = "";
        txtResPinCode.Text = "";
        txtRessPost.Text = "";
        txtRessTehsil.Text = "";
        txtPerAdd.Text = "";
        txtPerCity.Text = "";
        txtPerDistrict.Text = "";
        txtPerPinCode.Text = "";
        txtPerPost.Text = "";
        txtPerTehsil.Text = "";
        txtProAdd.Text = "";
        txtProCity.Text = "";
        txtProDistrict.Text = "";
        txtProPinCode.Text = "";
        txtProPost.Text = "";
        txtProTehsil.Text = "";
        ddlorg.ClearSelection();
        ddldept.ClearSelection();
        ddldesig.ClearSelection();
        ddlPerState.ClearSelection();
        ddlproState.ClearSelection();
        ddlRestate.ClearSelection();
        ddlPreffAddress.ClearSelection();
        ddlPresentOcc.ClearSelection();
        ddluniversity2.ClearSelection();
        ddlUniversity.ClearSelection();
        ddluniversity3.ClearSelection();
        ddluniversity4.ClearSelection();
        ddlCollege.ClearSelection();
        ddlcollege2.ClearSelection();
        ddlcollege3.ClearSelection();
        ddlcollege4.ClearSelection();
        ddlY1.ClearSelection();
        ddlY2.ClearSelection();
        ddlY3.ClearSelection();
        ddlY4.ClearSelection();
        ddlState.ClearSelection();
        txtaddressd.Text = "";
        txtNameofCouncil.Text = "";
        txtreason.Text = "";
        txtValidity.Text = "";
        txtBank.Text = "";
        txtBranch.Text = "";
        txtdate.Text = "";
        txtDDno.Text = "";
        txtDrwan.Text = "";
        txtBankname_forMPSVC.Text = "";
        txtBranch_forMPSVC.Text = "";
        txtCheckDD_forMPSVC.Text = "";
        txtpaymentdate_forMPSVC.Text = "";
        txtdrawnamedd_forMPSVC.Text = "";
    }

    protected void Formreadonly()
    {
        txtApplicant.ReadOnly = true;
        txtMiddleName.ReadOnly = true;
        txtLastname.ReadOnly = true;
        txtFHname.ReadOnly = true;
        txtDOBb.Enabled = false;
        txtResAdd.ReadOnly = true;
        txtResCity.ReadOnly = true;
        txtResDistrict.ReadOnly = true;
        txtResPinCode.ReadOnly = true;
        txtRessPost.ReadOnly = true;
        txtRessTehsil.ReadOnly = true;
        txtPerAdd.ReadOnly = true;
        txtPerCity.ReadOnly = true;
        txtPerDistrict.ReadOnly = true;
        txtPerPinCode.ReadOnly = true;
        txtPerPost.ReadOnly = true;
        txtPerTehsil.ReadOnly = true;
        txtProAdd.ReadOnly = true;
        txtProCity.ReadOnly = true;
        txtProDistrict.ReadOnly = true;
        txtProPinCode.ReadOnly = true;
        txtProPost.ReadOnly = true;
        txtProTehsil.ReadOnly = true;
        ddlgender.Enabled = false;
        ddlorg.Enabled = false;
        ddldept.Enabled = false;
        ddldesig.Enabled = false;
        ddlPerState.Enabled = false;
        ddlPresentOcc.Enabled = false;
        ddlproState.Enabled = false;
        ddlRestate.Enabled = false;
        ddlPreffAddress.Enabled = false;
        txtEmailID.ReadOnly = true;
        txtMobileno.ReadOnly = true;
        txtmobileother.ReadOnly = true;
        ddlState.Enabled = false;
        txtaddressd.ReadOnly = true;
        //txtNameofCouncil.ReadOnly = true;
        txtreason.ReadOnly = true;
        //txtValidity.Enabled = false;
        txtBank.ReadOnly = true;
        txtBranch.ReadOnly = true;
        txtdate.Enabled = false;
        txtDDno.ReadOnly = true;
        txtDrwan.ReadOnly = true;
        txtReginumber.ReadOnly = true;

        txtBankname_forMPSVC.ReadOnly = true;
        txtBranch_forMPSVC.ReadOnly = true;
        txtCheckDD_forMPSVC.ReadOnly = true;
        txtpaymentdate_forMPSVC.ReadOnly = true;
        //txtdrawnamedd_forMPSVC.ReadOnly = true;
    }

    private string GetValidUpToDate(string InComingDate)
    {
        string[] slipDate = InComingDate.Split("".ToCharArray());
        string FinalDate = slipDate[0];
        string[] FDate = FinalDate.Split("/".ToCharArray());
        int current_month = Convert.ToInt32(FDate[1]);
        if (current_month <= 3)
        {
            FDate[0] = (Convert.ToInt32(FDate[0]) - 1).ToString();
        }
        string Date_Final = FDate[0] + "/03/31";
        return Date_Final;
    }
    //protected void popup_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        if (filUploadImg.HasFile)
    //        {
    //            string Applicantimg = Guid.NewGuid() + "-" + filUploadImg.PostedFile.FileName;
    //            filUploadImg.SaveAs(Server.MapPath("~/Upload_Doc/Aplicant_Images/" + Path.GetFileName(Applicantimg)));
    //            lblurl.Text = "~/Upload_Doc/Aplicant_Images/" + Applicantimg.ToString();
    //            ViewState["Aplicant_Images"] = Applicantimg;
    //            imgApplicant.ImageUrl = lblurl.Text;


    //        }

    //        if (filUploadBirthproof.HasFile)
    //        {
    //            string ApplicantBirth = Guid.NewGuid() + "-" + filUploadBirthproof.PostedFile.FileName;
    //            filUploadBirthproof.SaveAs(Server.MapPath("~/Upload_Doc/Birth_Proof/" + Path.GetFileName(ApplicantBirth)));
    //            lblBirth.Text = "~/Upload_Doc/Birth_Proof/" + ApplicantBirth.ToString();
    //            ViewState["Birth_Proof"] = ApplicantBirth;
    //            imgBirthproof.ImageUrl = lblBirth.Text;

    //        }

    //        if (filUploadDegree.HasFile)
    //        {
    //            string Applicantdegree = Guid.NewGuid() + "-" + filUploadDegree.PostedFile.FileName;
    //            filUploadDegree.SaveAs(Server.MapPath("~/Upload_Doc/Degree_certificate/" + Path.GetFileName(Applicantdegree)));
    //            lblDegricert.Text = "~/Upload_Doc/Degree_certificate/" + Applicantdegree.ToString();
    //            ViewState["Degree_certificate"] = Applicantdegree;
    //            imgDegreeCertifiacte.ImageUrl = lblDegricert.Text;

    //        }

    //        if (filUploadDD.HasFile)
    //        {
    //            string ApplicantDD = Guid.NewGuid() + "-" + filUploadDD.PostedFile.FileName;
    //            filUploadDD.SaveAs(Server.MapPath("~/Upload_Doc/Demand_Draft/" + Path.GetFileName(ApplicantDD)));
    //            lblDD.Text = "~/Upload_Doc/Demand_Draft/" + ApplicantDD.ToString();
    //            ViewState["Demand_Draft"] = ApplicantDD;
    //            imgDD.ImageUrl = lblDD.Text;

    //        }

    //        if (filUploadRegisCert.HasFile)
    //        {
    //            string Applicantregcert = Guid.NewGuid() + "-" + filUploadRegisCert.PostedFile.FileName;
    //            filUploadRegisCert.SaveAs(Server.MapPath("~/Upload_Doc/Registration_certificate/" + Path.GetFileName(Applicantregcert)));
    //            lblregicert.Text = "~/Upload_Doc/Registration_certificate/" + Applicantregcert.ToString();
    //            ViewState["Registration_certificate"] = Applicantregcert;
    //            imgReegiCert.ImageUrl = lblregicert.Text;

    //        }

    //        if (filUploadSign.HasFile)
    //        {
    //            string ApplicantSign = Guid.NewGuid() + "-" + filUploadSign.PostedFile.FileName;
    //            filUploadSign.SaveAs(Server.MapPath("~/Upload_Doc/Sign/" + Path.GetFileName(ApplicantSign)));
    //            lblSign.Text = "~/Upload_Doc/Sign/" + ApplicantSign.ToString();
    //            ViewState["Sign"] = ApplicantSign;
    //            imgSign.ImageUrl = lblSign.Text;

    //        }
    //        //--------------------------------- 
    //        txtName2.Text = txtApplicant.Text;
    //        txtFHofname2.Text = txtFHname.Text;
    //        txtdateofbirth2.Text = txtDOBb.Text;
    //        dldGender2.SelectedValue = ddlgender.SelectedValue;
    //        //txtNameofCollege2.Text = ddlCollege.SelectedItem.ToString();
    //        //txtDigri2.Text = txtDegree.Text;
    //        //txtResidential2.Text = txtAddress.Text;
    //        //txtinstitute2.Text = ddlUniversity.SelectedItem.ToString();
    //        txtno2.Text = txtMobileno.Text;
    //        txtmail2.Text = txtEmailID.Text;
    //        txtpr2.Text = txtNameofsvp.Text;
    //        txtRegistrationNumber2.Text = txtReginumber.Text;
    //        txtValidityofR2.Text = txtValidity.Text;
    //        txtregistrationisapplied2.Text = ddlState.SelectedItem.ToString();
    //        txtDemandNo2.Text = txtDDno.Text;
    //        Textdraw2.Text = txtDrwan.Text;
    //        Textdate2.Text = txtdate.Text;
    //        Textbank2.Text = txtBank.Text;
    //        TextBranch2.Text = txtBranch.Text;
    //        textreason2.Text = txtreason.Text;
    //        imgApplicant.ImageUrl = lblurl.Text;
    //        imgDD.ImageUrl = lblDD.Text;
    //        imgBirthproof.ImageUrl = lblBirth.Text;
    //        imgDegreeCertifiacte.ImageUrl = lblDegricert.Text;
    //        imgReegiCert.ImageUrl = lblregicert.Text;
    //        imgSign.ImageUrl = lblSign.Text;
    //        TextregisName2.Text = txtNameofCouncil.Text;
    //        TextRegistAdd.Text = txtaddressd.Text;
    //        ClientScript.RegisterStartupScript(this.GetType(), "popup", "ShowPopup();", true);


    //    }

    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //    }

    //}

    //protected void btndelete_Click(object sender, EventArgs e) // delete upload images if user cancel form 
    //{

    //    string Aplicant_Images = Path.Combine(Server.MapPath("~/Upload_Doc/Aplicant_Images/"), ViewState["Aplicant_Images"].ToString());
    //    string Birth_Proof = Path.Combine(Server.MapPath("~/Upload_Doc/Birth_Proof/"), ViewState["Birth_Proof"].ToString());
    //    string Degree_certificate = Path.Combine(Server.MapPath("~/Upload_Doc/Degree_certificate/"), ViewState["Degree_certificate"].ToString());
    //    string Demand_Draft = Path.Combine(Server.MapPath("~/Upload_Doc/Demand_Draft/"), ViewState["Demand_Draft"].ToString());
    //    string Registration_certificate = Path.Combine(Server.MapPath("~/Upload_Doc/Registration_certificate/"), ViewState["Registration_certificate"].ToString());
    //    string Sign = Path.Combine(Server.MapPath("~/Upload_Doc/Sign/"), ViewState["Sign"].ToString());



    //    if (File.Exists(Aplicant_Images))
    //    {
    //        File.Delete(Aplicant_Images);
    //    }
    //    if (File.Exists(Birth_Proof))
    //    {
    //        File.Delete(Birth_Proof);
    //    }
    //    if (File.Exists(Degree_certificate))
    //    {
    //        File.Delete(Degree_certificate);
    //    }
    //    if (File.Exists(Demand_Draft))
    //    {
    //        File.Delete(Demand_Draft);
    //    }
    //    if (File.Exists(Registration_certificate))
    //    {
    //        File.Delete(Registration_certificate);
    //    }
    //    if (File.Exists(Sign))
    //    {
    //        File.Delete(Sign);
    //    }

    //}
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet dsprint = obj.ByProcedure("UpdateVerication", new string[] { "flag", "RegiNo" }
                            , new string[] { "1", hf_regno.Value }, "dataset");

            if (dsprint.Tables[0].Rows.Count > 0)
            {

                //lblID.Text = dsprint.Tables[0].Rows[0]["RegiNo"].ToString();
                lblapllicant.Text = dsprint.Tables[0].Rows[0]["Name"].ToString();
                lblApplicantFH.Text = dsprint.Tables[0].Rows[0]["FatherName"].ToString();
                lblDOB.Text = Convert.ToDateTime(dsprint.Tables[0].Rows[0]["DOB"]).ToString("dd/MM/yyyy");
                lblGender.Text = dsprint.Tables[0].Rows[0]["Gender"].ToString();
                lblresidntialAddress.Text = dsprint.Tables[0].Rows[0]["PreferedAdd"].ToString();
                lblNO.Text = dsprint.Tables[0].Rows[0]["MobileNo"].ToString();
                lblemail.Text = dsprint.Tables[0].Rows[0]["EmailId"].ToString();
                lblPR.Text = dsprint.Tables[0].Rows[0]["State_Veterinary_Council_namepresent"].ToString();
                lblRn.Text = dsprint.Tables[0].Rows[0]["RegiNo"].ToString();                
                lblAppli.Text = dsprint.Tables[0].Rows[0]["StateName"].ToString();
                lblddno.Text = dsprint.Tables[0].Rows[0]["ChequeNo"].ToString();
                lblDddrname.Text = dsprint.Tables[0].Rows[0]["Drawn_name_DD"].ToString();
                lblDate.Text = dsprint.Tables[0].Rows[0]["alDate"].ToString();
                lblIssuebank.Text = dsprint.Tables[0].Rows[0]["BankName"].ToString();
                lblIssueBranch.Text = dsprint.Tables[0].Rows[0]["Bank_Branch_Name"].ToString();
                Lblrison.Text = dsprint.Tables[0].Rows[0]["Remark"].ToString();
                lblVetenaryCouncil.Text = dsprint.Tables[0].Rows[0]["Registrar_Name"].ToString();
                lblRAddress.Text = dsprint.Tables[0].Rows[0]["Registrar_Adresse"].ToString();
                lblddno.Text = dsprint.Tables[0].Rows[0]["ChequeNo"].ToString();
                lblAmount.Text = dsprint.Tables[0].Rows[0]["TotalAmount"].ToString();
                lblCollegeName.Text = dsprint.Tables[0].Rows[0]["CollegeName"].ToString();
                lblUniversity.Text = dsprint.Tables[0].Rows[0]["UniversityName"].ToString();
                // START Changes Done Of Change request on 21 Apr 22 By Bhanu.
                //lblDegreeName.Text = dsprint.Tables[0].Rows[0]["DegreeName"].ToString();                             
                DateTime Lvalue = DateTime.Now;
                DateTime rValue = Convert.ToDateTime(dsprint.Tables[0].Rows[0]["Validupto"].ToString());
                if (Lvalue > rValue)
                {
                    
                    lblVr.Text = "";
                }
                else
                {
                    lblVr.Text = Convert.ToDateTime(dsprint.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");
                }
                // START Changes Done Of Change request on 21 Apr 22 By Bhanu.
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "window.print('Divprint')", true);

        }


        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
    //protected void ddlUniversity_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        lblMsg.Text = "";

    //        ds = obj.ByProcedure("USP_University", new string[] { "flag", "ID" }
    //                        , new string[] { "2", ddlUniversity.SelectedValue }, "dataset");

    //        if (ds != null && ds.Tables[0].Rows.Count > 0)
    //        {
    //            //ddlCollege.DataTextField = "CollegeName";
    //            //ddlCollege.DataValueField = "ID";
    //            //ddlCollege.DataSource = ds.Tables[0];
    //            //ddlCollege.DataBind();
    //            //ddlCollege.Items.Insert(0, new ListItem("Select", "0"));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
    //    }
    //}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtRegNo.Text != "")
            {
                btnsubmit.Enabled = true;
                SearchRegistration();
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Please enter registration no.";

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void ddlorg_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            if (ddlorg.SelectedIndex > 0)
            {
                DataSet dt1 = obj.ByDataSet("select * from tbl_Departmentmaster where Organaizationid='" + ddlorg.SelectedValue + "'");
                if (dt1.Tables[0].Rows.Count > 0)
                {
                    ddldept.DataTextField = "DepaertmentName";
                    ddldept.DataValueField = "ID";
                    ddldept.DataSource = dt1.Tables[0];
                    ddldept.DataBind();
                    ddldept.Items.Insert(0, "Select");
                    string ddlOrgName = ddlorg.SelectedItem.Text;
                    if (ddlOrgName == "Other")
                    {
                        //txtOrg.Visible = true;
                        txtOrg.Visible = false; //change due to creating problem by bhanu on 17-03-2022
                    }
                    else
                    {
                        txtOrg.Visible = false;
                    }
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
    protected void ddlPresentOcc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string ddlPDoc = ddlPresentOcc.SelectedItem.Text;
            if (ddlPDoc == "Other")
            {
                //txtPresentOcc.Visible = true;
                txtPresentOcc.Visible = false; // change due to creating problem on 17-03-2022 by bhanu
            }
            else
            {
                txtPresentOcc.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }


    }
    protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddldept.SelectedIndex > 0)
            {
                DataSet dt3 = obj.ByDataSet("select * from tbl_Designationmaster where OrganaizationId=" + ddlorg.SelectedValue + " and DepartmentID=" + ddldept.SelectedValue + "");
                if (dt3.Tables[0].Rows.Count > 0)
                {
                    ddldesig.DataTextField = "DesinationName";
                    ddldesig.DataValueField = "ID";
                    ddldesig.DataSource = dt3.Tables[0];
                    ddldesig.DataBind();
                    ddldesig.Items.Insert(0, "Select");
                    string ddlDeptName = ddldept.SelectedItem.Text;
                    string ddldeptNameOrg = ddldept.SelectedItem.Text;
                    if (ddlDeptName == "Other")
                    {
                        // txtDept.Visible = true;
                        txtDept.Visible = false; //change by bhanu on 17-03-2022 due to creating problem
                    }
                    else if (ddldeptNameOrg == "Name of Organization & Address")
                    {
                        //txtDept.Visible = true;
                        txtDept.Visible = false; //change by bhanu on 17-03-2022 due to creating problem
                    }
                    else
                    {

                        txtDept.Visible = false;
                    }
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
    protected void ddlPerState_Init(object sender, EventArgs e)
    {
        try
        {
            ddlPerState.Items.Clear();

            DataSet dsUniversity = obj.ByProcedure("USP_University", new string[] { "flag", }, new string[] { "3", }, "dataset");

            if (dsUniversity != null && dsUniversity.Tables[0].Rows.Count > 0)
            {
                ddlPerState.DataTextField = "StateName";
                ddlPerState.DataValueField = "StateId";
                ddlPerState.DataSource = dsUniversity.Tables[0];
                ddlPerState.DataBind();
                ddlPerState.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void ddlproState_Init(object sender, EventArgs e)
    {
        try
        {
            ddlproState.Items.Clear();

            DataSet dsState = obj.ByProcedure("USP_University", new string[] { "flag", }, new string[] { "3", }, "dataset");

            if (dsState != null && dsState.Tables[0].Rows.Count > 0)
            {
                ddlproState.DataTextField = "StateName";
                ddlproState.DataValueField = "StateId";
                ddlproState.DataSource = dsState.Tables[0];
                ddlproState.DataBind();
                ddlproState.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void ddlRestate_Init(object sender, EventArgs e)
    {
        try
        {
            ddlRestate.Items.Clear();

            DataSet dsget = obj.ByProcedure("USP_University", new string[] { "flag", }, new string[] { "3", }, "dataset");

            if (dsget != null && dsget.Tables[0].Rows.Count > 0)
            {
                ddlRestate.DataTextField = "StateName";
                ddlRestate.DataValueField = "StateId";
                ddlRestate.DataSource = dsget.Tables[0];
                ddlRestate.DataBind();
                ddlRestate.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void ddlUniversity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";

            ds1 = obj.ByProcedure("USP_University", new string[] { "flag", "ID" }
                        , new string[] { "2", ddlUniversity.SelectedValue }, "dataset");

            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                ddlCollege.DataTextField = "CollegeName";
                ddlCollege.DataValueField = "ID";
                ddlCollege.DataSource = ds1.Tables[0];
                ddlCollege.DataBind();
                ddlCollege.Items.Insert(0, new ListItem("Select", "0"));
            }


        }
        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void ddluniversity2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ds2 = obj.ByProcedure("USP_University", new string[] { "flag", "ID" }
                            , new string[] { "2", ddluniversity2.SelectedValue }, "dataset");

            if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
            {
                ddlcollege2.DataTextField = "CollegeName";
                ddlcollege2.DataValueField = "ID";
                ddlcollege2.DataSource = ds2.Tables[0];
                ddlcollege2.DataBind();
                ddlcollege2.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void ddluniversity3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ds3 = obj.ByProcedure("USP_University", new string[] { "flag", "ID" }
                           , new string[] { "2", ddluniversity3.SelectedValue }, "dataset");

            if (ds3 != null && ds3.Tables[0].Rows.Count > 0)
            {
                ddlcollege3.DataTextField = "CollegeName";
                ddlcollege3.DataValueField = "ID";
                ddlcollege3.DataSource = ds3.Tables[0];
                ddlcollege3.DataBind();
                ddlcollege3.Items.Insert(0, new ListItem("Select", "1"));
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void ddluniversity4_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds4 = obj.ByProcedure("USP_University", new string[] { "flag", "ID" }
                            , new string[] { "2", ddluniversity4.SelectedValue }, "dataset");

            if (ds4 != null && ds4.Tables[0].Rows.Count > 0)
            {
                ddlcollege4.DataTextField = "CollegeName";
                ddlcollege4.DataValueField = "ID";
                ddlcollege4.DataSource = ds4.Tables[0];
                ddlcollege4.DataBind();
                ddlcollege4.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = obj.ErrorAlert(ex.Message.ToString());
        }
    }
    //protected void Confirm_Click(object sender, EventArgs e)
    //{
    //    string SendOTP = "2";
    //    string OTP = txtOTP.Text;
    //    SendOTP = ViewState["OTPSended"].ToString();
    //    if (SendOTP == OTP)
    //    {
    //        ViewState["OTPSended"] = null;
    //        lblOTPInvalid.Text = "";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPNotVerified();", true);
    //        FillUserDetails(sender, e);
    //    }
    //    else
    //    {
    //        lblOTPInvalid.Text = "* Invalid OTP";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopOTPVerification();", true);
    //    }
    //}
    protected void lnkdisApprove_Click(object sender, EventArgs e) // Verification Cancel Event
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
    protected void btnok_Click(object sender, EventArgs e)
    {
        hidefrom.Visible = true;
        if (HF_Ok.Value == "0")
        {
            if (Session["IsVerify"] != null)
            {
                if (Session["IsVerify"].ToString() == "1")
                {
                    Response.Redirect("AdminSection/FrmSecondLevelValid.aspx");
                }
                else
                {
                    Response.Redirect("AdminSection/ActionRegistration.aspx");
                }
            }
        }

    }
}