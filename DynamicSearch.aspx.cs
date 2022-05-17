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

public partial class AdminSection_DynamicSearch : System.Web.UI.Page
{
    //DBAccess dbAccess = new DBAccess();
    DataTable myDT = new DataTable();
    //ClsVB objvb = new ClsVB();
    List<Columns> ColumnList = new List<Columns>();
    

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            fillCBL();
            callGrid();
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
    //private string showExperience(string doj)
    //{
    //    DateTime joiningDate = Convert.ToDateTime(doj);
    //    TimeSpan myTS = DateTime.Now.Subtract(joiningDate);
    //    int years = myTS.Days / 365;
    //    int month = (int)((myTS.Days % 365) / 30);
    //    int days = (int)((myTS.Days % 365) % 30);
    //    return years.ToString() + " Years" + " and " + month.ToString() + " Months";
    //}
    protected void fillGrid()
    {
        APIProcedure api = new APIProcedure();
        DataSet ds = api.ByDataSet(@"SELECT RegiNo,convert(varchar, RegiDate,106) as RegiDate
      ,FName+''+MName+''+LName as Fname,FatherName
      ,convert(varchar, DOB,106) as DOB,Gender,PresentOccuption
      ,ResAdd,ResCity,ResDistrict
      ,ResState,ResPinCode
      ,ProAdd,ProState,ProCity
      ,ProDistrict
      ,ProPinCode
      ,PerAdd
      ,PerCity
      ,PerDistrict
      ,PerState
      ,PerPinCode
      ,PreferedAdd
      ,PhoneNo
      ,MobileNo
      ,PreferedPhoneNo
      ,Fax
      ,Qualification
      ,PassingYear
      ,UniversityInstitute
      ,OtherQualification
      ,OthPassingYear
      ,OthUniversityInstitute
      ,EmailId
      ,MemStatus
      
  FROM tblNewRegistration where isNull(RegiNo,'') <> ''");
     gridDetails.DataSource = ds;
        gridDetails.DataBind();
        gridDetails.AlternatingRowStyle.CssClass = "alt-row";
        myDT.Dispose();
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
        ColumnList.Add(new Columns("Fname", "Fname"));
        ColumnList.Add(new Columns("Registration No", "RegiNo"));
        ColumnList.Add(new Columns("Registration Date", "RegiDate"));
        ColumnList.Add(new Columns("Father's Name", "FatherName"));
       
        ColumnList.Add(new Columns("Date of Birth", "DOB"));

        ColumnList.Add(new Columns("Gender", "Gender"));
        ColumnList.Add(new Columns("Phone No", "PhoneNo"));
        ColumnList.Add(new Columns("Mobile No", "MobileNo"));

        ColumnList.Add(new Columns("Fax No ", "Fax"));
        ColumnList.Add(new Columns("Email ID", "EmailId"));
        ColumnList.Add(new Columns("Residential Address", "ResAdd"));
        ColumnList.Add(new Columns("Residential City", "ResCity"));
        ColumnList.Add(new Columns("Residential District ", "ResDistrict"));

        ColumnList.Add(new Columns("Residential State", "ResState"));
        ColumnList.Add(new Columns("Residential PinCode", "ResPinCode"));
       
        ColumnList.Add(new Columns("Professional Address", "ProAdd"));
        ColumnList.Add(new Columns("Professional State", "ProState"));
        ColumnList.Add(new Columns("Professional City", "ProCity"));
        ColumnList.Add(new Columns("Professional District", "ProDistrict"));
        ColumnList.Add(new Columns("Professional PinCode", "ProPinCode"));
        //  
        ColumnList.Add(new Columns("Permanent Address", "PerAdd"));
        ColumnList.Add(new Columns("Permanent City", "PerCity"));
        ColumnList.Add(new Columns("Permanent District", "PerDistrict"));
        ColumnList.Add(new Columns("Permanent State", "PerState"));
        ColumnList.Add(new Columns("Permanent PinCode", "PerPinCode"));
        ColumnList.Add(new Columns("Sector", ""));
        ColumnList.Add(new Columns("Organization ", ""));
        ColumnList.Add(new Columns("Department ", ""));
        ColumnList.Add(new Columns("Designation ", ""));
       
      

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
}
