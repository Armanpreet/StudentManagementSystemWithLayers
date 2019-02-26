using DataLayer;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class CourseService
    {
        static CourseRepository repository;
        static CourseService()
        {
            repository = new CourseRepository();
        }
        public static Cours Insert(Cours obj)
        {
            return repository.Insert(obj);
        }
        public static List<Cours> GetAll()
        {
            return repository.GetAll();
        }
        public static void Update(Cours obj)
        {
            repository.Update(obj);
        }
        public static void Delete(int Id)
        {
            repository.Delete(Id);
        }
    }
}
