namespace ROS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Membership
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ClubId { get; set; }

        public virtual Club Club { get; set; }

        public virtual User User { get; set; }
    }
}
