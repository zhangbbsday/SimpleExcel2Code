using System.Collections;
using System.Data;

namespace SimpleExcel2Code
{
    public partial class Table
    {
        public class Row
        {
            public int Count => DataRow.ItemArray.Length;
            public object this[int col] => GetValue(col);
            private DataRow DataRow { get; }
            public Row(DataRow row)
            {
                DataRow = row;
            }

            public object GetValue(int col)
            {
                return DataRow.ItemArray[col].ToString();
            }

            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < DataRow.ItemArray.Length; i++)
                {
                    yield return GetValue(i);
                }
            }
        }
    }
}
