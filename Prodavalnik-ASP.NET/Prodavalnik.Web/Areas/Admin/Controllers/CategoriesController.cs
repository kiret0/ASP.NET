using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodavalnik.Web.Areas.Admin.Controllers
{
    using Attributes;
    using AutoMapper;
    using Base;
    using Data.Contracts;
    using Models.BindingModels.Admin;
    using Models.EntityModels;
    using Services;
    using Services.Contracts;

    [RouteArea("Admin")]
    [RoutePrefix("Category")]
    [CustomAuthorize(Roles = "Admin")]
    public class CategoriesController : BaseController
    {
        private ICategoriesService service;
        public CategoriesController(IProdavalnikData data) : base(data)
        {
            this.service = new CategoriesService(data);
        }
        
        [Route("add")]
        public ActionResult Add()
        {
            return View();
        }

        [Route("add")]
        [HttpPost]
        public ActionResult Add([Bind(Exclude = "")] AddCategoryBindingModel bind)
        {
            try
            {
                var category = Mapper.Map<AddCategoryBindingModel,Category>(bind);
                this.service.AddNewCategory(category);

                return RedirectToAction("AdminPanel","Admin");
            }
            catch
            {
                return View();
            }
        }

        
    }
}