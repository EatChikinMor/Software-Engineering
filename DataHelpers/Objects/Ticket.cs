using System;

namespace DataHelpers.Objects
{
    public class Ticket
    {
        public Guid TicketNo { get; set; }

        public Int32 EventID { get; set; }

        public Int32 Level { get; set; }

        public Char Section { get; set; }

        public Int32 Row { get; set; }

        public Int32 Seat { get; set; }
    }
}
