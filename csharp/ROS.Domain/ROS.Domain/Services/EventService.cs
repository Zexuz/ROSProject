using ROS.Domain.Contexts;
using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Services
{
    class EventService
    {
        private readonly EventContext _eventContext;

        public EventService(EventContext eventContext)
        {
            _eventContext = eventContext;
        }
        public Event GetById(int eventId, int regattaId)
        {
            return _eventContext.Events.SingleOrDefault(e => e.Id == eventId && e.RegattaId == regattaId);
        }
    }
}
