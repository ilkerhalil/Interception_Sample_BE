using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public class ErrorHandlerStartegy : BaseStartegy
    {
        private readonly string _notifyEmail;
        private readonly EmailService emailService;

        public ErrorHandlerStartegy(MarshalByRefObject marshalByRefObject, IMethodCallMessage message,string notifyEmail)
            :base(marshalByRefObject,message)
        {
            _notifyEmail = notifyEmail;
            emailService = new EmailService();
        }


        public override IMethodReturnMessage Execute()
        {
            var methodReturnMessage = RemotingServices.ExecuteMessage(MarshalByRefObject, Message);
            if(methodReturnMessage.Exception!=null) emailService.SendEmail(new[] { _notifyEmail }, null, $"Error {methodReturnMessage.Exception.TargetSite.Name}", methodReturnMessage.Exception.ToString());
            return methodReturnMessage;
        }
    }
}