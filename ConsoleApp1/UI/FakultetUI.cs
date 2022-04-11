using ConsoleApp1.DAL;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.UI
{
    class FakultetUI
    {
        public static void PrikaziFakultete()
        {
            using (MyContext mc = new MyContext())
            {
                Console.WriteLine("=====FAKULTETI=====");
                List<Fakultet> fakulteti = mc.Fakulteti.ToList();
                foreach (Fakultet x in fakulteti)
                {
                    Console.WriteLine("Id = " + x.Id + ", Naziv = " + x.Naziv);
                }
                Console.WriteLine("=================");
            }

        }

        public static void DodajFakultet()
        {
            Fakultet x = new Fakultet();
            Console.WriteLine("Unesite naziv fakulteta");
            x.Naziv = Console.ReadLine();

            using (MyContext ctx = new MyContext())
            {
                ctx.Fakulteti.Add(x);
                ctx.SaveChanges();
            }
            Console.WriteLine("=================");
        }
    }
}
