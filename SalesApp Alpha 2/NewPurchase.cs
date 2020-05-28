using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesApp_Alpha_2
{
    public partial class NewPurchase : Form
    {
        public NewPurchase()
        {
            InitializeComponent();
        }

        private DataFieldTemplate GetSearchDataField()
        {
            return new DataFieldTemplate(Product.TableFields.Description,
                                         InputBox_Search.InputValue,
                                         SQLValueType.SqlString);
        }

        private DataTable GetSearchResult()
        {
            return Product.GetTableProducts(Product.GetActiveFields(true), GetSearchDataField());
        }

        private Product GetProductSelected()
        {
            int i = ListBox_SearchResults.SelectedIndex;
            if (i != -1)
            {
                try
                {
                    return Product.GetFromID((int)ListBox_SearchResults.SelectedValue);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else return null;
        }

        private Product GetProductTyped()
        {
            return ProductProperties_Selected.GetObject();
        }

        private List<Product> products = new List<Product>();
        private LinkedList<Product> ToCartLinked = new LinkedList<Product>();

        private void InputBox_Search_InputChanged(object sender, EventArgs e)
        {
            RefreshSearchResults();
        }

        private void RefreshSearchResults()
        {
            ListBox_SearchResults.DataSource = null;
            ListBox_SearchResults.DataSource = GetSearchResult();
            ListBox_SearchResults.DisplayMember = Product.TableFields.Description.ToString();
            ListBox_SearchResults.ValueMember = Product.TableFields.ID.ToString();
        }

        private void BTT_AddToList_Click(object sender, EventArgs e)
        {
            Product typed = GetProductTyped();
            if (!IsLoaded(typed))
            {
                LinkedListNode<Product> linkedListNode = new LinkedListNode<Product>(typed);
                ToCartLinked.AddLast(linkedListNode);
            }
            else PremadeMessage.PMNotification("Producto ya existente");
            RefreshGridView();
        }

        private void RefreshGridView()
        {
            GridView_Products.DataSource = null;
            GridView_Products.DataSource = ToCartLinked;
        }

        private bool IsLoaded(Product p)
        {
            foreach (Product item in products)
            {
                if (p.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        private void ListBox_SearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product pp = GetProductSelected();
            if (pp != null)
            {
                ProductProperties_Selected.inputBox_Text_Description.InputValue = pp.Description;
                ProductProperties_Selected.inputBox_Combo_TradeMark.InputValue = pp.TradeMark;
            }
            else ProductProperties_Selected.ClearProperties();
        }
    }
}
