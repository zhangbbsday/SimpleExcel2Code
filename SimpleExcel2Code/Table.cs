using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace SimpleExcel2Code
{
    public class Table
    {
        public DataRow this[int index]
        {
            get => DataTable.Rows[index];
        }

        public string Name { get => DataTable.TableName; }
        private DataTable DataTable { get; }
        public Table(DataTable dataTable)
        {
            DataTable = dataTable;
        }
    }
}
