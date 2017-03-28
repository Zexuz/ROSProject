using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.PocoClasses.Regattas
{
    public class PocoRegatta
    {
        public int Id { get; set; }

        public int? ContactPersonsId { get; set; }

        public int HostingClubId { get; set; }

        public int? AddressContactId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int Fee { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public virtual AddressContact AddressContact { get; set; }

        public virtual Club Club { get; set; }

        public virtual ContactPerson ContactPerson { get; set; }

        [Required]
        [StringLength(100)]
        public string ContactPersonEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactPersonPhoneNumber { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string BoxNumber { get; set; }

        [StringLength(50)]
        public string StreetAddress { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string ZipCode { get; set; }
    }
}
