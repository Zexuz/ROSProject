﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ROS.Domain.Models;
using Boat = ROS.MVC.PocoClasses.Entries.Boat;

namespace ROS.MVC.ViewModel.EntriesViewModels
{
    public class DetailEntiresViewModel
    {
        private ForDetailEntiryViewModel Entry;
        private ForDetailRegUserViewModel RegUser;
        private ForDetailRegattaViewModel Regatta;
    }
}