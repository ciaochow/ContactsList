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
            vm.Contacts = _repo.AllContacts().OrderBy(m => m.FirstName).ToList();
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

        [HttpPost]
        public ActionResult RemoveContact(int id)
        {
            _repo.RemoveContact(id);
            TempData["Message"] = "The contact has been deleted.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditContact(int id)
        {
            ContactsListVm vm = new ContactsListVm();
            vm.Contacts = _repo.AllContacts();
            Contact contacttoedit = new Contact();
            contacttoedit = vm.Contacts[id];

            return View(contacttoedit);
        }

        [HttpPost]
        public ActionResult EditContact(Contact model)
        {
            if (ModelState.IsValid && model != null)
            {
                Contact contact = new Contact()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    Email = model.Email
                };

                _repo.EditContact(contact);
                TempData["Message"] = "The contact has been updated.";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}