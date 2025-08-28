using Microsoft.AspNetCore.Mvc;
using TodoApi.Dtos;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly ITodoRepository _repo;

    public TodoController(ITodoRepository repo)
    {
        _repo = repo;
    }

    // GET /api/todo
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<TodoReadDto>>>> GetAll()
    {
        try
        {
            var todos = await _repo.GetAllAsync();
            var result = todos.Select(t => new TodoReadDto
            {
                Id = t.Id,
                Title = t.Title,
                IsDone = t.IsDone,
            });

            return Ok(ApiResponse<IEnumerable<TodoReadDto>>.SuccessResponse(result, "Todos retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<TodoReadDto>>.ErrorResponse("Internal server error", ex.Message));
        }
    }

    // GET /api/todo/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<TodoReadDto>>> GetById(int id)
    {
        try
        {
            var todo = await _repo.GetByIdAsync(id);
            if (todo == null)
                return NotFound(ApiResponse<TodoReadDto>.ErrorResponse("Todo not found"));

            var result = new TodoReadDto 
            { 
                Id = todo.Id, 
                Title = todo.Title, 
                IsDone = todo.IsDone,
              
            };
            
            return Ok(ApiResponse<TodoReadDto>.SuccessResponse(result, "Todo retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<TodoReadDto>.ErrorResponse("Internal server error", ex.Message));
        }
    }

    // POST /api/todo
    [HttpPost]
    public async Task<ActionResult<ApiResponse<TodoReadDto>>> Create(TodoCreateDto dto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                return BadRequest(ApiResponse<TodoReadDto>.ErrorResponse("Title is required"));

            var todo = new Todo { Title = dto.Title };
            await _repo.AddAsync(todo);
            await _repo.SaveChangesAsync();

            var result = new TodoReadDto 
            { 
                Id = todo.Id, 
                Title = todo.Title, 
                IsDone = todo.IsDone,
            };

            return CreatedAtAction(nameof(GetById), new { id = todo.Id },
                ApiResponse<TodoReadDto>.SuccessResponse(result, "Todo created successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<TodoReadDto>.ErrorResponse("Internal server error", ex.Message));
        }
    }

    // PUT /api/todo/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<TodoReadDto>>> Update(int id, TodoUpdateDto dto)
    {
        try
        {
            var todo = await _repo.GetByIdAsync(id);
            if (todo == null)
                return NotFound(ApiResponse<TodoReadDto>.ErrorResponse("Todo not found"));

            todo.Title = dto.Title;
            todo.IsDone = dto.IsDone;
            

            await _repo.UpdateAsync(todo);
            await _repo.SaveChangesAsync();

            var result = new TodoReadDto 
            { 
                Id = todo.Id, 
                Title = todo.Title, 
                IsDone = todo.IsDone,
        
            };

            return Ok(ApiResponse<TodoReadDto>.SuccessResponse(result, "Todo updated successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<TodoReadDto>.ErrorResponse("Internal server error", ex.Message));
        }
    }

    // DELETE /api/todo/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
    {
        try
        {
            var todo = await _repo.GetByIdAsync(id);
            if (todo == null)
                return NotFound(ApiResponse<object>.ErrorResponse("Todo not found"));

            await _repo.DeleteAsync(todo);
            await _repo.SaveChangesAsync();

            return Ok(ApiResponse<object>.SuccessResponse(null, "Todo deleted successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse("Internal server error", ex.Message));
        }
    }
}