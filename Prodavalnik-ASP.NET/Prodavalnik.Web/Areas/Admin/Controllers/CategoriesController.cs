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
    using Models.BindingModels;
    using Models.EntityModels;
    using Services;
    using Web.Controllers.Base;
    [RouteArea("Admin")]
    [RoutePrefix("Category")]
    [CustomAuthorize(Roles = "Admin")]
    public class CategoriesController : BaseController
    {
        private CategoriesService service;
        public CategoriesController(IProdavalnikData data) : base(data)
        {
            this.service = new CategoriesService(data);
        }

        [Route("all")]
        public ActionResult All()
        {
            return View();
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

                return RedirectToAction("All");
            }
            catch
            {
                return View();
            }
        }

        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Route("edit/{id}")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Route("delete/{id}")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}