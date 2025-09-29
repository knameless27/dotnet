using AutoMapper;
using TaskApi.DTOs;
using TaskApi.Models;

namespace TaskApi.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TaskItem, TaskReadDto>();
        CreateMap<TaskCreateDto, TaskItem>();
    }
}
