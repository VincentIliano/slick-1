﻿using Slick.Models.Contracts;
using Slick.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slick.Api.Dtos
{
    public class ConsultantDetailsDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string WorkEmail { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public IList<string> Specialisations { get; set; }
        public IList<ContractDto> Contracts { get; set; }
        public ContractDto CurrentContract
        {
            get
            {
                if (this.Contracts != null)
                {
                    var query = from c in this.Contracts
                                orderby c?.StartDate descending
                                select c;

                    return query.FirstOrDefault();

                }
                else
                {
                    return null;
                }

            }
        }
    }
}
