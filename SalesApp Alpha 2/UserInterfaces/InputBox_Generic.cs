using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.CodeDom;

namespace SalesApp_Alpha_2.UserInterfaces
{
    enum InputBoxType
    {
        Text,
        Integer,
        Money,
        Collection
    }

    public partial class InputBox_Generic<T> : UserControl
    {
        Control controlUsed = new Control();
        readonly TextBox textBox = new TextBox();
        readonly ComboBox comboBox = new ComboBox();
        readonly NumericUpDown numericBox = new NumericUpDown();

        readonly List<Type> typesNumeric = new List<Type>()
        {
            typeof(double), typeof(int), typeof(short), typeof(decimal)
        };

        public InputBox_Generic(string title, Image icon16px)
        {
            InitializeComponent();
            InitializeProperties();
            DrawVariant();
            Title = title;
            Icon16 = icon16px;
        }

        private void InitializeProperties()
        {
            Dock = DockStyle.Top;
            BackColor = Color.Red;
        }

        private void DrawVariant()
        {
            if (InputValueType.Equals(typeof(string)))
            {
                controlUsed = textBox;
            }
            else if (typesNumeric.Contains(InputValueType))
            {
                controlUsed = numericBox;
            }
            else if (InputValueType.Equals(typeof(object)))
            {
                controlUsed = comboBox;
            }
            controlUsed.Dock = DockStyle.Top;
            Panel_Input.Controls.Add(controlUsed);
        }

        public Type InputValueType => typeof(T);
        public Image Icon16
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }
        public string Title
        {
            get => Label_Title.Text;
            set => Label_Title.Text = value;
        }
        public T InputValue
        {
            set
            {
                if (InputValueType.Equals(typeof(string)))
                {
                    controlUsed.Text = value.ToString();
                }
                else if (InputValueType.Equals(typeof(decimal)))
                {
                    numericBox.Value = Convert.ToDecimal(value);
                }
            }
            get
            {
                if (InputValueType.Equals(typeof(decimal)))
                {
                    return (T)(object)numericBox.Value;
                }
                else
                {
                    return (T)(object)controlUsed.Text;
                }
            }
        }
    }
}
