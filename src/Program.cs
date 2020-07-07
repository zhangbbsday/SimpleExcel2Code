using System;
using SimpleExcel2Code;
using SimpleExcel2Code.CustomService;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialization();
            Command command = new Command(args);
            try
            {
                command.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Initialization()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
    }
}
