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
        private List<Product> ListProducts = new List<Product>();

        private Predicate<Product> PredicateProductBeta
        {
            get => new Predicate<Product>(P => P.ID.Equals(IDSelected));
        }

        private List<Product> GetListProducts()
        {
            ListProducts = Product.GetListProducts(SearchFilter);
            return ListProducts;
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

        private Product Selected
        {
            get => ListProducts.Find(PredicateProductBeta);
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

        #region Getters/Setters Antiguos

        ///// <summary>
        ///// Retorna el actual producto seleccionado del <see cref="DataGridView"/>
        ///// </summary>
        //private Product ListProductSelected
        //{
        //    get
        //    {
        //        int Row = (int)Product.TableFields.ID;
        //        try
        //        {
        //            int ID = (int)GridView_Products.Rows[SelectedRow].Cells[Row].Value;
        //            return Product.GetFromID(ID);
        //        }
        //        catch (NullReferenceException)
        //        {
        //            return null;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Obtiene la tabla de productos de la Base de Datos
        ///// </summary>
        //private DataTable TableProducts
        //{
        //    get
        //    {
        //        return Product.GetTableProducts(Product.GetActiveFields(true),
        //                                        SearchFilter,
        //                                        true);
        //    }
        //}

        /// <summary>
        /// Establece la fuente de datos del <see cref="DataGridView"/>
        /// </summary>
        private void SetGridDataSource(List<Product> value)
        {
            GridView_Products.DataSource = value;
        }

        /// <summary>
        /// Establece el producto para mostrar al usuario sus propiedades detalladas en el formulario
        /// </summary>
        private void SetProductProperties(Product P)
        {
            if (P != null)
            {
                LBL_Title.Text = P.ToString();
            }
            UI_ProductsProperties_Input.SetObject(P);
        }
        #endregion

        //Todo: permitir actualización de la tabla desde otros formularios
        public void RefreshTable(bool TryConservateRow = false)
        {
            int Row = TryConservateRow ? SelectedRow : 0;
            SetGridDataSource(GetListProducts());
            SelectedRow = Row;
        }

        private void DBTableProducts_SelectionChanged(object sender, EventArgs e)
        {
            SetProductProperties(Selected);
        }

        private void BTT_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                //Execute
                Product Selected = UI_ProductsProperties_Input.GetObject();
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
                Product P = Selected;
                P.Deleted += ProductActioned;
                P.Delete();
            }
        }

        private void BTT_Nuevo_Click(object sender, EventArgs e)
        {
            Form Create = new Products_New();
            Create.Show();
        }

        private void BTT_Vender_Click(object sender, EventArgs e)
        {
            Product P = Selected;
            P.Selled += ProductActioned;
            P.Sell(1);
        }

        //Invoke Refresh Table
        //TODO: añadir eventos de clase para refrescar la tabla al interactuar con la base de datos
        //private void Qsql_InsertIntoSuccess() => RefreshTable();
        private void inBox_Buscar_TextChange(object sender, EventArgs e) => RefreshTable();
        private void Products_Load(object sender, EventArgs e) => RefreshTable();
    }
}
