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
    public class TaloSaunatController : Controller
    {
        private JohaMeriSQL1Entities db = new JohaMeriSQL1Entities();

        // GET: TaloSaunat
        public ActionResult Index()
        {
            return View(db.TaloSauna.ToList());
        }

        /*lisätty 7.9.2016*/
        public ActionResult OnOff(int Sauna_ID, bool SaunanTila)
        {
            using (var dp = new JohaMeriSQL1Entities())
            {
                var sauna = dp.TaloSauna.First(c => c.Sauna_ID == Sauna_ID);
               
                sauna.SaunanTila= SaunanTila;
                dp.SaveChanges();
            }

            return new EmptyResult();
        }



        // GET: TaloSaunat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloSauna taloSauna = db.TaloSauna.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }
            return View(taloSauna);
        }

        // GET: TaloSaunat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaloSaunat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sauna_ID,SaunaTavoiteLampotila,SaunaNykyLampotila,SaunanTila,SaunaTilaKirjattu,Saunan_ID,SaunanNimi")] TaloSauna taloSauna)
        {
            if (ModelState.IsValid)
            {
                db.TaloSauna.Add(taloSauna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taloSauna);
        }

        // GET: TaloSaunat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloSauna taloSauna = db.TaloSauna.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }
            return View(taloSauna);
        }

        // POST: TaloSaunat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sauna_ID,SaunaTavoiteLampotila,SaunaNykyLampotila,SaunanTila,SaunaTilaKirjattu,Saunan_ID,SaunanNimi")] TaloSauna taloSauna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taloSauna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taloSauna);
        }

        // GET: TaloSaunat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloSauna taloSauna = db.TaloSauna.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }
            return View(taloSauna);
        }

        // POST: TaloSaunat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaloSauna taloSauna = db.TaloSauna.Find(id);
            db.TaloSauna.Remove(taloSauna);
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
