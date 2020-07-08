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
using Microsoft.Analytics.Interfaces;

namespace SalesApp_Alpha_2.UserInterfaces
{
    public enum InputBoxType
    {
        Text,
        Integer,
        Money,
        Collection
    }

    public partial class InputBox_Generic<T> : UserControl
    {
        public event EventHandler InputValueChanged;

        private Control controlUsed = new Control();
        private readonly TextBox textBox = new TextBox();
        private readonly ComboBox comboBox = new ComboBox();
        private readonly NumericUpDown numericBox = new NumericUpDown();

        private readonly List<Type> AllowedTypes = new List<Type>()
        {
            typeof(string), typeof(double), typeof(object), typeof(int)
        };

        public InputBox_Generic(string title, Image icon16px, int tabIndex = 0)
        {
            MasterConstructor(title, icon16px, tabIndex);
        }

        private void MasterConstructor(string title, Image icon16px, int tabIndex)
        {
            if (!AllowedTypes.Contains(InputValueType)) throw new ArgumentOutOfRangeException();
            InitializeComponent();
            Dock = DockStyle.Top;
            Title = title;
            Icon16 = icon16px;
            TabIndex = tabIndex;
            DrawVariant();
        }

        private void DrawVariant()
        {
            switch (BoxType)
            {
                case InputBoxType.Text:
                    controlUsed = textBox;
                    break;
                case InputBoxType.Integer:
                    controlUsed = numericBox;
                    break;
                case InputBoxType.Money:
                    controlUsed = numericBox;
                    break;
                default:
                    controlUsed = comboBox;
                    break;
            }
            controlUsed.Dock = DockStyle.Top;
            Panel_Input.Controls.Add(controlUsed);
            controlUsed.TextChanged += ControlUsed_TextChanged;
        }

        private void ControlUsed_TextChanged(object sender, EventArgs e)
        {
            InputValueChanged?.Invoke(this, e);
        }

        public Predicate<T> DelegatePredicate { get; set; }
        public Type InputValueType => typeof(T);
        public InputBoxType BoxType
        {
            get
            {
                if (InputValueType.Equals(typeof(string)))
                {
                    return InputBoxType.Text;
                }
                else if (InputValueType.Equals(typeof(double)))
                {
                    return InputBoxType.Money;
                }
                else if (InputValueType.Equals(typeof(int)))
                {
                    return InputBoxType.Integer;
                }
                else
                {
                    return InputBoxType.Collection;
                }
            }
        }

        #region CustomProperties

        /// <summary>
        /// Icono del cuadro de entrada
        /// </summary>
        public Image Icon16
        {
            get => Picture_Icon.Image;
            set => Picture_Icon.Image = value;
        }

        /// <summary>
        /// Título de la caja de entrada
        /// </summary>
        public string Title
        {
            get => Label_Title.Text;
            set => Label_Title.Text = value;
        }

        /// <summary>
        /// Determina si permite o no escribir en el control de entrada
        /// </summary>
        public bool InputEnabled
        {
            get => controlUsed.Enabled;
            set => controlUsed.Enabled = value;
        }


        /// <summary>
        /// Error visible en la interfaz de usuario
        /// </summary>
        public bool VisualError
        {
            get => visualError;
            set
            {
                visualError = value;
                Label_Title.Font = visualError ? new Font(Label_Title.Font, FontStyle.Bold) : new Font(Label_Title.Font, FontStyle.Regular);
                Label_Title.ForeColor = visualError ? Color.DarkRed : Color.FromKnownColor(KnownColor.ControlText);
            }
        }
        private bool visualError;

        /// <summary>
        /// Valor de entrada
        /// </summary>
        public T InputValue
        {
            set
            {
                switch (BoxType)
                {
                    case InputBoxType.Integer:
                    case InputBoxType.Money:
                        numericBox.Value = Convert.ToDecimal(value);
                        break;
                    default:
                        controlUsed.Text = Convert.ToString(value);
                        break;
                }
            }
            get
            {
                switch (BoxType)
                {
                    case InputBoxType.Integer:
                        return (T)(object)int.Parse(numericBox.Value.ToString());
                    case InputBoxType.Money:
                        return (T)(object)double.Parse(numericBox.Value.ToString());
                    default:
                        return (T)(object)controlUsed.Text;
                }
            }
        }
        #endregion

        private void InputBox_Generic_Validating(object sender, CancelEventArgs e)
        {
            if (DelegatePredicate != null)
            {
                bool result = !DelegatePredicate(InputValue);
                VisualError = result;
                e.Cancel = result;
            }
        }
    }
}
