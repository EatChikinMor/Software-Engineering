using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHelpers.Objects;


namespace DataHelpers
{
    public class AddEventController
    {
        private Event mEvent;
        private TicketingDBConnector mDBC;

        public AddEventController()
        {
            mEvent = new Event();
            mDBC = new TicketingDBConnector();
        }

        public bool addEvent(string name, DateTime date, bool flr, bool l1, bool l2, Decimal bp, Decimal mp)
        {
            mEvent = new Event();

            mEvent.Name = name;
            mEvent.Date = date;
            mEvent.Floor = flr;
            mEvent.Level1 = l1;
            mEvent.Level2 = l2;
            mEvent.BasePrice = bp;
            mEvent.MaxPrice = mp;

            if (mDBC.save(mEvent))
                return true;
            else
                return false;
        }
    }
}
