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
        Product SearchSelected
        {
            get
            {
                if (SearchValue != null)
                {
                    return Product.GetFromID((int)SearchValue);
                }
                else return null;
            }
        }

        Product PropertiesSelected
        {
            get => UI_SelectProductsProperties.GetObject();
        }

        DataTable ProductsDataTable
        {
            get => Product.GetTableProducts(Product.GetActiveFields(true), DataFieldSearch);
        }

        DataFieldTemplate DataFieldSearch
        {
            get => new DataFieldTemplate(Product.TableFields.Description,
                                             IB_Text_Search.InputValue,
                                             SQLValueType.SqlString);
        }

        object SearchValue
        {
            get => LB_SearchResults.SelectedValue;
        }
        #endregion

        private readonly List<Product> ListToAddProducts = new List<Product>();

        private void IB_Text_Search_InputChanged(object sender, EventArgs e)
        {
            RefreshSearchResults();
        }

        private void RefreshSearchResults()
        {
            LB_SearchResults.DisplayMember = Product.TableFields.Description.ToString();
            LB_SearchResults.ValueMember = Product.TableFields.ID.ToString();
            LB_SearchResults.DataSource = ProductsDataTable;
        }

        private void LB_SearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            if (SearchSelected != null)
            {
                LoadProperties(SearchSelected);
            }
            else UI_SelectProductsProperties.ClearProperties();
        }

        private void LoadProperties(Product P)
        {
            UI_SelectProductsProperties.inputBox_Text_Description.InputValue = P.Description;
            UI_SelectProductsProperties.inputBox_Combo_TradeMark.InputValue = P.TradeMark;
        }

        #region Add to list
        private void BTT_AddToList_Click(object sender, EventArgs e)
        {
            try
            {
                Product ToAdd = PropertiesSelected;
                if (!ListToAddProducts.Contains(ToAdd))
                {
                    AddToCart(ToAdd);
                }
                else throw new ProductRepeatedException();
            }
            catch (ProductRepeatedException ex)
            {
                UI_SelectProductsProperties.ExceptionsHandler(ex);
                PremadeMessage.PMNotification(ex.Message);
            }
        }

        private void AddToCart(Product P)
        {
            ListToAddProducts.Add(P);
            UI_SelectProductsProperties.ClearProperties();
            RefreshDataSource();
            IB_Text_Search.ResetInputValue();
            IB_Text_Search.Focus();
        }
        #endregion

        private void RefreshDataSource()
        {
            DGV_ProductsLoaded.DataSource = null;
            DGV_ProductsLoaded.DataSource = ListToAddProducts;
        }

        private void BTT_ConfirmPurchase_Click(object sender, EventArgs e)
        {
            Product.ListPurchased += Product_ListPurchased;
            Product.ListToPurchase(ListToAddProducts);
        }

        private void Product_ListPurchased(object sender, ECrud e)
        {
            PremadeMessage.PMNotification("Lista de compra procesada");
        }

        private void IB_Text_Search_Leave(object sender, EventArgs e)
        {
            if (SearchSelected == null)
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
            if (SearchSelected != null)
            {
                UI_SelectProductsProperties.inputBox_Numeric_Quantity.Focus();
            }
        }
    }
}
