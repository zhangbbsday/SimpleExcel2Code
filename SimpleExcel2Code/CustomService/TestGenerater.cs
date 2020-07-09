using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleExcel2Code.CustomService
{
    public class TestGenerater : IGenerateService
    {
        enum TempleType
        {
            FileComment,
            NameSpace,
            DataClass,
            CollectionClass,
            Property,
        }

        enum FileInfo
        {
            FileName,
            Path,
        }

        public string Path { get; private set; }
        private string ClassName { get; set; }
        private string ParentClassName { get; } = "ScriptableObject";
        private string TempleFile { get; } = "TestTemple.txt";
        private string EndTempleKeyWord { get; } = "End";
        private string[] Temples { get; } = new string[Enum.GetNames(typeof(TempleType)).Length];
        private Dictionary<string, TempleType> TempleMaps { get; } = new Dictionary<string, TempleType>
        {
            ["CommentTemple"] = TempleType.FileComment,
            ["NameSpaceTemple"] = TempleType.NameSpace,
            ["DataClassTemple"] = TempleType.DataClass,
            ["CollectionClassTemple"] = TempleType.CollectionClass,
            ["PropertyTemple"] = TempleType.Property,

        };

        public TestGenerater()
        {
            ReadTemple();
        }

        public string GenerateCode(DataCode dataCode)
        {
            HandleFileInfo(dataCode);
            return Join(dataCode);
        }

        private void HandleFileInfo(DataCode dataCode)
        {
            Path = dataCode.FileInfo[(int)FileInfo.Path] + dataCode.FileInfo[(int)FileInfo.FileName];
            ClassName = Regex.Replace(dataCode.FileInfo[(int)FileInfo.FileName], @"\.\w+$", "");
        }

        private void ReadTemple()
        {
            using (var stream = File.Open(TempleFile, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line.StartsWith("#"))
                        {
                            TempleType type = TempleMaps[line.TrimStart(new char[] { '#' })];
                            Temples[(int)type] = GetOneTemple(reader);
                        }
                    }
                }
            }
        }

        private string GetOneTemple(StreamReader reader)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Trim().StartsWith("#") && line.Contains(EndTempleKeyWord))
                    break;
                stringBuilder.Append(line + '\n');
            }

            return stringBuilder.ToString();
        }

        private string Join(DataCode dataCode)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(GetFileComment(dataCode));
            stringBuilder.Append(GetNameSpace(dataCode));
            stringBuilder.Append(GetDataClass(dataCode));
            stringBuilder.Append(CollectionClass(dataCode));

            return stringBuilder.ToString();
        }

        private string GetFileComment(DataCode dataCode)
        {
            string str = Temples[(int)TempleType.FileComment];
            return str.Replace("{copyright}", dataCode.FileComment[0])
                    .Replace("{lastedit}", dataCode.FileComment[1])
                    .Replace("{version}", dataCode.FileComment[2]);
        }

        private string GetNameSpace(DataCode dataCode)
        {
            return Temples[(int)TempleType.NameSpace];
        }

        private string GetDataClass(DataCode dataCode)
        {
            string str = Temples[(int)TempleType.DataClass];
            return str.Replace("{class}", ClassName)
                    .Replace("{parents}", ParentClassName)
                    .Replace("{properties}", GetProperties(dataCode));
        }

        private string GetProperties(DataCode dataCode)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string str = Temples[(int)TempleType.Property];
            for (int i = 0; i < dataCode.Property.Length; i++)
            {
                stringBuilder.Append(GetProperty(str, dataCode.Property[i], dataCode.PropertyType[i], dataCode.PropertyComment[i]));
            }
            return stringBuilder.ToString();
        }

        private string GetProperty(string str, string property, string type, string comment)
        {
            return str.Replace("{type}", type)
                    .Replace("{property}", property)
                    .Replace("{comment}", comment);
        }

        private string CollectionClass(DataCode dataCode)
        {
            string str = Temples[(int)TempleType.CollectionClass];
            return str.Replace("{class}", ClassName)
                    .Replace("{parents}", ParentClassName);
        }
    }
}
