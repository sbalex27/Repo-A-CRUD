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

            InputBox_Generic<object> generic = new InputBox_Generic<object>("Propiedad básica", Properties.Resources.icons8_búsqueda_16__1_);
            this.Controls.Add(generic);
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
    }
}
