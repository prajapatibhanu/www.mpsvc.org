using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Globalization;

public partial class AdminSection_PaymentDetailReport : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataTable myDT = new DataTable();
    List<Columns> ColumnList = new List<Columns>();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            btnPrint.Visible = false;
            // fillClient();
        }
    }

    private void fillCBL()
    {
        cblFields.RepeatColumns = 6;
        cblFields.RepeatDirection = RepeatDirection.Horizontal;
        cblFields.AutoPostBack = true;
        cblFields.DataSource = fillempFields();
        cblFields.DataValueField = "ColumnValue";
        cblFields.DataTextField = "ColumnName";
        cblFields.DataBind();

        foreach (ListItem item in cblFields.Items)
        {
            if (item.Value == "RegiNo" || item.Value == "Fname")
            {
                item.Selected = true;
                item.Enabled = false;
            }
        }
    }

    public void cblFields_SelectedIndexChanged(object sender, EventArgs e)
    {
        callGrid();
    }
    protected void fillGrid()
    {
        APIProcedure api = new APIProcedure();
        string Fromdate = Convert.ToDateTime(txtFDate.Text, cult).ToString("yyyy/MM/dd");
        string Todate = Convert.ToDateTime(txtToDate.Text, cult).ToString("yyyy/MM/dd");

        gridDetails.DataSource = api.ByProcedure("Proc_GetPhysicalDetails", new string[] { "ReprotType", "Fromdate", "Todate" }, new string[] { ddlType.SelectedValue.ToString(), Fromdate, Todate }, "dataset");
        gridDetails.DataBind();
        gridDetails.AlternatingRowStyle.CssClass = "alt-row";
        myDT.Dispose();
        btnPrint.Visible = true;
        if (gridDetails.Rows.Count <= 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "fnRpt", "alert('No record found');", true);
        }
    }

    private void callGrid()
    {
        bool flag = true;
        for (int i = 0; i < cblFields.Items.Count; i++)
        {
            if (cblFields.Items[i].Selected)
            {
                if (cblFields.Items[i].Value == "Qualification")
                {
                    TemplateField tfs = new TemplateField();
                    tfs.HeaderText = cblFields.Items[i].Text;
                    tfs.ItemTemplate = new CreateTemplate(ListItemType.Item, "Label");
                    gridDetails.Columns.Add(tfs);
                }

                else if (cblFields.Items[i].Value == "picture")
                {
                    TemplateField tfs = new TemplateField();
                    tfs.HeaderText = cblFields.Items[i].Text;
                    tfs.ItemTemplate = new CreateTemplate(ListItemType.Item, "Image");
                    gridDetails.Columns.Add(tfs);
                }
                else if (cblFields.Items[i].Value == "ResAdd")
                {

                    BoundField bfs1 = new BoundField();
                    bfs1.HeaderText = "Residential Address";
                    bfs1.DataField = "ResAdd";
                    gridDetails.Columns.Add(bfs1);

                    BoundField bfs2 = new BoundField();
                    bfs2.HeaderText = "Residential City/Town/Village";
                    bfs2.DataField = "ResCity";
                    gridDetails.Columns.Add(bfs2);

                    BoundField bfs3 = new BoundField();
                    bfs3.HeaderText = "Residential Post";
                    bfs3.DataField = "ResPost";
                    gridDetails.Columns.Add(bfs3);

                    BoundField bfs4 = new BoundField();
                    bfs4.HeaderText = "Residential Block/Tehsil";
                    bfs4.DataField = "ResTehsil";
                    gridDetails.Columns.Add(bfs4);

                    BoundField bfs5 = new BoundField();
                    bfs5.HeaderText = "Residential District";
                    bfs5.DataField = "ResDistrict";
                    gridDetails.Columns.Add(bfs5);

                    BoundField bfs6 = new BoundField();
                    bfs6.HeaderText = "Residential State ";
                    bfs6.DataField = "ResState";
                    gridDetails.Columns.Add(bfs6);

                    BoundField bfs7 = new BoundField();
                    bfs7.HeaderText = "Residential Pin Code";
                    bfs7.DataField = "ResPinCode";
                    gridDetails.Columns.Add(bfs7);

                }
                else if (cblFields.Items[i].Value == "ProAdd")
                {

                    BoundField bfs1 = new BoundField();
                    bfs1.HeaderText = "Professional Address";
                    bfs1.DataField = "ProAdd";
                    gridDetails.Columns.Add(bfs1);

                    BoundField bfs2 = new BoundField();
                    bfs2.HeaderText = "Professional City/Town/Village";
                    bfs2.DataField = "ProCity";
                    gridDetails.Columns.Add(bfs2);

                    BoundField bfs3 = new BoundField();
                    bfs3.HeaderText = "Professional Post";
                    bfs3.DataField = "ProPost";
                    gridDetails.Columns.Add(bfs3);

                    BoundField bfs4 = new BoundField();
                    bfs4.HeaderText = "Professional Block/Tehsil";
                    bfs4.DataField = "ProTehsil";
                    gridDetails.Columns.Add(bfs4);

                    BoundField bfs5 = new BoundField();
                    bfs5.HeaderText = "Professional District";
                    bfs5.DataField = "ProDistrict";
                    gridDetails.Columns.Add(bfs5);

                    BoundField bfs6 = new BoundField();
                    bfs6.HeaderText = "Professional State ";
                    bfs6.DataField = "ProState";
                    gridDetails.Columns.Add(bfs6);

                    BoundField bfs7 = new BoundField();
                    bfs7.HeaderText = "Professional Pin Code";
                    bfs7.DataField = "ProPinCode";
                    gridDetails.Columns.Add(bfs7);

                }
                else if (cblFields.Items[i].Value == "PerAdd")
                {

                    BoundField bfs1 = new BoundField();
                    bfs1.HeaderText = "Permanent Address";
                    bfs1.DataField = "PerAdd";
                    gridDetails.Columns.Add(bfs1);

                    BoundField bfs2 = new BoundField();
                    bfs2.HeaderText = "Permanent City/Town/Village";
                    bfs2.DataField = "PerCity";
                    gridDetails.Columns.Add(bfs2);

                    BoundField bfs3 = new BoundField();
                    bfs3.HeaderText = "Permanent Post";
                    bfs3.DataField = "PerPost";
                    gridDetails.Columns.Add(bfs3);

                    BoundField bfs4 = new BoundField();
                    bfs4.HeaderText = "Permanent Block/Tehsil";
                    bfs4.DataField = "PerTehsil";
                    gridDetails.Columns.Add(bfs4);

                    BoundField bfs5 = new BoundField();
                    bfs5.HeaderText = "Permanent District";
                    bfs5.DataField = "PerDistrict";
                    gridDetails.Columns.Add(bfs5);

                    BoundField bfs6 = new BoundField();
                    bfs6.HeaderText = "Permanent State ";
                    bfs6.DataField = "PerState";
                    gridDetails.Columns.Add(bfs6);

                    BoundField bfs7 = new BoundField();
                    bfs7.HeaderText = "Permanent Pin Code";
                    bfs7.DataField = "PerPinCode";
                    gridDetails.Columns.Add(bfs7);

                }
                else if (cblFields.Items[i].Value == "PrefAdd")
                {
                    
                    BoundField bfs1 = new BoundField();
                    bfs1.HeaderText = "Preferred Address";
                    bfs1.DataField = "PrefAdd";
                    gridDetails.Columns.Add(bfs1);

                    BoundField bfs2 = new BoundField();
                    bfs2.HeaderText = "Preferred City/Town/Village";
                    bfs2.DataField = "PrefCity";
                    gridDetails.Columns.Add(bfs2);

                    BoundField bfs3 = new BoundField();
                    bfs3.HeaderText = "Preferred Post";
                    bfs3.DataField = "PrefPost";
                    gridDetails.Columns.Add(bfs3);

                    BoundField bfs4 = new BoundField();
                    bfs4.HeaderText = "Preferred Block/Tehsil";
                    bfs4.DataField = "PrefTehsil";
                    gridDetails.Columns.Add(bfs4);

                    BoundField bfs5 = new BoundField();
                    bfs5.HeaderText = "Preferred District";
                    bfs5.DataField = "PrefDistrict";
                    gridDetails.Columns.Add(bfs5);

                    BoundField bfs6 = new BoundField();
                    bfs6.HeaderText = "Preferred State ";
                    bfs6.DataField = "PrefState";
                    gridDetails.Columns.Add(bfs6);

                    BoundField bfs7 = new BoundField();
                    bfs7.HeaderText = "Preferred Pin Code";
                    bfs7.DataField = "PrefPinCode";
                    gridDetails.Columns.Add(bfs7);

                }
                else
                {
                    BoundField bfs = new BoundField();
                    bfs.HeaderText = cblFields.Items[i].Text;
                    bfs.DataField = cblFields.Items[i].Value;
                    gridDetails.Columns.Add(bfs);


                }

            }
        }
        fillGrid();
    }

    private List<Columns> fillempFields()
    {
        ColumnList.Add(new Columns("Type Of Registration", "Apptype"));
        ColumnList.Add(new Columns("Name", "Fname"));
        ColumnList.Add(new Columns("Registration No", "RegiNo"));
        ColumnList.Add(new Columns("Registration Date", "RegiDate"));
        ColumnList.Add(new Columns("Father's Name", "FatherName"));
        ColumnList.Add(new Columns("Date of Birth", "DOB"));
        ColumnList.Add(new Columns("Gender", "Gender"));
        ColumnList.Add(new Columns("Phone No", "PhoneNo"));
        ColumnList.Add(new Columns("Mobile No", "MobileNo"));
        ColumnList.Add(new Columns("Fax No ", "Fax"));
        ColumnList.Add(new Columns("Email ID", "EmailId"));

        ColumnList.Add(new Columns("University", "University1"));
        ColumnList.Add(new Columns("College", "CollegeID1"));
        ColumnList.Add(new Columns("Year of Passing", "Year1"));



        ColumnList.Add(new Columns("Sector", "PresentOccuption"));
        ColumnList.Add(new Columns("Orgnaization", "OrganizationName"));
        ColumnList.Add(new Columns("Department", "DepartmentName"));
        ColumnList.Add(new Columns("Designation", "DesignationName"));
        ColumnList.Add(new Columns("Date of last renewal", "dateofverify"));
        ColumnList.Add(new Columns("Registration Valid upto", "Validupto"));



        ColumnList.Add(new Columns("Residential Address", "ResAdd"));

        //ColumnList.Add(new Columns("Residential City", "ResCity"));
        //ColumnList.Add(new Columns("Residential District ", "ResDistrict"));
        //ColumnList.Add(new Columns("Residential PinCode", "ResPinCode"));

        ColumnList.Add(new Columns("Professional Address", "ProAdd"));

        //ColumnList.Add(new Columns("Professional City", "ProCity"));
        //ColumnList.Add(new Columns("Professional District", "ProDistrict"));
        //ColumnList.Add(new Columns("Professional PinCode", "ProPinCode"));

        ColumnList.Add(new Columns("Permanent Address", "PerAdd"));

        //ColumnList.Add(new Columns("Permanent City", "PerCity"));
        //ColumnList.Add(new Columns("Permanent District", "PerDistrict"));
        //ColumnList.Add(new Columns("Permanent PinCode", "PerPinCode"));

        ColumnList.Add(new Columns("Preferred Address", "PrefAdd"));

        if (ddlType.SelectedValue == "2")
        {
            ColumnList.Add(new Columns("Transfer State", "Transferstateid"));
        }

        return ColumnList;
    }

    public class CreateTemplate : ITemplate
    {
        ListItemType listItem;
        string control;
        public CreateTemplate()
        {

        }

        public CreateTemplate(ListItemType item)
        {
            listItem = item;
        }

        public CreateTemplate(ListItemType item, string controlType)
        {
            listItem = item;
            control = controlType;
        }

        public void InstantiateIn(System.Web.UI.Control Container)
        {
            if (listItem == ListItemType.Item && control == "Image")
            {
                Image empImage = new Image();
                empImage.Width = 64;
                empImage.Height = 64;
                empImage.Style.Add("vertical-align", "text-top");
                empImage.DataBinding += new EventHandler(empImage_DataBinding);
                Container.Controls.Add(empImage);
            }
            else if (listItem == ListItemType.Item && control == "Label")
            {
                Label empLabel = new Label();
                empLabel.DataBinding += new EventHandler(empLabel_DataBinding);
                Container.Controls.Add(empLabel);
            }
            else if (listItem == ListItemType.Item && control == "DropDown")
            {
                DropDownList empDDL = new DropDownList();
                Container.Controls.Add(empDDL);
            }
        }

        public void empImage_DataBinding(object sender, EventArgs e)
        {
            Image imageData = (Image)sender;
            GridViewRow container = (GridViewRow)imageData.NamingContainer;
            object dataValue = DataBinder.GetPropertyValue(container.DataItem, "picture");
            if (dataValue != DBNull.Value)
            {
                imageData.ImageUrl = dataValue.ToString();//(File.Exists(Server.MapPath("../admin/images/") + dataValue.ToString()) ? dataValue.ToString() : "No_Image.gif");
            }
        }

        public void empLabel_DataBinding(object sender, EventArgs e)
        {
            Label lblData = (Label)sender;
            GridViewRow container = (GridViewRow)lblData.NamingContainer;
            object dataValue = DataBinder.GetPropertyValue(container.DataItem, "Qualification");

            if (dataValue != DBNull.Value)
            {
                lblData.Text = dataValue.ToString();
            }
        }
    }

    public class Columns
    {
        string _ColumnName, _ColumnValue;
        public Columns()
        {

        }

        public Columns(string name, string value)
        {
            _ColumnName = name;
            _ColumnValue = value;
        }

        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }

        public string ColumnValue
        {
            get { return _ColumnValue; }
            set { _ColumnValue = value; }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        fillCBL();
        callGrid();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //String popScript  ;
        //Session["PrintSTR"] = HF_GridData.Value;
        //popScript = "<script language='javascript' type='text/javascript'>window.open('PrintHTMLReport.aspx','_blank','addressbar=yes,resizable=yes,toolbar=no,status=no,menubar=no,location=center,scrollbars=yes,width=950,height=520')</script>";
        //Page.RegisterStartupScript("popScript", popScript);

    }
}
