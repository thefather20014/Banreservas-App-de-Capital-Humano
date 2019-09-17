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
	[Authorize]
	public class COSTOsController : Controller
    {
        private ProcesosDAEntities db = new ProcesosDAEntities();

        // GET: COSTOs
        public ActionResult Index()
        {
            var cOSTOes = db.COSTOes.Include(c => c.DD_Solicitudes);
            return View(cOSTOes.ToList());
        }

        // GET: COSTOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COSTO cOSTO = db.COSTOes.Find(id);
            if (cOSTO == null)
            {
                return HttpNotFound();
            }
            return View(cOSTO);
        }

        // GET: COSTOs/Create
        public ActionResult Create()
        {
            ViewBag.SOLICITUD = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE");
            return View();
        }

        // POST: COSTOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SOLICITUD,COSTO1")] COSTO cOSTO)
        {
            if (ModelState.IsValid)
            {
                db.COSTOes.Add(cOSTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SOLICITUD = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE", cOSTO.SOLICITUD);
            return View(cOSTO);
        }

        // GET: COSTOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COSTO cOSTO = db.COSTOes.Find(id);
            if (cOSTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.SOLICITUD = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE", cOSTO.SOLICITUD);
            return View(cOSTO);
        }

        // POST: COSTOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SOLICITUD,COSTO1")] COSTO cOSTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOSTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SOLICITUD = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE", cOSTO.SOLICITUD);
            return View(cOSTO);
        }

        // GET: COSTOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COSTO cOSTO = db.COSTOes.Find(id);
            if (cOSTO == null)
            {
                return HttpNotFound();
            }
            return View(cOSTO);
        }

        // POST: COSTOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COSTO cOSTO = db.COSTOes.Find(id);
            db.COSTOes.Remove(cOSTO);
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
