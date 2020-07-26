using System;
using System.IO;
using ExcelDataReader;

namespace SimpleExcel2Code
{
    public class ExcelReader
    {
        public Table DataTable { get; private set; }
        private IReadService ReadService { get; }
        public ExcelReader(IReadService readService = null)
        {
            ReadService = readService;
        }

        public DataCode Process(string path, int sheetIndex = 0)
        {
            DataTable = GetTable(path, sheetIndex);
            if (ReadService == null)
                return null;

            return GenerateDataCode(DataTable);
        }

        private Table GetTable(string path, int sheetIndex = 0)
        {
            if (DataTable != null)
                return DataTable;

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    var sheet = result.Tables[sheetIndex];
                    return sheet == null ? null : new Table(sheet); 
                }
            }
        }

        private DataCode GenerateDataCode(Table table)
        {
            return new DataCode(ReadService.ReadFileInfo(table),
                        ReadService.ReadFileComment(table),
                        ReadService.ReadPropertyComment(table),
                        ReadService.ReadPropertyType(table),
                        ReadService.ReadProperty(table));
        }
    }
}
