using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    APIProcedure obj = new APIProcedure();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        ds = obj.ByProcedure("SpComplainantRegistration", new string[] { "flag", "ComplaintID" }, new string[] { "8", "1" }, "dataset");

        
           
        

        StringBuilder Sb = new StringBuilder();

                Sb.Append("<div class='row'>");
                Sb.Append("<div class='col-md-12'>");
                    Sb.Append("<div class='table-responsive'>");
                    Sb.Append("<table class='table table-bordered' style='width: 80%'>");
                    
                    Sb.Append("</tr>");
                        Sb.Append("<tr>");
                            Sb.Append("<th>S.No.</th>");
                            Sb.Append("<th>FeedBack Date</th>");
                            Sb.Append("<th>FeedBack</th>");
                        Sb.Append("</tr>");
       if(ds != null && ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Sb.Append("<tr>");
            Sb.Append("<td>" + ds.Tables[0].Rows[i]["ComplaintChild_ID"] + "</td>");           
            Sb.Append("<td>" + ds.Tables[0].Rows[i]["Feedback"] + "</td>");           
            Sb.Append("<td>" + ds.Tables[0].Rows[i]["Complaint_Status"] + "</td>");           
            Sb.Append("</tr>");
          
        }
       }              
                           
         Sb.Append("</table>");
                    Sb.Append("</div>");
                Sb.Append("</div>");
            Sb.Append("</div>");
            strFeedback.InnerHtml = Sb.ToString();
    }
    protected void popup_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);


    }
}