using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ROS.Domain.Models;
//using Boat = ROS.MVC.PocoClasses.Entries.Boat;

namespace ROS.MVC.ViewModel.EntriesViewModels
{
    public class ForDetailEntryViewModel
    {

        public int Id { get; set; }

        public int BoatId { get; set; }

        public int SkipperId { get; set; }

        public int RegattaId { get; set; }

        public int Number { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Registration date")]
        public string RegistrationDateShortTimeString { get { return RegistrationDate.ToShortDateString(); } }

        public bool HasPayed { get; set; }

        [DisplayName("Has payed")]
        public string HasPayedMessage { get { return HasPayed ? "Yes" : "No"; } }

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