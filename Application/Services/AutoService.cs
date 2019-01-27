using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class AutoService : IAutoService
    {
        IAutoRepository repository;
        public AutoService(IAutoRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public IList<AutoDTO> GetAll()
        {
            return Builders.GenericBuilder.builderListEntityDTO<AutoDTO, TAuto>(repository.Items);
        }
        public void Insert(AutoDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<TAuto, AutoDTO>(entityDTO);
            repository.Save(entity);
        }
        public void Update(AutoDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<TAuto, AutoDTO>(entityDTO);
            repository.Save(entity);
        }
    }
}
