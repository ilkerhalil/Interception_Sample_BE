using System;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public class LogStartegy : BaseBeforeStartegy
    {
        private readonly Logger _logger;
        public LogStartegy(IMethodCallMessage methodCallMessage) 
            : base(methodCallMessage)
        {
            _logger = new Logger();
        }

        public override void Execute()
        {
            _logger.Logla(this.MethodCallMessage.InArgs.Select(d => d.ToString()).ToArray());
        }
    }
}