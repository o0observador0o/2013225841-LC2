using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CajeroAutomatico.Entities;
using CajeroAutomatico.Persistance;

namespace CajeroAutomatico.MVC.Controllers
{
    public class TecladoesController : Controller
    {
        private CajeroDBContext db = new CajeroDBContext();

        // GET: Tecladoes
        public ActionResult Index()
        {
            var teclado = db.Teclado.Include(t => t.ATM);
            return View(teclado.ToList());
        }

        // GET: Tecladoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = db.Teclado.Find(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            return View(teclado);
        }

        // GET: Tecladoes/Create
        public ActionResult Create()
        {
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion");
            return View();
        }

        // POST: Tecladoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTeclado,MarcaTeclado,idATM")] Teclado teclado)
        {
            if (ModelState.IsValid)
            {
                db.Teclado.Add(teclado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", teclado.idATM);
            return View(teclado);
        }

        // GET: Tecladoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = db.Teclado.Find(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", teclado.idATM);
            return View(teclado);
        }

        // POST: Tecladoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTeclado,MarcaTeclado,idATM")] Teclado teclado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teclado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idATM = new SelectList(db.ATM, "idATM", "Direccion", teclado.idATM);
            return View(teclado);
        }

        // GET: Tecladoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teclado teclado = db.Teclado.Find(id);
            if (teclado == null)
            {
                return HttpNotFound();
            }
            return View(teclado);
        }

        // POST: Tecladoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teclado teclado = db.Teclado.Find(id);
            db.Teclado.Remove(teclado);
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
