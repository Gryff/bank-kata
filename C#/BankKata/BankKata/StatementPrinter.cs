using System;

namespace BankKata
{
    public class StatementPrinter : IConsole
    {
        public void PrintLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}