using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExcel2Code
{
    public class DataCode
    {
        public string[] FileInfo { get; }
        public string[] FileComment { get; }
        public string[] PropertyComment { get; }
        public string[] PropertyType { get; }
        public string[] Property { get; }
        public DataCode(string[] fileInfo, string[] fileComment, string[] propertyComment, string[] propertyType, string[] property)
        {
            FileInfo = fileInfo;
            FileComment = fileComment;
            PropertyComment = propertyComment;
            PropertyType = propertyType;
            Property = property;
        }
    }
}
