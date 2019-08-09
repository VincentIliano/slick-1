using System;
using System.Collections.Generic;
using System.Text;
using Slick.Database;
using Slick.Models.Skills;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Slick.Repositories.Skills
{
    public class SpecialisationLevelRepository : ISpecialisationLevelRepository
    {
        private readonly ApplicationDbContext entitiesContext;

        public SpecialisationLevelRepository(ApplicationDbContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }

        public SpecialisationLevel Create(SpecialisationLevel level)
        {
            entitiesContext.Set<SpecialisationLevel>().Add(level);
            entitiesContext.SaveChanges();
            return level;
        }

        public void Delete(SpecialisationLevel level)
        {
            EntityEntry dbEntity = entitiesContext.Entry<SpecialisationLevel>(level);
            dbEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            entitiesContext.SaveChanges();
        }

        public IEnumerable<SpecialisationLevel> GetAll()
        {
            var items = entitiesContext.Set<SpecialisationLevel>();
            return items.ToList();
        }

        public SpecialisationLevel GetById(Guid id)
        {
            var item = GetAll().Where(s => s.Id == id).SingleOrDefault();
            return item;
        }

        public void Update(SpecialisationLevel level)
        {
            EntityEntry dbEntity = entitiesContext.Entry<SpecialisationLevel>(level);
            dbEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            entitiesContext.SaveChanges();
        }

        
    }
}
