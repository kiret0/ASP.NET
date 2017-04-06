namespace Prodavalnik.Web.Controllers.Base
{
    using Data.Contracts;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        private IProdavalnikData data;

        protected BaseController(IProdavalnikData data)
        {
            this.data = data;
        }
    }
}