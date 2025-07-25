using Dapper;
using System.Data;

public class CategoryRepository : ICategoryRepository
{
    private readonly IDbConnection _db;

    public CategoryRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        var sql = "SELECT * FROM Categories";
        var categories = await _db.QueryAsync<Category>(sql);
        return categories.AsList();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM Categories WHERE Id = @Id";
        return await _db.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id });
    }

    public async Task AddAsync(Category category)
    {
        var sql = "INSERT INTO Categories (Name) VALUES (@Name)";
        await _db.ExecuteAsync(sql, category);
    }

    public async Task UpdateAsync(Category category)
    {
        var sql = "UPDATE Categories SET Name = @Name WHERE Id = @Id";
        await _db.ExecuteAsync(sql, category);
    }

    public async Task DeleteAsync(int id)
    {
        var sql = "DELETE FROM Categories WHERE Id = @Id";
        await _db.ExecuteAsync(sql, new { Id = id });
    }
}
