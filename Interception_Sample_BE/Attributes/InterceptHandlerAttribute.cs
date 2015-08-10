using System;

namespace Interception_Sample_BE
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class InterceptHandlerAttribute : Attribute
    {
        protected InterceptHandlerAttribute(InterceptType interceptType)
        {
            InterceptType = interceptType;
        }

        public InterceptType InterceptType { get; private set; }

        public int Order { get; set; }

        public abstract Type StartegyType { get; }

    }
}