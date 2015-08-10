using System;

namespace Interception_Sample_BE
{
    public class SecurityHandlerAttribute : InterceptHandlerAttribute
    {
        public string Role { get; set; }

        public SecurityHandlerAttribute()
            : base(InterceptType.Before)
        {
        }
        public override Type StartegyType => typeof(SecurityStartegy);
    }
}