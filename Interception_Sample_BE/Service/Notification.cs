namespace Interception_Sample_BE
{
    public class Notification
    {
        private readonly SmsService _smsService;
        private EmailService _emailService;

        public Notification(SmsService smsService)
        {
            _smsService = smsService;
            _emailService = new EmailService();
        }

        public void SendSms(string phoneNo, string content)
        {
            _smsService.SendSms(phoneNo, content);
        }

        public void SendEmail(string[] to, string[] cc, string subject, string content)
        {
            _emailService.SendEmail(to, cc, subject, content);
        }
    }
}