using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TenYears.Services;
using TenYears.Models;

namespace TenYears.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        public ActionResult Index()
        {
            var person = new Person
            {
                Name = "Johan Öbrink",
                Photo = "http://fbcdn-sphotos-a.akamaihd.net/hphotos-ak-snc6/179618_10150133532645917_751525916_7929526_1262526_n.jpg",
                Testimonial = new Testimonial
                {
                    Headline = "Johan Öbrink",
                    Text = @"Since 2001, I met and married Adela and had two children - Caesar and Ava.

I moved three times.

I went from The Bearded Lady to Paradiset DDB and then started Man Machine which I then sold to 24HR where I remain.

I switched from Altavista to Google."
                },
                Events = new List<TimelineEvent>()
            };

            return View("details", person);
        }

        public ActionResult Details(string id)
        {
            return View(personService.Get(id));
        }

    }
}
