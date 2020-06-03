using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.CodeDom;
using System.Windows.Forms;

namespace SalesApp_Alpha_2
{
    /// <summary>
    /// Tipo de variable para procesar comandos SQL
    /// </summary>
    public enum SQLValueType
    {
        SqlString, 
        SqlInt, 
        SqlDouble,
        SqlNullFormat
    }

    /// <summary>
    /// Tablas registradas en la Base de Datos
    /// </summary>
    public enum SQLTable
    {
        Dailybox,
        Products,
        Purchases,
        Purchases_Details,
        Sales,
        Sales_Details
    };

    /// <summary>
    /// Clase de empaquetado de objetos para procesamiento SQL
    /// </summary>
    public class DataFieldTemplate
    {
        /// <summary>
        /// Instancia un nuevo empaquetado para utilizar como una comparación 
        /// lógica en una Query de SQL
        /// </summary>
        /// <param name="Field">Campo de la tabla</param>
        /// <param name="Value">Valor del campo</param>
        /// <param name="ValueType">Tipo de variable del campo</param>
        /// <param name="LikeOperator">Tipo de operador de búsqueda (False "=", True "Like")</param>
        /// <exception cref="ArgumentException"></exception>
        public DataFieldTemplate(Enum Field, object Value, SQLValueType ValueType, bool LikeOperator)
        {
            if (Field is null)
            {
                throw new ArgumentNullException(nameof(Field));
            }
            else this.Field = Field;

            if (Value is null)
            {
                throw new ArgumentNullException(nameof(Value));
            }
            else this.Value = Value;

            this.ValueType = ValueType;
            this.LikeOperator = LikeOperator;
        }

        /// <summary>
        /// Instancia un nuevo empaquetado para SQL
        /// </summary>
        /// <param name="Field">Campo de la tabla</param>
        /// <param name="Value">Valor del campo</param>
        /// <param name="ValueType">Tipo de variable del campo</param>
        /// <exception cref="EmptyInputException"></exception>
        public DataFieldTemplate(Enum Field, object Value, SQLValueType ValueType)
        {
            if (Field == null || Value == null) throw new EmptyInputException();

            this.Field = Field;
            this.Value = Value.ToString();
            this.ValueType = ValueType;
            LikeOperator = false;
        }

        /// <summary>
        /// Objeto enumerador que identifica el campo de la tabla
        /// </summary>
        public Enum Field { get; private set; }
        /// <summary>
        /// Valor del campo
        /// </summary>
        public object Value { get; private set; }
        /// <summary>
        /// Tipo de valor admitido por SQL para establecer el formato de <see cref="FormattedValue"/>
        /// </summary>
        public SQLValueType ValueType { get; private set; }
        /// <summary>
        /// Operador lógico de comparación [True = "Like"] [False = "="]
        /// </summary>
        public bool LikeOperator { get; private set; }
        /// <summary>
        /// Valor Formateado para comparación lógica en comando SQL
        /// <code>'%Apple%', 'Apple', 205, 15.25</code>
        /// </summary>
        public string FormattedValue
        {
            get
            {
                switch (ValueType)
                {
                    case SQLValueType.SqlString:
                        return LikeOperator ? $"'%{Value}%'" : $"'{Value}'";
                    default:
                        return Value.ToString();
                }
            }
        }

        /// <summary>
        /// Convierte el objeto actual en una condicional legible para la sintaxis de MySQL
        /// </summary>
        /// <returns>
        /// <code>ID = 25, Name = 'John', Description Like '%Apple%'</code>
        /// </returns>
        public override string ToString()
        {
            string Operator = LikeOperator ? "Like" : "=";
            return $"{Field} {Operator} {FormattedValue}";
        }
    }

    public static class Qsql
    {
        #region Properties
        private readonly static MySqlConnection sqlConnection = new MySqlConnection(Properties.Settings.Default.StringConnectionMySQL);
        private const string Comma = ", ";
        #endregion

        #region Events
        public delegate void QsqlEventHandler();
        public static event QsqlEventHandler InsertIntoSuccess;
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

        //Commands
        public static void InsertInto(SQLTable TableWork, List<DataFieldTemplate> FieldsAndValues)
        {
            //Command Generator
            string Fields = null;
            string Values = null;
            FillFieldsAndValues(FieldsAndValues, ref Fields, ref Values);
            string cmdText = $"Insert into {TableWork} ({Fields}) Values ({Values})";

            //Execute
            ExecuteNonQuery(cmdText);
            if (InsertIntoSuccess != null)
            {
                InsertIntoSuccess();
                InsertIntoSuccess = null;
            }
        }

        static void FillFieldsAndValues(List<DataFieldTemplate> DataFields, ref string Fields, ref string Values)
        {
            int i = 0;
            foreach (DataFieldTemplate Template in DataFields)
            {
                Fields += Template.Field;
                Values += Template.FormattedValue;
                if (++i != DataFields.Count)
                {
                    Fields += Comma;
                    Values += Comma;
                }
            }
        }

        public static void UpdateWhere(SQLTable TableWork,
                                       DataFieldTemplate FieldAndValue,
                                       DataFieldTemplate Conditional)
        {
            List<DataFieldTemplate> fieldTemplate = new List<DataFieldTemplate>() { FieldAndValue };
            UpdateWhere(TableWork, fieldTemplate, Conditional);
        }
        public static void UpdateWhere(SQLTable TableWork,
                                       List<DataFieldTemplate> FieldsAndValuesList,
                                       DataFieldTemplate Conditional)
        {
            //Variables Declaration
            int Lenght = FieldsAndValuesList.Count;
            string ToStrings = null;
            int i = 0;

            //Concatenate Command
            foreach (DataFieldTemplate item in FieldsAndValuesList)
            {
                i++;
                ToStrings += item.ToString();
                if (i != Lenght) ToStrings += Comma;
            }
            string cmdText = $"Update {TableWork} set {ToStrings} Where {Conditional}";

            //Execute
            ExecuteNonQuery(cmdText);
            if (UpdateSuccess != null)
            {
                UpdateSuccess();
                UpdateSuccess = null;
            }
        }

        public static void DeleteWhere(SQLTable TableWork, DataFieldTemplate DataFieldConditional)
        {
            string cmdText = $"Delete from {TableWork} Where {DataFieldConditional}";
            ExecuteNonQuery(cmdText);
            if (DeleteSucess != null)
            {
                DeleteSucess();
                DeleteSucess = null;
            }
        }

        public static List<object> Select(SQLTable Table,
                                          Enum Field = null,
                                          DataFieldTemplate Filter = null,
                                          bool EmptyLoadAll = false)
        {
            List<Enum> LField = new List<Enum> { Field };
            List<object> Items = new List<object>();
            DataTable Result = Select(Table, LField, Filter, EmptyLoadAll);
            foreach (DataRow row in Result.Rows)
            {
                Items.Add(row[0].ToString());
            }
            return Items;
        }

        public static DataTable Select(SQLTable Table,
                                       List<Enum> FieldsCollection,
                                       DataFieldTemplate Filter,
                                       bool EmptyLoadAll = false)
        {
            string Fields = FieldsCollection is null ? "*" : FieldsExpression(FieldsCollection);
            string Command = $"Select {Fields} From {Table}";
            if (Filter != null)
            {
                if (Filter.Value.ToString().Length == 0)
                {
                    if (!EmptyLoadAll) return null;
                }
                else Command += $" Where {Filter}";
            }
            DataTable dataTable = GetTable(Command);
            if (dataTable.Rows.Count == 0)
            {
                dataTable = null;
            }
            return dataTable;
        }

        public static DataTable Select(SQLTable Table, List<Enum> FieldsCollection)
        {
            return Select(Table, FieldsCollection, null);
        }

        public static DataTable Select(SQLTable Table)
        {
            return Select(Table, null);
        }

        public static string FieldsExpression(List<Enum> Fields)
        {
            int Lenght = Fields.Count;
            string Expression = null;
            int i = 0;

            foreach (Enum e in Fields)
            {
                Expression += e.ToString();
                if (++i != Lenght)
                {
                    Expression += Comma;
                }
            }
            return Expression;
        }

        static DataTable GetTable(string Command)
        {
            TryOpen();
            MySqlCommand sqlCommand = new MySqlCommand(Command, sqlConnection);
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable table = new DataTable();
            sqlDataAdapter.Fill(table);
            TryClose();
            return table;
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
