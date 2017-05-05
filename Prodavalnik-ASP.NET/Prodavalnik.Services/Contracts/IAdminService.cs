namespace Prodavalnik.Services.Contracts
{
    using System.Collections.Generic;
    using Models.EntityModels;

    public interface IAdminService
    {
        ApplicationUser GetUserByUsername(string username);
        void AddAdmin(string userId);
        int GetReportsUnreadCount();
        int GetRegisteredUsersCount();
        IEnumerable<Report> GetReports();
        void ReadReport(int reportId);
        IEnumerable<Report> GetReadReports();
    }
}