using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group8Project.Models;

namespace Group8Project.Controllers
{
    public class CandidatePoliciesController : Controller
    {
        private DB_128040_group8Entities db = new DB_128040_group8Entities();

        // GET: CandidatePolicies
        public ActionResult Index()
        {
            var candidatePolicies = db.CandidatePolicies.Include(c => c.CandidateTable).Include(c => c.PolicyyTable);
            return View(candidatePolicies.ToList());
        }

        // GET: CandidatePolicies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidatePolicy candidatePolicy = db.CandidatePolicies.Find(id);
            if (candidatePolicy == null)
            {
                return HttpNotFound();
            }
            return View(candidatePolicy);
        }

        // GET: CandidatePolicies/Create
        public ActionResult Create()
        {
            ViewBag.CandidateID = new SelectList(db.CandidateTables, "CandidateID", "CandidateName");
            ViewBag.PolicyID = new SelectList(db.PolicyyTables, "PolicyID", "PolicyName");
            return View();
        }

        // POST: CandidatePolicies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidatePolicyID,PolicyID,CandidateID,PolicyDescription")] CandidatePolicy candidatePolicy)
        {
            if (ModelState.IsValid)
            {
                db.CandidatePolicies.Add(candidatePolicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CandidateID = new SelectList(db.CandidateTables, "CandidateID", "CandidateName", candidatePolicy.CandidateID);
            ViewBag.PolicyID = new SelectList(db.PolicyyTables, "PolicyID", "PolicyName", candidatePolicy.PolicyID);
            return View(candidatePolicy);
        }

        // GET: CandidatePolicies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidatePolicy candidatePolicy = db.CandidatePolicies.Find(id);
            if (candidatePolicy == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateID = new SelectList(db.CandidateTables, "CandidateID", "CandidateName", candidatePolicy.CandidateID);
            ViewBag.PolicyID = new SelectList(db.PolicyyTables, "PolicyID", "PolicyName", candidatePolicy.PolicyID);
            return View(candidatePolicy);
        }

        // POST: CandidatePolicies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidatePolicyID,PolicyID,CandidateID,PolicyDescription")] CandidatePolicy candidatePolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidatePolicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateID = new SelectList(db.CandidateTables, "CandidateID", "CandidateName", candidatePolicy.CandidateID);
            ViewBag.PolicyID = new SelectList(db.PolicyyTables, "PolicyID", "PolicyName", candidatePolicy.PolicyID);
            return View(candidatePolicy);
        }

        // GET: CandidatePolicies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidatePolicy candidatePolicy = db.CandidatePolicies.Find(id);
            if (candidatePolicy == null)
            {
                return HttpNotFound();
            }
            return View(candidatePolicy);
        }

        // POST: CandidatePolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CandidatePolicy candidatePolicy = db.CandidatePolicies.Find(id);
            db.CandidatePolicies.Remove(candidatePolicy);
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
