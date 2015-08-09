using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Interception_Sample_BE
{
    public interface IStartegy
    {
        IMethodReturnMessage Execute();
    }
}