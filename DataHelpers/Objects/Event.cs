using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DataHelpers.Objects
{
    public class Event
    {
        public Int32 ID { get; set; }

        public String Name { get; set; }

        public DateTime Date { get; set; }

        public Boolean Floor { get; set; }

        public Boolean Level1 { get; set; }

        public Boolean Level2 { get; set; }

        public Decimal BasePrice { get; set; }

        public Decimal MaxPrice { get; set; }

    }
}
