namespace ROS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Entry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entry()
        {
            RegisteredUsers = new HashSet<RegisteredUser>();
            Results = new HashSet<Result>();
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }

        public int BoatId { get; set; }

        public int SkipperId { get; set; }

        public int RegattaId { get; set; }

        public int Number { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        public bool HasPayed { get; set; }

        public string HasPayedMessage
        {
            get { return HasPayed ? "Yes" : "No"; }
        }

        public virtual Boat Boat { get; set; }

        public virtual Regatta Regatta { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegisteredUser> RegisteredUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
