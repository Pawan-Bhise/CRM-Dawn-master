using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenterSecure.Models
{
    public class TicketExcelExport
    {
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string CallingNumber { get; set; }
        public string TypeOfCall { get; set; }
        public string CollectionPointNumber { get; set; }
        public string BranchName { get; set; }
        public string RepaymentAmount { get; set; }
        public string TotalDueAmount { get; set; }
        public string SchPaid { get; set; }
        public string RepaymentVoucher { get; set; }
        public string DepositeSavingAmount { get; set; }
        public string WithdrawAmount { get; set; }
        public string MessageFromDawn { get; set; }
        public string CashIs { get; set; }
        public string AmountCorrect { get; set; }
        public DateTime? CollectionDate { get; set; }
        public string Remark { get; set; }
        public DateTime? TicketOpenDate { get; set; }
   
    }
}