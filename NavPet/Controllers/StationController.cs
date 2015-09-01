using NavPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NavPet.Controllers
{
    public class StationController : Controller
    {
        public static readonly IStationRepository _station = new StationRepository();
        //
        // GET: /Station/

        public ActionResult Index()
        {
            return View(_station.GetAllStations().AsQueryable());
        }

        //
        // GET: /Station/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Station/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Station/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create(Station station)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                _station.AddStation(station);
                return RedirectToAction("Create");
            }
            
            {
                return View(station);
            }
        }

        //
        // GET: /Station/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Station/Edit/5

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

        //
        // GET: /Station/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Station/Delete/5

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
