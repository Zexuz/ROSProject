using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ROS.MVC.PocoClasses.Clubs
{
    public class PocoClub
    {
        public int Id { get; set; }

        public int? ContactPersonsId { get; set; }

        public int? AddressContactId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(2083)]
        public string Logo { get; set; }

        [StringLength(2083)]
        public string HomePage { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }


    }
}
