using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SimpleExcel2Code
{
    public class CodeGenerater
    {
        private IGenerateService GenerateService { get; }
        public CodeGenerater(IGenerateService generateService)
        {
            GenerateService = generateService;
        }

        public void GenerateCode(DataCode dataCode, string path)
        {
            string code = GenerateService.GenerateCode(dataCode);
            WriteToFile(code, path);
        }

        public void GenerateCode(DataCode dataCode)
        {
            string code = GenerateService.GenerateCode(dataCode);
            WriteToFile(code, GenerateService.Path);
        }

        private void WriteToFile(string code, string path)
        {
            using (var file = File.Create(path))
            {
                using (var stream = new StreamWriter(file))
                {
                    stream.Write(code);
                }
            }
        }
    }
}
