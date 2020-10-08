using System;
using System.Collections.Generic;
using modul2_4.Lib.Models;


// Exercici mòdul 2-4 sobre usuaris que tenen videos
// Author: Cristian Picart
// Date: 6/10/2020

namespace modul2_4
{
    class Program
    {
        static Dictionary<string, Usuari> Usuaris = new Dictionary<string, Usuari>();
        static Dictionary<string, Video> Videos = new Dictionary<string, Video>();

        static string logger = null;

        static void Main(string[] args)
        {
            try
            {

                MenuPrincipal();
                var tecla = true;

                while (tecla)
                {
                    var opcio = Console.ReadKey().KeyChar;

                    if (opcio == 'a')
                    {
                        MenuUsuaris();
                    }
                    else if (opcio == 'b')
                    {
                        MenuVideos();
                    }
                    else if (opcio == 's')
                    {
                        System.Environment.Exit(-1);
                    }
                }
            }catch (Exception e)
                {
                Console.WriteLine("*** Error d'exepció: " + e) ;
                }

        }

        static void MenuUsuaris()
        {
            Console.WriteLine();
            MenuUsuarisOpcions();

            var tecla = true;
            while (tecla)
            {
                var text = Console.ReadLine();

                switch (text)
                {
                    case "all":
                        LlistaUsuaris();
                        break;
                    case "add":
                        AfegirUsuari();
                        break;
                    case "del":
                        EsborraUsuari();
                        break;
                    case "edit":
                        EditaUsuari();
                        break;
                    case "m":
                        tecla = false;
                        break;
                    default:
                        Console.WriteLine("ERROR: tecla no reconeguda ***");
                        break;
                }
            }


            MenuPrincipal();
        }

        static void MenuVideos()
        {
            Console.WriteLine();
            MenuVideosOpcions();

            var tecla = true;
            while (tecla)
            {
                var text = Console.ReadLine();

                switch (text)
                {
                    case "all":
                        LlistaVideos();
                        break;
                    case "log":
                        Loggejar();
                        break;
                    case "add":
                        AfegirVideo();
                        break;
                    case "del":
                        EsborraVideo();
                        break;
                    case "m":
                        tecla = false;
                        break;
                    default:
                        Console.WriteLine("ERROR: tecla no reconeguda ***");
                        break;
                }
            }


            MenuPrincipal();
        }

        private static void MenuUsuarisOpcions()
        {
            Console.WriteLine("---- Menu d'usuaris ----");

            Console.WriteLine("Per afegir un nou usuari escriu: add");
            Console.WriteLine("Per a editar un usuari escriu: edit");
            Console.WriteLine("Per a esborrar un usuari escriu: del");
            Console.WriteLine("Per veure tots els usuaris escriure: all");
            Console.WriteLine("Per a tornar al menú principal escriu: m");
        }
        private static void MenuVideosOpcions()
        {
            Console.WriteLine("---- Menu de videos ----");

            Console.WriteLine("Per loggejar-te escriu: log");
            Console.WriteLine("Per afegir un video escriu: add");
            Console.WriteLine("Per editar un video escriu: edit");
            Console.WriteLine("Per esborrar un video escriu: del");
            Console.WriteLine("Per veure tots els videos escriu: all");
            Console.WriteLine("Per a tornar al menú principal escriu: m");
        }

        private static void MenuPrincipal()
        {
            Console.WriteLine("Benvingut al programa per a la gestió de videos");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Gestió d'usuaris opció ---> a");
            Console.WriteLine("Gestió de videos opció ---> b");
            Console.WriteLine("Sortir ---> s");
        }

        static void LlistaUsuaris()
        {
            Console.WriteLine("--- Llista d'usuaris ---");
            foreach (var usuari in Usuaris.Values)
            {

                Console.WriteLine($"{usuari.user} {usuari.nom} {usuari.cognom} {usuari.password} {usuari.data_registre}");
            }
        }
        static void EsborraUsuari()
        {
            Console.WriteLine("--- Esborrar usuari ----------");
            Console.WriteLine("Posa nom d'usuari");
            var tecla = true;
            while (tecla)
            {
                var user = Console.ReadLine();

                if (Usuaris.ContainsKey(user))
                {
                    Usuaris.Remove(user);
                    Console.WriteLine($"AVÍS: L'usuari {user} s'ha esborrat ***");
                }
                else if (string.IsNullOrEmpty(user) || user.Length < 6)
                {
                    Console.WriteLine("ERROR: Usuari amb format incorrecte ***");
                }
                else if (!Usuaris.ContainsKey(user))
                {
                    Console.WriteLine("AVÍS: Usuari no existeix ***");
                }
                tecla = false;
            }
            MenuUsuarisOpcions();
        }

        static void EditaUsuari()
        {

        }
        static void AfegirUsuari()
        {
            Console.WriteLine("--- Afegir usuari -------");
            Console.WriteLine("Posa nom d'usuari");

            var tecla = true;
            while (tecla)
            {
                var user = Console.ReadLine();

                if (string.IsNullOrEmpty(user) || user.Length < 6)
                {
                    Console.WriteLine("ERROR: L'usuari amb format incorrecte ***");
                }
                else if (Usuaris.ContainsKey(user))
                {
                    Console.WriteLine($"AVÍS: Ja existeix un usuari amb el user {user} ***");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("--- Dades complementàries -----");
                        Console.WriteLine("Escriu el nom de pila");
                        var name = Console.ReadLine();
                        Console.WriteLine("Escriu els cognoms");
                        var cognoms = Console.ReadLine();
                        Console.WriteLine("Escriu el password");
                        var clau = Console.ReadLine();

                        try
                        {
                            if (string.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("ERROR: El nom està buit ***");
                            }
                            else
                            {
                          
                            var usuari = new Usuari
                            {
                                user = user,
                                nom = name,
                                cognom = cognoms,
                                password = clau,
                                data_registre = DateTime.Now,
                            };
                            Usuaris.Add(usuari.user, usuari);
                            tecla = false;
                            break;
                           
                            }   
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ERROR: Error afegint usuari: " + e);
                            break;
                        }
                    }
                }
            }

            MenuUsuarisOpcions();
        }

        static void AfegirVideo()
        {
            var tecla = true;
            if (logger == null) 
            {
                Console.WriteLine("AVÍS: Has de loggejar-te abans ***");
                tecla = false; 
            }

            while (tecla)
            {
                Console.WriteLine("--- Afegir video -----");
                Console.WriteLine("Posa titol del video, i 's' per acabar:");
                var titol = Console.ReadLine();

                if (titol == "s")
                {
                    break;
                }
                else if (string.IsNullOrEmpty(titol))
                {
                    Console.WriteLine("ERROR: Títol està en blanc");
                }

                else
                {
                    while (true)
                    {
                        Console.WriteLine("--- Dades complementàries -----");
                        Console.WriteLine("Escriu la url");
                        var ruta = Console.ReadLine();
                        if (string.IsNullOrEmpty(ruta))
                        {
                            Console.WriteLine("ERROR: La url està buida");
                            break;
                        }

                        Console.WriteLine("Escriu un tag ('s' per acabar)");
                        List<string> tags = new List<string>();
                        string texte = "";

                        while (texte != "s")
                        {
                            texte = Console.ReadLine();
                            if (texte != "s")
                            {
                                tags.Add(texte);
                            }
                        }

                        try
                        {
                            var video = new Video
                            {
                                propietari = logger,
                                ruta = ruta,
                                titol = titol,
                                tags = tags,
                            };
                            Videos.Add(titol, video);
                            tecla = false;
                            break;

                        }catch (Exception e)
                        {
                            Console.WriteLine("ERROR: Error afegint video: " + e);
                            break;
                        }
                    }
                }
            }

            MenuVideosOpcions();
        }

        static void LlistaVideos()
        {
            Console.WriteLine($"--- Llista de videos de l'usuari {logger} ---");
            foreach (var video in Videos.Values)
            {
                if (video.propietari == logger)
                {
                    Console.WriteLine($"{video.titol} {video.ruta}");
                    video.tags.ForEach(delegate (String tags)
                    {
                        Console.WriteLine($"Tag: {tags}");
                    });

                }
            }
        }
        static void EsborraVideo()
        {
            Console.WriteLine("--- Esborrar video ----------");
            Console.WriteLine("Posa titol del video");


            var titol_video = Console.ReadLine();
            foreach (var video in Videos.Values)
            {
                if ((video.propietari == logger) && (Videos.ContainsKey(titol_video)))
                {
                    Videos.Remove(titol_video);
                    Console.WriteLine($"AVÍS: El video {titol_video} s'ha esborrat ***");
                }
            }

            MenuVideosOpcions();
        }

        static void Loggejar()
        {
            logger = "";
            Console.WriteLine("Posa nom d'usuari");

            var tecla = true;
            while (tecla)
            {
                var user = Console.ReadLine();

                if (Usuaris.ContainsKey(user))
                {
                    Console.WriteLine($"AVÍS: Estàs loggejat com a {user} ***");
                    logger = user;
                }
                else if (string.IsNullOrEmpty(user) || user.Length < 6)
                {
                    Console.WriteLine("ERROR: Usuari amb format incorrecte ***");
                }
                else if (!Usuaris.ContainsKey(user))
                {
                    Console.WriteLine("AVÍS: Usuari no existeix ***");
                }
                tecla = false;
            }
            MenuVideosOpcions();
        }
    }
}