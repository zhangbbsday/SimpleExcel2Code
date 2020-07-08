using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExcel2Code
{
    public partial class Command
    {
        private string[] TipMessage { get; } =
        {
            "Use",
            "\te2c [ExcelFile] Or e2c [Command]",
            "Also can input help to get help infomation.",
        };

        private string[] HelpMessage { get; } =
        {
            "Generater Code:",
            "\te2c [ExcelFile]",
            "Command:",
            "\ttip\tView the tip.",
            "\thelp\tView the help infomation.",
        };

        private void Tip()
        {
            PrintMessages(TipMessage);
        }

        private void Help()
        {
            PrintMessages(HelpMessage);
        }

        private void PrintMessages(string[] messages)
        {
            foreach (var str in messages)
            {
                Console.WriteLine(str);
            }
        }
    }
}
