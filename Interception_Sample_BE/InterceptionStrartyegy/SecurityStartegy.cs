using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace Interception_Sample_BE
{
    public class SecurityStartegy: BaseStartegy
    {
        private readonly string _userName;
        private readonly string _role;
        private readonly Security security;
        public SecurityStartegy(MarshalByRefObject marshalByRefObject, IMethodCallMessage message,string userName, string role)
            :base(marshalByRefObject,message)
        {
            _userName = userName;
            _role = role;
            this.security = new Security();
        }

        public override IMethodReturnMessage Execute()
        {
            if(!security.CheckAuthorization(this._userName, this._role))throw new SecurityException();
            return RemotingServices.ExecuteMessage(MarshalByRefObject, Message);
        }

    }
}