using TodoApi.Models;

namespace TodoApi.Interfaces;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetAllAsync();
    Task<Todo?> GetByIdAsync(int id);
    Task<Todo> AddAsync(Todo todo);
    Task UpdateAsync(Todo todo);
    Task DeleteAsync(Todo todo);
    Task<bool> SaveChangesAsync();
}
