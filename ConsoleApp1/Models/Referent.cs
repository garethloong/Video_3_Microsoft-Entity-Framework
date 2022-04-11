using ConsoleApp1.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class Referent:IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
