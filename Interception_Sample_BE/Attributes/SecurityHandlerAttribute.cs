using System;

namespace Interception_Sample_BE
{
    public class SecurityHandlerAttribute : Attribute
    {
        public int Order { get; set; }
        public string Role { get; set; }
    }
}