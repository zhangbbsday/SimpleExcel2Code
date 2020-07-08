using ExcelDataReader;

namespace SimpleExcel2Code
{
    public interface IReadService
    {
        /// <summary>
        /// 代码生成后的文件信息
        /// </summary>
        string[] ReadFileInfo(Table table);
        /// <summary>
        /// 代码生成后文件注释信息
        /// </summary>
        string[] ReadFileComment(Table table);
        /// <summary>
        /// 代码生成后每个类属性的注释
        /// </summary>
        string[] ReadPropertyComment(Table table);
        /// <summary>
        /// 代码生成后属性对应的类型
        /// </summary>
        string[] ReadPropertyType(Table table);
        /// <summary>
        /// 代码生成后的类属性
        /// </summary>
        string[] ReadProperty(Table table);
    }
}
