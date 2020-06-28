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

        #region BetaTestOneSearch
        private List<Product> ListProducts;
        private Product Selected;

        private Predicate<Product> PredicateProductBeta
        {
            get => new Predicate<Product>(P => P.ID.Equals(IDSelected));
        }

        private List<Product> GetListProducts()
        {
            return ListProducts = Product.GetListProducts(SearchFilter, true);
        }

        /// <summary>
        /// Fila activa del actual producto seleccionado
        /// </summary>
        public int SelectedRow
        {
            get => GridView_Products.CurrentRow.Index;
            set
            {
                if (GridView_Products.Rows.Count != 0)
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
            get => (int)GridView_Products[(int)Product.TableFields.ID, SelectedRow].Value;
        }

        private Product GetSelected()
        {
            return Selected = ListProducts.Find(PredicateProductBeta);
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

        //Todo: permitir actualización de la tabla desde otros formularios
        public void RefreshTable(bool TryConservateRow = false)
        {
            int Row = TryConservateRow ? SelectedRow : 0;
            GridView_Products.DataSource = GetListProducts();
            SelectedRow = Row;
        }

        private void DBTableProducts_SelectionChanged(object sender, EventArgs e)
        {
            SetProductProperties(GetSelected());
        }

        private void BTT_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                //Execute
                Selected.Updated += ProductActioned;
                Selected.Update();
            }
            catch (CrudListExceptions ex)
            {
                UI_ProductsProperties_Input.ExceptionsHandler(ex.ExceptionsList);
            }
            catch (MySqlException)
            {
                PremadeMessage.PMDataBaseException();
            }
            catch (Exception ex)
            {
                PremadeMessage.PMNotification(ex.Message);
            }
        }

        private void ProductActioned(object sender, string Action, int AffectedsRecords)
        {
            PremadeMessage.ObjectAction(sender, Action, AffectedsRecords);
            if (AffectedsRecords != 0)
            {
                RefreshTable();
            }
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
