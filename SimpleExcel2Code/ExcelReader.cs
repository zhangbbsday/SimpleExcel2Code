using System;
using System.IO;
using ExcelDataReader;

namespace SimpleExcel2Code
{
    public class ExcelReader
    {
        private IReadService ReadService { get; }
        public ExcelReader(IReadService readService)
        {
            ReadService = readService;
        }

        public DataCode Process(string path, int sheetIndex = 0)
        {
            Table table = GetTable(path, sheetIndex);
            return GenerateDataCode(table);
        }

        private Table GetTable(string path, int sheetIndex)
        {

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
