using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Infrastructure.Logging;

namespace Com.Jamim.Infrastructure.Email
{
    public class TextLoggingEmailService : IEmailService
    {

        public void SendMail(string from, string to, string subject, string body)
        {
            StringBuilder email = new StringBuilder();
            email.AppendLine(String.Format("To:{0}", to));
            email.AppendLine(String.Format("From:{0}", from));
            email.AppendLine(String.Format("Subject:{0}", subject));
            email.AppendLine(String.Format("Body:{0}", body));

            LoggingFactory.GetLogger().Log(LogType.Customer, email.ToString(), MessageType.Notice);
        }
    }
}
