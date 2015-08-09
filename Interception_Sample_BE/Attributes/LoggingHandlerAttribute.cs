using System;
using System.Security.AccessControl;

namespace Interception_Sample_BE
{
    public class LoggingHandlerAttribute : Attribute
    {
        public int Order { get; set; }

    }
}