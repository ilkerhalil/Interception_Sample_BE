using System;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;

namespace Interception_Sample_BE
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InterceptAttribute : ContextAttribute
    {
        public InterceptAttribute()
            : base("Intercept")
        {
        }

        public override void Freeze(Context newContext)
        {
        }

        public override bool IsContextOK(Context ctx, IConstructionCallMessage ctorMsg)
        {
            var p = (InterceptProperty)ctx.GetProperty("Intercept");
            return p != null;
        }

        public override bool IsNewContextOK(Context newCtx)
        {
            var p = (InterceptProperty)newCtx.GetProperty("Intercept");
            return p != null;
        }
    }
}