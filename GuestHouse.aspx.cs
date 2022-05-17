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

public partial class GuestHouse : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    //CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    APIProcedure objdb = new APIProcedure(); string path2, path3, path4;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSecurity Isecrity = new DataSecurity();
    int noofday = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnBook.Enabled = false;
            CalendarExtender1.StartDate = DateTime.Now;
            CalendarExtender3.StartDate = DateTime.Now;
            ChkRoom1.Enabled = false;
            ChkRoom2.Enabled = false;
            ChkRoom3.Enabled = false;
            ChkRoom4.Enabled = false;
            enabledisableExtrabed();
        }
    }  
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        DataSet ds;
        if (txtRegistrationno.Text.Trim() != "")
        {
            ds = objdb.ByDataSet("select * from tblNewRegistration where RegiNo ='" + txtRegistrationno.Text + "' and ApplicationRequestId <> 7  and ApplicationRequestId <> 8 and ApplicationRequestId <> 9");
            if (ds.Tables[0].Rows.Count != 0)
            {
                DateTime Lvalue = DateTime.Now;
                DateTime rValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["Validupto"].ToString());
                if (Lvalue > rValue)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key2", "PopTemAndConditionRenew();", true);
                    lblMSgAlert.Text = "Your registration is expired first apply for renewal registration ";
                    return;
                }
                btnBook.Enabled = true;
                txtName.Enabled = false;
                txtMail.Enabled = false;
                hf_regno.Value = ds.Tables[0].Rows[0]["RegiNo"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["FName"].ToString() + "" + ds.Tables[0].Rows[0]["MName"].ToString() + "" + ds.Tables[0].Rows[0]["LName"].ToString();
                txtMob.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                txtMail.Text = ds.Tables[0].Rows[0]["Emailid"].ToString();
                HF_Application.Value = ds.Tables[0].Rows[0]["ApplicationNo"].ToString();
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Invalid registration no.";
            }
        }
        else
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please enter registration no.";
        }

    }
    protected void btnBook_Click(object sender, EventArgs e)
    {
        try
        {
            string DateOfBooking = Convert.ToDateTime(DateTime.Now, cult).ToString("yyyy/MM/dd");
            string extraBedrequired = "";
            string noofroom = "";
            if (ChkRoom1.Checked == true)
            {
                noofroom = "1";
            }
            if (ChkRoom2.Checked == true)
            {
                if (noofroom != "")
                {
                    noofroom += "," + "2";
                }
                else
                {
                    noofroom = "2";
                }
            }
            if (ChkRoom3.Checked == true)
            {
                if (noofroom != "")
                {
                    noofroom += "," + "3";
                }
                else
                {
                    noofroom = "3";
                }

            }
            if (ChkRoom4.Checked == true)
            {
                if (noofroom != "")
                {
                    noofroom += "," + "4";
                }
                else
                {
                    noofroom = "4";
                }

            }
            extraBedrequired = findExtrabedRooms();
            string str = hf_regno.Value + "*" + ddlIdentityType.SelectedItem.Text + "*" + txtIdentityNo.Text + "*" + lblNoOfRoom.Text + "*" + lblNoOfDay.Text + "*" + Convert.ToDateTime(txtFromdt.Text, cult).ToString("yyyy/MM/dd") + "*" + Convert.ToDateTime(txtToDt.Text, cult).ToString("yyyy/MM/dd") + "*" + noofroom + "*" + extraBedrequired + "*" + lblExtraBedAmount.Text + "*" + lblTotalAmount.Text + "*" + "0" + "*" + "1" + "*" + DateOfBooking;  
            string str1 = noofroom;                    
            ds = objdb.ByProcedure("InsertTempTransction", new string[] { "ApplicationNo", "TblMaster", "TblTran" },
             new string[] { HF_Application.Value, str, str1 }, "dataset");
            string TempTranId = ds.Tables[0].Rows[0]["id"].ToString(); 
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "MessageVerify();", true);
            RedirectonPaymentGatewayPage(TempTranId);

        }
        catch (Exception ex) { lblError.Text = objdb.ErrorAlert(ex.Message.ToString()); }
    }
    public void RedirectonPaymentGatewayPage(string tempT_Id)
    {
        string var = HF_Application.Value + "*" + lblTotalAmount.Text + "*" + txtMail.Text + "*" + txtMob.Text + "*" + txtName.Text + "*" + tempT_Id;
        string EncryptedStr = Isecrity.Encrypt(var);
        obCommonFuction.EmptyTextBoxes(this);
        Response.Redirect("~/FrmRequestGuestHouse.aspx?TRequest=" + Server.UrlEncode(EncryptedStr));
    }
    protected void ChkBedRequired_CheckedChanged(object sender, EventArgs e)
    {
        int room1 = 0;
        int room2 = 0;
        int room3 = 0;
        int room4 = 0;
        int calRoom = 0;
        int totPayableAmt = 0;
        int extraBedAmtperDay = 0;
        enabledisableExtrabed();
        int noofroom = 0;
        int NoOfExtraBed = ContExtraBed();
        if (NoOfExtraBed > 0)
        {
            lblExtraBedAmount.Text = "200";
            extraBedAmtperDay = Convert.ToInt32(NoOfExtraBed) * Convert.ToInt32(lblExtraBedAmount.Text) * Convert.ToInt32(lblNoOfDay.Text);
            lblExtraBedAmount.Text = Convert.ToInt32(extraBedAmtperDay).ToString();
        }
        else
        {
            lblExtraBedAmount.Text = "0";
        }

        if (ChkRoom1.Checked == true)
        {
            noofroom = Convert.ToInt32("1");
        }
        if (ChkRoom2.Checked == true)
        {
            noofroom = Convert.ToInt32(noofroom) + Convert.ToInt32("1");
        }
        if (ChkRoom3.Checked == true)
        {
            noofroom = Convert.ToInt32(noofroom) + Convert.ToInt32("1");
        }
        if (ChkRoom4.Checked == true)
        {
            noofroom = Convert.ToInt32(noofroom) + Convert.ToInt32("1");
        }
        lblNoOfRoom.Text = Convert.ToInt32(noofroom).ToString();    
        ds = objdb.ByDataSet("select * from tbl_GuestHouseMaster");
        if (ds.Tables[0].Rows.Count > 0)
        {
            room1 = Convert.ToInt32(ds.Tables[0].Rows[0]["Amount"]);
            room2 = Convert.ToInt32(ds.Tables[0].Rows[1]["Amount"]);
            room3 = Convert.ToInt32(ds.Tables[0].Rows[2]["Amount"]);
            room4 = Convert.ToInt32(ds.Tables[0].Rows[3]["Amount"]);

            if (ChkRoom1.Checked == true)
            {
                calRoom = Convert.ToInt32(room1);
            }
            if (ChkRoom2.Checked == true)
            {
                calRoom = Convert.ToInt32(calRoom) + Convert.ToInt32(room2);
            }
            if (ChkRoom3.Checked == true)
            {
                calRoom = Convert.ToInt32(calRoom) + Convert.ToInt32(room3);
            }
            if (ChkRoom4.Checked == true)
            {
                calRoom = Convert.ToInt32(calRoom) + Convert.ToInt32(room4);
            }
        }
        lblChargePerday.Text = Convert.ToInt32(calRoom).ToString();

        if (NoOfExtraBed > 0)
        {
            totPayableAmt = Convert.ToInt32(lblNoOfDay.Text) * Convert.ToInt32(lblChargePerday.Text) + Convert.ToInt32(lblExtraBedAmount.Text);
            lblTotalAmount.Text = totPayableAmt.ToString();
        }
        else
        {
            totPayableAmt = Convert.ToInt32(lblNoOfDay.Text) * Convert.ToInt32(lblChargePerday.Text);
            lblTotalAmount.Text = totPayableAmt.ToString();
        }
    }

    protected void txtFromdt_TextChanged(object sender, EventArgs e)
    {
        clearControl();
        if (txtFromdt.Text.Trim() != "" && txtToDt.Text.Trim() != "")
        {
            DateTime startDate = Convert.ToDateTime(txtFromdt.Text, cult);
            DateTime endDate = Convert.ToDateTime(txtToDt.Text, cult);
            string calculate = (endDate - startDate).TotalDays.ToString();
            noofday = Convert.ToInt32(calculate) + Convert.ToInt32("1");
            lblNoOfDay.Text = Convert.ToInt32(noofday).ToString();
        }
    }
    protected void clearControl()
    {
        ChkRoom1.Checked = false;
        ChkRoom2.Checked = false;
        ChkRoom3.Checked = false;
        ChkRoom4.Checked = false;
        ChkBedRequired1.Checked = false;
        ChkBedRequired2.Checked = false;
        ChkBedRequired3.Checked = false;
        ChkBedRequired4.Checked = false;
        lblNoOfRoom.Text = "0";
        lblNoOfDay.Text = "0";
        lblChargePerday.Text = "0";
        lblExtraBedAmount.Text = "0";
        lblTotalAmount.Text = "0";
    }
    protected void lnkChkAvail_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dscheckAvail = new DataSet();
            string frDate = Convert.ToDateTime(txtFromdt.Text, cult).ToString("yyyy/MM/dd");
            string toDate = Convert.ToDateTime(txtToDt.Text, cult).ToString("yyyy/MM/dd");
            dscheckAvail = objdb.ByProcedure("Proc_CheckAvailability", new string[] { "Fromdate", "Todate" },
                 new string[] { frDate, toDate }, "dataset");
            ChkRoom1.Enabled = true;
            ChkRoom2.Enabled = true;
            ChkRoom3.Enabled = true;
            ChkRoom4.Enabled = true;
            for (int i = 0; i <= dscheckAvail.Tables[0].Rows.Count - 1; i++)
            {
                if (dscheckAvail.Tables[0].Rows[i]["RoomId"].ToString().Trim() == "1")
                {
                    ChkRoom1.Enabled = false;
                }
                if (dscheckAvail.Tables[0].Rows[i]["RoomId"].ToString().Trim() == "2")
                {
                    ChkRoom2.Enabled = false;
                }
                if (dscheckAvail.Tables[0].Rows[i]["RoomId"].ToString().Trim() == "3")
                {
                    ChkRoom3.Enabled = false;
                }
                if (dscheckAvail.Tables[0].Rows[i]["RoomId"].ToString().Trim() == "4")
                {
                    ChkRoom4.Enabled = false;
                }
            }
            checkVIP();
            ChangeColurofCheckBox();
            if (ChkRoom1.Enabled == false && ChkRoom2.Enabled == false && ChkRoom3.Enabled == false && ChkRoom4.Enabled == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "fnRpt", "alert('No room is available');", true);
            }
        }
        catch
        {

        }
    }

    protected void checkVIP()
    {
        try
        {
            DataSet dsGuestHouseDetail = objdb.ByDataSet("select * from tbl_GuestHouseMaster");
            if (dsGuestHouseDetail.Tables[0].Rows.Count > 0)
            {
                if (dsGuestHouseDetail.Tables[0].Rows[0]["IsDisplay"].ToString().Trim() == "0")
                {
                    ChkRoom1.Enabled = false;
                    ChkBedRequired1.Enabled = false;
                }
                if (dsGuestHouseDetail.Tables[0].Rows[1]["IsDisplay"].ToString().Trim() == "0")
                {
                    ChkRoom2.Enabled = false;
                    ChkBedRequired2.Enabled = false;
                }
                if (dsGuestHouseDetail.Tables[0].Rows[2]["IsDisplay"].ToString().Trim() == "0")
                {
                    ChkRoom3.Enabled = false;
                    ChkBedRequired3.Enabled = false;
                }
                if (dsGuestHouseDetail.Tables[0].Rows[3]["IsDisplay"].ToString().Trim() == "0")
                {
                    ChkRoom4.Enabled = false;
                    ChkBedRequired4.Enabled = false;
                }
            }
        }
        catch
        {

        }
    }
    public int ContExtraBed()
    {
        int NoofextraBed = 0;
        if (ChkBedRequired1.Checked == true)
        {
            NoofextraBed = 1;
        }
        if (ChkBedRequired2.Checked == true)
        {
            NoofextraBed = Convert.ToInt32(NoofextraBed) + 1;
        }
        if (ChkBedRequired3.Checked == true)
        {
            NoofextraBed = Convert.ToInt32(NoofextraBed) + 1;
        }
        if (ChkBedRequired4.Checked == true)
        {
            NoofextraBed = Convert.ToInt32(NoofextraBed) + 1;
        }
        return NoofextraBed;
    }
    public void enabledisableExtrabed()
    {
        if (ChkRoom1.Checked == true)
        {
            ChkBedRequired1.Enabled = true;
        }
        else
        {
            ChkBedRequired1.Enabled = false;
            ChkBedRequired1.Checked = false;
        }
        if (ChkRoom2.Checked == true)
        {
            ChkBedRequired2.Enabled = true;
        }
        else
        {
            ChkBedRequired2.Enabled = false;
            ChkBedRequired2.Checked = false;
        }
        if (ChkRoom3.Checked == true)
        {
            ChkBedRequired3.Enabled = true;
        }
        else
        {
            ChkBedRequired3.Enabled = false;
            ChkBedRequired3.Checked = false;
        }
        if (ChkRoom4.Checked == true)
        {
            ChkBedRequired4.Enabled = true;
        }
        else
        {
            ChkBedRequired4.Enabled = false;
            ChkBedRequired4.Checked = false;
        }
    }
    public void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistrationLinkNew.aspx");
    }
    public void ChangeColurofCheckBox()
    {
        if (ChkRoom1.Enabled == true)
        {
            ChkRoom1.ForeColor = Color.Green;
            ChkBedRequired1.ForeColor = Color.Green;
        }
        else
        {

        }
        if (ChkRoom2.Enabled == true)
        {
            ChkRoom2.ForeColor = Color.Green;
            ChkBedRequired2.ForeColor = Color.Green;
        }
        else
        {

        }
        if (ChkRoom3.Enabled == true)
        {
            ChkRoom3.ForeColor = Color.Green;
            ChkBedRequired3.ForeColor = Color.Green;
        }
        else
        {

        }
        if (ChkRoom4.Enabled == true)
        {
            ChkRoom4.ForeColor = Color.Green;
            ChkBedRequired4.ForeColor = Color.Green;
        }
        else
        {

        }
    }
    public string findExtrabedRooms()
    {
        string noofExtraBedroom = "";
        if (ChkBedRequired1.Checked == true)
        {
            noofExtraBedroom = "1";
        }
        if (ChkBedRequired2.Checked == true)
        {
            if (noofExtraBedroom != "")
            {
                noofExtraBedroom += "," + "2";
            }
            else
            {
                noofExtraBedroom = "2";
            }
        }
        if (ChkBedRequired3.Checked == true)
        {
            if (noofExtraBedroom != "")
            {
                noofExtraBedroom += "," + "3";
            }
            else
            {
                noofExtraBedroom = "3";
            }
        }
        if (ChkBedRequired4.Checked == true)
        {
            if (noofExtraBedroom != "")
            {
                noofExtraBedroom += "," + "4";
            }
            else
            {
                noofExtraBedroom = "4";
            }

        }
        return noofExtraBedroom;
    }
}
