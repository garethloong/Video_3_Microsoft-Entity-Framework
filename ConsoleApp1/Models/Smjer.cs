using ConsoleApp1.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class Smjer : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Naziv { get; set; }

        // oboje dole neophodno da bi EF formirao vezu medju tabelama (1:N), a naziv property-a sa Id-em se formira tako sto na nziv klase/tabele dodaje Id (ne ID)
        public int FakultetId { get; set; }     // Foreign key for the object/property Fakultet
        public Fakultet Fakultet { get; set; }      // needed in order to create a relation in the DB between Smjer and Fakultet tables
    }
}
