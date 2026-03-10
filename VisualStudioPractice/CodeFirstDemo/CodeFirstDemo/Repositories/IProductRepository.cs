using CodeFirstDemo.Models;

namespace CodeFirstDemo.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product?> GetById(int id);

        Task Add(Product product);

        Task Update(Product product);

        Task Delete(int id);
    }
}