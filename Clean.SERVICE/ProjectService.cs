using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.CORE.Repositories;
using Clean.CORE.Services;
using System.Collections.Generic;
using AutoMapper;
using Clean.CORE.DTO;

namespace Clean.SERVICE
{
    public class ProjectService:IProjectService
    {
            private readonly IRepositoryManager _repositoryManager;
            private readonly IMapper _mapper;

            public ProjectService(IRepositoryManager repositoryManager, IMapper mapper)
            {
                _repositoryManager = repositoryManager;
                _mapper = mapper;
            }

            public IEnumerable<ProjectDto> GetAll()
            {
                var list = _repositoryManager.Projects.GetAll();
                return _mapper.Map<IEnumerable<ProjectDto>>(list);
            }

            public ProjectDto? GetById(int id)
            {
                var proj = _repositoryManager.Projects.GetById(id);
                return _mapper.Map<ProjectDto>(proj);
            }

            public IEnumerable<ProjectDto> Search(string keyword)
            {
                var list = _repositoryManager.Projects.SearchProject(keyword);
                return _mapper.Map<IEnumerable<ProjectDto>>(list);
            }

            public ProjectDto Add(Project project)
            {
                var newProject = _repositoryManager.Projects.Add(project);
                _repositoryManager.Save();
                return _mapper.Map<ProjectDto>(newProject);
            }

            public ProjectDto? Update(int id, Project updated)
            {
                var proj = _repositoryManager.Projects.Update(id, updated);
                _repositoryManager.Save();
                return _mapper.Map<ProjectDto>(proj);
            }

            public bool Delete(int id)
            {
                bool isDeleted = _repositoryManager.Projects.Delete(id);
                if (isDeleted)
                {
                    _repositoryManager.Save();
                }

                return isDeleted;
            }

        public ProjectWithAssignmentsDto? GetByIdWithAssignments(int id)
        {
            var proj = _repositoryManager.Projects.GetByIdWithAssignments(id);
            return _mapper.Map<ProjectWithAssignmentsDto>(proj);
        }

        public IEnumerable<ProjectWithAssignmentsDto> GetAllWithAssignments()
        {
            var list = _repositoryManager.Projects.GetAllWithAssignments();
            return _mapper.Map<IEnumerable<ProjectWithAssignmentsDto>>(list);
        }

   
    }
    }

