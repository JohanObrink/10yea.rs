using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TenYears.Services;
using TenYears.Models;

namespace TenYears.Controllers
{
    public class TimelineController : Controller
    {
        private readonly ITimelineService timelineService;

        public TimelineController(ITimelineService timelineService)
        {
            this.timelineService = timelineService;
        }
        //
        // GET: /Timeline/

        public ActionResult Index()
        {
            return View(timelineService.GetAll());
        }

        //
        // GET: /Timeline/Details/5

        public ActionResult Details(string id)
        {
            return View(timelineService.Get(id));
        }

        //
        // GET: /Timeline/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Timeline/Create

        [HttpPost]
        public ActionResult Create(TimelineEvent timelineEvent)
        {
            try
            {
                // TODO: Add insert logic here
                timelineEvent = timelineService.Save(timelineEvent);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Could not Create", ex);
                return View(timelineEvent);
            }
        }
        
        //
        // GET: /Timeline/Edit/5
 
        public ActionResult Edit(string id)
        {
            return View(timelineService.Get(id));
        }

        //
        // POST: /Timeline/Edit/5

        [HttpPost]
        public ActionResult Edit(TimelineEvent timelineEvent)
        {
            try
            {
                // TODO: Add update logic here
                timelineEvent = timelineService.Save(timelineEvent);

                return RedirectToAction("Details", new { id = timelineEvent.Id });
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Could not Edit", ex);
                return View(timelineEvent);
            }
        }

        //
        // GET: /Timeline/Delete/5
 
        public ActionResult Delete(string id)
        {
            return View(timelineService.Get(id));
        }

        //
        // POST: /Timeline/Delete/5

        [HttpPost]
        public ActionResult Delete(TimelineEvent timelineEvent)
        {
            try
            {
                // TODO: Add delete logic here
                timelineService.Delete(timelineEvent);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Could not Delete", ex);
                return View(timelineEvent);
            }
        }
    }
}
