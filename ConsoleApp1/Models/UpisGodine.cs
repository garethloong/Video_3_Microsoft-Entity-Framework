using ConsoleApp1.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class UpisGodine : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DatumUpisa { get; set; }
        public int GodinaStudija { get; set; }

        // oboje dole neophodno da bi EF formirao vezu medju tabelama, a naziv property-a sa Id-em se formira tako sto na naziv klase/tabele dodaje Id (ne ID)
        // Ako polje Student kod upisa godine teoretski nije obavezno, mozemo staviti da je tipa int? umjesto int
        public int StudentId { get; set; }      // Convention is to add "Id" to the name of the object in order to make foreign key name - in that case EF will recognize a relation between StudentId and Student (next line).
        public Student Student { get; set; }    // needed in order to create a relation in the DB between UpisGodine and Student tables
        public int SmjerId { get; set; }
        public Smjer Smjer { get; set; }     // needed in order to create a relation in the DB between UpisGodine and Smjer tables
        public int AkademskaGodinaId { get; set; }
        public AkademskaGodina AkademskaGodina { get; set; }     // needed in order to create a relation in the DB between UpisGodine and AkademskaGodina tables
    }
}
