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
            Qsql.InsertIntoSuccess += Qsql_InsertIntoSuccess;
        }

        #region Getters/Setters
        /// <summary>
        /// Obiene o establece la actual fila seleccionada
        /// </summary>
        private int SelectedRow
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
        /// Retorna el actual producto seleccionado del <see cref="DataGridView"/>
        /// </summary>
        private Product ListProductSelected
        {
            get
            {
                int Row = (int)Product.TableFields.ID;
                try
                {
                    int ID = (int)GridView_Products.Rows[SelectedRow].Cells[Row].Value;
                    return Product.GetFromID(ID);
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
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
                                             SQLValueType.SqlString, true);
            }
        }

        /// <summary>
        /// Obtiene la tabla de productos de la Base de Datos
        /// </summary>
        private DataTable TableProducts
        {
            get
            {
                return Product.GetTableProducts(Product.GetActiveFields(true),
                                                SearchFilter,
                                                true);
            }
        }

        /// <summary>
        /// Establece la fuente de datos del <see cref="DataGridView"/>
        /// </summary>
        private void SetGridDataSource(DataTable value)
        {
            GridView_Products.DataSource = value;
        }

        /// <summary>
        /// Establece el producto para mostrar al usuario sus propiedades detalladas en el formulario
        /// </summary>
        private void SetProductProperties(Product value)
        {
            if (value != null)
            {
                LBL_Title.Text = value.ToString();
            }
            UI_ProductsProperties_Input.SetObject(value);
        }
        #endregion

        private void RefreshTable(bool TryConservateRow = false)
        {

            int Row = TryConservateRow ? SelectedRow : 0;
            SetGridDataSource(TableProducts);
            SelectedRow = Row;
        }

        private void DBTableProducts_SelectionChanged(object sender, EventArgs e)
        {
            SetProductProperties(ListProductSelected);
        }

        private void BTT_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                //Execute
                //TODO: no actualiza reistros porque no se está adjuntando a la instancia el id aparentemente
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

        private void ProductActioned(object sender, ECrud e)
        {
            PremadeMessage.ObjectAction(sender, e.Action);
            RefreshTable(true);
        }

        private void BTT_Eliminar_Click(object sender, EventArgs e)
        {
            if (PremadeMessage.PMYesNo($"Se eliminará permanentemente {ListProductSelected}"))
            {
                Product Selected = ListProductSelected;
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
            Product Selected = ListProductSelected;
            Selected.Selled += ProductActioned;
            Selected.Sell(1);
        }

        //Invoke Refresh Table
        private void Qsql_InsertIntoSuccess() => RefreshTable();
        private void inBox_Buscar_TextChange(object sender, EventArgs e) => RefreshTable();
        private void Products_Load(object sender, EventArgs e) => RefreshTable();
    }
}
