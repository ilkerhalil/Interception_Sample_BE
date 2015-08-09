using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Threading;

namespace Interception_Sample_BE
{
    public class CreditInterceptor : RealProxy
    {
        private readonly MarshalByRefObject _marshalByRefObject;

        public CreditInterceptor(MarshalByRefObject marshalByRefObject)
        {
            _marshalByRefObject = marshalByRefObject;
        }

        public override IMessage Invoke(IMessage msg)
        {

            var methodCall = msg as IMethodCallMessage;
            var targetMethod = methodCall.MethodBase as MethodInfo;
            var attributes = targetMethod.GetCustomAttributes(true);
            foreach (var attribute in attributes)
            {
                //if (attribute is LoggingHandlerAttribute)
                //{
                //    var logStartegy =new LogStartegy();
                //    logStartegy.Execute(msg);
                //}
                //if (attribute is SecurityHandlerAttribute)
                //{
                //    var securityStartegy = new SecurityStartegy(Thread.CurrentPrincipal.Identity.Name,(attribute as SecurityHandlerAttribute).Role,marshalByRefObject: );
                //    securityStartegy.Execute(msg);
                //}
                //if (attribute is ErrorHandlerAttribute)
                //{
                //    var errorHandlerStartegy = new ErrorHandlerStartegy((attribute as ErrorHandlerAttribute).NotifyEmail,_marshalByRefObject);
                //    errorHandlerStartegy.Execute(msg);
                //}
                //return RemotingServices.ExecuteMessage(_marshalByRefObject, methodCall);
            }
            return null;
        }
    }
}