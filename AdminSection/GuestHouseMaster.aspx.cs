using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

public partial class AdminSection_GuestHouseMaster : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillRoomMasterDetails();
        }
    }
    protected void btnBook_Click(object sender, EventArgs e)
    {
        try
        {
            string chk1, chk2, chk3, chk4;
            if (ChkRoom1.Checked == true)
            {
                chk1 = "1";
            }
            else
            {
                chk1 = "0";
            }
            if (ChkRoom2.Checked == true)
            {
                chk2 = "1";
            }
            else
            {
                chk2 = "0";
            }
            if (ChkRoom3.Checked == true)
            {
                chk3 = "1";
            }
            else
            {
                chk3 = "0";
            }
            if (ChkRoom4.Checked == true)
            {
                chk4 = "1";
            }
            else
            {
                chk4 = "0";
            }

            objdb.ByText(@"Update tbl_GuestHouseMaster set Amount =" + txtRoom1Amount.Text + " , IsDisplay= " + chk1 + " where id  = 1");
            objdb.ByText(@"Update tbl_GuestHouseMaster set Amount =" + txtRoom2Amount.Text + " , IsDisplay= " + chk2 + " where id  = 2");
            objdb.ByText(@"Update tbl_GuestHouseMaster set Amount =" + txtRoom3Amount.Text + " , IsDisplay= " + chk3 + " where id  = 3");
            objdb.ByText(@"Update tbl_GuestHouseMaster set Amount =" + txtRoom4Amount.Text + " , IsDisplay= " + chk4 + " where id  = 4");

            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "fnRpt", "alert('Record Updated succesfully');", true);

        }
        catch (Exception ex)
        {

        }

    }
    public void FillRoomMasterDetails()
    {
        DataSet dsGuestHouseDetail = objdb.ByDataSet("select * from tbl_GuestHouseMaster");
        if (dsGuestHouseDetail.Tables[0].Rows.Count > 0)
        {
            if (dsGuestHouseDetail.Tables[0].Rows[0]["IsDisplay"].ToString().Trim () == "1")
            {
                ChkRoom1.Checked = true;
            }
            else {
                ChkRoom1.Checked = false ;
            }
            txtRoom1Amount.Text = dsGuestHouseDetail.Tables[0].Rows[0]["Amount"].ToString ();
            if (dsGuestHouseDetail.Tables[0].Rows[1]["IsDisplay"].ToString().Trim() == "1")
            {
                ChkRoom2.Checked = true;
            }
            else
            {
                ChkRoom2.Checked = false;
            }

            txtRoom2Amount.Text = dsGuestHouseDetail.Tables[0].Rows[1]["Amount"].ToString();
            if (dsGuestHouseDetail.Tables[0].Rows[2]["IsDisplay"].ToString().Trim() == "1")
            {
                ChkRoom3.Checked = true;
            }
            else
            {
                ChkRoom3.Checked = false;
            }

            txtRoom3Amount.Text = dsGuestHouseDetail.Tables[0].Rows[2]["Amount"].ToString();
            if (dsGuestHouseDetail.Tables[0].Rows[3]["IsDisplay"].ToString().Trim() == "1")
            {
                ChkRoom4.Checked = true;
            }
            else
            {
                ChkRoom4.Checked = false;
            }

            txtRoom4Amount.Text = dsGuestHouseDetail.Tables[0].Rows[3]["Amount"].ToString();      
        }

    }
}