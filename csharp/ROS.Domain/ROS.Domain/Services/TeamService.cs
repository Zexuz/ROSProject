﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROS.Domain.Contexts;
using ROS.Domain.Models;

namespace ROS.Domain.Services
{
    public class TeamService
    {
        private readonly TeamContext _teamContext;

        public TeamService(TeamContext teamContext)
        {
            _teamContext = teamContext;
        }

        public IEnumerable<Team> GetAll()
        {
            return _teamContext.Team;
        }

        public Team Add(Team team)
        {
            if (!isUserValid(team))
                throw new ArgumentException();

            var returnedTeam = _teamContext.Team.Add(team);
            _teamContext.Context.SaveChanges();
            return returnedTeam;
        }


        private bool isUserValid(Team team)
        {
            //todo validate user
            return true;
        }

        public Team Remove(Team team)
        {
            var removedTeam = _teamContext.Team.Remove(team);
            _teamContext.SaveChanges();
            return removedTeam;
        }

        public Team Edit(Team team)
        {
            var dbTeam = _teamContext.Team.SingleOrDefault(u => u.Id == team.Id);

            if (dbTeam == null)
            {
                throw new Exception("Can't find team in db!");
            }

           
            dbTeam.Name = team.Name;
          
            _teamContext.SaveChanges();

            return team;
        }


    }
}
