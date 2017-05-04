using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodavalnik.Web.Controllers
{
    using System.Web.Security;
    using AutoMapper;
    using Base;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.BindingModels.Users;
    using Models.EntityModels;
    using Models.ViewModels.User;
    using Services;

    [Authorize]
    [RoutePrefix("profile")]
    public class UsersController : BaseController
    {
        private UsersService service;
        // GET: Users
        public UsersController(IProdavalnikData data) : base(data)
        {
            this.service = new UsersService(data);
        }

        [Route("~/profile")]
        public ActionResult Profile()
        {
            
            var myAdsFromDb = this.service.GetMyAdsFromDb(User.Identity.GetUserId());
            IEnumerable<MyAdViewModel> myAdViewModels =
                Mapper.Map<IEnumerable<Ad>, IEnumerable<MyAdViewModel>>(myAdsFromDb);

            return View(myAdViewModels);
        }
        [Route("messages")]
        public ActionResult Messages()
        {
            var messagesFromDb = this.service.GetMessagesFromDb(User.Identity.GetUserId());
            IEnumerable<MessageViewModel> messageViewModels =
                Mapper.Map<IEnumerable<Message>, IEnumerable<MessageViewModel>>(messagesFromDb);
            return View(messageViewModels);
        }
        [Route("messages/send")]
        public ActionResult SendMessages()
        {
            var sendMessagesFromDb = this.service.GetSendMessagesFromDb(User.Identity.GetUserId());
            IEnumerable<MessageViewModel> messageViewModels =
                Mapper.Map<IEnumerable<Message>, IEnumerable<MessageViewModel>>(sendMessagesFromDb);
            return View(messageViewModels);
        }
        [Route("message/{messageId}")]
        public ActionResult MessageDetails(int messageId)
        {
            var messageFromDb = this.service.GetMessage(messageId);
            MessageDetailsViewModel messageViewModel = Mapper.Map<Message, MessageDetailsViewModel>(messageFromDb);
            return View(messageViewModel);
        }
        [Route("message/{messageId}")]
        [HttpPost]
        public ActionResult MessageDetails([Bind(Exclude = "")] SendMessageBindingModel bind,int messageId)
        {
            var ad = this.service.GetAdByName(bind.AdName);
            var sender = this.service.GetUserById(User.Identity.GetUserId());
            var recipient = this.service.GetUserById(bind.RecipientId);
            this.service.AddMessage(ad, sender, recipient, bind.MessageContent);
            return RedirectToAction("SendMessages", "Users");
        }

        [Route("settings")]
        public ActionResult Settings(string message)
        {
            var user = this.service.GetUserById(User.Identity.GetUserId());
            var settingsViewModel = new SettingsViewModel()
            {
                CurrentUser = user
            };
            ViewBag.StatusMessage = message;
            return View(settingsViewModel);
        }

        [Route("settings/editProfile")]
        [HttpPost]
        public ActionResult EditProfile([Bind(Exclude = "")] EditProfileBindingModel bind)
        {
            var currentUser = this.service.GetUserById(User.Identity.GetUserId());
            var settingsViewModel = new SettingsViewModel()
            {
                CurrentUser = currentUser
            };
            if (ModelState.IsValid)
            {
                
                this.service.EditProfile(currentUser, bind);

            }
            return RedirectToAction("Settings", "Users", new {Message = "Успеншо редактирахте профила" });
        }

        [Route("ad/delete")]
        [HttpPost]
        public ActionResult DeleteAd([Bind(Exclude = "")] DeleteMyAdBindingModel bind)
        {
            var ad = this.service.GetAdById(bind.AdId);
            this.service.DeleteAd(ad);
            return RedirectToAction("Profile");
        }

        [Route("settings/deleteProfile")]
        [HttpPost]
        public ActionResult DeleteProfile()
        {
            var user = this.service.GetUserById(User.Identity.GetUserId());
            this.service.RemoveAds(user);
            this.service.RemoveMessages(user);
            return RedirectToAction("DeleteProfile", "Manage", new {area = ""});
        }
    }
}
