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
	public class DesembolsoController : Controller
    {
        private ProcesosDAEntities db = new ProcesosDAEntities();

        // GET: Desembolso
        public ActionResult Index()
        {
            var dD_Desembolso = db.DD_Desembolso.Include(d => d.DD_Beneficiarios);
            return View(dD_Desembolso.ToList());
        }

        // GET: Desembolso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Desembolso dD_Desembolso = db.DD_Desembolso.Find(id);
            if (dD_Desembolso == null)
            {
                return HttpNotFound();
            }
            return View(dD_Desembolso);
        }

        // GET: Desembolso/Create
        public ActionResult Create()
        {
            ViewBag.BENEFICIARIOID = new SelectList(db.DD_Beneficiarios, "ID", "CODIGO");
            return View();
        }

        // POST: Desembolso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CODIGO,BENEFICIARIOID,CODIGO_BENEFICIARIO,MONTO,FECHA,CONCEPTO,AREA,METODO_PAGO")] DD_Desembolso dD_Desembolso)
        {
            if (ModelState.IsValid)
            {
                db.DD_Desembolso.Add(dD_Desembolso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BENEFICIARIOID = new SelectList(db.DD_Beneficiarios, "ID", "CODIGO", dD_Desembolso.BENEFICIARIOID);
            return View(dD_Desembolso);
        }
		[Authorize(Roles = "Admin, Admin, Supervisor")]
		// GET: Desembolso/Edit/5
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Desembolso dD_Desembolso = db.DD_Desembolso.Find(id);
            if (dD_Desembolso == null)
            {
                return HttpNotFound();
            }
            ViewBag.BENEFICIARIOID = new SelectList(db.DD_Beneficiarios, "ID", "CODIGO", dD_Desembolso.BENEFICIARIOID);
            return View(dD_Desembolso);
        }

        // POST: Desembolso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CODIGO,BENEFICIARIOID,CODIGO_BENEFICIARIO,MONTO,FECHA,CONCEPTO,AREA,METODO_PAGO")] DD_Desembolso dD_Desembolso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dD_Desembolso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BENEFICIARIOID = new SelectList(db.DD_Beneficiarios, "ID", "CODIGO", dD_Desembolso.BENEFICIARIOID);
            return View(dD_Desembolso);
        }
		[Authorize(Roles = "Admin, Admin, Supervisor")]
		// GET: Desembolso/Delete/5
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Desembolso dD_Desembolso = db.DD_Desembolso.Find(id);
            if (dD_Desembolso == null)
            {
                return HttpNotFound();
            }
            return View(dD_Desembolso);
        }
		[Authorize(Roles = "Admin, Admin, Supervisor")]
		// POST: Desembolso/Delete/5
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DD_Desembolso dD_Desembolso = db.DD_Desembolso.Find(id);
            db.DD_Desembolso.Remove(dD_Desembolso);
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
