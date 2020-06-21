using System;
using System.Collections.Generic;

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
                        return Operator == SQLOperator.Like ? $"'%{Value}%'" : $"'{Value}'";
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
}
