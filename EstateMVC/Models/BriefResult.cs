using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstateMVC.Models
{
    public partial class BriefResult
    {
        [Display(Name = "Podgląd")]
        public string ImagePath { get; set; }

        [Display(Name = "Identyfikator")]
        public string HLCN { get; set; }

        [Display(Name = "Cena")]
        public decimal HousePrice { get; set; }

        [Display(Name = "Dzielnica")]
        public string HomeLocation { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Ilość pokoi")]
        public int RoomAmount { get; set; }

        [Display(Name = "Ilość łazienek")]
        public int BathroomAmount { get; set; }

        [Display(Name = "Ilość sypialni")]
        public int BedroomAmount { get; set; }


        public BriefResult(string imgpath, string hlcn, decimal hprice,
            string hloc, string address, int roomamt, int bathamt, int bedamt)
        {
            ImagePath = imgpath;
            HLCN = hlcn;
            HousePrice = hprice;
            HomeLocation = hloc;
            Address = address;
            RoomAmount = roomamt;
            BathroomAmount = bathamt;
            BedroomAmount = bedamt;
        }

    }


}