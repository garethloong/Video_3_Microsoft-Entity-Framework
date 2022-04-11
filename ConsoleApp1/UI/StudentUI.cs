using ConsoleApp1.DAL;
using ConsoleApp1.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.UI
{
    class StudentUI
    {
        public static void PrikaziStudente()
        {
            using (MyContext mc = new MyContext())
            {
                Console.WriteLine("====STUDENTI====");
                List<Student> students = mc.Studenti
                    .Include(x=>x.Korisnik)	// Include() requires using System.Data.Entity;
                    .Include(x=>x.Smjer)      // nepotrebno zbog linije ispod
                    .Include(x=>x.Smjer.Fakultet)
                    .ToList();    // ToList() requires System.Linq to be included 

                foreach (Student item in students)
                {
                    Console.WriteLine("Id: " + item.Id);
                    Console.WriteLine("Broj indexa: " + item.BrojIndexa);
                    Console.WriteLine("Ime: " + item.Korisnik.Ime);
                    Console.WriteLine("Prezime: " + item.Korisnik.Prezime);
                    Console.WriteLine("Fakultet: " + item.Smjer.Fakultet.Naziv);
                    Console.WriteLine("Smjer: " + item.Smjer.Naziv);
                    Console.WriteLine("========================");
                }
            }
        }

        public static void DodajStudenta()
        {
            // 1st approach 
            Korisnik k = new Korisnik();
            k.Student = new Student();

            Console.WriteLine("Unesite ime: ");
            k.Ime = Console.ReadLine();

            Console.WriteLine("Unesite prezime: ");
            k.Prezime = Console.ReadLine();

            Console.WriteLine("Unesite broj indexa: ");
            k.Student.BrojIndexa = Console.ReadLine();

            Console.WriteLine("Unesite ID smjera: ");
            SmjerUI.PrikaziSmjerove();
            k.Student.SmjerId = int.Parse(Console.ReadLine());

            // 2nd approach
            //Student s = new Student();
            //Korisnik k = new Korisnik();

            //Console.WriteLine("Unesite ime");
            //k.Ime = Console.ReadLine();

            //Console.WriteLine("Unesite prezime");
            //k.Prezime = Console.ReadLine();

            //Console.WriteLine("Unesite broj indeksa");
            //s.BrojIndeksa = Console.ReadLine();

            //Console.WriteLine("Unesite Id smjera");
            //SmjerUI.PrikaziSmjerove();
            //s.SmjerId = int.Parse(Console.ReadLine());

            //s.Korisnik = k;
            //k.Student = s;

            /////////////////////////////////

            // 1st approach - using MyContext and manually calling Dispose() method
            //MyContext mc = new MyContext();
            //mc.Studenti.Add(s);
            //mc.SaveChanges();
            //mc.Dispose();

            // 2nd approach with "using" block - preferred !!!
            using (MyContext mc = new MyContext())
            {
                mc.Korisnici.Add(k);
                mc.SaveChanges();
            }

            Console.WriteLine("----------------------------");
        }

    }
}
