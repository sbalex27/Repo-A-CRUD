using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesApp_Alpha_2
{
    /// <summary>
    /// Método delegado para control de eventos generados por objeto CRUD
    /// </summary>
    /// <param name="sender">Objeto CRUD</param>
    /// <param name="Action">Acción descriptiva evento</param>
    /// <param name="AffectedsRecords">Número de registros involucrados</param>
    public delegate void CrudEventHandler(object sender, string Action, int AffectedsRecords);

    /// <summary>
    /// Interfaz que delega funciones básicas de un objeto CRUD
    /// </summary>
    public interface ICrud
    {
        /// <summary>
        /// Evento que se lanza al validar el objeto
        /// </summary>
        event EventHandler<string> Validating;

        /// <summary>
        /// Evento que se lanza al añadir el objeto
        /// </summary>
        event CrudEventHandler Added;

        /// <summary>
        /// Evento que se lanza al actualizar el objeto
        /// </summary>
        event CrudEventHandler Updated;

        /// <summary>
        /// Evento que se lanza al eliminar el objeto
        /// </summary>
        event CrudEventHandler Deleted;

        /// <summary>
        /// Añade objeto a la Base de Datos
        /// </summary>
        void Add();

        /// <summary>
        /// Actualiza el objeto en la Base de Datos
        /// </summary>
        void Update();

        /// <summary>
        /// Elimina el objeto de la Base de Datos
        /// </summary>
        void Delete();
    }
}