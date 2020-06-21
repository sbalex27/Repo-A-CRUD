using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SalesApp_Alpha_2
{
    public class DataBaseInteraction
    {
        public SQLTable Table { get; protected set; }
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
            TryOpen();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(S.ToString(), connection);
            TryClose();
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public static void RunNonQuery(DataBaseInteraction Command, out int AffectedRows)
        {
            TryOpen();
            AffectedRows = new MySqlCommand(Command.ToString(), connection).ExecuteNonQuery();
            TryClose();
        }
    }

    public class Select : DataBaseInteraction
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
        public DataFieldTemplate Filter { get; set; }
        public Enum OrderByField { get; set; }

        public override string ToString()
        {
            //Base
            string FieldsString = string.Join<Enum>(", ", Fields.ToArray());
            string cmd = $"Select {FieldsString} From {Table}";
            //Secondary
            if (!string.IsNullOrWhiteSpace(Filter?.Value.ToString())) cmd += $" Where {Filter}";
            if (OrderByField != null) cmd += $" Order by {OrderByField}";
            //Return
            return cmd;
        }

        public DataTable Execute()
        {
            return RunSelect(this);
        }

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

    public class Update : DataBaseInteraction
    {
        public Update (SQLTable table, List<DataFieldTemplate> dataFieldsCollection)
        {
            if (dataFieldsCollection is null || dataFieldsCollection.Count == 0)
            {
                throw new ArgumentNullException(nameof(dataFieldsCollection));
            }
            Table = table;
            DataFieldsCollection = dataFieldsCollection;
        }

        public Update (SQLTable table, DataFieldTemplate DataField)
        {
            if (DataField is null)
            {
                throw new ArgumentNullException(nameof(DataField));
            }
            Table = table;
            DataFieldsCollection = new List<DataFieldTemplate> { DataField };
        }
        public List<DataFieldTemplate> DataFieldsCollection { get; private set; }
        public DataFieldTemplate Conditional { get; set; }

        public int Execute()
        {

        }
    }

    public class InsertInto : DataBaseInteraction
    {
        public InsertInto(SQLTable Table, List<DataFieldTemplate> Collection)
        {
            if (Collection is null || Collection.Count == 0)
            {
                throw new ArgumentNullException(nameof(Collection));
            }

            this.Table = Table;
            DataFieldsCollection = Collection;
        }

        public List<DataFieldTemplate> DataFieldsCollection { get; private set; }

        public override string ToString()
        {
            DataFieldTemplate.ConcatenateFieldsValues(DataFieldsCollection, out string Fields, out string FormattedValues);
            return $"Insert Into {Table} ({Fields}) Values ({FormattedValues})";
        }

        public int Execute()
        {
            RunNonQuery(this, out int AffectedRows);
            return AffectedRows;
        }
    }


}
