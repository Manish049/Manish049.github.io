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
    public class UserController : Controller
    {
        private FFGSPL_dbEntities db = new FFGSPL_dbEntities();

        // GET: User_tbl
        public async Task<ActionResult> Index()
        {
            return View(await db.User_tbl.ToListAsync());
        }

        // GET: User_tbl/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_tbl user_tbl = await db.User_tbl.FindAsync(id);
            if (user_tbl == null)
            {
                return HttpNotFound();
            }
            return View(user_tbl);
        }

        // GET: User_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ur_firstname,ur_lastname,ur_email,ur_mobile,ur_entity,ur_password,ur_createdby,ur_createdat,ur_updateby,ur_updatedat,ur_isdeleted,ur_role,ur_desg")] User_tbl user_tbl)
        {
            if (ModelState.IsValid)
            {
                db.User_tbl.Add(user_tbl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user_tbl);
        }

        // GET: User_tbl/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_tbl user_tbl = await db.User_tbl.FindAsync(id);
            if (user_tbl == null)
            {
                return HttpNotFound();
            }
            return View(user_tbl);
        }

        // POST: User_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ur_firstname,ur_lastname,ur_email,ur_mobile,ur_entity,ur_password,ur_createdby,ur_createdat,ur_updateby,ur_updatedat,ur_isdeleted,ur_role,ur_desg")] User_tbl user_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_tbl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user_tbl);
        }

        // GET: User_tbl/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_tbl user_tbl = await db.User_tbl.FindAsync(id);
            if (user_tbl == null)
            {
                return HttpNotFound();
            }
            return View(user_tbl);
        }

        // POST: User_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User_tbl user_tbl = await db.User_tbl.FindAsync(id);
            db.User_tbl.Remove(user_tbl);
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
