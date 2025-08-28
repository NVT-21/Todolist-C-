using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
        return await _context.Todos.AsNoTracking().ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public async Task<Todo> AddAsync(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task UpdateAsync(Todo todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
    }

    public async Task DeleteAsync(Todo todo)
    {
        _context.Todos.Remove(todo);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
