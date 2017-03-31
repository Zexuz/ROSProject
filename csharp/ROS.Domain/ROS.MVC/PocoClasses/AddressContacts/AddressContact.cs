using System.ComponentModel;

namespace ROS.MVC.PocoClasses.AddressContacts
{
    public class AddressContact
    {

        [DisplayName("Next of kin")]
        public string NextOfKin { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("Box number")]
        public string BoxNumber { get; set; }

        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Zip code")]
        public string ZipCode { get; set; }


    }
}