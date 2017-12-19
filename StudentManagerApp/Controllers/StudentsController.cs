using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentManagerApp.Models;

namespace StudentManagerApp.Controllers
{
    public class StudentsController : ApiController
    {
        private AppDbContextDataContext db;
        // GET: api/Student
        public IEnumerable<Student> Get()
        {
            using (db = new AppDbContextDataContext())
            {
                return db.Students.ToList();
            }
        }

        // GET: api/Students/5
        public Student Get(int id)
        {
            using (db = new AppDbContextDataContext())
            {
                return db.Students.FirstOrDefault(s => s.Id == id);
            }
        }

        // POST: api/Students
        public void Post([FromBody]Student student)
        {
            using (db = new AppDbContextDataContext())
            {
                db.Students.InsertOnSubmit(student);
                db.SubmitChanges();
            }
        }

        // PUT: api/Students/5
        public void Put(int id, [FromBody]Student student)
        {
            using (db = new AppDbContextDataContext())
            {
                var studentOld = db.Students.FirstOrDefault(s => s.Id == id);
                studentOld.Grade = student.Grade;
                studentOld.Name = student.Name;
                db.SubmitChanges();
            }
        }

        // DELETE: api/Students/5
        public void Delete(int id)
        {
            using (db = new AppDbContextDataContext())
            {
                var student = db.Students.FirstOrDefault(s => s.Id == id);
                db.Students.DeleteOnSubmit(student);
                db.SubmitChanges();
            }
        }
    }
}
