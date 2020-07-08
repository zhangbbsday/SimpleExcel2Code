using System.Collections.Generic;
using System.Data;


namespace SimpleExcel2Code
{
    public partial class Table
    {
        public Row this[int row] => Rows[row];
        public string Name { get => DataTable.TableName; }
        private DataTable DataTable { get; }
        private List<Row> Rows { get; }
        public Table(DataTable dataTable)
        {
            DataTable = dataTable;
            Rows = new List<Row>();
            SetRows();
        }

        public string GetValue(int row, int col)
        {
            return DataTable.Rows[row][col].ToString();
        }

        private void SetRows()
        {
            for (int i = 0; i < DataTable.Rows.Count; i++)
            {
                Rows.Add(new Row(DataTable.Rows[i]));
            }
        }
    }
}
