using System;
using System.Collections.Generic;
using System.Text;
using Slick.Models.Skills;
using Slick.Repositories;
using Slick.Repositories.Skills;
using System.Linq;

namespace Slick.Services.Skills
{
    public class SpecialisationLevelService : ISpecialisationLevelService
    {
        private readonly IEntityRepository<SpecialisationLevel> repo;

        public SpecialisationLevelService(IEntityRepository<SpecialisationLevel> repo)
        {
            this.repo = repo;
        }

        public SpecialisationLevel Create(SpecialisationLevel level)
        {
            return repo.Create(level);
        }

        public void Delete(SpecialisationLevel level)
        {
            level.IsDeleted = true;
            repo.Update(level);
        }

        public IEnumerable<SpecialisationLevel> GetAll()
        {
            return repo.GetAll().Where(sl => sl.IsDeleted == false).ToList();
        }

        public SpecialisationLevel GetById(Guid id)
        {
            return repo.GetById(id);
        }

        public void Update(SpecialisationLevel level)
        {
            repo.Update(level);
        }
    }
}
