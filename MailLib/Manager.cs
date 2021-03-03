
using System;
using System.Collections.Generic;
using System.Linq;
using S22.Imap;
using System.Net.Mail;
namespace MailLib
{
    public static class Manager
    {

        public static List<DeliveryMessage> GetMessages(
            string username,
            string password,
            SearchCondition searchCondition = null
        )
        {
            List<DeliveryMessage> res = new List<DeliveryMessage>();
            MessageFinder mf = new MessageFinder(username, password);

            IEnumerable<MailMessage> messages = mf.GetMessagesBySearchCondition(searchCondition ?? SearchCondition.From("from@gmail.com").And(SearchCondition.Subject("subject")).And(SearchCondition.Unseen())); 

            foreach (var msg in messages)
            {
                res.Add(new DeliveryMessage(msg));
                
            }

            return res;
        }
#if DEBUG
        static void Main(string[] args)
        {

            List<DeliveryMessage> msgs = GetMessages("username", "password");
           

            foreach(var m in msgs)
                Console.WriteLine(m.Data);
            Console.ReadKey();
        }
#endif
    }
}
