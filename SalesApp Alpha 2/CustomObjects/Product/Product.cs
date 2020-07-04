using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace SalesApp_Alpha_2
{
    /// <summary>
    /// Objeto de tipo Producto con métodos de compra/venta
    /// </summary>
    public class Product : CObjectCRUD<Product.TableFields>, INegotiable
    {
        #region Constructor and Properties
        /// <summary>
        /// Constructor de un producto vacío
        /// </summary>
        public Product() { }

        /// <summary>
        /// Constructor de un producto con un ID existente
        /// </summary>
        /// <param name="ID">Identificador de producto</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Product(int ID)
        {
            if (ID != 0)
            {
                this.ID = ID;
            }
            else throw new ArgumentOutOfRangeException(nameof(ID));
        }

        private string description;
        private string trademark;
        private int quantity;
        private double price;

        public int ID { get; private set; }

        public string Description
        {
            get => description;
            set => description = string.IsNullOrWhiteSpace(value) ? throw new ProductObligatoryFieldException(TableFields.Description) : value;
        }
        public string TradeMark
        {
            get => trademark;
            set => trademark = string.IsNullOrWhiteSpace(value) ? throw new ProductObligatoryFieldException(TableFields.TradeMark) : value;
        }
        public int Quantity
        {
            get => quantity;
            set => quantity = value < 0 ? throw new ProductQuantityException() : value;
        }
        public double Price
        {
            get => price;
            set => price = value <= 0 ? throw new ProductInvalidPriceException() : value;
        }

        
        #endregion

        #region Override virtual object
        public override string ToString()
        {
            return $"{Description} - {TradeMark}";
        }

        public override bool Equals(object obj)
        {
            return obj is Product p
                && p.Description == Description
                && p.TradeMark == TradeMark;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Exclusive Statics
        /// <summary>
        /// Enumeradores de campos del objeto producto
        /// </summary>
        public enum TableFields
        {
            ID, Description, TradeMark, Quantity, Price
        }

        /// <summary>
        /// Tabla principal de la clase
        /// </summary>
        public const SQLTable TableWork = SQLTable.Products;

        /// <summary>
        /// Configura los campos activos del producto
        /// </summary>
        /// <param name="IncludesID">True  incluye la clave primaria "ID"</param>
        /// <returns><see cref="List{T}"/> de <see cref="Enum"/> de los campos activos</returns>
        public static List<TableFields> GetActiveFields(bool IncludesID)
        {
            List<TableFields> f = new List<TableFields>();
            if (IncludesID)
            {
                f.Add(TableFields.ID);
            }
            f.Add(TableFields.Description);
            f.Add(TableFields.TradeMark);
            f.Add(TableFields.Quantity);
            f.Add(TableFields.Price);
            return f;
        }

        /// <summary>
        /// Devuelve toda la tabla de productos
        /// </summary>
        /// <returns>Hola</returns>
        public static DataTable GetTableProducts()
        {
            return GetTableProducts(GetActiveFields(true));
        }

        /// <summary>
        /// Devuelve una tabla personalizada de productos
        /// </summary>
        /// <param name="Fields">Campos (columnas) de la tabla</param>
        /// <param name="Filter">Filtro de búsqueda</param>
        /// <param name="UnconditionalReturnsAll">Si la búsqueda no retorna resultados,
        /// se cargan todos los datos</param>
        /// <returns></returns>
        public static DataTable GetTableProducts(List<TableFields> Fields, DataFieldTemplate Filter = null, bool UnconditionalReturnsAll = false)
        {
            return GetDataTable(TableWork, Fields, Filter, UnconditionalReturnsAll);
        }

        /// <summary>
        /// Devuelve una lista de productos
        /// </summary>
        /// <param name="Filter">Filtro de búsqueda</param>
        /// <returns></returns>
        public static List<Product> GetProductListed(DataFieldTemplate Filter = null, bool UnconditionalReturnsAll = false)
        {
            DataTable Results = GetTableProducts(GetActiveFields(true), Filter, UnconditionalReturnsAll);
            List<Product> Products = new List<Product>();

            if (Results != null && Results.Rows.Count != 0)
            {
                foreach (DataRow row in Results.Rows)
                {
                    Products.Add(new Product()
                    {
                        ID = Convert.ToInt32(row[TableFields.ID.ToString()]),
                        Description = Convert.ToString(row[TableFields.Description.ToString()]),
                        TradeMark = Convert.ToString(row[TableFields.TradeMark.ToString()]),
                        Quantity = Convert.ToInt32(row[TableFields.Quantity.ToString()]),
                        Price = Convert.ToDouble(row[TableFields.Price.ToString()])
                    });
                }
            }
            return Products;
        }

        /// <summary>
        /// Obtiene el producto según su llave primaria
        /// </summary>
        /// <param name="ID">Llave primaria</param>
        /// <returns></returns>
        /// <exception cref="NoResultsException"></exception>
        /// <exception cref="MultipleResultsException"></exception>
        public static Product GetFromID(int ID)
        {
            return GetProductListed().Find(P => P.ID.Equals(ID));
        }

        /// <summary>
        /// Obtiene una lista de las marcas registradas
        /// </summary>
        /// <returns>Lista de marcas</returns>
        public static List<object> GetTradeMarks()
        {
            return new Select<TableFields>(TableFields.TradeMark, SQLTable.Products)
            {
                GroupByField = TableFields.TradeMark,
                OrderByField = TableFields.TradeMark
            }.RunSelectListed();
        }

        /// <summary>
        /// Tiene lugar al procesar una lista de compra de productos
        /// </summary>
        public static event EventHandler<string> ListPurchased;

        public static void ListToPurchase(List<Product> ShoppingCart)
        {
            List<Product> Listed = GetProductListed(UnconditionalReturnsAll: true);
            foreach (Product ToShop in ShoppingCart)
            {
                Product Finded = Listed.Find(P => P.Equals(ToShop));
                if (Finded is null) Finded.Add(); 
                else Finded.Purchase(ToShop.Quantity);
            }
            if (ListPurchased != null)
            {
                ListPurchased(ShoppingCart, "Lista de compras procesada correctamente");
                ListPurchased = null;
            }
        }
        #endregion

        #region Implements
        public override event EventHandler<string> Validating;
        public override event CrudEventHandler Added;
        public override event CrudEventHandler Updated;
        public override event CrudEventHandler Deleted;
        

        protected override DataFieldTemplate GetDataField(TableFields Field)
        {
            switch (Field)
            {
                case TableFields.ID:
                    return new DataFieldTemplate(Field, ID, SQLValueType.SqlInt);
                case TableFields.Description:
                    return new DataFieldTemplate(Field, Description, SQLValueType.SqlString);
                case TableFields.TradeMark:
                    return new DataFieldTemplate(Field, TradeMark, SQLValueType.SqlString);
                case TableFields.Quantity:
                    return new DataFieldTemplate(Field, Quantity, SQLValueType.SqlInt);
                case TableFields.Price:
                    return new DataFieldTemplate(Field, Price, SQLValueType.SqlDouble);
                default:
                    throw new InvalidFieldException();
            }
        }

        public override void Add()
        {
            try
            {
                ActionNonQuery(new InsertInto(TableWork, GetListDataFields())
                {
                    SecondaryEvent = Added,
                    CommandDescription = "Añadido(s)"
                });
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProductException(ex);
            }
        }

        public override void Delete()
        {
            ActionNonQuery(new Delete(TableWork, GetDataField(TableFields.ID))
            {
                CommandDescription = "Eliminado(s)",
                SecondaryEvent = Deleted
            });
        }
        
        public override void Update()
        {
            try
            {
                ActionNonQuery(new Update(TableWork, GetListDataFields(), GetDataField(TableFields.ID))
                {
                    CommandDescription = "Actualizado(s)",
                    SecondaryEvent = Updated
                });
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProductException(ex);
            }
        }

        protected override List<DataFieldTemplate> GetListDataFields()
        {
            List<DataFieldTemplate> dft = new List<DataFieldTemplate>();
            GetActiveFields(false).ForEach(field => dft.Add(GetDataField(field)));
            return dft;
        }

        public event CrudEventHandler Purchased;
        public event CrudEventHandler Selled;

        public void Purchase(int quantity)
        {
            Quantity += quantity;
            ActionNonQuery(new Update(TableWork, GetDataField(TableFields.Quantity), GetDataField(TableFields.ID))
            {
                CommandDescription = "Compra de Producto",
                SecondaryEvent = Purchased
            });
        }

        public void Sell(int quantity)
        {
            Quantity -= quantity;
            ActionNonQuery(new Update(TableWork, GetDataField(TableFields.Quantity), GetDataField(TableFields.ID))
            {
                CommandDescription = "Venta de Producto",
                SecondaryEvent = Selled
            });
        }
        #endregion
    }
}
