using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstateMVC.Models
{
    public partial class EstateSearching
    {
        public int MaxPrice { get; set; }
        public int MinPrice { get; set; }
        public int RoomAmount { get; set; }
        public int BedroomAmount { get; set; }
        public int BathroomAmount { get; set; }
    }
}