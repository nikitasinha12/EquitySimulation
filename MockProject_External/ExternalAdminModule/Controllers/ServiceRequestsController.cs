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
    public class ServiceRequestsController : Controller
    {
        private External_DatabaseEntities db = new External_DatabaseEntities();

        // GET: ServiceRequests
        public ActionResult Index()
        {
            var serviceRequests = db.ServiceRequests.Include(s => s.Status).Include(s => s.StockData);
            return View(serviceRequests.ToList());
        }

        // GET: ServiceRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequest);
        }

        //// GET: ServiceRequests/Create
        //public ActionResult Create()
        //{
        //    ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName");
        //    ViewBag.Symbol = new SelectList(db.StockDatas, "Symbol", "Name");
        //    return View();
        //}

        //// POST: ServiceRequests/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "RequestID,BlockID,TraderID,Symbol,QtyRequested,QtyAllocated,Type,Side,StatusID,TimeStamp")] ServiceRequest serviceRequest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ServiceRequests.Add(serviceRequest);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName", serviceRequest.StatusID);
        //    ViewBag.Symbol = new SelectList(db.StockDatas, "Symbol", "Name", serviceRequest.Symbol);
        //    return View(serviceRequest);
        //}

        //// GET: ServiceRequests/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
        //    if (serviceRequest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName", serviceRequest.StatusID);
        //    ViewBag.Symbol = new SelectList(db.StockDatas, "Symbol", "Name", serviceRequest.Symbol);
        //    return View(serviceRequest);
        //}

        //// POST: ServiceRequests/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "RequestID,BlockID,TraderID,Symbol,QtyRequested,QtyAllocated,Type,Side,StatusID,TimeStamp")] ServiceRequest serviceRequest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(serviceRequest).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName", serviceRequest.StatusID);
        //    ViewBag.Symbol = new SelectList(db.StockDatas, "Symbol", "Name", serviceRequest.Symbol);
        //    return View(serviceRequest);
        //}

        //// GET: ServiceRequests/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
        //    if (serviceRequest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(serviceRequest);
        //}

        //// POST: ServiceRequests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
        //    db.ServiceRequests.Remove(serviceRequest);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
