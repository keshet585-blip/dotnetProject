using System.Collections.Generic;
using Clean.DATA.Repositories;
using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.CORE.Services;
using Clean.CORE.Repositories;
using AutoMapper;
using Clean.CORE.DTO;

namespace Clean.SERVICE
{
    public class ProjectAssignmentService:IProjectAssignmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProjectAssignmentService(IRepositoryManager repository, IMapper mapper)
        {
            _repositoryManager = repository;
            _mapper = mapper;
        }

        public IEnumerable<ProjectAssignmentDto> GetAll()
        {
            var list = _repositoryManager.ProjectAssignments.GetAll();
            return _mapper.Map<IEnumerable<ProjectAssignmentDto>>(list);
        }

        public ProjectAssignmentDto? GetById(int id)
        {
            var item = _repositoryManager.ProjectAssignments.GetById(id);
            return _mapper.Map<ProjectAssignmentDto>(item);
        }

        public ProjectAssignmentDto Add(ProjectAssignment assignment)
        {
            var newAssignment = _repositoryManager.ProjectAssignments.Add(assignment);
            _repositoryManager.Save();
            return _mapper.Map<ProjectAssignmentDto>(newAssignment);
        }

        public ProjectAssignmentDto? Update(int id, ProjectAssignment updated)
        {
            var tmp=_repositoryManager.ProjectAssignments.Update(id, updated);
            _repositoryManager.Save();
            return _mapper.Map<ProjectAssignmentDto>(tmp);
        }

        public bool Delete(int id)
        {
            var isDeleted = _repositoryManager.ProjectAssignments.Delete(id);
            if (isDeleted) _repositoryManager.Save();
            return isDeleted;
        }

        public IEnumerable<ProjectAssignmentDto> GetByProject(int projectId)
        {
            var list = _repositoryManager.ProjectAssignments.GetAssignmentsByProject(projectId);
            return _mapper.Map<IEnumerable<ProjectAssignmentDto>>(list);
        }

        public IEnumerable<ProjectAssignmentDto> GetAssignmentsByEmployee(int employeeId)
        {
            var list = _repositoryManager.ProjectAssignments.GetAssignmentsByEmployee(employeeId);
            return _mapper.Map<IEnumerable<ProjectAssignmentDto>>(list);
      }

        public IEnumerable<ProjectAssignmentDto> GetAssignmentsByProject(int projectId)
        {
            var list = _repositoryManager.ProjectAssignments.GetAssignmentsByProject(projectId);
            return _mapper.Map<IEnumerable<ProjectAssignmentDto>>(list);
        }

     
    }
}
