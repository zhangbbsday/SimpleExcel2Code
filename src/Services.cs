using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExcel2Code
{
    public class Services
    {
        public IReadService ReadService { get; }
        public IGenerateService GenerateService { get; }

        public Services(IReadService readService, IGenerateService generateService)
        {
            ReadService = readService;
            GenerateService = generateService;
        }
    }
}
