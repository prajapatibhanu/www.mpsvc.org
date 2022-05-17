using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DotNetIntegrationKit;
using System.Configuration;

public partial class frmResponse : System.Web.UI.Page
{
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
        APIProcedure objdb = new APIProcedure();
        string mbNo;
        string rbmobileprefered = "1";
        var RquestParameter = Request.QueryString["Type"].ToString();
        string[] ItemValue = RquestParameter.Split("*".ToCharArray());
        string ApplicationNo = ItemValue[0];
        Int32 ApplicationType = Convert.ToInt32(ItemValue[1]);
        string Tempid = ItemValue[2];
        DataSet TempTransactionDetail = objdb.ByDataSet("Select * from Tbl_Transaction where id ='" + Tempid + "'");
        string str = TempTransactionDetail.Tables[0].Rows[0]["TblMaster"].ToString();
        DataSet dsSentMail = objdb.ByDataSet("Select * from tblNewRegistration where ApplicationNo='" + ApplicationNo + "'");
        
        if (str != "")
        {
            objdb.ByText(str);
        }
        DataSet dsMaxid = objdb.ByDataSet("Select Max(Id) as Id from Tbl_Transactiondetails where ApplicationNo='" + ApplicationNo + "'");
        string maxid = dsMaxid.Tables[0].Rows[0]["Id"].ToString();
        objdb.ByText("Update Tbl_Transactiondetails set TransactionStatus = '" + strPG_TxnStatus + "', TransactionId = '" + strPG_ClintTxnRefNo + "' where Id = '" + maxid + "'");

        objdb.ByText("Delete from Tbl_Transaction  where ApplicationNo='" + ApplicationNo + "'");
        if (rbmobileprefered == "1")
        {
            mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo"].ToString();
        }
        else
        {
            mbNo = dsSentMail.Tables[0].Rows[0]["MobileNo2"].ToString();
        }
        string mail = dsSentMail.Tables[0].Rows[0]["EmailId"].ToString();
        string subject = "MPSVC Registration Mail";
        string body = objdb.CreateEmailBody(ApplicationType, ApplicationNo); //Email body function
        string mbMessage = objdb.CreateMessageBody(ApplicationType, ApplicationNo); // Message Body Function
        objdb.SendMailMPSVC(mail, subject, body, "", mbNo, mbMessage); //Common Function for sent email.
        lblMsg.Text = objdb.SaveAlert("Application submitted successfully, Please check your email for further details.");    
    }
}