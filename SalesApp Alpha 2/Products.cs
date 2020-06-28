using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SalesApp_Alpha_2.Properties;
using System.Collections.Generic;

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

        private Predicate<Product> PredicateID
        {
            get => new Predicate<Product>(P => P.ID.Equals(IDSelected));
        }

        private List<Product> GetListProducts()
        {
            return ListProducts = Product.GetListProducts(SearchFilter, true);
        }

        private int PreviousRowSelected(int Last)
        {
            return ListProducts.FindIndex(P => P.ID.Equals(Last));
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

        private Product GetSelected()
        {
            return Selected = ListProducts.Find(PredicateID);
        }

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
        #endregion

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
        //Todo: actualizar detalles del producto cuando se refresque la tabla
        public void RefreshTable()
        {
            int Previous = 0;
            if (AnyRowActive)
            {
                Previous = IDSelected;
            }
            GridView_Products.DataSource = GetListProducts();
            RowIndex = PreviousRowSelected(Previous);
        }

        private void GridView_Products_SelectionChanged(object sender, EventArgs e)
        {
            SetProductProperties(GetSelected());
        }

        private void BTT_Modificar_Click(object sender, EventArgs e)
        {
            Product FromProperties = UI_ProductsProperties_Input.GetObject();
            FromProperties.Updated += ProductActioned;
            FromProperties.Update();
        }

        private void ProductActioned(object sender, string Action, int AffectedsRecords)
        {
            if (AffectedsRecords != 0) RefreshTable();
            PremadeMessage.ObjectAction(sender, Action, AffectedsRecords);
        }

        private void BTT_Eliminar_Click(object sender, EventArgs e)
        {
            if (PremadeMessage.PMYesNo($"Se eliminará permanentemente {Selected}"))
            {
                Selected.Deleted += ProductActioned;
                Selected.Delete();
            }
        }

        private void BTT_Nuevo_Click(object sender, EventArgs e)
        {
            Form Create = new Products_New();
            Create.Show();
        }

        private void BTT_Vender_Click(object sender, EventArgs e)
        {
            Selected.Selled += ProductActioned;
            Selected.Sell(1);
        }

        //Invoke Refresh Table
        //TODO: añadir eventos de clase para refrescar la tabla al interactuar con la base de datos
        //private void Qsql_InsertIntoSuccess() => RefreshTable();
        private void inBox_Buscar_TextChange(object sender, EventArgs e) => RefreshTable();
        private void Products_Load(object sender, EventArgs e) => RefreshTable();
    }
}
