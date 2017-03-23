namespace ROS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RaceEntry
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int RaceId { get; set; }

        public virtual RaceEvent RaceEvent { get; set; }

        public virtual Team Team { get; set; }
    }
}
