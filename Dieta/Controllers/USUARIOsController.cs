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
	public class USUARIOsController : Controller
    {
        private ProcesosDAEntities db = new ProcesosDAEntities();

        // GET: USUARIOs
        public ActionResult Index()
        {
            var uSUARIOS = db.USUARIOS.Include(u => u.PERFILE);
            return View(uSUARIOS.ToList());
        }

		public ActionResult OrderByName()
		{
			var name = from n in db.USUARIOS
					   orderby n.USUARIO1
					   select n;
			return View(name);
		}

		public ActionResult OrderByPassword()
		{
			var pass = from n in db.USUARIOS
					   orderby n.PASSWORD
					   select n;
			return View(pass);
		}

		public ActionResult OrderByPerfil()
		{
			var perfil = from n in db.USUARIOS
					   join role in db.PERFILES on
					   n.PERFIL equals role.ID
					   orderby role.PERFIL ascending
					   select n;
			return View(perfil);
		}

		// GET: USUARIOs/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIOs/Create
        public ActionResult Create()
        {
            ViewBag.PERFIL = new SelectList(db.PERFILES, "ID", "PERFIL");
            return View();
        }

        // POST: USUARIOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,USUARIO1,PASSWORD,PERFIL")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIOS.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PERFIL = new SelectList(db.PERFILES, "ID", "PERFIL", uSUARIO.PERFIL);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PERFIL = new SelectList(db.PERFILES, "ID", "PERFIL", uSUARIO.PERFIL);
            return View(uSUARIO);
        }

        // POST: USUARIOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,USUARIO1,PASSWORD,PERFIL")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PERFIL = new SelectList(db.PERFILES, "ID", "PERFIL", uSUARIO.PERFIL);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            db.USUARIOS.Remove(uSUARIO);
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
