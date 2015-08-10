using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public class ErrorHandlerStartegy :BaseAfterStartegy
    {
        private readonly EmailService _emailService;

        public ErrorHandlerStartegy(IMethodCallMessage methodCallMessage, IMethodReturnMessage methodReturnMessage)
            :base(methodCallMessage,methodReturnMessage)
        {
            _emailService = new EmailService();
        }

        public override string StartegyName { get; }

        public override void Execute()
        {
            var errorHandlerAttribute = this.MethodCallMessage.MethodBase.GetCustomAttribute(typeof(ErrorHandlerAttribute)) as ErrorHandlerAttribute;
            if (errorHandlerAttribute == null) throw new ArgumentNullException("errorHandlerAttribute");
            if (MethodReturnMessage.Exception != null)
                _emailService.SendEmail(new[] { errorHandlerAttribute.NotifyEmail }, null,
                    string.Format("Error {0}", MethodReturnMessage.Exception.TargetSite.Name), MethodReturnMessage.Exception.ToString());
        }
    }
}