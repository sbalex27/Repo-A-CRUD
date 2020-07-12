using SalesApp_Alpha_2.UserInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesApp_Alpha_2
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ingresarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Products_New();
            frm.Show();
        }

        private void verTablaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Products();
            form.Show();
        }

        private void modificarProductoDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Products_New(true);
            form.Show();
        }

        private void nuevaCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Purchases_New();
            form.Show();
        }

        private void BTT_Test_Click(object sender, EventArgs e)
        {
            //if (uiProductProperties1.ValidateChildren())
            //{
            //    Product p = uiProductProperties1.GetObject();
            //    MessageBox.Show(p.ToString());
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //uiProductProperties1.Restore();
        }
    }
}
