using System;
using System.Collections.Generic;


namespace modul2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercici lletres repetides
            //FASE1

            char[] nom = { 'C', 'r', 'i', 's', 't', 'i', 'a', 'n' };
            int max = nom.Length;


            Console.WriteLine("Exercici lletres repetides");
            Console.WriteLine("FASE1");
            Console.WriteLine("Recorrem l'array....");


            for (int i = 0; i < max; i++)
            {
                Console.Write(nom[i]);
            }


            //FASE2

            string nom2 = "Cristian";
            bool is_vocal = false;

            char[] charNom = nom2.ToCharArray();

            var vocals = new[] { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("FASE2");
            Console.WriteLine("Recorrem la llista del nom " + nom2);

            for (int i = 0; i < charNom.Length; i++)
            {
                if (Char.IsNumber(charNom[i]))
                {
                    Console.WriteLine("Els noms de persones no contenen números");
                    break;
                }

                for (int j = 0; j < vocals.Length; j++)
                {
                    if (charNom[i] == vocals[j])
                    {
                        Console.WriteLine("VOCAL");
                        is_vocal = true;
                        break;
                    }
                }
                if (is_vocal) { is_vocal = false; }
                else {Console.WriteLine("CONSONANT"); }


            }

            //FASE3
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("FASE3");
            Console.WriteLine("Guardem la llista del nom al diccionari..." + nom2);

            //char[] charNom = nom2.ToCharArray();
            List<char> llistaNom = new List<char>();
            for (int i = 0; i < charNom.Length; i++)
            {
                llistaNom.Add(charNom[i]);
            }
            Dictionary<char, int> diccionariNom = new Dictionary<char, int>();

            foreach (var nomx in llistaNom)
            {
                if (!diccionariNom.ContainsKey(nomx))
                    diccionariNom.Add(nomx, 1);
                else
                {
                    diccionariNom[nomx]++;
                }
            }

            foreach (var nomx in diccionariNom)
            {
                Console.WriteLine(nomx);
            }

            //FASE4
            string nom3 = "Pepito";
            string cognom3 = "Gonzalez";

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("FASE4");
            Console.WriteLine("Crea la llista del nom i cognom..." + nom3 + " " + cognom3);

            char[] charNom3 = nom3.ToCharArray();
            char[] charCognom3 = cognom3.ToCharArray();

            List<char> llistaNom3 = new List<char>();
            List<char> llistaCognom3 = new List<char>();
            List<char> llistaNomComplert = new List<char>();

            for (int i = 0; i < charNom3.Length; i++)
            {
                llistaNom3.Add(charNom3[i]);
            }

            for (int i = 0; i < charCognom3.Length; i++)
            {
                llistaCognom3.Add(charCognom3[i]);
            }

            llistaNomComplert.AddRange(llistaNom3);
            llistaNomComplert.Add(' ');
            llistaNomComplert.AddRange(llistaCognom3);

            foreach (var lletra in llistaNomComplert)
            {
                Console.Write(lletra);
            }
        }
    }
    }
