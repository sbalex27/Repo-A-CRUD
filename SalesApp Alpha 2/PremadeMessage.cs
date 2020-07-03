using SalesApp_Alpha_2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static SalesApp_Alpha_2.QFunctions;

namespace SalesApp_Alpha_2
{
    static class PremadeMessage
    {
        static string _title;
        static string _caption;
        static MessageBoxButtons _buttons;
        static MessageBoxIcon _icon;

        /// <summary>
        /// Si está activada la opción de mostrar un mensaje por cada acción entonces
        /// muestra un mensaje de información de la acción del objeto
        /// </summary>
        /// <param name="o">Objeto en cuestión</param>
        /// <param name="arg">Acción del objeto</param>
        public static void ObjectAction(object o, string arg, int affected = 0)
        {
            if (Settings.Default.MessageForEachAction)
            {
                _title = arg;
                _caption = $"{affected} {arg}: {o}";
                _buttons = MessageBoxButtons.OK;
                _icon = MessageBoxIcon.Information;
                Show();
            }
        }

        public static bool YesNo(string Caption)
        {
            DialogResult result = MessageBox.Show(Caption, "¿Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return true;
            } else return false;
        }

        public static void Notification(string Caption, string Title)
        {
            _title = Title;
            _caption = Caption;
            _buttons = MessageBoxButtons.OK;
            _icon = MessageBoxIcon.Information;
            Show();
        }

        public static void Notification(string Caption)
        {
            _title = "Notificación";
            _caption = Caption;
            _buttons = MessageBoxButtons.OK;
            _icon = MessageBoxIcon.Information;
            Show();
        }

        //public static void PMFormatException(string InvalidValue = "")
        //{
        //    _title = "El formato es incorrecto";
        //    _caption = "No se permiten el ingreso de estos valores";
        //    if (!IsEmptyText(InvalidValue)) { _caption += " - " + InvalidValue; }
        //    _buttons = MessageBoxButtons.OK;
        //    _icon = MessageBoxIcon.Exclamation;

        //    Show();
        //}

        //public static void PMFatalException()
        //{
        //    _title = "Error";
        //    _caption = "Ha ocurrido un error intentelo de nuevo";
        //    _buttons = MessageBoxButtons.OK;
        //    _icon = MessageBoxIcon.Error;

        //    Show();
        //}

        //public static void PMDataBaseException(int ExceptionNumber = 0)
        //{
        //    switch (ExceptionNumber)
        //    {
        //        case (int)MySqlExceptionList.VeryLong:
        //            _caption = "El valor es demasiado largo";
        //            break;

        //        default:
        //            _caption = "Ha ocurrido un error al manipular la base de datos, reintente";
        //            break;
        //    }
        //    _title = "Base de Datos";
        //    _buttons = MessageBoxButtons.OK;
        //    _icon = MessageBoxIcon.Error;
        //    Show();
        //}

        private static void Show()
        {
            MessageBox.Show(_caption, _title, _buttons, _icon);
        }

        private enum MySqlExceptionList
        {
            VeryLong = 1406
        } 
    }
}
