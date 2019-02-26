using DataLayer;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class StudentService
    {
        static StudentRepository repository;
        static StudentService()
        {
            repository = new StudentRepository();
        }
        public static Student Insert(Student obj)
        {
            return repository.Insert(obj);
        }
        public static List<Student> GetAll()
        {
            return repository.GetAll();
        }
        public static void Update(Student obj)
        {
            repository.Update(obj);
        }
        public static void Delete(int Id)
        {
            repository.Delete(Id);
        }
    }
}
