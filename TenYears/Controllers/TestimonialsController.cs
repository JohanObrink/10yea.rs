using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TenYears.Services;
using TenYears.Models;

namespace TenYears.Controllers
{
    public class TestimonialsController : Controller
    {
        private readonly IPersonService personService;

        public TestimonialsController(IPersonService personService)
        {
            this.personService = personService;
        }

        public ActionResult Show(string id, string name)
        {
            return View();
        }

        public ActionResult Create(Person person)
        {
            return View();
        }

    }
}
