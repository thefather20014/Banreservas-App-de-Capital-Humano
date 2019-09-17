using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dieta.Models;

namespace Dieta.Controllers
{
	[Authorize(Roles = "Admin, Admin")]
	public class PERFILEsController : Controller
    {
        private ProcesosDAEntities db = new ProcesosDAEntities();

        // GET: PERFILEs
        public ActionResult Index()
        {
            return View(db.PERFILES.ToList());
        }

        // GET: PERFILEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERFILE pERFILE = db.PERFILES.Find(id);
            if (pERFILE == null)
            {
                return HttpNotFound();
            }
            return View(pERFILE);
        }

        // GET: PERFILEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PERFILEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PERFIL")] PERFILE pERFILE)
        {
            if (ModelState.IsValid)
            {
                db.PERFILES.Add(pERFILE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pERFILE);
        }

        // GET: PERFILEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERFILE pERFILE = db.PERFILES.Find(id);
            if (pERFILE == null)
            {
                return HttpNotFound();
            }
            return View(pERFILE);
        }

        // POST: PERFILEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PERFIL")] PERFILE pERFILE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERFILE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pERFILE);
        }

        // GET: PERFILEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERFILE pERFILE = db.PERFILES.Find(id);
            if (pERFILE == null)
            {
                return HttpNotFound();
            }
            return View(pERFILE);
        }

        // POST: PERFILEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERFILE pERFILE = db.PERFILES.Find(id);
            db.PERFILES.Remove(pERFILE);
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
