using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailLib
{
    public class DeliveryData
    {
        private Dictionary<string, string>  parsedFrom;
        public string PickUpAt;
        public string PickUpDateEST;
        public string DeliverTo;
        public string DeliveryDateEST;
        public int Miles;
        public int Pieces;
        public int Weight;
        public string Dims;
        public bool Stackable;
        public bool Hazardous;
        public bool FASTLoad;
        public bool DockLevel;
        public string SuggestedTruckSize;
        public string Notes;
        public DeliveryData(Dictionary<string, string> data)
        {
            parsedFrom = data;
            //TODO add date parsing
            PickUpAt = data["Pick-up at"];
            PickUpDateEST = data["Pick-up date (EST)"];
            DeliverTo = data["Deliver to"];
            DeliveryDateEST = data["Delivery date (EST)"];
            Miles = int.Parse(data["Miles"]);
            Pieces = int.Parse(data["Pieces"]);
            Weight = int.Parse(data["Weight"]);
            Dims = data["Dims"];
            Stackable = data["Stackable"] == "Yes";
            Hazardous = data["Hazardous"] == "Yes";
            FASTLoad = data["FAST Load"] == "Yes";
            DockLevel = data["Dock Level"] == "Yes";
            SuggestedTruckSize = data["Suggested Truck Size"];
            Notes = data["Notes"];

        }

        public override string ToString()
        {
            string str = "DeliveryData \n{";
            foreach (var kv in parsedFrom)
                str += $"\n\t{kv.Key}  =  {kv.Value}";
            str += "\n}";
            return str;
        }
    }
}
