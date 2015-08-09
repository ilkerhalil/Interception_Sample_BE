using System;

namespace Interception_Sample_BE
{
    public class Logger
    {
        public void Logla(params string[] parameters)
        {
            Console.WriteLine(string.Join(",",parameters));
        }
    }
}
