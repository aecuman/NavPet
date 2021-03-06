﻿using NavPet.Models.Userprofiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NavPet.Controllers
{
    public class ProfilesController : Controller
    {
        public static readonly IProfilesRepository _profile = new ProfilesRepository();
        //
        // GET: /Profiles/

        public ActionResult Index()
        {
            //_profile.GetAllProfiles()

            return View(_profile.GetAllProfiles().Where(s => s.UserName.Contains(User.Identity.Name)));
        }

        //
        // GET: /Profiles/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Profiles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Profiles/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Profiles/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Profiles/Edit/5

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
        // GET: /Profiles/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Profiles/Delete/5

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
