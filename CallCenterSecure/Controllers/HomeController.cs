using CallCenter.BusinessLogic;
using CallCenter.CustomAuthentication;
using CallCenter.DataAccess;
using CallCenter.Models;
using CallCenterSecure.BusinessLogic;
using CallCenterSecure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallCenter.Controllers
{
    [CustomAuthorize(Roles = "Admin|Supervisor|Agent")]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            User.IsInRole("Admin");

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            return View();
        }
        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }


       

        public ActionResult PieChart(string filter)
        {
            CategoryProvider categoryProvider = new CategoryProvider();
            var ticket = categoryProvider.GetAllTickets();
            var sr = categoryProvider.GetAllSRs();
            ChartSRTicketModel chartSRTicketModel = new ChartSRTicketModel();

            if (filter == "today")
            {
                //chartSRTicketModel.TotalSR = sr.Where(s => Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date).Count(); ;
                chartSRTicketModel.OpenSR = sr.Where(s => s.TypeOfCall.ToLower() == "complaint" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date).Count();
                chartSRTicketModel.InProgressSR = sr.Where(s => s.TypeOfCall.ToLower() == "inquire" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date).Count();
                //chartSRTicketModel.CloseSR = sr.Where(s => s.Status == "Closed" && Convert.ToDateTime(s.TicketCloseDate).Date == Convert.ToDateTime(DateTime.Now).Date).Count();
                chartSRTicketModel.TotalSR = chartSRTicketModel.OpenSR + chartSRTicketModel.InProgressSR + chartSRTicketModel.CloseSR;

                chartSRTicketModel.OpenTicket = ticket.Where(s => s.TypeOfCall == "GLClients" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date).Count();
                chartSRTicketModel.InProgressTicket = ticket.Where(s => s.TypeOfCall == "AllILClients" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date).Count();
                chartSRTicketModel.CloseTicket = ticket.Where(s => s.TypeOfCall == "ILClients" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date).Count();
                chartSRTicketModel.VASClient = ticket.Where(s => s.TypeOfCall == "VSAClients" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date).Count();
                chartSRTicketModel.TotalTicket = chartSRTicketModel.OpenTicket + chartSRTicketModel.InProgressTicket + chartSRTicketModel.CloseTicket + chartSRTicketModel.VASClient;

            }
            else if (filter == "yesterday")
            {
                chartSRTicketModel.OpenSR = sr.Where(s => s.TypeOfCall.ToLower() == "complaint" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date.AddDays(-1)).Count();
                chartSRTicketModel.InProgressSR = sr.Where(s => s.TypeOfCall.ToLower() == "inquire" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date.AddDays(-1)).Count();
                //chartSRTicketModel.CloseSR = sr.Where(s => s.Status == "Closed" && Convert.ToDateTime(s.TicketCloseDate).Date == Convert.ToDateTime(DateTime.Now).Date.AddDays(-1)).Count();
                chartSRTicketModel.TotalSR = chartSRTicketModel.OpenSR + chartSRTicketModel.InProgressSR + chartSRTicketModel.CloseSR;

                chartSRTicketModel.OpenTicket = ticket.Where(s => s.TypeOfCall == "GLClients" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date.AddDays(-1)).Count();
                chartSRTicketModel.InProgressTicket = ticket.Where(s => s.TypeOfCall == "AllILClients" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date.AddDays(-1)).Count();
                chartSRTicketModel.CloseTicket = ticket.Where(s => s.TypeOfCall == "ILClients" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date.AddDays(-1)).Count();
                chartSRTicketModel.VASClient = ticket.Where(s => s.TypeOfCall == "VSAClients" && Convert.ToDateTime(s.TicketOpenDate).Date == Convert.ToDateTime(DateTime.Now).Date.AddDays(-1)).Count();
                chartSRTicketModel.TotalTicket = chartSRTicketModel.OpenTicket + chartSRTicketModel.InProgressTicket + chartSRTicketModel.CloseTicket + chartSRTicketModel.VASClient;

            }
            else if (filter == "lastmonth")
            {
                chartSRTicketModel.OpenSR = sr.Where(s => s.TypeOfCall.ToLower() == "complaint" && Convert.ToDateTime(s.TicketOpenDate).Date >= Convert.ToDateTime(DateTime.Now).Date.AddMonths(-1)).Count();
                chartSRTicketModel.InProgressSR = sr.Where(s => s.TypeOfCall.ToLower() == "inquire" && Convert.ToDateTime(s.TicketOpenDate).Date >= Convert.ToDateTime(DateTime.Now).Date.AddMonths(-1)).Count();
                //chartSRTicketModel.CloseSR = sr.Where(s => s.Status == "Closed" && Convert.ToDateTime(s.TicketCloseDate).Date >= Convert.ToDateTime(DateTime.Now).Date.AddMonths(-1)).Count();
                chartSRTicketModel.TotalSR = chartSRTicketModel.OpenSR + chartSRTicketModel.InProgressSR + chartSRTicketModel.CloseSR;


                chartSRTicketModel.OpenTicket = ticket.Where(s => s.TypeOfCall == "GLClients" && Convert.ToDateTime(s.TicketOpenDate).Date >= Convert.ToDateTime(DateTime.Now).Date.AddMonths(-1)).Count();
                chartSRTicketModel.InProgressTicket = ticket.Where(s => s.TypeOfCall == "AllILClients" && Convert.ToDateTime(s.TicketOpenDate).Date >= Convert.ToDateTime(DateTime.Now).Date.AddMonths(-1)).Count();
                chartSRTicketModel.CloseTicket = ticket.Where(s => s.TypeOfCall == "ILClients" && Convert.ToDateTime(s.TicketOpenDate).Date >= Convert.ToDateTime(DateTime.Now).Date.AddMonths(-1)).Count();
                chartSRTicketModel.VASClient = ticket.Where(s => s.TypeOfCall == "VSAClients" && Convert.ToDateTime(s.TicketOpenDate).Date >= Convert.ToDateTime(DateTime.Now).Date.AddMonths(-1)).Count();
                chartSRTicketModel.TotalTicket = chartSRTicketModel.OpenTicket + chartSRTicketModel.InProgressTicket + chartSRTicketModel.CloseTicket + chartSRTicketModel.VASClient;
            }
            else
            {
                chartSRTicketModel.TotalSR = sr.Count;
                chartSRTicketModel.OpenSR = sr.Where(s => s.TypeOfCall.ToLower() == "complaint").Count();
                chartSRTicketModel.InProgressSR = sr.Where(s => s.TypeOfCall.ToLower() == "inquire").Count();
                //chartSRTicketModel.CloseSR = sr.Where(s => s.Status == "Closed").Count();

                chartSRTicketModel.TotalTicket = ticket.Count;
                chartSRTicketModel.OpenTicket = ticket.Where(s => s.TypeOfCall == "GLClients").Count();
                chartSRTicketModel.InProgressTicket = ticket.Where(s => s.TypeOfCall == "AllILClients").Count();
                chartSRTicketModel.CloseTicket = ticket.Where(s => s.TypeOfCall == "ILClients").Count();
                chartSRTicketModel.VASClient = ticket.Where(s => s.TypeOfCall == "VSAClients").Count();

            }

            var top3Ticket = ticket.GroupBy(t => t.Category).OrderByDescending(d => d.Count()).ToList();
            if (top3Ticket.Count() > 0)
            {
                int count = 1;
                foreach (var item in top3Ticket)
                {
                    if (count <= 3)
                    {
                        var cat = categoryProvider.GetCategoryById(Convert.ToInt32(item.Select(i => i.Category).FirstOrDefault()));
                        if (cat != null)
                            chartSRTicketModel.Top3Ticket += cat.CategoryName.Trim() + "|";
                        else
                            chartSRTicketModel.Top3Ticket += item.Select(i => i.Category).FirstOrDefault() + "|";
                        count++;
                    }
                    else
                        break;
                }
            }

            var top3SR = sr.GroupBy(t => t.Category).OrderByDescending(d => d.Count()).ToList();
            if (top3SR.Count() > 0)
            {
                int count = 1;
                foreach (var item in top3SR)
                {
                    if (count <= 3)
                    {
                        var cat = categoryProvider.GetCategoryById(Convert.ToInt32(item.Select(i => i.Category).FirstOrDefault()));
                        if (cat != null)
                            chartSRTicketModel.Top3SR += cat.CategoryName.Trim() + "|";
                        else
                            chartSRTicketModel.Top3SR += item.Select(i => i.Category).FirstOrDefault() + "|";
                        count++;
                    }
                    else
                        break;
                }
            }

            return Json(chartSRTicketModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LineChart(string chartshow)
        {
            CategoryProvider categoryProvider = new CategoryProvider();
            var ticket = categoryProvider.GetAllTickets();
            ChartSRTicketModel chartSRTicketModel = new ChartSRTicketModel();

            chartSRTicketModel.TotalSR = ticket.Count;
            chartSRTicketModel.OpenSR = ticket.Where(sr => sr.Status == "Open").Count();
            chartSRTicketModel.InProgressSR = ticket.Where(sr => sr.Status == "InProgress").Count();
            chartSRTicketModel.CloseSR = ticket.Where(sr => sr.Status == "Closed").Count();



            return Json(chartSRTicketModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TicketList()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            TicketManagementModel ticketManagementModel = new TicketManagementModel();
            CategoryProvider categoryProvider = new CategoryProvider();
            ticketManagementModel.TicketList = categoryProvider.GetAllTickets();
            int lastDaysData = Convert.ToInt32(ConfigurationManager.AppSettings["LastDaysData"]);
            if (ticketManagementModel.TicketList != null)
                ticketManagementModel.TicketList = ticketManagementModel.TicketList.Where(tl => tl.TicketOpenDate != null && Convert.ToDateTime(tl.TicketOpenDate).Date >= Convert.ToDateTime(DateTime.Now.AddDays(-lastDaysData))).ToList();


            if (ticketManagementModel.TicketList != null && ticketManagementModel.TicketList.Count > 0)
            {
                foreach (var item in ticketManagementModel.TicketList)
                {
                    var cat = categoryProvider.GetCategoryById(Convert.ToInt32(item.Category));
                    if (cat != null)
                        item.Category = cat.CategoryName;
                    var subcat = categoryProvider.GetSubCategoryById(Convert.ToInt32(item.SubCategory));
                    if (subcat != null)
                        item.SubCategory = subcat.SubCategoryName;
                    var subsubCategory = categoryProvider.GetSubSubCategoryById(Convert.ToInt32(item.SubSubCategory));
                    if (subsubCategory != null)
                        item.SubSubCategory = subsubCategory.SubSubCategoryName;

                    if (item.CollectionPointNumber != null)
                        item.CollectionPointNumber = "*" + item.CollectionPointNumber;

                    if (item.TicketOpenDate != null)
                    {
                        if (item.TicketCloseDate != null)
                            item.Duration = Convert.ToInt32((Convert.ToDateTime(item.TicketCloseDate) - Convert.ToDateTime(item.TicketOpenDate)).TotalMinutes);
                        else
                            item.Duration = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(item.TicketOpenDate)).TotalMinutes);
                    }

                }
            }

            ViewBag.DateFormat = Convert.ToString(ConfigurationManager.AppSettings["DateFormat"]);

            if (User.IsInRole("Admin") || User.IsInRole("Supervisor"))
                ViewBag.IsAccess = true;
            else
                ViewBag.IsAccess = false;

            return View(ticketManagementModel);
        }

        [HttpPost]
        public ActionResult TicketList(TicketManagementModel ticketManagementModel)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            //TicketManagementModel ticketManagementModel = new TicketManagementModel();
            CategoryProvider categoryProvider = new CategoryProvider();
            var ticketList = categoryProvider.GetAllTickets();

            if (ticketManagementModel.TicketOpenDate != null && ticketManagementModel.TicketCloseDate != null)
                ticketList = ticketList.Where(tl => Convert.ToDateTime(tl.TicketOpenDate).Date >= Convert.ToDateTime(ticketManagementModel.TicketOpenDate).Date && Convert.ToDateTime(tl.TicketOpenDate).Date <= Convert.ToDateTime(ticketManagementModel.TicketCloseDate).Date).ToList();
            else
            {
                if (ticketManagementModel.TicketOpenDate != null)
                    ticketList = ticketList.Where(tl => tl.TicketOpenDate != null && Convert.ToDateTime(tl.TicketOpenDate).Date == Convert.ToDateTime(ticketManagementModel.TicketOpenDate).Date).ToList();
                if (ticketManagementModel.TicketCloseDate != null)
                    ticketList = ticketList.Where(tl => tl.TicketCloseDate != null && Convert.ToDateTime(tl.TicketCloseDate).Date == Convert.ToDateTime(ticketManagementModel.TicketCloseDate).Date).ToList();
            }
            if (!string.IsNullOrEmpty(ticketManagementModel.CallingNumber))
                ticketList = ticketList.Where(tl => tl.CallingNumber == ticketManagementModel.CallingNumber).ToList();
            if (!string.IsNullOrEmpty(ticketManagementModel.Status) && ticketManagementModel.Status.ToLower() != "select status")
                ticketList = ticketList.Where(tl => tl.Status == ticketManagementModel.Status).ToList();

           

            ticketManagementModel.TicketList = ticketList;

            if (ticketManagementModel.TicketList != null && ticketManagementModel.TicketList.Count > 0)
            {
                foreach (var item in ticketManagementModel.TicketList)
                {
                    var cat = categoryProvider.GetCategoryById(Convert.ToInt32(item.Category));
                    if (cat != null)
                        item.Category = cat.CategoryName;
                    var subcat = categoryProvider.GetSubCategoryById(Convert.ToInt32(item.SubCategory));
                    if (subcat != null)
                        item.SubCategory = subcat.SubCategoryName;
                    var subsubCategory = categoryProvider.GetSubSubCategoryById(Convert.ToInt32(item.SubSubCategory));
                    if (subsubCategory != null)
                        item.SubSubCategory = subsubCategory.SubSubCategoryName;

                    if (item.CollectionPointNumber != null)
                        item.CollectionPointNumber = "*" + item.CollectionPointNumber;

                    if (item.TicketOpenDate != null)
                    {
                        if (item.TicketCloseDate != null)
                            item.Duration = Convert.ToInt32((Convert.ToDateTime(item.TicketCloseDate) - Convert.ToDateTime(item.TicketOpenDate)).TotalMinutes);
                        else
                            item.Duration = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(item.TicketOpenDate)).TotalMinutes);
                    }
                }
            }

            ViewBag.DateFormat = Convert.ToString(ConfigurationManager.AppSettings["DateFormat"]);
            //if (((CustomPrincipal)User).UserRoleId == 1 || ((CustomPrincipal)User).UserRoleId==2)
            if (User.IsInRole("Admin") || User.IsInRole("Supervisor"))
                ViewBag.IsAccess = true;
            else
                ViewBag.IsAccess = false;
            return View(ticketManagementModel);
        }
        public ActionResult TicketManagement()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            TicketManagementModel ticketManagementModel = new TicketManagementModel();
            CategoryProvider categoryProvider = new CategoryProvider();
            ticketManagementModel.CategoryList = categoryProvider.GetAllCategory();
            ticketManagementModel.SubCategoryList = ticketManagementModel.CategoryList.Count > 0 ? categoryProvider.GetSubCategoryByCategoryId(ticketManagementModel.CategoryList[0].CategoryId) : new List<SubCategoryMaster>();
            ticketManagementModel.SubSubCategoryList = ticketManagementModel.SubCategoryList.Count > 0 ? categoryProvider.GetSubSubCategoryBySubCategoryId(ticketManagementModel.SubCategoryList[0].SubCategoryId) : new List<SubSubCategoryMaster>();

            return View(ticketManagementModel);
        }
        [HttpPost]
        public ActionResult TicketManagement(TicketManagementModel ticketManagementModel)
        {
            bool statusTicket = false;
            string messageTicket = string.Empty;

            //if (ModelState.IsValid)
            //{

           
            if (!string.IsNullOrEmpty(ticketManagementModel.IL_Remark))
                ticketManagementModel.Remark = ticketManagementModel.IL_Remark;

            if (!string.IsNullOrEmpty(ticketManagementModel.ALL_IL_Remark))
                ticketManagementModel.Remark = ticketManagementModel.ALL_IL_Remark;

            if (!string.IsNullOrEmpty(ticketManagementModel.GL_Remark))
                ticketManagementModel.Remark = ticketManagementModel.GL_Remark;

            switch (ticketManagementModel.TypeOfCall)
            {
                case "GLClients":
                    ticketManagementModel.ClientId = ticketManagementModel.GLClientId;
                    ticketManagementModel.Name = ticketManagementModel.GLName;
                    ticketManagementModel.CallingNumber = ticketManagementModel.GLCallingNumber;
                    ticketManagementModel.BranchName = ticketManagementModel.GLBranchName;
                    ticketManagementModel.CollectionDate = ticketManagementModel.GLCollectionDate;
                    ticketManagementModel.CollectionPointNumber = ticketManagementModel.GLCollectionPointNumber;
                    ticketManagementModel.RepaymentAmount = ticketManagementModel.GLRepaymentAmount;
                    ticketManagementModel.WithdrawAmount = ticketManagementModel.GLWithdrawAmount;
                    ticketManagementModel.TotalDueAmount = ticketManagementModel.GLTotalDueAmount;
                    ticketManagementModel.DepositeSavingAmount = ticketManagementModel.GLDepositeSavingAmount;
                    ticketManagementModel.SchPaid = ticketManagementModel.GLSchPaid;
                    break;
                case "AllILClients":
                    ticketManagementModel.ClientId = ticketManagementModel.All_ILClientId;
                    ticketManagementModel.Name = ticketManagementModel.All_ILName;
                    ticketManagementModel.CallingNumber = ticketManagementModel.All_ILCallingNumber;
                    ticketManagementModel.BranchName = ticketManagementModel.All_ILBranchName;
                    ticketManagementModel.CollectionDate = ticketManagementModel.All_ILCollectionDate;
                    ticketManagementModel.CollectionPointNumber = ticketManagementModel.All_ILCollectionPointNumber;
                    ticketManagementModel.RepaymentAmount = ticketManagementModel.All_ILRepaymentAmount;
                    ticketManagementModel.WithdrawAmount = ticketManagementModel.All_ILWithdrawAmount;
                    ticketManagementModel.TotalDueAmount = ticketManagementModel.All_ILTotalDueAmount;
                    ticketManagementModel.DepositeSavingAmount = ticketManagementModel.All_ILDepositeSavingAmount;
                    ticketManagementModel.SchPaid = ticketManagementModel.All_ILSchPaid;
                    break;
                case "ILClients":
                    ticketManagementModel.ClientId = ticketManagementModel.ILClientId;
                    ticketManagementModel.Name = ticketManagementModel.ILName;
                    ticketManagementModel.CallingNumber = ticketManagementModel.ILCallingNumber;
                    ticketManagementModel.BranchName = ticketManagementModel.ILBranchName;
                    ticketManagementModel.CollectionDate = ticketManagementModel.ILCollectionDate;
                    ticketManagementModel.CollectionPointNumber = ticketManagementModel.ILCollectionPointNumber;
                    ticketManagementModel.RepaymentAmount = ticketManagementModel.ILRepaymentAmount;
                    ticketManagementModel.WithdrawAmount = ticketManagementModel.ILWithdrawAmount;
                    ticketManagementModel.TotalDueAmount = ticketManagementModel.ILTotalDueAmount;
                    ticketManagementModel.DepositeSavingAmount = ticketManagementModel.ILDepositeSavingAmount;
                    ticketManagementModel.SchPaid = ticketManagementModel.ILSchPaid;
                    break;
                case "VSAClients":
                    ticketManagementModel.ClientId = ticketManagementModel.VSAClientId;
                    ticketManagementModel.Name = ticketManagementModel.VSAName;
                    ticketManagementModel.CallingNumber = ticketManagementModel.VSACallingNumber;
                    ticketManagementModel.BranchName = ticketManagementModel.VSABranchName;
                    ticketManagementModel.CollectionDate = ticketManagementModel.VSACollectionDate;
                    ticketManagementModel.CollectionPointNumber = ticketManagementModel.VSACollectionPointNumber;
                    ticketManagementModel.RepaymentAmount = ticketManagementModel.VSARepaymentAmount;
                    ticketManagementModel.WithdrawAmount = ticketManagementModel.VSAWithdrawAmount;
                    ticketManagementModel.TotalDueAmount = ticketManagementModel.VSATotalDueAmount;
                    ticketManagementModel.DepositeSavingAmount = ticketManagementModel.VSADepositeSavingAmount;
                    ticketManagementModel.SchPaid = ticketManagementModel.VSASchPaid;
                    break;
                default:
                    break;
            }


            using (AuthenticationDB dbContext = new AuthenticationDB())
            {
                var ticketManagement = new TicketManagement()
                {
                    TypeOfCaller = ticketManagementModel.TypeOfCaller,
                    TypeOfCall = ticketManagementModel.TypeOfCall,
                    CollectionDate = ticketManagementModel.CollectionDate,
                    ClientId = ticketManagementModel.ClientId,
                    Name = ticketManagementModel.Name,
                    CallingNumber = ticketManagementModel.CallingNumber,
                    BranchName = ticketManagementModel.BranchName,
                    CollectionPointNumber = ticketManagementModel.CollectionPointNumber,
                    RepaymentAmount = ticketManagementModel.RepaymentAmount,
                    DepositeSavingAmount = ticketManagementModel.DepositeSavingAmount,
                    WithdrawAmount = ticketManagementModel.WithdrawAmount,
                    TotalDueAmount = ticketManagementModel.TotalDueAmount,
                    RepaymentVoucher = ticketManagementModel.RepaymentVoucher,
                    MessageFromDawn = ticketManagementModel.MessageFromDawn,
                    CashIs = ticketManagementModel.CashIs,
                    AmountCorrect = ticketManagementModel.AmountCorrect,
                    Remark = ticketManagementModel.Remark,
                    SchPaid = ticketManagementModel.SchPaid,

                    // CustomerSegment = ticketManagementModel.CustomerSegment,

                    //  Category = ticketManagementModel.Category,
                    //  SubCategory = ticketManagementModel.SubCategory,
                    //  SubSubCategory = ticketManagementModel.SubSubCategory,

                    TicketOpenDate = DateTime.Now,
                    TicketOpenAgentName = User.Identity.Name,
                    Status = "Open"

                };
                dbContext.TicketManagements.Add(ticketManagement);
                dbContext.SaveChanges();
            }

            //VerificationEmail(registrationView.Email, registrationView.ActivationCode.ToString());
            messageTicket = "Ticket has been created successfully.";
            statusTicket = true;
            return RedirectToAction("TicketList", "Home");
            //}
            //else
            //{
            //    messageTicket = "Something Wrong!";
            //    CategoryProvider categoryProvider = new CategoryProvider();
            //    ticketManagementModel.CategoryList = categoryProvider.GetAllCategory();
            //    ticketManagementModel.SubCategoryList = categoryProvider.GetSubCategoryByCategoryId(Convert.ToInt32(ticketManagementModel.Category));
            //    ticketManagementModel.SubSubCategoryList = categoryProvider.GetSubSubCategoryBySubCategoryId(Convert.ToInt32(ticketManagementModel.SubSubCategory));
            //}
            //ViewBag.Message = messageTicket;
            //ViewBag.Status = statusTicket;
            //return View(ticketManagementModel);
        }

        public ActionResult TicketManagementEdit(int id)
        {
            TicketManagementModel ticketManagementModel = new TicketManagementModel();
            CategoryProvider categoryProvider = new CategoryProvider();
            TicketManagement ticket = new TicketManagement();
            ticket = categoryProvider.GetTicketsById(id);

            ticketManagementModel.TicketId = ticket.TicketId;

            ticketManagementModel.Name = ticket.Name;

            ticketManagementModel.CallingNumber = ticket.CallingNumber;
            ticketManagementModel.TypeOfCaller = ticket.TypeOfCaller;
            ticketManagementModel.CustomerSegment = ticket.CustomerSegment;

            

            ticketManagementModel.TypeOfCall = ticket.TypeOfCall;
            ticketManagementModel.Category = ticket.Category;
            ticketManagementModel.SubCategory = ticket.SubCategory;
            ticketManagementModel.SubSubCategory = ticket.SubSubCategory;
            ticketManagementModel.Remark = ticket.Remark;

            if (ticket.TypeOfCall == "GLClients")
                ticketManagementModel.GL_Remark = ticket.Remark;

            if (ticket.TypeOfCall == "AllILClients")
                ticketManagementModel.ALL_IL_Remark = ticket.Remark;

            if (ticket.TypeOfCall == "ILClients")
                ticketManagementModel.IL_Remark = ticket.Remark;

            ticketManagementModel.Status = ticket.Status;
            ticketManagementModel.CategoryList = categoryProvider.GetAllCategory();
            ticketManagementModel.SubCategoryList = ticketManagementModel.CategoryList.Count > 0 ? categoryProvider.GetSubCategoryByCategoryId(Convert.ToInt32(ticketManagementModel.Category)) : new List<SubCategoryMaster>();
            ticketManagementModel.SubSubCategoryList = ticketManagementModel.SubCategoryList.Count > 0 ? categoryProvider.GetSubSubCategoryBySubCategoryId(Convert.ToInt32(ticketManagementModel.SubCategory)) : new List<SubSubCategoryMaster>();

            return View(ticketManagementModel);
        }

        [HttpPost]
        public ActionResult TicketManagementEdit(TicketManagementModel ticketManagementModel)
        {

            bool statusTicket = false;
            string messageTicket = string.Empty;
            if (ModelState.IsValid)
            {
                using (AuthenticationDB dbContext = new AuthenticationDB())
                {
                    var result = dbContext.TicketManagements.SingleOrDefault(m => m.TicketId == ticketManagementModel.TicketId);
                    if (result != null)
                    {
                        result.Name = ticketManagementModel.Name;
                        result.CallingNumber = ticketManagementModel.CallingNumber;
                        result.TypeOfCaller = ticketManagementModel.TypeOfCaller;
                        result.CustomerSegment = ticketManagementModel.CustomerSegment;
                        result.TypeOfCall = ticketManagementModel.TypeOfCall;
                        result.Category = ticketManagementModel.Category;
                        result.SubCategory = ticketManagementModel.SubCategory;
                        result.SubSubCategory = ticketManagementModel.SubSubCategory;
                        result.Remark = ticketManagementModel.Remark;
                        result.Status = ticketManagementModel.Status;
                        result.TicketCloseDate = ticketManagementModel.Status.ToLower() == "closed" ? DateTime.Now : ticketManagementModel.TicketCloseDate;
                        result.TicketCloseAgentName = User.Identity.Name;
                        dbContext.SaveChanges();
                        messageTicket = "Category has been updated successfully.";
                        statusTicket = true;

                    }
                }
                return RedirectToAction("TicketList", "Home");
            }
            else
            {
                messageTicket = "Something Wrong!";
                CategoryProvider categoryProvider = new CategoryProvider();
                ticketManagementModel.CategoryList = categoryProvider.GetAllCategory();
                ticketManagementModel.SubCategoryList = ticketManagementModel.CategoryList.Count > 0 ? categoryProvider.GetSubCategoryByCategoryId(Convert.ToInt32(ticketManagementModel.Category)) : new List<SubCategoryMaster>();
                ticketManagementModel.SubSubCategoryList = ticketManagementModel.SubCategoryList.Count > 0 ? categoryProvider.GetSubSubCategoryBySubCategoryId(Convert.ToInt32(ticketManagementModel.SubCategory)) : new List<SubSubCategoryMaster>();

            }

            return View(ticketManagementModel);
        }


        public ActionResult TicketDownloadExcel(string opendate, string closedate, string callingno, string status) //string opendate, string closedate)
        {
            TicketManagementModel ticketManagementModel = new TicketManagementModel();

            if (!string.IsNullOrEmpty(opendate))
                ticketManagementModel.TicketOpenDate = Convert.ToDateTime(opendate);

            if (!string.IsNullOrEmpty(closedate))
                ticketManagementModel.TicketCloseDate = Convert.ToDateTime(closedate);

            if (!string.IsNullOrEmpty(callingno))
                ticketManagementModel.CallingNumber = callingno;

            if (!string.IsNullOrEmpty(status))
                ticketManagementModel.Status = status;

            CategoryProvider categoryProvider = new CategoryProvider();
            var ticketList = categoryProvider.GetAllTickets();

            //foreach (var item in ticketList)
            //{
            //    var cat = categoryProvider.GetCategoryById(Convert.ToInt32(item.Category));
            //    if (cat != null)
            //        item.Category = cat.CategoryName;
            //    var subcat = categoryProvider.GetSubCategoryById(Convert.ToInt32(item.SubCategory));
            //    if (subcat != null)
            //        item.SubCategory = subcat.SubCategoryName;
            //    var subsubCategory = categoryProvider.GetSubSubCategoryById(Convert.ToInt32(item.SubSubCategory));
            //    if (subsubCategory != null)
            //        item.SubSubCategory = subsubCategory.SubSubCategoryName;

            //    if (item.TicketOpenDate != null)
            //    {
            //        if (item.TicketCloseDate != null)
            //            item.Duration = Convert.ToInt32((Convert.ToDateTime(item.TicketCloseDate) - Convert.ToDateTime(item.TicketOpenDate)).TotalMinutes);
            //        else
            //            item.Duration = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(item.TicketOpenDate)).TotalMinutes);
            //    }

            //}

            if (ticketManagementModel.TicketOpenDate != null && ticketManagementModel.TicketCloseDate != null)
                ticketList = ticketList.Where(tl => Convert.ToDateTime(tl.TicketOpenDate).Date >= Convert.ToDateTime(ticketManagementModel.TicketOpenDate).Date && Convert.ToDateTime(tl.TicketCloseDate).Date <= Convert.ToDateTime(ticketManagementModel.TicketCloseDate).Date).ToList();
            else
            {
                if (ticketManagementModel.TicketOpenDate != null)
                    ticketList = ticketList.Where(tl => tl.TicketCloseDate != null && Convert.ToDateTime(tl.TicketOpenDate).Date == Convert.ToDateTime(ticketManagementModel.TicketOpenDate).Date).ToList();
                if (ticketManagementModel.TicketCloseDate != null)
                    ticketList = ticketList.Where(tl => tl.TicketCloseDate != null && Convert.ToDateTime(tl.TicketCloseDate).Date == Convert.ToDateTime(ticketManagementModel.TicketCloseDate).Date).ToList();
            }
            if (!string.IsNullOrEmpty(ticketManagementModel.CallingNumber))
                ticketList = ticketList.Where(tl => tl.CallingNumber == ticketManagementModel.CallingNumber).ToList();
            if (!string.IsNullOrEmpty(ticketManagementModel.Status) && ticketManagementModel.Status.ToLower() != "select status")
                ticketList = ticketList.Where(tl => tl.Status == ticketManagementModel.Status).ToList();

            List<TicketExcelExport> ticketExcelExports = new List<TicketExcelExport>();
            foreach (var item in ticketList)
            {
                var excelRecord = new TicketExcelExport();

                excelRecord.ClientId = item.ClientId;
                excelRecord.Name = item.Name;
                excelRecord.CallingNumber = item.CallingNumber;
                excelRecord.TypeOfCall = item.TypeOfCall;
                excelRecord.CollectionPointNumber = "'"+item.CollectionPointNumber;
                excelRecord.BranchName = item.BranchName;
                excelRecord.RepaymentAmount = item.RepaymentAmount;
                excelRecord.TotalDueAmount = item.TotalDueAmount;
                excelRecord.SchPaid = item.SchPaid;
                excelRecord.RepaymentVoucher = item.RepaymentVoucher;
                excelRecord.DepositeSavingAmount = item.DepositeSavingAmount;
                excelRecord.WithdrawAmount = item.WithdrawAmount;
                excelRecord.MessageFromDawn = item.MessageFromDawn;
                excelRecord.CashIs = item.CashIs;
                excelRecord.AmountCorrect = item.AmountCorrect;
                excelRecord.CollectionDate = item.CollectionDate;
                excelRecord.Remark = item.Remark;
                excelRecord.TicketOpenDate = item.TicketOpenDate;

                ticketExcelExports.Add(excelRecord);
            }

            var gv = new GridView();
            gv.DataSource = ticketExcelExports.OrderByDescending(m => m.TicketOpenDate);
            gv.DataBind();
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            byte[] bindata = System.Text.Encoding.ASCII.GetBytes(objStringWriter.ToString());
            return File(bindata, "application/ms-excel", "OutBoundExcel.xls");
        }

        public ActionResult SRList()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            SRManagementModel sRManagementModel = new SRManagementModel();
            CategoryProvider categoryProvider = new CategoryProvider();
            sRManagementModel.SRList = categoryProvider.GetAllSRs();

           
            foreach (var item in sRManagementModel.SRList)
            {
                var cat = categoryProvider.GetCategoryById(Convert.ToInt32(item.Category));
                if (cat != null)
                    item.Category = cat.CategoryName;
                var subcat = categoryProvider.GetSubCategoryById(Convert.ToInt32(item.SubCategory));
                if (subcat != null)
                    item.SubCategory = subcat.SubCategoryName;
                var subsubCategory = categoryProvider.GetSubSubCategoryById(Convert.ToInt32(item.SubSubCategory));
                if (subsubCategory != null)
                    item.SubSubCategory = subsubCategory.SubSubCategoryName;

                if (item.TicketOpenDate != null)
                {
                    if (item.TicketCloseDate != null)
                    {
                        if (Convert.ToInt32((Convert.ToDateTime(item.TicketCloseDate) - Convert.ToDateTime(item.TicketOpenDate)).TotalHours) > Convert.ToInt32(ConfigurationManager.AppSettings["RubySegmentSLAInHour"]) && item.CustomerSegment != null && item.CustomerSegment.ToLower() == "ruby")
                        {
                            item.SlaBridge = "YES";
                        }
                        else if (Convert.ToInt32((Convert.ToDateTime(item.TicketCloseDate) - Convert.ToDateTime(item.TicketOpenDate)).TotalHours) > Convert.ToInt32(ConfigurationManager.AppSettings["NonRubySegmentSLAInHour"]) && item.CustomerSegment != null)
                        {
                            item.SlaBridge = "YES";
                        }
                        else
                            item.SlaBridge = "NO";
                    }
                    else
                    {
                        if (Convert.ToInt32((DateTime.Now - Convert.ToDateTime(item.TicketOpenDate)).TotalHours) > Convert.ToInt32(ConfigurationManager.AppSettings["RubySegmentSLAInHour"]) && item.CustomerSegment != null && item.CustomerSegment.ToLower() == "ruby")
                        {
                            item.SlaBridge = "YES";
                        }
                        else if (Convert.ToInt32((DateTime.Now - Convert.ToDateTime(item.TicketOpenDate)).TotalHours) > Convert.ToInt32(ConfigurationManager.AppSettings["NonRubySegmentSLAInHour"]) && item.CustomerSegment != null)
                        {
                            item.SlaBridge = "YES";
                        }
                        else
                            item.SlaBridge = "NO";
                    }
                }
            }
            ViewBag.DateFormat = Convert.ToString(ConfigurationManager.AppSettings["DateFormat"]);
            if (User.IsInRole("Admin") || User.IsInRole("Supervisor"))
                ViewBag.IsAccess = true;
            else
                ViewBag.IsAccess = false;
            return View(sRManagementModel);
        }
        [HttpPost]
        public ActionResult SRList(SRManagementModel sRManagementModel)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            //SRManagementModel sRManagementModel = new SRManagementModel();
            CategoryProvider categoryProvider = new CategoryProvider();
            var SRList = categoryProvider.GetAllSRs();

            if (sRManagementModel.TicketOpenDate != null && sRManagementModel.TicketCloseDate != null)
                SRList = SRList.Where(tl => Convert.ToDateTime(tl.TicketOpenDate).Date >= Convert.ToDateTime(sRManagementModel.TicketOpenDate).Date && Convert.ToDateTime(tl.TicketCloseDate).Date <= Convert.ToDateTime(sRManagementModel.TicketCloseDate).Date).ToList();
            else
            {
                if (sRManagementModel.TicketOpenDate != null)
                    SRList = SRList.Where(tl => tl.TicketOpenDate != null && Convert.ToDateTime(tl.TicketOpenDate).Date == Convert.ToDateTime(sRManagementModel.TicketOpenDate).Date).ToList();
                if (sRManagementModel.TicketCloseDate != null)
                    SRList = SRList.Where(tl => tl.TicketCloseDate != null && Convert.ToDateTime(tl.TicketCloseDate).Date == Convert.ToDateTime(sRManagementModel.TicketCloseDate).Date).ToList();
            }
            if (!string.IsNullOrEmpty(sRManagementModel.PhoneNo))
                SRList = SRList.Where(tl => tl.PhoneNo == sRManagementModel.PhoneNo).ToList();
            if (!string.IsNullOrEmpty(sRManagementModel.Status) && sRManagementModel.Status.ToLower() != "select status")
                SRList = SRList.Where(tl => tl.Status == sRManagementModel.Status).ToList();

            sRManagementModel.SRList = SRList;

            foreach (var item in sRManagementModel.SRList)
            {
                var cat = categoryProvider.GetCategoryById(Convert.ToInt32(item.Category));
                if (cat != null)
                    item.Category = cat.CategoryName;
                var subcat = categoryProvider.GetSubCategoryById(Convert.ToInt32(item.SubCategory));
                if (subcat != null)
                    item.SubCategory = subcat.SubCategoryName;
                var subsubCategory = categoryProvider.GetSubSubCategoryById(Convert.ToInt32(item.SubSubCategory));
                if (subsubCategory != null)
                    item.SubSubCategory = subsubCategory.SubSubCategoryName;

                if (item.TicketOpenDate != null)
                {
                    if (item.TicketCloseDate != null)
                    {
                        if (Convert.ToInt32((Convert.ToDateTime(item.TicketCloseDate) - Convert.ToDateTime(item.TicketOpenDate)).TotalHours) > Convert.ToInt32(ConfigurationManager.AppSettings["RubySegmentSLAInHour"]) && item.CustomerSegment != null && item.CustomerSegment.ToLower() == "ruby")
                        {
                            item.SlaBridge = "YES";
                        }
                        else if (Convert.ToInt32((Convert.ToDateTime(item.TicketCloseDate) - Convert.ToDateTime(item.TicketOpenDate)).TotalHours) > Convert.ToInt32(ConfigurationManager.AppSettings["NonRubySegmentSLAInHour"]) && item.CustomerSegment != null)
                        {
                            item.SlaBridge = "YES";
                        }
                        else
                            item.SlaBridge = "NO";
                    }
                    else
                    {
                        if (Convert.ToInt32((DateTime.Now - Convert.ToDateTime(item.TicketOpenDate)).TotalHours) > Convert.ToInt32(ConfigurationManager.AppSettings["RubySegmentSLAInHour"]) && item.CustomerSegment != null && item.CustomerSegment.ToLower() == "ruby")
                        {
                            item.SlaBridge = "YES";
                        }
                        else if (Convert.ToInt32((DateTime.Now - Convert.ToDateTime(item.TicketOpenDate)).TotalHours) > Convert.ToInt32(ConfigurationManager.AppSettings["NonRubySegmentSLAInHour"]) && item.CustomerSegment != null)
                        {
                            item.SlaBridge = "YES";
                        }
                        else
                            item.SlaBridge = "NO";
                    }
                }
            }

            ViewBag.DateFormat = Convert.ToString(ConfigurationManager.AppSettings["DateFormat"]);
            if (User.IsInRole("Admin") || User.IsInRole("Supervisor"))
                ViewBag.IsAccess = true;
            else
                ViewBag.IsAccess = false;
            return View(sRManagementModel);
        }

        public ActionResult SRManagement()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            SRManagementModel sRManagementModel = new SRManagementModel();
            CategoryProvider categoryProvider = new CategoryProvider();
            sRManagementModel.CategoryList = categoryProvider.GetAllCategory();
            sRManagementModel.SubCategoryList = sRManagementModel.CategoryList.Count > 0 ? categoryProvider.GetSubCategoryByCategoryId(sRManagementModel.CategoryList[0].CategoryId) : new List<SubCategoryMaster>();
            sRManagementModel.SubSubCategoryList = sRManagementModel.SubCategoryList.Count > 0 ? categoryProvider.GetSubSubCategoryBySubCategoryId(sRManagementModel.SubCategoryList[0].SubCategoryId) : new List<SubSubCategoryMaster>();
            return View(sRManagementModel);
        }

        [HttpPost]
        public ActionResult SRManagement(SRManagementModel sRManagementModel)
        {
            bool statusTicket = false;
            string messageTicket = string.Empty;

            try
            {
                using (AuthenticationDB dbContext = new AuthenticationDB())
                {
                    var sRManagement = new SRManagement()
                    {
                        PhoneNo = sRManagementModel.PhoneNo,
                        TypeOfCall = sRManagementModel.TypeOfCall,

                        CustomerName = sRManagementModel.CustomerName,
                        CustomerSegment = sRManagementModel.CustomerSegment,
                        NatureofComplaints = sRManagementModel.TypeOfCall == "Complaint" ? sRManagementModel.NatureofComplaints : null,
                        Address = sRManagementModel.Address,
                        BranchName = sRManagementModel.TypeOfCall == "Complaint" ? sRManagementModel.BranchName : null,
                        BranchOther = sRManagementModel.BranchOther,
                        ResoluctionFeedback = sRManagementModel.ResoluctionFeedback,
                        TypeOfCallerOther = sRManagementModel.TypeOfCallerOther,
                        TypeOfCaller = sRManagementModel.TypeOfCall == "Complaint" ? null : sRManagementModel.TypeOfCaller,
                        //TypeOfCaller
                        TypeOfProduct = sRManagementModel.TypeOfCall == "Complaint" ? null : sRManagementModel.TypeOfCaller == "Products" ? sRManagementModel.TypeOfProduct : null,
                        TypeOfProductOther = sRManagementModel.TypeOfProductOther,
                        Gender = sRManagementModel.TypeOfCall == "Complaint" ? null : sRManagementModel.TypeOfCaller == "Products" ? sRManagementModel.Gender : null,
                        RegionComplaint = sRManagementModel.TypeOfCall == "Complaint" ? sRManagementModel.RegionComplaint : null,
                        Town = sRManagementModel.TypeOfCall == "Complaint" ? null : sRManagementModel.TypeOfCaller == "Products" ? sRManagementModel.Town : null,
                        TypeOfBusiness = sRManagementModel.TypeOfCall == "Complaint" ? null : sRManagementModel.TypeOfCaller == "Products" ? sRManagementModel.TypeOfBusiness : null,
                        TypeOfBusinessOther = sRManagementModel.TypeOfBusinessOther,
                        Email = sRManagementModel.Email,
                        AgentName = sRManagementModel.AgentName,
                        RequestForResoluction = sRManagementModel.RequestForResoluction,
                        Remark = sRManagementModel.Remark,
                        TicketOpenDate = DateTime.Now,
                        TicketOpenAgentName = User.Identity.Name,
                        Status = "Open",
                        BranchNameClient = sRManagementModel.TypeOfCall == "Complaint" ? null : sRManagementModel.TypeOfCaller == "Products" ? null : sRManagementModel.BranchNameClient,
                        RegionProduct = sRManagementModel.TypeOfCall == "Complaint" ? null : sRManagementModel.TypeOfCaller == "Products" ? sRManagementModel.RegionProduct : null
                    };
                    dbContext.SRManagements.Add(sRManagement);
                    dbContext.SaveChanges();
                }

                return RedirectToAction("SRList", "Home");
            }
            catch (Exception ex)
            {
                return View(sRManagementModel);
            }



        }


        public ActionResult SRManagementEdit(int Id)
        {

            SRManagementModel sRManagementModel = new SRManagementModel();
            CategoryProvider categoryProvider = new CategoryProvider();
            SRManagement sr = new SRManagement();
            sr = categoryProvider.GetSRById(Id);
            sRManagementModel.SRId = sr.SRId;
            sRManagementModel.PhoneNo = sr.PhoneNo;
            sRManagementModel.TypeOfCall = sr.TypeOfCall;

            sRManagementModel.CustomerName = sr.CustomerName;
            sRManagementModel.CustomerSegment = sr.CustomerSegment;
            sRManagementModel.NatureofComplaints = sr.NatureofComplaints;
            sRManagementModel.Address = sr.Address;
            sRManagementModel.BranchName = sr.BranchName;
            sRManagementModel.BranchOther = sr.BranchOther;
            sRManagementModel.ResoluctionFeedback = sr.ResoluctionFeedback;
            sRManagementModel.TypeOfCallerOther = sr.TypeOfCallerOther;
            sRManagementModel.TypeOfCaller = sr.TypeOfCall;
            //TypeOfCaller
            sRManagementModel.TypeOfProduct = sr.TypeOfProduct;
            sRManagementModel.TypeOfProductOther = sr.TypeOfProductOther;
            sRManagementModel.Gender = sr.Gender;
            sRManagementModel.RegionComplaint = sr.RegionComplaint;
            sRManagementModel.Town = sr.Town;
            sRManagementModel.TypeOfBusiness = sr.TypeOfBusiness;
            sRManagementModel.TypeOfBusinessOther = sr.TypeOfBusinessOther;
            sRManagementModel.Email = sr.Email;
            sRManagementModel.AgentName = sr.AgentName;
            sRManagementModel.RequestForResoluction = sr.RequestForResoluction;
            return View(sRManagementModel);
        }
        [HttpPost]
        public ActionResult SRManagementEdit(SRManagementModel sRManagementModel)
        {
            bool statusTicket = false;
            string messageTicket = string.Empty;
            try
            {
                using (AuthenticationDB dbContext = new AuthenticationDB())
                {
                    var result = dbContext.SRManagements.SingleOrDefault(m => m.SRId == sRManagementModel.SRId);
                    if (result != null)
                    {

                        result.PhoneNo = sRManagementModel.PhoneNo;
                        result.TypeOfCall = sRManagementModel.TypeOfCall;

                        result.CustomerName = sRManagementModel.CustomerName;
                        result.CustomerSegment = sRManagementModel.CustomerSegment;
                        result.NatureofComplaints = sRManagementModel.NatureofComplaints;
                        result.Address = sRManagementModel.Address;
                        result.BranchName = sRManagementModel.BranchName;
                        result.BranchOther = sRManagementModel.BranchOther;
                        result.ResoluctionFeedback = sRManagementModel.ResoluctionFeedback;
                        result.TypeOfCallerOther = sRManagementModel.TypeOfCallerOther;
                        result.TypeOfCaller = sRManagementModel.TypeOfCall == "Complaint" ? "" : sRManagementModel.TypeOfCaller;
                        //TypeOfCaller
                        result.TypeOfProduct = sRManagementModel.TypeOfCall == "Complaint" ? "" : sRManagementModel.TypeOfProduct;
                        result.TypeOfProductOther = sRManagementModel.TypeOfProductOther;
                        result.Gender = sRManagementModel.TypeOfCall == "Complaint" ? "" : sRManagementModel.Gender;
                        result.RegionComplaint = sRManagementModel.TypeOfCall == "Complaint" ? "" : sRManagementModel.RegionComplaint;
                        result.Town = sRManagementModel.TypeOfCall == "Complaint" ? "" : sRManagementModel.Town;
                        result.TypeOfBusiness = sRManagementModel.TypeOfCall == "Complaint" ? "" : sRManagementModel.TypeOfBusiness;
                        result.TypeOfBusinessOther = sRManagementModel.TypeOfBusinessOther;
                        result.Email = sRManagementModel.Email;
                        result.AgentName = sRManagementModel.AgentName;
                        result.RequestForResoluction = sRManagementModel.RequestForResoluction;

                        dbContext.SaveChanges();
                        messageTicket = "SR has been updated successfully.";
                        statusTicket = true;

                    }
                }
                return RedirectToAction("SRList", "Home");
            }
            catch (Exception ex)
            {
                return View(sRManagementModel);
            }


        }


        public ActionResult SRDownloadExcel(string opendate, string closedate, string callingno, string status)
        {

            SRManagementModel sRManagementModel = new SRManagementModel();

            if (!string.IsNullOrEmpty(opendate))
                sRManagementModel.TicketOpenDate = Convert.ToDateTime(opendate);

            if (!string.IsNullOrEmpty(closedate))
                sRManagementModel.TicketCloseDate = Convert.ToDateTime(closedate);

            if (!string.IsNullOrEmpty(callingno))
                sRManagementModel.PhoneNo = callingno;
            if (!string.IsNullOrEmpty(status))
                sRManagementModel.Status = status;

            CategoryProvider categoryProvider = new CategoryProvider();
            var SRList = categoryProvider.GetAllSRs();

            foreach (var item in SRList)
            {
                var cat = categoryProvider.GetCategoryById(Convert.ToInt32(item.Category));
                if (cat != null)
                    item.Category = cat.CategoryName;
                var subcat = categoryProvider.GetSubCategoryById(Convert.ToInt32(item.SubCategory));
                if (subcat != null)
                    item.SubCategory = subcat.SubCategoryName;
                var subsubCategory = categoryProvider.GetSubSubCategoryById(Convert.ToInt32(item.SubSubCategory));
                if (subsubCategory != null)
                    item.SubSubCategory = subsubCategory.SubSubCategoryName;

                if (item.TicketOpenDate != null)
                {
                    if (item.TicketCloseDate != null)
                    {
                        if (Convert.ToInt32((Convert.ToDateTime(item.TicketCloseDate) - Convert.ToDateTime(item.TicketOpenDate)).TotalHours) > Convert.ToInt32(ConfigurationManager.AppSettings["RubySegmentSLAInHour"]) && item.CustomerSegment != null && item.CustomerSegment.ToLower() == "ruby")
                        {
                            item.SlaBridge = "YES";
                        }
                        else if (Convert.ToInt32((Convert.ToDateTime(item.TicketCloseDate) - Convert.ToDateTime(item.TicketOpenDate)).TotalHours) > Convert.ToInt32(ConfigurationManager.AppSettings["NonRubySegmentSLAInHour"]) && item.CustomerSegment != null)
                        {
                            item.SlaBridge = "YES";
                        }
                        else
                            item.SlaBridge = "NO";
                    }
                    else
                    {
                        if (Convert.ToInt32((DateTime.Now - Convert.ToDateTime(item.TicketOpenDate)).TotalMinutes) > Convert.ToInt32(ConfigurationManager.AppSettings["RubySegmentSLAInHour"]) && item.CustomerSegment != null && item.CustomerSegment.ToLower() == "ruby")
                        {
                            item.SlaBridge = "YES";
                        }
                        else if (Convert.ToInt32((DateTime.Now - Convert.ToDateTime(item.TicketOpenDate)).TotalMinutes) > Convert.ToInt32(ConfigurationManager.AppSettings["NonRubySegmentSLAInHour"]) && item.CustomerSegment != null)
                        {
                            item.SlaBridge = "YES";
                        }
                        else
                            item.SlaBridge = "NO";
                    }
                }
            }

            if (sRManagementModel.TicketOpenDate != null && sRManagementModel.TicketCloseDate != null)
                SRList = SRList.Where(tl => Convert.ToDateTime(tl.TicketOpenDate).Date >= Convert.ToDateTime(sRManagementModel.TicketOpenDate).Date && Convert.ToDateTime(tl.TicketCloseDate).Date <= Convert.ToDateTime(sRManagementModel.TicketCloseDate).Date).ToList();
            else
            {
                if (sRManagementModel.TicketOpenDate != null)
                    SRList = SRList.Where(tl => tl.TicketOpenDate != null && Convert.ToDateTime(tl.TicketOpenDate).Date == Convert.ToDateTime(sRManagementModel.TicketOpenDate).Date).ToList();
                if (sRManagementModel.TicketCloseDate != null)
                    SRList = SRList.Where(tl => tl.TicketCloseDate != null && Convert.ToDateTime(tl.TicketCloseDate).Date == Convert.ToDateTime(sRManagementModel.TicketCloseDate).Date).ToList();
            }
            if (!string.IsNullOrEmpty(sRManagementModel.PhoneNo))
                SRList = SRList.Where(tl => tl.PhoneNo == sRManagementModel.PhoneNo).ToList();
            if (!string.IsNullOrEmpty(sRManagementModel.Status) && sRManagementModel.Status.ToLower() != "select status")
                SRList = SRList.Where(tl => tl.Status == sRManagementModel.Status).ToList();

            var gv = new GridView();
            gv.DataSource = SRList;
            gv.DataBind();
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            byte[] bindata = System.Text.Encoding.ASCII.GetBytes(objStringWriter.ToString());
            return File(bindata, "application/ms-excel", "InBoundExcel.xls");
        }
        public ActionResult KnowledgeCenter()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            return View();
        }

        public string GetSubCategoryByCategory(string CategoryId)
        {

            CategoryProvider categoryProvider = new CategoryProvider();
            return (JsonConvert.SerializeObject(categoryProvider.GetSubCategoryByCategoryId(Convert.ToInt32(CategoryId)))).ToString();
        }
        public string GetSubSubCategoryBySubCategory(string SubCategoryId)
        {

            CategoryProvider categoryProvider = new CategoryProvider();
            if (!string.IsNullOrEmpty(SubCategoryId) && SubCategoryId != "null")
                return (JsonConvert.SerializeObject(categoryProvider.GetSubSubCategoryBySubCategoryId(Convert.ToInt32(SubCategoryId)))).ToString();
            else
                return "";
        }
        public string TicketClientSearch(string TypeOfCall, string SPParameterValue, string ClientId, string SearchBranch)
        {
            try
            {
                string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["ReportServer"].ConnectionString;
                string spName = string.Empty;
                if (TypeOfCall == "GLClients")
                    spName = "Kredits_GlClient";
                else if (TypeOfCall == "AllILClients")
                    spName = "Kredits_IlClientEarly";
                else if (TypeOfCall == "ILClients")
                    spName = "Kredits_IlClient";
                else if (TypeOfCall == "VSAClients")
                    spName = "Kredits_VsaClient";

                SqlConnection cnn = new SqlConnection(cnnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = spName;
                cmd.Parameters.AddWithValue("@SearchItem", ClientId);
                cmd.Parameters.AddWithValue("@SearchType", SPParameterValue);
                cmd.Parameters.AddWithValue("@BrchName", SearchBranch);
                //add any parameters the stored procedure might require
                cnn.Open();
                var adapter = new SqlDataAdapter(cmd);
                var dataset = new DataSet();
                adapter.Fill(dataset);

                cnn.Close();

                if (dataset != null)
                {
                    string Jsonobject = Newtonsoft.Json.JsonConvert.SerializeObject(dataset.Tables[0]);
                    return Jsonobject;
                }

                else
                    return "nodatafound";
            }
            catch (Exception ex)
            {
                    return ex.Message;
            }
            
        }
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }



        public ActionResult ResetPassword(int? id)
        {
            RegistrationViewModel registrationViewModel = new RegistrationViewModel();
            CategoryProvider categoryProvider = new CategoryProvider();
            CustomRoleProvider customRoleProvider = new CustomRoleProvider();
            User user = new User();

            if (id != null)
                user = categoryProvider.GetUserById(Convert.ToInt32(id));
            else
                user = categoryProvider.GetUserByUserName(User.Identity.Name);

            registrationViewModel.UserId = user.UserId;

            registrationViewModel.FirstName = user.FirstName;
            registrationViewModel.LastName = user.LastName;
            registrationViewModel.Username = user.Username;
            registrationViewModel.RoleId = user.RoleId;
            registrationViewModel.Email = user.Email;

            return View(registrationViewModel);

        }

        [HttpPost]
        public ActionResult ResetPassword(RegistrationViewModel registrationViewModel)
        {
            bool statusRegistration = false;
            string messageRegistration = string.Empty;
            if (ModelState.IsValid)
            {

                using (AuthenticationDB dbContext = new AuthenticationDB())
                {
                    var result = dbContext.Users.SingleOrDefault(m => m.UserId == registrationViewModel.UserId);
                    if (result != null)
                    {
                        result.Password = EncryptionProvider.Encrypt(registrationViewModel.Password);
                        dbContext.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "Home");

            }
            return View(registrationViewModel);
        }

    }
}