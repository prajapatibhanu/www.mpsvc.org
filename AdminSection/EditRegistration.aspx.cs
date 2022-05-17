using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Globalization;

public partial class EditRegistration : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    APIProcedure objdb = new APIProcedure(); string path2, path3, path4;
    string mbNo = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fnProState();
            fnPerState();
            getResDistrict();
            FillFinancialYear();
            DateTime myDate = DateTime.Now;
            DateTime backDays = myDate.AddDays(-45);
            HdnDate.Value = Convert.ToDateTime(backDays).ToString("MM/dd/yyyy");

            DataSet dd1 = objdb.ByDataSet("select * from Tbl_UniversityMaster");
            if (dd1.Tables[0].Rows.Count > 0)
            {
                ddl1.DataTextField = "UniversityName";
                ddl1.DataValueField = "id";
                ddl1.DataSource = dd1.Tables[0];
                ddl1.DataBind();
                ListItem LiItem1 = new ListItem();
                LiItem1.Text = "Select";
                LiItem1.Value = "0";
                ddl1.Items.Insert(0, LiItem1);

                ddl2.DataTextField = "UniversityName";
                ddl2.DataValueField = "id";
                ddl2.DataSource = dd1.Tables[0];
                ddl2.DataBind();
                ListItem LiItem2 = new ListItem();
                LiItem2.Text = "Select";
                LiItem2.Value = "0";
                ddl2.Items.Insert(0, LiItem2);

                ddl3.DataTextField = "UniversityName";
                ddl3.DataValueField = "id";
                ddl3.DataSource = dd1.Tables[0];
                ddl3.DataBind();
                ListItem LiItem3 = new ListItem();
                LiItem3.Text = "Select";
                LiItem3.Value = "0";
                ddl3.Items.Insert(0, LiItem3);

                ddl4.DataTextField = "UniversityName";
                ddl4.DataValueField = "id";
                ddl4.DataSource = dd1.Tables[0];
                ddl4.DataBind();
                ListItem LiItem4 = new ListItem();
                LiItem4.Text = "Select";
                LiItem4.Value = "0";
                ddl4.Items.Insert(0, LiItem4);
            }

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
            }
            if (Request.QueryString["editR"] != null)
            {
                string[] arr = Request.QueryString["editR"].ToString().Split("*".ToCharArray());
                string applicationNo = arr[1];
                string Tid = arr[0];
                ds = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
                FillHiddenCalculation(ds);
                if (Session["IsVerify"] != null)
                {
                    if (Session["IsVerify"].ToString() == "0" || Session["IsVerify"].ToString() == "1")
                    {
                        lblAmount.Text = ds.Tables[1].Rows[0]["TotalAmount"].ToString();
                    }
                }
                else
                {
                    lblAmount.Text = HF_TotalAmount.Value;
                }
                FieldFill(sender, e);
            }

        }
    }
    protected void FillFinancialYear()
    {

        // Start Add Passing year on 14-0-2022 by bhanu
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
       // End Add Passing year on 14-0-2022 by bhanu
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

        ListItem LiItemPY1 = new ListItem();
        LiItemPY1.Text = "Select";
        LiItemPY1.Value = "0";

        ddlY1.Items.Insert(0, "Select");
        ddlY2.Items.Insert(0, "Select");
        ddlY3.Items.Insert(0, "Select");
        ddlY4.Items.Insert(0, "Select");

    }

    public void FieldFill(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["editR"] != null)
            {
                string[] arr = Request.QueryString["editR"].ToString().Split("*".ToCharArray());
                string applicationNo = arr[1];
                string Tid = arr[0];
                ds = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtRegNo.Enabled = false;
                    txtRegNo.Text = ds.Tables[1].Rows[0]["ApplicationNo"].ToString();
                    try
                    {
                        txtRegDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ApplicationDate"]).ToString("yyyy/MM/dd");
                    }
                    catch { }
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
                        ddlPresentOcc.Items.FindByText(ds.Tables[0].Rows[0]["PresentOccuption"].ToString()).Selected = true;
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
                        ddlResDistrict.ClearSelection();
                        ddlResDistrict.Items.FindByText(ds.Tables[0].Rows[0]["ResDistrict"].ToString()).Selected = true;
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
                        ddlProState_SelectedIndexChanged(sender, e);
                        ddlProDistrict.ClearSelection();
                        ddlProDistrict.Items.FindByText(ds.Tables[0].Rows[0]["ProDistrict"].ToString()).Selected = true;
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
                        ddlPerState_SelectedIndexChanged(sender, e);
                        ddlPerDistrict.ClearSelection();
                        ddlPerDistrict.Items.FindByText(ds.Tables[0].Rows[0]["PerDistrict"].ToString()).Selected = true;
                    }
                    catch { }
                    string[] landline = new string[2];
                    landline = ds.Tables[0].Rows[0]["PhoneNo"].ToString().Split("-".ToCharArray());
                    txtSTDcode.Text = landline[0];
                    txtPreffPhoneNo.Text = landline[1];
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
                    txtStdFaxCode.Text = faxLine[0];
                    txtFaxNo.Text = faxLine[1];
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
                    try
                    {
                        ddl1.ClearSelection();
                        ddl1.Items.FindByValue(ds.Tables[0].Rows[0]["University1"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        if (ddl1.SelectedIndex > 0)
                        {
                            ddl1_SelectedIndexChanged(sender, e);
                            ddlc1.ClearSelection();
                            ddlc1.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID1"].ToString()).Selected = true;
                        }
                    }
                    catch { }

                    try
                    {
                        ddlY1.ClearSelection();
                        ddlY1.Items.FindByValue(ds.Tables[0].Rows[0]["Year1"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        ddl2.ClearSelection();
                        ddl2.Items.FindByValue(ds.Tables[0].Rows[0]["University2"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        if (ddl2.SelectedIndex > 0)
                        {
                            ddl2_SelectedIndexChanged(sender, e);
                            ddlc2.ClearSelection();
                            ddlc2.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID2"].ToString()).Selected = true;
                        }
                    }
                    catch { }
                    try
                    {

                        ddlY2.ClearSelection();
                        ddlY2.Items.FindByValue(ds.Tables[0].Rows[0]["Year2"].ToString()).Selected = true;
                    }
                    catch { }

                    try
                    {
                        ddl3.ClearSelection();
                        ddl3.Items.FindByValue(ds.Tables[0].Rows[0]["University3"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        if (ddl3.SelectedIndex > 0)
                        {
                            ddl3_SelectedIndexChanged(sender, e);
                            ddlc3.ClearSelection();
                            ddlc3.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID3"].ToString()).Selected = true;
                        }
                    }
                    catch { }
                    try
                    {
                        ddlY3.ClearSelection();
                        ddlY3.Items.FindByValue(ds.Tables[0].Rows[0]["Year3"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        ddl4.ClearSelection();
                        ddl4.Items.FindByValue(ds.Tables[0].Rows[0]["University4"].ToString()).Selected = true;
                    }
                    catch { }
                    try
                    {
                        if (ddlc4.SelectedIndex > 0)
                        {
                            ddl4_SelectedIndexChanged(sender, e);
                            ddlc4.ClearSelection();
                            ddlc4.Items.FindByValue(ds.Tables[0].Rows[0]["CollegeID4"].ToString()).Selected = true;
                        }
                    }
                    catch { }
                    try
                    {
                        ddlY4.ClearSelection();
                        ddlY4.Items.FindByValue(ds.Tables[0].Rows[0]["Year4"].ToString()).Selected = true;
                    }
                    catch { }
                    string Noc = "";
                    Noc = ds.Tables[1].Rows[0]["NocNumber"].ToString();
                    if (Noc != "")
                    {
                        chkNocDetails.Checked = true;
                        tr_NocNumber.Visible = true;
                        tr_NocState.Visible = true;
                    }
                    else
                    {
                        tr_NocNumber.Visible = false;
                        tr_NocState.Visible = false;
                    }
                    txtNocNumber.Text = ds.Tables[1].Rows[0]["NocNumber"].ToString();
                    try
                    {
                        //txtNocDate.Text = ds.Tables[1].Rows[0]["NocDate"].ToString();
                        txtNocDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["NocDate"]).ToString("dd/MM/yyyy");

                    }
                    catch
                    {

                    }
                    // Added to fill Expiry date of Transfer in application 
                    try
                    {
                        TxtExpDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"]).ToString("dd/MM/yyyy");
                        if (TxtExpDate.Text == "01/01/1900")
                        {
                            TxtExpDate.Text = "";
                        }

                    }
                    catch
                    {
                    }

                    txtNocState.Text = ds.Tables[1].Rows[0]["NocState"].ToString();
                    try
                    {
                        txtRegistrationDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegiDate"]).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    try
                    {
                        txtDegreedate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DegreeDate"]).ToString("dd/MM/yyyy");
                    }
                    catch { }
                    try
                    {
                        txtDegid.Text = ds.Tables[0].Rows[0]["DegreeId"].ToString();
                    }
                    catch { }




                    string str1 = "";
                    str1 = ds.Tables[1].Rows[0]["Isonline"].ToString();
                    if (str1 == "1")
                    {
                        rbOnline.Checked = true;
                        tr_payment.Visible = false;
                        tr_cheque.Visible = false;
                        tr_Pdate.Visible = false;
                    }
                    else
                    {
                        rboffline.Checked = true;
                    }
                    txtcheque.Text = ds.Tables[1].Rows[0]["ChequeNo"].ToString();
                    txtbank.Text = ds.Tables[1].Rows[0]["BankName"].ToString();
                    txtPaymentDate.Text = Convert.ToDateTime(ds.Tables[1].Rows[0]["ChequeDate"]).ToString("dd/MM/yyyy");
                    string chkApplicationReqestId = ds.Tables[1].Rows[0]["ApplicationRequestId"].ToString();
                    if (chkApplicationReqestId == "0" || chkApplicationReqestId == "3")
                    {
                        HF_DomicileCert.Value = ds.Tables[0].Rows[0]["File1"].ToString();
                        HF_DegreeCert.Value = ds.Tables[0].Rows[0]["File2"].ToString();
                        HF_Photo.Value = ds.Tables[0].Rows[0]["File3"].ToString();
                        HF_OtherCert.Value = ds.Tables[0].Rows[0]["File4"].ToString();
                        HF_10thCert.Value = ds.Tables[0].Rows[0]["File5"].ToString();
                        HF_NocCertificate.Value = ds.Tables[0].Rows[0]["NocCertificate"].ToString();
                        tr_New.Visible = true;
                        tr_Renew.Visible = false;
                    }
                    else
                    {
                        HF_DomicileCert.Value = ds.Tables[0].Rows[0]["FileRenew1"].ToString();
                        HF_DegreeCert.Value = ds.Tables[0].Rows[0]["FileRenew2"].ToString();
                        HF_Photo.Value = ds.Tables[0].Rows[0]["FileRenew3"].ToString();
                        HF_OtherCert.Value = ds.Tables[0].Rows[0]["FileRenew4"].ToString();
                        tr_Renew.Visible = true;
                        tr_New.Visible = false;
                    }
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string RegistrationStatusBit = "2";
            if (Session["IsVerify"] != null)
            {
                if (Session["IsVerify"].ToString() == "1")
                {
                    RegistrationStatusBit = "3";
                }
            }
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
            string FileName = "";
            string file1path = "";
            string file2path = "";
            string file3path = "";
            string file4path = "";
            string file5path = "";
            string noc_Upload = "";
            string file6path = "";
            string file7path = "";
            string file8path = "";
            string file9path = "";

            DataSet ds = new DataSet();

            string ImgStatus = "";
            string FileName1 = "";
            string ImgStatus1 = "";
            string FileName2 = "";
            string ImgStatus2 = "";
            string FileName3 = "";
            string ImgStatus3 = "";
            string isOnline = "";
            DateTime DteCheck;


            DateTime mydate = DateTime.Now;
            DateTime Fiveyearbackdate = mydate.AddYears(5);
            string ValidupTo = GetValidUpToDate(Convert.ToDateTime(Fiveyearbackdate, cult).ToString("yyyy/MM/dd"));

            string[] arr = Request.QueryString["editR"].ToString().Split("*".ToCharArray());
            string applicationNo = arr[1];
            string Tid = arr[0];
            DataSet dsDetails = objdb.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");
            DateTime Curentdate = DateTime.Now;


            string validadate = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["Validupto"]).ToString("yyyy/MM/dd");
            DateTime vailidity = DateTime.Parse(validadate);

            //if (Session["IsVerify"] != null)
            //{
            //    if (Session["IsVerify"].ToString() == "1")
            //    {
            //        if (vailidity > Curentdate)
            //        {
            //            if (dsDetails.Tables[0].Rows[0]["ValidFrom"].ToString() != "")
            //            {
            //                string validfrom = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["ValidFrom"]).ToString("yyyy/MM/dd");
            //                DateTime financialyear = DateTime.Parse(validfrom);
            //                DateTime finyear = financialyear.AddYears(5).AddHours(-24);
            //                ValidupTo = Convert.ToDateTime(finyear, cult).ToString("yyyy/MM/dd");
            //            }
            //        }
            //    }
            //}

            string DOB = "";
            if (txtDOB.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtDOB.Text, cult);
                }
                catch { DOB = "NoDate"; }
            }
            if (DOB != "")
            {
                lblMsg.Text = objdb.ErrorAlert("Please enter correct Date Of Birth.");
            }
            else
            {
                if (rboffline.Checked == true)
                {
                    isOnline = "0";
                }
                else
                {
                    isOnline = "1";
                }
                string chkApplicationReqestId1 = dsDetails.Tables[0].Rows[0]["ApplicationRequestId"].ToString();
                if (chkApplicationReqestId1 == "0" || chkApplicationReqestId1 == "3")
                {
                    if (rbDecline.Checked == true)
                    {
                        if (FileUpload1.HasFile)
                        {
                            file1path = Guid.NewGuid() + "-" + FileUpload1.FileName;
                            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file1path));
                        }
                    }
                    else
                    {
                        file1path = HF_DomicileCert.Value;
                    }
                    if (rbDecline1.Checked == true)
                    {
                        if (FileUpload2.HasFile)
                        {
                            file2path = Guid.NewGuid() + "-" + FileUpload2.FileName;
                            FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file2path));
                        }
                    }
                    else
                    {
                        file2path = HF_DegreeCert.Value;
                    }
                    if (rbDecline2.Checked == true)
                    {
                        if (FileUpload3.HasFile)
                        {
                            file3path = Guid.NewGuid() + "-" + FileUpload3.FileName;
                            FileUpload3.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file3path));
                        }
                    }
                    else
                    {
                        file3path = HF_Photo.Value;
                    }
                    if (rbDecline3.Checked == true)
                    {
                        if (FileUpload4.HasFile)
                        {
                            file4path = Guid.NewGuid() + "-" + FileUpload4.FileName;
                            FileUpload4.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file4path));
                        }
                    }
                    else
                    {
                        file4path = HF_OtherCert.Value;
                    }
                    if (rbDecline4.Checked == true)
                    {
                        if (FileUpload5.HasFile)
                        {
                            file5path = Guid.NewGuid() + "-" + FileUpload5.FileName;
                            FileUpload5.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file5path));
                        }
                    }
                    else
                    {
                        file5path = HF_10thCert.Value;
                    }
                    if (rbDecline5.Checked == true)
                    {
                        if (FileUpload6.HasFile)
                        {
                            noc_Upload = Guid.NewGuid() + "-" + FileUpload6.FileName;
                            FileUpload6.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + noc_Upload));
                        }
                    }
                    else
                    {
                        noc_Upload = HF_NocCertificate.Value;
                    }
                }
                else
                {
                    if (rbRenewDecline.Checked == true)
                    {
                        if (FileUploadRenew6.HasFile)
                        {
                            file6path = Guid.NewGuid() + "-" + FileUploadRenew6.FileName;
                            FileUploadRenew6.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file6path));
                        }
                    }
                    else
                    {
                        file6path = HF_DomicileCert.Value;
                    }

                    if (rbRenewDecline1.Checked == true)
                    {
                        if (FileUploadRenew7.HasFile)
                        {
                            file7path = Guid.NewGuid() + "-" + FileUploadRenew7.FileName;
                            FileUploadRenew7.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file7path));
                        }
                    }
                    else
                    {
                        file7path = HF_DegreeCert.Value;
                    }

                    if (rbRenewDecline2.Checked == true)
                    {
                        if (FileUploadRenew8.HasFile)
                        {
                            file8path = Guid.NewGuid() + "-" + FileUploadRenew8.FileName;
                            FileUploadRenew8.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file8path));
                        }
                    }
                    else
                    {
                        file8path = HF_Photo.Value;
                    }
                    if (rbRenewDecline3.Checked == true)
                    {
                        if (FileUploadRenew9.HasFile)
                        {
                            file9path = Guid.NewGuid() + "-" + FileUploadRenew9.FileName;
                            FileUploadRenew9.PostedFile.SaveAs(Server.MapPath("~/Upload_Certificate/" + file9path));
                        }
                    }
                    else
                    {
                        file9path = HF_OtherCert.Value;
                    }
                }
                if (Request.QueryString["editR"] != null)
                {
                    string ApplicationReqestId = dsDetails.Tables[1].Rows[0]["ApplicationRequestId"].ToString();
                    string tranStatus = dsDetails.Tables[1].Rows[0]["TransactionStatus"].ToString();
                    string tranId = dsDetails.Tables[1].Rows[0]["TransactionId"].ToString();
                    string paymentDate = Convert.ToDateTime(dsDetails.Tables[1].Rows[0]["ChequeDate"]).ToString("yyyy/MM/dd");

                    string chkRegDate = "";
                    if (ApplicationReqestId == "3")
                    {
                        chkRegDate = Convert.ToDateTime(txtRegistrationDate.Text, cult).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        chkRegDate = Convert.ToDateTime(DateTime.Now, cult).ToString("yyyy/MM/dd");
                    }
                    string ApplyDate = Convert.ToDateTime(DateTime.Now, cult).ToString("yyyy/MM/dd");
                    FillHiddenCalculation(dsDetails);


                    if (ApplicationReqestId == "0" || ApplicationReqestId == "3") // For New and Transfer in mp
                    {
                        //txtRegNo.Text = applicationNo;
                        if (chkNocDetails.Checked == true)
                        {
                            if (rboffline.Checked == true)
                            {
                                ds = objdb.ByProcedure("ProcNewRegistrationEdit", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2" },
                                         new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), file6path, file7path, file8path, file9path, txtNocNumber.Text, Convert.ToDateTime(txtNocDate.Text, cult).ToString("yyyy/MM/dd"), txtNocState.Text, noc_Upload, RegistrationStatusBit, Convert.ToDateTime(TxtExpDate.Text, cult).ToString("yyyy/MM/dd"), "1", txtMobileNo2.Text }, "dataset");
                            }
                            else
                            {
                                ds = objdb.ByProcedure("ProcNewRegistrationEdit", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2" },
                                         new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, paymentDate, file6path, file7path, file8path, file9path, txtNocNumber.Text, Convert.ToDateTime(txtNocDate.Text, cult).ToString("yyyy/MM/dd"), txtNocState.Text, noc_Upload, RegistrationStatusBit, ValidupTo, "1", txtMobileNo2.Text }, "dataset");
                            }
                            objdb.ByText(@"Update tbl_Transactiondetails set RegistrationStatus = '" + RegistrationStatusBit + "' where id ='" + Tid + "'");
                        }
                        else
                        {
                            if (rboffline.Checked == true)
                            {
                                ds = objdb.ByProcedure("ProcNewRegistrationEdit", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2" },
                                         new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), file6path, file7path, file8path, file9path, txtNocNumber.Text, txtNocDate.Text, txtNocState.Text, noc_Upload, RegistrationStatusBit, ValidupTo, "1", txtMobileNo2.Text }, "dataset");
                            }
                            else
                            {
                                ds = objdb.ByProcedure("ProcNewRegistrationEdit", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2" },
                                         new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, paymentDate, file6path, file7path, file8path, file9path, txtNocNumber.Text, txtNocDate.Text, txtNocState.Text, noc_Upload, RegistrationStatusBit, ValidupTo, "1", txtMobileNo2.Text }, "dataset");
                            }
                            objdb.ByText(@"Update tbl_Transactiondetails set RegistrationStatus = '" + RegistrationStatusBit + "' where id ='" + Tid + "'");
                        }
                    }
                    else // For Renewal Registration
                    {
                        //Start 1. For Advance Renewal
                        DataSet dsForAdvanceRenewal = new DataSet();
                        dsForAdvanceRenewal = objdb.ByProcedure("ProcChageDateTemp", new string[] { "flag", "ApplicationNo" },
                                     new string[] { "2", applicationNo }, "dataset");

                        ViewState["ForAdvanceRenewal"] = dsForAdvanceRenewal.Tables[0].Rows[0]["ForAdvanceRenewal"].ToString();
                        //End 1. For Advance Renewal


                        string RegistrationStatus_check = dsDetails.Tables[0].Rows[0]["RegistrationStatus"].ToString();

                        if (RegistrationStatus_check == "1")
                        {
                            ValidupTo = getDate(dsDetails.Tables[0].Rows[0]["Validupto"].ToString());

                            ValidupTo = Convert.ToDateTime(ValidupTo, cult).ToString("yyyy/MM/dd");
                        }
                        string NocDate = "";
                        if (txtNocDate.Text != "")
                        {
                            NocDate = Convert.ToDateTime(txtNocDate.Text, cult).ToString("yyyy/MM/dd");
                        }
                        if (vailidity > Curentdate) // renewal beofre validity date
                        {
                            if (rboffline.Checked == true) // offline payment mode
                            {
                                if (Session["IsVerify"] != null)
                                {
                                    if (Session["IsVerify"].ToString() == "1")
                                    {
                                        ds = objdb.ByProcedure("USP_renewalProcess", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2", "IsVerify" },
                                             new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), file6path, file7path, file8path, file9path, txtNocNumber.Text, NocDate, txtNocState.Text, noc_Upload, RegistrationStatusBit, "", "1", txtMobileNo2.Text, "1" }, "dataset");
                                    }
                                    else
                                    {
                                        ds = objdb.ByProcedure("USP_renewalProcess", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2" },
                                          new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), file6path, file7path, file8path, file9path, txtNocNumber.Text, NocDate, txtNocState.Text, noc_Upload, RegistrationStatusBit, "", "1", txtMobileNo2.Text }, "dataset");
                                    }
                                }
                    
                            }
                            else // online payment mode
                            {
                                if (Session["IsVerify"] != null)
                                {
                                    if (Session["IsVerify"].ToString() == "1")
                                    {
                                        ds = objdb.ByProcedure("USP_renewalProcess", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2", "IsVerify" },
                                              new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, paymentDate, file6path, file7path, file8path, file9path, txtNocNumber.Text, NocDate, txtNocState.Text, noc_Upload, RegistrationStatusBit, "", "1", txtMobileNo2.Text, "1" }, "dataset");
                                    }
                                    else
                                    {
                                        ds = objdb.ByProcedure("USP_renewalProcess", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2" },
                                              new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, paymentDate, file6path, file7path, file8path, file9path, txtNocNumber.Text, NocDate, txtNocState.Text, noc_Upload, RegistrationStatusBit, "", "1", txtMobileNo2.Text}, "dataset");
                                    }  
                                }

                            }
                            objdb.ByText(@"Update tbl_Transactiondetails set RegistrationStatus = '" + RegistrationStatusBit + "' where id ='" + Tid + "'");
                        }
                        else // renewal beofre validity date
                        {
                            if (rboffline.Checked == true)
                            {
                                if (Session["IsVerify"] != null)
                                {
                                if (Session["IsVerify"].ToString() == "1")
                                {

                                    ds = objdb.ByProcedure("USP_renewalProcess", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2", "IsVerify" },
                                            new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), file6path, file7path, file8path, file9path, txtNocNumber.Text, NocDate, txtNocState.Text, noc_Upload, RegistrationStatusBit, "", "2", txtMobileNo2.Text, "1" }, "dataset");
                                }
                              
                                     else
                                    {
                                        ds = objdb.ByProcedure("USP_renewalProcess", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2" },
                                          new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, paymentDate, file6path, file7path, file8path, file9path, txtNocNumber.Text, NocDate, txtNocState.Text, noc_Upload, RegistrationStatusBit, "", "2", txtMobileNo2.Text }, "dataset");
                                    }
                                
                            }
                                //ds = objdb.ByProcedure("USP_renewalProcess", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2" },
                                //            new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), file6path, file7path, file8path, file9path, txtNocNumber.Text, NocDate, txtNocState.Text, noc_Upload, RegistrationStatusBit, "", "2", txtMobileNo2.Text}, "dataset");
                            }
                            else
                            {
                                if (Session["IsVerify"] != null)
                                {
                                    if (Session["IsVerify"].ToString() == "1")
                                    {
                                        ds = objdb.ByProcedure("USP_renewalProcess", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2", "IsVerify" },
                                                    new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, Convert.ToDateTime(txtPaymentDate.Text, cult).ToString("yyyy/MM/dd"), file6path, file7path, file8path, file9path, txtNocNumber.Text, NocDate, txtNocState.Text, noc_Upload, RegistrationStatusBit, "", "2", txtMobileNo2.Text, "1" }, "dataset");
                                    }
                                    else
                                    {
                                        ds = objdb.ByProcedure("USP_renewalProcess", new string[] { "ApplicationNo", "Applicationdate", "RegiDate", "FName", "MName", "LName", "FatherName", "DOB", "Gender", "PresentOccuption", "OrganizationId", "OrganizationText", "DepartmentId", "DepartmentText", "Designationid", "DesignationText", "ResAdd", "ResCity", "ResDistrict", "ResTown", "ResPost", "ResTehsil", "ResPinCode", "ResState", "ProAdd", "ProCity", "ProDistrict", "ProTown", "ProPost", "ProTehsil", "ProPinCode", "ProState", "PerAdd", "PerCity", "PerDistrict", "PerTown", "PerPost", "PerTehsil", "PerPinCode", "PerState", "PhoneNo", "PreferedAdd", "MobileNo", "Fax", "EmailId", "PreferedPhoneNo", "University1", "University2", "University3", "University4", "CollegeID1", "CollegeID2", "CollegeID3", "CollegeID4", "Year1", "Year2", "Year3", "Year4", "File1", "File2", "File3", "File4", "File5", "Degreedate", "Degreeid", "ChequeNo", "BankName", "ChequeDate", "FileRenew1", "FileRenew2", "FileRenew3", "FileRenew4", "NocNumber", "NocDate", "NocState", "NocCertificate", "RegistrationStatus", "Validupto", "type", "MobileNo2" },
                                          new string[] { txtRegNo.Text, txtRegDate.Text, chkRegDate, txtFName.Text, txtMName.Text, txtLastName.Text, txtFatherName.Text, Convert.ToDateTime(txtDOB.Text, cult).ToString("yyyy/MM/dd"), ddlGender.SelectedItem.Text, ddlPresentOcc.SelectedItem.Text, ddlorg.SelectedValue, txtOrg.Text, ddldept.SelectedValue, txtDept.Text, ddldesig.SelectedValue, txtDesig.Text, txtResAdd.Text, txtResCity.Text, ddlResDistrict.SelectedItem.Text, "", txtResPost.Text, txtResTehsil.Text, txtResPinCode.Text, ddlResState.SelectedValue.ToString().Replace("Select", "0"), txtProAdd.Text, txtProCity.Text, ddlProDistrict.SelectedItem.Text, "", txtProPost.Text, txtProTehsil.Text, txtProPinCode.Text, ddlProState.SelectedValue.ToString().Replace("Select", "0"), txtPerAdd.Text, txtPerCity.Text, ddlPerDistrict.SelectedItem.Text, "", txtPerPost.Text, txtPerTehsil.Text, txtPerPinCode.Text, ddlPerState.SelectedValue.ToString().Replace("Select", "0"), PreferedNo, ddlPreffAddress.SelectedItem.Text, txtMobileNo1.Text, stdFax, txtEmailId.Text, rbmobileprefered, ddl1.SelectedValue, ddl2.SelectedValue, ddl3.SelectedValue, ddl4.SelectedValue, ddlc1.SelectedValue, ddlc2.SelectedValue, ddlc3.SelectedValue, ddlc4.SelectedValue, ddlY1.SelectedValue, ddlY2.SelectedValue, ddlY3.SelectedValue, ddlY4.SelectedValue, file1path, file2path, file3path, file4path, file5path, Convert.ToDateTime(txtDegreedate.Text, cult).ToString("yyyy/MM/dd"), txtDegid.Text, txtcheque.Text, txtbank.Text, paymentDate, file6path, file7path, file8path, file9path, txtNocNumber.Text, NocDate, txtNocState.Text, noc_Upload, RegistrationStatusBit, "", "2", txtMobileNo2.Text }, "dataset");
                                    }
                                }

                        
                            }

                            objdb.ByText(@"Update tbl_Transactiondetails set RegistrationStatus = '" + RegistrationStatusBit + "' where id ='" + Tid + "'");
                        }
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (RegistrationStatusBit == "3")
                        {
                            //Start 2. For Advance Renewal
                            if (ViewState["ForAdvanceRenewal"] != null)
                            {
                                if (ViewState["ForAdvanceRenewal"].ToString() == "1")
                                {
                                    objdb.ByProcedure("ProcChageDateTemp", new string[] { "flag", "ApplicationNo" },
                                         new string[] { "1", applicationNo }, "dataset");
                                }
                            }
                            // //End 2. For Advance Renewal

                            DataSet dsDetailsNew = objdb.ByDataSet("select * from tblNewRegistration where ApplicationNo='" + applicationNo + "'");
                            // if (rbmobileprefered == "1")
                            // {
                            //     mbNo = dsDetailsNew.Tables[0].Rows[0]["MobileNo"].ToString();
                            //}
                            // else
                            // {
                            //    mbNo = dsDetailsNew.Tables[0].Rows[0]["MobileNo2"].ToString();
                            // }
                            string regno = dsDetailsNew.Tables[0].Rows[0]["RegiNo"].ToString();
                            string val = getDate(dsDetailsNew.Tables[0].Rows[0]["Validupto"].ToString());

                            //string mail = dsDetailsNew.Tables[0].Rows[0]["EmailId"].ToString();
                            //string subject = "MPSVC Verification Mail";
                            //string body = objdb.CreateAdminEmailBody(Convert.ToInt32(ApplicationReqestId), regno);
                            //string mbMessage = objdb.CreateAdminMessageBody(Convert.ToInt32(ApplicationReqestId), regno); // Message Body Function

                            //objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.
                            lblMSgAlert.Text = "Registration no. '" + regno + "' verified successfully valid upto '" + val + "' ";
                        }
                        else
                        {
                            lblMSgAlert.Text = "Application forwarded for second level verification.";
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopTemAndCondition();", true);
                        obCommonFuction.EmptyTextBoxes(this);

                    }
                    else
                    {
                        lblMsg.Text = objdb.ErrorAlert(ds.Tables[0].Rows[0]["Msg"].ToString());

                    }
                }
                else
                {

                }
            }
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
    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl1.SelectedIndex > 0)
        {
            DataSet dd1 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl1.SelectedValue + "");
            if (dd1.Tables[0].Rows.Count > 0)
            {
                ddlc1.DataTextField = "CollegeName";
                ddlc1.DataValueField = "id";
                ddlc1.DataSource = dd1.Tables[0];
                ddlc1.DataBind();
                ListItem LiItemc1 = new ListItem();
                LiItemc1.Text = "Select";
                LiItemc1.Value = "0";
                ddlc1.Items.Insert(0, LiItemc1);
                ddl1.Focus();
            }
        }
    }
    protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl2.SelectedIndex > 0)
        {
            DataSet dd3 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl2.SelectedValue + "");
            if (dd3.Tables[0].Rows.Count > 0)
            {
                ddlc2.DataTextField = "CollegeName";
                ddlc2.DataValueField = "id";
                ddlc2.DataSource = dd3.Tables[0];
                ddlc2.DataBind();
                ListItem LiItemc2 = new ListItem();
                LiItemc2.Text = "Select";
                LiItemc2.Value = "0";
                ddlc2.Items.Insert(0, LiItemc2);
                ddl2.Focus();
            }
        }
    }
    protected void ddl3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl3.SelectedIndex > 0)
        {
            DataSet dd33 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl3.SelectedValue + "");
            if (dd33.Tables[0].Rows.Count > 0)
            {
                ddlc3.DataTextField = "CollegeName";
                ddlc3.DataValueField = "id";
                ddlc3.DataSource = dd33.Tables[0];
                ddlc3.DataBind();
                ListItem LiItemc3 = new ListItem();
                LiItemc3.Text = "Select";
                LiItemc3.Value = "0";
                ddlc3.Items.Insert(0, LiItemc3);
                ddl3.Focus();
            }
        }
    }
    protected void ddl4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl4.SelectedIndex > 0)
        {
            DataSet dd333 = objdb.ByDataSet("select * from tbl_CollegeMaster where UniversityID=" + ddl4.SelectedValue + "");
            if (dd333.Tables[0].Rows.Count > 0)
            {
                ddlc4.DataTextField = "CollegeName";
                ddlc4.DataValueField = "id";
                ddlc4.DataSource = dd333.Tables[0];
                ddlc4.DataBind();
                ListItem LiItemc4 = new ListItem();
                LiItemc4.Text = "Select";
                LiItemc4.Value = "0";
                ddlc4.Items.Insert(0, LiItemc4);
                ddl4.Focus();
            }
        }
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
                string ddlDeptName = ddldept.SelectedItem.Text;
                if (ddlOrgName == "Other" || ddlDeptName == "Other")
                {
                    txtOrg.Visible = true;
                    txtDept.Visible = true;
                    txtDesig.Visible = true;
                }
                else
                {
                    txtOrg.Visible = false;
                    txtDept.Visible = false;
                    txtDesig.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }
    protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
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
                txtPerPinCode.Text = txtResPinCode.Text.Trim();
                txtPerPost.Text = txtResPost.Text.Trim();
                txtPerTehsil.Text = txtResTehsil.Text.Trim();
            }
            else
            {
                txtPerAdd.Text = "";
                txtPerCity.Text = "";
                ddlPerDistrict.SelectedItem.Text = "";
                ddlPerState.SelectedIndex = 0;
                txtPerPinCode.Text = "";
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = objdb.ErrorAlert(ex.Message.ToString());
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("");
    }
    protected void Ok_Click(object sender, EventArgs e)
    {
        if (Session["IsVerify"] != null)
        {
            if (Session["IsVerify"].ToString() == "1")
            {
                HiddenAppNoID.Value = Request.QueryString["editR"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "CallPrintReceiptFrmSecondLevelValid();", true);
                //Response.Redirect("FrmSecondLevelValid.aspx");
            }
            else
            {
                HiddenAppNoID.Value = Request.QueryString["editR"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "CallPrintReceiptActionRegistration(" + Request.QueryString["editR"] + ");", true);
                //Response.Redirect("ActionRegistration.aspx");
            }
        }

    }
    private void FillHiddenCalculation(DataSet ds)
    {
        string ApplicationReqestId = ds.Tables[1].Rows[0]["ApplicationRequestId"].ToString();
        if (ApplicationReqestId == "0" || ApplicationReqestId == "3")
        {
            HF_RegistationFees.Value = "25";
            HF_RenewalFees.Value = "0";
            HF_ServiceChagre.Value = "2000";
            HF_LateFees.Value = "0";
            HF_ReEstabilishmentFees.Value = "0";
            HF_TotalAmount.Value = "2025";
        }
        else if (ApplicationReqestId == "1")
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
                        HF_RenewalFees.Value = "15";
                        HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
                        HF_ReEstabilishmentFees.Value = "25";
                        HF_ServiceChagre.Value = "1000";
                        HF_TotalAmount.Value = (15 + Convert.ToInt32(count) * 5 + 25 + 1000).ToString();
                    }
                    else
                    {
                        HF_ServiceChagre.Value = "2000";
                        HF_RenewalFees.Value = "15";
                        HF_LateFees.Value = (Convert.ToInt32(count) * 5).ToString();
                        HF_ReEstabilishmentFees.Value = "15";
                        HF_TotalAmount.Value = (15 + Convert.ToInt32(count) * 5 + 15 + 2000).ToString();
                    }

                }
            }
        }
        else
        {
            HF_RegistationFees.Value = "25";
            HF_RenewalFees.Value = "0";
            HF_ServiceChagre.Value = "2000";
            HF_LateFees.Value = "0";
            HF_ReEstabilishmentFees.Value = "0";
            HF_TotalAmount.Value = "2025";
        }
    }
    protected void chkNocDetails_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkNocDetails.Checked == true)
            {
                tr_NocNumber.Visible = true;
                tr_NocState.Visible = true;
            }
            else
            {
                tr_NocNumber.Visible = false;
                tr_NocState.Visible = false;
            }
            chkNocDetails.Focus();
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
}
