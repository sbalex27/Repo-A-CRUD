using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Net.Http.Headers;
using System.Data;

namespace SalesApp_Alpha_2
{
    /// <summary>
    /// El campo representado por Enum no es válido
    /// </summary>
    [Serializable]
    public class InvalidFieldException : Exception
    {
        public InvalidFieldException() : base("Campo de propiedad no registrado en el contexto actual") { }
        public InvalidFieldException(string message) : base(message) { }
        public InvalidFieldException(string message, Exception inner) : base(message, inner) { }
        protected InvalidFieldException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class CrudListExceptions : Exception
    {
        public CrudListExceptions(List<Exception> exceptions)
        {
            ExceptionsList = exceptions;
        }
        public List<Exception> ExceptionsList { get; private set; }
    }

    /// <summary>
    /// Clase abstracta encargada de delegar objetos CRUD
    /// </summary>
    public abstract class CObjectCRUD : ICrud
    {
        #region Interface Implementation
        //Events
        public abstract event EventHandler<ECrud> Validating;
        public abstract event EventHandler<ECrud> Added;
        public abstract event EventHandler<ECrud> Updated;
        public abstract event EventHandler<ECrud> Deleted;

        //Basic Voids
        public abstract void Add();
        public abstract void Update();
        public abstract void Delete();
        #endregion

        #region AbstractsRegion
        /// <summary>
        /// Devuelve una lista de las propiedades activas del objeto
        /// empaquetadas para el uso SQL
        /// </summary>
        /// <returns></returns>
        protected abstract List<DataFieldTemplate> GetListDataFields();

        /// <summary>
        /// Devuelve una lista de las excepciones que contiene un objeto
        /// </summary>
        /// <returns></returns>
        public abstract List<Exception> GetListExceptions();

        /// <summary>
        /// Devuelve la propiedad empaquetada para el uso SQL
        /// </summary>
        /// <param name="Field">Campo de la propiedad a empaquetar</param>
        /// <returns>Retorna DataFieldTemplate</returns>
        /// <exception cref="InvalidFieldException"></exception>
        protected abstract DataFieldTemplate DataField(Enum Field);
        #endregion

        #region Events (voids) imported from database

        /// <summary>
        /// Método de respuesta de una adición a la Base de Datos
        /// </summary>
        protected abstract void DBAdded();

        /// <summary>
        /// Método de respuesta de una actualización a la Base de Datos
        /// </summary>
        protected abstract void DBUpdated();

        /// <summary>
        /// Método de respuesta de una eliminación a la Base de Datos
        /// </summary>
        protected abstract void DBDeleted();
        #endregion

        #region Statics
        /// <summary>
        /// Realiza una consulta en una tabla de la base de datos 
        /// y la devuelve en forma de tabla de tipo DataTable
        /// </summary>
        /// <param name="Table">Nombre de la tabla a consultar</param>
        /// <param name="Fields">Lista de parámetros a consultar</param>
        /// <param name="Filter">Filtro de la búsqueda</param>
        /// <param name="EmptyLoadAll">Si es verdadero y la búsqueda no devuelve
        /// ningún resultado, se cargan todos los datos de los parámetros asignados
        /// aunque no coincidan con la búsqueda</param>
        /// <returns></returns>
        protected static DataTable GetDataTable(SQLTable Table, List<Enum> Fields, DataFieldTemplate Filter, bool EmptyLoadAll = false)
        {
            //TODO: Probar funcionamiento EmptyLoadAll
            bool UseLike = false;
            if (Filter != null)
            {
                if (QFunctions.IsEmptyText(Filter.Value))
                {
                    Filter = null;
                }
                else
                {
                    if (Filter.TypeSQL == SQLValueType.SqlString)
                    {
                        UseLike = true;
                    }
                }
            }
            return Qsql.Select(Table, Fields, Filter, UseLike);
        }
        #endregion
    }

}