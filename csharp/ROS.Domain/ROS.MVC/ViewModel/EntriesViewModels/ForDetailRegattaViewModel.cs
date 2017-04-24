using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ROS.Domain.Models;

namespace ROS.MVC.ViewModel.EntriesViewModels
{
    public class ForDetailRegattaViewModel
    {

        public int Id { get; set; }

        public int HostingClubId { get; set; }

        public int? AddressContactId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int Fee { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public virtual AddressContact AddressContact { get; set; }

        public virtual Club Club { get; set; }

        public virtual ContactPerson ContactPerson { get; set; }
    }
}