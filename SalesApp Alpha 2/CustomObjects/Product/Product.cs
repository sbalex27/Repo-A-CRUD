using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
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

        public int ID { get; private set; }
        public string Description { get; set; }
        public string TradeMark { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public const SQLTable TableWork = SQLTable.Products;

        public enum TableFields
        {
            ID, Description, TradeMark, Quantity, Price
        }

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
        /// <exception cref="NoResultsException"></exception>
        public static List<Product> GetProductListed(DataFieldTemplate Filter = null, bool UnconditionalReturnsAll = false)
        {
            List<Product> Products = new List<Product>();
            DataTable Results = GetTableProducts(GetActiveFields(true), Filter, UnconditionalReturnsAll);
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
        public static event EventHandler ListPurchased;

        ///// <summary>
        ///// Procesa una lista de compra de productos
        ///// </summary>
        ///// <param name="Products">Lista de productos</param>
        //public static void ListToPurchaseOld(List<Product> Products)
        //{
        //    foreach (Product ToPurchase in Products)
        //    {
        //        bool Procesed = false;
        //        foreach (Product Existent in GetProductListed())
        //        {
        //            if (ToPurchase.Equals(Existent))
        //            {
        //                Existent.Purchase(ToPurchase.Quantity);
        //                Procesed = true;
        //                break;
        //            }
        //        }
        //        if (!Procesed)
        //        {
        //            ToPurchase.Add();
        //        }
        //    }
        //    if (ListPurchased != null)
        //    {
        //        ListPurchased(Products, new ECrud("Lista Procesada"));
        //        ListPurchased = null;
        //    }
        //}

        //UNDONE: Revisar código optimizado en la modificación del método ListToPurchase
        public static void ListToPurchase(List<Product> ShoppingCart)
        {
            List<Product> Listed = GetProductListed();
            foreach (Product ToShop in ShoppingCart)
            {
                Product Finded = Listed.Find(P => P.Equals(ToShop));
                if (Finded is null) Finded.Add(); 
                else Finded.Purchase(ToShop.Quantity);
            }
            if (ListPurchased != null)
            {
                ListPurchased(ShoppingCart, EventArgs.Empty);
                ListPurchased = null;
            }
        }
        #endregion

        #region Implements
        public override event EventHandler<string> Validating;
        public override event CrudEventHandler Added;
        public override event CrudEventHandler Updated;
        public override event CrudEventHandler Deleted;
        

        protected override DataFieldTemplate DataField(TableFields Field)
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
                ActionNonQuery(new InsertInto(TableWork, GetListDataFields())
                {
                    CommandDescription = "Añadido(s)",
                    SecondaryEvent = Added
                });
            }
            else throw new ProductInvalidException();
        }

        public override void Delete()
        {
            ActionNonQuery(new Delete(TableWork, DataField(TableFields.ID))
            {
                CommandDescription = "Eliminado(s)",
                SecondaryEvent = Deleted
            });
        }

        //undone: si funciona el nuevo método de reemplazo deshacer este.
        public List<Exception> GetListExceptionsOld()
        {
            Validating?.Invoke(this, "Validando Producto");
            List<Exception> exceptions = new List<Exception>();

            Func<string, bool> IsEmpty = new Func<string, bool>(val => string.IsNullOrEmpty(val));
            Action<List<Exception>, Exception> action = (ex, li) => ex.Add(li);
            Action CriticalValues = new Action(delegate ()
            {
                exceptions.Add(new ProductCriticalValuesException());
            });

            if (IsEmpty(Description))
            {
                CriticalValues();
            }
            if (IsEmpty(TradeMark))
            {
                CriticalValues();
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

        public override List<Exception> GetListExceptions()
        {
            Validating?.Invoke(this, "Validando");
            List<Exception> exceptions = new List<Exception>();

            Func<string, bool> isEmpty = new Func<string, bool>(s => string.IsNullOrWhiteSpace(s));
            Func<object, bool> isCero = new Func<object, bool>(delegate (object arg)
            {
                decimal.TryParse(arg.ToString(), out decimal result);
                return result <= 0;
            });

            Action<Exception> addException = new Action<Exception>(ex => exceptions.Add(ex));
            Action<string> criticalValue = new Action<string>(delegate (string arg)
            {
                if (isEmpty(arg)) addException(new ProductCriticalValuesException());
            });

            criticalValue(Description);
            criticalValue(TradeMark);
            if (isCero(Quantity)) addException(new ProductNoQuantityException());
            if (isCero(Price)) addException(new ProductWorthlessException());
            return exceptions;
        }

        //toDO: IMPORTANTE continuar agregando el código para implementer la nueva excepción ProductException
        public List<Exception> GetExceptions()
        {
            List<Exception> exceptions = new List<Exception>();
            Predicate<object> IsEmpty = new Predicate<object>(o => string.IsNullOrEmpty(o.ToString()));
            Action<TableFields> AddEmpty = new Action<TableFields>(f => exceptions.Add(new ProductObligatoryFieldException(f)));

            if (IsEmpty(Description))
            {
                AddEmpty(TableFields.Description);
            }
            if (IsEmpty(TradeMark))
            {
                AddEmpty(TableFields.TradeMark);
            }
            if (IsEmpty(Quantity))
            {
                AddEmpty(TableFields.Quantity);
            }
            if (IsEmpty(Price))
            {
                AddEmpty(TableFields.Price);
            }
            if (Price <= 0)
            {
                exceptions.Add(new ProductInvalidPriceException());
            }
            if (Quantity <= 0)
            {
                exceptions.Add(new ProductSoldOutException());
            }

            return exceptions;
        }

        //TODO: intentar ver si la validación puede ir vinculada de algún modo a SQL y que dependiendo la excepción sql retorne una excepción personalizada
        public bool ValidateTrial()
        {
            List<TableFields> f = GetActiveFields(false);

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
                ActionNonQuery(new Update(TableWork, GetListDataFields(), DataField(TableFields.ID))
                {
                    CommandDescription = "Actualización(es)",
                    SecondaryEvent = Updated
                });
            }
            else throw new ProductInvalidException();
        }

        protected override List<DataFieldTemplate> GetListDataFields()
        {
            List<DataFieldTemplate> dft = new List<DataFieldTemplate>();
            GetActiveFields(false).ForEach(field => dft.Add(DataField(field)));
            return dft;
        }
        #endregion

        #region Exclusives Methods
        public event CrudEventHandler Purchased;
        public event CrudEventHandler Selled;

        public void Purchase(int quantity)
        {
            Quantity += quantity;
            ActionNonQuery(new Update(TableWork, DataField(TableFields.Quantity), DataField(TableFields.ID))
            {
                CommandDescription = "Compra de Producto",
                SecondaryEvent = Purchased
            });
        }

        public void Sell(int quantity)
        {
            Quantity -= quantity;
            ActionNonQuery(new Update(TableWork, DataField(TableFields.Quantity), DataField(TableFields.ID))
            {
                CommandDescription = "Venta de Producto",
                SecondaryEvent = Selled
            });
        }
        #endregion

    }
}
