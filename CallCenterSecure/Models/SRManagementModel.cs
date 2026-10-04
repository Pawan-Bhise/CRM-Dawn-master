using CallCenter.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenter.Models
{
    public class SRManagementModel
    {
        public int SRId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required]
        public string AgentName { get; set; }
        [Required]
        public string RequestComplaintDetails { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string SubSubCategory { get; set; }
        public string Remark { get; set; }
        public List<CategoryMaster> CategoryList { get; set; }
        public List<SubCategoryMaster> SubCategoryList { get; set; }
        public List<SubSubCategoryMaster> SubSubCategoryList { get; set; }
        public List<SRManagement> SRList { get; set; }

        public DateTime? TicketOpenDate { get; set; }
        public DateTime? TicketCloseDate { get; set; }
        public string TicketOpenAgentName { get; set; }
        public string TicketCloseAgentName { get; set; }
        public string Status { get; set; } //Open, Inprogress, Closed

        public string TypeOfCaller { get; set; }
        public string CustomerSegment { get; set; }
        public string TypeOfCall { get; set; }

        public string ResoluctionFeedback { get; set; }
        public string SlaBridge { get; set; }

        public string NatureofComplaints { get; set; }
        public string Address { get; set; }
        public string BranchName { get; set; }
        public string BranchOther { get; set; }
        public string RequestForResoluction { get; set; }
        public string Gender { get; set; }

        public string TypeOfCallerOther { get; set; }
        public string TypeOfProduct { get; set; }
        public string TypeOfProductOther { get; set; }
        public string RegionComplaint { get; set; }
        public string RegionProduct { get; set; }

        public string Town { get; set; }
        public string TypeOfBusiness { get; set; }
        public string TypeOfBusinessOther { get; set; }
        public string BranchNameClient { get; set; }
        



    }
}