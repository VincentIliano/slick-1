using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slick.Models.Contracts;
using Slick.Repositories;

namespace Slick.Services.Contracts
{
    public class ContractService : IContractService
    {
        private readonly IEntityRepository<Contract> contractRepo;

        public ContractService(IEntityRepository<Contract> contractRepo)
        {
            this.contractRepo = contractRepo;
        }

        public Contract Create(Contract c)
        {
            return contractRepo.Create(c);
        }

        public void Delete(Contract c)
        {
            
        }

        public IEnumerable<Contract> GetActiveContracts()
        {
            return null;
        }

        public IEnumerable<Contract> GetContractsForConsultant(Guid consultantId) {
            return this.contractRepo.FindBy(c => c.ConsultantId == consultantId).ToList();
        }

        public IEnumerable<Contract> GetAll()
        {
            return contractRepo.GetAllIncluding(c => c.ContractType).ToList();
        }

        public Contract GetById(Guid id)
        {
            return contractRepo.GetById(id);
        }

        public void Update(Contract c)
        {
            contractRepo.Update(c);
        }
    }
}
