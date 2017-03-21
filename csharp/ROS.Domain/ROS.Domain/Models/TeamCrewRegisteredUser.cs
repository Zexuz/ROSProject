namespace ROS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TeamCrewRegisteredUser
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int RegisteredUserId { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }

        public virtual Team Team { get; set; }
    }
}
