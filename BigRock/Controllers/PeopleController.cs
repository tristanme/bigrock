﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BigRock.Models;

namespace BigRock.Controllers
{
    public class PeopleController : Controller
    {
        private BigRockConnection db = new BigRockConnection();

        // GET: People
        public ActionResult Index(string searchValue)
        {
            var people = from p in db.Person select p;

            if (!string.IsNullOrEmpty(searchValue))
            {
                string firstName = string.Empty;
                string lastName = string.Empty;

                ParseSearchValue(searchValue, ref firstName, ref lastName);

                people = people.Where(s => s.FirstName.Contains(firstName) || s.LastName.Contains(lastName));
            }

            return View(people);
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {

            return View();

        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,MiddleName,LastName,FamilyCode,SecurityCard,TypeCode,TypeCodeOther")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,FamilyCode,SecurityCard,TypeCode,TypeCodeOther")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Person.Find(id);
            db.Person.Remove(person);
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

        private void ParseSearchValue(string searchValue, ref string firstName, ref string lastName)
        {
            int idx = searchValue.IndexOf(",");

            if (idx > 0)
            {
                lastName = searchValue.Substring(0, idx).Trim();
                firstName = searchValue.Substring(idx, searchValue.Length - 1).Trim();
            }
            else
            {
                idx = searchValue.IndexOf(" ");
                if (idx > 0)
                {
                    firstName = searchValue.Substring(0, idx).Trim();
                    lastName = searchValue.Substring(idx, searchValue.Length - 1).Trim();
                }
                else
                {
                    firstName = searchValue;
                    lastName = searchValue;
                }
            }

        }
    }
}
