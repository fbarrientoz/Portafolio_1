using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portafolio_1.Models;

namespace Portafolio_1.Controllers
{
    public class HabilidadController : Controller
    {
        private portafolioEntities1 db = new portafolioEntities1();

        // GET: Habilidad
        public ActionResult Index()
        {
            var habilidads = db.Habilidads.Include(h => h.AspNetUser);
            return View(habilidads.ToList());
        }

        // GET: Habilidad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habilidad habilidad = db.Habilidads.Find(id);
            if (habilidad == null)
            {
                return HttpNotFound();
            }
            return View(habilidad);
        }

        // GET: Habilidad/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Habilidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UsuarioId,Nombre,Dominio")] Habilidad habilidad)
        {
            if (ModelState.IsValid)
            {
                db.Habilidads.Add(habilidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", habilidad.UsuarioId);
            return View(habilidad);
        }

        // GET: Habilidad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habilidad habilidad = db.Habilidads.Find(id);
            if (habilidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", habilidad.UsuarioId);
            return View(habilidad);
        }

        // POST: Habilidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UsuarioId,Nombre,Dominio")] Habilidad habilidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(habilidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", habilidad.UsuarioId);
            return View(habilidad);
        }

        // GET: Habilidad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habilidad habilidad = db.Habilidads.Find(id);
            if (habilidad == null)
            {
                return HttpNotFound();
            }
            return View(habilidad);
        }

        // POST: Habilidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Habilidad habilidad = db.Habilidads.Find(id);
            db.Habilidads.Remove(habilidad);
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
