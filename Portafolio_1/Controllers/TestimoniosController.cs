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
    public class TestimoniosController : Controller
    {
        private portafolioEntities1 db = new portafolioEntities1();

        // GET: Testimonios
        public ActionResult Index()
        {
            var testimonios = db.Testimonios.Include(t => t.AspNetUser);
            return View(testimonios.ToList());
        }

        // GET: Testimonios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonio testimonio = db.Testimonios.Find(id);
            if (testimonio == null)
            {
                return HttpNotFound();
            }
            return View(testimonio);
        }

        // GET: Testimonios/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Testimonios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UsuarioId,IP,Nombre,Comentario,Fecha")] Testimonio testimonio)
        {
            if (ModelState.IsValid)
            {
                db.Testimonios.Add(testimonio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", testimonio.UsuarioId);
            return View(testimonio);
        }

        // GET: Testimonios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonio testimonio = db.Testimonios.Find(id);
            if (testimonio == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", testimonio.UsuarioId);
            return View(testimonio);
        }

        // POST: Testimonios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UsuarioId,IP,Nombre,Comentario,Fecha")] Testimonio testimonio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testimonio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.AspNetUsers, "Id", "Email", testimonio.UsuarioId);
            return View(testimonio);
        }

        // GET: Testimonios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonio testimonio = db.Testimonios.Find(id);
            if (testimonio == null)
            {
                return HttpNotFound();
            }
            return View(testimonio);
        }

        // POST: Testimonios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Testimonio testimonio = db.Testimonios.Find(id);
            db.Testimonios.Remove(testimonio);
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
