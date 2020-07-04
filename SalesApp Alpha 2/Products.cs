using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;

namespace SalesApp_Alpha_2
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        #region Properties

        private List<Product> ListProducts;
        private Product Selected;

        /// <summary>
        /// Obtiene el filtro de búsqueda empaquetado
        /// </summary>
        private DataFieldTemplate SearchFilter
        {
            get
            {
                return new DataFieldTemplate(Product.TableFields.Description,
                                             inBox_Buscar.InputText,
                                             SQLValueType.SqlString, SQLOperator.Like);
            }
        }

        /// <summary>
        /// Fila activa del actual producto seleccionado
        /// </summary>
        public int RowIndex
        {
            get
            {
                return GridView_Products.CurrentRow.Index;
            }
            set
            {
                if (GridView_Products.Rows.Count != 0 && value != -1)
                {
                    GridView_Products.Rows[value].Cells[0].Selected = true;
                }
            }
        }

        /// <summary>
        /// ID del actual producto seleccionado de la lista
        /// </summary>
        private int IDSelected
        {
            get => (int)GridView_Products[(int)Product.TableFields.ID, RowIndex].Value;
        }
        #endregion

        /// <summary>
        /// Procesa el método <see cref="List{T}.Find(Predicate{T})"/>
        /// </summary>
        /// <returns>El <see cref="Product"/> de la <see cref="ListProducts"/> que coincida con el <see cref="Product.ID"/></returns>
        private Product GetSelected()
        {
            return Selected = ListProducts.Find(P => P.ID.Equals(IDSelected));
        }

        /// <summary>
        /// Procesa y asigna el método <see cref="Product.GetProductListed(DataFieldTemplate, bool)"/>
        /// </summary>
        /// <returns><see cref="ListProducts"/></returns>
        private List<Product> GetListProducts()
        {
            return ListProducts = Product.GetProductListed(SearchFilter, true);
        }

        private void SetProductProperties(Product P)
        {
            if (P != null)
            {
                LBL_Title.Text = P.ToString();
            }
            UI_ProductsProperties_Input.SetObject(P);
        }

        public bool AnyRowActive
        {
            get => !(GridView_Products.CurrentRow is null);
        }

        //Todo: permitir actualización de la tabla desde otros formularios
        //Todo: Intentar mantener el registro de la anterior fila activa
        public void RefreshTable()
        {
            GridView_Products.DataSource = GetListProducts();
        }

        private void GridView_Products_SelectionChanged(object sender, EventArgs e)
        {
            SetProductProperties(GetSelected());
        }

        private void BTT_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                Product FromProperties = UI_ProductsProperties_Input.GetObject();
                FromProperties.Updated += ProductActioned;
                FromProperties.Update();
            }
            catch (Exception ex)
            {
                PremadeMessage.Notification(ex.Message);
            }
            
        }

        private void ProductActioned(object sender, string Action, int AffectedsRecords)
        {
            if (AffectedsRecords != 0) RefreshTable();
            PremadeMessage.ObjectAction(sender, Action, AffectedsRecords);
        }

        private void BTT_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (PremadeMessage.YesNo($"Se eliminará permanentemente {Selected}"))
                {
                    Selected.Deleted += ProductActioned;
                    Selected.Delete();
                }
            }
            catch (Exception ex)
            {
                PremadeMessage.Notification(ex.Message);
            }
        }

        private void BTT_Nuevo_Click(object sender, EventArgs e)
        {
            Products_New Create = new Products_New();
            Create.Show();
            Create.Added += Create_Added;
        }


        private void BTT_Vender_Click(object sender, EventArgs e)
        {
            Selected.Selled += ProductActioned;
            Selected.Sell(1);
        }

        //Invoke Refresh Table
        private void Create_Added(object sender, Product e) => RefreshTable();
        private void inBox_Buscar_TextChange(object sender, EventArgs e) => RefreshTable();
        private void Products_Load(object sender, EventArgs e) => RefreshTable();
    }
}
