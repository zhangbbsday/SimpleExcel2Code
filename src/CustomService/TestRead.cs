using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using SimpleExcel2Code;

namespace SimpleExcel2Code.CustomService
{
    public class TestRead : IReadService
    {
        public string[] ReadFileComment(Table table)
        {
            string copyright = (string)table[0][0];
            string lastEdit = (string)table[1][0];
            string version = (string)table[1][1];
            return GetComment(copyright, lastEdit, version);
        }

        private string[] GetComment(string copyright, string lastEdit, string version)
        {
            List<string> strs = new List<string>();
            using (var stream = new StreamReader("CustomService\\TestFileComment.txt"))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    line = line.Replace("{copyright}", copyright);
                    line = line.Replace("{lastedit}", lastEdit);
                    line = line.Replace("{version}", version);
                    strs.Add(line);
                }

                return strs.ToArray();
            }
        }

        public string[] ReadFileInfo(Table table)
        {
            string[] info = new string[2];
            info[0] = (string)table[2][0];
            info[1] = (string)table[2][1];
            return info;
        }

        public string[] ReadProperty(Table table)
        {
            List<string> strs = new List<string>();

            for (int i = 0; i < table[5].ItemArray.Length; i++)
            {
                string str = (string)table[5][i];
                strs.Add(str);
            }
            return strs.ToArray();
        }

        public string[] ReadPropertyComment(Table table)
        {
            List<string> strs = new List<string>();

            for (int i = 0; i < table[4].ItemArray.Length; i++)
            {
                string str = (string)table[4][i];
                strs.Add(str);
            }
            return strs.ToArray();
        }

        public string[] ReadPropertyType(Table table)
        {
            List<string> strs = new List<string>();

            for (int i = 0; i < table[6].ItemArray.Length; i++)
            {
                string str = (string)table[6][i];
                strs.Add(str);
            }
            return strs.ToArray();
        }
    }
}
