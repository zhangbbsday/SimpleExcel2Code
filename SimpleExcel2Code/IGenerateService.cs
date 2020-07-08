using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExcel2Code
{
    public interface IGenerateService
    {
        string Path { get; }
        string GenerateCode(DataCode dataCode);
    }
}
