using System;
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

        public event EventHandler<Product> Added;

        private bool FormActionModify { get; set; }

        private void BTT_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = UI_ProductsPropertiesInput.GetObject();
                p.Added += P_Event;
                p.Add();
            }
            catch (Exception ex)
            {
                PremadeMessage.Notification(ex.Message);
            }
        }

        private void P_Event(object sender, string Action, int AffectedsRecords)
        {
            PremadeMessage.ObjectAction(sender, Action, AffectedsRecords);
            Added?.Invoke(this, (Product)sender);
            Close();
        }
    }
}