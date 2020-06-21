using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace SalesApp_Alpha_2
{
    public class DataBaseInteraction
    {
        public SQLTable Table { get; protected set; }
        private readonly static MySqlConnection Connection = new MySqlConnection(Properties.Settings.Default.StringConnectionMySQL);
        private MySqlCommand Command => new MySqlCommand(ToString(), Connection);
        private MySqlDataAdapter DataAdapter => new MySqlDataAdapter(Command);

        private void TryOpen()
        {
            try
            {
                if (Connection.State == ConnectionState.Closed) Connection.Open();
            }
            catch (MySqlException)
            {
                throw new QsqlConnectionException();
            }
        }

        private void TryClose()
        {
            try
            {
                if (Connection.State == ConnectionState.Open) Connection.Close();
            }
            catch (MySqlException)
            {
                throw new QsqlConnectionException();
            }
        }

        public DataTable RunSelect()
        {
            TryOpen();
            DataTable dataTable = new DataTable();
            DataAdapter.Fill(dataTable);
            TryClose();
            return dataTable;
        }

        public int RunNonQuery()
        {
            if (GetType() == typeof(Select)) throw new Exception("Consulta no válida");
            TryOpen();
            int AffectedRows = Command.ExecuteNonQuery();
            TryClose();
            return AffectedRows;
        }
    }

    public class Select : DataBaseInteraction, IConditionableInteraction
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
        public Enum OrderByField { get; set; }
        public DataFieldTemplate Conditional { get; set; }
        public bool Conditionable => !string.IsNullOrWhiteSpace(Conditional?.Value.ToString());

        public override string ToString()
        {
            //Base
            string FieldsString = string.Join<Enum>(", ", Fields.ToArray());
            string cmd = $"Select {FieldsString} From {Table}";
            //Secondary
            if (Conditionable) cmd += $" Where {Conditional}";
            if (OrderByField != null) cmd += $" Order by {OrderByField}";
            //Return
            return cmd;
        }

        public List<object> GetListed()
        {
            List<object> list = new List<object>();
            foreach (DataRow row in RunSelect().Rows)
            {
                list.Add(row[0]);
            }
            return list;
        }
    }

    public class Update : DataBaseInteraction, IConditionableInteraction, IAddOnInteraction
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
        public List<DataFieldTemplate> DataFieldsCollection { get; set; }
        public DataFieldTemplate Conditional { get; set; }
        public bool Conditionable => !string.IsNullOrWhiteSpace(Conditional?.Value.ToString());

        public override string ToString()
        {
            //Base
            string CollectionString = DataFieldTemplate.ConcatenateToStrings(DataFieldsCollection);
            string Command = $"Update {Table} Set {CollectionString}";
            //Secondary
            if (Conditionable) Command += $" Where {Conditional}";
            return Command;
        }
    }

    public class InsertInto : DataBaseInteraction, IAddOnInteraction
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

        public List<DataFieldTemplate> DataFieldsCollection { get; set; }

        public override string ToString()
        {
            DataFieldTemplate.ConcatenateFieldsValues(DataFieldsCollection, out string Fields, out string FormattedValues);
            return $"Insert Into {Table} ({Fields}) Values ({FormattedValues})";
        }
    }

    public class Delete : DataBaseInteraction, IConditionableInteraction
    {
        public Delete(SQLTable table, DataFieldTemplate conditional)
        {
            Table = table;
            Conditional = conditional;
        }

        public DataFieldTemplate Conditional { get; set; }
        public bool Conditionable { get; set; }

        public override string ToString()
        {
            return $"Delete From {Table} Where {Conditional}";
        }
    }

    #region Interfaces
    public interface IConditionableInteraction
    {
        DataFieldTemplate Conditional { get; set; }
        bool Conditionable { get; }
    }

    public interface IAddOnInteraction
    {
        List<DataFieldTemplate> DataFieldsCollection { get; set; }
    }
    #endregion
}
