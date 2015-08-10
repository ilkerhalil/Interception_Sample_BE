using System;
using System.Globalization;
using System.Security;
using System.Threading;

namespace Interception_Sample_BE
{
    [Intercept]
    public class Credit
    {
        private readonly Logger _logger;
        private readonly Notification _notification;
        private readonly Security _security;

        public Credit(Logger logger, Notification notification, Security security)
        {
            _logger = logger;
            _notification = notification;
            _security = security;
        }

        [LoggingHandler]
        [ErrorHandler("developer@bank.com")]
        [SecurityHandler(Role = "operation")]
        public decimal CalculateCreditExpense(string requester, double requesterRate, decimal creditAmount)
        {
            return 0;
        }
    }
}