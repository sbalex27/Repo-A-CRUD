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
                _icon = MessageBoxIcon.None;
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
