using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Threading;

namespace Interception_Sample_BE
{
    public class SecurityStartegy : BaseStartegy
    {


        public SecurityStartegy(string role)
        {
            _security = new Security();
        }

        public override void Execute(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
        {
            var securityHandlerAttribute = callMsg.MethodBase.GetCustomAttribute(typeof(SecurityHandlerAttribute)) as SecurityHandlerAttribute;
            if (securityHandlerAttribute == null) throw new ArgumentNullException("securityHandlerAttribute");
            if (!_security.CheckAuthorization(Thread.CurrentPrincipal.Identity.Name, securityHandlerAttribute.Role)) throw new SecurityException();
        }

        Security _security;
    }
}