using TaskApi.DTOs;

namespace TaskApi.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskReadDto>> GetAllAsync();
    Task<TaskReadDto> CreateAsync(TaskCreateDto dto);
    Task<bool> CompleteAsync(Guid id);
    Task<TaskUpdateDto> UpdateAsync(Guid id, TaskUpdateDto dto);
    Task<bool> DeleteAsync(Guid id);
}
