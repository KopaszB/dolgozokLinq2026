using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dolgozokLinq
{
    internal class Program
    {
        static List<Dolgozo> dolgozok = new List<Dolgozo>();  
        static void Main(string[] args)
        {
            AdatBeolvas();

            //AdatKiir();

            //1.feladat
            int jutalomOsszeg = dolgozok.Sum(x=>x.Jutalom);
            Console.WriteLine($"A jutalmak összeg: {jutalomOsszeg}");

            //2.feladat
            double fizAtlag = dolgozok.Average(x => x.Fizetes);
            Console.WriteLine($"A fizetések átlaga: {fizAtlag:F0}");

            //3.feladat
            bool vaneRecski = dolgozok.Any(x => x.Telepules == "Recsk");
            Console.WriteLine(vaneRecski?"Van recski dolgozó":"Nincs recski dolgozó");

            //4.feladat
            Console.WriteLine($"Tatai dolgozók: {dolgozok.Count(x=>x.Telepules== "Tata")} fő");

            //5.feladat
            dolgozok.ForEach(w => Console.WriteLine($"{w.Nev,-30} - {w.Fizetes}"));

            //6.feladat
                //1.módszer
            List<Dolgozo> legmagasabbFizu = dolgozok.OrderByDescending(x => x.Fizetes).Take(1).ToList();
            foreach (var item in legmagasabbFizu)
            {
                Console.WriteLine(item.Nev + " " +item.Fizetes);
            }
                //2.módszer
            //var maxFizu = dolgozok.Max(x => x.Fizetes);
            var maxIndex = dolgozok.FindIndex(x => x.Fizetes == dolgozok.Max(y => y.Fizetes));
            Console.WriteLine(dolgozok[maxIndex].Nev + " " + dolgozok[maxIndex].Telepules);

            //7.feladat
            dolgozok.Where(x => x.Fizetes > dolgozok.Average(y => y.Fizetes)).ToList().ForEach(w => Console.WriteLine($"Neve: {w.Nev}, fizetése: {w.Fizetes}"));

            //8.feladat
            dolgozok.Where(x=>x.Szuletes.ToString()==dolgozok.OrderBy(y=>y.Szuletes).Take(1).ToString()).ToList().ForEach(w => Console.WriteLine($"{w.Nev}"));


            Console.ReadKey();
        }

        private static void AdatKiir()
        {
            foreach (var item in dolgozok)
            {
                Console.WriteLine($"{item.Nev}");
            }
        }

        private static void AdatBeolvas()
        {
            try
            {
                dolgozok = File.ReadAllLines("dolgozok.txt")
                    .Skip(1)
                    .Select(sor => sor.Split(';'))
                    .Select(adat => new Dolgozo(
                        int.Parse(adat[0]),
                        adat[1],
                        adat[2],
                        adat[3],
                        adat[4],
                        int.Parse(adat[5]),
                        int.Parse(adat[6]),
                        DateTime.Parse(adat[7]),
                        DateTime.Parse(adat[8]),
                        adat[9])
                        ).ToList();
            }
            catch (Exception e)
            {

                Console.WriteLine($"Hiba történt: {e.Message}");
            }
            
        }
    }
}
