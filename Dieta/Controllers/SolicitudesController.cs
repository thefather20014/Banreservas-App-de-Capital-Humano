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
	public class SolicitudesController : Controller
    {
        private ProcesosDAEntities db = new ProcesosDAEntities();

        // GET: Solicitudes
        public ActionResult Index()
        {
            return View(db.DD_Solicitudes.ToList());
        }

        // GET: Solicitudes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Solicitudes dD_Solicitudes = db.DD_Solicitudes.Find(id);
            if (dD_Solicitudes == null)
            {
                return HttpNotFound();
            }
            return View(dD_Solicitudes);
        }
		[Authorize]
		// GET: Solicitudes/Create
		public ActionResult Create()
        {
            return View();
        }

        // POST: Solicitudes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,FECHA,CARGO,DEPENDENCIA,MOTIVO,F_ENTRADA,F_SALIDA,TIPO,Combustible")] DD_Solicitudes dD_Solicitudes)
        {
            if (ModelState.IsValid)
            {
                db.DD_Solicitudes.Add(dD_Solicitudes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dD_Solicitudes);
        }
		[Authorize(Roles = "Admin, Admin, Supervisor")]
		// GET: Solicitudes/Edit/5
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Solicitudes dD_Solicitudes = db.DD_Solicitudes.Find(id);
            if (dD_Solicitudes == null)
            {
                return HttpNotFound();
            }
            return View(dD_Solicitudes);
        }
		[Authorize(Roles = "Admin, Admin, Supervisor")]
		// POST: Solicitudes/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,FECHA,CARGO,DEPENDENCIA,MOTIVO,F_ENTRADA,F_SALIDA,TIPO,Combustible")] DD_Solicitudes dD_Solicitudes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dD_Solicitudes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dD_Solicitudes);
        }
		[Authorize(Roles = "Admin, Admin, Supervisor")]
		// GET: Solicitudes/Delete/5
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Solicitudes dD_Solicitudes = db.DD_Solicitudes.Find(id);
            if (dD_Solicitudes == null)
            {
                return HttpNotFound();
            }
            return View(dD_Solicitudes);
        }
		[Authorize(Roles = "Admin, Admin, Supervisor")]
		// POST: Solicitudes/Delete/5
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DD_Solicitudes dD_Solicitudes = db.DD_Solicitudes.Find(id);
            db.DD_Solicitudes.Remove(dD_Solicitudes);
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
