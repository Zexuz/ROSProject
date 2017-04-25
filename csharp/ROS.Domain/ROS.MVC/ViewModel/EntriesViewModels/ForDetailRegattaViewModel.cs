using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ROS.Domain.Models;

namespace ROS.MVC.ViewModel.EntriesViewModels
{
    public class ForDetailRegattaViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ForDetailRegattaViewModel()
        {
            Entries = new HashSet<Entry>();
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }

        public int? ContactPersonsId { get; set; }

        public int HostingClubId { get; set; }

        public int? AddressContactId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Start date")]
        public DateTime StartDateTime { get; set; }

        [DisplayName("End date")]
        public DateTime EndDateTime { get; set; }

        [DisplayName("Joining fee")]
        public int Fee { get; set; }

        [DisplayName("Regatta Description")]
        [StringLength(1024)]
        public string Description { get; set; }

        public virtual AddressContact AddressContact { get; set; }

        public virtual Club Club { get; set; }

        public virtual ContactPerson ContactPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
    }
}