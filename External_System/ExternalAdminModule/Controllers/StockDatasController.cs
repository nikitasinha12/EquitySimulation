using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExternalAdminModule;

namespace ExternalAdminModule.Controllers
{
    public class StockDatasController : Controller
    {
        private External_DatabaseEntities db = new External_DatabaseEntities();

        // GET: StockDatas
        public ActionResult Index()
        {
            return View(db.StockDatas.ToList());
        }

        // GET: StockDatas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockData stockData = db.StockDatas.Find(id);
            if (stockData == null)
            {
                return HttpNotFound();
            }
            return View(stockData);
        }

        // GET: StockDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Symbol,Name,QuantityAvailable,MarketPrice")] StockData stockData)
        {
            if (ModelState.IsValid)
            {
                db.StockDatas.Add(stockData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockData);
        }

        // GET: StockDatas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockData stockData = db.StockDatas.Find(id);
            if (stockData == null)
            {
                return HttpNotFound();
            }
            return View(stockData);
        }

        // POST: StockDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Symbol,Name,QuantityAvailable,MarketPrice")] StockData stockData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockData);
        }

        // GET: StockDatas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockData stockData = db.StockDatas.Find(id);
            if (stockData == null)
            {
                return HttpNotFound();
            }
            return View(stockData);
        }

        // POST: StockDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StockData stockData = db.StockDatas.Find(id);
            db.StockDatas.Remove(stockData);
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
