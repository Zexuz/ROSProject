using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.PocoClasses.Entries
{
    public class PocoBoat
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SailNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public double? Handicap { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        public string DropDownInfo
        {
            get
            {
                return $"{Name} {SailNumber}";
            }
        }
    }
}
