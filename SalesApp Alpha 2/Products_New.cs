﻿using System;
using System.Windows.Forms;

namespace SalesApp_Alpha_2
{
    public partial class Products_New : Form
    {
        public Products_New(bool Modify = false)
        {
            FormActionModify = Modify;
            InitializeComponent();
        }

        private bool FormActionModify { get; set; }

        private void BTT_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = UI_ProductsPropertiesInput.GetObject();
                p.Added += P_Event;
                p.Updated += P_Event;

                if (FormActionModify)
                {
                    Product ToModify = Product.GetFromID(p.ID);
                    ToModify = p;
                    ToModify.Update();
                }
                else p.Add();
            }
            catch (Exception ex)
            {
                PremadeMessage.PMNotification(ex.Message);
            }
        }

        private void P_Event(object sender, ECrud e)
        {
            PremadeMessage.ObjectAction(sender, e.Action);
            Close();
        }
    }
}
