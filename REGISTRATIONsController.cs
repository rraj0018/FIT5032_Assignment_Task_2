using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment_Task_2.Models;

namespace FIT5032_Assignment_Task_2.Controllers
{
    public class REGISTRATIONsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: REGISTRATIONs
        public ActionResult Index()
        {
            return View(db.REGISTRATIONs.ToList());
        }

        // GET: REGISTRATIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRATION rEGISTRATION = db.REGISTRATIONs.Find(id);
            if (rEGISTRATION == null)
            {
                return HttpNotFound();
            }
            return View(rEGISTRATION);
        }

        // GET: REGISTRATIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: REGISTRATIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_role,user_name,user_email,user_password")] REGISTRATION rEGISTRATION)
        {
            if (ModelState.IsValid)
            {
                db.REGISTRATIONs.Add(rEGISTRATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rEGISTRATION);
        }

        // GET: REGISTRATIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRATION rEGISTRATION = db.REGISTRATIONs.Find(id);
            if (rEGISTRATION == null)
            {
                return HttpNotFound();
            }
            return View(rEGISTRATION);
        }

        // POST: REGISTRATIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_role,user_name,user_email,user_password")] REGISTRATION rEGISTRATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEGISTRATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rEGISTRATION);
        }

        // GET: REGISTRATIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRATION rEGISTRATION = db.REGISTRATIONs.Find(id);
            if (rEGISTRATION == null)
            {
                return HttpNotFound();
            }
            return View(rEGISTRATION);
        }

        // POST: REGISTRATIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REGISTRATION rEGISTRATION = db.REGISTRATIONs.Find(id);
            db.REGISTRATIONs.Remove(rEGISTRATION);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
