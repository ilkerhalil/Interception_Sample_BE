using System;

namespace Interception_Sample_BE
{
    class Program
    {
        static void Main()
        {
            Credit credit =new Credit();
            credit.CalculateCreditExpense("iturer", 5, 1000);
            Console.ReadLine();
        }
    }
}
