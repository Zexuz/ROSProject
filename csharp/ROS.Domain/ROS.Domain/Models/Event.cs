namespace ROS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            RaceEvents = new HashSet<RaceEvent>();
            SocialEvents = new HashSet<SocialEvent>();
        }

        public int Id { get; set; }

        public int RegattaId { get; set; }

        public int? ContactPersonsId { get; set; }

        public int Number { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        public int? MaxParticipants { get; set; }

        public int Fee { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public virtual ContactPerson ContactPerson { get; set; }

        public virtual Regatta Regatta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceEvent> RaceEvents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SocialEvent> SocialEvents { get; set; }
    }
}
