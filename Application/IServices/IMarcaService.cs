using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IMarcaService
    {
        void Insert(MarcaDTO entityDTO);
        IList<MarcaDTO> GetAll();
        void Update(MarcaDTO entityDTO);
        void Delete(Guid entityId);
    }
}
