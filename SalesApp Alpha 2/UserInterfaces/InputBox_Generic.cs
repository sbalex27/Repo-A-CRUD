using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesApp_Alpha_2.UserInterfaces
{
    public partial class InputBox_Generic<T> : UserControl
    {
        public InputBox_Generic()
        {
            InitializeComponent();
            InitializeManual();
        }

        public void InitializeManual()
        {
            this.AutoSize = true;
            this.Dock = DockStyle.Top;
            this.MinimumSize = new Size(150, 0);
            this.Name = "x";
        }
    }
}
