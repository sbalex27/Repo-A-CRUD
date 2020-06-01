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
        /// <param name="Val">Valor del campo</param>
        /// <param name="ValueType">Typo de variable del campo</param>
        /// <param name="LikeOperator">Tipo de operador de búsqueda (False "=", True "Like")</param>
        /// <exception cref="ArgumentException"></exception>
        public DataFieldTemplate(object Field, object Val, SQLValueType ValueType, bool LikeOperator)
        {
            if (Field is null)
            {
                throw new ArgumentNullException(nameof(Field));
            }
            else this.Field = Field.ToString();

            if (Val is null)
            {
                throw new ArgumentNullException(nameof(Val));
            }
            else this.Value = Val.ToString();

            this.ValueType = ValueType;
            this.LikeOperator = LikeOperator;
        }

        /// <summary>
        /// Instancia un nuevo empaquetado para SQL
        /// </summary>
        /// <param name="Field">Campo de la tabla</param>
        /// <param name="Val">Valor del campo</param>
        /// <param name="ValueType">Tipo de variable del campo</param>
        /// <exception cref="EmptyInputException"></exception>
        public DataFieldTemplate(object Field, object Val, SQLValueType ValueType)
        {
            if (Field == null || Val == null) throw new EmptyInputException();

            this.Field = Field.ToString();
            this.Value = Val.ToString();
            this.ValueType = ValueType;
            LikeOperator = false;
        }
        /// <summary>
        /// Instancia un nuevo empaquetado para SQL valor/formato <see cref="SQLValueType.SqlNullFormat"/>
        /// </summary>
        /// <param name="Field">Campo de la tabla</param>
        public DataFieldTemplate(object Field)
        {
            if (Field is null)
            {
                throw new ArgumentNullException(nameof(Field));
            }
            else
            {
                this.Field = Field.ToString();
                Value = "Null";
                ValueType = SQLValueType.SqlNullFormat;
                LikeOperator = false;
            }
        }

        public string Field { get; private set; }
        public string Value { get; private set; }
        public SQLValueType ValueType { get; private set; }
        public bool LikeOperator { get; private set; }

        //public Type Type
        //{
        //    get
        //    {
        //        switch (TypeSQL)
        //        {
        //            case SQLValueType.SqlString:
        //                return typeof(string);
        //            case SQLValueType.SqlInt:
        //                return typeof(int);
        //            case SQLValueType.SqlDouble:
        //                return typeof(double);
        //            case SQLValueType.SqlNullFormat:
        //                return typeof(object);

        //            default:
        //                throw new Exception("No aviable Type");
        //        }
        //    }
        //}

        public override string ToString()
        {
            string Operator = LikeOperator ? "Like" : "=";
            return $"{Field} {Operator} {ConvertedValue()}";
        }

        //public string ToString(bool UseLike)
        //{
        //    if (UseLike)
        //    {
        //        Value = $"%{Value}%";
        //        return $"{Field} Like {ConvertedValue()}";
        //    }
        //    else return ToString();
        //}

        public string ConvertedValue()
        {
            switch (ValueType)
            {
                case SQLValueType.SqlString:
                    return LikeOperator ? $"'%{Value}%'" : $"'{Value}'";
                case SQLValueType.SqlInt:
                    return Value.ToString();
                case SQLValueType.SqlDouble:
                    return Value.ToString();
                case SQLValueType.SqlNullFormat:
                    return Value.ToString();
                default:
                    return Value.ToString();
            }
        }
    }

    public static class Qsql
    {
        //Static Properties
        private readonly static MySqlConnection sqlConnection = new MySqlConnection(Properties.Settings.Default.StringConnectionMySQL);
        private const string Comma = ", ";


        //Events
        public delegate void QsqlEventHandler();
        public static event QsqlEventHandler InsertIntoSuccess;
        public static event QsqlEventHandler UpdateSuccess;
        public static event QsqlEventHandler DeleteSucess;

        //Shorcuts
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

        public static void CmdExecuteNonQuery(string CommandText)
        {
            TryOpen();
            MySqlCommand mySqlCommand = new MySqlCommand(CommandText, sqlConnection);
            mySqlCommand.ExecuteNonQuery();
            TryClose();
        }

        //Commands
        public static void InsertInto(SQLTable TableWork, List<DataFieldTemplate> FieldsAndValues)
        {
            //Variables Declaration
            int Lenght = FieldsAndValues.Count;
            string Fields = null;
            string Values = null;
            int i = 0;

            //Command Generator
            foreach (DataFieldTemplate item in FieldsAndValues)
            {
                i++;
                Fields += item.Field;
                Values += item.ConvertedValue();
                if (i != Lenght)
                {
                    Fields += Comma;
                    Values += Comma;
                }
            }
            string cmdText = $"Insert into {TableWork} ({Fields}) Values ({Values})";

            //Execute
            CmdExecuteNonQuery(cmdText);
            if (InsertIntoSuccess != null)
            {
                InsertIntoSuccess();
                InsertIntoSuccess = null;
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
            CmdExecuteNonQuery(cmdText);
            if (UpdateSuccess != null)
            {
                UpdateSuccess();
                UpdateSuccess = null;
            }
        }

        public static void DeleteWhere(SQLTable TableWork, DataFieldTemplate DataFieldConditional)
        {
            string cmdText = $"Delete from {TableWork} Where {DataFieldConditional}";
            CmdExecuteNonQuery(cmdText);
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
                if (Filter.Value.Length == 0)
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
