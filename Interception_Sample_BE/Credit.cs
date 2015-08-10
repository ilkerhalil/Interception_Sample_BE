using System;
using System.Globalization;
using System.Security;
using System.Threading;

namespace Interception_Sample_BE
{
    [Intercept]
    public class Credit: ContextBoundObject
    {
        

        [LoggingHandler]
        [ErrorHandler("developer@bank.com")]
        [SecurityHandler(Role = "operation")]
        public decimal CalculateCreditExpense(string requester, double requesterRate, decimal creditAmount)
        {
            return 0;
        }
    }
}