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
            {Product.TableFields.Description, Box_Description },
            {Product.TableFields.TradeMark, Box_Trademark },
            {Product.TableFields.Quantity, Box_Quantity },
            {Product.TableFields.Price, Box_Price }
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
                Box_ID.InputValue = value.ID.ToString();
                Box_Description.InputValue = value.Description;
                Box_Trademark.InputValue = value.TradeMark;
                Box_Quantity.InputValue = value.Quantity;
                Box_Price.InputValue = (decimal)value.Price;
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
                Box_Description.InputValue = value.Description;
                Box_Trademark.InputValue = value.TradeMark;
            }
        }

        public bool PropertyID
        {
            get => Box_ID.Visible;
            set => Box_ID.Visible = value;
        }
        #endregion

        private void InitializeOptionals()
        {
            List<Product.TableFields> fields = Product.GetActiveFields(true);
            Box_ID.Visible = fields.Contains(Product.TableFields.ID);
            Box_Description.Visible = fields.Contains(Product.TableFields.Description);
            Box_Trademark.Visible = fields.Contains(Product.TableFields.TradeMark);
            Box_Quantity.Visible = fields.Contains(Product.TableFields.Quantity);
            Box_Price.Visible = fields.Contains(Product.TableFields.Price);
        }

        public void ValidateObject()
        {
            try
            {
                productObject.Description = Box_Description.InputValue;
                productObject.TradeMark = Box_Trademark.InputValue;
                productObject.Quantity = (int)Box_Quantity.InputValue;
                productObject.Price = (double)Box_Price.InputValue;
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
            Box_Trademark.ChangeDataSource(Product.GetTradeMarks());
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
            if (PropertyID) Box_ID.Focus(); else Box_Description.Focus();
        }
    }
}
