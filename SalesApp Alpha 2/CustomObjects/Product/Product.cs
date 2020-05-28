using System;
using System.Collections.Generic;
using System.Data;

using static SalesApp_Alpha_2.DataFieldTemplate;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SalesApp_Alpha_2
{
    public partial class OProduct
    {
        //Constructors
        public OProduct() { }

        public OProduct(int ID, string Description, string TradeMark)
        {
            this.ID = ID;
            this.Description = Description;
            this.TradeMark = TradeMark;
        }

        #region Properties and proeprties methods

        //Properties
        public int ID { get; private set; }
        public string Description { get; set; }
        public string TradeMark { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public enum TableFields
        {
            ID,
            Description,
            TradeMark,
            Quantity,
            Price
        }

        //Properties on data field template

        private DataFieldTemplate DataField(TableFields Field)
        {
            return DataField(Field, this);
        }
        private static DataFieldTemplate DataField(TableFields Field, object NewValue)
        {
            return DataField(Field, null, NewValue);
        }
        private static DataFieldTemplate DataField(TableFields Field, OProduct ToEvaluate, object NewValue = null)
        {
            bool ActiveProduct = ToEvaluate != null;
            switch (Field)
            {
                case TableFields.ID:
                    return new DataFieldTemplate(Field, ActiveProduct ? ToEvaluate.ID : NewValue, SQLValueType.SqlInt);
                case TableFields.Description:
                    return new DataFieldTemplate(Field, ActiveProduct ? ToEvaluate.Description : NewValue, SQLValueType.SqlString);
                case TableFields.TradeMark:
                    return new DataFieldTemplate(Field, ActiveProduct ? ToEvaluate.TradeMark : NewValue, SQLValueType.SqlString);
                case TableFields.Quantity:
                    return new DataFieldTemplate(Field, ActiveProduct ? ToEvaluate.Quantity : NewValue, SQLValueType.SqlInt);
                case TableFields.Price:
                    return new DataFieldTemplate(Field, ActiveProduct ? ToEvaluate.Price : NewValue, SQLValueType.SqlDouble);
                default:
                    throw new Exception("Campo inválido");
            }
        }

        private List<DataFieldTemplate> DataFieldsActivated(bool IncludesID)
        {
            List<DataFieldTemplate> DataFieldTemplates = new List<DataFieldTemplate>();

            if (IncludesID) DataFieldTemplates.Add(DataField(TableFields.ID));

            DataFieldTemplates.Add(DataField(TableFields.Description));
            DataFieldTemplates.Add(DataField(TableFields.TradeMark));
            DataFieldTemplates.Add(DataField(TableFields.Quantity));
            DataFieldTemplates.Add(DataField(TableFields.Price));
            //INSERT HERE OPTIONALS
            return DataFieldTemplates;
        }

        public static List<Enum> GetFieldsActivated()
        {
            List<Enum> tableFields = new List<Enum>
            {
                TableFields.ID,
                TableFields.Description,
                TableFields.TradeMark,
                TableFields.Quantity,
                TableFields.Price
            };
            //INSERT HERE OPTIONALS
            return tableFields;
        }

        //private static readonly Converter<TableFields, object> ListFieldsToObjects = new Converter<TableFields, object>(FieldToObject);
        //private static readonly Converter<TableFields, Enum> ListFieldsToEnum = new Converter<TableFields, Enum>(FieldToEnum);

        //private static Enum FieldToEnum(TableFields input)
        //{
        //    return (Enum)input;
        //}
        #endregion

        #region Object Methods

        public override string ToString() => $"{Description} - {TradeMark}";
        public string ToString(bool Details)
        {
            if (Details)
            {
                return $"[ID {ID}]: {Description} || {TradeMark} (Q {Price} c/u) * {Quantity}";
            }
            else return ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            try
            {
                if (((OProduct)obj).Description == Description &&
                    ((OProduct)obj).TradeMark == TradeMark)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override int GetHashCode() => base.GetHashCode();
        #endregion

        #region Statics
        //static private object FieldToObject(TableFields Field) => Field.ToString();

        static public DataTable GetAll(List<Enum> Fields)
        {
            return GetAll(Fields, TableFields.Description, null);
        }

        static public DataTable GetAll(List<Enum> Fields, TableFields FieldForFilter, string ValueFilter, bool IfEmptyIsNull = false)
        {
            bool IsEmpty = QFunctions.IsEmptyText(ValueFilter);
            if (IfEmptyIsNull && IsEmpty) return null;
            DataFieldTemplate Conditional = IsEmpty ? null : DataField(FieldForFilter, ValueFilter);
            return Qsql.Select(SQLTable.Products, Fields, Conditional, true);
        }

        static public List<OProduct> GetAll()
        {
            DataTable ProductsDataTable = GetAll(GetFieldsActivated());
            List<OProduct> ProductsList = new List<OProduct>();

            foreach (DataRow row in ProductsDataTable.Rows)
            {
                ProductsList.Add(new OProduct()
                {
                    ID = Convert.ToInt32(row[TableFields.ID.ToString()]),
                    Description = Convert.ToString(row[TableFields.Description.ToString()]),
                    TradeMark = Convert.ToString(row[TableFields.TradeMark.ToString()]),
                    Quantity = Convert.ToInt32(row[TableFields.Quantity.ToString()]),
                    Price = Convert.ToDouble(row[TableFields.Price.ToString()])
                });
            }
            return ProductsList;
        }

        public static OProduct GetFromID(int ID)
        {
            DataTable ProductsDataTable = Qsql.Select(SQLTable.Products,
                GetFieldsActivated(),
                DataField(TableFields.ID, ID),
                false);

            switch (ProductsDataTable.Rows.Count)
            {
                case 0:
                    throw new NoResultsException();
                case 1:
                    return new OProduct
                    {
                        ID = Convert.ToInt32(ProductsDataTable.Rows[0][(int)TableFields.ID]),
                        Description = Convert.ToString(ProductsDataTable.Rows[0][(int)TableFields.Description]),
                        TradeMark = Convert.ToString(ProductsDataTable.Rows[0][(int)TableFields.TradeMark]),
                        Quantity = Convert.ToInt32(ProductsDataTable.Rows[0][(int)TableFields.Quantity]),
                        Price = Convert.ToDouble(ProductsDataTable.Rows[0][(int)TableFields.Price]),
                    };
                default:
                    throw new MultipleResultsException();
            }
        }

        public static List<object> GetTradeMarks()
        {
            return Qsql.Select(SQLTable.Products, TableFields.TradeMark);
        }

        public static void PurchaseList(List<OProduct> ListToPurchase) => PurchaseList(ListToPurchase, null);
        public static void PurchaseList(List<OProduct> ListToPurchase, System.Windows.Forms.ProgressBar ReferencedProgressBar)
        {
            bool ReferencedPB = false;
            if (ReferencedProgressBar != null) ReferencedPB = true;
            if (ReferencedPB)
            {
                ReferencedProgressBar.Visible = true;
                ReferencedProgressBar.Value = 0;
                ReferencedProgressBar.Maximum = ListToPurchase.Count;
            }
            foreach (OProduct ToPurchase in ListToPurchase)
            {
                bool Purchased = false;
                foreach (OProduct Existent in GetAll())
                {
                    if (ToPurchase.Equals(Existent))
                    {
                        Existent.Purchase(ToPurchase.Quantity);
                        Purchased = true;
                        break;
                    }
                }
                if (!Purchased) ToPurchase.Add();
                if (ReferencedPB) ReferencedProgressBar.PerformStep();
            }
            if (ReferencedPB) ReferencedProgressBar.Visible = false;
            if (ListPurchased != null)
            {
                ListPurchased(null, new ProductEventArgs("Lista de Compra Procesada"));
                ListPurchased = null;
            }
        }

        #endregion

        #region Instance Methods

        public List<Exception> Validate()
        {
            List<Exception> exceptions = new List<Exception>();
            bool LDescription = QFunctions.IsEmptyText(Description);
            bool LTradeMark = QFunctions.IsEmptyText(TradeMark);
            bool LQuantity = Quantity <= 0;
            bool LPrice = Price <= 0;
            if (LDescription || LTradeMark) exceptions.Add(new ProductCriticalValuesException());
            if (LQuantity) exceptions.Add(new ProductNoQuantityException());
            if (LPrice) exceptions.Add(new ProductWorthlessException());
            return exceptions;
        }

        //public void Validate(UI_ProductsProperties uI_ProductsProperties)
        //{
        //    uI_ProductsProperties.DisableVisualErrors();
        //    foreach (Exception ex in Validate())
        //    {
        //        uI_ProductsProperties.ExceptionsHandler(ex);
        //    }
        //    if (uI_ProductsProperties.GetAnalyzedExceptions() != 0) throw new Exception("No se admiten algunos de los valores");
        //}

        public bool IsContained(List<OProduct> ProductList)
        {
            foreach (OProduct p in ProductList)
            {
                if (Equals(p))
                {
                    return true;
                }
            }
            return false;
        }

        public void Add()
        {
            Qsql.InsertIntoSuccess += Qsql_InsertIntoSuccess;
            Qsql.InsertInto(SQLTable.Products, DataFieldsActivated(false));
        }

        public void Update()
        {
            //Execute
            Qsql.UpdateSuccess += Qsql_UpdateSuccess;
            Qsql.UpdateWhere(SQLTable.Products, DataFieldsActivated(false), DataField(TableFields.ID));
        }

        public void Delete()
        {
            //Execute
            Qsql.DeleteSucess += Qsql_DeleteSucess;
            Qsql.DeleteWhere(SQLTable.Products, DataField(TableFields.ID));
        }

        private void SellOrPurchase(bool PurchaseAsTrue, int Units)
        {
            Quantity = PurchaseAsTrue ? Quantity + Units : Quantity - Units;
            Qsql.UpdateWhere(SQLTable.Products, DataField(TableFields.Quantity), DataField(TableFields.ID));
        }

        public void Sell(int Units)
        {
            SellOrPurchase(false, Units);
            Selled?.Invoke(this, new ProductEventArgs("Producto Vendido"));
        }

        public void Purchase(int Units)
        {
            SellOrPurchase(true, Units);
            Purchased?.Invoke(this, new ProductEventArgs("Producto Comprado"));
        }

        public void Clone(OProduct ProductToClone)
        {
            try
            {
                if (ProductToClone != null)
                {
                    Description = ProductToClone.Description;
                    TradeMark = ProductToClone.TradeMark;
                    Quantity = ProductToClone.Quantity;
                    Price = ProductToClone.Price;
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                throw new ProductCriticalValuesException();
            }
        }
        #endregion
    }

    #region Events
    public class ProductEventArgs : EventArgs
    {
        public ProductEventArgs(string s) => Action = s;
        public string Action { get; set; }
    }

    //Invoke Event voids
    public partial class OProduct
    {
        //Events
        public delegate void EventHandler(object sender, ProductEventArgs e);
        public event EventHandler<ProductEventArgs> Added;
        public event EventHandler<ProductEventArgs> Updated;
        public event EventHandler<ProductEventArgs> Deleted;
        public event EventHandler<ProductEventArgs> Selled;
        public event EventHandler<ProductEventArgs> Purchased;
        public static event EventHandler<ProductEventArgs> ListPurchased;

        //Delegated Database Events
        private void Qsql_DeleteSucess() => Deleted?.Invoke(this, new ProductEventArgs("Producto Eliminado"));
        private void Qsql_UpdateSuccess() => Updated?.Invoke(this, new ProductEventArgs("Producto Actualizado"));
        private void Qsql_InsertIntoSuccess() => Added?.Invoke(this, new ProductEventArgs("Producto Añadido"));
    }
    #endregion
}
