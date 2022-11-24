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
    public class DatoController : Controller
    {
        private portafolioEntities1 db = new portafolioEntities1();

        // GET: Dato
        public ActionResult Index()
        {
            var datos = db.Datos.Include(d => d.AspNetUser);
            return View(datos.ToList());
        }

        // GET: Dato/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dato dato = db.Datos.Find(id);
            if (dato == null)
            {
                return HttpNotFound();
            }
            return View(dato);
        }

        // GET: Dato/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Dato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Clientes,Texto,UsuarioId,Descripcion_Hecho")] Dato dato)
        {
            if (ModelState.IsValid)
            {
                db.Datos.Add(dato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", dato.UsuarioId);
            return View(dato);
        }

        // GET: Dato/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dato dato = db.Datos.Find(id);
            if (dato == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", dato.UsuarioId);
            return View(dato);
        }

        // POST: Dato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Clientes,Texto,UsuarioId,Descripcion_Hecho")] Dato dato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", dato.UsuarioId);
            return View(dato);
        }

        // GET: Dato/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dato dato = db.Datos.Find(id);
            if (dato == null)
            {
                return HttpNotFound();
            }
            return View(dato);
        }

        // POST: Dato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dato dato = db.Datos.Find(id);
            db.Datos.Remove(dato);
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
