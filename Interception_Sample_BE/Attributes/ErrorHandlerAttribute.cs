using System;
using System.Runtime.Remoting.Contexts;

namespace Interception_Sample_BE
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ErrorHandlerAttribute : InterceptHandlerAttribute
    {
        public ErrorHandlerAttribute(string notifyEmail)
            : base(InterceptType.After)
        {
            NotifyEmail = notifyEmail;
        }
        public string NotifyEmail { get; private set; }
        public int Order { get; set; }
    }
}