using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailLib
{
    public struct DeliveryData
    {
        string PickUpAt;
        string PickUpDateEST;
        string DeliverTo;
        string DeliveryDateEST;
        int Miles;
        int Pieces;
        int Weight;
        string Dims;
        bool Stackable;
        bool Hazardous;
        bool FASTLoad;
        bool DockLevel;
        string SuggestedTruckSize;
        string Notes;
    }
}
