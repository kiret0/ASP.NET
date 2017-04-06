namespace Prodavalnik.Web.Controllers
{
    using Base;
    using Data.Contracts;
    using System.Web.Mvc;
    using Services;

    public class HomeController : BaseController
    {
        private HomeService service;
        public HomeController(IProdavalnikData data) : base(data)
        {
            this.service = new HomeService(data);
        }

        public ActionResult Index(string search)
        {
            return View();
        }

        
    }
}