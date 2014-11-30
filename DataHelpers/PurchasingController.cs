using DataHelpers.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelpers
{
    public class PurchasingController
    {
        #region private members

        private Event selectedEvent = new Event();

        private static DBConnector _TDH = new DBConnector();

        #endregion

        public Event buildEvent(DataRow Row)
        {
            selectedEvent = new Event()
            {
                ID = Convert.ToInt32(Row["ID"].ToString()),
                Name = Row["Name"].ToString(),
                Date = Convert.ToDateTime(Row["Date"].ToString()),
                Floor = Convert.ToBoolean(Row["Floor"].ToString()),
                Level1 = Convert.ToBoolean(Row["Level1"].ToString()),
                Level2 = Convert.ToBoolean(Row["Level2"].ToString()),
                BasePrice = Convert.ToDecimal(Row["BasePrice"].ToString()),
                MaxPrice = Convert.ToDecimal(Row["MaxPrice"].ToString())
            };

            return selectedEvent;
        }

        public Decimal GenerateTicketPrice(int LevelIndex, string Section, int Row)
        {
            int Levels = 0;

            if (selectedEvent.Floor && selectedEvent.Level1 && selectedEvent.Level2)
            {
                Levels = 3;
            }
            else if ((!selectedEvent.Floor & (selectedEvent.Level1 ^ selectedEvent.Level2)) || (selectedEvent.Floor & !(selectedEvent.Level1 | selectedEvent.Level2)))
            {
                Levels = 1;
            }
            else
            {
                Levels = 2;
            }

            Decimal price, increment;

            Dictionary<string, int> section = new Dictionary<string, int>()
	        {
	            {"A", 1},
	            {"B", 1},
	            {"C", 2},
	            {"D", 2},
                {"E", 3},
                {"F", 3},
                {"G", 4},
                {"H", 4},
                {"I", 5},
                {"J", 5}
	        };

            decimal BasePrice = selectedEvent.BasePrice, MaxPrice = selectedEvent.MaxPrice;

            int seatPriceRange = (Levels * section.Keys.Count * 25) / 2; //A = B, C = D etc, only require half the
            //tickets to be priced -> divide by two

            increment = (MaxPrice - BasePrice) / (seatPriceRange - 1);

            BasePrice = BasePrice - increment;

            //125x + 25(y-1) + z-1 => Alternate = 125x + 25y + z - 26
            price = BasePrice + (increment * (seatPriceRange - ((125 * LevelIndex) + (25 * (section[Section] - 1)) + (Row - 1))));

            return Math.Round(price, 2);
        }

        public int[] getSeats(int Level, char Section, int Row)
        {
            List<Int32> Seats = new List<Int32>();

            for (int i = 1; i < 26; i++)
            {
                Seats.Add(i);
            }

            DataTable dt = _TDH.GetUnavailableSeats(selectedEvent.ID, Level, Section, Row);

            foreach (DataRow row in dt.Rows)
            {
                Seats.Remove(Convert.ToInt32(row.ToString()));
            }

            int[] ReturnSeats = new int[Seats.Count];


            for (int i = 0; i < Seats.Count; i++)
            {
                ReturnSeats[i] = Seats[i];
            }
            
            return ReturnSeats;
        }

        public bool cardCheck(string creditCardNumber)
        {
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                return false;
            }
            else if (creditCardNumber.Length > 19 || creditCardNumber.Length < 12)
            {
                return false;
            }

            int sumOfDigits = creditCardNumber.Where((e) => e >= '0' && e <= '9').Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2)).Sum((e) => e / 10 + e % 10);

            return sumOfDigits % 10 == 0;
        }

        public Guid SubmitOrder(int Level, char Section, int Row, int Seat, string LastFour, ref string orderNumber)
        {
            Ticket ticket = new Ticket()
            {
                TicketNo = Guid.NewGuid(),
                EventID = selectedEvent.ID,
                Level = Level,
                Row = Row,
                Section = Section,
                Seat = Seat
            };
            int count = 0;

            orderNumber = _TDH.GenerateTicket(ticket, ref count);

            _TDH.GenerateOrder(ticket.TicketNo, orderNumber, LastFour);

            return ticket.TicketNo;
        }
    }
}
