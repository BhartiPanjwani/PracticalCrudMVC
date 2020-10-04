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
    public class ProductsController : Controller
    {
        private CrudContext db = new CrudContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Attribute).Include(p => p.AttributeValues).Include(p => p.Category).ToList();
            return View(products.ToList());
        }

        // GET: Products/Details/5`
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            Product model = new Product();
            foreach (var category in db.Categories)
            {
                model.CategoryList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            return View(model);

        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {

            foreach (var category in db.Categories)
            {
                product.CategoryList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }

            if (product.CategoryId > 0)
            {
                product.AttributeList = BindAttributeList(product.CategoryId);
                if (product.AttributeId > 0)
                {
                    product.AttributeValuesList = BindAttributeValueList(product.AttributeId);
                }
            }

            if (ModelState.IsValid)
            {
                if (product.CategoryId > 0 && product.AttributeId > 0 && product.AttributeValuesId > 0)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }


            return View(product);

        }

        #region Bind Lists
        private List<SelectListItem> BindAttributeValueList(int attributeId)
        {
            List<SelectListItem> AttributeValueList = new List<SelectListItem>();
            var attributeValues = db.AttributeValues.Where(x => x.AttributeId == attributeId).ToList();
            foreach (var attributeValue in attributeValues)
            {
                AttributeValueList.Add(new SelectListItem { Text = attributeValue.Name, Value = attributeValue.Id.ToString() });
            }
            return AttributeValueList;
        }

        private List<SelectListItem> BindAttributeList(int categoryId)
        {
            List<SelectListItem> AttributeList = new List<SelectListItem>();
            var attributes = db.Attributes.Where(x => x.CategoryId == categoryId).ToList();
            foreach (var attribute in attributes)
            {
                AttributeList.Add(new SelectListItem { Text = attribute.Name, Value = attribute.Id.ToString() });
            }
            return AttributeList;
        }

        #endregion
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            foreach (var category in db.Categories)
            {
                product.CategoryList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            if (product.CategoryId > 0)
            {
                product.AttributeList = BindAttributeList(product.CategoryId);
                if (product.AttributeId > 0)
                {
                    product.AttributeValuesList = BindAttributeValueList(product.AttributeId);
                }
            }
            return View(product);
        }

        // POST: Products/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            foreach (var category in db.Categories)
            {
                product.CategoryList.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString() });
            }
            if (product.CategoryId > 0)
            {
                product.AttributeList = BindAttributeList(product.CategoryId);
                if (product.AttributeId > 0 && product.AttributeList.Select(c=>c.Value).Contains(product.AttributeId.ToString()))
                {
                    product.AttributeValuesList = BindAttributeValueList(product.AttributeId);
                }
            }
            if (ModelState.IsValid)
            {
                if (product.CategoryId > 0 && product.AttributeId > 0 && product.AttributeValuesId > 0)
                {
                    if (product.AttributeValuesList.Select(x=>x.Value).Contains(product.AttributeValuesId.ToString()))
                    {
                        db.Entry(product).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
