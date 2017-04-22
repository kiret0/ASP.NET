using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodavalnik.Web.Controllers
{
    using System.IO;
    using AutoMapper;
    using Base;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels.Ads;
    using Models.EntityModels;
    using Models.EntityModels.Enums;
    using Models.ViewModels.Ads;
    using Ninject.Infrastructure.Language;
    using Services;
    [RoutePrefix("ads")]
    [Authorize]
    public class AdsController : BaseController
    {
        private AdsService service;

        public AdsController(IProdavalnikData data) : base(data)
        {
            this.service = new AdsService(data);
        }

        [AllowAnonymous]
        [Route("~/ads")]
        public ActionResult Index(string query)
        {
            var categories = this.service.GetAllCategories();

            var cats = categories.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
                Selected = true

            });

            var adsFromDb = this.service.FindingAdsByQuery(query);
            IEnumerable<PreviewAdViewModel> ads = Mapper.Map<IEnumerable<Ad>, IEnumerable<PreviewAdViewModel>>(adsFromDb);
            
            AdsViewModel adsVm = new AdsViewModel()
            {
                previewAdViewModels = ads,
                Categories = cats
            };
            return View(adsVm);
        }

        // GET: Ads/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("add")]
        public ActionResult Add()
        {
            var categories = this.service.GetAllCategories();

             var cats= categories.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
                Selected = true

            });
            
            AddAdViewModel advm = new AddAdViewModel()
            {
                Categories = cats
            };
            return View(advm);
        }

        [Route("add")]
        [HttpPost]
        public ActionResult Add([Bind(Exclude = "")] AddAdsBindingModel bind, HttpPostedFileBase[] images)
        {
            try
            {
                var imgs = new HashSet<Image>();

                foreach (var image in images)
                {
                    if (image != null && image.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(image.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadsImages"), fileName);
                        image.SaveAs(path);

                        var img = new Image() { ImageName = fileName };
                        imgs.Add(img);
                    }

                }

                if (ModelState.IsValid)
                {
                    var category = this.service.GetCategoryById(bind.CategoryId);
                    var user = this.service.GetUserById(User.Identity.GetUserId());
                    
                    this.service.AddAdToDatabase(category, user, imgs, bind);
                }
                return RedirectToAction("Index","Home");
            }
            catch
            {
                var categories = this.service.GetAllCategories();

                var cats = categories.Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                    Selected = true

                });

                AddAdViewModel advm = new AddAdViewModel()
                {
                    Categories = cats
                };
                return View(advm);
            }
        }

        // GET: Ads/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ads/Edit/5
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

        // GET: Ads/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ads/Delete/5
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
