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
	public class GrupoOcupacionalController : Controller
    {
        private ProcesosDAEntities db = new ProcesosDAEntities();

        // GET: GrupoOcupacional
        public ActionResult Index()
        {
            return View(db.DD_GrupoOcupacional.ToList());
        }

        // GET: GrupoOcupacional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_GrupoOcupacional dD_GrupoOcupacional = db.DD_GrupoOcupacional.Find(id);
            if (dD_GrupoOcupacional == null)
            {
                return HttpNotFound();
            }
            return View(dD_GrupoOcupacional);
        }

        // GET: GrupoOcupacional/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoOcupacional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,DESAYUNO,ALMUERZO,CENA,HOSPEDAJE")] DD_GrupoOcupacional dD_GrupoOcupacional)
        {
            if (ModelState.IsValid)
            {
                db.DD_GrupoOcupacional.Add(dD_GrupoOcupacional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dD_GrupoOcupacional);
        }
		// GET: GrupoOcupacional/Edit/5
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_GrupoOcupacional dD_GrupoOcupacional = db.DD_GrupoOcupacional.Find(id);
            if (dD_GrupoOcupacional == null)
            {
                return HttpNotFound();
            }
            return View(dD_GrupoOcupacional);
        }

        // POST: GrupoOcupacional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,DESAYUNO,ALMUERZO,CENA,HOSPEDAJE")] DD_GrupoOcupacional dD_GrupoOcupacional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dD_GrupoOcupacional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dD_GrupoOcupacional);
        }

        // GET: GrupoOcupacional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_GrupoOcupacional dD_GrupoOcupacional = db.DD_GrupoOcupacional.Find(id);
            if (dD_GrupoOcupacional == null)
            {
                return HttpNotFound();
            }
            return View(dD_GrupoOcupacional);
        }

        // POST: GrupoOcupacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DD_GrupoOcupacional dD_GrupoOcupacional = db.DD_GrupoOcupacional.Find(id);
            db.DD_GrupoOcupacional.Remove(dD_GrupoOcupacional);
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
