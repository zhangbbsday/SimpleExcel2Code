using System.Collections.Generic;
using System.Data;

namespace SimpleExcel2Code
{
    public partial class Table
    {
        public Row this[int row] => Rows[row];
        public string this[int row, int col] => Rows[row][col];
        public string Name { get => DataTable.TableName; }
        public int Length { get => Rows.Count; }
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
