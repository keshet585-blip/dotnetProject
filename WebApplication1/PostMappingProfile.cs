using AutoMapper;
using Clean.API.Models;
using Clean.CORE.Entities;

namespace Clean.API
{
    public class PostMappingProfile:Profile
    {
        public PostMappingProfile()
        {
            CreateMap<EmployeePost, Employee>().ReverseMap();
            CreateMap<ProjectAssignmentPost, ProjectAssignment>().ReverseMap();
            CreateMap<ProjectPost, Project>().ReverseMap();
        }
    }
}
