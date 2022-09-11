using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagement2.Models;

namespace SchoolManagement2.Controllers
{
    public class EnrollmentsController : Controller
    {
        private StudentEntities2 db = new StudentEntities2();

        // GET: Enrollments
        public async Task<ActionResult> Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Cource).Include(e => e.student).Include(e => e.Lecturer);
            return View(await enrollments.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            ViewBag.CourceId = new SelectList(db.Cources, "CourceId", "title");
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "firstname");
            ViewBag.Lecturer_Id = new SelectList(db.Lecturers, "Lecturer_Id", "firstname");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EnrollmentId,Grade,StudentId,CourceId,Lecturer_Id")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourceId = new SelectList(db.Cources, "CourceId", "title", enrollment.CourceId);
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "firstname", enrollment.StudentId);
            ViewBag.Lecturer_Id = new SelectList(db.Lecturers, "Lecturer_Id", "firstname", enrollment.Lecturer_Id);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourceId = new SelectList(db.Cources, "CourceId", "title", enrollment.CourceId);
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "firstname", enrollment.StudentId);
            ViewBag.Lecturer_Id = new SelectList(db.Lecturers, "Lecturer_Id", "firstname", enrollment.Lecturer_Id);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EnrollmentId,Grade,StudentId,CourceId,Lecturer_Id")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourceId = new SelectList(db.Cources, "CourceId", "title", enrollment.CourceId);
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "firstname", enrollment.StudentId);
            ViewBag.Lecturer_Id = new SelectList(db.Lecturers, "Lecturer_Id", "firstname", enrollment.Lecturer_Id);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Enrollment enrollment = await db.Enrollments.FindAsync(id);
            db.Enrollments.Remove(enrollment);
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
