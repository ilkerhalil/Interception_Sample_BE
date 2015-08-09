using System;

namespace Interception_Sample_BE
{
    public class ErrorHandlerAttribute: Attribute
    {
        public string NotifyEmail { get; }

        public int Order { get; set; }


        public ErrorHandlerAttribute(string notifyEmail)
        {
            NotifyEmail = notifyEmail;
        }

    }
}