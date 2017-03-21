namespace ROS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Team()
        {
            RaceEntries = new HashSet<RaceEntry>();
            TeamBoatResults = new HashSet<TeamBoatResult>();
            TeamCrewRegisteredUsers = new HashSet<TeamCrewRegisteredUser>();
        }

        public int Id { get; set; }

        public int EntryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual Entry Entry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceEntry> RaceEntries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamBoatResult> TeamBoatResults { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamCrewRegisteredUser> TeamCrewRegisteredUsers { get; set; }
    }
}
