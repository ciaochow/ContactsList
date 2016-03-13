using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactsList.Data;
using ContactsList.Model;
using ContactsList.Models.ViewModels;

namespace ContactsList.Controllers
{
    public class HomeController : Controller
    {
        ContactsListRepo _repo = new ContactsListRepo();

        public ActionResult Index()
        {
            ContactsListVm vm = new ContactsListVm();
            vm.Contacts = _repo.AllContacts();
            ViewBag.Message = TempData["Message"];
            return View(vm);
        }

        public ActionResult AddContact()
        {
            return View("AddContact", new Contact());
        }

        [HttpPost]
        public ActionResult AddContact(Contact model)
        {
            if (ModelState.IsValid)
            {
                _repo.AddContact(model);
                TempData["Message"] = "A new contact has been added.";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //public ActionResult RemoveContact(Contact model)
        //{
        //    return View(model);
        //}


        //[HttpPost]
        //public ActionResult RemoveContact(int id)
        //{
        //    _repo.RemoveContact(id);
        //    TempData["Message"] = "The contact has been deleted.";
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult RemoveContact(int id)
        {
            _repo.RemoveContact(id);
            TempData["Message"] = "The contact has been deleted.";
            return RedirectToAction("Index");
        }
    }
}