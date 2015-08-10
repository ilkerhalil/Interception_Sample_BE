using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public interface IStartegy
    {
        string StartegyName { get;  }
        void Execute();
    }
}