using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class TeacherRepository
    {
        public Teacher Insert(Teacher obj)
        {
            using (StudentMgtSystemEntities db = new StudentMgtSystemEntities())
            {
                db.Teachers.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }
        public List<Teacher> GetAll()
        {
            using (StudentMgtSystemEntities db = new StudentMgtSystemEntities())
            {
                return db.Teachers.ToList();
            }
        }
        public void Update(Teacher obj)
        {
            StudentMgtSystemEntities db = new StudentMgtSystemEntities();
            Teacher teacher = db.Teachers.Single(u => u.Id == obj.Id);
            teacher.TeacherName = obj.TeacherName;
            teacher.Qualification = obj.Qualification;
            //cours.CourseDuration = obj.CourseDuration;
            //cours.teacherId = obj.teacherId;
            db.Teachers.Attach(teacher);
            db.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int Id)
        {
            StudentMgtSystemEntities db = new StudentMgtSystemEntities();
            Teacher teacher = db.Teachers.Single(u => u.Id == Id);
            db.Teachers.Attach(teacher);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
        }

    }
}
