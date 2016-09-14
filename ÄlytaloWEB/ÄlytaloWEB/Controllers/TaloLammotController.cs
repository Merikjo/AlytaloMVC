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
    public class TaloLammotController : Controller
    {
        private JohaMeriSQL1Entities db = new JohaMeriSQL1Entities();

        // GET: TaloLammot
        public ActionResult Index()
        {
            return View(db.TaloLampo.ToList());
        }

        // GET: TaloLammot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloLampo taloLampo = db.TaloLampo.Find(id);
            if (taloLampo == null)
            {
                return HttpNotFound();
            }
            return View(taloLampo);
        }

        // GET: TaloLammot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaloLammot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Huone_ID,Huone,HuoneTavoiteLampo,HuoneNykyLampo,LampoKirjattu")] TaloLampo taloLampo)
        {
            if (ModelState.IsValid)
            {
                db.TaloLampo.Add(taloLampo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taloLampo);
        }

        // GET: TaloLammot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloLampo taloLampo = db.TaloLampo.Find(id);
            if (taloLampo == null)
            {
                return HttpNotFound();
            }
            return View(taloLampo);
        }

        // POST: TaloLammot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Huone_ID,Huone,HuoneTavoiteLampo,HuoneNykyLampo,LampoKirjattu")] TaloLampo taloLampo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taloLampo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taloLampo);
        }

        // GET: TaloLammot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloLampo taloLampo = db.TaloLampo.Find(id);
            if (taloLampo == null)
            {
                return HttpNotFound();
            }
            return View(taloLampo);
        }

        // POST: TaloLammot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaloLampo taloLampo = db.TaloLampo.Find(id);
            db.TaloLampo.Remove(taloLampo);
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
