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
        }

        #region Getters

        private List<Product> Products = new List<Product>();
        private readonly List<Product> ListToAddProducts = new List<Product>();

        private Product GetSelected()
        {
            return Products.Find(P => P.ID.Equals((int)LB_SearchResults.SelectedValue));
        }

        private Product GetModified()
        {
            return UI_SelectProductsProperties.GetObject();
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
        #endregion

        private void IB_Text_Search_InputChanged(object sender, EventArgs e) => Search();

        private void Search()
        {
            LB_SearchResults.DisplayMember = Product.TableFields.Description.ToString();
            LB_SearchResults.ValueMember = Product.TableFields.ID.ToString();
            LB_SearchResults.DataSource = GetProducts();
        }

        private void LB_SearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void LoadProperties()
        {
            Product Selected = GetSelected();
            if (Selected is null)
            {
                UI_SelectProductsProperties.ClearProperties();
            }
            else
            {
                UI_SelectProductsProperties.SemiSetObject(Selected);
            }
        }

        #region Add to list
        private void BTT_AddToList_Click(object sender, EventArgs e)
        {
            try
            {
                Product P = GetModified();
                if (ListToAddProducts.Contains(P))
                {
                    throw new ProductRepeatedException();
                }
                else
                {
                    AddToList(P);
                    
                }
            }
            catch (ProductException ex)
            {
                PremadeMessage.PMNotification(ex.Message);
            }
        }

        private void AddToList(Product P)
        {
            ListToAddProducts.Add(P);
            RefreshCart();
            IB_Text_Search.ResetInputValue();
            IB_Text_Search.Focus();
        }
        #endregion

        private void RefreshCart()
        {
            DGV_ProductsLoaded.DataSource = null;
            DGV_ProductsLoaded.DataSource = ListToAddProducts;
        }

        private void BTT_ConfirmPurchase_Click(object sender, EventArgs e)
        {
            Product.ListPurchased += Product_ListPurchased;
            Product.ListToPurchase(ListToAddProducts);
        }

        private void Product_ListPurchased(object sender, EventArgs e)
        {
            PremadeMessage.PMNotification("Lista de compras procesada correctamente", "Procesado");
        }

        private void IB_Text_Search_Leave(object sender, EventArgs e)
        {
            if (GetSelected() == null)
            {
                UI_SelectProductsProperties.SetFocus();
            }
        }

        private void BTT_New_Click(object sender, EventArgs e)
        {
            UI_SelectProductsProperties.ClearProperties();
            UI_SelectProductsProperties.SetFocus();
        }

        private void UI_SelectProductsProperties_Enter(object sender, EventArgs e)
        {
            if (GetSelected() != null)
            {
                UI_SelectProductsProperties.inputBox_Numeric_Quantity.Focus();
            }
        }
    }
}
