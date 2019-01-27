using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IAutoService
    {
        void Insert(AutoDTO entityDTO);
        IList<AutoDTO> GetAll();
        void Update(AutoDTO entityDTO);
        void Delete(Guid entityId);
    }
}
