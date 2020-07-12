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
        private Control ControlBase = new Control();
        private readonly TextBox ControlTextBox = new TextBox();
        private readonly ComboBox ControlComboBox = new ComboBox();
        private readonly NumericUpDown ControlNumericBox = new NumericUpDown()
        {
            Minimum = 0,
            Maximum = 1000
        };

        private readonly List<Type> AllowedTypes = new List<Type>()
        {
            typeof(string), typeof(double), typeof(int), typeof(object)
        };

        private readonly Dictionary<Type, InputBoxType> KeyValuesTypes = new Dictionary<Type, InputBoxType>()
        {
            {typeof(string), InputBoxType.Text },
            {typeof(double), InputBoxType.Money },
            {typeof(int), InputBoxType.Integer },
            {typeof(object), InputBoxType.Collection }
        };

        private Dictionary<InputBoxType, Control> KeyValuesControls => new Dictionary<InputBoxType, Control>()
        {
            {InputBoxType.Text, ControlTextBox },
            {InputBoxType.Money, ControlNumericBox },
            {InputBoxType.Integer, ControlNumericBox },
            {InputBoxType.Collection, ControlComboBox }
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
                InitializeVariant();
            }
            else throw new ArgumentException("Tipo de clase generica no admitida");
        }

        private void InitializeVariant()
        {
            KeyValuesControls.TryGetValue(BoxType, out Control ctrl);
            ControlBase = ctrl;
            ControlBase.Dock = DockStyle.Top;
            Panel_Input.Controls.Add(ControlBase);
            ControlBase.TextChanged += ControlUsed_TextChanged;
        }

        #region CustomProperties

        /// <summary>
        /// Obtiene o establece la instrucción de establecer automáticamente el estado
        /// <see cref="VisualError"/> a <see langword="false"/> al invocarse su evento
        /// <see cref="Control.Validated"/>
        /// </summary>
        public bool AutoDisableError { get; set; }

        /// <summary>
        /// Obtiene o establece el delegado predicado que se utilizará en la verificación
        /// del evento <see cref="Control.Validating"/> para la posterior invocación del
        /// evento <see cref="Control.Validated"/>
        /// </summary>
        public Predicate<T> DelegatePredicate { get; set; }

        /// <summary>
        /// Obtiene o establece la acción que se realizará dentro del evento <see cref="Control.Validated"/>
        /// </summary>
        public Action DelegateAction { get; set; }

        /// <summary>
        /// Obtiene el <see cref="Type"/> de <see cref="T"/>
        /// </summary>
        public Type InputValueType => typeof(T);

        /// <summary>
        /// Obtiene el tipo de caja que se ha instanciado mediante un <see cref="Enum"/>
        /// </summary>
        public InputBoxType BoxType
        {
            get
            {
                KeyValuesTypes.TryGetValue(InputValueType, out InputBoxType Value);
                return Value;
            }
        }

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

        private void ControlUsed_TextChanged(object sender, EventArgs e)
        {
            base.OnTextChanged(e);
        }

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

        /// <summary>
        /// Establece una fuente de datos para una caja <see cref="InputBox_Generic{T}"/>
        /// donde <see cref="T"/> es de tipo <see cref="object"/>
        /// </summary>
        /// <param name="dataSource">Establece la propiedad <see cref="ComboBox.DataSource"/></param>
        /// <param name="displayMember">Establece la propiedad <see cref="ListControl.DisplayMember"/></param>
        /// <param name="valueMember">Establece la propiedad de <see cref="ListControl.ValueMember"/></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void SetDataSource(object dataSource, string displayMember = null, string valueMember = null)
        {
            if (BoxType.Equals(InputBoxType.Collection))
            {
                ControlComboBox.DataSource = dataSource;
                ControlComboBox.DisplayMember = displayMember;
                ControlComboBox.ValueMember = valueMember;
                ControlComboBox.SelectedIndex = -1;
            }
            else throw new InvalidOperationException("No se puede aplicar la fuente de datos");
        }

        /// <summary>
        /// Establece un rango numérico para una caja donde <see cref="T"/> sea de tipo <see cref="object"/>
        /// </summary>
        /// <param name="MinValue">Establece la propiedad <see cref="NumericUpDown.Minimum"/></param>
        /// <param name="MaxValue">Establece la propiedad <see cref="NumericUpDown.Maximum"/></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void SetNumericalRange(T MinValue, T MaxValue)
        {
            bool equals(InputBoxType t) => BoxType.Equals(t);
            if (equals(InputBoxType.Integer) || equals(InputBoxType.Money))
            {
                decimal min = Convert.ToDecimal(MinValue);
                decimal max = Convert.ToDecimal(MaxValue);
                if (min < max)
                {
                    ControlNumericBox.Minimum = min;
                    ControlNumericBox.Maximum = max;
                }
                else throw new ArgumentException("El valor mínimo tiene que ser menor que el máximo");
            }
            else throw new InvalidOperationException("No se puede establecer un rango numérico a este tipo de caja de entrada");
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
            VisualError = false;
        }

        public override string ToString()
        {
            return $"{BoxType} - {Title}: {InputValue}";
        }

        public new bool Enabled
        {
            get => ControlBase.Enabled;
            set => ControlBase.Enabled = value;
        }
    }
}
