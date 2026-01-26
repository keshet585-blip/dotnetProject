using AutoMapper;
using Clean.CORE.DTO;
using Clean.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.CORE
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<DTO.EmployeeDto, Employee>().ReverseMap();
            CreateMap<DTO.ProjectDto, Project>().ReverseMap();
            CreateMap<DTO.ProjectAssignmentDto, ProjectAssignment>().ReverseMap();
            CreateMap<DTO.EmployeeWithAssignmentsDto, Employee>().ReverseMap();
            CreateMap<DTO.ProjectWithAssignmentsDto, Project>().ReverseMap();
        }
    }
}
