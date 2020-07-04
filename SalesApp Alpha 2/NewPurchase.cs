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
            //ListBox_SearchResults.DisplayMember = Product.TableFields.Description.ToString();
            //ListBox_SearchResults.ValueMember = Product.TableFields.ID.ToString();
        }
        
        private DataFieldTemplate GetConditional()
        {
            return new DataFieldTemplate(Product.TableFields.Description,
                                         InputBox_Search.InputValue,
                                         SQLValueType.SqlString);
        }

        private List<Product> GetSearchResult()
        {
            return SearchResults = Product.GetProductListed(GetConditional());
        }

        private object GetSelectedValue()
        {
            return ListBox_SearchResults.SelectedValue;
        }

        private Product GetProductSelected()
        {
            return SearchResults.Find(P => P.ID.Equals(GetSelectedValue()));
        }

        private Product GetFromPropertiesUI()
        {
            return ProductProperties_Selected.GetObject();
        }

        private List<Product> SearchResults = new List<Product>();
        private readonly List<Product> ShoppingCart = new List<Product>();

        private void InputBox_Search_InputChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            ListBox_SearchResults.DataSource = GetSearchResult();
            
        }

        private void BTT_AddToList_Click(object sender, EventArgs e)
        {
            Product typed = GetFromPropertiesUI();
            if (!ShoppingCart.Contains(typed))
            {
                ShoppingCart.Add(typed);
                RefreshGridView();
            }
            else PremadeMessage.Notification("Producto ya cargado");
            
        }

        private void RefreshGridView()
        {
            GridView_Products.DataSource = null;
            GridView_Products.DataSource = ShoppingCart;
        }

        private void ListBox_SearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product P = GetProductSelected();
            ProductProperties_Selected.SemiSetObject(P);
        }
    }
}
