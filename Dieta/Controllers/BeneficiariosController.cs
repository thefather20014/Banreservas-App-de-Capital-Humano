using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dieta.Models;
using PagedList;
using PagedList.Mvc;

namespace Dieta.Controllers
{
	[Authorize]
	public class BeneficiariosController : Controller
	{
		private ProcesosDAEntities db = new ProcesosDAEntities();

		// GET: Beneficiarios
		public ActionResult Index(string searchBy, string search, int? page)
		{
			var dD_Beneficiarios = db.DD_Beneficiarios.Include(d => d.DD_GrupoOcupacional).Include(d => d.DD_Solicitudes);
			if (searchBy == "Name")
			{
				return View(dD_Beneficiarios.Where(x => x.NOMBRE.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 8));
			}
			else
			{
				return View(dD_Beneficiarios.Where(x => x.CODIGO.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 8));
			}
		}

		// GET: Beneficiarios/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DD_Beneficiarios dD_Beneficiarios = db.DD_Beneficiarios.Find(id);
			if (dD_Beneficiarios == null)
			{
				return HttpNotFound();
			}
			return View(dD_Beneficiarios);
		}

		public ActionResult OrderByName()
		{
			var name = from n in db.DD_Beneficiarios
					   orderby n.NOMBRE
					   select n;
			return View(name);
		}

		public ActionResult OrderByTotal()
		{
			var name = from n in db.DD_Beneficiarios
					   orderby n.TOTAL descending
					   select n;
			return View(name);
		}

		public void add(string username)
		{
			var result = new DD_Bitacora()
			{
				USERNAME = User.Identity.Name,
			    EVENTO = User.Identity.Name + " Inserto en la tablaBeneficiario a " + username,
				DATE = DateTime.Now
			};

			db.DD_Bitacora.Add(result);
		}

		[Authorize]
		// GET: Beneficiarios/Create
		public ActionResult Create()
		{
			ViewBag.ASIGNATURASID = new SelectList(db.DD_GrupoOcupacional, "ID", "NOMBRE");
			ViewBag.SOLICITUDESID = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE");
			return View();
		}

		// POST: Beneficiarios/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CODIGO,NOMBRE,ASIGNATURASID,SOLICITUDESID,DESAYUNO,ALMUERZO,CENA,HOSPEDAJE,TOTAL")] DD_Beneficiarios dD_Beneficiarios)
        {
            if (ModelState.IsValid)
            {
                db.DD_Beneficiarios.Add(dD_Beneficiarios);
				add(dD_Beneficiarios.NOMBRE);
				db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ASIGNATURASID = new SelectList(db.DD_GrupoOcupacional, "ID", "NOMBRE", dD_Beneficiarios.ASIGNATURASID);
            ViewBag.SOLICITUDESID = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE", dD_Beneficiarios.SOLICITUDESID);
            return View(dD_Beneficiarios);
        }
		[Authorize(Roles = "Admin, Admin, Supervisor")]
		// GET: Beneficiarios/Edit/5
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Beneficiarios dD_Beneficiarios = db.DD_Beneficiarios.Find(id);
            if (dD_Beneficiarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.ASIGNATURASID = new SelectList(db.DD_GrupoOcupacional, "ID", "NOMBRE", dD_Beneficiarios.ASIGNATURASID);
            ViewBag.SOLICITUDESID = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE", dD_Beneficiarios.SOLICITUDESID);
            return View(dD_Beneficiarios);
        }

		// POST: Beneficiarios/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize(Roles = "Admin, Admin, Supervisor")]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CODIGO,NOMBRE,ASIGNATURASID,SOLICITUDESID,DESAYUNO,ALMUERZO,CENA,HOSPEDAJE,TOTAL")] DD_Beneficiarios dD_Beneficiarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dD_Beneficiarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ASIGNATURASID = new SelectList(db.DD_GrupoOcupacional, "ID", "NOMBRE", dD_Beneficiarios.ASIGNATURASID);
            ViewBag.SOLICITUDESID = new SelectList(db.DD_Solicitudes, "ID", "NOMBRE", dD_Beneficiarios.SOLICITUDESID);
            return View(dD_Beneficiarios);
        }
		[Authorize(Roles = "Admin, Admin, Supervisor")]
		// GET: Beneficiarios/Delete/5
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DD_Beneficiarios dD_Beneficiarios = db.DD_Beneficiarios.Find(id);
            if (dD_Beneficiarios == null)
            {
                return HttpNotFound();
            }
            return View(dD_Beneficiarios);
        }
		[Authorize(Roles = "Admin, Admin, Supervisor")]
		// POST: Beneficiarios/Delete/5
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DD_Beneficiarios dD_Beneficiarios = db.DD_Beneficiarios.Find(id);
            db.DD_Beneficiarios.Remove(dD_Beneficiarios);
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
