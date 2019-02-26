using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class StudentRepository
    {
        public Student Insert(Student obj)
        {
            using (StudentMgtSystemEntities db = new StudentMgtSystemEntities())
            {
                db.Students.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }
        public List<Student> GetAll()
        {
            using (StudentMgtSystemEntities db = new StudentMgtSystemEntities())
            {
                return db.Students.ToList();
            }
        }
        public void Update(Student obj)
        {
            StudentMgtSystemEntities db = new StudentMgtSystemEntities();
            Student student = db.Students.Single(u => u.Id == obj.Id);
            student.StdName = obj.StdName;
            student.FatherName = obj.FatherName;
            student.Address = obj.Address;
            student.Mobile = obj.Mobile;
            student.Gender = student.Gender;
            student.CourseId = obj.CourseId;
            student.TeacherId = obj.TeacherId;
            student.Email = obj.Email;
            db.Students.Attach(student);
            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int Id)
        {
            StudentMgtSystemEntities db = new StudentMgtSystemEntities();
            Student student = db.Students.Single(u => u.Id == Id);
            db.Students.Attach(student);
            db.Students.Remove(student);
            db.SaveChanges();
        }

    }
}
