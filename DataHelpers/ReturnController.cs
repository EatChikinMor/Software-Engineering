using DataHelpers.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelpers
{
    public class ReturnController
    {
        #region Class Level Variables

        private TicketingDBConnector _TDH = new TicketingDBConnector();

        #endregion
        public void SubmitRequest(Guid ticketNo)
        {
            _TDH.StoreRequestReturns(ticketNo);
        }

        public void ApproveRequest(Guid approve_request)
        {
            _TDH.StoreApprovedRequest(approve_request);
        }

        public void RejectRequest(Guid reject_request)
        {
            _TDH.StoreRejectRequest(reject_request);
        }
    }
}
  
    

