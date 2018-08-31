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
    public class BrandController : Controller
    {
        private FFGSPL_dbEntities db = new FFGSPL_dbEntities();

        // GET: Brand
        public async Task<ActionResult> Index()
        {
            return View(await db.Brand_tbl.ToListAsync());
        }

        // GET: Brand/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand_tbl brand_tbl = await db.Brand_tbl.FindAsync(id);
            if (brand_tbl == null)
            {
                return HttpNotFound();
            }
            return View(brand_tbl);
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "br_id,br_name,br_creaetedby,br_createdat,br_updatedby,br_updatedat,br_isdeleted")] Brand_tbl brand_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Brand_tbl.Add(brand_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(brand_tbl);
        }

        // GET: Brand/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand_tbl brand_tbl = await db.Brand_tbl.FindAsync(id);
            if (brand_tbl == null)
            {
                return HttpNotFound();
            }
            return View(brand_tbl);
        }

        // POST: Brand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "br_id,br_name,br_creaetedby,br_createdat,br_updatedby,br_updatedat,br_isdeleted")] Brand_tbl brand_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(brand_tbl);
        }

        // GET: Brand/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand_tbl brand_tbl = await db.Brand_tbl.FindAsync(id);
            if (brand_tbl == null)
            {
                return HttpNotFound();
            }
            return View(brand_tbl);
        }

        // POST: Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Brand_tbl brand_tbl = await db.Brand_tbl.FindAsync(id);
            db.Brand_tbl.Remove(brand_tbl);
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
