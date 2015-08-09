using System;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public class LogStartegy: BaseStartegy
    {
        private readonly Logger _logger;
        public LogStartegy(MarshalByRefObject marshalByRefObject, IMethodCallMessage message)
            :base(marshalByRefObject,message)
        {
            _logger = new Logger();
        }

        public override IMethodReturnMessage Execute()
        {
            _logger.Logla(Message.InArgs.Select(d => d.ToString()).ToArray());
            return RemotingServices.ExecuteMessage(MarshalByRefObject, Message);
        }
    }
}