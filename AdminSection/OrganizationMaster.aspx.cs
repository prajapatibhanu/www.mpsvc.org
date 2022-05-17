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
using System.Data;

public partial class AdminSection_OrganizationMaster : System.Web.UI.Page
{
    APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrd();
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (HiddenField1.Value == "")
        {
            api.ByText("insert into tbl_OrganizationMaster(OrganaizationName)values ('" + txtSearch.Text + "')");
            lblMsg.Text = "Data Saved successfully";
        }
        else
        {
            api.ByText("update tbl_OrganizationMaster set OrganaizationName ='" + txtSearch.Text + "' where id =" + HiddenField1.Value + "");
            lblMsg.Text = "Data Updated successfully";

        } txtSearch.Text = "";
        HiddenField1.Value = "";

        fillgrd();
    }
    public void fillgrd()
    {
        DataSet dd = api.ByDataSet("select * from tbl_OrganizationMaster");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearch.Text = GridView1.SelectedRow.Cells[1].Text;
        HiddenField1.Value = GridView1.SelectedDataKey.Value.ToString();
    }

    protected void delete_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        //getting rowid
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        //Getting id
        int id = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
        api.ByText("Delete from tbl_OrganizationMaster where id =" + id + "");
        lblMsg.Text = "Data Deleted successfully";
        fillgrd();
    }   
}
