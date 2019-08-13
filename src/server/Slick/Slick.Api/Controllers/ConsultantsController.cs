using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slick.Api.Dtos;
using Slick.Models.Contracts;
using Slick.Models.People;
using Slick.Services.Contracts;
using Slick.Services.People;

namespace Slick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantsController : ControllerBase
    {
        private readonly IConsultantsService consultantsService;
        private readonly IContractService contractService;

        public ConsultantsController(IConsultantsService consultantsService, IContractService contractService)
        {
            this.consultantsService = consultantsService;
            this.contractService = contractService;
        }

        [HttpPost]
        public IActionResult Post(Consultant c) {
            this.consultantsService.Create(c);
            if (c.Id == Guid.Empty) {
                return StatusCode(500);
            }

            return Ok(c);
        }

        // [controller]?sort=firstname&filter=firstname&value=kevin
        [HttpGet]
        public IActionResult Get([FromQuery]string sort, [FromQuery] string filter, [FromQuery] string value) {
            IList<ConsultantDto> consultants = new List<ConsultantDto>();
            IEnumerable<Consultant> consultantsFromDb = new List<Consultant>();
            if (!string.IsNullOrEmpty(filter))
            {
                // voor de veiligheid hebben we besloten om niets terug te geven wanneer de value niet ingevuld is
                if (string.IsNullOrEmpty(value)) return BadRequest("Parameterless searches have been disabled.");

                if (filter == "firstname") consultantsFromDb = this.consultantsService.FindByFirstname(value, sort);
                else if (filter == "lastname") consultantsFromDb = this.consultantsService.FindByLastname(value, sort);
            }
            else {
                consultantsFromDb = this.consultantsService.GetAll(sort);
            }
            foreach (var c in consultantsFromDb)
            {
                consultants.Add(new ConsultantDto()
                {
                    Id = c.Id,
                    Url = "http://"+ Request.Host.Value + "/api/consultants/" + c.Id,
                    Firstname = c.Firstname,
                    Lastname = c.Lastname,
                    Email = c.Email,
                    WorkEmail = c.WorkEmail,
                    Telephone = c.Telephone,
                    Street = c.Address?.Street,
                    Number = c.Address?.Number,
                    City = c.Address?.City,
                    Zip = c.Address?.Zip
                });
            }

            return Ok(consultants);
        }

        // [controller]/id
        [HttpGet("{id}")]
        public IActionResult Get(Guid id) {
            var c = consultantsService.GetByIdWithDetails(id);
            if (c == null) return NotFound();

            var consultant = new ConsultantDetailsDto() {
                Firstname = c.Firstname,
                Lastname = c.Lastname,
                Email = c.Email,
                WorkEmail = c.WorkEmail,
                Telephone = c.Telephone,
                Street = c.Address?.Street,
                Number = c.Address?.Number,
                City = c.Address?.City,
                Zip = c.Address?.Zip
            };

            var contractsFromDb = this.contractService.GetContractsForConsultant(id);
            consultant.Contracts = new List<ContractDto>();
            foreach (Contract cont in contractsFromDb) {
                consultant.Contracts.Add(new ContractDto() {
                    EndDate = cont.EndDate,
                    StartDate = cont.StartDate,
                    DocumentUrl = cont.DocumentUrl,
                    Salary = cont.Salary,
                    SignedDate = cont.SignedDate
                });
            }

            return Ok(consultant);
        }
    }
}