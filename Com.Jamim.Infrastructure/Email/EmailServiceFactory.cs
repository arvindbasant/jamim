using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Infrastructure.Email
{
    public class EmailServiceFactory : IEmailService
    {
        private static IEmailService _emailService;

        public static void InitializeEmailServiceFactory(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public static IEmailService GetEmailService()
        {
            return _emailService;
        }

        public void SendMail(string from, string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
