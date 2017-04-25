using ROS.Domain.Interfaces;

namespace ROS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RegisteredUser : IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegisteredUser()
        {
            SocialEntries = new HashSet<SocialEntry>();
            TeamCrewRegisteredUsers = new HashSet<TeamCrewRegisteredUser>();
        }

        public int Id { get; set; }

        public int EntryId { get; set; }

        public int UserId { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SocialEntry> SocialEntries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamCrewRegisteredUser> TeamCrewRegisteredUsers { get; set; }
    }
}
