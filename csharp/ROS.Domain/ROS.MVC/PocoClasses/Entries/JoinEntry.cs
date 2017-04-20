using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ROS.MVC.PocoClasses.Entries
{
    public class JoinEntry
    {

        [DisplayName("Entry number, this is a nr that is 6 char long")]
        public string EntryNumber { get; set; }
    }
}