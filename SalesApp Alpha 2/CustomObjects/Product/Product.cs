using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SalesApp_Alpha_2
{
    /// <summary>
    /// Objeto de tipo Producto con métodos de compra/venta
    /// </summary>
    public class Product : CObjectCRUD, IEquatable<Product>
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

        private const SQLTable TableWork = SQLTable.Products;

        public int ID { get; private set; }
        public string Description { get; set; }
        public string TradeMark { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public enum TableFields
        {
            ID, Description, TradeMark, Quantity, Price
        }

        /// <summary>
        /// Configura los campos activos del producto
        /// </summary>
        /// <param name="IncludesID">True  incluye la clave primaria "ID"</param>
        /// <returns><see cref="List{T}"/> de <see cref="Enum"/> de los campos activos</returns>
        public static List<Enum> GetActiveFields(bool IncludesID)
        {
            List<Enum> f = new List<Enum>();
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

        public bool Equals(Product other)
        {
            return Equals(other);
        }
        #endregion

        #region Exclusive Statics
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
        public static DataTable GetTableProducts(List<Enum> Fields, DataFieldTemplate Filter = null, bool UnconditionalReturnsAll = false)
        {
            return GetDataTable(TableWork, Fields, Filter, null, UnconditionalReturnsAll);
        }

        /// <summary>
        /// Devuelve una lista de productos
        /// </summary>
        /// <param name="Filter">Filtro de búsqueda</param>
        /// <returns></returns>
        /// <exception cref="NoResultsException"></exception>
        public static List<Product> GetListProducts(DataFieldTemplate Filter = null, bool UnconditionalReturnsAll = false)
        {
            List<Product> Products = new List<Product>();
            DataTable Results = GetTableProducts(GetActiveFields(true), Filter, UnconditionalReturnsAll);

            if (!(Results?.Rows.Count == 0))
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
        public static Product GetFromID(int ID) //Manual Override
        {
            DataFieldTemplate DF = new DataFieldTemplate(TableFields.ID, ID, SQLValueType.SqlInt);
            List<Product> products = GetListProducts(DF);
            switch (products.Count)
            {
                case 0:
                    throw new NoResultsException();
                case 1:
                    return products[0];
                default:
                    throw new MultipleResultsException();
            }
        }

        /// <summary>
        /// Obtiene una lista de las marcas registradas
        /// </summary>
        /// <returns>Lista de marcas</returns>
        public static List<object> GetTradeMarks()
        {
            return new Select(TableFields.TradeMark, SQLTable.Products)
            {
                GroupByField = TableFields.TradeMark,
                OrderByField = TableFields.TradeMark
            }.RunSelectListed();
        }

        /// <summary>
        /// Tiene lugar al procesar una lista de compra de productos
        /// </summary>
        public static event EventHandler<ECrud> ListPurchased;
        /// <summary>
        /// Procesa una lista de compra de productos
        /// </summary>
        /// <param name="Products">Lista de productos</param>
        public static void ListToPurchase(List<Product> Products)
        {
            foreach (Product ToPurchase in Products)
            {
                bool Procesed = false;
                foreach (Product Existent in GetListProducts())
                {
                    if (ToPurchase.Equals(Existent))
                    {
                        Existent.Purchase(ToPurchase.Quantity);
                        Procesed = true;
                        break;
                    }
                }
                if (!Procesed)
                {
                    ToPurchase.Add();
                }
            }
            if (ListPurchased != null)
            {
                ListPurchased(Products, new ECrud("Lista Procesada"));
                ListPurchased = null;
            }
        }
        #endregion

        #region Implements
        public override event EventHandler<string> Validating;
        public override event CrudEventHandler Added;
        public override event CrudEventHandler Updated;
        public override event CrudEventHandler Deleted;

        protected override DataFieldTemplate DataField(Enum Field)
        {
            if (Field is TableFields F)
            {
                switch (F)
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
            else throw new InvalidFieldException();
        }

        public override void Add()
        {
            if (GetListExceptions().Count == 0)
            {
                InsertInto I = new InsertInto(TableWork, GetListDataFields())
                {
                    CommandDescription = "Añadido(s)"
                };
                I.Interaction += DBInteraction;
                I.ExecuteNonQuery();
            }
            else throw new ProductInvalidException();
        }

        private void DBInteraction(DataBaseInteraction sender, int AffectedRows, Type T, string QueryDetails)
        {
            if (T == typeof(InsertInto))
            {
                Added?.Invoke(this, QueryDetails, AffectedRows);
            }
            else if (T == typeof(Update))
            {
                Updated?.Invoke(this, QueryDetails, AffectedRows);
            }
            else if (T == typeof(Delete))
            {
                Deleted?.Invoke(this, QueryDetails, AffectedRows);
            }
        }

        public override void Delete()
        {
            Delete D = new Delete(TableWork, DataField(TableFields.ID))
            {
                CommandDescription = "Eliminado(s)"
            };
            D.Interaction += DBInteraction;
            D.ExecuteNonQuery();
        }

        public override List<Exception> GetListExceptions()
        {
            Validating?.Invoke(this, "Validando Producto");
            List<Exception> exceptions = new List<Exception>();
            if (QFunctions.IsEmptyText(Description))
            {
                exceptions.Add(new ProductCriticalValuesException());
            }
            if (QFunctions.IsEmptyText(TradeMark))
            {
                exceptions.Add(new ProductCriticalValuesException());
            }
            if (Quantity < 0)
            {
                exceptions.Add(new ProductNoQuantityException());
            }
            if (Price <= 0)
            {
                exceptions.Add(new ProductWorthlessException());
            }
            return exceptions;
        }

        //TODO: intentar ver si la validación puede ir vinculada de algún modo a SQL y que dependiendo la excepción sql retorne una excepción personalizada
        public bool ValidateTrial()
        {
            List<Enum> f = GetActiveFields(false);

            if (f.Contains(TableFields.Description) && string.IsNullOrWhiteSpace(Description))
            {
                throw new ProductCriticalValuesException();
            }
            if (f.Contains(TableFields.TradeMark) && string.IsNullOrWhiteSpace(TradeMark))
            {
                throw new ProductCriticalValuesException();
            }
            if (f.Contains(TableFields.Quantity) && Quantity < 0)
            {
                throw new ProductNoQuantityException();
            }
            if (f.Contains(TableFields.Price) && Price <= 0)
            {
                throw new ProductWorthlessException();
            }
            return true;
        }

        public override void Update()
        {
            if (GetListExceptions().Count == 0)
            {
                Update U = new Update(TableWork, GetListDataFields(), DataField(TableFields.ID))
                {
                    CommandDescription = "Actualización(es)"
                };
                U.Interaction += DBInteraction;
                U.ExecuteNonQuery();
            }
            else throw new ProductInvalidException();
        }

        protected override List<DataFieldTemplate> GetListDataFields()
        {
            List<DataFieldTemplate> dft = new List<DataFieldTemplate>();
            foreach (Enum e in GetActiveFields(false))
            {
                dft.Add(DataField(e));
            }
            return dft;
        }
        #endregion

        #region Exclusives Methods
        /// <summary>
        /// Evento que se lanza al comprar un producto
        /// </summary>
        public event CrudEventHandler Purchased;
        /// <summary>
        /// Evento que se lanza al vender un producto
        /// </summary>
        public event CrudEventHandler Selled;

        /// <summary>
        /// Procesa la compra del producto
        /// </summary>
        /// <param name="Quantity">Cantidad de unidades</param>
        public void Purchase(int Quantity)
        {
            this.Quantity += Quantity;
            Update Purchase = new Update(TableWork, DataField(TableFields.Quantity), DataField(TableFields.ID))
            {
                CommandDescription = "Compra de Producto"
            };
            Purchase.Interaction += Purchase_Interaction;
            Purchase.ExecuteNonQuery();
        }

        private void Purchase_Interaction(DataBaseInteraction sender, int AffectedRows, Type T, string QueryDescription)
        {
            Purchased?.Invoke(this, QueryDescription, AffectedRows);
        }

        /// <summary>
        /// Procesa la venta del producto
        /// </summary>
        /// <param name="Quantity">Cantidad de unidades</param>
        public void Sell(int Quantity)
        {
            this.Quantity -= Quantity;
            Update Sell = new Update(TableWork, DataField(TableFields.Quantity), DataField(TableFields.ID))
            {
                CommandDescription = "Venta de Producto"
            };
            Sell.Interaction += Sell_Interaction;
            Sell.ExecuteNonQuery();
        }

        private void Sell_Interaction(DataBaseInteraction sender, int AffectedRows, Type T, string CommandDetails)
        {
            Selled?.Invoke(this, CommandDetails, AffectedRows);
        }



        #endregion

    }
}
