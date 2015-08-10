using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public class InterceptProperty : IContextProperty, IContributeObjectSink
    {



        public bool IsNewContextOK(Context newCtx)
        {
            var p = newCtx.GetProperty("Intercept") as InterceptProperty;
            return p != null;
        }

        public void Freeze(Context newContext)
        {
        }

        public string Name => "Intercept";

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            return new InterceptSink(nextSink);
        }
    }
}