using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ÄlytaloWEB.Models;

namespace ÄlytaloWEB.Controllers
{
    public class TaloValotController : Controller
    {
        private JohaMeriSQL1Entities db = new JohaMeriSQL1Entities();

        // GET: TaloValot
        public ActionResult Index()
        {
            return View(db.TaloValo.ToList());
        }

        // GET: TaloValot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloValo taloValo = db.TaloValo.Find(id);
            if (taloValo == null)
            {
                return HttpNotFound();
            }
            return View(taloValo);
        }

        // GET: TaloValot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaloValot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Valo_ID,Huone,ValaisinType,Lamppu_ID,ValoTila_ID,ValonMaara,ValoTilaKirjattu")] TaloValo taloValo)
        {
            if (ModelState.IsValid)
            {
                db.TaloValo.Add(taloValo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taloValo);
        }

        // GET: TaloValot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloValo taloValo = db.TaloValo.Find(id);
            if (taloValo == null)
            {
                return HttpNotFound();
            }
            return View(taloValo);
        }

        // POST: TaloValot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Valo_ID,Huone,ValaisinType,Lamppu_ID,ValoTila_ID,ValonMaara,ValoTilaKirjattu")] TaloValo taloValo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taloValo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taloValo);
        }

        // GET: TaloValot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloValo taloValo = db.TaloValo.Find(id);
            if (taloValo == null)
            {
                return HttpNotFound();
            }
            return View(taloValo);
        }

        // POST: TaloValot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaloValo taloValo = db.TaloValo.Find(id);
            db.TaloValo.Remove(taloValo);
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
