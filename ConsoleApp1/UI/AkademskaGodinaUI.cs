using ConsoleApp1.DAL;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.UI
{
    class AkademskaGodinaUI
    {
        public static void PrikaziAkademskeGodine()
        {
            using (MyContext ctx = new MyContext())
            {
                Console.WriteLine("=====Akademske godine=====");
                List<AkademskaGodina> fakulteti = ctx.AkademskeGodine
                    .Where(y => !y.IsDeleted)
                    .ToList();
                foreach (AkademskaGodina x in fakulteti)
                {
                    Console.WriteLine("Id = " + x.Id + ", Opis = " + x.Opis);
                }
                Console.WriteLine("=================");
            }

        }

        public static void DodajAkademskuGodinu()
        {
            AkademskaGodina x = new AkademskaGodina();
            Console.WriteLine("Unesite akademsku godinu");
            x.Opis = Console.ReadLine();

            using (MyContext ctx = new MyContext())
            {
                ctx.AkademskeGodine.Add(x);
                ctx.SaveChanges();
            }
            Console.WriteLine("=================");
        }
    }
}
