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
                using (StreamReader olvas = new StreamReader("dolgozok.txt"))
                {
                    olvas.ReadLine();
                    while (!olvas.EndOfStream)
                    {
                        string[] sor = olvas.ReadLine().Split(';');
                        var egyDolgozo = new Dolgozo
                            (
                            byte.Parse(sor[0]),
                            sor[1],
                            sor[2],
                            sor[3],
                            sor[4],
                            int.Parse(sor[5]),
                            int.Parse(sor[6]),
                            DateTime.Parse(sor[7]),
                            DateTime.Parse(sor[8]),
                            sor[9]
                            );
                        dolgozok.Add(egyDolgozo);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Hiba történt: {e.Message}");
            }
            
        }
    }
}
