using System;
using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public abstract class BaseStartegy : IStartegy
    {
        protected BaseStartegy() { }

        public abstract void Execute(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg);

    }
}