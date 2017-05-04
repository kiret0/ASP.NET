using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodavalnik.Web.Areas.Admin.Controllers
{
    using Attributes;
    using AutoMapper;
    using Data.Contracts;
    using Models.BindingModels.Admin;
    using Models.EntityModels;
    using Models.ViewModels.Admin;
    using Services;
    using Web.Controllers.Base;

    [RouteArea("Admin")]
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private AdminService service;


        public AdminController(IProdavalnikData data) : base(data)
        {
            this.service = new AdminService(data);
        }

        [Route("~/admin")]
        public ActionResult AdminPanel()
        {
            var reportsUnreadCount = this.service.GetReportsUnreadCount();
            var registeredUsersCount = this.service.GetRegisteredUsersCount();
            var adminPanelViewModel = new AdminPanelViewModel()
            {
                ReportsUnreadCount = reportsUnreadCount,
                RegisteredUserCount = registeredUsersCount
            };
            return View(adminPanelViewModel);
        }

        [Route("~/admin/addAdmin")]
        public ActionResult AddAdmin(string username)
        {
            var user = this.service.GetUserByUsername(username);
            return View(user);
        }

        [Route("~/admin/addAdmin")]
        [HttpPost]
        public ActionResult AddAdmin([Bind(Exclude = "")] AddAdminBindingModel bind)
        {
            this.service.AddAdmin(bind.UserId);
            return RedirectToAction("AdminPanel");
        }

        [Route("~/admin/reports")]
        public ActionResult Reports()
        {
            var reportsFromDb = this.service.GetReports();
            var reportViewModels = Mapper.Map<IEnumerable<Report>, IEnumerable<ReportViewModel>>(reportsFromDb);
            return View(reportViewModels);
        }
        [Route("~/admin/reports")]
        [HttpPost]
        public ActionResult Reports([Bind(Exclude = "")] ReportBindingModel bind)
        {
            var reportsFromDb = this.service.GetReports();
            var reportViewModels = Mapper.Map<IEnumerable<Report>, IEnumerable<ReportViewModel>>(reportsFromDb);
            this.service.ReadReport(bind.ReportId);
            return View(reportViewModels);
        }

        [Route("~/admin/reports/read")]
        public ActionResult ReadReports()
        {
            var reportsFromDb = this.service.GetReadReports();
            var reportViewModels = Mapper.Map<IEnumerable<Report>, IEnumerable<ReportViewModel>>(reportsFromDb);
            return View(reportViewModels);
        }

        
    }
}