using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace MailLib
{
    public class DeliveryMessage
    {
        public MailMessage RawMessage { get; set; }
        public DeliveryData Data { get; set; }
        public DeliveryMessage(MailMessage msg)
        {
            RawMessage = msg;
            Data = new DeliveryDataParser(msg).Parse();
        }
    }
}
