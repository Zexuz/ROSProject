namespace ROS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SocialEntry
    {
        public int Id { get; set; }

        public int RegisteredUserId { get; set; }

        public int SocialEventsId { get; set; }

        public int? Friends { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }

        public virtual SocialEvent SocialEvent { get; set; }
    }
}
