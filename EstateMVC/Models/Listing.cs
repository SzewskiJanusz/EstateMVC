//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstateMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Listing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Listing()
        {
            this.ListingPicture = new HashSet<ListingPicture>();
        }
    
        public long ListingID { get; set; }
        public string HLCN { get; set; }
        public decimal HousePrice { get; set; }
        public int RoomAmount { get; set; }
        public int BathroomAmount { get; set; }
        public int BedroomAmount { get; set; }
        public string HomeLocation { get; set; }
        public string ContactName { get; set; }
        public string EmailContact { get; set; }
        public string PhoneContact { get; set; }
        public string Address { get; set; }
        public string HomeSurfaceArea { get; set; }
        public string ParcelSurfaceArea { get; set; }
        public string YearBuilt { get; set; }
        public string ParcelSize { get; set; }
        public int GarageSlots { get; set; }
        public string Notes { get; set; }
        public string TypeOfProperty { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListingPicture> ListingPicture { get; set; }
    }
}
