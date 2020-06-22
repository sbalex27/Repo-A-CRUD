using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace SalesApp_Alpha_2
{
    public class DataBaseInteraction
    {
        #region Events
        public delegate void DBEventHandler(DataBaseInteraction sender, int AffectedRows, string Action);
        public event DBEventHandler Interaction;
        #endregion

        #region Properties
        public SQLTable Table { get; protected set; }
        public bool IsConditionable => !string.IsNullOrWhiteSpace(Filter?.Value.ToString());
        private MySqlCommand Command => new MySqlCommand(ToString(), Connection);
        private MySqlDataAdapter DataAdapter => new MySqlDataAdapter(Command);
        private readonly static MySqlConnection Connection = new MySqlConnection(Properties.Settings.Default.StringConnectionMySQL);
        private DataFieldTemplate PFilter { get; set; }
        private List<DataFieldTemplate> PDataFieldCollection { get; set; }
        public DataFieldTemplate Filter
        {
            get => PFilter;
            set => PFilter = value is null ? throw new ArgumentNullException() : value;
        }
        public List<DataFieldTemplate> DataFieldCollection
        {
            get => PDataFieldCollection;
            set => PDataFieldCollection = value is null | value.Count == 0 ? throw new ArgumentNullException(nameof(DataFieldCollection)) : value;
        }
        #endregion

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
            int Rows = DataAdapter.Fill(dataTable);
            TryClose();

            Interaction?.Invoke(this, Rows, "Seleccionado");
            return dataTable;
        }

        public void RunNonQuery()
        {
            if (GetType() != typeof(Select))
            {
                TryOpen();
                int Rows = Command.ExecuteNonQuery();
                TryClose();

                Interaction?.Invoke(this, Rows, "NonQuery");
            }
            else throw new InvalidOperationException();
        }
    }

    public class Select : DataBaseInteraction
    {
        #region Constructors
        public Select(List<Enum> Fields, SQLTable Table)
        {
            this.Fields = Fields;
            this.Table = Table;
        }

        public Select(Enum Field, SQLTable Table)
        {
            this.Field = Field;
            this.Table = Table;
        }
        #endregion

        #region Properties
        public Enum OrderByField { get; set; }
        private List<Enum> PFields { get; set; }
        public List<Enum> Fields
        {
            get => PFields;
            set => PFields = value is null || value.Count == 0 ? throw new ArgumentNullException(nameof(Fields)) : value;
        }
        private Enum Field
        {
            set => Fields = value is null ? throw new ArgumentNullException(nameof(Field)) : new List<Enum> { value };
        }
        #endregion

        #region Voids
        public override string ToString()
        {
            //Base
            string FieldsString = string.Join(", ", Fields);
            string cmd = $"Select {FieldsString} From {Table}";
            //Secondary
            if (IsConditionable) cmd += $" Where {Filter}";
            if (OrderByField != null) cmd += $" Order by {OrderByField}";
            //Return
            return cmd;
        }

        public List<object> RunSelectListed()
        {
            List<object> list = new List<object>();
            foreach (DataRow row in RunSelect().Rows)
            {
                list.Add(row[0]);
            }
            return list;
        }
        #endregion
    }

    public class Update : DataBaseInteraction
    {
        public Update (SQLTable table, List<DataFieldTemplate> dataFieldsCollection)
        {
            Table = table;
            DataFieldCollection = dataFieldsCollection;
        }

        public Update (SQLTable table, DataFieldTemplate dataField)
        {
            Table = table;
            DataField = dataField;
        }

        private DataFieldTemplate DataField
        {
            set => DataFieldCollection = value is null ? throw new ArgumentNullException(nameof(DataField)) : new List<DataFieldTemplate> { value };
        }

        public override string ToString()
        {
            //Base
            string CollectionString = DataFieldTemplate.JoinCollection(DataFieldCollection);
            string Command = $"Update {Table} Set {CollectionString}";
            //Secondary
            if (IsConditionable) Command += $" Where {Filter}";
            return Command;
        }
    }

    public class InsertInto : DataBaseInteraction
    {
        public InsertInto(SQLTable Table, List<DataFieldTemplate> Collection)
        {
            this.Table = Table;
            DataFieldCollection = Collection;
        }

        public override string ToString()
        {
            DataFieldTemplate.ConcatenateFieldsValues(DataFieldCollection, out string Fields, out string FormattedValues);
            return $"Insert Into {Table} ({Fields}) Values ({FormattedValues})";
        }
    }

    public class Delete : DataBaseInteraction
    {
        public Delete(SQLTable table, DataFieldTemplate conditional)
        {
            Table = table;
            Filter = conditional;
        }

        public override string ToString()
        {
            return $"Delete From {Table} Where {Filter}";
        }
    }
}
