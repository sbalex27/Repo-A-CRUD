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
    public partial class InputBox_Numeric : UserControl, IBoxInput<decimal>
    {
        #region Events
        public event InputBoxEventHandler InputChanged;
        private void NUM_Input_ValueChanged(object sender, EventArgs e) => InputChanged?.Invoke(null, EventArgs.Empty);
        #endregion

        public InputBox_Numeric()
        {
            InitializeComponent();
        }

        public string Title { get => LBL_Title.Text; set => LBL_Title.Text = value; }
        public Image Picture { get => Pic_16px.Image; set => Pic_16px.Image = value; }
        public bool InputEnabled { get => NUM_Input.Enabled; set => NUM_Input.Enabled = value; }
        public decimal InputValue { get => NUM_Input.Value; set => NUM_Input.Value = value; }
        public int DecimalPlaces { get => NUM_Input.DecimalPlaces; set => NUM_Input.DecimalPlaces = value; }

        private bool _VisualError;
        public bool VisualError 
        { 
            get => _VisualError; 
            set
            {
                _VisualError = value;
                BoxErrorState.VisualError(ref LBL_Title, value);
            }
        }

        private void NUM_Input_Enter(object sender, EventArgs e)
        {
            if (NUM_Input.Value == 0) NUM_Input.ResetText();
        }

        public void ResetInputValue()
        {
            InputValue = 0;
            VisualError = false;
        }
    }
}
