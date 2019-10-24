using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Product.Data.Context;
using Product.Data.Entities;

namespace ProductWeb.Controllers
{
    public class MaterialsController : Controller
    {
        private ProductDataContext db = new ProductDataContext();

        // GET: Materials
        public ActionResult Index()
        {
            return View(db.Materials.ToList());
        }

        // GET: Materials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: Materials/Create
        public ActionResult Create()
        {
            Material model = new Material();
            model.ExecutivesList = db.Materials;
            return View(model);
        }

        // POST: Materials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterialId,Name,Cost")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Materials.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(material);
        }

        // GET: Materials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            material.ExecutivesList = db.Materials;
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
          
        }
     

       // POST: Materials/Edit/5
       // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
       // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( FormCollection obj)
        {
        
                using (var db1 = new ProductDataContext())
                {
                //var myData = db1.ProductMaterials.Where(x => x.MaterialId == material.MaterialId).ToList();
                //myData.ForEach(m => m.MaterialId = int.Parse(obj["hidden1"]));
                //db.SaveChanges();
                Int32 deleteId = int.Parse(obj["hidden1"]);
                Int32 keepId = int.Parse(obj["hidden2"]);

                    var query = db1.ProductMaterials.Where(p => p.MaterialId == deleteId).ToList();
                    foreach(var post in query)
                    {
                        post.MaterialId =keepId;
                    }
                    db1.SaveChanges();

                var itemToRemove = db.Materials.SingleOrDefault(x => x.MaterialId == deleteId);
               
                if (itemToRemove != null)
                {
                    db.Materials.Remove(itemToRemove);
                    db.SaveChanges();
                   
                }
                return RedirectToAction("Index");
                  
                //material.Name = obj["hidden1"].ToString();
                //db.Entry(material).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
           
        }

        //public ActionResult Edit(FormCollection obj)
        //{

        //    using (var db1 = new ProductDataContext())
        //    {
        //        var myData = db1.ProductMaterials.Where(x => x.MaterialId == int.Parse(obj["hidden1"])).ToList();
        //        myData.ForEach(m => m.MaterialId = int.Parse(obj["hidden1"]));
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        // }
        // GET: Materials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Materials.Find(id);
            db.Materials.Remove(material);
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
