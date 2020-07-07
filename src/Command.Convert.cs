using SimpleExcel2Code.CustomService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExcel2Code
{
    public partial class Command
    {
        private void Convert(string path)
        {
            Services services = new Services(new TestRead(), new TestGenerater());
            ExcelReader reader = new ExcelReader(services.ReadService);
            CodeGenerater codeGenerater = new CodeGenerater(services.GenerateService);

            var data = reader.Process(path);
            codeGenerater.GenerateCode(data);

            Console.WriteLine("Convert successfully!");
        }
    }
}
