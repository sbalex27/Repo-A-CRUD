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
    public partial class InputBox_Combo : UserControl, IBoxInput<string>
    {
        #region Events
        public event InputBoxEventHandler InputChanged;
        public event InputBoxEventHandler InputEnter;
        private void CB_Input_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputChanged?.Invoke(null, EventArgs.Empty);
        }

        private void CB_Input_Enter(object sender, EventArgs e)
        {
            InputEnter?.Invoke(null, EventArgs.Empty);
        }
        #endregion

        public InputBox_Combo()
        {
            InitializeComponent();
        }

        public string Title { get => LBL_Title.Text; set => LBL_Title.Text = value; }
        public Image Picture { get => Pic_16px.Image; set => Pic_16px.Image = value; }
        public object InputDataSource { get => CB_Input.DataSource; set => CB_Input.DataSource = value; }
        public string InputValue { get => CB_Input.Text; set => CB_Input.Text = value; }
        public bool InputEnabled { get => LBL_Title.Enabled; set => LBL_Title.Enabled = value; }

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

        public void ChangeDataSource(object NewDataSource)
        {
            CB_Input.DataSource = NewDataSource;
            CB_Input.SelectedItem = null;
        }

        public void ResetInputValue()
        {
            InputValue = null;
            VisualError = false;
        }
    }
}
