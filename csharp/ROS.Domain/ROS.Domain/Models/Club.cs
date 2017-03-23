namespace ROS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Club
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Club()
        {
            ClubAdmins = new HashSet<ClubAdmin>();
            Memberships = new HashSet<Membership>();
            Regattas = new HashSet<Regatta>();
        }

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

        public virtual AddressContact AddressContact { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClubAdmin> ClubAdmins { get; set; }

        public virtual ContactPerson ContactPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Membership> Memberships { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Regatta> Regattas { get; set; }
    }
}
