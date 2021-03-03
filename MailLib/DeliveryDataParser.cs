using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace MailLib
{
    class DeliveryDataParser
    {
        public string Text { get; set; }
        public DeliveryDataParser(string text)
        {
            Text = text;
        }
        public DeliveryDataParser(MailMessage msg)
        {
            Text = msg.Body;
        }

        private void CutUselessText()
        {
            string firstKeyword = "Pick-up at";
            string secondKeyword = "If you are interested in this load";
            Text = Text.Substring(Text.IndexOf(firstKeyword));
            Text = Text.Substring(0, Text.IndexOf(secondKeyword));
            Text = Text.Trim();            

        }

        public DeliveryData Parse()
        {
            CutUselessText();
            string[] rawStrings = Text.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            foreach(var rs in rawStrings)
                keyValues.Add(rs.Split(":".ToCharArray(), 2).First().Trim(), rs.Split(":".ToCharArray(), 2).Last().Trim());

            DeliveryData dd = new DeliveryData(keyValues);
            
            return dd;
        }
    }
}
