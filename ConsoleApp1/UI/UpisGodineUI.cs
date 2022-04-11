using ConsoleApp1.DAL;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp1.UI
{
    class UpisGodineUI
    {
        public static void PrikaziUpiseGodine()
        {
            using (MyContext mc = new MyContext())
            {
                Console.WriteLine("=====Akademske godine=====");
                // Postoje 2 verzije Include funkcije - jedna genericka i jedna koja prima string. Nama treba genericka a ona trazi System.Data.Entity namespace
                List<UpisGodine> upisi = mc.UpisiGodine
                    .Include(x => x.AkademskaGodina)
                    .Include(x => x.Smjer)
                    .Include(x => x.Student.Korisnik)
                    .ToList();

                foreach (UpisGodine x in upisi)
                {
                    Console.WriteLine("Id = " + x.Id + ", Smjer = " + x.Smjer.Naziv + ", Akademska godina = " + x.AkademskaGodina.Opis + ", Godina studija = " + x.GodinaStudija + ", Student = " + x.Student.Korisnik.Ime + " " + x.Student.Korisnik.Prezime);
                }
                Console.WriteLine("=================");
            }

        }

        public static void DodajUpisGodine()
        {
            UpisGodine x = new UpisGodine();

            Console.WriteLine("Unesite Id studenta");
            StudentUI.PrikaziStudente();
            x.StudentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite Id smjera");
            SmjerUI.PrikaziSmjerove();
            x.SmjerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite Id akademske godine");
            AkademskaGodinaUI.PrikaziAkademskeGodine();
            x.AkademskaGodinaId = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite godinu studija (1,2,3,4)");
            x.GodinaStudija = int.Parse(Console.ReadLine());

            x.DatumUpisa = DateTime.Now;

            using (MyContext ctx = new MyContext())
            {
                ctx.UpisiGodine.Add(x);
                ctx.SaveChanges();
            }
            Console.WriteLine("=================");
        }
    }
}
