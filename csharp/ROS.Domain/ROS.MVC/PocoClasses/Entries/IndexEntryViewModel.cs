using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ROS.Domain.Models;

namespace ROS.MVC.PocoClasses.Entries
{
    class IndexEntryViewModel
    {
        public int Id { get; set; }

        public int BoatId { get; set; }

        public int SkipperId { get; set; }

        public int RegattaId { get; set; }

        [DisplayName("Entry Number")]
        public int Number { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Registration Date")]
        public DateTime RegistrationDate { get; set; }

        public bool HasPayed { get; set; }

        [DisplayName ("Has Payed")]
        public string HasPayedMessage { get { return HasPayed ? "Yes" : "No"; } }

        public virtual Boat Boat { get; set; }

        public virtual Regatta Regatta { get; set; }

        public virtual User User { get; set; }
    }
}
