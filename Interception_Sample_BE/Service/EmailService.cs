using System;

namespace Interception_Sample_BE
{
    public class EmailService
    {
        public void SendEmail(string[] to, string[] cc, string subject, string content)
        {
            Console.WriteLine("Mail gönderiliyor To {0} -- Subject {1} \n{2}",string.Join(",",to),subject,content);
        }
    }
}