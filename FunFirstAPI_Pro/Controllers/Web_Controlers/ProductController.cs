using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FunFirstAPI_Pro.Models;

namespace FunFirstAPI_Pro.Controllers.Web_Controlers
{
    public class ProductController : Controller
    {
        private FFGSPL_dbEntities db = new FFGSPL_dbEntities();

        // GET: Product
        public async Task<ActionResult> Index()
        {
            return View(await db.Product_tbl.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_tbl product_tbl = await db.Product_tbl.FindAsync(id);
            if (product_tbl == null)
            {
                return HttpNotFound();
            }
            return View(product_tbl);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "pr_id,pr_name,pr_createdby,pr_createdat,pr_updatedby,pr_updatedat,pr_isdeleted")] Product_tbl product_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Product_tbl.Add(product_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product_tbl);
        }

        // GET: Product/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_tbl product_tbl = await db.Product_tbl.FindAsync(id);
            if (product_tbl == null)
            {
                return HttpNotFound();
            }
            return View(product_tbl);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "pr_id,pr_name,pr_createdby,pr_createdat,pr_updatedby,pr_updatedat,pr_isdeleted")] Product_tbl product_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product_tbl);
        }

        // GET: Product/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_tbl product_tbl = await db.Product_tbl.FindAsync(id);
            if (product_tbl == null)
            {
                return HttpNotFound();
            }
            return View(product_tbl);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product_tbl product_tbl = await db.Product_tbl.FindAsync(id);
            db.Product_tbl.Remove(product_tbl);
            await db.SaveChangesAsync();
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
