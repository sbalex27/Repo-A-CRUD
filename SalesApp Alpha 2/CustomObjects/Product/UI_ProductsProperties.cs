using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom;

namespace SalesApp_Alpha_2
{
    public partial class UI_ProductsProperties : UserControl, IPropertiesUI<Product>
    {
        public UI_ProductsProperties()
        {
            InitializeComponent();
            InitializeOptionals();
        }

        #region Properties
        private Product _ProductObject;
        public Product GetObject()
        {
            //int id = _ProductObject == null ? 0 : _ProductObject.ID;
            //Todo: solucionar problema de implementación de ID al Get

            //_ProductObject = new Product(_ProductObject ?? _ProductObject.ID)
            //{
            //    ID = inputBox_Text_ID.InputValue,
            //    Description = inputBox_Text_Description.InputValue,
            //    TradeMark = inputBox_Combo_TradeMark.InputValue,
            //    Quantity = (int)inputBox_Numeric_Quantity.InputValue,
            //    Price = (double)inputBox_Numeric_Price.InputValue
            //};

            _ProductObject =_ProductObject ?? new Product();
            _ProductObject.Description = inputBox_Text_Description.InputValue;
            _ProductObject.TradeMark = inputBox_Combo_TradeMark.InputValue;
            _ProductObject.Quantity = (int)inputBox_Numeric_Quantity.InputValue;
            _ProductObject.Price = (double)inputBox_Numeric_Price.InputValue;
            ValidateObject();
            return _ProductObject;
        }
        public void SetObject(Product value)
        {
            _ProductObject = value;
            if (_ProductObject != null)
            {
                inputBox_Text_ID.InputValue = value.ID.ToString();
                inputBox_Text_Description.InputValue = value.Description;
                inputBox_Combo_TradeMark.InputValue = value.TradeMark;
                inputBox_Numeric_Quantity.InputValue = value.Quantity;
                inputBox_Numeric_Price.InputValue = (decimal)value.Price;
            }
            else ClearProperties();
        }

        public bool PropertyID
        {
            get => inputBox_Text_ID.Visible;
            set => inputBox_Text_ID.Visible = value;
        }
        #endregion

        private void InitializeOptionals()
        {
            List<Enum> fields = Product.GetActiveFields(true);
            inputBox_Text_ID.Visible = fields.Contains(Product.TableFields.ID);
            inputBox_Text_Description.Visible = fields.Contains(Product.TableFields.Description);
            inputBox_Combo_TradeMark.Visible = fields.Contains(Product.TableFields.TradeMark);
            inputBox_Numeric_Quantity.Visible = fields.Contains(Product.TableFields.Quantity);
            inputBox_Numeric_Price.Visible = fields.Contains(Product.TableFields.Price);
        }

        public void ValidateObject()
        {
            List<Exception> exceptions = _ProductObject.GetListExceptions();
            ExceptionsHandler(exceptions);
            if (exceptions.Count != 0)
            {
                throw new ProductInvalidException();
            }
        }

        public void DisableVisualErrors()
        {
            foreach (Control item in Controls)
            {
                if (item is InputBox_Numeric ibn) ibn.VisualError = false;
                if (item is InputBox_Combo ibc) ibc.VisualError = false;
                if (item is InputBox_Text ibt) ibt.VisualError = false;
            }
        }

        public void ExceptionsHandler(Exception ex)
        {
            Type t = ex.GetType();
            if (t.Equals(typeof(ProductCriticalValuesException)))
            {
                inputBox_Text_ID.VisualError = true;
                inputBox_Text_Description.VisualError = true;
                inputBox_Combo_TradeMark.VisualError = true;
            }
            else if (t.Equals(typeof(ProductRepeatedException)))
            {
                inputBox_Text_ID.VisualError = true;
                inputBox_Text_Description.VisualError = true;
                inputBox_Combo_TradeMark.VisualError = true;
            }
            else if (t.Equals(typeof(ProductNoQuantityException)))
            {
                inputBox_Numeric_Quantity.VisualError = true;
            }
            else if (t.Equals(typeof(ProductWorthlessException)))
            {
                inputBox_Numeric_Price.VisualError = true;
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        public void ExceptionsHandler(List<Exception> exceptions)
        {
            DisableVisualErrors();
            foreach (Exception ex in exceptions)
            {
                ExceptionsHandler(ex);
            }
        }

        private void inputBox_Combo_TradeMark_Load(object sender, EventArgs e)
        {
            inputBox_Combo_TradeMark.ChangeDataSource(Product.GetTradeMarks());
        }

        public void ClearProperties()
        {
            foreach (Control item in Controls)
            {
                if (item is InputBox_Numeric ibn) ibn.ResetInputValue();
                else if (item is InputBox_Text ibt) ibt.ResetInputValue();
                else if (item is InputBox_Combo ibc) ibc.ResetInputValue();
            }
        }

        public void SetFocus()
        {
            if (PropertyID) inputBox_Text_ID.Focus(); else inputBox_Text_Description.Focus();
        }

    }
}
