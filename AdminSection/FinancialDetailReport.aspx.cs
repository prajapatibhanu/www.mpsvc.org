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
public partial class FinancialDetailReport : System.Web.UI.Page
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

        gridDetails.DataSource = api.ByProcedure("Proc_GetFinancialDetails", new string[] { "ReprotType", "Fromdate", "Todate" }, new string[] { ddlType.SelectedValue.ToString(), Fromdate, Todate }, "dataset");
        gridDetails.DataBind();
        btnPrint.Visible = true;
        gridDetails.AlternatingRowStyle.CssClass = "alt-row";
        myDT.Dispose();
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
        ColumnList.Add(new Columns("Registration Fees", "RegistrationFees"));
        ColumnList.Add(new Columns("Service Charge In Rs", "ServiceCharge"));
        ColumnList.Add(new Columns("Late Fees", "LateFees"));
        ColumnList.Add(new Columns("Re-Establishment Fees In Rs", "ReEstablishmentFees"));
        ColumnList.Add(new Columns("Transfer Fees In Rs", "Transferfees"));
        ColumnList.Add(new Columns("Total In Rs.", "TotalAmount"));
        ColumnList.Add(new Columns("Registration Valid upto", "Validupto"));
        ColumnList.Add(new Columns("Bank Name", "BankName"));
        ColumnList.Add(new Columns("Cheque No.", "ChequeNo"));
        ColumnList.Add(new Columns("Payment date", "ChequeDate"));
        ColumnList.Add(new Columns("Transaction Id", "TransactionId"));
        ColumnList.Add(new Columns("Payment Mode", "PaymentType"));
        ColumnList.Add(new Columns("Renewal Fees", "RenewalFees"));
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
        //String popScript;
        //Session["PrintSTR"] = HF_GridData.Value;
        //popScript = "<script language='javascript' type='text/javascript'>window.open('PrintHTMLReport.aspx','_blank','addressbar=yes,resizable=yes,toolbar=no,status=no,menubar=no,location=center,scrollbars=yes,width=950,height=520')</script>";
        //Page.RegisterStartupScript("popScript", popScript);

    }
 
}
