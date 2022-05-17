using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Helpers;
using System.Net;


public abstract class AbstApiDB
{

    public abstract void WriteLog(string _msg);
    public abstract string ReplaceVal(string msg);
    public abstract string base64Encode(string sData);
    public abstract string base64Decod(string sData);
    public abstract void ByText(string Query);
    public abstract void ByText(string Query, SqlConnection Con, SqlTransaction Tran);
    public abstract DataSet ByDataSet(string Query);
    public abstract void ResizeImage(Image ImageId, int ResizeWidth, int ResizeHeight);
    public abstract DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string OutPutParamName, out int TotRecord, string ByDataSetAlert);
    public abstract DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string ByDataSetAlert);
    public abstract DataTable ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string OutPutParamName, out int TotRecord, string ByDataTableAlert, string PassEmptyText);
    public abstract DataTable ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string ByDataTableAlert, string PassEmptyText);
    public abstract DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, SqlConnection Cnn, SqlTransaction Tran, string ByDataTableAlert);

    public abstract DataSet ByProcedure(string ProcedureName, string ByDataSetAlert);
    public abstract void ByProcedure(string ProcedureName, string[] SaveParameter, string[] SaveValues, Char BySaveAlert);
    public abstract void ByProcedure(string ProcedureName, string[] SaveParameter, string[] SaveValues, string byWithTranSaveAlert, SqlConnection Cnn, SqlTransaction Trans);

    public abstract string uploadFile(FileUpload FileUpload1, string FolderName, int FileSize);

}

public class APIProcedure : AbstApiDB
{

    public int _NewWidth, _NewHeight;
    public string _ErrorMessage;
    public string _mobileNo, _textMsg, _firstname, _bymemId, _verificationcode,
      _loginpwd, _transPwd, _amount, _description, _pinqty, _tomemID, _generateAPI,
        _FileName, _fileExt;
    public string FileExt
    {
        get
        {
            return _fileExt;
        }
        set
        {
            _fileExt = value;
        }
    }
    public string FullFileName
    {
        set
        {
            _FileName = value;
        }
        get
        {
            return _FileName;
        }
    }
    public string TomemID
    {
        get { return string.IsNullOrEmpty(_tomemID) ? "" : _tomemID; }
        set { _tomemID = value; }
    }
    public string Pinqty
    {
        get { return string.IsNullOrEmpty(_pinqty) ? "" : _pinqty; }
        set { _pinqty = value; }
    }
    public string Descrp
    {
        get { return string.IsNullOrEmpty(_description) ? "" : _description; }
        set { _description = value; }
    }
    public string Amt
    {
        get { return string.IsNullOrEmpty(_amount) ? "" : _amount; }
        set { _amount = value; }
    }

    public string TransPwd
    {
        get { return string.IsNullOrEmpty(_transPwd) ? "" : _transPwd; }
        set { _transPwd = value; }
    }
    public string Mobileno
    {
        get { return string.IsNullOrEmpty(_mobileNo) ? "" : _mobileNo; }
        set { _mobileNo = value; }
    }
    public string TextMsg
    {
        get { return string.IsNullOrEmpty(_textMsg) ? "" : _textMsg; }
        set { _textMsg = value; }
    }

    public string Firstname
    {
        get { return string.IsNullOrEmpty(_firstname) ? "" : _firstname; }
        set { _firstname = value; }
    }
    public string BymemId
    {
        get { return string.IsNullOrEmpty(_bymemId) ? "" : _bymemId; }
        set { _bymemId = value; }
    }
    public string Verificationcode
    {
        get { return string.IsNullOrEmpty(_verificationcode) ? "" : _verificationcode; }
        set { _verificationcode = value; }
    }
    public string Loginpwd
    {
        get { return string.IsNullOrEmpty(_loginpwd) ? "" : _loginpwd; }
        set { _loginpwd = value; }
    }
    public string GenerateAPI
    {
        get { return string.IsNullOrEmpty(_generateAPI) ? "" : _generateAPI; }
        set { _generateAPI = value; }
    }
    public int NewWidth
    {
        get { return _NewWidth; }
        set { _NewWidth = value; }
    }
    public int NewHeight
    {
        get { return _NewHeight; }
        set { _NewHeight = value; }
    }
    public string ErrorMessage
    {
        get { return _ErrorMessage; }
        set { _ErrorMessage = value; }
    }
    public string Cn;
    public DataSet ds;
    public DataTable dt;
    public SqlCommand cmd;

    public string getconnection
    {

        get
        {
            try
            {
                Cn = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString.ToString();
            }
            catch { ErrorMessage = "Yes"; throw new Exception("Please Provide Connection Object Name:Conn"); }

            return Cn;
        }
    }
    public override string uploadFile(FileUpload FileUpload1, string FolderName, int MaxFileSizeInKB)
    {
        string Msg = "", SaveSts = "";
        int NewFileSizeInKB = 0;
        try
        {
            // 1 MB= 1000 KB
            //1024 Bytes =1 KB
            //1 kb  =1*1024=1 MB 
            NewFileSizeInKB = MaxFileSizeInKB * 1024;
            StringBuilder sb = new StringBuilder();
            string dirName = HttpContext.Current.Server.MapPath("~/" + FolderName);
            Random Rnd = new Random();
            //Create Directory if not exist.
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            else
            {
                HttpFileCollection uploadFilCol = HttpContext.Current.Request.Files;

                for (int i = 0; i < uploadFilCol.Count; i++)
                {
                    HttpPostedFile file = uploadFilCol[i];
                    string fileExt = Path.GetExtension(file.FileName).ToLower();
                    //get file extention like .jpg
                    string FilePath = HttpContext.Current.Server.MapPath("~/" + file.FileName);
                    //Uploaded File Location 
                    int ContentFileSize = file.ContentLength;
                    if (NewFileSizeInKB > ContentFileSize || MaxFileSizeInKB == 0)
                    {
                        //File Extention
                        if (fileExt == ".jpg" || fileExt == ".pdf" || fileExt == ".gif" || fileExt == ".jpeg" || fileExt == ".png" || fileExt == ".doc" || fileExt == ".docx")
                        {
                            FileExt = fileExt;
                            FullFileName = System.DateTime.Now.ToString("ddMMyyyymmttss") + "_" + Convert.ToString(Rnd.Next(0, 99999)) + fileExt;
                            file.SaveAs(dirName + "/" + FullFileName);
                            //File save in to Directory With New Name.
                            //FileInfo fileinfo = new FileInfo(dirName + "\\" + FileFullName);
                            //sb.Append(dirName + "\\" + FileFullName + " :: <span style='Color:Green'>File Size : </span>" + fileinfo.Length * 1024 + " <span style='Color:Green'> bytes </span>" + fileinfo.Length / 1024 + " <span style='Color:Green'>KB </span>" + fileinfo.Length / 1024000 + " <span style='Color:Red'>MB </span></br>");
                            SaveSts = "Ok";
                        }
                        else
                        {
                            SaveSts = "NotOk";
                            Msg = "File format not recognised." + " jpg/jpeg/gif/png/pdf/doc/docx formats";
                        }
                    }
                    else
                    {
                        SaveSts = "NotOk";
                        Msg = "<span style='Color:Red'> Maximum length of uploading file should be " + MaxFileSizeInKB + " KB.</span>";
                    }
                }
                if (SaveSts == "Ok" || SaveSts == "NotOk")
                {
                    if (SaveSts == "NotOk")
                    {

                    }
                    else
                    {
                        Msg = SaveSts;
                    }
                }
                else
                {
                    Msg = "Please upload files.";
                }
            }
        }
        catch (Exception ex) { throw ex; }
        return Msg;
    }
    public override void WriteLog(string _msg)
    {
        string filepath;
        try
        {
            filepath = HttpContext.Current.Server.MapPath("~/exLog.html");
            if (System.IO.File.Exists(filepath))
            {
                using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath("~/exLog.html"), true))
                {

                    //for writing time....

                    writer.Write("<br>" + "[<b style='color:Red;'>Date:</b> " + DateTime.Now.ToLongDateString() + "] & [<b style='color:Red;'>Time:</b> " + DateTime.Now.ToLongTimeString() + "]");
                    writer.WriteLine();
                    //actual write cintent.....            

                    writer.Write("<br>" + ReplaceVal(_msg));
                    writer.WriteLine();
                    //For Record Sepration....            

                    writer.WriteLine("<br><hr>");
                    writer.Close();
                }
            }
            else
            {
                System.IO.StreamWriter sw = System.IO.File.CreateText(filepath);
                //for writing time....            

                using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath("~/exLog.html"), true))
                {

                    //for writing time....

                    writer.Write("[<b style='color:Red;'>Date:</b> " + DateTime.Now.ToLongDateString() + "] & [<b style='color:Red;'>Time:</b> " + DateTime.Now.ToLongTimeString() + "]");
                    writer.WriteLine();

                    //actual write cintent.....            

                    writer.Write("<br>" + ReplaceVal(_msg));
                    writer.WriteLine();
                    //For Record Sepration....            

                    writer.WriteLine("<br><hr>");
                    writer.Close();
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
    }
    public override string ReplaceVal(string msg)
    {
        string Msg = "";
        try
        {
            Msg = msg;
            Msg.Replace(@"at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj)
   at System.Data.SqlClient.TdsParser.Run(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj)
   at System.Data.SqlClient.SqlCommand.RunExecuteNonQueryTds(String methodName, Boolean async)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(DbAsyncResult result, String methodName, Boolean sendToPipe)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()", "").Replace("Error Msg :", "<b style='color:Red;'>Error Msg :</b>").Replace("Event Info :", "<b style='color:Red;'>Event Info :</b>");
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        return Msg;
    }
    public override string base64Encode(string sData)
    {
        try
        {
            byte[] encData_byte = new byte[sData.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }
    }
    public override string base64Decod(string sData)
    {
        string result = "";
        try
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(sData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            result = new String(decoded_char);
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        return result;
    }
    public override void ByText(string Query)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                using (SqlDataAdapter adp = new SqlDataAdapter())
                {
                    adp.SelectCommand = new SqlCommand(Query, cn);
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                //cmd.Dispose();
                ds.Dispose();
            }
        }

    }
    public override void ByText(string Query, SqlConnection Con, SqlTransaction Tran)
    {
        try
        {
            cmd = new SqlCommand(Query, Con, Tran);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally { cmd.Dispose(); }
    }
    public override DataSet ByDataSet(string Query)
    {
        try
        {

            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                using (SqlDataAdapter adp = new SqlDataAdapter())
                {
                    adp.SelectCommand = new SqlCommand(Query, cn);
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }

        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                //cmd.Dispose();
                ds.Dispose();
            }
        }
        return ds;
    }
    public override void ResizeImage(Image ImageId, int ResizeWidth, int ResizeHeight)
    {
        int width = 0, height = 0, newWidth = 0, newHeight = 0, wHStatus = 0, MainWidth = 0, MainHeight = 0;
        try
        {
            System.Drawing.Image image101 = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(ImageId.ImageUrl));
            width = image101.Width;
            height = image101.Height;

            if (width > height)
            { wHStatus = 1; }
            if (width < height)
            { wHStatus = 2; }
            if (width == height)
            { wHStatus = 3; }

            if (wHStatus == 1)
            {
                if (width > ResizeWidth)
                {
                    MainWidth = ResizeWidth;
                    double ratioX = (double)ResizeWidth / image101.Width;
                    double ratioY = (double)ResizeHeight / image101.Height;
                    double ratio1 = Math.Min(ratioX, ratioY);

                    newWidth = (int)(image101.Width * ratio1);
                    newHeight = (int)(image101.Height * ratio1);
                    MainHeight = newHeight;
                    //check = 1;
                }
                else
                {
                    MainWidth = width;

                    if (height > ResizeHeight)
                    {
                        double ratioX = (double)ResizeWidth / image101.Width;
                        double ratioY = (double)ResizeHeight / image101.Height;
                        double ratio1 = Math.Min(ratioX, ratioY);

                        newWidth = (int)(image101.Width * ratio1);
                        newHeight = (int)(image101.Height * ratio1);
                        MainHeight = newHeight;
                        MainWidth = newWidth;
                    }
                    else
                    {
                        MainHeight = height;
                    }
                }
            }
            if (wHStatus == 2)
            {
                if (height > ResizeHeight)
                {
                    double ratioX = (double)ResizeWidth / image101.Width;
                    double ratioY = (double)ResizeHeight / image101.Height;
                    double ratio1 = Math.Min(ratioX, ratioY);

                    newWidth = (int)(image101.Width * ratio1);
                    newHeight = (int)(image101.Height * ratio1);
                    MainHeight = newHeight;
                    MainWidth = newWidth;
                }
                else
                {
                    MainHeight = height;
                    if (width > ResizeWidth)
                    {
                        MainWidth = ResizeWidth;
                        double ratioX = (double)ResizeWidth / image101.Width;
                        double ratioY = (double)ResizeHeight / image101.Height;
                        double ratio1 = Math.Min(ratioX, ratioY);

                        newWidth = (int)(image101.Width * ratio1);
                        newHeight = (int)(image101.Height * ratio1);
                        MainHeight = newHeight;
                        //check = 1;
                    }
                    else
                    {
                        MainWidth = width;
                    }
                }
            }
            if (wHStatus == 3)
            {
                if (width > ResizeWidth)
                {
                    MainWidth = ResizeWidth;
                    double ratioX = (double)ResizeWidth / image101.Width;
                    double ratioY = (double)ResizeHeight / image101.Height;
                    double ratio1 = Math.Min(ratioX, ratioY);

                    newWidth = (int)(image101.Width * ratio1);
                    newHeight = (int)(image101.Height * ratio1);
                    MainHeight = newHeight;
                    //check = 1;
                }
                else
                {
                    MainWidth = width;

                    if (height > ResizeHeight)
                    {
                        double ratioX = (double)ResizeWidth / image101.Width;
                        double ratioY = (double)ResizeHeight / image101.Height;
                        double ratio1 = Math.Min(ratioX, ratioY);

                        newWidth = (int)(image101.Width * ratio1);
                        newHeight = (int)(image101.Height * ratio1);
                        MainHeight = newHeight;
                        MainWidth = newWidth;
                    }
                    else
                    {
                        MainHeight = height;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        NewWidth = MainWidth;
        NewHeight = MainHeight;

    }
    public override DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string OutPutParamName, out int TotRecord, string ByDataSetAlert)
    {
        try
        {

            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + OutPutParamName, SqlDbType.Int).Direction = ParameterDirection.Output;
                for (int i = 0; i < Parameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + Parameter[i].ToString(), Values[i].ToString());
                }
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }

        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
            //throw;
        }
        finally
        {

            if (ErrorMessage != "Yes")
            {
                ds.Dispose();
                cmd.Dispose();
            }
        }
        TotRecord = (int)cmd.Parameters["@" + OutPutParamName].Value;
        return ds;
    }
    public override DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string ByDataSetAlert)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Parameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + Parameter[i].ToString(), Values[i].ToString());
                }
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {

                ds.Dispose();
                cmd.Dispose();
            }
        }
        return ds;
    }
    public override DataTable ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string OutPutParamName, out int TotRecord, string ByDataTableAlert, string PassEmptyText)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + OutPutParamName, SqlDbType.Int).Direction = ParameterDirection.Output;
                for (int i = 0; i < Parameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + Parameter[i].ToString(), Values[i].ToString());
                }
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adp.Fill(dt);
                }
            }

        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
            //throw;
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                dt.Dispose();
                cmd.Dispose();
            }
        }
        TotRecord = (int)cmd.Parameters["@" + OutPutParamName].Value;
        return dt;
    }
    public override DataTable ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string ByDataTableAlert, string PassEmptyText)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Parameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + Parameter[i].ToString(), Values[i].ToString());
                }
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adp.Fill(dt);
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                dt.Dispose();
                cmd.Dispose();
            }
        }
        return dt;
    }

    public override DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, SqlConnection Cnn, SqlTransaction Tran, string ByDataTableAlert)
    {
        try
        {
            cmd = new SqlCommand(ProcedureName, Cnn, Tran);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Parameter.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + Parameter[i].ToString(), Values[i].ToString());
            }
            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                ds = new DataSet();
                adp.Fill(ds);
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                ds.Dispose();
                cmd.Dispose();
            }
        }
        return ds;
    }

    public override DataSet ByProcedure(string ProcedureName, string ByDataSetAlert)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                ds.Dispose();
                cmd.Dispose();
            }
        }
        return ds;
    }
    public override void ByProcedure(string ProcedureName, string[] SaveParameter, string[] SaveValues, Char BySaveAlert)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < SaveParameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + SaveParameter[i].ToString(), SaveValues[i].ToString());
                }
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                cmd.Dispose();
                ds.Dispose();
            }
        }

    }
    public override void ByProcedure(string ProcedureName, string[] SaveParameter, string[] SaveValues, string byWithTranSaveAlert, SqlConnection Cnn, SqlTransaction Trans)
    {
        try
        {
            cmd = new SqlCommand(ProcedureName, Cnn, Trans);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SaveParameter.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + SaveParameter[i].ToString(), SaveValues[i].ToString());
            }

            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                ds = new DataSet();
                adp.Fill(ds);
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            cmd.Dispose();
            ds.Dispose();

        }
    }
    public string SaveAlert(string Text)
    {
        return "<div class='alert alert-success'><strong>" + Text + "</strong></div>";
    }
    public string EmptyAlert(string Text)
    {
        return "<div class='alert alert-warning'><strong>" + Text + "</strong></div>";
    }
    public string ErrorAlert(string Text)
    {
        return "<div class='alert alert-danger'><strong>" + Text + "</strong></div>";
    }

    public void SendMailMPSVC(String UserId, String Subject, String Body, String filepath, string mobileNumber, string message)
    {   
        try
        {
            // For Sending SMS
            //Your authentication key
            string authKey = "97368Amvyj8EFL563df93f";
            //Multiple mobiles numbers separated by comma
            // mobileNumber = "";
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = "MPSVCI";
            //Your message to send, Add URL encoding here.
            message = HttpUtility.UrlEncode(message);

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "4");

            //Call Send SMS API
            string sendSMSUri = "http://bulksms.viasgroups.com/sendhttp.php";
            //Create HTTPWebrequest
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
            //Prepare and Add URL Encoded data
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(sbPostData.ToString());
            //Specify post method
            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/x-www-form-urlencoded";
            httpWReq.ContentLength = data.Length;
            using (Stream stream = httpWReq.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            //Get the response
            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();

            //Close the response
            reader.Close();
            response.Close();
        }
        catch (SystemException ex)
        {

        }


        // For Sending Mail

        string customerName = "Madhya Pradesh State Veterinary Council";
        string customerEmail = UserId;
        string subjectLine = Subject;
        string msg = Body;
        string fileAttachment = filepath;
        string with = "with";
        string errorMessage = "";

        // use a try catch block and send the email
        try
        {

            EmailService.EmailMPSVC MS = new EmailService.EmailMPSVC();
            string x =  MS.SendMail(customerEmail,subjectLine,fileAttachment,customerName,msg,with);
             //Initialize WebMail helper
            WebMail.SmtpServer = "mail.mpsvc.org";
            WebMail.SmtpPort = 25;
            WebMail.UserName = "veterinary@mpsvc.org";
            WebMail.Password = "@BHOPALVETY_123";
            WebMail.From = "veterinary@mpsvc.org";
            WebMail.EnableSsl = false;
                       
            //////Temporary service By Gmail
            //WebMail.SmtpServer = "smtp.gmail.com";
            //WebMail.SmtpPort = 587;
            //WebMail.UserName = "mpsvcveterinary@gmail.com";ok
            //WebMail.Password = "@BHOPALVETY_123";
            //WebMail.From = "mpsvcveterinary@gmail.com";
            //WebMail.EnableSsl = true;


            // Create array containing file name
            var filesList = new string[] { fileAttachment };

            // Attach file and send email
            //if (fileAttachment == null || fileAttachment == "")
            //{
            //    WebMail.Send(to: customerEmail,
            //    subject: subjectLine,
            //    body: "From: " + customerName + "\n\n  message: " + msg, replyTo: "mpsvc.bhopal@gmail.com");
            //    with = "without";
            //}
            //else
            //{
            //    WebMail.Send(to: customerEmail,
            //    subject: subjectLine,
            //    body: "From: " + customerName + "\n\n message: " + msg,
            //    filesToAttach: filesList, replyTo: "mpsvc.bhopal@gmail.com");
            //}
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }

    }

    public string CreateEmailBody(int i, string applicationno)
    {
        string emailBody = "";
        StringBuilder sbNew = new StringBuilder();
        if (i == 0)
        {
            sbNew.Append("<html><head><title>New Registration</title></head><body><p>Thanks for paying your fees 2025Rs. <br/><br/>Your request regarding New Registration/Transfer in M.P. is submitted to M.P.V.C.I. <br/> <br/>And your application no is:'" + applicationno + "' <br/><br/>You are required to be presented to M.P.V.C.I office within 15 days. Along with <br/><br/>following Original documents:-<br/><br/>1- Degree/P.D.C<br/><br/>2- 10th Marksheet (for Date of birth verification)<br/><br/>3- Domicile Certificate<b Style='Color:Green'><br/><br/>In case of queries feel free to contact:- <br/><br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/></b></p></body></html>");
        }
        if (i == 1)
        {
            sbNew.Append("<html><head><title>Renew Registration</title></head><body><p>Thanks, for paying your fees. <br/><br/>Your request regarding renewal of Registration is submitted to M.P.V.C.I.<br/><br/>You will get alert after generation of Your Certificate/document. <b Style='Color:Green'><br/>In case of queries feel free to contact:- <br/><br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/></b></p></body></html>");
        }
        if (i == 2)
        {
            //sbNew.Append("<html><head><title>Transfer Registration</title></head><body> <p>Your transfer registration request sent successfully. your registration no '" + applicationno + "'</p><p>Please carry following documents in original to MPSVC office within 15 days: </p>\n\n<p>1. Original registration certificate</p>\n<p>2. Original renewal certificate</p>\n<p>3. Original Id Card</p>\n<b Style='Color:Green'><p>MPSVC Address :</p>\n<p>Block No. 413,</p>\n<p>Vidhyanchal bhawan, Jail Road,</p>\n<p>Bhopal, MP.</p></b></body></html>");
            sbNew.Append("<html> 	<head> 		<title>Transfer Registration</title> 	</head> 	<body> 		<p>Your transfer registration request sent successfully. your registration no '" + applicationno + "'</p> 		<p>Please send following documents in original to MPSVC office within 15 days: </p> 		<p>1. Original registration certificate</p> 		<p>2. Original renewal certificate</p> 		<p>3. Original Id Card</p> 		<b Style='Color:Green'> 			<br/>In case of queries feel free to contact:- <br/> 			<br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/> 		</b> 	</body> </html>");
        }
        if (i == 3)
        {
            sbNew.Append("<html> 	<head> 		<title>New Registration</title> 	</head> 	<body> 		<p>Your Transfer in M.P. request sent successfully. your application no '" + applicationno + "'</p><p>Please carry following documents in original to MPSVC office within 15 days: </p><p>1. Domicile certificate of Parent State</p><p>2. Graduation degree/ PDC certificate</p><p>2. 10th marksheet</p><p>3.Applicant has to bring with him letter (NOC) of V.C.I. New Delhi and (NOC) from Concerning State.</p><p>4.Affidavit of 50 Rs with subject regarding his/her professional work in Madhya Pradesh while reporting to M.P.V.C.I. Bhopal office for verification.</p> 		<br/> 		<b Style='Color:Green'> 			<br/>In case of queries feel free to contact:- <br/> 			<br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/> 		</b> 	</body> </html>");
            //sbNew.Append("<html><head><title>New Registration</title></head><body> <p>Your new registration request sent successfully. your application no '" + applicationno + "'</p><p>Please carry following documents in original to MPSVC office within 15 days: </p>\n\n<p>1. Domicile certificate of Parent State</p>\n<p>2. Graduation degree/ PDC certificate</p>\n<p>3. 10th marksheet</p>\n <p>4.Applicant has to bring with him letter (NOC) of V.C.I. New Delhi</p>\n  <p>5.Affidavit of 50 Rs with subject regarding his/her professional work in Madhya Pradesh while reporting to M.P.V.C.I. Bhopal office for verification.</p>\n <b Style='Color:Green'><p>MPSVC Address :</p>\n<p>Block No. 413,</p>\n<p>Vidhyanchal bhawan, Jail Road,</p>\n<p>Bhopal, MP.</p></b></body></html>");
        }
        if (i == 4)
        {
            //sbNew.Append("<html><head><title>Duplicate Id Card Registration</title></head><body> <p>Your Duplicate Certificate Registration sent successfully. your application no '" + applicationno + "'</p><p>Please carry following documents in original to MPSVC office within 15 days: </p>\n\n<p>1. Domicile certificate</p>\n<p>2. Graduation degree/ PDC certificate</p>\n<p>3. 10th marksheet</p>\n<b Style='Color:Green'><p>MPSVC Address :</p>\n<p>Block No. 413,</p>\n<p>Vidhyanchal bhawan, Jail Road,</p>\n<p>Bhopal, MP.</p></b></body></html>");
            sbNew.Append("<html> 	<head> 		<title>Duplicate Id Card Registration</title> 	</head> 	<body> 		<p>Your Duplicate ID Card Request sent successfully. your application no '" + applicationno + "'</p> 		<b Style='Color:Green'> 			<br/>In case of queries feel free to contact:- <br/> 			<br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/> 		</b> 	</body> </html>");
        }
        if (i == 5)
        {
            //sbNew.Append("<html><head><title>Duplicate Certificate Registration</title></head><body> <p>Your Duplicate Certificate Registration request sent successfully. your application no '" + applicationno + "'</p><p>Please carry following documents in original to MPSVC office within 15 days: </p>\n\n<p>1. Domicile certificate</p>\n<p>2. Graduation degree/ PDC certificate</p>\n<p>3. 10th marksheet</p>\n<b Style='Color:Green'><p>MPSVC Address :</p>\n<p>Block No. 413,</p>\n<p>Vidhyanchal bhawan, Jail Road,</p>\n<p>Bhopal, MP.</p></b></body></html>");
            sbNew.Append("<html> 	<head> 		<title>Duplicate Certificate Registration</title> 	</head> 	<body> 		<p>Your Duplicate Certificate Request sent successfully. your application no '" + applicationno + "'</p> 		<b Style='Color:Green'> 			<br/>In case of queries feel free to contact:- <br/> 			<br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/> 		</b> 	</body> </html>");
        }
        if (i == 6)
        {
            //sbNew.Append("<html><head><title>Update Qualification Registration</title></head><body> <p>Your update qualification registration request sent successfully. your application no '" + applicationno + "'</p><p>Please carry following documents in original to MPSVC office within 15 days: </p>\n\n<p>1. Domicile certificate</p>\n<p>2. Graduation degree/ PDC certificate</p>\n<p>3. 10th marksheet</p>\n<b Style='Color:Green'><p>MPSVC Address :</p>\n<p>Block No. 413,</p>\n<p>Vidhyanchal bhawan, Jail Road,</p>\n<p>Bhopal, MP.</p></b></body></html>");
            sbNew.Append("<html> 	<head> 		<title>Update Qualification Registration</title> 	</head> 	<body> 		<p>Your update qualification request sent successfully. your application no '" + applicationno + "'</p> 		<b Style='Color:Green'> 			<br/>In case of queries feel free to contact:- <br/> 			<br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/> 		</b> 	</body> </html>");
        }
        if (i == 7)
        {
            //sbNew.Append("<html><head><title>Provisional Registration</title></head><body> <p>Your Provisional Registration request sent successfully. your application no '" + applicationno + "'</p></body></html>");
            sbNew.Append("<html> 	<head> 		<title>Provisional Registration</title> 	</head> 	<body> 		<p>Your Provisional Registration request sent successfully. your application no '" + applicationno + "'</p> 		<b Style='Color:Green'> 			<br/>In case of queries feel free to contact:- <br/> 			<br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/> 		</b> 	</body> </html>");
        }
        emailBody = sbNew.ToString();
        return emailBody;
    }

    public string CreateAdminEmailBody(int i, string registrationNo)
    {
        string emailBody = "";
        StringBuilder sbVerified = new StringBuilder();
        if (i == 0)
        {
            sbVerified.Append("<html><head><title>New Registration</title></head><body> <p>Your new registration is verified successfully. your registration no. :'" + registrationNo + "'</p></body></html>");
        }
        if (i == 1)
        {
            sbVerified.Append("<html><head><title>Renew Registration</title></head><body> <p>Your renew registration is verified successfully. your registration no '" + registrationNo + "'</p></body></html>");
        }
        if (i == 2)
        {
            sbVerified.Append("<html><head><title>Transfer Registration</title></head><body> <p>Your transfer registration is verified successfully. your registration no '" + registrationNo + "'</p></body></html>");
        }
        if (i == 3)
        {
            sbVerified.Append("<html><head><title>Transfer in MP Registration</title></head><body> <p>Your registration is verified successfully. your registration no '" + registrationNo + "'</p></body></html>");
        }
        if (i == 4)
        {
            sbVerified.Append("<html><head><title>Duplicate Id Card</title></head><body> <p>Your duplicate Id Card registration is verified successfully. your registration no. :'" + registrationNo + "'</p></body></html>");
        }
        if (i == 5)
        {
            sbVerified.Append("<html><head><title>Duplicate Certificate</title></head><body> <p>Your duplicate certificate registration is verified successfully. your registration no. :'" + registrationNo + "'</p></body></html>");
        }
        if (i == 6)
        {
            sbVerified.Append("<html><head><title>Update Qualification Registration</title></head><body> <p>Your update qualification registration is verified successfully. your registration no. :'" + registrationNo + "'</p></body></html>");
        }
        if (i == 7)
        {
            sbVerified.Append("<html><head><title>Provisional Registration</title></head><body> <p>Your Provisional registration is verified successfully. your registration no. :'" + registrationNo + "'</p></body></html>");
        }
        emailBody = sbVerified.ToString();
        return emailBody;
    }

    public string CreateAdminCertificateEmailBody(int i, string address)
    {
        string emailBody = "";
        StringBuilder sbVerified = new StringBuilder();
        if (i == 0)
        {
            sbVerified.Append("<html><head><title>New Registration</title></head><body><p>Your New registration Certificate has been generated successfully, <br/><br/>Please find attachment to download your certificate.<br/><br/>This certificate will be delivered to you at the postal address that you had mentioned while submission:-<br/><br/><b Style='Color:Green'>'" + address + "'</b><br/><b Style='Color:Green'><br/>In case of queries feel free to contact:- <br/><br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/></b></p></body></html>");
        }
        if (i == 1)
        {
            sbVerified.Append("<html><head><title>Renew Registration</title></head><body><p>Your Renewal registration Certificate has been generated successfully, <br/><br/>Please find attachment to download your certificate.<br/><br/>This certificate will be delivered to you at the postal address that you had mentioned while submission:-<br/><br/><b Style='Color:Green'>'" + address + "'</b><br/><b Style='Color:Green'><br/>In case of queries feel free to contact:- <br/><br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/></b></p></body></html>");
        }
        if (i == 2)
        {
            //sbVerified.Append("<html><head><title>Transfer Registration</title></head><body> <p>Your transfer registration certificate generate successfully, Please find attachment to download your certificate.</p>\n<p>This certificate is delivered in this address that you are mentioned below :</p><b Style='Color:Green'>\n '" + address + "'</b></body></html>");
            sbVerified.Append("<html><head><title>Transfer Registration</title></head><body><p>Your N.O.C. generated successfully, Please find attachment to download your certificate.</p><p>This certificate will be delivered to you at the postal address that you had mentioned while submission:-</p><b Style='Color:Green'>'" + address + "'</b><br/><b Style='Color:Green'><br/>In case of queries feel free to contact:- <br/><br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/></b></body></html>");
        }
        if (i == 3)
        {
            sbVerified.Append("<html><head><title>New Registration</title></head><body><p>Your New registration Certificate has been generated successfully, <br/><br/>Please find attachment to download your certificate.<br/><br/>This certificate will be delivered to you at the postal address that you had mentioned while submission:-<br/><br/><b Style='Color:Green'>'" + address + "'</b><br/><b Style='Color:Green'><br/>In case of queries feel free to contact:- <br/><br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/></b></p></body></html>");
        }
        if (i == 4)
        {
            //sbVerified.Append("<html><head><title>Duplicate Id Card Registration</title></head><body> <p>Your Duplicate Id Card registration certificate generate successfully, Please find attachment to download your certificate.</p>\n<p>This certificate is delivered in this address that you are mentioned below :</p><b Style='Color:Green'>\n '" + address + "'</b></body></html>");
            sbVerified.Append("<html> 	<head> 		<title>Duplicate Id Card</title> 	</head> 	<body> 		<p>Your Duplicate Id Card generate successfully,</p><p>This Duplicate Id Card will be delivered to you at the postal address that you had mentioned while submission:-</p><b Style='Color:Green'>'" + address + "'</b> 		<br/> 		<b Style='Color:Green'> 			<br/>In case of queries feel free to contact:- <br/> 			<br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/> 		</b> 	</body> </html>");
        }
        if (i == 5)
        {
            sbVerified.Append("<html><head><title>Duplicate Certificate Registration</title></head><body><p>Your Duplicate registration certificate generate successfully, Please find attachment to download your certificate.</p><p>This certificate will be delivered to you at the postal address that you had mentioned while submission:-</p><b Style='Color:Green'>'" + address + "'</b><br/><b Style='Color:Green'><br/>In case of queries feel free to contact:- <br/><br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/></b></body></html>");
            //sbVerified.Append("<html><head><title>Duplicate Certificate Registration</title></head><body> <p>Your Duplicate registration certificate generate successfully, Please find attachment to download your certificate.</p>\n<p>This certificate is delivered in this address that you are mentioned below :</p><b Style='Color:Green'>\n '" + address + "'</b></body></html>");
        }
        if (i == 7)
        {
            sbVerified.Append("<html><head><title>Provisional Registration</title></head><body><p>Your Provisional registration certificate generate successfully, Please find attachment to download your certificate.</p><p>This certificate will be delivered to you at the postal address that you had mentioned while submission:-</p><b Style='Color:Green'>'" + address + "'</b><br/><b Style='Color:Green'><br/>In case of queries feel free to contact:- <br/><br/>Madhya Pradesh State Veterinary Council,<br/>Kamdhenu Bhawan Campus,<br/>Vaishali Nagar<br/>Bhopal<br/>Phone :- (0755) 2670153 , 2771987<br/>Email:- mpsvc.bhopal@gmail.com<br/>Web Address www.mpsvc.org<br/></b></body></html>");
        }
        emailBody = sbVerified.ToString();
        return emailBody;
    }


    public string CreateMessageBody(int i, string applicationno)
    {
        string msgBody = "";
        StringBuilder sbNew = new StringBuilder();
        if (i == 0)
        {
            sbNew.Append("Your new registration request sent successfully. your application no '" + applicationno + "'");
        }
        if (i == 1)
        {
            sbNew.Append("Your renew registration request sent successfully. your registration no '" + applicationno + "'");
        }
        if (i == 2)
        {
            sbNew.Append("Your transfer registration request sent successfully. your registration no '" + applicationno + "'");
        }
        if (i == 3)
        {
            sbNew.Append("Your Transfer in MP registration request sent successfully. your application no '" + applicationno + "'");
        }
        if (i == 4)
        {
            sbNew.Append("Your Duplicate ID Card Request sent successfully. your application no '" + applicationno + "'");
        }
        if (i == 5)
        {
            sbNew.Append("Your Duplicate Certificate Registration request sent successfully. your application no '" + applicationno + "'");
        }
        if (i == 6)
        {
            sbNew.Append("Your update qualification registration request sent successfully. your application no '" + applicationno + "'");
        }
        if (i == 7)
        {
            sbNew.Append("Your provisional registration request sent successfully. your application no '" + applicationno + "'");
        }
        msgBody = sbNew.ToString();
        return msgBody;
    }
	//start done changes by bhanu on 19feb2022
	public string CreateSmSexpiry(int i, string registrationNo, string Validity)
    {
        string msgBody = "";
        StringBuilder sbsms = new StringBuilder();

        if(i == 0)
        {
            sbsms.Append("The Validity of your registration no " + registrationNo + " is going to expire on " + Validity + " kindly apply for renewal as soon as possible MPSVC Bhopal.");
        }
        msgBody = sbsms.ToString();
        return msgBody;
    }
	//end done changes by bhanu on 19feb2022
    public string CreateAdminMessageBody(int i, string registrationNo)
    {
        string msgBody = "";
        StringBuilder sbVerified = new StringBuilder();
        if (i == 0)
        {
            sbVerified.Append("Your new registration is verified successfully. your registration no. :'" + registrationNo + "'");
        }
        if (i == 1)
        {
            sbVerified.Append("Your renew registration is verified successfully. your registration no '" + registrationNo + "'");
        }
        if (i == 2)
        {
            sbVerified.Append("Your transfer registration is verified successfully. your registration no '" + registrationNo + "'");
        }
        if (i == 3)
        {
            sbVerified.Append("Your Transfer in MP registration is verified successfully. your registration no '" + registrationNo + "'");
        }
        if (i == 4)
        {
            sbVerified.Append("Your duplicate Id Card registration is verified successfully. your registration no. :'" + registrationNo + "'");
        }
        if (i == 5)
        {
            sbVerified.Append("Your duplicate certificate registration is verified successfully. your registration no. :'" + registrationNo + "'");
        }
        if (i == 6)
        {
            sbVerified.Append("Your update qualification registration is verified successfully. your registration no. :'" + registrationNo + "'");
        }
        if (i == 7)
        {
            sbVerified.Append("Your provisional registration is verified successfully. your registration no. :'" + registrationNo + "'");
        }
        msgBody = sbVerified.ToString();
        return msgBody;
    }

    public string CreateMessageCertificateEmailBody(int i, string address)
    {
        string msgBody = "";
        StringBuilder sbVerified = new StringBuilder();
        if (i == 0)
        {
            //sbVerified.Append("Your new registration certificate generated successfully, \n This certificate is delivered in this address that you are mentioned below :\n '" + address + "'");
            sbVerified.Append("Your MPSVC new Registration certificate has been generated successfully,\n\nyou will receive this certificate soon....");
            
        }
        if (i == 1)
        {
            //sbVerified.Append("Your renew registration certificate generate successfully, \n This certificate is delivered in this address that you are mentioned below :\n '" + address + "'");
            sbVerified.Append("Your MPSVC renew registration certificate has been generated successfully,\n\n you will receive this certificate soon....");
        }
        if (i == 2)
        {
            //sbVerified.Append("Your transfer registration certificate generate successfully, \n This certificate is delivered in this address that you are mentioned below :\n '" + address + "'");
            sbVerified.Append("Your Transfer registration certificate generate successfully, \n you will receive this certificate soon....");
        }
        if (i == 3)
        {
            //sbVerified.Append("Your new registration certificate generate successfully,\n This certificate is delivered in this address that you are mentioned below :\n '" + address + "'");
            sbVerified.Append("Your new registration certificate generate successfully,\n you will receive this certificate soon....");
        }
        if (i == 4)
        {
            //sbVerified.Append("Your Duplicate Id Card registration certificate generate successfully,\n This certificate is delivered in this address that you are mentioned below :\n '" + address + "'");
            sbVerified.Append("Your Duplicate Id Card generate successfully,\n you will receive this Id soon....");
        }
        if (i == 5)
        {
            //sbVerified.Append("Your Duplicate registration certificate generate successfully, \n This certificate is delivered in this address that you are mentioned below :\n '" + address + "'");
            sbVerified.Append("Your Duplicate registration certificate generate successfully, \n you will receive this certificate soon....");
        }
        msgBody = sbVerified.ToString();
        return msgBody;
    }

    //OTP code Send
    public string Send_OTP(string mobNo)
    {
        string str = "";
        string Msg = "";
        // declare array string to generate random string with combination of small,capital letters and numbers
        char[] charArr = "0123456789".ToCharArray();
        string strrandom = string.Empty;
        Random objran = new Random();
        int noofcharacters = 6;
        for (int i = 0; i < noofcharacters; i++)
        {
            //It will not allow Repetation of Characters
            int pos = objran.Next(1, charArr.Length);
            if (!strrandom.Contains(charArr.GetValue(pos).ToString()))
                strrandom += charArr.GetValue(pos);
            else
                i--;
        }
        str = strrandom;
        Msg = "Your OTP is " + str + " Please don't share with anyone.";
        sendOTPSms(mobNo, Msg);

        return str;
    }
    public void sendOTPSms(string mobileNumber, string message)
    {
        try
        {
            // For Sending SMS
            //Your authentication key
            string authKey = "97368Amvyj8EFL563df93f";
            //Multiple mobiles numbers separated by comma
           // mobileNumber = "";
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = "MPSVCI";
            //Your message to send, Add URL encoding here.
            message = HttpUtility.UrlEncode(message);

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "4");

            //Call Send SMS API
            string sendSMSUri = "http://bulksms.viasgroups.com/sendhttp.php";
            //Create HTTPWebrequest
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
            //Prepare and Add URL Encoded data
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(sbPostData.ToString());
            //Specify post method
            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/x-www-form-urlencoded";
            httpWReq.ContentLength = data.Length;
            using (Stream stream = httpWReq.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            //Get the response
            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();

            //Close the response
            reader.Close();
            response.Close();
        }
        catch (SystemException ex)
        {

        }
    }
}


