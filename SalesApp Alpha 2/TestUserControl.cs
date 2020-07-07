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
        private InputBox_Generic<string> Box_Nombre;
        private InputBox_Generic<string> Box_Apellido;
        private InputBox_Generic<int> Box_Edad;
        private InputBox_Generic<double> Box_Sueldo;
        private InputBox_Generic<object> Box_Area;
        private Padding padding = new Padding(0, 3, 0, 3);
        #endregion

        public TestUserControl()
        {
            InitializeComponent();

            SuspendLayout();

            #region Instances
            Box_Nombre = new InputBox_Generic<string>("Nombre", Properties.Resources.icons8_archivo_de_imagen_16, padding);
            Box_Apellido = new InputBox_Generic<string>("Apellido", Properties.Resources.icons8_añadir_16, padding);
            Box_Edad = new InputBox_Generic<int>("Edad", Properties.Resources.icons8_búsqueda_16__1_, padding);
            Box_Sueldo = new InputBox_Generic<double>("Sueldo", Properties.Resources.icons8_carrito_de_la_compra_cargado_16, padding);
            Box_Area = new InputBox_Generic<object>("Área", Properties.Resources.icons8_de_acuerdo_16, padding);
            #endregion

            #region Display Instances
            Controls.Add(Box_Area);
            Controls.Add(Box_Sueldo);
            Controls.Add(Box_Edad);
            Controls.Add(Box_Apellido);
            Controls.Add(Box_Nombre);
            #endregion

            AutoSize = true;
            ResumeLayout(false);
        }


    }
}
