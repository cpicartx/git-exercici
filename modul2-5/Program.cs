using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace modul2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //FASE1
            Console.WriteLine("FASE1");
            int[] numeros = { 2, 6, 8, 4, 5, 5, 9, 2, 1, 8, 7, 5, 9, 6, 4 };

            IEnumerable<int> parell = from d in numeros
                                             where (d % 2 == 0)
                                             orderby d
                                             select d;

            // mostra els números parells
            foreach (var item in parell)
            {
                Console.WriteLine(item);

            }

            //FASE2 
            Console.WriteLine("FASE2");
            var alumnos = new List<Alumno>
            {
                new Alumno {Nombre = "Alumne1",Nota = 2},
                new Alumno {Nombre = "Alumne2",Nota = 6},
                new Alumno {Nombre = "Alumne3",Nota = 8},
                new Alumno { Nombre = "Alumne4", Nota = 4 },
                new Alumno { Nombre = "Alumne5", Nota = 5 },
                new Alumno { Nombre = "Alumne6", Nota = 5 },
                new Alumno { Nombre = "Alumne7", Nota = 9 },
                new Alumno { Nombre = "Alumne8", Nota = 2 },
                new Alumno { Nombre = "Alumne9", Nota = 1 },
                new Alumno { Nombre = "Alumne10", Nota = 8 },
                new Alumno { Nombre = "Alumne11", Nota = 7 },
                new Alumno { Nombre = "Alumne12", Nota = 5 },
                new Alumno { Nombre = "Alumne13", Nota = 9 },
                new Alumno { Nombre = "Alumne14", Nota = 6 },
                new Alumno { Nombre = "Alumne15", Nota = 4 }
            };
            var notaMitjana = alumnos.Average(x => x.Nota);
            var notaMaxima = alumnos.Max(x => x.Nota);
            var notaMinima = alumnos.Min(x => x.Nota);

            Console.WriteLine("Nota mitjana = " + notaMitjana);
            Console.WriteLine("Nota màxima = " + notaMaxima);
            Console.WriteLine("Nota mínima = " + notaMinima);

            //FASE3
            Console.WriteLine("FASE3");
            IEnumerable<int> mesGrans5 = from d in numeros
                                      where (d > 5)
                                      orderby d
                                      select d;

            IEnumerable<int> mesPetits5 = from d in numeros
                                         where (d < 5)
                                         orderby d
                                         select d;

            // mostra els números més grans que 5

            Console.WriteLine("Els números més grans que 5 són: ");
            foreach (var item in mesGrans5)
            {
                Console.WriteLine(item);

            }

            // mostra els números més petits que 5
            Console.WriteLine("Els números més petits que 5 són: ");
            foreach (var item in mesPetits5)
            {
                Console.WriteLine(item);

            }

            //FASE4
            Console.WriteLine("FASE4");
            string[] noms = {"David", "Sergio", "Maria", "Laura", "Oscar", "Julia", "Oriol" };

            IEnumerable<string> començaO = from d in noms
                                          where d.StartsWith ("O")
                                          orderby d
                                          select d;
            Console.WriteLine("Els noms que comencen per la lletra O són: ");
            foreach (var item in començaO)
            {
                Console.WriteLine(item);

            }
            IEnumerable<string> mes6 = from d in noms
                                            where d.Length > 6
                                           orderby d
                                           select d;
            Console.WriteLine("Els noms que tenen més de 6 lletres són: ");
            foreach (var item in mes6)
            {
                Console.WriteLine(item);

            }

            IEnumerable<string> ordDesc = from d in noms
                                       //where d
                                       orderby d descending
                                       select d;
            Console.WriteLine("Els noms ordenats descentment són: ");
            foreach (var item in ordDesc)
            {
                Console.WriteLine(item);

            }


        }
    }
    public class Alumno
    {
        public string Nombre { get; set; }

        public int Nota { get; set; }
    }
}
