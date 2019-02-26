using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CourseRepository
    {
        public Cours Insert(Cours obj)
        {
            using (StudentMgtSystemEntities db = new StudentMgtSystemEntities())
            {
                db.Courses.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }
        public List<Cours> GetAll()
        {
            using (StudentMgtSystemEntities db = new StudentMgtSystemEntities())
            {
                return db.Courses.ToList();
            }
        }
        public void Update(Cours obj)
        {
            StudentMgtSystemEntities db = new StudentMgtSystemEntities();
            Cours cours = db.Courses.Single(u => u.Id == obj.Id);
            cours.CourseName = obj.CourseName;
            cours.CourseFees = obj.CourseFees;
            cours.CourseDuration = obj.CourseDuration;
            //cours.teacherId = obj.teacherId;
            db.Courses.Attach(cours);
            db.Entry(cours).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int Id)
        {
            StudentMgtSystemEntities db = new StudentMgtSystemEntities();
            Cours cours = db.Courses.Single(u => u.Id == Id);
            db.Courses.Attach(cours);
            db.Courses.Remove(cours);
            db.SaveChanges();
        }

    }
}
