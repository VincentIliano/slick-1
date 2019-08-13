﻿using Slick.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slick.Services.Contracts
{
    public interface IContractService
    {
        IEnumerable<Contract> GetAll();
        IEnumerable<Contract> GetActiveContracts();
        IEnumerable<Contract> GetContractsForConsultant(Guid consultantId);
        Contract GetById(Guid id);
        void Update(Contract c);
        void Delete(Contract c);
        Contract Create(Contract c);
    }
}
