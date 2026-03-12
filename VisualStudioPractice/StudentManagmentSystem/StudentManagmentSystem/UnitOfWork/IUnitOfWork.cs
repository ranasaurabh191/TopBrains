using StudentManagmentSystem.Models;
using StudentManagmentSystem.Repositories;

namespace StudentManagmentSystem.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> Students { get; }

        IGenericRepository<Department> Departments { get; }

        IGenericRepository<Course> Courses { get; }

        void Save();
    }
}