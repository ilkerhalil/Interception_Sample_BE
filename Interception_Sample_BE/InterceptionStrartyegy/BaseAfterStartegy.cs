using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public abstract class BaseAfterStartegy:IStartegy
    {

        protected BaseAfterStartegy(IMethodCallMessage methodCallMessage, IMethodReturnMessage methodReturnMessage)
        {
            MethodCallMessage = methodCallMessage;
            MethodReturnMessage = methodReturnMessage;
        }

        public abstract string StartegyName { get; }

        public virtual IMethodCallMessage MethodCallMessage { get; }

        public virtual IMethodReturnMessage MethodReturnMessage { get; }

        public abstract void Execute();

    }
}