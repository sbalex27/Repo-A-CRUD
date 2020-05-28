using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesApp_Alpha_2
{
    public partial class InBox : UserControl
    {
        public InBox()
        {
            InitializeComponent();
        }

        //Properties
        public string Title 
        {
            get
            {
                return LBL_Title.Text;
            }
            set
            {
                LBL_Title.Text = value;
            }
        }
        public string InputText 
        {
            get
            {
                return TXT_Input.Text;
            }
            set
            {
                TXT_Input.Text = value;
            }
        }
        public Image Picture
        {
            get
            {
                return Picture_16px.Image;
            }
            set
            {
                Picture_16px.Image = value;
            }
        }

        //Events
        public delegate void TextChangeEventHandler(object sender, EventArgs e);
        public event TextChangeEventHandler TextChange;

        //Methods & Functions
        private void TXT_Input_TextChanged(object sender, EventArgs e)
        {
            TextChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
