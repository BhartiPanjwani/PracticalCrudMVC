using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudOperationPractical.Models;

namespace CrudOperationPractical.Controllers
{
    public class AttributeValuesController : Controller
    {
        private CrudContext db = new CrudContext();

        // GET: AttributeValues
        public ActionResult Index()
        {
            var attributeValues = db.AttributeValues.Include(a => a.Attribute);
            return View(attributeValues.ToList());
        }

        // GET: AttributeValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttributeValues attributeValues = db.AttributeValues.Find(id);
            if (attributeValues == null)
            {
                return HttpNotFound();
            }
            return View(attributeValues);
        }

        // GET: AttributeValues/Create
        public ActionResult Create()
        {
            ViewBag.AttributeId = new SelectList(db.Attributes, "Id", "Name");
            return View();
        }

        // POST: AttributeValues/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttributeValues attributeValues)
        {
            if (ModelState.IsValid)
            {
                db.AttributeValues.Add(attributeValues);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttributeId = new SelectList(db.Attributes, "Id", "Name", attributeValues.AttributeId);
            return View(attributeValues);
        }

        // GET: AttributeValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttributeValues attributeValues = db.AttributeValues.Find(id);
            if (attributeValues == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttributeId = new SelectList(db.Attributes, "Id", "Name", attributeValues.AttributeId);
            return View(attributeValues);
        }

        // POST: AttributeValues/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AttributeValues attributeValues)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attributeValues).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttributeId = new SelectList(db.Attributes, "Id", "Name", attributeValues.AttributeId);
            return View(attributeValues);
        }

        // GET: AttributeValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttributeValues attributeValues = db.AttributeValues.Find(id);
            if (attributeValues == null)
            {
                return HttpNotFound();
            }
            return View(attributeValues);
        }

        // POST: AttributeValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttributeValues attributeValues = db.AttributeValues.Find(id);
            db.AttributeValues.Remove(attributeValues);
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
