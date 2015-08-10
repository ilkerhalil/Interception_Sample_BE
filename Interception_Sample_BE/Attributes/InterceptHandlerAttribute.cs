using System;

namespace Interception_Sample_BE
{
    [AttributeUsage(AttributeTargets.Method)]
    public class InterceptHandlerAttribute : Attribute
    {
        public InterceptType InterceptType { get; private set; }

        public InterceptHandlerAttribute(InterceptType interceptType)
        {
            InterceptType = interceptType;
        }
    }
}