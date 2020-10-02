using System;

namespace modul2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercici noms ciutats
            //FASE1
            string ciutat1, ciutat2, ciutat3, ciutat4, ciutat5, ciutat6 = "";
            string texte = "Entra nom ciutat: ";

            Console.WriteLine("FASE1");
            Console.WriteLine(texte);
            ciutat1 = Console.ReadLine();
            Console.WriteLine(texte);
            ciutat2 = Console.ReadLine();
            Console.WriteLine(texte);
            ciutat3 = Console.ReadLine();
            Console.WriteLine(texte);
            ciutat4 = Console.ReadLine();
            Console.WriteLine(texte);
            ciutat5 = Console.ReadLine();
            Console.WriteLine(texte);
            ciutat6 = Console.ReadLine();

            Console.WriteLine("Ciutat1: " + ciutat1);
            Console.WriteLine("Ciudad2: " + ciutat2);
            Console.WriteLine("Ciudad3: " + ciutat3);
            Console.WriteLine("Ciudad4: " + ciutat4);
            Console.WriteLine("Ciudad5: " + ciutat5);
            Console.WriteLine("Ciudad6: " + ciutat6);

            // FASE2 ///////////////////////////////////////////////////////
            Console.WriteLine(" ");
            Console.WriteLine("FASE2");

            string[] ciutats = new string[6] { ciutat1, ciutat2, ciutat3, ciutat4, ciutat5, ciutat6 };
            string[] ciutatsBack = new string[6];
            ciutatsBack = ciutats;

            Array.Sort(ciutats);
            Console.WriteLine("Ciutats per ordre alfabètic...");
            for (int i = 0; i < ciutats.Length; i++)
            {
                Console.WriteLine(ciutats[i]);
            }

            // FASE3  ////////////////////////////////////////////////////
            Console.WriteLine(" ");
            Console.WriteLine("FASE3");

            string[] ciutatsModif = new string[6];
            ciutatsModif = ciutatsBack;

            for (int i = 0; i < ciutatsModif.Length; i++)
            {
                ciutatsModif[i] = ciutatsModif[i].Replace('a', '4');
            }

            Array.Sort(ciutatsModif);

            for (int i = 0; i < ciutatsModif.Length; i++)
            {
                Console.WriteLine(ciutatsModif[i]);
            }

            // FASE4  ////////////////////////////////////////////////////
            Console.WriteLine(" ");
            Console.WriteLine("FASE4");

            string[] arrayCiutat1 = new string[ciutat1.Length];
            string[] arrayCiutat2 = new string[ciutat2.Length];
            string[] arrayCiutat3 = new string[ciutat3.Length];
            string[] arrayCiutat4 = new string[ciutat4.Length];
            string[] arrayCiutat5 = new string[ciutat5.Length];
            string[] arrayCiutat6 = new string[ciutat6.Length];


            for (int i = ciutat1.Length - 1; i >= 0; i--)
            {
                arrayCiutat1[i] = ciutat1.Substring(i, 1);
            }

            for (int i = arrayCiutat1.Length - 1; i >= 0; i--)
            {
                Console.Write(arrayCiutat1[i]);
            }
            Console.WriteLine(" ");

            for (int i = ciutat2.Length - 1; i >= 0; i--)
            {
                arrayCiutat2[i] = ciutat2.Substring(i, 1);
            }

            for (int i = arrayCiutat2.Length - 1; i >= 0; i--)
            {
                Console.Write(arrayCiutat2[i]);
            }
            Console.WriteLine(" ");

            for (int i = ciutat3.Length - 1; i >= 0; i--)
            {
                arrayCiutat3[i] = ciutat3.Substring(i, 1);
            }

            for (int i = arrayCiutat3.Length - 1; i >= 0; i--)
            {
                Console.Write(arrayCiutat3[i]);
            }
            Console.WriteLine(" ");

            for (int i = ciutat4.Length - 1; i >= 0; i--)
            {
                arrayCiutat4[i] = ciutat4.Substring(i, 1);
            }

            for (int i = arrayCiutat4.Length - 1; i >= 0; i--)
            {
                Console.Write(arrayCiutat4[i]);
            }

            Console.WriteLine(" ");
            for (int i = ciutat5.Length - 1; i >= 0; i--)
            {
                arrayCiutat5[i] = ciutat5.Substring(i, 1);
            }

            for (int i = arrayCiutat5.Length - 1; i >= 0; i--)
            {
                Console.Write(arrayCiutat5[i]);
            }
            Console.WriteLine(" ");
            for (int i = ciutat6.Length - 1; i >= 0; i--)
            {
                arrayCiutat6[i] = ciutat6.Substring(i, 1);
            }

            for (int i = arrayCiutat6.Length - 1; i >= 0; i--)
            {
                Console.Write(arrayCiutat6[i]);
            }
        }
    }
}
