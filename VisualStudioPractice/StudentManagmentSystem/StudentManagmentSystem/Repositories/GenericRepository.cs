using System.Linq.Expressions;
using StudentManagmentSystem.Data;
namespace StudentManagmentSystem.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly StudentDbContext _context;

    public GenericRepository(StudentDbContext context)
    {
        _context = context;
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Insert(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(int id)
    {
        var entity = _context.Set<T>().Find(id);

        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
        }
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate).ToList();
    }
}