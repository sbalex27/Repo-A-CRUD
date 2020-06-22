using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SalesApp_Alpha_2
{
    public static class Qsql
    {
        #region Properties
        private readonly static MySqlConnection sqlConnection = new MySqlConnection(Properties.Settings.Default.StringConnectionMySQL);
        private const string Comma = ", ";
        #endregion

        #region Events
        public delegate void QsqlEventHandler();
        //public static event QsqlEventHandler InsertIntoSuccess;
        public static event QsqlEventHandler UpdateSuccess;
        public static event QsqlEventHandler DeleteSucess;
        #endregion

        #region DataBase Open-Close
        private static void TryOpen()
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();
            }
            catch (MySqlException)
            {
                throw new QsqlConnectionException();
            }
        }
        private static void TryClose()
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
            }
            catch (MySqlException)
            {
                throw new QsqlConnectionException();
            }
        }
        #endregion

        private static void ExecuteNonQuery(string CommandText)
        {
            TryOpen();
            MySqlCommand mySqlCommand = new MySqlCommand(CommandText, sqlConnection);
            mySqlCommand.ExecuteNonQuery();
            TryClose();
        }

        /// <summary>
        /// Actualiza el valor de un campo de una tabla en la Base de Datos
        /// si cumple con el parámetro de condición
        /// </summary>
        /// <param name="TableWork">Tabla a trabajar</param>
        /// <param name="FieldAndValue">Empaquetado MySql con el nuevo valor</param>
        /// <param name="Conditional">Parámetro de condición</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void UpdateWhere(SQLTable TableWork,
                                       DataFieldTemplate FieldAndValue,
                                       DataFieldTemplate Conditional)
        {
            //Validation
            if (FieldAndValue is null) throw new ArgumentNullException(nameof(FieldAndValue));

            //Call Update
            List<DataFieldTemplate> Template = new List<DataFieldTemplate>() { FieldAndValue };
            UpdateWhere(TableWork, Template, Conditional);
        }
        /// <summary>
        /// Actualiza valores de un registro en la base de datos si cumple con el
        /// parámetro de condición
        /// </summary>
        /// <param name="TableWork">Tabla a trabajar</param>
        /// <param name="FieldsAndValuesList">Lista de empaquetados MySQL con los nuevos valores</param>
        /// <param name="Conditional">Parámetro de condición</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void UpdateWhere(SQLTable TableWork,
                                       List<DataFieldTemplate> FieldsAndValuesList,
                                       DataFieldTemplate Conditional)
        {
            //Validation
            if (Conditional is null) throw new ArgumentNullException(nameof(Conditional));
            
            //Command
            string NewStrings = DataFieldTemplate.JoinCollection(FieldsAndValuesList);
            string Command = $"Update {TableWork} set {NewStrings} Where {Conditional}";

            //Execute
            ExecuteNonQuery(Command);

            //Event
            if (UpdateSuccess != null)
            {
                UpdateSuccess();
                UpdateSuccess = null;
            }
        }

        /// <summary>
        /// Elimina un los registros de la base de datos si cumplen con la condicional
        /// </summary>
        /// <param name="TableWork">Tabla a trabajar</param>
        /// <param name="Conditional">Parámetro de condición</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void DeleteWhere(SQLTable TableWork, DataFieldTemplate Conditional)
        {
            //Validation
            if (Conditional is null) throw new ArgumentNullException(nameof(Conditional));
            //Command
            string cmdText = $"Delete from {TableWork} Where {Conditional}";
            //Execute
            ExecuteNonQuery(cmdText);
            //Event
            if (DeleteSucess != null)
            {
                DeleteSucess();
                DeleteSucess = null;
            }
        }
    }

    #region DataBase Exceptions
    [Serializable]
    public class QsqlConnectionException : Exception
    {
        public QsqlConnectionException() : base("No se puede conectar a la base de datos") { }
        public QsqlConnectionException(string message) : base(message) { }
        public QsqlConnectionException(string message, Exception inner) : base(message, inner) { }
        protected QsqlConnectionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    #endregion
}
