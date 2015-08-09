using System;
using System.Globalization;
using System.Runtime.Remoting.Proxies;
using System.Security;
using System.Security.Claims;
using System.Threading;

namespace Interception_Sample_BE
{
    public class Credit
    {
        private readonly Logger _logger;
        private readonly Notification _notification;
        private readonly Security _security;

        public Credit(Logger logger,Notification notification,Security security)
        {
            _logger = logger;
            _notification = notification;
            _security = security;
        }


        [LoggingHandler]
        [ErrorHandler("developer@bank.com")]
        //[ValidationHandler]
        [SecurityHandler(Role="operation")]
        public decimal CalculateCreditExpense(string requester,double requesterRate,decimal creditAmount)
        {
            try
            {
                if (!_security.CheckAuthorization(Thread.CurrentPrincipal.Identity.Name, "operation")) throw new SecurityException();
                _logger.Logla(requester, requesterRate.ToString(CultureInfo.InvariantCulture), creditAmount.ToString(CultureInfo.InvariantCulture));
                return 0;
            }
            catch (Exception exception)
            {
                _notification.SendEmail(new []{"developer@bank.com"},null, "Error CalculateCreditExpense..!", exception.ToString());
                throw;
            }
        }
    }
}