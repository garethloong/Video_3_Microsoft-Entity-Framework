using ConsoleApp1.DAL;
using ConsoleApp1.Models;
using ConsoleApp1.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Login();

            int unos;

            do
            {
                Console.WriteLine("1. Student - dodaj");
                Console.WriteLine("2. Student - prikazi");
                Console.WriteLine("3. Smjer - dodaj");
                Console.WriteLine("4. Smjer - prikazi");
                Console.WriteLine("5. Fakultet - dodaj");
                Console.WriteLine("6. Fakultet - prikazi");
                Console.WriteLine("7. Akademska godina - dodaj");
                Console.WriteLine("8. Akademska godina - prikazi");
                Console.WriteLine("9. Upis godine - dodaj");
                Console.WriteLine("10. Upis godine - prikazi");
                Console.WriteLine("11. EXIT");

                unos = int.Parse(Console.ReadLine());

                switch (unos)
                {
                    case 1:
                        StudentUI.DodajStudenta();
                        break;
                    case 2:
                        StudentUI.PrikaziStudente();
                        break;
                    case 3:
                        SmjerUI.DodajSmjer();
                        break;
                    case 4:
                        SmjerUI.PrikaziSmjerove();
                        break;
                    case 5:
                        FakultetUI.DodajFakultet();
                        break;
                    case 6:
                        FakultetUI.PrikaziFakultete();
                        break;
                    case 7:
                        AkademskaGodinaUI.DodajAkademskuGodinu();
                        break;
                    case 8:
                        AkademskaGodinaUI.PrikaziAkademskeGodine();
                        break;
                    case 9:
                        UpisGodineUI.DodajUpisGodine();
                        break;
                    case 10:
                        UpisGodineUI.PrikaziUpiseGodine();
                        break;
                }
            } while (unos != 11);
        }


        private static void Login()
        {
            Korisnik k = null;
            do
            {
                Console.WriteLine("Unesite username");
                string u = Console.ReadLine();

                Console.WriteLine("Unesite password");
                string p = Console.ReadLine();

                using (MyContext ctx = new MyContext())
                {
                    k = ctx.Korisnici.Where(x => x.Username == u && x.Password == p).SingleOrDefault();
                    if (k == null)
                        Console.WriteLine("Pogrešan username i/ili password");
                    else
                    {
                        if (k.Referent == null)
                            Console.WriteLine("Upozorenje: Niste referent.");
                    }
                }
            } while (k == null);
        }
    }
}
