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

public partial class AdminSection_SectorMaster : System.Web.UI.Page
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
            api.ByText("insert into Tbl_Sectormaster(SectorName)values ('"+txtSearch.Text+"')");
            lblMsg.Text = "Data Saved successfully";
        }
        else
        { 
            api.ByText("update Tbl_Sectormaster set SectorName ='" + txtSearch.Text + "' where id ="+HiddenField1.Value+"");
            lblMsg.Text = "Data Updated successfully";

        } txtSearch.Text = "";
        HiddenField1.Value = "";

        fillgrd();
    }
    public void fillgrd()
    {
      DataSet dd=  api.ByDataSet("select * from Tbl_Sectormaster");
      GridView1.DataSource = dd.Tables[0];
      GridView1.DataBind();
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearch.Text = GridView1.SelectedRow.Cells[1].Text;
        HiddenField1.Value = GridView1.SelectedDataKey.Value.ToString();
    }

    // Private Sub SelectRowForDeletion(ByVal index As String)
    //    Dim dt2 As DataTable = ViewState("Data")
    //    'Dim dr2 As DataRow
    //    Dim eno As String
    //    'Dim eno As String = GridView1.Rows(GridView1.SelectedIndex)
    //    With GridView1.Rows(index)
    //        hdn.Value = CType(.FindControl("Hiddenvalue1"), HiddenField).Value
    //        eno = hdn.Value
    //        dt2.DefaultView.RowFilter = "ID<>'" & eno & "'"
    //        dt2 = dt2.DefaultView.ToTable()
    //        ViewState("Data") = dt2
    //        GridView1.DataSource = ViewState("Data")
    //        GridView1.DataBind()
    //    End With

    //End Sub
    //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    //LinkButton lnk = (LinkButton)sender;
    //    //string eno = lnk.CommandArgument;
    //    HiddenField1.Value = GridView1.DataKeyNames.ToString();
    //    api.ByText("Delete from Tbl_Sectormaster where id =" + HiddenField1.Value + "");
    //    lblMsg.Text = "Data Deleted successfully";
    //}
    //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if(e.CommandName=="Delete")
    //    {
    //        LinkButton lnk = sender as LinkButton;
    //        string eno = lnk.CommandArgument;
    //        api.ByText("Delete from Tbl_Sectormaster where id =" + eno + "");
    //        lblMsg.Text = "Data Deleted successfully";
    //    }
    //}

    protected void delete_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        //getting rowid
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        //Getting id
        int id = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
        api.ByText("Delete from Tbl_Sectormaster where id =" + id + "");
        lblMsg.Text = "Data Deleted successfully";
        fillgrd();
    }
}
