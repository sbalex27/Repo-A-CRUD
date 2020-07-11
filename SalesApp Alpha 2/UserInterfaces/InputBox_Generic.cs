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
        //public event EventHandler InputValueChanged;

        private Control ControlBase = new Control();
        private readonly TextBox ControlTextBox = new TextBox();
        private readonly ComboBox ControlComboBox = new ComboBox();
        private readonly NumericUpDown ControlNumericBox = new NumericUpDown();

        private readonly List<Type> AllowedTypes = new List<Type>()
        {
            typeof(string), typeof(double), typeof(object), typeof(int)
        };

        /// <summary>
        /// Constructor para una caja de entrada genérica
        /// </summary>
        /// <param name="title">Título de la caja</param>
        /// <param name="icon16px">Ícono de la caja</param>
        /// <param name="tabIndex">Índice de tabulación de la caja</param>
        public InputBox_Generic(string title, Image icon16px, int tabIndex = 0)
        {
            if (AllowedTypes.Contains(InputValueType))
            {
                InitializeComponent();
                Dock = DockStyle.Top;
                Title = title;
                Icon16 = icon16px;
                TabIndex = tabIndex;
                AutoDisableError = true;
                DrawVariant();
            }
            else throw new ArgumentException("Tipo de clase generica no admitida");
        }

        private void DrawVariant()
        {
            ControlBase = GetControlVariation();
            ControlBase.Dock = DockStyle.Top;
            Panel_Input.Controls.Add(ControlBase);
            ControlBase.TextChanged += ControlUsed_TextChanged;
        }

        private Control GetControlVariation()
        {
            switch (BoxType)
            {
                case InputBoxType.Text:
                    return ControlTextBox;
                case InputBoxType.Integer:
                case InputBoxType.Money:
                    return ControlNumericBox;
                default:
                    return ControlComboBox;
            }
        }

        private void ControlUsed_TextChanged(object sender, EventArgs e)
        {
            base.OnTextChanged(e);
        }

        public bool AutoDisableError { get; set; }
        public Predicate<T> DelegatePredicate { get; set; }
        public Action DelegateAction { get; set; }
        public delegate void BetaDelegateAction();

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
            get => ControlBase.Enabled;
            set => ControlBase.Enabled = value;
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
                        ControlNumericBox.Value = Convert.ToDecimal(value);
                        break;
                    default:
                        ControlBase.Text = Convert.ToString(value);
                        break;
                }
            }
            get
            {
                switch (BoxType)
                {
                    case InputBoxType.Integer:
                        return (T)(object)int.Parse(ControlNumericBox.Value.ToString());
                    case InputBoxType.Money:
                        return (T)(object)double.Parse(ControlNumericBox.Value.ToString());
                    default:
                        return (T)(object)ControlBase.Text;
                }
            }
        }
        #endregion

        private void InputBox_Generic_Validated(object sender, EventArgs e)
        {
            if (AutoDisableError)
            {
                VisualError = false;
                DelegateAction?.Invoke();
            }
        }

        private void InputBox_Generic_Validating(object sender, CancelEventArgs e)
        {
            if (DelegatePredicate != null)
            {
                if (!DelegatePredicate.Invoke(InputValue))
                {
                    VisualError = true;
                    e.Cancel = true;
                }
            }
        }

        public override void ResetText()
        {
            switch (BoxType)
            {
                case InputBoxType.Integer:
                case InputBoxType.Money:
                    ControlNumericBox.Value = Convert.ToDecimal(0);
                    break;
                default:
                    ControlBase.Text = string.Empty;
                    break;
            }
        }

        public new bool Enabled
        {
            get => ControlBase.Enabled;
            set => ControlBase.Enabled = value;
        }
    }
}
