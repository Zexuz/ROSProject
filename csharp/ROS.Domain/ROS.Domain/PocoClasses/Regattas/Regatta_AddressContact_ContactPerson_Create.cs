using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.PocoClasses.Regattas
{
    public class Regatta_AddressContact_ContactPerson_Create
    {
        [Required]
        [StringLength(50)]
        public string Regatta_Name { get; set; }

        public DateTime Regatta_StartDateTime { get; set; }

        public DateTime Regatta_EndDateTime { get; set; }

        public int Regatta_Fee { get; set; }

        [StringLength(1024)]
        public string Regatta_Description { get; set; }

        [StringLength(50)]
        public string AddressContact_PhoneNumber { get; set; }

        [StringLength(50)]
        public string AddressContact_Country { get; set; }

        [StringLength(50)]
        public string AddressContact_BoxNumber { get; set; }

        [StringLength(50)]
        public string AddressContact_StreetAddress { get; set; }

        [StringLength(50)]
        public string AddressContact_City { get; set; }

        [StringLength(50)]
        public string AddressContact_ZipCode { get; set; }
    }
}
