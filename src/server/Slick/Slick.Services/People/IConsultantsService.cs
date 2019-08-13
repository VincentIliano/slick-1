using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Services.People
{
    public interface IConsultantsService
    {
        IEnumerable<Consultant> GetAll();
        IEnumerable<Consultant> GetAll(string sort);

        IEnumerable<Consultant> FindByFirstname(string firstname);
        IEnumerable<Consultant> FindByFirstname(string firstname, string sort);
        IEnumerable<Consultant> FindByLastname(string lastname);
        IEnumerable<Consultant> FindByLastname(string lastname, string sort);


        Consultant GetById(Guid id);
        Consultant GetByIdWithDetails(Guid id);

        void Update(Consultant c);
        void Delete(Consultant c);
        Consultant Create(Consultant c);
    }
}
