using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;

using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class MarcaService : IMarcaService
    {
        IMarcaRepository repository;
        public MarcaService(IMarcaRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public IList<MarcaDTO> GetAll()
        {
            return Builders.GenericBuilder.builderListEntityDTO<MarcaDTO, TMarca>(repository.Items);
        }
        public void Insert(MarcaDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<TMarca, MarcaDTO>(entityDTO);
            repository.Save(entity);
        }
        public void Update(MarcaDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<TMarca, MarcaDTO>(entityDTO);
            repository.Save(entity);
        }
    }
}
