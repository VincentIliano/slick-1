using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slick.Models.People;
using Slick.Repositories;
using System.Linq.Dynamic.Core;

namespace Slick.Services.People
{
    public class ConsultantsService : IConsultantsService
    {
        private readonly IEntityRepository<Consultant> consultantsRepo;

        public ConsultantsService(IEntityRepository<Consultant> consultantsRepo)
        {
            this.consultantsRepo = consultantsRepo;
        }
        public Consultant Create(Consultant c)
        {
            return this.consultantsRepo.Create(c);
        }

        public void Delete(Consultant c)
        {
            c.IsDeleted = true;
            this.consultantsRepo.Update(c);
        }

        public IEnumerable<Consultant> GetAll()
        {
            return this.consultantsRepo.GetAll().Where(c => c.IsDeleted == false);
        }

        public IEnumerable<Consultant> GetAll(string sort) {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";

            return this.consultantsRepo.GetAll().OrderBy(sort).ToList();
        }

        public IEnumerable<Consultant> FindByFirstname(string firstname) {
            return this.consultantsRepo.FindBy(c => c.Firstname == firstname).ToList();
        }

        public IEnumerable<Consultant> FindByFirstname(string firstname, string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";
            return this.consultantsRepo.FindBy(c => c.Firstname == firstname).OrderBy(sort).ToList();
        }

        public IEnumerable<Consultant> FindByLastname(string lastname)
        {
            return this.consultantsRepo.FindBy(c => c.Lastname == lastname).ToList();
        }

        public IEnumerable<Consultant> FindByLastname(string lastname, string sort) {
            if (string.IsNullOrEmpty(sort)) sort = "lastname";
            return this.consultantsRepo.FindBy(c => c.Lastname == lastname).OrderBy(sort).ToList();
        }

        public Consultant GetById(Guid id)
        {
            return this.consultantsRepo.GetById(id);
        }

        public Consultant GetByIdWithDetails(Guid id) {
            return this.consultantsRepo.GetById(id, c => c.Address);
        }

        public void Update(Consultant c)
        {
            this.consultantsRepo.Update(c);
        }
    }
}
