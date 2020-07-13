using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesApp_Alpha_2.UserInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms.Design;
using System.Reflection;
using System.Collections;

namespace SalesApp_Alpha_2
{
    public partial class UiProductProperties : UserControl, IUIProperties<Product>
    {
        private readonly int TabI = 0;
        private readonly InputBox_Generic<int> BoxID;
        private readonly InputBox_Generic<string> BoxDescription;
        private readonly InputBox_Generic<object> BoxTrademark;
        private readonly InputBox_Generic<int> BoxQuantity;
        private readonly InputBox_Generic<double> BoxPrice;

        public UiProductProperties()
        {
            InitializeComponent();

            #region Instanciate
            BoxID = new InputBox_Generic<int>("ID", Properties.Resources._16px_Hashtag, TabI++);
            BoxDescription = new InputBox_Generic<string>("Descripción", Properties.Resources._16px_Product, TabI++);
            BoxTrademark = new InputBox_Generic<object>("Marca", Properties.Resources._16px_Trademark, TabI++);
            BoxQuantity = new InputBox_Generic<int>("Cantidad", Properties.Resources._16px_List, TabI++);
            BoxPrice = new InputBox_Generic<double>("Precio", Properties.Resources._16px_Price, TabI++);
            #endregion

            BoxTrademark.SetDataSource(Product.GetTradeMarks());

            #region Validations
            BoxDescription.DelegatePredicate = Product.PredicateDescription;
            BoxTrademark.DelegatePredicate = arg => Product.PredicateTradeMark(arg.ToString());
            BoxQuantity.DelegatePredicate = Product.PredicateQuantity;
            BoxPrice.DelegatePredicate = Product.PredicatePrice;
            #endregion

            Controls.AddRange(new Control[]
            {
                BoxPrice,
                BoxQuantity,
                BoxTrademark,
                BoxDescription,
                BoxID
            });
        }

        public bool ShowPrimaryKey
        {
            get => BoxID.Visible;
            set => BoxID.Visible = value;
        }

        public bool EnablePrimaryKey
        {
            get => BoxID.Enabled;
            set => BoxID.Enabled = value;
        }

        public Product GetObject() => new Product()
        {
            Description = BoxDescription.InputValue,
            TradeMark = BoxTrademark.InputValue.ToString(),
            Quantity = BoxQuantity.InputValue,
            Price = BoxPrice.InputValue
        };

        public void SetObject(Product obj)
        {
            if (obj != null)
            {
                BoxID.InputValue = obj.ID;
                BoxDescription.InputValue = obj.Description;
                BoxTrademark.InputValue = obj.TradeMark;
                BoxQuantity.InputValue = obj.Quantity;
                BoxPrice.InputValue = obj.Price;
            }
            else Restore();
        }

        public void Restore()
        {
            foreach (Control ctrl in Controls) ctrl.ResetText();
        }
    }

    public interface IUIProperties<T> where T : ICrud
    {
        /// <summary>
        /// Establece el objeto para manipular con la interfaz de usuario
        /// </summary>
        /// <param name="obj">Objeto <see cref="ICrud"/> a manejar</param>
        void SetObject(T obj);

        /// <summary>
        /// Genera una nueva instancia a partir de la información que se 
        /// mostró en la interfaz de usuario
        /// </summary>
        /// <returns>Objeto <see cref="ICrud"/> instanciado</returns>
        T GetObject();

        /// <summary>
        /// Determina si se va a mostrar el control modificando su propiedad
        /// <see cref="Control.Visible"/>
        /// </summary>
        bool ShowPrimaryKey { get; set; }

        /// <summary>
        /// Determina si se va a habilitar la edición del control
        /// que contiene la llave primaria modificando su propiedad
        /// <see cref="Control.Enabled"/>
        /// </summary>
        bool EnablePrimaryKey { get; set; }
        
        /// <summary>
        /// Restablece los valores predeterminados de cada control
        /// </summary>
        void Restore();
    }
}
