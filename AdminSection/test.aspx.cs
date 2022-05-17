using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

public partial class AdminSection_test : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    // DataSet dsNew = new DataSet();
    //DataSet dsRenew = new DataSet();
    APIProcedure api = new APIProcedure();
    CultureInfo cult = new CultureInfo("gu-IN", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        //ViewState["Renew"] = ""; // raje
        string[] arr = Request.QueryString["ID"].ToString().Split("*".ToCharArray());
        string applicationNo = arr[1];
        string Tid = arr[0];
        ds = api.ByProcedure("GetUSerDetailsWithTransaction", new string[] { "ApplicationNo", "TransctionId" }, new string[] { applicationNo, Tid }, "dataset");

        if (ds.Tables[0].Rows.Count > 0)
        {

            if (ds.Tables[1].Rows[0]["ApplicationRequestId"].ToString() == "0")
            {
                Regstration_Certificate(ds);
            }
            else if (ds.Tables[1].Rows[0]["ApplicationRequestId"].ToString() == "1")
            {
                //ViewState["Renew"] = "Renew"; // raje
                Renew_Certificate(ds);
            }
            else if (ds.Tables[1].Rows[0]["ApplicationRequestId"].ToString() == "2")
            {
                Noc_Certificate(ds);
            }
            else if (ds.Tables[1].Rows[0]["ApplicationRequestId"].ToString() == "3")
            {
                TransferInMP_Certificate(ds);
            }
            else if (ds.Tables[1].Rows[0]["ApplicationRequestId"].ToString() == "5")
            {
                Regstration_Certificate(ds);
            }
            else if (ds.Tables[1].Rows[0]["ApplicationRequestId"].ToString() == "7")
            {
                Provisional_Certificate(ds);
            }

            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "print", "window.print();", true);
        }

    }

    //private void Noc_Certificate(DataSet dsNoc) //old noc certificate
    //{


    //    int TransferstateId = 0;
    //    string TransferStateName = "";
    //    try
    //    {
    //        DataSet dsTransferState = new DataSet();
    //        TransferstateId = Convert.ToInt16(dsNoc.Tables[0].Rows[0]["Transferstateid"]);
    //        dsTransferState = api.ByDataSet("select * from tblStateMaster where StateId = " + TransferstateId);
    //        TransferStateName = dsTransferState.Tables[0].Rows[0]["StateName"].ToString();
    //    }
    //    catch
    //    {
    //    }
    //    string regNo = dsNoc.Tables[0].Rows[0]["RegiNo"].ToString();
    //    string regDate = getDate(dsNoc.Tables[0].Rows[0]["RegiDate"].ToString());
    //    string name = dsNoc.Tables[0].Rows[0]["FName"].ToString() + " " + dsNoc.Tables[0].Rows[0]["MName"].ToString() + " " + dsNoc.Tables[0].Rows[0]["LName"].ToString();
    //    string validupto = getDate(dsNoc.Tables[0].Rows[0]["Validupto"].ToString());
    //    string fathername = dsNoc.Tables[0].Rows[0]["FatherName"].ToString();
    //    string dob = Convert.ToDateTime(dsNoc.Tables[0].Rows[0]["DOB"].ToString(), cult).ToString("dd/MM/yyyy");
    //    string perAddress = dsNoc.Tables[0].Rows[0]["PerAdd"].ToString() + " " + dsNoc.Tables[0].Rows[0]["PerCity"].ToString() + " " + dsNoc.Tables[0].Rows[0]["PerDistrict"].ToString() + " " + dsNoc.Tables[0].Rows[0]["PerPinCode"].ToString();
    //    string YearOfPassing = dsNoc.Tables[0].Rows[0]["Year1"].ToString();

    //    StringBuilder sbNoc = new StringBuilder();

    //    sbNoc.Append("<table align=center width='100%' style='border-style: solid; border-color: Black;'>");
    //    sbNoc.Append("<tr><td align='left'><img src='../images/Vet-Council-Logo.bmp' alt='' width='150px' height='150px;' style='padding-top: 20px;padding-left: 20px;padding-bottom: 20px;'/></td><td colspan='2'><h2>Madhya Pradesh State Veterinary Council, Vaishali Nagar, Bhopal,462003</h2> <br /><b>Tel: 2670153 (Off); Fax: 0755-2670153</b><br /><b>Email: mpsvc.bhopal@gmail.com</b></td></tr><tr><td colspan='3' align='center'>A Statutory Body Constituted Under the Indian Veterinary Council Act, 1984 Adoptedby Government of Madhya Pradesh in 1986<hr /></td></tr><tr><td align='left'><b>No.</b></td><td align='center'><b> /MPSVC /NOC /Bhopal /2018-19</b></td><td align='center'><b> Date-</b></td></tr><tr><td colspan='3' align='center'><br /><b><u>NO DUES CERTIFICATE</u></b><br /></td></tr><tr><td colspan='3' style='line-height: 1.5;'><br />");
    //    sbNoc.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>This is to certify that Dr. " + name + " was registered</b>");
    //    sbNoc.Append("<b> with Madhya Pradesh State Veterinary Council bearing Registration No.</b>");
    //    sbNoc.Append("<b>MPSVC/" + regNo + " on Date- " + regDate + "</b>");
    //    sbNoc.Append(" </td></tr><tr><td ></td><td colspan='2' style='line-height: 1.3;'>1) There are no dues against him/her in this Council.<br />2) There is no objection of this Council for his/her registration with any other Veterinary Council.<br /><br />His/Her other details as per the MP State Veterinary Council Register are as follows:<br /></td></tr><tr><td colspan='3'style='line-height: 1.4;'><br />");
    //    sbNoc.Append("<b>Registration valid up to: " + validupto + "</b>");
    //    sbNoc.Append("<br />");
    //    sbNoc.Append("Father's Name: " + fathername + "");
    //    sbNoc.Append("<br />");
    //    sbNoc.Append("Date of Birth: " + dob + "");
    //    sbNoc.Append("<br />");
    //    sbNoc.Append("Year of acquiring qualification: " + YearOfPassing + "");
    //    sbNoc.Append("<br />");
    //    sbNoc.Append("Permanent address: " + perAddress + "");
    //    sbNoc.Append("<br/><br/><br/><br/><br/><br/></td></tr><tr><td colspan='2'></td><td align='center'>Registrar<br />M.P. State Veterinary Council<br />Bhopal</b></td></tr><tr><td align='left'><b>No.</b></td><td align='center'><b> /MPSVC /NOC /Bhopal /2016-17</b></td><td align='center'><b> Date-</b></td></tr><tr><td colspan='3' style='line-height: 1.3;'>CC. for information to:<br />1. Secretary, Veterinary Council of India, New Delhi.<br />2. Registrar,  " + TransferStateName + " State Veterinary Council</td></tr><tr><td colspan='2'></td><td align='center'><b>Registrar<br />M.P. State Veterinary Council<br />Bhopal</b></td></tr><tr><td  align='Left'></td></tr></table>");

    //    dvReceipt.InnerHtml = sbNoc.ToString();

    //}

    private void Noc_Certificate(DataSet dsNoc)
    {

        int TransferstateId = 0;
        string TransferStateName = "";
        try
        {
            DataSet dsTransferState = new DataSet();
            TransferstateId = Convert.ToInt16(dsNoc.Tables[0].Rows[0]["Transferstateid"]);
            dsTransferState = api.ByDataSet("select * from tblStateMaster where StateId = " + TransferstateId);
            TransferStateName = dsTransferState.Tables[0].Rows[0]["StateName"].ToString();
        }
        catch
        {
        }
        string regNo = dsNoc.Tables[0].Rows[0]["RegiNo"].ToString();
        //string regDate = getDate(dsNoc.Tables[0].Rows[0]["RegiDate"].ToString());
        string name = dsNoc.Tables[0].Rows[0]["FName"].ToString() + " " + dsNoc.Tables[0].Rows[0]["MName"].ToString() + " " + dsNoc.Tables[0].Rows[0]["LName"].ToString();
        string validupto = Convert.ToDateTime(dsNoc.Tables[0].Rows[0]["Validupto"], cult).ToString("dd/MM/yyyy");
        string fathername = dsNoc.Tables[0].Rows[0]["FatherName"].ToString();
        string dob = Convert.ToDateTime(dsNoc.Tables[0].Rows[0]["DOB"].ToString(), cult).ToString("dd/MM/yyyy");
        string perAddress = dsNoc.Tables[0].Rows[0]["PerAdd"].ToString() + " " + dsNoc.Tables[0].Rows[0]["PerCity"].ToString() + " " + dsNoc.Tables[0].Rows[0]["PerDistrict"].ToString() + " " + dsNoc.Tables[0].Rows[0]["PerPinCode"].ToString();
        //string YearOfPassing = dsNoc.Tables[0].Rows[0]["Year1"].ToString();
        //string perAddress = dsNoc.Tables[0].Rows[0]["ResAdd"].ToString();

        StringBuilder sbNoc = new StringBuilder();

        //sbNoc.Append("<table align=center width='100%' style='border-style: solid; border-color: Black;'>");
        //sbNoc.Append("<tr><td align='left'><img src='../images/Vet-Council-Logo.bmp' alt='' width='150px' height='150px;' style='padding-top: 20px;padding-left: 20px;padding-bottom: 20px;'/></td><td colspan='2'><h2>Madhya Pradesh State Veterinary Council, Vaishali Nagar, Bhopal,462003</h2> <br /><b>Tel: 2670153 (Off); Fax: 0755-2670153</b><br /><b>Email: mpsvc.bhopal@gmail.com</b></td></tr><tr><td colspan='3' align='center'>A Statutory Body Constituted Under the Indian Veterinary Council Act, 1984 Adoptedby Government of Madhya Pradesh in 1986<hr /></td></tr><tr><td align='center' colspan='3'><b>PART 3</b></td></tr><tr><td colspan='3' align='center'><br /><b><u>Verification and No Objection Certificate by the State Veterinary Council</u></b><br /></td></tr><tr><td colspan='3' style='line-height: 1.5;'><br />");
        //sbNoc.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>It is certified that the details provided in Part 1 and 2 of the application have been verified </b>");
        //sbNoc.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b> and found to be correct. The name of Dr. " + name + "  in this<b>");
        //sbNoc.Append("<br />");
        //sbNoc.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b> is registered  State Council </b>");     
        //sbNoc.Append("<b>  and his/her registration number is. MPSVC/" + regNo + " which valid </b>");
        //sbNoc.Append("<br />");
        //sbNoc.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b> up to " + validupto + " Further,in respect of Dr." + name + "  </b>");        
        //sbNoc.Append("<b>there is no due </b>");
        //sbNoc.Append("<br />");
        //sbNoc.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>or any Disciplinary case pending / contemplated </b>");      
        //sbNoc.Append("<b>at this Council. This Council has NO  </b>");
        //sbNoc.Append("<br/>");      
        //sbNoc.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>OBJECTION /OBJECTION (Strike out which is not applicable) for the transfer of </b>");    
        //sbNoc.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>registration Of Dr. " + name + "  To " + TransferStateName + " State Veterinary Council </b>");
        //sbNoc.Append("<br/>");
        //sbNoc.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>  DR. " + name + " has surrendered his her original certificate to this  </b>");
        //sbNoc.Append("<br />");
        //sbNoc.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>State Council his/her name will be deleted from the register of this State Council.</b>");
        //sbNoc.Append("<br />");
        //sbNoc.Append("<b><br/><br/></td></tr><tr><td colspan='2'></td><td align='center'><b>पंजीयक का नाम<br/>/Name of Registrar: ________ <br />हस्ताक्षर/Signature: ________ <br />स्थान/Place:________ <br />तिथि/Date:________</td></tr><tr><td align='left' ><b>File No.:________<br /><br /></td><td align='center'><b></b></td><td align='center'><b> </b></td></tr><tr><td colspan='3' style='line-height: 1.3;'><b>अग्रसरित/Forworded to:<br />सचिव/The Secretary<br />भारतीय पशु चिकित्सा परिषद्/Vetenary Council of India<br /><b>अगस्त क्रांति भवन/August Kranti Bhawan<br /><b>भीकाजी काम्प्लेक्स/Bhikaji Complex<br /><b>नई दिल्ली 110066- New Delhi -110066<br /><b>Email – vciinfo@nic.in</ b></td></tr><tr><td colspan='3' align='right'><b style='padding-right:20px'>राज्य परिषद की सील<br /><b>(Seal Of Council)<br />M.P. State Veterinary Council<br />Bhopal</b></td></tr><tr><td  align='Left'></td></tr></table>");


          sbNoc.Append("<table  width='100%' style='border-style: solid; border-color: Black;'>");
          sbNoc.Append("<tr>");
          sbNoc.Append("<td align='left'>");
          sbNoc.Append("<img src='../images/Vet-Council-Logo.bmp' alt='' width='150px' height='150px;' style='padding-top: 20px; padding-left: 20px; padding-bottom: 20px;' /></td>");
          sbNoc.Append("<td colspan='2'>");
          sbNoc.Append("<h2>Madhya Pradesh State Veterinary Council, Vaishali Nagar, Bhopal,462003</h2>");
          sbNoc.Append("<br />");
          sbNoc.Append("<b>Tel: 2670153 (Off); Fax: 0755-2670153</b>");
          sbNoc.Append("<br />");
          sbNoc.Append("<b>Email: mpsvc.bhopal@gmail.com</b>");
          sbNoc.Append("</td>");
          sbNoc.Append("</tr>");
          sbNoc.Append("<tr>");
          sbNoc.Append("<td colspan='3' align='center' >A Statutory Body Constituted Under the Indian Veterinary Council Act, 1984 Adoptedby");
          sbNoc.Append("</td>");
          sbNoc.Append("</tr>");
          sbNoc.Append("<tr>");
          sbNoc.Append("<td colspan='3'  align='center' >Government of Madhya Pradesh in 1986<hr />");
          sbNoc.Append("</td>");
          sbNoc.Append("</tr>");
          sbNoc.Append("<tr>");
          sbNoc.Append("<br />");
          sbNoc.Append("<td colspan='3' align='center'><b>PART 3</b>");
          sbNoc.Append("</td>");
          sbNoc.Append("</tr>");
          sbNoc.Append("<tr>");
          sbNoc.Append("<td colspan='3' align='center'>");                       
          sbNoc.Append("<b>Verification and No Objection Certificate by the State Veterinary Council</b>");
          sbNoc.Append("</td>");
          sbNoc.Append("</tr>");
          sbNoc.Append("<tr>");
          sbNoc.Append("<td colspan='3' style='line-height: 1.5;'>");
          sbNoc.Append("<div style='width:90%;margin:auto'>");
          sbNoc.Append("<br />");
          sbNoc.Append("<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;It is certified that the details provided in Part 1 and 2 of the application have been verified and found to be correct. The name of Dr. " + name + "  is registered in this State Council and his/her registration number is. MPSVC/" + regNo + " which valid  up to " + validupto + ".</b>");
          sbNoc.Append("<br /><br /><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Further, in respect of Dr." + name + "  there is no due or any Disciplinary case pending / contemplated at this Council. This Council has NO OBJECTION /OBJECTION (Strike out which is not applicable) for the transfer of registration Of Dr. " + name + "  To " + TransferStateName + " State Veterinary Council. DR. " + name + " has surrendered his/her original certificate to this State Council his/her name will be deleted from the register of this State Council.</b>");
          sbNoc.Append("</div>");
          sbNoc.Append("</td>");
          sbNoc.Append("</tr>");              
          sbNoc.Append("<tr>");
          //sbNoc.Append("<td colspan='3'><div style='display:inline-block;float:right;padding-right:40px'>");
          sbNoc.Append("<td colspan='3'><div style='display:inline-block;float:right;padding-right:20px'>");
          sbNoc.Append("<br />");
          sbNoc.Append("<b>पंजीयक का नाम<br />");
          sbNoc.Append("/Name of Registrar: (Dr. Umesh Chandra Sharma)");
          sbNoc.Append("</b><br />");
          sbNoc.Append("<b>हस्ताक्षर/Signature: ________</b>");
          sbNoc.Append("<br />");
          sbNoc.Append("<b>स्थान/Place: Bhopal</b>");
          sbNoc.Append("<br /><b>तिथि/Date:________ </b>");
          sbNoc.Append("</div>");
          sbNoc.Append("</td>");
          sbNoc.Append(" </tr>");
          sbNoc.Append("<tr>");
          sbNoc.Append(" <td colspan='3'>");
          sbNoc.Append("<div style='display:inline-block;float:left;padding-left:40px'>");
          sbNoc.Append("<b>File No.:________</b><br />");
          sbNoc.Append("<br /></div></td>");                   
          sbNoc.Append("</tr>");
          sbNoc.Append("<tr>");                    
          sbNoc.Append("<td colspan='3' style='line-height: 1.3;'>");
          sbNoc.Append("<div style='display:inline-block;float:left;padding-left:40px'>");
          sbNoc.Append("<b>अग्रसरित/Forwarded to:<br />");
          sbNoc.Append("सचिव/The Secretary<br />");
          sbNoc.Append("भारतीय पशु चिकित्सा परिषद्/Veterinary Council of India<br />");
          sbNoc.Append("अगस्त क्रांति भवन/August Kranti Bhawan<br />");
          sbNoc.Append("भीकाजी काम्प्लेक्स/BhikajiCama Place<br />");
          sbNoc.Append("नई दिल्ली 110066- New Delhi -110066<br />");
          sbNoc.Append("Email – vciinfo@nic.in</b>");
          sbNoc.Append("</div></td>");
          sbNoc.Append("</tr>");
          sbNoc.Append("<tr>");
          sbNoc.Append("<td colspan='2' align='right'><div style='display:inline-block;float:right;padding:0 40px 20px 0'><b>राज्य परिषद की सील<br />");
          sbNoc.Append("(Seal Of Council)<br />");
          sbNoc.Append("M.P. State Veterinary Council<br />");
          sbNoc.Append(" Bhopal</b></div></td>");
          sbNoc.Append("</tr>");               
          sbNoc.Append(" </table>");

          dvReceipt.InnerHtml = sbNoc.ToString();
    }


    private void Regstration_Certificate(DataSet dsNew)
    {
        string Picpath = "";

        if (dsNew.Tables[0].Rows[0]["File3"].ToString() != "")
        {
            Picpath = dsNew.Tables[0].Rows[0]["File3"].ToString();

        }
        string validupto = getDate(dsNew.Tables[0].Rows[0]["Validupto"].ToString());
        string regNo = dsNew.Tables[0].Rows[0]["RegiNo"].ToString();
        // string regDate = getDate(dsNew.Tables[0].Rows[0]["RegiDate"].ToString());
        DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
        DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local

        string regDate = localTime.ToString("dd/MM/yyyy");


        string district = dsNew.Tables[0].Rows[0]["PerDistrict"].ToString();
        string name = dsNew.Tables[0].Rows[0]["FName"].ToString() + " " + dsNew.Tables[0].Rows[0]["MName"].ToString() + " " + dsNew.Tables[0].Rows[0]["LName"].ToString();

        string Rpt = "";
        StringBuilder sbReceipt = new StringBuilder();

        sbReceipt.Append("<table width='700px'   style='border-style:solid; border-color:Black' height='900px'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("<table width='650px' border='0' height='900px' >");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;'>");
        sbReceipt.Append("<b>FORM-X</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;'>");
        sbReceipt.Append("<b>[See rule 10(3)]</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4; font-size:xx-large'>");
        sbReceipt.Append("<b style='font-family: cooper;'>CERTIFICATE OF REGISTRATION</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td colspan='2'>");
        sbReceipt.Append("");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;font-size:small'>");
        sbReceipt.Append("<b>Madhya Pradesh State Veterinary Council established under Section 32</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;font-size:small'>");
        sbReceipt.Append("<b>of the Indian Veterinary Council Act, 1984 (No. 52 of 1984)</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("<table width='550px' border='0'  style='border-style:solid;'>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'right' width='60%'>");
        sbReceipt.Append("<img height='150px' width='150px' src='../images/Vet-Council-Logo.bmp' />");
        sbReceipt.Append("</td>");
        sbReceipt.Append("<td align= 'right'>");
        sbReceipt.Append("<img height='150px' width='150px' src='../Upload_Certificate/" + Picpath + "' />");

        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");
        sbReceipt.Append("<table style='line-height: 1.5;font-size: 18px;'>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left'>");
        sbReceipt.Append("<table width= '65%' style='border-style:solid; border-color: #548DD4;border-radius: 7px;'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' style='color: #548DD4; font-weight:bold'>");
        sbReceipt.Append("No. MPSVC &nbsp;&nbsp;&nbsp;<span style='color:maroon;'>" + regNo + "</span>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");

        sbReceipt.Append("<td align= 'right'>");
        sbReceipt.Append("<table width= '100%' style='border-style:solid; border-color: #548DD4;border-radius: 7px;'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' style='color: #548DD4; font-weight:bold'>");
        sbReceipt.Append("Date &nbsp;&nbsp;&nbsp;<span style='color:maroon;'> " + regDate + "</span>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td colspan='2'>");
        sbReceipt.Append("<p style='text-align: justify;color: #548DD4;font-weight: bold;font-size: 20px;line-height: 1.6;margin: 5px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This is to certify that Dr.<span style='color:maroon;'> " + name + "  </span> resident of <span style='color:maroon;'>" + district + ", Madhya Pradesh</span> have been duly registered   as   Registered Veterinary Practitioner and is entitled  to all the privileges granted to such practitioners under the Indian Veterinary Council Act, 1984 (No. 52 of 1984). This Registration has been effected with   the Madhya Pradesh State Veterinary Council,   under the said act.");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td colspan='2'>");
        sbReceipt.Append("<p style='text-align: justify;color: #548DD4;font-weight: bold;font-size: 20px;line-height: 1.6;margin: 5px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In witness where of are herewith affixed the seal of the Madhya Pradesh State Veterinary Council and Signature of the Registrar of the said State Council.</p>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr> <td align='left' colspan='2'> <table width='50%' style='border-style:solid; border-color: #548DD4;border-radius: 7px;'>  <tbody>  <tr>  <td align='center' style='color: #548DD4; font-weight:bold'>Date of Next Renewal&nbsp;&nbsp;&nbsp;<span style='color:maroon;'>" + validupto + "</span>  </td>  </tr>  </tbody> </table> </td> </tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'right' colspan='2' style='color: #548DD4; font-weight:bold' >");
        sbReceipt.Append("Signature of Registrar");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4; '>");
        sbReceipt.Append("<hr/>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");



        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='font-size:small; color: #548DD4;'>");
        sbReceipt.Append("(This Certificate is the property of the Madhya Pradesh State Veterinary Council, and is issued to the Registered");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='font-size:small; color: #548DD4;''>");
        sbReceipt.Append("Veterinary Practitioner mentioned above under rule 10(3) of the M.P. State Veterinary Council rules, 1993)");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='font-size:small; color: red;''>");
        sbReceipt.Append("(As Per the VCI rule 48(I) this registration has to be renewed in every five year before the 1st day of the April of the year to which it relates)");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");
        sbReceipt.Append("</table>");

        dvReceipt.InnerHtml = sbReceipt.ToString();

    }

    private void Renew_Certificate(DataSet dsRenew)
    {
        string Picpath = "";

        if (dsRenew.Tables[0].Rows[0]["FileRenew3"].ToString() != "")
        {
            Picpath = dsRenew.Tables[0].Rows[0]["FileRenew3"].ToString();

        }
        else
        {
            Picpath = dsRenew.Tables[0].Rows[0]["File3"].ToString();
        }
        string regNo = dsRenew.Tables[0].Rows[0]["RegiNo"].ToString();
        //string regDate = getDate(dsRenew.Tables[0].Rows[0]["RegiDate"].ToString());
        DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
        DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local

        string regDate = localTime.ToString("dd/MM/yyyy");
        string validupto = getDate(dsRenew.Tables[0].Rows[0]["Validupto"].ToString());
        string fromdate = "";

        if (dsRenew.Tables[0].Rows[0]["ValidFrom"].ToString() == "")
        {
            fromdate = regDate;
        }
        else
        {
            fromdate = getDate(dsRenew.Tables[0].Rows[0]["ValidFrom"].ToString());
        }
        

        //Start This code is added for advance renewal .. and after 31-03-2017 you can remove this line
        if (Convert.ToDateTime(localTime.ToString("MM/dd/yyyy")) <= Convert.ToDateTime("03/31/2017"))
        {
            if (validupto == "31/3/2022")
            {
                fromdate = "01/04/2017";
            }
        }
        //End

        string name = dsRenew.Tables[0].Rows[0]["FName"].ToString() + " " + dsRenew.Tables[0].Rows[0]["MName"].ToString() + " " + dsRenew.Tables[0].Rows[0]["LName"].ToString();


        StringBuilder sbReceipt = new StringBuilder();

        sbReceipt.Append("<table width='700px' style='border-style:solid; border-color:Black' height='900px'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("<table width='650px' border='0' height='900px' >");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;'>");
        sbReceipt.Append("<b>FORM-XII</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;'>");
        sbReceipt.Append("<b>[See rule 15]</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4; font-size:xx-large'>");
        sbReceipt.Append("<b style='font-family: cooper;'>RENEWAL OF REGISTRATION</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td colspan='2'>");
        sbReceipt.Append("");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;font-size:small'>");
        sbReceipt.Append("Madhya Pradesh State Veterinary Council established under Section 32");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;font-size:small'>");
        sbReceipt.Append("of the Indian Veterinary Council Act, 1984 (No. 52 of 1984) ");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("<table width='550px' border='0'  style='border-style:solid;'>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'right' width='60%'>");
        sbReceipt.Append("<img height='150px' width='150px' src='../images/Vet-Council-Logo.bmp' />");
        sbReceipt.Append("</td>");
        sbReceipt.Append("<td align= 'right' >");
        sbReceipt.Append("<img height='150px' width='150px' src='../Upload_Certificate/" + Picpath + "' />");

        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");
        sbReceipt.Append("<table style='line-height: 1.5;font-size: 18px;'>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2'>");
        sbReceipt.Append("<table width= '40%' style='border-style:solid; border-color: #548DD4; border-radius: 7px;'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' style='color: #548DD4; font-weight:bold'>");
        sbReceipt.Append("No. MPSVC &nbsp;&nbsp;&nbsp;<span style='color:maroon;'> " + regNo + " </span>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td colspan='2'>");
        sbReceipt.Append("<br/>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td colspan='2'>");

        // fromdate & validupto // Updated by rajendra start
        //if (ViewState["Renew"].ToString() == "Renew")
        //{
        //    string[] FDate = fromdate.Split("/".ToCharArray());
        //    string Date_Final = FDate[1] + "/" + FDate[0] + "/" + FDate[2];
        //    if (int.Parse(FDate[1]) < 4)
        //    {
        //        fromdate = "01/04/" + FDate[2].ToString();
        //        validupto = "31/03/" + (int.Parse(FDate[2]) + 5).ToString();
        //    }
        //    CultureInfo cult = new CultureInfo("gu-IN", true);
        //    string valid_Date = Convert.ToDateTime(validupto, cult).ToString("yyyy/MM/dd");
		//
        //    api.ByProcedure("Proc_ValidFrom", new string[] { "type", "RegiNo", "validupto" }, new string[] { "2", regNo, //valid_Date }, "dataset");
        //}
        // Updated by rajendra End



        sbReceipt.Append("<p style='text-align: justify;color: #548DD4;font-weight: bold;font-size: 20px;line-height: 1.6;margin: 5px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This is to certify that Registration of Dr.<span style='color:maroon;'> " + name + "  </span> has been renewed from <span style='color:maroon;'> " + fromdate + "</span> up to <span style='color:maroon;'> " + validupto + "</span> and is entiled to all the privileges granted to such practitioners under the Indian Veterinary Council Act, 1984(No.52 of 1984). This Registration has been effected with the Madhya Pradesh State Veterinary Council, under the said act.</p>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td colspan='2'>");
        sbReceipt.Append("<p style='text-align: justify;color: #548DD4;font-weight: bold;font-size: 20px;line-height: 1.6;margin: 5px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In witness where of are herewith affixed the seal of the Madhya Pradesh State Veterinary Council and Signature of the Registrar of the said State Council.</p>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='color: #548DD4; font-weight:bold'>");
        sbReceipt.Append("Date of issue");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='color:maroon; font-weight:bold'>");
        sbReceipt.Append("" + regDate + "");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'right' colspan='2' style='color: #548DD4; font-weight:bold' >");
        sbReceipt.Append("Signature of Registrar");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4; '>");
        sbReceipt.Append("<hr/>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");



        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='font-size:small; color: #548DD4;'>");
        sbReceipt.Append("(This Certificate is the &nbsp; property of the Madhya Pradesh State Veterinary Council, and is issued to  the Registered");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='font-size:small; color: #548DD4;''>");
        sbReceipt.Append("Veterinary Practitioner &nbsp; mentioned above under rule 15 of &nbsp; the  M.P. &nbsp;State Veterinary Council rules, 1993)");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");
        sbReceipt.Append("</table>");

        dvReceipt.InnerHtml = sbReceipt.ToString();
    }
    private void Provisional_Certificate(DataSet dsRenew)
    {
        string Picpath = "";

        if (dsRenew.Tables[0].Rows[0]["File2"].ToString() != "")
        {
            Picpath = dsRenew.Tables[0].Rows[0]["File2"].ToString();

        }
        string regNo = dsRenew.Tables[0].Rows[0]["RegiNo"].ToString();




        DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
        DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local

        //DateTime dt = localTime.AddMonths(6);
		DateTime dt = localTime.AddYears(1);
        dt = dt.AddDays(-1);
        string validupto = dt.ToString("dd/MM/yyyy");

        string regDate = localTime.ToString("dd/MM/yyyy");
        //string regDate = getDate(dsRenew.Tables[0].Rows[0]["RegiDate"].ToString());
        string name = dsRenew.Tables[0].Rows[0]["FName"].ToString() + " " + dsRenew.Tables[0].Rows[0]["MName"].ToString() + " " + dsRenew.Tables[0].Rows[0]["LName"].ToString();
        //string validupto = getDate(dsRenew.Tables[0].Rows[0]["Validupto"].ToString());
        string fathername = dsRenew.Tables[0].Rows[0]["FatherName"].ToString();
        string dob = Convert.ToDateTime(dsRenew.Tables[0].Rows[0]["DOB"].ToString(), cult).ToString("dd/MM/yyyy");
        string perAddress = dsRenew.Tables[0].Rows[0]["PerAdd"].ToString() + " " + dsRenew.Tables[0].Rows[0]["PerCity"].ToString() + " " + dsRenew.Tables[0].Rows[0]["PerDistrict"].ToString() + " " + dsRenew.Tables[0].Rows[0]["PerPinCode"].ToString();
        string PassingYear = dsRenew.Tables[0].Rows[0]["Year1"].ToString();
        string Univercityid = dsRenew.Tables[0].Rows[0]["University1"].ToString();
        string Colgid = dsRenew.Tables[0].Rows[0]["CollegeID1"].ToString();
        string Gender = dsRenew.Tables[0].Rows[0]["Gender"].ToString();
        DataSet dsuniver = api.ByDataSet("Select * from Tbl_UniversityMaster where ID = '" + Univercityid + "'");
        DataSet dsclg = api.ByDataSet("Select * from tbl_CollegeMaster where ID = '" + Colgid + "'");
        string Univercity = dsuniver.Tables[0].Rows[0]["UniversityName"].ToString();
        string Colg = dsclg.Tables[0].Rows[0]["CollegeName"].ToString();

        StringBuilder sbReceipt = new StringBuilder();
        sbReceipt.Append("<table width='700px' style='border-style: solid; border-color: Black'> <tr> <td align='center' colspan='2'> <table width='650px' border='0'> <tr><td align='center' colspan='2'></td> </tr><tr> <td colspan='2'></td> </tr> <tr> <td align='center' colspan='2' style='font-size: x-large; font-weight: bold'>Madhya Pradesh State Veterinary Council, </td> </tr> <tr><td align='center' colspan='2' style='font-size: x-large; font-weight: bold'>Bhopal </td> </tr> <tr> <td align='center' colspan='2'> <table width='100%' border='0' style='border-style: solid;'><tr><td align='right' width='60%'> <img height='100px' width='100px' src='../images/Vet-Council-Logo.bmp' /></td> <td align='center'> <img height='100px' width='100px' src='../Upload_Certificate/" + Picpath + "' /></td> </tr> <table width='100%'> <tr> <td align='center' colspan='2'></br></td> </tr> <tr><td align='center' colspan='2' style='font-size: x-large'><b>Provisional Registration Certificate</b></td> </tr> <tr> <td align='left'><table width='65%'> <tr> <td align='left'>Certificate No &nbsp;&nbsp;&nbsp;<span style='color: maroon;'>" + regNo + "</span></td> </tr> </table> </td> <td align='right'> <table width='80%'><tr><td align='left'>Date &nbsp;&nbsp;&nbsp;<span style='color: maroon;'> " + regDate + "</span></td>  </tr> </table></td> </tr> <tr> <td align='center' colspan='2'></br><table style ='border-width: medium; border-style: solid; height:300px' border='1' > <tr><td class='auto-style2'> Name (Male/Female)</td> <td class='auto-style2'>Father’s Name</td><td class='auto-style3'>Address</td> <td class='auto-style2'>Recognized Veterinary Science Qualification & Date of passing of Exam</td><td class='auto-style2'>Name of University/ College </td><td class='auto-style2'>Valid Up to </td></tr>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td >" + name + "<br/>( " + Gender + " ) </td>");
        sbReceipt.Append("<td>" + fathername + "</td>");
        sbReceipt.Append("<td>" + perAddress + "</td>");
        sbReceipt.Append("<td>B.V.SC.& A.H. / " + PassingYear + " </td>");
        sbReceipt.Append("<td>" + Univercity + "/" + Colg + "</td>");
        sbReceipt.Append("<td>" + validupto + "</td>");
        sbReceipt.Append("</tr>");
        sbReceipt.Append("</table></td> </tr> <tr><td colspan='2' align ='left'> </td>  </tr> <tr> <td colspan='2' align ='left'>Date:- &nbsp;&nbsp;&nbsp;<span style='color: maroon;'> " + regDate + "</span></td>   </tr><tr> <td colspan='2' align ='left' >Bhopal</td>  </tr> <tr> <td colspan='2' style='font-weight: bold'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Registrar</td> </tr><tr> <td colspan='2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; M.P.State Veterinary Council</td> </tr> <tr><td colspan='2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; Bhopal</br></td> </tr> <tr><td align='center' colspan='2'></br></td></tr> <tr> <td align='center' colspan='2'></br></td> </tr> <tr><td align='center' colspan='2'>  <hr /> </td> </tr> <tr> <td align='left' colspan='2' style='font-size: small;'>Note –</td> </tr> <tr> <td align='left' colspan='2' style='font-size:small;'>1- The Certificate holder is hereby authorized for training in recognized institute.</td> </tr> <tr> <td align='left' colspan='2' style='font-size: small;'>2- Original Provisional Registration Certificate has to be submitted at the time of final</td> </tr> <tr>  <td align='center' colspan='2'></br></td> </tr> <tr> <td align='center' colspan='2'></br></td> </tr>  </table>    </td> </tr> </table>  </td>  </tr> </table>");
        dvReceipt.InnerHtml = sbReceipt.ToString();
    }

    private void TransferInMP_Certificate(DataSet dsNew)
    {
        string Picpath = "";

        if (dsNew.Tables[0].Rows[0]["File3"].ToString() != "")
        {
            Picpath = dsNew.Tables[0].Rows[0]["File3"].ToString();

        }
        DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
        DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local
        localTime.ToString();


        string datetimeNow = localTime.ToString("dd/MM/yyyy");

        // string datetimeNow = Convert.ToDateTime(DateTime.Now, cult).ToString("dd/MM/yyyy");
        string regNo = dsNew.Tables[0].Rows[0]["RegiNo"].ToString();
        string regDate = getDate(dsNew.Tables[0].Rows[0]["RegiDate"].ToString());
        string district = dsNew.Tables[0].Rows[0]["PerDistrict"].ToString();
        string name = dsNew.Tables[0].Rows[0]["FName"].ToString() + " " + dsNew.Tables[0].Rows[0]["MName"].ToString() + " " + dsNew.Tables[0].Rows[0]["LName"].ToString();

        string ValidUpTo = getDate(dsNew.Tables[0].Rows[0]["Validupto"].ToString());

        string Rpt = "";
        StringBuilder sbReceipt = new StringBuilder();

        sbReceipt.Append("<table width='700px'   style='border-style:solid; border-color:Black' height='900px'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("<table width='650px' border='0' height='900px' >");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;'>");
        sbReceipt.Append("<b>FORM-X</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;'>");
        sbReceipt.Append("<b>[See rule 10(3)]</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4; font-size:xx-large'>");
        sbReceipt.Append("<b style='font-family: cooper;'>CERTIFICATE OF REGISTRATION</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td colspan='2'>");
        sbReceipt.Append("");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;font-size:small'>");
        sbReceipt.Append("<b>Madhya Pradesh State Veterinary Council established under Section 32</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4;font-size:small'>");
        sbReceipt.Append("<b>of the Indian Veterinary Council Act, 1984 (No. 52 of 1984)</b>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("<table width='550px' border='0'  style='border-style:solid;'>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'right' width='60%'>");
        sbReceipt.Append("<img height='150px' width='150px' src='../images/Vet-Council-Logo.bmp' />");
        sbReceipt.Append("</td>");
        sbReceipt.Append("<td align= 'right'>");
        sbReceipt.Append("<img height='150px' width='150px' src='../Upload_Certificate/" + Picpath + "' />");

        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");
        sbReceipt.Append("<table style='line-height: 1.5;font-size: 18px;'>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left'>");
        sbReceipt.Append("<table width= '65%' style='border-style:solid; border-color: #548DD4;border-radius: 7px;'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' style='color: #548DD4; font-weight:bold'>");
        sbReceipt.Append("No. MPSVC &nbsp;&nbsp;&nbsp;<span style='color:maroon;'>" + regNo + "</span>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");

        sbReceipt.Append("<td align= 'right'>");
        sbReceipt.Append("<table width= '100%' style='border-style:solid; border-color: #548DD4;border-radius: 7px;'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' style='color: #548DD4; font-weight:bold'>");
        sbReceipt.Append("Date &nbsp;&nbsp;&nbsp;<span style='color:maroon;'> " + regDate + "</span>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td colspan='2'>");
        sbReceipt.Append("<p style='text-align: justify;color: #548DD4;font-weight: bold;font-size: 20px;line-height: 1.6;margin: 5px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;This is to certify that Dr.<span style='color:maroon;'> " + name + "  </span> resident of <span style='color:maroon;'>" + district + ", Madhya Pradesh</span> have been duly registered   as   Registered Veterinary Practitioner and is entitled  to all the privileges granted to such practitioners under the Indian Veterinary Council Act, 1984 (No. 52 of 1984). This Registration has been effected with   the Madhya Pradesh State Veterinary Council,   under the said act.");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td colspan='2'>");
        sbReceipt.Append("<p style='text-align: justify;color: #548DD4;font-weight: bold;font-size: 20px;line-height: 1.6;margin: 5px;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In witness where of are herewith affixed the seal of the Madhya Pradesh State Veterinary Council and Signature of the Registrar of the said State Council.</p>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left'>");
        sbReceipt.Append("<table width= '65%' style='border-style:solid; border-color: #548DD4;border-radius: 7px;'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' style='color: #548DD4; font-weight:bold'>");
        sbReceipt.Append("Date of issue  &nbsp;&nbsp;&nbsp;<span style='color:maroon;'>" + datetimeNow + "</span>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");
        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left'>");
        sbReceipt.Append("<table width= '65%' style='border-style:solid; border-color: #548DD4;border-radius: 7px;'>");
        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' style='color: #548DD4; font-weight:bold'>");
        sbReceipt.Append("Valid Upto  &nbsp;&nbsp;&nbsp;<span style='color:maroon;'>" + ValidUpTo + "</span>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");
        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' >");
        sbReceipt.Append("</br>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'right' colspan='2' style='color: #548DD4; font-weight:bold' >");
        sbReceipt.Append("Signature of Registrar");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'center' colspan='2' style='color: #548DD4; '>");
        sbReceipt.Append("<hr/>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");



        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='font-size:small; color: #548DD4;'>");
        sbReceipt.Append("(This Certificate is the property of the Madhya Pradesh State Veterinary Council, and is issued to the Registered");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");

        sbReceipt.Append("<tr>");
        sbReceipt.Append("<td align= 'left' colspan='2' style='font-size:small; color: #548DD4;''>");
        sbReceipt.Append("Veterinary Practitioner mentioned above under rule 10(3) of the M.P. State Veterinary Council rules, 1993)");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");


        sbReceipt.Append("</table>");
        sbReceipt.Append("</td>");
        sbReceipt.Append("</tr>");
        sbReceipt.Append("</table>");

        dvReceipt.InnerHtml = sbReceipt.ToString();

    }
    private string getDate(string InComingDate)
    {
        string[] slipDate = InComingDate.Split("".ToCharArray());
        string FinalDate = slipDate[0];
        string[] FDate = FinalDate.Split("/".ToCharArray());
        string Date_Final = FDate[1] + "/" + FDate[0] + "/" + FDate[2];
        return Date_Final;

    }

}
