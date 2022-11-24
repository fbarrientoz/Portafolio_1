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
    public class ExperienciaController : Controller
    {
        private portafolioEntities1 db = new portafolioEntities1();

        // GET: Experiencia
        public ActionResult Index()
        {
            var experiencias = db.Experiencias.Include(e => e.AspNetUser).Include(e => e.Tipo);
            return View(experiencias.ToList());
        }

        // GET: Experiencia/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = db.Experiencias.Find(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // GET: Experiencia/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Tipo_ID = new SelectList(db.Tipoes, "Id", "Descripcion");
            return View();
        }

        // POST: Experiencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UsuarioID,Tipo_ID,Nombre,Titulo,Desde,Hasta,Descripcion")] Experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                db.Experiencias.Add(experiencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", experiencia.UsuarioID);
            ViewBag.Tipo_ID = new SelectList(db.Tipoes, "Id", "Descripcion", experiencia.Tipo_ID);
            return View(experiencia);
        }

        // GET: Experiencia/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = db.Experiencias.Find(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", experiencia.UsuarioID);
            ViewBag.Tipo_ID = new SelectList(db.Tipoes, "Id", "Descripcion", experiencia.Tipo_ID);
            return View(experiencia);
        }

        // POST: Experiencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UsuarioID,Tipo_ID,Nombre,Titulo,Desde,Hasta,Descripcion")] Experiencia experiencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experiencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", experiencia.UsuarioID);
            ViewBag.Tipo_ID = new SelectList(db.Tipoes, "Id", "Descripcion", experiencia.Tipo_ID);
            return View(experiencia);
        }

        // GET: Experiencia/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = db.Experiencias.Find(id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        // POST: Experiencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Experiencia experiencia = db.Experiencias.Find(id);
            db.Experiencias.Remove(experiencia);
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
