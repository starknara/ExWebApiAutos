﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IAutoRepository : IRepository<TAuto>
    {
        //IQueryable<TMarca> FilterMarcas(int pageSize, int page);

        //IQueryable<TMarca> Marcas { get; }

        //void SaveMarca(TMarca marca);

        //void DeleteMarca(Guid MarcaID);
    }
}
