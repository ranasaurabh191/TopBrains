using StudentManagmentSystem.Data;
using StudentManagmentSystem.Models;
using StudentManagmentSystem.Repositories;

namespace StudentManagmentSystem.UnitOfWork
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly StudentDbContext _context;

        public IGenericRepository<Student> Students { get; }

        public IGenericRepository<Department> Departments { get; }

        public IGenericRepository<Course> Courses { get; }

        public UnitOfWorkService(StudentDbContext context)
        {
            _context = context;

            Students = new GenericRepository<Student>(context);
            Departments = new GenericRepository<Department>(context);
            Courses = new GenericRepository<Course>(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}