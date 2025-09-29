using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.DTOs;
using TaskApi.Models;

namespace TaskApi.Services;

public class TaskService : ITaskService
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public TaskService(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskReadDto>> GetAllAsync()
    {
        var tasks = await _db.Tasks.OrderByDescending(t => t.CreatedAt).ToListAsync();
        return _mapper.Map<IEnumerable<TaskReadDto>>(tasks);
    }

    public async Task<TaskReadDto> CreateAsync(TaskCreateDto dto)
    {
        var entity = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description
        };
        _db.Tasks.Add(entity);
        await _db.SaveChangesAsync();
        return _mapper.Map<TaskReadDto>(entity);
    }

    public async Task<bool> CompleteAsync(Guid id)
    {
        var task = await _db.Tasks.FindAsync(id);
        if (task == null) return false;
        task.IsCompleted = true;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<TaskUpdateDto> UpdateAsync(Guid id, TaskUpdateDto dto)
    {
        var task = await _db.Tasks.FindAsync(id);
        if (task == null) return _mapper.Map<TaskUpdateDto>(new TaskItem{});
        var entity = new TaskItem
        {
            Id = task.Id,
            Title = dto.Title ?? task.Title,
            Description = dto.Description ?? task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt,
        };
        _db.Tasks.Update(entity);
        await _db.SaveChangesAsync();
        return _mapper.Map<TaskUpdateDto>(entity);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var task = await _db.Tasks.FindAsync(id);
        if (task == null) return false;
        _db.Tasks.Remove(task);
        await _db.SaveChangesAsync();
        return true;
    }
}
