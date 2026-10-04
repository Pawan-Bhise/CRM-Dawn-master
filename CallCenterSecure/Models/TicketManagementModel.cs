using CallCenter.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallCenter.Models
{
    public class TicketManagementModel
    {
        public int TicketId { get; set; }
         
        public string Name { get; set; }
         
        public string CallingNumber { get; set; }
        public string TypeOfCaller { get; set; }
        public string CustomerSegment { get; set; }
        public string TypeOfCall { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string SubSubCategory { get; set; }
        public string Remark { get; set; }
        //public List<SelectListItem> CategoryList { get; set; }

        public List<CategoryMaster> CategoryList { get; set; }
        public List<SubCategoryMaster> SubCategoryList { get; set; }
        public List<SubSubCategoryMaster> SubSubCategoryList { get; set; }

        public List<TicketManagement> TicketList { get; set; }

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

        public string SPParameterValue { get; set; }
        public string TotalDueAmount { get; set; }
        public string SchPaid { get; set; }
        public string GL_Remark { get; set; }
        public string IL_Remark { get; set; }
        public string ALL_IL_Remark { get; set; }

        public string GLClientId { get; set; }
        public string ILClientId { get; set; }
        public string All_ILClientId { get; set; }
        public string VSAClientId { get; set; }

        public string GLBranchName { get; set; }
        public string ILBranchName { get; set; }
        public string All_ILBranchName { get; set; }
        public string VSABranchName { get; set; }

        public string GLCashIs { get; set; }
        public string ILCashIs { get; set; }

        public string GLName { get; set; }
        public string ILName { get; set; }
        public string All_ILName { get; set; }
        public string VSAName { get; set; }


        public string GLCallingNumber { get; set; }
        public string ILCallingNumber { get; set; }
        public string All_ILCallingNumber { get; set; }
        public string VSACallingNumber { get; set; }


        public DateTime? GLCollectionDate { get; set; }
        public DateTime? ILCollectionDate { get; set; }
        public DateTime? All_ILCollectionDate { get; set; }
        public DateTime? VSACollectionDate { get; set; }

        public string GLCollectionPointNumber { get; set; }
        public string ILCollectionPointNumber { get; set; }
        public string All_ILCollectionPointNumber { get; set; }
        public string VSACollectionPointNumber { get; set; }

        public string GLRepaymentAmount { get; set; }
        public string ILRepaymentAmount { get; set; }
        public string All_ILRepaymentAmount { get; set; }
        public string VSARepaymentAmount { get; set; }

        public string GLWithdrawAmount { get; set; }
        public string ILWithdrawAmount { get; set; }
        public string All_ILWithdrawAmount { get; set; }
        public string VSAWithdrawAmount { get; set; }

        public string GLTotalDueAmount { get; set; }
        public string ILTotalDueAmount { get; set; }
        public string All_ILTotalDueAmount { get; set; }
        public string VSATotalDueAmount { get; set; }

        public string GLDepositeSavingAmount { get; set; }
        public string ILDepositeSavingAmount { get; set; }
        public string All_ILDepositeSavingAmount { get; set; }
        public string VSADepositeSavingAmount { get; set; }

        public string GLSchPaid { get; set; }
        public string ILSchPaid { get; set; }
        public string All_ILSchPaid { get; set; }
        public string VSASchPaid { get; set; }

    }
}