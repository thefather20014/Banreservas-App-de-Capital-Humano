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
    public class DD_BitacoraController : Controller
    {
        private ProcesosDAEntities db = new ProcesosDAEntities();

        // GET: DD_Bitacora
        public ActionResult Index()
        {
            return View(db.DD_Bitacora.ToList());
        }

        // GET: DD_Bitacora/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Bitacora dD_Bitacora = db.DD_Bitacora.Find(id);
            if (dD_Bitacora == null)
            {
                return HttpNotFound();
            }
            return View(dD_Bitacora);
        }

        // GET: DD_Bitacora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DD_Bitacora/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,USERNAME,EVENTO,DATE")] DD_Bitacora dD_Bitacora)
        {
            if (ModelState.IsValid)
            {
                db.DD_Bitacora.Add(dD_Bitacora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dD_Bitacora);
        }

        // GET: DD_Bitacora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Bitacora dD_Bitacora = db.DD_Bitacora.Find(id);
            if (dD_Bitacora == null)
            {
                return HttpNotFound();
            }
            return View(dD_Bitacora);
        }

        // POST: DD_Bitacora/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,USERNAME,EVENTO,DATE")] DD_Bitacora dD_Bitacora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dD_Bitacora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dD_Bitacora);
        }

        // GET: DD_Bitacora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Bitacora dD_Bitacora = db.DD_Bitacora.Find(id);
            if (dD_Bitacora == null)
            {
                return HttpNotFound();
            }
            return View(dD_Bitacora);
        }

        // POST: DD_Bitacora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DD_Bitacora dD_Bitacora = db.DD_Bitacora.Find(id);
            db.DD_Bitacora.Remove(dD_Bitacora);
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
