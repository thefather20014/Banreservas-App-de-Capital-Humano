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
	[Authorize(Roles = "Admin, Admin, Supervisor")]
	public class DISTANCIAsController : Controller
    {
        private ProcesosDAEntities db = new ProcesosDAEntities();

        // GET: DISTANCIAs
        public ActionResult Index()
        {
            var dISTANCIAs = db.DISTANCIAs.Include(d => d.DD_Solicitudes);
            return View(dISTANCIAs.ToList());
        }

        // GET: DISTANCIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTANCIA dISTANCIA = db.DISTANCIAs.Find(id);
            if (dISTANCIA == null)
            {
                return HttpNotFound();
            }
            return View(dISTANCIA);
        }

        // GET: DISTANCIAs/Create
        public ActionResult Create()
        {
            ViewBag.SOLICITUD = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE");
            return View();
        }

        // POST: DISTANCIAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,SOLICITUD,DESDE,HASTA,KM")] DISTANCIA dISTANCIA)
        {
            if (ModelState.IsValid)
            {
                db.DISTANCIAs.Add(dISTANCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SOLICITUD = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE", dISTANCIA.SOLICITUD);
            return View(dISTANCIA);
        }

        // GET: DISTANCIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTANCIA dISTANCIA = db.DISTANCIAs.Find(id);
            if (dISTANCIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.SOLICITUD = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE", dISTANCIA.SOLICITUD);
            return View(dISTANCIA);
        }

        // POST: DISTANCIAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,SOLICITUD,DESDE,HASTA,KM")] DISTANCIA dISTANCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISTANCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SOLICITUD = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE", dISTANCIA.SOLICITUD);
            return View(dISTANCIA);
        }

        // GET: DISTANCIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTANCIA dISTANCIA = db.DISTANCIAs.Find(id);
            if (dISTANCIA == null)
            {
                return HttpNotFound();
            }
            return View(dISTANCIA);
        }

        // POST: DISTANCIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DISTANCIA dISTANCIA = db.DISTANCIAs.Find(id);
            db.DISTANCIAs.Remove(dISTANCIA);
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
