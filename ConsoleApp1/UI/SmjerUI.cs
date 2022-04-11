using ConsoleApp1.DAL;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.UI
{
    class SmjerUI
    {
        public static void PrikaziSmjerove()
        {
            using (MyContext mc = new MyContext())
            {
                Console.WriteLine("====SMJEROVI======");
                // ToList() requires System.Linq and Include() requires System.Data.Entity to be included.
                // stacking Include() method to add a table Fakultet which data we need to access
                List<Smjer> smjerovi = mc.Smjerovi
                    .Include(x=>x.Fakultet)
                    .ToList();

                foreach (Smjer item in smjerovi)
                {
                    Console.WriteLine("Id: " + item.Id);
                    Console.WriteLine("Naziv: " + item.Naziv);

                    // This will not work  since it takes data ONLY from the table Smjer, but from not the Fakultet. To make it work we need
                    // to use Include() method (line where we get Smjerovi) in order to set name of the dependent tables (e.g. Fakultet) we intend to use:
                    Console.WriteLine("Fakultet: " + item.Fakultet.Naziv);  

                    // This will work without Include() method.
                    //Fakultet f = mc.Fakulteti.Where(x => x.Id == item.FakultetId).FirstOrDefault();
                    //Console.WriteLine("Fakultet: " + f.Naziv);

                    Console.WriteLine("========================");
                }
            }
        }

        public static void DodajSmjer()
        {
            Smjer s = new Smjer();

            Console.WriteLine("Unesite naziv smjera: ");
            s.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite ID fakulteta: ");
            FakultetUI.PrikaziFakultete();
            s.FakultetId = int.Parse(Console.ReadLine());

            using (MyContext mc = new MyContext())
            {
                mc.Smjerovi.Add(s);
                mc.SaveChanges();
            }

            Console.WriteLine("----------------------------");
        }

    }
}
