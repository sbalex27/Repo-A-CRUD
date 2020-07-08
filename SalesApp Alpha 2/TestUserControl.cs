using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesApp_Alpha_2.UserInterfaces;
using MySql.Data;

namespace SalesApp_Alpha_2
{
    public partial class TestUserControl : UserControl
    {
        #region Variables
        private readonly InputBox_Generic<string> Box_Nombre;
        private readonly InputBox_Generic<string> Box_Apellido;
        private readonly InputBox_Generic<int> Box_Edad;
        private readonly InputBox_Generic<double> Box_Sueldo;
        private readonly InputBox_Generic<object> Box_Area;
        private readonly Padding customPadding = new Padding(0, 3, 0, 3);
        #endregion

        public TestUserControl()
        {
            InitializeComponent();

            #region Instances
            Box_Nombre = new InputBox_Generic<string>("Nombre", Properties.Resources.icons8_archivo_de_imagen_16)
            {
                Padding = customPadding,
                DelegatePredicate = new Predicate<string>(s => !string.IsNullOrWhiteSpace(s)),
            };
            Box_Apellido = new InputBox_Generic<string>("Apellido", Properties.Resources.icons8_añadir_16);
            Box_Edad = new InputBox_Generic<int>("Edad", Properties.Resources.icons8_búsqueda_16__1_);
            Box_Sueldo = new InputBox_Generic<double>("Sueldo", Properties.Resources.icons8_carrito_de_la_compra_cargado_16);
            Box_Area = new InputBox_Generic<object>("Área", Properties.Resources.icons8_de_acuerdo_16);
            #endregion

            Controls.AddRange(new Control[]
            {
                Box_Area,
                Box_Sueldo,
                Box_Edad,
                Box_Apellido,
                Box_Nombre
            });

            AutoSize = true;
        }

        private void Box_Nombre_Validated(object sender, EventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        public void DisableVisualErrors()
        {
            Box_Nombre.VisualError = false;
            Box_Apellido.VisualError = false;
            Box_Edad.VisualError = false;
            Box_Sueldo.VisualError = false;
            Box_Area.VisualError = false;
        }
    }
}
