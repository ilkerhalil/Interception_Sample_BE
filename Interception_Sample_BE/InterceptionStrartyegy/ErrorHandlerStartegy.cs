using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public class ErrorHandlerStartegy : BaseStartegy
    {
        private readonly EmailService emailService;

        public ErrorHandlerStartegy()
        {
            emailService = new EmailService();
        }

        public override void Execute(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
        {
            var errorHandlerAttribute = callMsg.MethodBase.GetCustomAttribute(typeof(ErrorHandlerAttribute)) as ErrorHandlerAttribute;
            if (errorHandlerAttribute == null) throw new ArgumentNullException("errorHandlerAttribute");
            if (retMsg.Exception != null)
                emailService.SendEmail(new[] { errorHandlerAttribute.NotifyEmail }, null,
                    string.Format("Error {0}", retMsg.Exception.TargetSite.Name), retMsg.Exception.ToString());
        }
    }
}