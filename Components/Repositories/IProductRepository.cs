using ProductDisplaySystem.Models;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<IEnumerable<ProductWithCategory>> GetAllWithCategoryAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}
