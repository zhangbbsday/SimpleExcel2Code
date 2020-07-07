using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExcel2Code
{
    public partial class Command
    {
        private string[] Args { get; }
        public Command(string[] args)
        {
            Args = args;
            SetCommands();
        }

        public void Execute()
        {
            if (Args.Length == 0)
            {
                Tip();
                return;
            }

            foreach (var str in Args)
            {
                ExecuteCommand(str);
            }
        }
    }
}
