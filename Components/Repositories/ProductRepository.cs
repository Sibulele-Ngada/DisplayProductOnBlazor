using Dapper;
using System.Data;
using ProductDisplaySystem.Models;


    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<ProductWithCategory>> GetAllWithCategoryAsync()
        {
            var sql = @"
                SELECT 
                    p.Name, 
                    p.Price, 
                    c.Name AS CategoryName, 
                    c.Description AS CategoryDescription
                FROM Products p
                INNER JOIN Categories c ON p.CategoryId = c.Id";

            return await _connection.QueryAsync<ProductWithCategory>(sql);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Products";
            var products = await _connection.QueryAsync<Product>(sql);
            return products.AsList();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        }

        
        public async Task AddAsync(Product product)
        {
            var sql = "INSERT INTO Products (Name, Price, CategoryId) VALUES (@Name, @Price, @CategoryId)";
            await _connection.ExecuteAsync(sql, product);
        }

        public async Task UpdateAsync(Product product)
        {
            var sql = "UPDATE Products SET Name = @Name, Price = @Price, CategoryId = @CategoryId WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, product);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
