namespace ROS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Result
    {
        public int Id { get; set; }

        public int TeamBoatResultsId { get; set; }

        public int EntryId { get; set; }

        public int RaceEventId { get; set; }

        public int? Distace { get; set; }

        public int? CalculatedDistance { get; set; }

        public int? Time { get; set; }

        public int? CalculatedTime { get; set; }

        public int? Rank { get; set; }

        [StringLength(3)]
        public string Remark { get; set; }

        public int? Points { get; set; }

        public virtual Entry Entry { get; set; }

        public virtual RaceEvent RaceEvent { get; set; }

        public virtual TeamBoatResult TeamBoatResult { get; set; }
    }
}
