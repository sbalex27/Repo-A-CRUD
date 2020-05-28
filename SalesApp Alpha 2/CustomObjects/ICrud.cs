using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesApp_Alpha_2
{
    public delegate void EventHandler(object sender, ECrud e);

    /// <summary>
    /// Clase hija de EventArgs encargada de gestionar las acciones
    /// de un objeto CRUD
    /// </summary>
    public class ECrud : EventArgs
    {
        /// <summary>
        /// Constructor de la gestion de un nuevo argumento
        /// </summary>
        /// <param name="action">Acción del objeto CRUD</param>
        public ECrud(string action)
        {
            Action = action;
        }

        /// <summary>
        /// Acción del objeto CRUD
        /// </summary>
        public string Action { get; private set; }
    }

    /// <summary>
    /// Interfaz que delega funciones básicas de un objeto CRUD
    /// </summary>
    public interface ICrud
    {
        /// <summary>
        /// Evento que se lanza al validar el objeto
        /// </summary>
        event EventHandler<ECrud> Validating;

        /// <summary>
        /// Evento que se lanza al añadir el objeto
        /// </summary>
        event EventHandler<ECrud> Added;

        /// <summary>
        /// Evento que se lanza al actualizar el objeto
        /// </summary>
        event EventHandler<ECrud> Updated;

        /// <summary>
        /// Evento que se lanza al eliminar el objeto
        /// </summary>
        event EventHandler<ECrud> Deleted;

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

        /// <summary>
        /// Analiza cada una de las posibles excepciones del objeto
        /// </summary>
        /// <returns><see cref="List{T}"/> de tipo <see cref="Exception"/></returns>
        List<Exception> GetListExceptions();
    }
}