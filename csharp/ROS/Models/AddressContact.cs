

namespace ROS.Models
{
    public class AddressContact
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string NextOfKin { get; set; }

        public int Number { get; set; }

        public Address Address { get; set; }

        public void SetAdress(string streetAdress, string boxNumber, string city, string zipCode, string country)
        {
            Address.StreetAdress = streetAdress;
            Address.BoxNumber = boxNumber;
            Address.City = city;
            Address.ZipCode = zipCode;
            Address.Country = country;
        }
    }
}