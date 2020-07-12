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
using System.Runtime.Remoting.Channels;

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
    public abstract class CObjectCRUD<TEnum> : ICrud
    {
        #region Interface Implementation
        //Events
        //public abstract event EventHandler<string> Validating;
        public abstract event CrudEventHandler Added;
        public abstract event CrudEventHandler Updated;
        public abstract event CrudEventHandler Deleted;

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
        /// Devuelve la propiedad empaquetada para el uso SQL
        /// </summary>
        /// <param name="Field">Campo de la propiedad a empaquetar</param>
        /// <returns>Retorna DataFieldTemplate</returns>
        /// <exception cref="InvalidFieldException"></exception>
        protected abstract DataFieldTemplate GetDataField(TEnum Field);

        #endregion

        #region Statics
        /// <summary>
        /// Realiza una consulta en una tabla de la base de datos 
        /// y la devuelve en forma de tabla de tipo DataTable
        /// </summary>
        /// <param name="Table">Nombre de la tabla a consultar</param>
        /// <param name="ListFields">Lista de parámetros a consultar</param>
        /// <param name="Filter">Filtro de la búsqueda</param>
        /// <param name="OrderBy">Si es verdadero y la búsqueda no devuelve
        /// ningún resultado, se cargan todos los datos de los parámetros asignados
        /// aunque no coincidan con la búsqueda</param>
        /// <returns></returns>
        protected static DataTable GetDataTable(SQLTable Table,
                                                List<TEnum> ListFields,
                                                DataFieldTemplate Filter,
                                                bool UnconditionalReturnsAll,
                                                TEnum OrderBy)
        {
            Select<TEnum> S = new Select<TEnum>(ListFields, Table)
            {
                Conditional = Filter,
                OrderByField = OrderBy
            };
            return !UnconditionalReturnsAll && !S.IsConditionable ? null : S.ExecuteSelect();
        }

        protected static DataTable GetDataTable(SQLTable Table, List<TEnum> ListFields, DataFieldTemplate Filter, bool UnconditionalReturnsAll)
        {
            return GetDataTable(Table, ListFields, Filter, UnconditionalReturnsAll, ListFields[0]);
        }

        protected static DataTable GetDataTable(SQLTable Table, List<TEnum> ListFields)
        {
            return GetDataTable(Table, ListFields, null, false);
        }

        /// <summary>
        /// Ejecuta una interacción con la base de datos sin retornar ningún resultado directamente
        /// y prepara un método para recibir al evento de interacción
        /// </summary>
        /// <param name="dbInteraction">Interacción a ejecutar</param>
        protected void ActionNonQuery(DataBaseInteraction dbInteraction)
        {
            dbInteraction.Interaction += DBInteraction;
            dbInteraction.ExecuteNonQuery();
        }

        /// <summary>
        /// Recibe el evento <see cref="DataBaseInteraction.Interaction"/> e invoca el
        /// <see cref="DataBaseInteraction.SecondaryEvent"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="AffectedRows"></param>
        /// <param name="secondaryEvent"></param>
        private void DBInteraction(DataBaseInteraction sender, int AffectedRows, CrudEventHandler secondaryEvent)
        {
            secondaryEvent?.Invoke(this, sender.CommandDescription, AffectedRows);
        }
        #endregion
    }

}