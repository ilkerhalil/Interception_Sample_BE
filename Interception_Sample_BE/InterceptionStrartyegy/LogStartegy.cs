using System;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public class LogStartegy : BaseStartegy
    {
        private readonly Logger _logger;
        public LogStartegy()
        {
            _logger = new Logger();
        }

        public override void Execute(IMethodCallMessage callMsg, ref IMethodReturnMessage retMsg)
        {
            _logger.Logla(callMsg.InArgs.Select(d => d.ToString()).ToArray());
        }
    }
}