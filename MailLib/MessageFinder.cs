using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using S22.Imap;
using S22;
using System.Net.Mail;

namespace MailLib
{
    class MessageFinder
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public MessageFinder()
        {

        }
        public MessageFinder(string login, string password)
        {
            Username = login;
            Password = password;
        }

        public IEnumerable<MailMessage> GetMessagesBySearchCondition(SearchCondition condition)
        {
            IEnumerable<MailMessage> messages;
            using (ImapClient client = new ImapClient("imap.gmail.com", 993, Username, Password, AuthMethod.Login, true))
            {
                IEnumerable<uint> uids = client.Search(condition);
                messages = client.GetMessages(uids);
            }
            return messages;
        }
    }
}
