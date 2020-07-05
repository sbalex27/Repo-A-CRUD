using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SalesApp_Alpha_2
{
    public partial class Purchases_New : Form
    {
        public Purchases_New()
        {
            InitializeComponent();
            LB_SearchResults.DisplayMember = Product.TableFields.Description.ToString();
            LB_SearchResults.ValueMember = Product.TableFields.ID.ToString();
        }

        #region Getters

        private List<Product> Products = new List<Product>();
        private readonly List<Product> ShoppingCart = new List<Product>();

        private object GetSelectedValue()
        {
            return LB_SearchResults.SelectedValue;
        }

        private Product GetSelected()
        {
            return Products.Find(P => P.ID.Equals(GetSelectedValue()));
        }

        List<Product> GetProducts()
        {
            return Products = Product.GetProductListed(GetConditional());
        }

        private DataFieldTemplate GetConditional()
        {
            return new DataFieldTemplate(Product.TableFields.Description,
                                         IB_Text_Search.InputValue,
                                         SQLValueType.SqlString,
                                         SQLOperator.Like);
        }

        private string TextSearch => IB_Text_Search.InputValue;
        private bool IsEmptyTextSearch => string.IsNullOrWhiteSpace(TextSearch);

        #endregion

        private void IB_Text_Search_InputChanged(object sender, EventArgs e)
        {
            Search();

            if (Products.Count.Equals(0))
            {
                ProductProperties.SemiSetObject(IsEmptyTextSearch ? null : new Product()
                {
                    Description = TextSearch
                });
            }
        }

        private void Search()
        {
            LB_SearchResults.SelectedIndex = -1;
            LB_SearchResults.DataSource = GetProducts();
        }

        private void LB_SearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void LoadProperties()
        {
            ProductProperties.SemiSetObject(GetSelected());
        }

        #region Add to list
        private void BTT_AddToList_Click(object sender, EventArgs e)
        {
            try
            {
                Product P = ProductProperties.GetObject();
                if (ShoppingCart.Contains(P)) throw new ProductRepeatedException(); 
                else AddToList(P);
            }
            catch (ProductException ex)
            {
                PremadeMessage.Notification(ex.Message);
            }
        }

        private void AddToList(Product P)
        {
            ShoppingCart.Add(P);
            ProductProperties.ClearProperties();
            RefreshCart();
            IB_Text_Search.ResetInputValue();
            IB_Text_Search.Focus();
        }
        #endregion

        private void RefreshCart()
        {
            DGV_ProductsLoaded.DataSource = new List<Product>(ShoppingCart);
        }

        private void BTT_ConfirmPurchase_Click(object sender, EventArgs e)
        {
            Product.ListPurchased += Product_ListPurchased;
            Product.ListToPurchase(ShoppingCart);
        }

        private void Product_ListPurchased(object sender, string e)
        {
            PremadeMessage.Notification(e);
            Close();
        }

        private void IB_Text_Search_Leave(object sender, EventArgs e)
        {
            if (GetSelected() is null)
            {
                if (IsEmptyTextSearch)
                {
                    ProductProperties.Box_Description.Focus();
                }
                else
                {
                    ProductProperties.Box_Trademark.Focus();
                }
            }
            else
            {
                ProductProperties.Box_Quantity.Focus();
            }
        }

        private void BTT_New_Click(object sender, EventArgs e)
        {
            ProductProperties.ClearProperties();
            ProductProperties.SetFocus();
        }

        //private void UI_SelectProductsProperties_Enter(object sender, EventArgs e)
        //{
        //    if (GetSelected() != null)
        //    {
        //        ProductProperties.inputBox_Numeric_Quantity.Focus();
        //    }
        //}
    }
}
