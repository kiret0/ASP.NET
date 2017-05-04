namespace Prodavalnik.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;

    public class AdminService : Service
    {
        public AdminService(IProdavalnikData data) : base(data)
        {
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            var user = this.data.Users.FindByPredicate(u => u.UserName.Contains(username));
            return user;
        }

        public void AddAdmin(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(data.Context.DbContext));
            userManager.AddToRole(userId, "Admin");
        }

        public int GetReportsUnreadCount()
        {
            var count = this.data.Reports.Find(rep => rep.Read == false).Count();
            return count;
        }

        public int GetRegisteredUsersCount()
        {
            var count = this.data.Users.GetAll().Count();
            return count;
        }

        public IEnumerable<Report> GetReports()
        {
            var reports = this.data.Reports.Find(rep => rep.Read == false);
            return reports;
        }

        public void ReadReport(int reportId)
        {
            this.data.Reports.GetById(reportId).Read = true;
            this.data.SaveChanges();
        }

        public IEnumerable<Report> GetReadReports()
        {
            var reports = this.data.Reports.Find(rep => rep.Read);
            return reports;
        }
        
    }
}