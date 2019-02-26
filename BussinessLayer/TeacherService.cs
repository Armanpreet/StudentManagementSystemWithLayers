using DataLayer;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class TeacherService
    {
        static TeacherRepository repository;
        static TeacherService()
        {
            repository = new TeacherRepository();
        }
        public static Teacher Insert(Teacher obj)
        {
            return repository.Insert(obj);
        }
        public static List<Teacher> GetAll()
        {
            return repository.GetAll();
        }
        public static void Update(Teacher obj)
        {
            repository.Update(obj);
        }
        public static void Delete(int Id)
        {
            repository.Delete(Id);
        }
    }
}
