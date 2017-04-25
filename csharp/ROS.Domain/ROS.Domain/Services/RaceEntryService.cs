using ROS.Domain.Contexts;
using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Services
{
    public class RaceEntryService
    {
        private readonly RaceEntryContext _raceEntryContext;

        public RaceEntryService(RaceEntryContext raceEntryContext)
        {
            _raceEntryContext = raceEntryContext;
        }

        public RaceEntry GetByTeamId(int teamId)
        {
            return _raceEntryContext.RaceEntry.SingleOrDefault(r => r.TeamId == teamId);
        }

        public IEnumerable<RaceEntry> GetEventIdsById(int teamId)
        {
            return _raceEntryContext.RaceEntry.Where(r => r.TeamId == teamId);
        }

        public RaceEntry Add(int teamId, int raceId)
        {
            RaceEntry newRaceEntry = new RaceEntry { TeamId = teamId, RaceId = raceId };
            RaceEntry returnedRaceEntry = _raceEntryContext.RaceEntry.Add(newRaceEntry);
            _raceEntryContext.Context.SaveChanges();
            return returnedRaceEntry;
        }
    }
}
