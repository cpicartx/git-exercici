using System;

namespace modul2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercici variables....
            // FASE 1
            string nom = "Juan";
            string cognom1 = "Asensio";
            string cognom2 = "Rodríguez";
            int dia = 18;
            int mes = 10;
            int any = 1980;

            Console.WriteLine("");
            Console.WriteLine("FASE1");
            Console.WriteLine(cognom1 + " " + cognom2 + ", " + nom);
            Console.WriteLine(dia + "/" + mes + "/" + any);

            // FASE2

            const int AnyTraspas = 1948;
            int cadaQuan = 4;
            int anyNaixament = 1972;
            int diferencia = 0;

            diferencia = anyNaixament - AnyTraspas;
            diferencia = diferencia / cadaQuan;

            Console.WriteLine("");
            Console.WriteLine("FASE2");
            Console.WriteLine("Any naixament: " + anyNaixament);
            Console.WriteLine(diferencia + " anys de traspàs");

            // FASE3

            int AnyTraspas2 = 1948;
            int cadaQuan2 = 4;
            int anyNaixament2 = 1972;
            bool traspas = false;
            string frase = "";
            int dia2 = 5;
            int mes2 = 4;
            int cont = 0;
            for (int i = AnyTraspas2; i <= anyNaixament2; i++)
            {
                cont++;
                if (cont == cadaQuan2) 
                    { traspas = true;
                    cont = 0;
                }
                else { traspas = false; }
            }

            Console.WriteLine("");
            Console.WriteLine("FASE3");
            Console.WriteLine($"El meu nom és {nom} {cognom1} {cognom2}");
            Console.WriteLine($"Vaig néixer el {dia2}/{mes2}/{anyNaixament2}");
            if (traspas == true)
                {frase = "El meu any de naixament és de traspàs"; }
            else { frase = "El meu any de naixament no és de traspàs"; }
            Console.WriteLine(frase);
        }
    }
}
