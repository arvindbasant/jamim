using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Model.Entities;

namespace Com.Jamim.Services.Customer.Messaging
{
    public class SuccessErrorMessage
    {
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
    }
}
