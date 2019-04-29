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
    public class CandidatesController : Controller
    {
        private DB_128040_group8Entities db = new DB_128040_group8Entities();

        // GET: Candidates
        public ActionResult Index()
        {
            return View(db.CandidateTables.ToList());
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateTable candidateTable = db.CandidateTables.Find(id);
            if (candidateTable == null)
            {
                return HttpNotFound();
            }
            return View(candidateTable);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidateID,CandidateName,CandidateParty,CandidateAge,CandidateGender")] CandidateTable candidateTable)
        {
            if (ModelState.IsValid)
            {
                db.CandidateTables.Add(candidateTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidateTable);
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateTable candidateTable = db.CandidateTables.Find(id);
            if (candidateTable == null)
            {
                return HttpNotFound();
            }
            return View(candidateTable);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateID,CandidateName,CandidateParty,CandidateAge,CandidateGender")] CandidateTable candidateTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidateTable);
        }

        // GET: Candidates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateTable candidateTable = db.CandidateTables.Find(id);
            if (candidateTable == null)
            {
                return HttpNotFound();
            }
            return View(candidateTable);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CandidateTable candidateTable = db.CandidateTables.Find(id);
            db.CandidateTables.Remove(candidateTable);
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
