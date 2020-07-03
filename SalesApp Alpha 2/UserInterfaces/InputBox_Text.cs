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
    public partial class InputBox_Text : UserControl, IBoxInput<string>
    {
        #region Custom Events
        public event InputBoxEventHandler InputChanged;
        private void TXT_Input_TextChanged(object sender, EventArgs e) => InputChanged?.Invoke(null, EventArgs.Empty);
        #endregion

        public InputBox_Text()
        {
            InitializeComponent();
        }

        public string InputValue { get => TXT_Input.Text; set => TXT_Input.Text = value; }
        public string Title { get => LBL_Title.Text; set => LBL_Title.Text = value; }
        public Image Picture { get => Pic_16px.Image; set => Pic_16px.Image = value; }
        public bool InputEnabled { get => TXT_Input.Enabled; set => TXT_Input.Enabled = value; }

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

        public void ResetInputValue()
        {
            InputValue = string.Empty;
            VisualError = false;
        }

        private void TXT_Input_Enter(object sender, EventArgs e)
        {
            if (!QFunctions.IsEmptyText(InputValue))
            {
                TXT_Input.SelectAll();
            }
        }
    }
}
