using System.Collections.Generic;

namespace SimpleExcel2Code.CustomService
{
    public class TestRead : IReadService
    {
        public string[] ReadFileComment(Table table)
        {
            string copyright = table[0, 0].ToString();
            string lastEdit = table[1, 0].ToString();
            string version = table[1, 1].ToString();
            return new string[] { copyright, lastEdit, version };
        }

        public string[] ReadFileInfo(Table table)
        {
            string[] info = new string[2];
            info[0] = table[2, 0].ToString();
            info[1] = table[2, 1].ToString();
            return info;
        }

        public string[] ReadProperty(Table table)
        {
            List<string> strs = new List<string>();

            foreach (string s in table[5])
            {
                strs.Add(s);
            }
            return strs.ToArray();
        }

        public string[] ReadPropertyComment(Table table)
        {
            List<string> strs = new List<string>();

            foreach (string s in table[4])
            {
                strs.Add(s);
            }
            return strs.ToArray();
        }

        public string[] ReadPropertyType(Table table)
        {
            List<string> strs = new List<string>();

            foreach (string s in table[6])
            {
                strs.Add(s);
            }
            return strs.ToArray();
        }
    }
}
