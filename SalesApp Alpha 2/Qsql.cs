using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

    public enum SQLOperator
    {
        Like,
        Equal,
        Between
    }

    /// <summary>
    /// Clase de empaquetado de objetos para procesamiento SQL
    /// </summary>
    public class DataFieldTemplate
    {
        //private const string Comma = ", ";

        /// <summary>
        /// Instancia un nuevo empaquetado para utilizar como una comparación 
        /// lógica en una Query de SQL
        /// </summary>
        /// <param name="Field">Campo de la tabla</param>
        /// <param name="Value">Valor del campo</param>
        /// <param name="ValueType">Tipo de variable del campo</param>
        /// <param name="Operator">Tipo de operador de búsqueda (False "=", True "Like")</param>
        /// <exception cref="ArgumentException"></exception>
        public DataFieldTemplate(Enum Field, object Value, SQLValueType ValueType, SQLOperator Operator)
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
            this.Operator = Operator;
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
            Operator = SQLOperator.Equal;
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
        /// Operador lógico de comparación
        /// </summary>
        public SQLOperator Operator { get; private set; }

        /// <summary>
        /// Operador lógico de comparación en formato de cadena de texto <see cref="string"/>
        /// </summary>
        public string OperatorStringable
        {
            get
            {
                Dictionary<SQLOperator, string> Stringable = new Dictionary<SQLOperator, string>
                {
                    {SQLOperator.Equal, "=" },
                    {SQLOperator.Like, "Like" },
                    {SQLOperator.Between, "Between" }
                };

                return Stringable[Operator];
            }
        }
        
        ///// <summary>
        ///// Operador lógico de comparación [True = "Like"] [False = "="]
        ///// </summary>
        //public bool LikeOperator { get; private set; }

        ///// <summary>
        ///// Valor formateado para obtener la cadena del uno de los operadores
        ///// <code>Like = </code>
        ///// </summary>
        //public string FormattedOperator
        //{
        //    get => LikeOperator ? "Like" : "=";
        //}


        /// <summary>
        /// Valor Formateado para comparación lógica en comando SQL
        /// <code>'%Apple%', 'Apple', 205, 15.25</code>
        /// </summary>
        public string FormattedValue
        {
            get
            {
                if (IsStringable)
                {
                    switch (ValueType)
                    {
                        case SQLValueType.SqlString:
                            return Operator == SQLOperator.Like ? $"'%{Value}%'" : $"'{Value}'";
                        default:
                            return Value.ToString();
                    }
                }
                else return "null";
            }
        }
        /// <summary>
        /// Analiza el estado del valor del campo y retorna <see langword="true"/> si no es nulo o si no está vacío.
        /// </summary>
        public bool IsStringable
        {
            get => !string.IsNullOrWhiteSpace(Value?.ToString());
        }

        /// <summary>
        /// Convierte el objeto actual en una condicional legible para la sintaxis de MySQL
        /// </summary>
        /// <returns>
        /// <code>ID = 25, Name = 'John', Description Like '%Apple%'</code>
        /// </returns>
        public override string ToString()
        {
            return $"{Field} {OperatorStringable} {FormattedValue}";
        }

        #region Statics
        /// <summary>
        /// Recibe y concatena la lista en valores obtenidos de <see cref="ToString"/>
        /// </summary>
        /// <param name="List">Lista a procesar</param>
        /// <returns>Valores concatenados</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string ConcatenateToStrings(List<DataFieldTemplate> List)
        {
            if (List is null || List.Count == 0) throw new ArgumentNullException(nameof(List));
            return string.Join<DataFieldTemplate>(", ", List.ToArray());
        }
        /// <summary>
        /// Concatena una lista en valores obtenidos de <see cref="FormattedValue"/>
        /// </summary>
        /// <param name="List">Lista a procesar</param>
        /// <returns>Valores concatenados</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string ConcatenateValues(List<DataFieldTemplate> List)
        {
            if (List is null) throw new ArgumentNullException(nameof(List));
            List<object> FormattedValues = new List<object>();
            foreach (DataFieldTemplate item in List)
            {
                FormattedValues.Add(item.FormattedValue);
            }
            return string.Join(", ", FormattedValues);
        }
        /// <summary>
        /// Concatena una lista en valores obtenidos de <see cref="Field"/>
        /// </summary>
        /// <param name="List">Lista a procesar</param>
        /// <returns>Valores concatenados</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string ConcatenateFields(List<DataFieldTemplate> List)
        {
            if (List is null || List.Count == 0) throw new ArgumentNullException(nameof(List));
            List<Enum> Fields = new List<Enum>();
            foreach (DataFieldTemplate item in List)
            {
                Fields.Add(item.Field);
            }
            return string.Join(", ", Fields);
        }
        /// <summary>
        /// Procesa una lista y concatena en dos cadenas de texto distintas las propiedades
        /// de <see cref="Field"/> y <see cref="FormattedValue"/>
        /// </summary>
        /// <param name="List">Lista a procesar</param>
        /// <param name="Fields">Valor de salida de <see cref="Field"/> concatenados</param>
        /// <param name="FormattedValues">Valor de salida de <see cref="FormattedValue"/> concatenados</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ConcatenateFieldsValues(List<DataFieldTemplate> List, out string Fields, out string FormattedValues)
        {
            if (List is null || List.Count == 0) throw new ArgumentNullException(nameof(List));
            Fields = ConcatenateFields(List);
            FormattedValues = ConcatenateValues(List);
        }
        #endregion
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

        /// <summary>
        /// Inserta dentro de una tabla de la base de datos un objeto <see cref="DataFieldTemplate"/>
        /// </summary>
        /// <param name="TableWork">Tabla en la que se insertará el registro</param>
        /// <param name="FieldsAndValues">Empaquetado MySQL para insertar</param>
        public static void InsertInto(SQLTable TableWork, List<DataFieldTemplate> FieldsAndValues)
        {
            //Command Generator
            DataFieldTemplate.ConcatenateFieldsValues(FieldsAndValues, out string Fields, out string Values);
            string Command = $"Insert into {TableWork} ({Fields}) Values ({Values})";

            //Execute
            ExecuteNonQuery(Command);
            if (InsertIntoSuccess != null)
            {
                InsertIntoSuccess();
                InsertIntoSuccess = null;
            }
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
            string NewStrings = DataFieldTemplate.ConcatenateToStrings(FieldsAndValuesList);
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

        //#region Select

        //public static List<object> Select(SQLTable Table,
        //                                  Enum Field = null,
        //                                  DataFieldTemplate Filter = null)
        //{
        //    List<Enum> LField = new List<Enum> { Field };
        //    List<object> Items = new List<object>();
        //    DataTable Result = Select(Table, LField, Filter, null);
        //    foreach (DataRow row in Result.Rows)
        //    {
        //        Items.Add(row[0].ToString());
        //    }
        //    return Items;
        //}

        //public static DataTable Select(SQLTable Table,
        //                               List<Enum> FieldsCollection,
        //                               DataFieldTemplate Conditional,
        //                               Enum OrderByField)
        //{
        //    //Var
        //    string Fields = FieldsCollection is null ? "*" : FieldsExpression(FieldsCollection);
        //    string Command = $"Select {Fields} From {Table}";

        //    //Conditional
        //    if (!string.IsNullOrWhiteSpace(Conditional?.Value.ToString()))
        //    {
        //        Command += $" Where {Conditional}";
        //    }

        //    //Order By
        //    if (OrderByField != null)
        //    {
        //        Command += $" Order By {OrderByField}";
        //    }

        //    //Execute
        //    return GetTable(Command);
        //}

        //public static DataTable Select(SQLTable Table, List<Enum> FieldsCollection, DataFieldTemplate Conditional)
        //{
        //    return Select(Table, FieldsCollection, Conditional, null);
        //}

        //public static DataTable Select(SQLTable Table, List<Enum> FieldsCollection)
        //{
        //    return Select(Table, FieldsCollection, null);
        //}

        //public static DataTable Select(SQLTable Table)
        //{
        //    return Select(Table, null);
        //}

        //#endregion

        //static DataTable GetTable(string Command)
        //{
        //    TryOpen();
        //    MySqlCommand sqlCommand = new MySqlCommand(Command, sqlConnection);
        //    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
        //    DataTable table = new DataTable();
        //    sqlDataAdapter.Fill(table);
        //    TryClose();
        //    return table;
        //}

        #region Concatenates
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
        #endregion
    }

    public class Select
    {
        public Select(List<Enum> Fields, SQLTable Table)
        {
            if (Fields != null && Fields.Count != 0)
            {
                this.Fields = Fields;
                this.Table = Table;
            }
            else throw new ArgumentNullException(nameof(Fields));
        }

        public Select(Enum Field, SQLTable Table)
        {
            if (Field != null)
            {
                Fields = new List<Enum> { Field };
                this.Table = Table;
            }
            else throw new ArgumentNullException(nameof(Field));
        }

        public List<Enum> Fields { get; private set; }
        public SQLTable Table { get; private set; }
        public DataFieldTemplate Filter { get; set; }
        public Enum OrderByField { get; set; }

        public override string ToString()
        {
            //Base
            string FieldsString = string.Join<Enum>(", ", Fields.ToArray());
            string cmd = $"Select {FieldsString} From {Table}";
            //Secondary
            if (Filter.IsStringable) cmd += $" Where {Filter}";
            if (OrderByField != null) cmd += $" Order by {OrderByField}";
            //Return
            return cmd;
        }

        public DataTable Execute() => DataBase.RunSelect(this);

        public List<object> GetListed()
        {
            List<object> list = new List<object>();
            foreach (DataRow row in Execute().Rows)
            {
                list.Add(row[0]);
            }
            return list;
        }
    }

    public static class DataBase
    {
        private readonly static MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.StringConnectionMySQL);

        public static void TryOpen()
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();
            }
            catch (MySqlException)
            {
                throw new QsqlConnectionException();
            }
        }

        public static void TryClose()
        {
            try
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
            catch (MySqlException)
            {
                throw new QsqlConnectionException();
            }
        }

        public static DataTable RunSelect(Select S)
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(S.ToString(), connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
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
