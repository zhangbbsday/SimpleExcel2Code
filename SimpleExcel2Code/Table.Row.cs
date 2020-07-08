﻿using System.Data;

namespace SimpleExcel2Code
{
    public partial class Table
    {
        public class Row
        {
            public int Count => DataRow.ItemArray.Length;
            public string this[int col] => GetValue(col);
            private DataRow DataRow { get; }
            public Row(DataRow row)
            {
                DataRow = row;
            }

            public string GetValue(int col)
            {
                return DataRow.ItemArray[col].ToString();
            }
        }
    }
}