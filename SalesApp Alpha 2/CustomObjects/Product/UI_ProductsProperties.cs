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
            _ProductObject = _ProductObject ?? new Product();
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
            if (_ProductObject is null)
            {
                ClearProperties();
            }
            else
            {
                inputBox_Text_ID.InputValue = value.ID.ToString();
                inputBox_Text_Description.InputValue = value.Description;
                inputBox_Combo_TradeMark.InputValue = value.TradeMark;
                inputBox_Numeric_Quantity.InputValue = value.Quantity;
                inputBox_Numeric_Price.InputValue = (decimal)value.Price;
            }
        }

        public void SemiSetObject(Product value)
        {
            if (value is null)
            {
                ClearProperties();
            }
            else
            {
                inputBox_Text_Description.InputValue = value.Description;
                inputBox_Combo_TradeMark.InputValue = value.TradeMark;
            }
        }

        public bool PropertyID
        {
            get => inputBox_Text_ID.Visible;
            set => inputBox_Text_ID.Visible = value;
        }

        public bool IsValid
        {
            get
            {

            }
        }
        #endregion

        private void InitializeOptionals()
        {
            List<Product.TableFields> fields = Product.GetActiveFields(true);
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

        //toDo: borrar método de lanzamiento de excepciones antigüo si funciona el nuevo
        public void ExceptionsHandlerOLD(Exception ex)
        {
            switch (ex)
            {
                case ProductCriticalValuesException _:
                    inputBox_Text_ID.VisualError = true;
                    inputBox_Text_Description.VisualError = true;
                    inputBox_Combo_TradeMark.VisualError = true;
                    break;
                case ProductRepeatedException _:
                    inputBox_Text_ID.VisualError = true;
                    inputBox_Text_Description.VisualError = true;
                    inputBox_Combo_TradeMark.VisualError = true;
                    break;
                case ProductNoQuantityException _:
                    inputBox_Numeric_Quantity.VisualError = true;
                    break;
                case ProductWorthlessException _:
                    inputBox_Numeric_Price.VisualError = true;
                    break;
                default:
                    throw new InvalidCastException();
            }
        }

        public void ExceptionsHandler(Exception ex)
        {
            try
            {
                throw new Exception("Producto inválido", ex);
            }
            catch (ProductCriticalValuesException)
            {
                inputBox_Text_ID.VisualError = true;
                inputBox_Text_Description.VisualError = true;
                inputBox_Combo_TradeMark.VisualError = true;
            }
            catch (ProductRepeatedException)
            {
                inputBox_Text_ID.VisualError = true;
                inputBox_Text_Description.VisualError = true;
                inputBox_Combo_TradeMark.VisualError = true;
            }
            catch (ProductNoQuantityException)
            {
                inputBox_Numeric_Quantity.VisualError = true;
            }
            catch (ProductWorthlessException)
            {
                inputBox_Numeric_Price.VisualError = true;
            }
        }

        public void ExceptionsHandler(List<Exception> exceptions)
        {
            DisableVisualErrors();
            exceptions.ForEach(ex => ExceptionsHandler(ex));
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
