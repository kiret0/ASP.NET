using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodavalnik.Web.Controllers
{
    using AutoMapper;
    using Base;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
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

    }
}
