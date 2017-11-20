using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstateMVC.Models
{
    public partial class DetailedListing
    {
        public EstateMVC.Models.Listing listing { get; set; }
        public string imagePath { get; set; }
    }
}