namespace Prodavalnik.Web.Areas.Admin.Controllers.Base
{
    using System.Web.Mvc;
    using Data.Contracts;

    public abstract class BaseController : Controller
    {
        private IProdavalnikData data;

        protected BaseController(IProdavalnikData data)
        {
            this.data = data;
        }
    }
}