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

public partial class AdminSection_Frm_EditGuestHouse : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    //CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    DataSet dsFill;
    APIProcedure objdb = new APIProcedure(); string path2, path3, path4;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    int noofday = 0;
    string r1, r2, r3, r4;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["editGH"] != null)
            {
                FillGuestHouseDetails(sender, e);
            }
        }
    }

    public void FillGuestHouseDetails(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["editGH"] != null)
            {
                dsFill = objdb.ByProcedure("Proc_GetGusetHouseRequest", new string[] { "KeyBoard", "Type" }, new string[] { Request.QueryString["editGH"].ToString().Trim(), "2" }, "dataset");
                //dsFill = objdb.ByProcedure("Proc_GetGusetHouseRequest", new string[] { "KeyBoard", "Type" }, new string[] { Request.QueryString["editGH"].ToString().Trim(), "2" }, "dataset");
                if (dsFill.Tables[0].Rows.Count > 0)
                {
                    txtRegistrationno.Text = dsFill.Tables[0].Rows[0]["RegiNo"].ToString();
                    imgPic.Src =  "~/Upload_Certificate/"+ dsFill.Tables[0].Rows[0]["photo"].ToString();
                    txtName.Text = dsFill.Tables[0].Rows[0]["Name"].ToString();
                    txtMail.Text = dsFill.Tables[0].Rows[0]["EmailId"].ToString();
                    txtMob.Text = dsFill.Tables[0].Rows[0]["MobileNo"].ToString();
                    ddlIdentityType.Items.FindByText(dsFill.Tables[0].Rows[0]["IdentityType"].ToString()).Selected = true;
                    txtIdentityNo.Text = dsFill.Tables[0].Rows[0]["IdentityNo"].ToString();

                    if (txtFromdt.Text != null && txtToDt.Text != null)
                    {
                        txtFromdt.Text = dsFill.Tables[0].Rows[0]["FromDate"].ToString();
                        txtToDt.Text = dsFill.Tables[0].Rows[0]["ToDate"].ToString();
                        txtFromdt_TextChanged(sender, e);
                    }
                    string[] IsRoomNO = new string[4];
                    IsRoomNO = dsFill.Tables[0].Rows[0]["RoomNo"].ToString().Split(",".ToCharArray());
                    if (IsRoomNO.Length >= 1)
                    {
                        r1 = IsRoomNO[0].Trim();
                        getCheckedValue(r1);
                        ChkBedRequired_CheckedChanged(sender, e);
                    }
                    if (IsRoomNO.Length >= 2)
                    {
                        r2 = IsRoomNO[1].Trim();
                        getCheckedValue(r2);
                        ChkBedRequired_CheckedChanged(sender, e);
                    }
                    if (IsRoomNO.Length >= 3)
                    {
                        r3 = IsRoomNO[2].Trim();
                        getCheckedValue(r3);
                        ChkBedRequired_CheckedChanged(sender, e);
                    }
                    if (IsRoomNO.Length >= 4)
                    {
                        r4 = IsRoomNO[3].Trim();
                        getCheckedValue(r4);
                        ChkBedRequired_CheckedChanged(sender, e);
                    }
                    string[] IsChkBedRequired = new string[4];
                    IsChkBedRequired = dsFill.Tables[0].Rows[0]["IsExtraBedRequired"].ToString().Split(",".ToCharArray());

                    if (IsChkBedRequired.Length >= 1)
                    {
                        r1 = IsChkBedRequired[0].Trim();
                        CheckExtrabedValue(r1);                      
                    }
                    if (IsChkBedRequired.Length >= 2)
                    {
                        r2 = IsChkBedRequired[1].Trim();
                        CheckExtrabedValue(r2);     
                    }
                    if (IsChkBedRequired.Length >= 3)
                    {
                        r3 = IsChkBedRequired[2].Trim();
                        CheckExtrabedValue(r3);              
                    }
                    if (IsChkBedRequired.Length >= 4)
                    {
                        r4 = IsChkBedRequired[3].Trim();
                        CheckExtrabedValue(r4);
                    }
                    ChkBedRequired_CheckedChanged(sender, e);
                }
            }
            else
            {

            }
        }
        catch
        {

        }
    }

    protected void getCheckedValue(string r)
    {
        if (r == "1")
        {
            ChkRoom1.Checked = true;
        }
        if (r == "2")
        {
            ChkRoom2.Checked = true;
        }
        if (r == "3")
        {
            ChkRoom3.Checked = true;
        }
        if (r == "4")
        {
            ChkRoom4.Checked = true;
        }
    }
    protected void CheckExtrabedValue(string r)
    {
        if (r == "1")
        {
            ChkBedRequired1.Checked = true;
        }
        if (r == "2")
        {
            ChkBedRequired2.Checked = true;
        }
        if (r == "3")
        {
            ChkBedRequired3.Checked = true;
        }
        if (r == "4")
        {
            ChkBedRequired4.Checked = true;
        }
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
        // hf_noofroom.Value = lblNoOfRoom.Text;


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
            //hf_noofday.Value = lblNoOfDay.Text;
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
    protected void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            string chkInTime = ddlTime.SelectedItem.Text;
            string chkInTimeAmPm = ddlAMPM.SelectedItem.Text;
            string addChkInTime = chkInTime + "-" + chkInTimeAmPm;
            string extraBedrequired = "";
            string noofroom = "";

            if (ChkRoom1.Checked == true)
            {
                noofroom = "1";
            }
            if (ChkRoom2.Checked == true)
            {
                noofroom += "," + "2";
            }
            if (ChkRoom3.Checked == true)
            {
                noofroom += "," + "3";
            }
            if (ChkRoom4.Checked == true)
            {
                noofroom += "," + "4";
            }
            extraBedrequired = findExtrabedRooms();

            if (hf_ChkInChkOut.Value == "0")
            {
                ds = objdb.ByProcedure("ProcUpdateGuestHousedetails", new string[] { "IdentityType", "IdentityNo", "NoOfRoom", "NoOfDay", "FromDate", "ToDate", "RoomNo", "IsExtraBedRequired", "ExtraBedAmount", "TotalAmount", "CheckInTime", "CheckOutTime", "Isbooked", "ID" },
                     new string[] { ddlIdentityType.SelectedItem.Text, txtIdentityNo.Text, lblNoOfRoom.Text, lblNoOfDay.Text, Convert.ToDateTime(txtFromdt.Text, cult).ToString("yyyy/MM/dd"), Convert.ToDateTime(txtToDt.Text, cult).ToString("yyyy/MM/dd"), noofroom, extraBedrequired, lblExtraBedAmount.Text, lblTotalAmount.Text, addChkInTime, "", "1", Request.QueryString["editGH"].ToString() }, "dataset");

                string masterid = Request.QueryString["editGH"].ToString();
                ds = objdb.ByDataSet("update tbl_GuestHouseBookingDetail set BFromdate = '" + Convert.ToDateTime(txtFromdt.Text, cult).ToString("yyyy/MM/dd") + "' , BTodate = '" + Convert.ToDateTime(txtToDt.Text, cult).ToString("yyyy/MM/dd") + "' where  MasterGuestId ='" + masterid + "'");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "checkIN();", true);
            }
            if (hf_ChkInChkOut.Value == "1")
            {
                DataSet dschk = objdb.ByDataSet("select * from tbl_GuestHousedetail where id = '" + Request.QueryString["editGH"].ToString() + "'");
                string editcheckIn = dschk.Tables[0].Rows[0]["CheckInTime"].ToString();

                ds = objdb.ByProcedure("ProcUpdateGuestHousedetails", new string[] { "IdentityType", "IdentityNo", "NoOfRoom", "NoOfDay", "FromDate", "ToDate", "RoomNo", "IsExtraBedRequired", "ExtraBedAmount", "TotalAmount", "CheckInTime", "CheckOutTime", "Isbooked", "ID" },
              new string[] { ddlIdentityType.SelectedItem.Text, txtIdentityNo.Text, lblNoOfRoom.Text, lblNoOfDay.Text, Convert.ToDateTime(txtFromdt.Text, cult).ToString("yyyy/MM/dd"), Convert.ToDateTime(txtToDt.Text, cult).ToString("yyyy/MM/dd"), noofroom, extraBedrequired, lblExtraBedAmount.Text, lblTotalAmount.Text, editcheckIn, addChkInTime, "0", Request.QueryString["editGH"].ToString() }, "dataset");

                string masterid = Request.QueryString["editGH"].ToString();
                ds = objdb.ByDataSet("update tbl_GuestHouseBookingDetail set BFromdate = '" + Convert.ToDateTime(txtFromdt.Text, cult).ToString("yyyy/MM/dd") + "' , BTodate = '" + Convert.ToDateTime(txtToDt.Text, cult).ToString("yyyy/MM/dd") + "' , IsBook = '0' where  MasterGuestId ='" + masterid + "'");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "checkOut();", true);
            }

            obCommonFuction.EmptyTextBoxes(this);


        }
        catch (Exception ex) { lblError.Text = objdb.ErrorAlert(ex.Message.ToString()); }
    }
    protected void BtnIn_Click(object sender, EventArgs e)
    {
        hf_ChkInChkOut.Value = "0";
        lblCheckInOut.Text = "Check In Time";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopupOpen();", true);
       
    }
    protected void BtnOut_Click(object sender, EventArgs e)
    {
        hf_ChkInChkOut.Value = "1";
        lblCheckInOut.Text = "Check Out Time";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "PopupOpen();", true);
     
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