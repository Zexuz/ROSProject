using System;

namespace ROS.Models
{
    public class Entry
    {
        public int Id { get; set; }

        public DateTime RegistrationDate{ get; set; }

        public int Number { get; set; }

        public bool HasPaid { get; set; }

        public int  TotalFee { get; set; }


    }
}