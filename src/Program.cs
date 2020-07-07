using System;
using SimpleExcel2Code;
using SimpleExcel2Code.CustomService;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string str = @"E:\test.xlsx";
            Test(str);

            Console.WriteLine("生成成功!");
            Console.ReadKey();
        }

        static void Test(string path)
        {
            Services services = new Services(new TestRead(), new TestGenerater());
            ExcelReader reader = new ExcelReader(services.ReadService);
            CodeGenerater codeGenerater = new CodeGenerater(services.GenerateService);

            var data = reader.Process(path);
            codeGenerater.GenerateCode(data);
        }
    }
}
