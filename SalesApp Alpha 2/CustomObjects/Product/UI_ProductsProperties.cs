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
using System.Reflection;

namespace SalesApp_Alpha_2
{
    public partial class UI_ProductsProperties : UserControl, IPropertiesUI<Product>
    {
        public UI_ProductsProperties()
        {

            InitializeComponent();
            InitializeOptionals();
        }

        Dictionary<Product.TableFields, UserControl> KeyValuePairs => new Dictionary<Product.TableFields, UserControl>()
        {
            {Product.TableFields.Description, inputBox_Text_Description },
            {Product.TableFields.TradeMark, inputBox_Combo_TradeMark },
            {Product.TableFields.Quantity, inputBox_Numeric_Quantity },
            {Product.TableFields.Price, inputBox_Numeric_Price }
        };

        #region Properties
        private Product productObject;
        public Product GetObject()
        {
            productObject = productObject ?? new Product();
            DisableVisualErrors();
            ValidateObject();
            return productObject;
        }

        private void VisualError(Control control, bool value)
        {
            if (control is InputBox_Text ibt) ibt.VisualError = value;
            if (control is InputBox_Numeric ibn) ibn.VisualError = value;
            if (control is InputBox_Combo ibc) ibc.VisualError = value;
        }

        public void SetObject(Product value)
        {
            productObject = value;
            if (productObject is null)
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
                productObject = value;
                inputBox_Text_Description.InputValue = value.Description;
                inputBox_Combo_TradeMark.InputValue = value.TradeMark;
            }
        }

        public bool PropertyID
        {
            get => inputBox_Text_ID.Visible;
            set => inputBox_Text_ID.Visible = value;
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
            try
            {
                productObject.Description = inputBox_Text_Description.InputValue;
                productObject.TradeMark = inputBox_Combo_TradeMark.InputValue;
                productObject.Quantity = (int)inputBox_Numeric_Quantity.InputValue;
                productObject.Price = (double)inputBox_Numeric_Price.InputValue;
            }
            catch (ProductException ex)
            {
                KeyValuePairs.TryGetValue(ex.ExceptionField, out UserControl ctrl);
                VisualError(ctrl, true);
                ctrl.Focus();
                throw;
            }
        }

        public void DisableVisualErrors()
        {
            foreach (Control item in Controls)
            {
                VisualError(item, false);
            }
        }

        private void inputBox_Combo_TradeMark_Load(object sender, EventArgs e)
        {
            inputBox_Combo_TradeMark.ChangeDataSource(Product.GetTradeMarks());
        }

        public void ClearProperties()
        {
            productObject = null;
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
