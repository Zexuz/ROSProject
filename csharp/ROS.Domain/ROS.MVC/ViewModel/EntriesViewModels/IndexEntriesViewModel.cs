using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ROS.Domain.Models;
using Boat = ROS.MVC.PocoClasses.Entries.Boat;

namespace ROS.MVC.ViewModel.EntriesViewModels
{
    public class IndexEntriesViewModel
    {
        public int Id { get; set; }

        [DisplayName("Sail Number")]
        public int BoatId { get; set; }

        [DisplayName("Skipper Email")]
        public int SkipperId { get; set; }

        [DisplayName("Regatta Name")]
        public int RegattaId { get; set; }

        [DisplayName("Entry Number")]
        public int Number { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Paid")]
        public bool HasPayed { get; set; }

        [DisplayName("Paid")]
        public string HasPayedMessage { get { return HasPayed ? "Yes" : "No"; } }

        public virtual Boat Boat { get; set; }

        public virtual Regatta Regatta { get; set; }

        public virtual User User { get; set; }
    }
}