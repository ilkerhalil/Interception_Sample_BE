using System;
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
            throw new NotImplementedException();
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