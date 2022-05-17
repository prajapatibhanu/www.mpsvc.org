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

public partial class AdminSection_CollegeMaster : System.Web.UI.Page
{
    APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dd1 = api.ByDataSet("select * from Tbl_UniversityMaster");
            DropDownList1.DataTextField = "UniversityName";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataSource = dd1.Tables[0];
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0,"Select..");
            fillgrd();
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (HiddenField1.Value == "")
        {
            api.ByText("insert into tbl_CollegeMaster(UniversityID,CollegeName)values ("+DropDownList1.SelectedValue+",'" + txtSearch.Text + "')");
            lblMsg.Text = "Data Saved successfully";
        }
        else
        {
            api.ByText("update tbl_CollegeMaster set UniversityID="+DropDownList1.SelectedValue+", CollegeName ='" + txtSearch.Text + "' where id =" + HiddenField1.Value + "");
            lblMsg.Text = "Data Updated successfully";

        } txtSearch.Text = "";
        DropDownList1.SelectedIndex = 0;
        HiddenField1.Value = "";

        fillgrd();
    }
    public void fillgrd()
    {
        DataSet dd = api.ByDataSet(@"SELECT     dbo.Tbl_UniversityMaster.UniversityName, dbo.tbl_CollegeMaster.ID, dbo.tbl_CollegeMaster.UniversityID, dbo.tbl_CollegeMaster.CollegeName
FROM         dbo.tbl_CollegeMaster INNER JOIN
                      dbo.Tbl_UniversityMaster ON dbo.tbl_CollegeMaster.UniversityID = dbo.Tbl_UniversityMaster.ID");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearch.Text = GridView1.SelectedRow.Cells[2].Text;
        DropDownList1.SelectedValue = ((HiddenField)GridView1.SelectedRow.FindControl("HiddenField2")).Value;
        HiddenField1.Value = GridView1.SelectedDataKey.Value.ToString();
    }

    protected void delete_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        //getting rowid
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        //Getting id
        int id = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
        api.ByText("Delete from tbl_CollegeMaster where id =" + id + "");
        lblMsg.Text = "Data Deleted successfully";
        fillgrd();
    }
}
