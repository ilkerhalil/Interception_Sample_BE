using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Interception_Sample_BE
{
    public static class StartegyFactory
    {
        public  static IEnumerable<IStartegy> CreateBeforeStartegyFactory(IMethodCallMessage methodCallMessage, params Type[] beforeStartegies)
        {
            return beforeStartegies.Select(baseBeforeStartegy => Activator.CreateInstance(baseBeforeStartegy, methodCallMessage) as BaseBeforeStartegy);
        }

        public static IEnumerable<IStartegy> CreateAfterStartegyFactory(IMethodCallMessage methodCallMessage, IMethodReturnMessage methodReturnMessage, params Type[] afterStartegies)
        {
            return afterStartegies.Select(baseAfterStartegy => Activator.CreateInstance(baseAfterStartegy, methodCallMessage, methodReturnMessage) as BaseAfterStartegy);
        }
    }
}
