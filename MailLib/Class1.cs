#if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using S22.Imap;
using System.Net.Mail;
namespace MailLib
{
    class Program
    {

        static void Main(string[] args)
        {
            MessageFinder mf = new MessageFinder("username", "password"); // юзернейм без @gmail.com

            IEnumerable<MailMessage> messages = mf.GetMessagesBySearchCondition(
                SearchCondition.From("from_username@gmail.com")
                .And(SearchCondition.Subject("subject"))); // можно редактировать

            //IEnumerable<MailMessage> messages = mf.GetMessagesBySearchCondition(
            //    SearchCondition.From("from_username@gmail.com")
            //    .And(SearchCondition.Recent())); // можно редактировать

            DeliveryDataParser parser = new DeliveryDataParser(messages.First().Body);
            parser.CutUselessText();
            Dictionary<string, string> dd = parser.Parse();

            foreach (var kv in dd)
                Console.WriteLine($"{kv.Key} - {kv.Value}");
            
            Console.ReadKey();
        }
    }
}
#endif