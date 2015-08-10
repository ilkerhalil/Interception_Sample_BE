using System;
using System.Security.AccessControl;

namespace Interception_Sample_BE
{
    public class LoggingHandlerAttribute : InterceptHandlerAttribute
    {
        public LoggingHandlerAttribute() 
            : base(InterceptType.Before)
        {
        }

        public override Type StartegyType => typeof (LogStartegy);
    }
}