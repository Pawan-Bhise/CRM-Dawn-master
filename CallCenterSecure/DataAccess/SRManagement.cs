using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CallCenter.DataAccess
{
    public class SRManagement
    {
        public int SRId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string AgentName { get; set; }
        public string RequestComplaintDetails { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string SubSubCategory { get; set; }
        public string Remark { get; set; }
        public DateTime? TicketOpenDate { get; set; }
        public DateTime? TicketCloseDate { get; set; }
        public string TicketOpenAgentName { get; set; }
        public string TicketCloseAgentName { get; set; }
        public string Status { get; set; } //Open, Inprogress, Hold, Closed, Cancelled
        public string TypeOfCaller { get; set; }
        public string CustomerSegment { get; set; }
        public string TypeOfCall { get; set; }
        public string  ResoluctionFeedback { get; set; }



        public string NatureofComplaints { get; set; }
        public string Address { get; set; }
        public string BranchName { get; set; }
        public string BranchOther { get; set; }
        public string RequestForResoluction { get; set; }

        public string TypeOfCallerOther { get; set; }
        public string TypeOfProduct { get; set; }
        public string TypeOfProductOther { get; set; }
        public string RegionComplaint { get; set; }

        public string RegionProduct { get; set; }
        public string Town { get; set; }
        public string TypeOfBusiness { get; set; }
        public string TypeOfBusinessOther { get; set; }

        public string Gender { get; set; }
        public string BranchNameClient { get; set; }

        [NotMapped]
        public string SlaBridge { get; set; }




    }
}