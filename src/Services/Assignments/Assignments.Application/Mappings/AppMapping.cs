using Assignments.Application.Assignments.Dtos;
using Assignments.Domain.Assignments;
using AutoMapper;

namespace Assignments.Application.Mappings;

public class AppMapping : Profile
{
    public AppMapping()
    {
        CreateMap<Assignment, AssignmentDto>().ReverseMap();
        CreateMap<AssignmentStatus, AssignmentStatusDto>().ReverseMap();
    }
}