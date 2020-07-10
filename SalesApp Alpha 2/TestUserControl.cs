﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesApp_Alpha_2.UserInterfaces;
using MySql.Data;

namespace SalesApp_Alpha_2
{
    public partial class TestUserControl : UserControl
    {
        #region Control Variables
        private readonly InputBox_Generic<double> Box_Price;
        private readonly InputBox_Generic<int> Box_Quantity;
        private readonly InputBox_Generic<string> Box_TradeMark;
        private readonly InputBox_Generic<string> Box_Description;
        private readonly InputBox_Generic<int> Box_ID;
        #endregion

        private readonly Padding CustomPadding = new Padding(3);

        public TestUserControl()
        {
            InitializeComponent();

            int i = 0;
            #region Instanciate
            Box_ID = new InputBox_Generic<int>("ID", Properties.Resources._16px_List, i++)
            {
                Padding = CustomPadding
            };
            Box_Description = new InputBox_Generic<string>("Descripción", Properties.Resources._16px_Product, i++)
            {
                Padding = CustomPadding,
            };

            Box_TradeMark = new InputBox_Generic<string>("Marca", Properties.Resources._16px_Trademark, i++)
            {
                Padding = CustomPadding
            };

            Box_Quantity = new InputBox_Generic<int>("Cantidad", Properties.Resources._16px_List, i++)
            {
                Padding = CustomPadding
            };

            Box_Price = new InputBox_Generic<double>("Precio", Properties.Resources._16px_Price, i++)
            {
                Padding = CustomPadding
            };
            #endregion

            Controls.AddRange(new Control[]
            {
                Box_Price,Box_Quantity,Box_TradeMark,Box_Description,Box_ID
            });
        }
    }
}
