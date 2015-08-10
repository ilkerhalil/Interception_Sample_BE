using System;

namespace Interception_Sample_BE
{
    public class SecurityHandlerAttribute : InterceptHandlerAttribute
    {
        public int Order { get; set; }
        public string Role { get; set; }

        public SecurityHandlerAttribute()
            : base(InterceptType.Before)
        {
        }
    }
}