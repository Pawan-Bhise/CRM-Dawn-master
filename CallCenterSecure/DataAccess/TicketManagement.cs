using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CallCenter.DataAccess
{
    public class TicketManagement
    {
        public int TicketId { get; set; }
        public string Name { get; set; }
        public string  CallingNumber { get; set; }
        public string TypeOfCaller  { get; set; }
        public string CustomerSegment { get; set; }
        public string TypeOfCall { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string SubSubCategory { get; set; }
        public string Remark { get; set; }
        public DateTime? TicketOpenDate { get; set; }
        public DateTime? TicketCloseDate { get; set; }
        public string TicketOpenAgentName { get; set; }
        public string TicketCloseAgentName { get; set; }
        public string Status { get; set; } //Open, Inprogress, Closed


        public DateTime? CollectionDate { get; set; }
        public string ClientId { get; set; }
        public string BranchName { get; set; }
        public string CollectionPointNumber { get; set; }
        public string RepaymentAmount { get; set; }
        public string DepositeSavingAmount { get; set; }
        public string WithdrawAmount { get; set; }
        public string RepaymentVoucher { get; set; }
        public string MessageFromDawn { get; set; }
        public string CashIs { get; set; }
        public string AmountCorrect { get; set; }
        public string TotalDueAmount { get; set; }
        public string SchPaid { get; set; }

        [NotMapped]
        public int Duration { get; set; }



    }
}