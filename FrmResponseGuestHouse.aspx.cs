using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetIntegrationKit;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public partial class FrmResponseGuestHouse : System.Web.UI.Page
{
    APIProcedure objdb = new APIProcedure();
    #region Variable Declaration

    string strHEX, strPGActualReponseWithChecksum, strPGActualReponseEncrypted, strPGActualReponseDecrypted, strPGresponseChecksum, strPGTxnStatusCode;
    string[] strPGChecksum, strPGTxnString;
    bool isDecryptable = false;

    string strPG_TxnStatus = string.Empty,
    strPG_ClintTxnRefNo = string.Empty,
            strPG_TPSLTxnBankCode = string.Empty,
            strPG_TPSLTxnID = string.Empty,
            strPG_TxnAmount = string.Empty,
            strPG_TxnDateTime = string.Empty,
            strPG_TxnDate = string.Empty,
            strPG_TxnTime = string.Empty;
    string strPGResponse;
    string[] strSplitDecryptedResponse;
    string[] strArrPG_TxnDateTime;
    string strDecryptedVal = string.Empty;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        strPGResponse = Request["msg"].ToString();
        if (strPGResponse != "" || strPGResponse != null)
        {
            //LBL_DisplayResult.Text = "Response :: " + strPGResponse;
            //Creating Object of Class DotNetIntegration_1_1.RequestURL
            RequestURL objRequestURL = new RequestURL();
            //Decrypting the PG response
            strDecryptedVal = objRequestURL.VerifyPGResponse(strPGResponse, Server.MapPath("Merchant.property"));
        }
        //lblResponseDecrypted.Text = strDecryptedVal;
        if (strDecryptedVal.StartsWith("ERROR"))
        {
            //lblValidate.Text = strDecryptedVal;
        }
        else
        {
            strSplitDecryptedResponse = strDecryptedVal.Split('|');
            GetPGRespnseData(strSplitDecryptedResponse);
            if (strPG_TxnStatus == "0300")
            {
                lblValidate.Text = "Transaction Success . Transaction Reference id =  " + strPG_ClintTxnRefNo;
                SendEmailWithSMS();
            }
            else
            {
                lblValidate.Text = "Transaction Fail :: <br/>" + " Transaction Reference id :: <br/>"
        + strPG_ClintTxnRefNo;
            }
        }
    }
    public void GetPGRespnseData(string[] parameters)
    {
        string[] strGetMerchantParamForCompare;
        for (int i = 0; i < parameters.Length; i++)
        {
            strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
            if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_STATUS")
            {
                strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
            }
            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "CLNT_TXN_REF")
            {
                strPG_ClintTxnRefNo = Convert.ToString(strGetMerchantParamForCompare[1]);
            }
            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_BANK_CD")
            {
                strPG_TPSLTxnBankCode = Convert.ToString(strGetMerchantParamForCompare[1]);
            }
            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_TXN_ID")
            {
                strPG_TPSLTxnID = Convert.ToString(strGetMerchantParamForCompare[1]);
            }
            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_AMT")
            {
                strPG_TxnAmount = Convert.ToString(strGetMerchantParamForCompare[1]);
            }
            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_TXN_TIME")
            {
                strPG_TxnDateTime = Convert.ToString(strGetMerchantParamForCompare[1]);
                strArrPG_TxnDateTime = strPG_TxnDateTime.Split(' ');
                strPG_TxnDate = Convert.ToString(strArrPG_TxnDateTime[0]);
                strPG_TxnTime = Convert.ToString(strArrPG_TxnDateTime[1]);
            }
        }
    }
    public void SendEmailWithSMS()
    {
        string mbNo;
        string rbmobileprefered = "1";
        var RquestParameter = Request.QueryString["Type"].ToString();
        string[] ItemValue = RquestParameter.Split("*".ToCharArray());
        string ApplicationNo = ItemValue[0].Trim();
        string TempTranid = ItemValue[1].Trim();
        DataSet dsSentMail = objdb.ByDataSet("Select * from tblNewRegistration where ApplicationNo='" + ApplicationNo + "'");
        DataSet TempTransactionDetail = objdb.ByDataSet("Select * from Tbl_Transaction where id ='" + TempTranid + "'");
        string GuestHouseid = insertGuestHouseDetails(TempTransactionDetail, ApplicationNo);
        string RegistrationNo = "";
        string GName = "";
        if (dsSentMail.Tables[0].Rows.Count > 0)
        {
            RegistrationNo = dsSentMail.Tables[0].Rows[0]["RegiNo"].ToString();
            GName = dsSentMail.Tables[0].Rows[0]["FName"].ToString() + " " + dsSentMail.Tables[0].Rows[0]["MName"].ToString() + " " + dsSentMail.Tables[0].Rows[0]["LName"].ToString();
        }
        objdb.ByText("Update tbl_GuestHousedetail set PaymentStatus = 1  and TransactionId = '" + strPG_ClintTxnRefNo + "' where id = '" + GuestHouseid + "'");
        DataSet dsguesthousedetail = objdb.ByDataSet("Select * from tbl_GuestHousedetail where id='" + GuestHouseid + "'");
        if (rbmobileprefered == "1")
        {
            mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo"].ToString();
        }
        else
        {
            mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo2"].ToString();
        }
        objdb.sendOTPSms(mbNo, "Room no. " + dsguesthousedetail.Tables[0].Rows[0]["RoomNo"].ToString() + " booked at MPVCI  Guest House from  " + Convert.ToDateTime(dsguesthousedetail.Tables[0].Rows[0]["FromDate"]).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(dsguesthousedetail.Tables[0].Rows[0]["ToDate"]).ToString("dd/MM/yyyy") + " Kindly bring your submitted id ");
        lblMsg.Text = objdb.SaveAlert("Room Booked Successfully, Please check your SMS to know about your booking detail.");
        Regstration_Certificate(dsguesthousedetail.Tables[0], GName);
    }
    private string insertGuestHouseDetails(DataSet dstemp, string ApplicationNo)
    {
        string str = dstemp.Tables[0].Rows[0]["TblMaster"].ToString();
        string[] strValue = new string[15];
        strValue = str.Split("*".ToCharArray());
        string str1 = dstemp.Tables[0].Rows[0]["TblTran"].ToString();
        string[] strNoOfRoom = new string[5];
        strNoOfRoom = str1.Split(",".ToCharArray());

        DataSet ds = objdb.ByProcedure("ProcInsertGuestHousedetails", new string[] { "RegiNo", "IdentityType", "IdentityNo", "NoOfRoom", "NoOfDay", "FromDate", "ToDate", "RoomNo", "IsExtraBedRequired", "ExtraBedAmount", "TotalAmount", "PaymentStatus", "Isbooked", "DateOfBooking" },
         new string[] { strValue[0], strValue[1], strValue[2], strValue[3], strValue[4], strValue[5], strValue[6], strValue[7], strValue[8], strValue[9], strValue[10], strValue[11], strValue[12], strValue[13] }, "dataset");

        string masterid = ds.Tables[0].Rows[0]["id"].ToString();

        for (int i = 0; i <= strNoOfRoom.Length - 1; i++)
        {
            ds = objdb.ByProcedure("ProcInsertGuestTransactiondetails", new string[] { "RegNo", "MasterGuestId", "RoomId", "BFromdate", "BTodate", "IsBook" },
                    new string[] { strValue[0], masterid, strNoOfRoom[i], strValue[5], strValue[6], "1" }, "dataset");
        }

        //objdb.ByText("Delete from Tbl_Transaction  where ApplicationNo='" + ApplicationNo + "'");
        return masterid;
    }
    private void Regstration_Certificate(DataTable dt, string name)
    {

        StringBuilder sbReceipt = new StringBuilder();
        String popScript;
        sbReceipt.Append("<table style ='width :50% ; border-style:solid; border-color:Black'>");
        sbReceipt.Append("<tr><td colspan='2' align='center' style='height: 41px'><b><span>Madhya Pradesh State Veterinary Council </br> Room Confirmation Slip</span></b></td> </tr><tr> <td style='width: 246px'>Registration No.</td><td>");
        sbReceipt.Append(dt.Rows[0]["RegiNo"].ToString() + "</td>");
        sbReceipt.Append("</tr> <tr><td style='width: 246px'>Name of Guest</td><td>");
        sbReceipt.Append(name + "</td>");
        sbReceipt.Append("</tr> <tr><td style='width: 246px'>Room No.</td> <td>");
        sbReceipt.Append(dt.Rows[0]["RoomNo"].ToString());
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr><tr> <td style='width: 246px'>Extra Bed Require Rooms </td>");
        sbReceipt.Append("<td>");
        sbReceipt.Append(dt.Rows[0]["IsExtraBedRequired"].ToString());
        sbReceipt.Append("</td></tr><tr><td style='width: 246px; font-weight: bold;'>Total Amount </td><td>");
        sbReceipt.Append(dt.Rows[0]["TotalAmount"].ToString());
        sbReceipt.Append("</td> </tr> <tr><td style='width: 246px'></td> <td></td> </tr> </table>");

        Session["PrintSTR"] = sbReceipt;
        popScript = "<script language='javascript' type='text/javascript'>window.open('AdminSection/PrintHTMLReport.aspx','_blank','addressbar=yes,resizable=yes,toolbar=no,status=no,menubar=no,location=center,scrollbars=yes,width=950,height=520')</script>";
        Page.RegisterStartupScript("popScript", popScript);

    }

}