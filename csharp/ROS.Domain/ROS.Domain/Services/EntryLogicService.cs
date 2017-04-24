using ROS.Domain.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Services
{
    public class EntryLogicService
    {
        private readonly RegisteredUserContext _registeredUserContext;
        private readonly EntryContext _entryContext;


        public EntryLogicService()
        {
            _registeredUserContext = new RegisteredUserContext();
            _entryContext = new EntryContext();
        }

        public int GetEntryIdFromEntryNumber(int entryNumber)
        {
            int entryId = _entryContext.Entries.SingleOrDefault(e => e.Number == entryNumber).Id;
            return entryId;
        }
    }
}
