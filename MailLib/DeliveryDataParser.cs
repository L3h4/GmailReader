using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailLib
{
    class DeliveryDataParser
    {
        public string Text { get; set; }
        public DeliveryDataParser(string text)
        {
            Text = text;
        }

        public void CutUselessText()
        {
            string firstKeyword = "Pick-up at";
            string secondKeyword = "If you are interested in this load";
            Text = Text.Substring(Text.IndexOf(firstKeyword));
            Text = Text.Substring(0, Text.IndexOf(secondKeyword));
            Text = Text.Trim();            

            //Console.WriteLine(Text);
        }

        public Dictionary<string, string> Parse()
        {
            string[] rawStrings = Text.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            foreach(var rs in rawStrings)
                keyValues.Add(rs.Split(":".ToCharArray(), 2).First().Trim(), rs.Split(":".ToCharArray(), 2).Last().Trim());

            
            return keyValues;
        }
    }
}
