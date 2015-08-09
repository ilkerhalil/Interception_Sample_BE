using System;

namespace Interception_Sample_BE
{
    public class ValidationHandlerAttribute : Attribute
    {
        public int Order { get; set; }
    }
}