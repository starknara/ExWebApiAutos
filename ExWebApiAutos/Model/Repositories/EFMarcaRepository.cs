using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiAutos.Model.Repositories
{
    public class EFMarcaRepository : IMarcaRepository
    {
        public IQueryable<TMarca> Items => context.TMarca;
        private ExWebApiAutosDbContext context;
        public EFMarcaRepository(ExWebApiAutosDbContext ctx)
        {
            context = ctx;
        }
        public void Save(TMarca marca)
        {
            if (marca.MarcaId == Guid.Empty)
            {
                marca.MarcaId = Guid.NewGuid();
                context.TMarca.Add(marca);
            }
            else
            {
                TMarca dbEntry = context.TMarca
                .FirstOrDefault(p => p.MarcaId == marca.MarcaId);
                if (dbEntry != null)
                {
                    dbEntry.MarcaNombre = marca.MarcaNombre;
                }
            }
            context.SaveChangesAsync();
        }
        public void Delete(Guid MarcaID)
        {
            TMarca dbEntry = context.TMarca
            .FirstOrDefault(p => p.MarcaId == MarcaID);
            if (dbEntry != null)
            {
                context.TMarca.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
