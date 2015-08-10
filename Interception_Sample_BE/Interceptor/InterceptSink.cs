using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public class InterceptSink : IMessageSink
    {
        private readonly IMessageSink _nextSink;

        public InterceptSink(IMessageSink nextSink)
        {
            _nextSink = nextSink;
        }

        public IMessage SyncProcessMessage(IMessage msg)
        {
            var mcm = (msg as IMethodCallMessage);
            IMessage rtnMsg = null;
            try
            {
                ExecuteBeforeStrategy(ref mcm);
            }
            catch (Exception exception)
            {
                var returnMessage = new ReturnMessage(exception,mcm) as IMethodReturnMessage;
                ExecuteAfterStrategy(mcm, ref returnMessage);
                return returnMessage;
            }
            rtnMsg = _nextSink.SyncProcessMessage(msg);
            var methodReturnMessage = (rtnMsg as IMethodReturnMessage);
            ExecuteAfterStrategy(mcm, ref methodReturnMessage);
            return (rtnMsg as IMethodReturnMessage);
        }

        private static void ExecuteAfterStrategy(IMethodCallMessage callMsg, ref IMethodReturnMessage rtnMsg)
        {
            var types =
                callMsg.MethodBase.GetCustomAttributes(typeof(InterceptHandlerAttribute), true)
                    .Where(w => ((InterceptHandlerAttribute)w).InterceptType == InterceptType.After)
                    .Select(s => ((InterceptHandlerAttribute)s).StartegyType).ToArray();
            foreach (var startegy in StartegyFactory.CreateAfterStartegyFactory(callMsg,rtnMsg,types))
            {
                startegy.Execute();
            }
        }

        private static void ExecuteBeforeStrategy(ref IMethodCallMessage callMsg)
        {
            var types =
                callMsg.MethodBase.GetCustomAttributes(typeof(InterceptHandlerAttribute), true)
                    .Where(w => ((InterceptHandlerAttribute)w).InterceptType == InterceptType.Before)
                    .Select(s => ((InterceptHandlerAttribute)s).StartegyType).ToArray();
            foreach (var startegy in StartegyFactory.CreateBeforeStartegyFactory(callMsg, types))
            {
                startegy.Execute();
            }
        }
        

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            var rtnMsgCtrl = _nextSink.AsyncProcessMessage(msg, replySink);
            return rtnMsgCtrl;
        }

        public IMessageSink NextSink
        {
            get { return _nextSink; }
        }
    }
}