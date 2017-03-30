using System.ComponentModel.DataAnnotations;

namespace ROS.MVC.PocoClasses.Entries
{
    public class BoatCreate
    {
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
        }
    }
