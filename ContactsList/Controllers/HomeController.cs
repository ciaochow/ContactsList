using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactsList.Data;
using ContactsList.Models.ViewModels;

namespace ContactsList.Controllers
{
    public class HomeController : Controller
    {
        ContactsListRepo _repo = new ContactsListRepo();

        public ActionResult Index()
        {
            ContactsListVm vm = new ContactsListVm();
            _repo.LoadAll();
            vm.Contacts = _repo.List();

            return View();
        }

        
    }
}