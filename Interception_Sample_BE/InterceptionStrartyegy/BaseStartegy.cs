using System;
using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public abstract class BaseStartegy : IStartegy
    {
        public virtual MarshalByRefObject MarshalByRefObject { get; private set; }
        public virtual IMethodCallMessage Message { get; private set; }

        protected BaseStartegy(MarshalByRefObject marshalByRefObject, IMethodCallMessage message)
        {
            MarshalByRefObject = marshalByRefObject;
            Message = message;
        }

        public abstract IMethodReturnMessage Execute();

    }
}