using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleExcel2Code.CustomService
{
    public class TestGenerater : IGenerateService
    {
        public string Path { get; private set; }
        private string ClassName { get; set; }
        private string ClassFormat { get; } = "public class {0} {1} {2}\n";
        public string GenerateCode(DataCode dataCode)
        {
            HandleFileInfo(dataCode);

            StringBuilder code = new StringBuilder();
            HandleFileComment(dataCode, code);
            HandleDataClass(dataCode, code);
            HandleDataClassCollection(code);
            return code.ToString();
        }

        private void HandleFileInfo(DataCode dataCode)
        {
            Path = dataCode.FileInfo[1] + dataCode.FileInfo[0];
            ClassName = Regex.Replace(dataCode.FileInfo[0], @"\.\w+$", "");
        }

        private void HandleFileComment(DataCode dataCode, StringBuilder str)
        {
            foreach (var s in dataCode.FileComment)
            {
                str.Append(s);
                str.Append('\n');
            }
            str.Append('\n');
        }

        private void HandleDataClass(DataCode dataCode, StringBuilder str)
        {
            str.Append(string.Format(ClassFormat, ClassName, "", ""));
            str.Append("{\n");
            HandleProperty(dataCode, str);
            str.Append("}\n");
        }

        private void HandleProperty(DataCode dataCode, StringBuilder str)
        {
            for (int i = 0; i < dataCode.Property.Length; i++)
            {
                string s = GetProperty(dataCode.Property[i], dataCode.PropertyType[i], dataCode.PropertyComment[i]);
                str.Append(s);
            }
        }

        private string GetProperty(string property, string type, string comment)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("\t//{0}\n", comment));
            stringBuilder.Append(string.Format("\tpublic {0} {1};\n", type, property));
            return stringBuilder.ToString();
        }

        private void HandleDataClassCollection(StringBuilder str)
        {
            str.Append('\n');
            str.Append(string.Format(ClassFormat, ClassName + "Collection", "", ""));
            str.Append("{\n");
            str.Append('\t');
            str.Append(string.Format("public List<{0}> {0}s", ClassName));
            str.Append(";\n");
            str.Append("}\n");
        }
    }
}
