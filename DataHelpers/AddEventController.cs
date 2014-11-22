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
        #region private members
        private Event mEvent;
        private TicketingDBConnector mDBC;
        #endregion

        //constructor
        public AddEventController()
        {
            mEvent = new Event();
            mDBC = new TicketingDBConnector();
            //AddEventForm mAEF = new AddEventForm();
            //AddEventConfirmForm mAECF = new AddEventConfirmForm();
        }

        //addEvent takes AddEventForm info and saves it to database
        /// <summary>
        /// description for addEvent
        /// </summary>
        /// <param name="name">Name of event</param>
        /// <param name="date">Date of event</param>
        /// <param name="flr">Floor level</param>
        /// <param name="l1">Level 1</param>
        /// <param name="l2">Level 2</param>
        /// <param name="bp">Base price</param>
        /// <param name="mp">Max price</param>
        public void addEvent(string name, DateTime date, bool flr, bool l1, bool l2, Decimal bp, Decimal mp)
        {
            mEvent = new Event();
            //populate event with data from form
            mEvent.Name = name;
            mEvent.Date = date;
            mEvent.Floor = flr;
            mEvent.Level1 = l1;
            mEvent.Level2 = l2;
            mEvent.BasePrice = bp;
            mEvent.MaxPrice = mp;

            //put event into database
            if (mDBC.save(mEvent))
            {
                //show AddEventConfirmForm
                //mAECF.show();
            }
            else
            { 
                //show AddEventForm cleared
                close();
            }
        }

        public void close()
        { 
            //show addEventForm cleared of data
            //mAEF.clear();
            //mAEF.show();
        }

        public void show()
        { 
            //mAEF.show();
        }
    }
}
