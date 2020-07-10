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

namespace SalesApp_Alpha_2
{
    public partial class UiProductProperties : UserControl
    {
        private readonly int TabI = 0;
        private readonly InputBox_Generic<int> BoxID;
        private readonly InputBox_Generic<string> BoxDescription;
        private readonly InputBox_Generic<string> BoxTrademak;
        private readonly InputBox_Generic<int> BoxQuantity;
        private readonly InputBox_Generic<double> BoxPrice;

        public UiProductProperties()
        {
            InitializeComponent();

            #region Instanciate
            BoxID = new InputBox_Generic<int>("ID", Properties.Resources._16px_List, TabI++);
            BoxDescription = new InputBox_Generic<string>("Descripción", Properties.Resources._16px_Product, TabI++);
            BoxTrademak = new InputBox_Generic<string>("Marca", Properties.Resources._16px_Trademark, TabI++);
            BoxQuantity = new InputBox_Generic<int>("Cantidad", Properties.Resources._16px_List, TabI++);
            BoxPrice = new InputBox_Generic<double>("Precio", Properties.Resources._16px_Price, TabI++);
            #endregion

            #region Validations
            BoxDescription.DelegatePredicate = Product.PredicateDescription;
            BoxTrademak.DelegatePredicate = Product.PredicateTradeMark;
            BoxQuantity.DelegatePredicate = Product.PredicateQuantity;
            BoxPrice.DelegatePredicate = Product.PredicatePrice;
            #endregion

            Controls.AddRange(new Control[]
            {
                BoxPrice,
                BoxQuantity,
                BoxTrademak,
                BoxDescription,
                BoxID
            });
        }
    }
}
