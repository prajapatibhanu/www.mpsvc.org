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

public partial class AdminSection_DesignationMaster : System.Web.UI.Page
{
    APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dd1 = api.ByDataSet("select * from tbl_OrganizationMaster");
            DropDownList1.DataTextField = "OrganaizationName";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataSource = dd1.Tables[0];
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Select..");
            fillgrd();
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (HiddenField1.Value == "")
        {
            api.ByText("insert into tbl_DesignationMaster(OrganaizationId,DepartmentID,DesinationName)values (" + DropDownList1.SelectedValue + ","+DropDownList2.SelectedValue+",'" + txtSearch.Text + "')");
            lblMsg.Text = "Data Saved successfully";
        }
        else
        {
            api.ByText("update tbl_DesignationMaster set OrganaizationId=" + DropDownList1.SelectedValue + ",DepartmentID=" + DropDownList2.SelectedValue + ", DesinationName ='" + txtSearch.Text + "' where id =" + HiddenField1.Value + "");
            lblMsg.Text = "Data Updated successfully";

        } txtSearch.Text = "";
        //DropDownList1.SelectedIndex = 0;
        //DropDownList2.SelectedIndex = 0;
        HiddenField1.Value = "";

        fillgrd();
    }
    public void fillgrd()
    {
        DataSet dd = api.ByDataSet(@"SELECT     dbo.tbl_OrganizationMaster.OrganaizationName, dbo.tbl_DesignationMaster.DesinationName, dbo.tbl_DesignationMaster.DepartmentID, 
                      dbo.tbl_DesignationMaster.OrganaizationId, dbo.tbl_DesignationMaster.ID, dbo.tbl_DepartmentMaster.DepaertmentName
FROM         dbo.tbl_DesignationMaster INNER JOIN
                      dbo.tbl_OrganizationMaster ON dbo.tbl_DesignationMaster.OrganaizationId = dbo.tbl_OrganizationMaster.Id INNER JOIN
                      dbo.tbl_DepartmentMaster ON dbo.tbl_OrganizationMaster.Id = dbo.tbl_DepartmentMaster.OrganaizationId AND 
                      dbo.tbl_DesignationMaster.DepartmentID = dbo.tbl_DepartmentMaster.ID");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearch.Text = GridView1.SelectedRow.Cells[2].Text;
        DropDownList1.SelectedValue = ((HiddenField)GridView1.SelectedRow.FindControl("HiddenField2")).Value;

        DataSet dd1 = api.ByDataSet("select * from tbl_DepartmentMaster where OrganaizationId=" + DropDownList1.SelectedValue + "");
        DropDownList1.DataTextField = "DepaertmentName";
        DropDownList1.DataValueField = "id";
        DropDownList1.DataSource = dd1.Tables[0];
        DropDownList1.DataBind();
        DropDownList2.SelectedValue = ((HiddenField)GridView1.SelectedRow.FindControl("HiddenField3")).Value;
        HiddenField1.Value = GridView1.SelectedDataKey.Value.ToString();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet dd1 = api.ByDataSet("select * from tbl_DepartmentMaster where OrganaizationId="+DropDownList1.SelectedValue+"");
        DropDownList2.DataTextField = "DepaertmentName";
        DropDownList2.DataValueField = "id";
        DropDownList2.DataSource = dd1.Tables[0];
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "Select..");
    }

    protected void delete_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        //getting rowid
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        //Getting id
        int id = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
        api.ByText("Delete from tbl_DesignationMaster where id =" + id + "");
        lblMsg.Text = "Data Deleted successfully";
        fillgrd();
    }
}
