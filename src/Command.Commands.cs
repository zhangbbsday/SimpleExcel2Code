using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExcel2Code
{
    public partial class Command
    {
        private Dictionary<string, Action> Commands { get; } = new Dictionary<string, Action>();

        private void SetCommands()
        {
            Commands.Add("tip", Tip);
            Commands.Add("help", Help);
        }

        private void ExecuteCommand(string message)
        {
            if (!Commands.ContainsKey(message))
            {
                if (System.IO.File.Exists(message))
                {
                    Convert(message);
                    return;
                }

                throw new KeyNotFoundException($"Cannot find \"{message}\" Command!");
            }
            Commands[message].Invoke();
        }
    }
}
