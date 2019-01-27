using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApiAutos.Model.Repositories
{
    public class EFAutoRepository : IAutoRepository
    {
        public IQueryable<TAuto> Items => context.TAuto;
        private ExWebApiAutosDbContext context;
        public EFAutoRepository(ExWebApiAutosDbContext ctx)
        {
            context = ctx;
        }
        public void Save(TAuto auto)
        {
            if (auto.AutoId == Guid.Empty)
            {
                auto.AutoId = Guid.NewGuid();
                context.TAuto.Add(auto);
            }
            else
            {
                TAuto dbEntry = context.TAuto
                .FirstOrDefault(p => p.AutoId == auto.AutoId);
                if (dbEntry != null)
                {
                    dbEntry.AutoNroAsientos = auto.AutoNroAsientos;
                    dbEntry.AutoColor = auto.AutoColor;
                    dbEntry.AutoAnioFab = auto.AutoAnioFab;
                    dbEntry.AutoPlaca = auto.AutoPlaca;
                    dbEntry.AutoTransmision = auto.AutoTransmision;
                    dbEntry.AutoVersion = auto.AutoVersion;
                    dbEntry.Marca = auto.Marca;
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
