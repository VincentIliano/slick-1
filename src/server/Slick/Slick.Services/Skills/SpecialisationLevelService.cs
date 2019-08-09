using System;
using System.Collections.Generic;
using System.Text;
using Slick.Models.Skills;
using Slick.Repositories.Skills;

namespace Slick.Services.Skills
{
    public class SpecialisationLevelService : ISpecialisationLevelService
    {
        private readonly ISpecialisationLevelRepository repo;

        public SpecialisationLevelService(ISpecialisationLevelRepository repo)
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
            return repo.GetAll();
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
