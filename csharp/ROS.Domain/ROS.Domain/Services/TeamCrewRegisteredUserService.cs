using ROS.Domain.Contexts;
using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Services
{
    public class TeamCrewRegisteredUserService
    {
        private readonly TeamCrewRegisteredUserContext _teamCrewRegisteredUserContext;

        public TeamCrewRegisteredUserService(TeamCrewRegisteredUserContext teamCrewRegisteredUserContext)
        {
            _teamCrewRegisteredUserContext = teamCrewRegisteredUserContext;
        }

        public IEnumerable<int> GetAllregisteredUserIdsByTeamId(int teamId)
        {
            return _teamCrewRegisteredUserContext.TeamCrewRegisteredUser.Where(r => r.TeamId == teamId).Select(r => r.RegisteredUserId);
        }

        public IEnumerable<int> GetAllTeamIdsByUserId(int userId)
        {
            return _teamCrewRegisteredUserContext.TeamCrewRegisteredUser.Where(r => r.RegisteredUserId == userId).Select(r => r.TeamId);
        }

        public TeamCrewRegisteredUser Add(int userId, int teamId)
        {
            TeamCrewRegisteredUser newTeamCrewRegisteredUser = new TeamCrewRegisteredUser { RegisteredUserId = userId, TeamId = teamId };
            TeamCrewRegisteredUser returnedTeamCrewRegisteredUser = _teamCrewRegisteredUserContext.TeamCrewRegisteredUser.Add(newTeamCrewRegisteredUser);
            _teamCrewRegisteredUserContext.Context.SaveChanges();
            return returnedTeamCrewRegisteredUser;
        }

        public TeamCrewRegisteredUser Remove(TeamCrewRegisteredUser teamCrewRegisteredUser)
        {
            var removedTeamCrewRegisteredUser = _teamCrewRegisteredUserContext.TeamCrewRegisteredUser.Remove(teamCrewRegisteredUser);
            _teamCrewRegisteredUserContext.Context.SaveChanges();
            return removedTeamCrewRegisteredUser;
        }
    }
}
