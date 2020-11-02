using System;
using System.Collections.Generic;
using System.Linq;
using modul2_4.Lib.Models;

// Exercici mòdul 2-4 sobre usuaris que tenen videos
// Author: Cristian Picart
// Date: 15/10/2020


namespace modul2_4
{
    /// <summary>
    /// Gestió d'usuaris i dels videos que té un usuari, i gestió de la llista
    /// de tags que té cada video
    /// </summary>
    class Program
    {

        public static Dictionary<CrudOptionsTypes, string> CrudOptionsNames = new Dictionary<CrudOptionsTypes, string>
        {
            { CrudOptionsTypes.Add, "add" },
            { CrudOptionsTypes.Edit, "edit" },
            { CrudOptionsTypes.DeleteOrView, "delete" }
        };

        public static Dictionary<Guid, User> Users = new Dictionary<Guid, User>();
        public static Dictionary<Guid, Video> Videos = new Dictionary<Guid, Video>();
        public static Dictionary<Guid, Tag> Tags = new Dictionary<Guid, Tag>();



        static void Main(string[] args)
        {
            LoadInitialData();

            Console.WriteLine("Benvingut al programa para gestió de videos");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Per anar a la gestió de usuaris opció --> u");
            Console.WriteLine("Per anar a la gestió de videos opció --> v");
            Console.WriteLine("Per anar a la gestió de tags opció --> t");
            Console.WriteLine("Per sortir del programa --> q");

            var keepdoing = true;

            while (keepdoing)
            {
                var option = Console.ReadKey().KeyChar;

                if (option == 'u')
                {
                    ShowUsersMenu();
                }
                else if (option == 'v')
                {
                    ShowVideosMenu();
                }
                else if (option == 't')
                {
                    ShowTagsMenu();
                }
                else if (option == 'q')
                {
                    System.Environment.Exit(0);
                }

            }


        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("Tornar al menú principal");
            Console.WriteLine("------------------------");
            Console.WriteLine("Per anar a la gestió de usuaris opció --> u");
            Console.WriteLine("Per anar a la gestió de videos opció --> v");
            Console.WriteLine("Per anar a la gestió de tags opció --> t");
            Console.WriteLine("Per sortir del programa --> q");
        }

        #region User Menu


        static void ShowUsersMenu()
        {
            Console.WriteLine();
            ShowUsersMenuOptions();

            var keepdoing = true;
            while (keepdoing)
            {
                var optionText = Console.ReadLine();
                string username = GetUsernameForOption(ref optionText);

                switch (optionText)
                {
                    case "all":
                        ShowAllUsers();
                        break;

                    case "add":
                        AddNewUser();
                        break;

                    case "edit":
                        EditUser(username);
                        break;

                    case "delete":
                        DeleteUser(username);
                        break;

                    case "m":
                        keepdoing = false;
                        break;

                    default:
                        Console.WriteLine("Opció incorrecte, escriu una altra o 'm' per tornar al menú principal");
                        break;
                }
            }

            ShowMainMenu();
        }

        private static void ShowUsersMenuOptions()
        {
            Console.WriteLine("--Menu d'usuaris--");

            Console.WriteLine("Per veure tots els usuaris escriu --> all");
            Console.WriteLine("Per afegir un nou usuari escriu --> add");
            Console.WriteLine("Per editar un usuari escriu --> edit + el username");
            Console.WriteLine("Per esborrar un usuari escriu --> delete + el username");
            Console.WriteLine("Per tornar al menú principal escriu --> m");
        }

        static string GetCrudOptionForUsername(CrudOptionsTypes option, string input, out string textOption)
        {
            textOption = string.Empty;

            var optionName = CrudOptionsNames[option];

            if (string.IsNullOrEmpty(input))
                return null;

            if (input.StartsWith(optionName))
            {
                char[] c1 = { ' ' };
                var spaso = input.Split(c1);

                if (spaso.Length > 2)
                    Console.WriteLine("warning: there more parameters than needed after username");
                else if (spaso.Length > 1)
                {
                    var text = spaso[1];
                    var currentUsername = User.IsUsernameValid(text) ? text : string.Empty;
                    while (true)
                    {
                        if (!string.IsNullOrEmpty(currentUsername))
                        {
                            textOption = optionName;
                            return currentUsername;
                        }

                        Console.WriteLine($"El username {spaso[1]} no existeix o té un format incorrecte, torna a escriure o 'sortir' per sortir");
                        text = Console.ReadLine();
                        if (text == "sortir")
                        {
                            ShowUsersMenuOptions();
                            return null;
                        }

                        currentUsername = User.IsUsernameValid(text) ? text : string.Empty;
                    }
                }
            }
            return null;
        }

        private static string GetUsernameForOption(ref string text)
        {
            var prev = text;
            var username = GetCrudOptionForUsername(CrudOptionsTypes.Edit, text, out text);

            if (string.IsNullOrEmpty(username))
                username = GetCrudOptionForUsername(CrudOptionsTypes.DeleteOrView, text, out text);

            if (string.IsNullOrEmpty(text))
                text = prev;

            return username;
        }

        static string GetUsernameFromInput(CrudOptionsTypes option, string currentUsername = "")
        {
            Console.WriteLine("Introdueix el username o 'sortir' per sortir");
            var text = Console.ReadLine();
            var optionName = CrudOptionsNames[option];

            while (true)
            {
                if (text == "sortir")
                    return null;

                if (!User.ValidateUsernameFormat(text))
                {
                    Console.WriteLine(User.UsernameFormatError);
                    Console.WriteLine("Introdueix el username o 'sortir' per sortir");
                }
                else if (!User.ValidateUsernameDuplicated(text, currentUsername)
                        && (optionName != CrudOptionsNames[CrudOptionsTypes.DeleteOrView]))
                {
                    Console.WriteLine($"{User.ValidateUsernameDuplicated(text, currentUsername)} {text}");
                    Console.WriteLine("Introdueix el username o 'sortir' per sortir");
                }
                else
                {
                    return text;
                }

                text = Console.ReadLine();
            }

        }

        static string GetNameFromInput()
        {
            Console.WriteLine("Introdueix el nom o 'sortir' per sortir");
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "sortir")
                    return null;

                if (!User.ValidateNameFormat(input))
                {
                    Console.WriteLine(User.NameFormatError);
                    Console.WriteLine("Introdueix el nom o 'sortir' per sortir");
                }
                else
                {
                    return input;
                }
            }
        }
        static string GetSurnameFromInput()
        {
            Console.WriteLine("Introdueix el cognom o 'sortir' per sortir");
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "sortir")
                    return null;

                if (!User.ValidateNameFormat(input))
                {
                    Console.WriteLine(User.NameFormatError);
                    Console.WriteLine("Introdueix el cognom o 'sortir' per sortir");
                }
                else
                {
                    return input;
                }
            }
        }
        static string GetPasswordFromInput()
        {
            Console.WriteLine("Introdueix el password o 'sortir' per sortir");
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "sortir")
                    return null;

                if (!User.ValidateNameFormat(input))
                {
                    Console.WriteLine(User.NameFormatError);
                    Console.WriteLine("Introdueix el password o 'sortir' per sortir");
                }
                else
                {
                    return input;
                }
            }
        }

        #endregion



        #region Videos Menu

        static void ShowVideosMenu()
        {
            Console.WriteLine();
            ShowVideosMenuOptions(); 

            var keepdoing = true;
            while (keepdoing)
            {
                var optionText = Console.ReadLine();
                string videoName = GetVideoNameForOption(ref optionText);

                switch (optionText)
                {
                    case "all":
                        ShowAllVideos();
                        break;

                    case "add":
                        AddNewVideo();
                        break;

                    case "edit":
                        EditVideo(videoName);
                        break;

                    case "delete":
                        DeleteVideo(videoName);
                        break;

                    case "m":
                        keepdoing = false;
                        break;

                    default:
                        Console.WriteLine("Opció incorrecte, escriu una altra o 'm' per tornar al menú principal");
                        break;
                }
            }

            ShowMainMenu();
        }


        private static void ShowVideosMenuOptions()
        {
            Console.WriteLine("--Menu de videos--");

            Console.WriteLine("Per veure tots els videos escriu --> all");
            Console.WriteLine("Per veure un nuevo video escriu --> add");
            Console.WriteLine("Per editar un video escriu --> edit + el videoName");
            Console.WriteLine("Per esborrar un video escriu --> delete + el videoName");
            Console.WriteLine("Per tornar al menú principal escriu --> m");
        }

        static string GetCrudOptionForVideoName(CrudOptionsTypes option, string input, out string textOption)
        {
            textOption = string.Empty;

            var optionName = CrudOptionsNames[option];

            if (string.IsNullOrEmpty(input))
                return null;

            if (input.StartsWith(optionName))
            {
                char[] c1 = { ' ' };
                var spaso = input.Split(c1);

                if (spaso.Length > 2)
                    Console.WriteLine("warning: there more parameters than needed after subject name");
                else if (spaso.Length > 1)
                {
                    var text = spaso[1];
                    var currentVideoName = Video.IsVideoNameValid(text) ? text : string.Empty;
                    while (true)
                    {
                        if (!string.IsNullOrEmpty(currentVideoName))
                        {
                            textOption = optionName;
                            return currentVideoName;
                        }

                        Console.WriteLine($"El video {spaso[1]} no existeix o té un format incorrecte, torna a escriure-la o 'sortir' per sortir");
                        text = Console.ReadLine();
                        if (text == "sortir")
                        {
                            ShowUsersMenuOptions();
                            return null;
                        }

                        currentVideoName = Video.IsVideoNameValid(text) ? text : string.Empty;
                    }
                }
            }
            return null;
        }

        static string GetVideoNameForOption(ref string text)
        {
            var prev = text;
            var name = GetCrudOptionForVideoName(CrudOptionsTypes.Edit, text, out text);

            if (string.IsNullOrEmpty(name))
            {
                text = prev;
                name = GetCrudOptionForVideoName(CrudOptionsTypes.DeleteOrView, text, out text);
            }

            if (string.IsNullOrEmpty(text))
                text = prev;

            return name;
        }

        static string GetVideoNameFromInput(CrudOptionsTypes option, string currentName = "")
        {
            Console.WriteLine("Introdueix el nom del video o 'sortir' per sortir");
            var text = Console.ReadLine();
            var optionName = CrudOptionsNames[option];

            while (true)
            {
                if (text == "sortir")
                    return null;

                if (!Video.ValidateNameFormat(text))
                {
                    Console.WriteLine(Video.NameFormatError);
                    Console.WriteLine("Introdueix el nom del video o 'sortir' per sortir");
                }
                else if (!Video.ValidateVideoNameDuplicated(text, currentName)
                        && (optionName != CrudOptionsNames[CrudOptionsTypes.DeleteOrView]))
                {
                    Console.WriteLine($"{Video.ValidateVideoNameDuplicated(text,currentName)} {text}");
                    Console.WriteLine("Introdueix el nom del video o 'sortir' per sortir");
                }
                else
                {
                    return text;
                }

                text = Console.ReadLine();
            }

        }

        #endregion

        #region Tags Menu

        static void ShowTagsMenu()
        {
            Console.WriteLine();
            ShowTagsMenuOptions();
            char[] c1 = { ' ' };

            var keepdoing = true;
            while (keepdoing)
            {
                var optionText = Console.ReadLine();
                var extraOption = string.Empty;

                /*if (optionText.Contains("allby"))
                {
                    var spaso = optionText.Split(c1);
                    if (spaso.Length > 0)
                    {
                        optionText = spaso[0];
                        if (spaso.Length > 1)
                            extraOption = spaso[1];
                    }
                }*/


                switch (optionText)
                {
                    case "all":
                        ShowAllTags();
                        break;

                    case "allbyuser":
                        ShowAllTagsByUsername();
                        break;

                    case "allbyvideo":
                        ShowAllTagsByVideo();
                        break;

                    case "add":
                        AddNewTag();
                        break;

                    case "m":
                        keepdoing = false;
                        break;

                    default:
                        Console.WriteLine("Opció incorrecte, escriu una altra o 'm' per anar al menú principal");
                        break;
                }
            }

            ShowMainMenu();
        }


        private static void ShowTagsMenuOptions()
        {
            Console.WriteLine("--Menu de tags--");

            Console.WriteLine("Per veure tots els tags escriu --> all");
            Console.WriteLine("Per veure tots els tags x usuari escriu --> allbyuser");
            Console.WriteLine("Per veure tots els tags x video escriu --> allbyvideo");
            Console.WriteLine("Per afegir un tag escriu --> add");
            Console.WriteLine("Per tornar al menú principal escriu --> m");
        }


        static string GetTagFromInput()
        {
            Console.WriteLine("Introdueix el tag o 'sortir' per sortir");
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "sortir")
                    return null;

                ///////////////////////


                if (!Tag.ValidateTextTagFormat(input))
                {
                    Console.WriteLine(Tag.TextFormatError);
                    Console.WriteLine("Introdueix el nom del tag o 'sortir' per sortir");
                }
                else if (!Tag.ValidateTextTagDuplicated(input))
                {
                    Console.WriteLine($"{Tag.ValidateTextTagDuplicated(input)} {input}");
                    Console.WriteLine("Introdueix el nom del tag o 'sortir' per sortir");
                }
                else
                {
                    return input;
                }

                input = Console.ReadLine();

                //Console.WriteLine("Introdueix el nom o 'sortir' per anular");

            }
        }


        #endregion

        #region User CRUD

        static void ShowAllUsers()
        {
            foreach (var user in Users.Values)
            {
                Console.WriteLine($"{user.UserName} {user.Name} {user.Surname} {user.Password} {user.TimeStamp}");
            }
        }

        static void AddNewUser()
        {
            #region Todos los inputs del modelo van a pasar por aquí
            var validatedUsername = GetUsernameFromInput(CrudOptionsTypes.Add);
            if (string.IsNullOrEmpty(validatedUsername))
                return;

            var validatedName = GetNameFromInput();
            if (string.IsNullOrEmpty(validatedName))
                return;

            var validatedSurname = GetSurnameFromInput();
            if (string.IsNullOrEmpty(validatedSurname))
                return;

            var validatedPassword= GetPasswordFromInput();
            #endregion
            if (string.IsNullOrEmpty(validatedPassword))
                return;


            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = validatedUsername,
                Name = validatedName,
                Surname = validatedSurname,
                Password = validatedPassword,
                TimeStamp = DateTime.Now
            };
            Users.Add(user.Id, user);

            Console.WriteLine($"User with username:{validatedUsername} and name: {validatedName} successfully added.");

            ShowUsersMenuOptions();

        }

        private static void EditUser(string username)
        {
            #region Todos los inputs del modelo van a pasar por aquí
            var validatedUsername = GetUsernameFromInput(CrudOptionsTypes.Edit, username);
            if (string.IsNullOrEmpty(validatedUsername))
                return;

            var validatedName = GetNameFromInput();
            if (string.IsNullOrEmpty(validatedName))
                return;
            #endregion

            // forma a manijen
            User existingUser = null;
            foreach(var item in Users)
            {
                // item es un par clave-valor key-value donde value es un objeto de tipo User
                if (item.Value.UserName == username)
                {
                    existingUser.UserName = validatedUsername;
                    existingUser.Name = validatedName;
                }
            }


        }

        private static void DeleteUser(string username)
        {
            var validatedUsername = string.IsNullOrEmpty(username) ? GetUsernameFromInput(CrudOptionsTypes.Edit, username) : username;
            if (string.IsNullOrEmpty(validatedUsername))
                return;

            // LINQ
            var existingStudent = Users.Values.FirstOrDefault(x => x.UserName == username);
            if (existingStudent != null)
            {
                Users.Remove(existingStudent.Id);
                Console.WriteLine("User sucessfully deleted!");
            }
            else
            {
                Console.WriteLine($"User with username {username} not found");
            }
        }

        #endregion

        #region Video CRUD

        static void ShowAllVideos()
        {
            foreach (var video in Videos.Values)
            {
                Console.WriteLine($"{video.Title} {video.UrlVideo}");
            }
        }

        static void AddNewVideo()
        {
            #region Todos los inputs del modelo van a pasar por aquí

            var validatedUsername = GetUsernameFromInput(CrudOptionsTypes.DeleteOrView);
            if (string.IsNullOrEmpty(validatedUsername))
                return;

            var validatedName = GetVideoNameFromInput(CrudOptionsTypes.Add);
            if (string.IsNullOrEmpty(validatedName))
                return;

            var validatedUrl = GetVideoNameFromInput(CrudOptionsTypes.Add);
            if (string.IsNullOrEmpty(validatedUrl))
                return;
            #endregion


            var video = new Video
            {
                Id = Guid.NewGuid(),
                UserName = validatedUsername,
                Title = validatedName,
                UrlVideo = validatedUrl
            };

            Videos.Add(video.Id, video);

            Console.WriteLine($"Video {validatedName} successfully added.");
            ShowVideosMenuOptions();
        }

        private static void EditVideo(string name)
        {
            #region Todos los inputs del modelo van a pasar por aquí

            var validatedName = GetVideoNameFromInput(CrudOptionsTypes.Edit, name);
            if (string.IsNullOrEmpty(validatedName))
                return;

            #endregion


            // Usando LINQ
            var existingVideo = Videos.Values.FirstOrDefault(x => x.Title == name);
            if (existingVideo != null)
            {
                existingVideo.Title = validatedName;
                Console.WriteLine("Video updated ok!");
            }
            else
            {

                Console.WriteLine($"Video with name {validatedName} not found");
            }
        }

        private static void DeleteVideo(string name)
        {
            var validatedName = string.IsNullOrEmpty(name) ? GetVideoNameFromInput(CrudOptionsTypes.Edit, name) : name;
            if (string.IsNullOrEmpty(validatedName))
                return;

            // Usando LINQ
            var existingItem = Videos.Values.FirstOrDefault(x => x.Title == name);
            if (existingItem != null)
            {
                Videos.Remove(existingItem.Id);
                Console.WriteLine("Video sucessfully delete!");
            }
            else
            {

                Console.WriteLine($"Video with name {name} not found");
            }
        }

        #endregion

        #region Tags CRUD

        static void ShowAllTags()
        {
            foreach (var tag in Tags.Values)
            {
                Console.WriteLine($"video: {tag.Title} usuari: {tag.UserName} tag: {tag.TextTag}");
            }
        }

        static void ShowAllTagsByUsername()
        {
            var validatedUsername = GetUsernameFromInput(CrudOptionsTypes.DeleteOrView);
            if (string.IsNullOrEmpty(validatedUsername))
                return;
            foreach (var tag in Tags.Values)
            {
                if (tag.UserName == validatedUsername)
                    Console.WriteLine($"video: {tag.Title} usuari: {tag.UserName} tag: {tag.TextTag}");
            }
        }

        static void ShowAllTagsByVideo()
        {
            var validatedVideoName = GetVideoNameFromInput(CrudOptionsTypes.DeleteOrView);
            if (string.IsNullOrEmpty(validatedVideoName))
                return;
            foreach (var tag in Tags.Values)
            {
                if (tag.Title == validatedVideoName)
                    Console.WriteLine($"video: {tag.Title} usuari: {tag.UserName} tag: {tag.TextTag}");
            }
        }

        static void AddNewTag()
        {
            #region Todos los inputs del modelo van a pasar por aquí
            var validatedUsername = GetUsernameFromInput(CrudOptionsTypes.DeleteOrView);
            if (string.IsNullOrEmpty(validatedUsername))
                return;

            var validatedVideoName = GetVideoNameFromInput(CrudOptionsTypes.DeleteOrView);
            if (string.IsNullOrEmpty(validatedVideoName))
                return;

            var validatedTextTag = GetTagFromInput();
            if (validatedTextTag == null)
                return;

            #endregion

            var currentUser = Users.Values.FirstOrDefault(x => x.UserName == validatedUsername);

            if (currentUser == null)
            {
                Console.WriteLine($"No s'ha trobat cap usuari amb el username {validatedUsername}");
                ShowTagsMenuOptions();
                return;

            }

            var currentVideo = Videos.Values.FirstOrDefault(x => x.Title == validatedVideoName);
            if (currentVideo == null)
            {
                Console.WriteLine($"No s'ha trobat cap video amb el nom {validatedVideoName}");
                ShowTagsMenuOptions();
                return;

            }

            var tag = new Tag
            {
                Id = Guid.NewGuid(),
                //Video.User.UserName = currentUser,
                //Video = currentVideo,
                TextTag = validatedTextTag

            };
            Tags.Add(tag.Id, tag);



            Console.WriteLine($"Tag for user with username:{validatedUsername} and video: {validatedVideoName} successfully added with grade:{validatedTextTag}.");

            ShowTagsMenuOptions();

        }

        #endregion

 

        public static void LoadInitialData()
        {
            var pepe = new User
            {
                Id = Guid.NewGuid(),
                UserName = "12345678a",
                Name = "pepe",
                Surname = "gotera",
                Password = "pepo_pass",
                TimeStamp = DateTime.Now
            };
            var lolo = new User
            {
                Id = Guid.NewGuid(),
                UserName = "11111111a",
                Name = "lolo",
                Surname = "lelo",
                Password = "lelo_pass",
                TimeStamp = DateTime.Now
            };

            Users.Add(pepe.Id, pepe);
            Users.Add(lolo.Id, lolo);

            var video1 = new Video
            {
                Id = Guid.NewGuid(),
                UserName = "lolo",
                UrlVideo = "http://video1",
                Title = "Video de curso de C#"
            };

            var video2 = new Video
            {
                Id = Guid.NewGuid(),
                UserName = "pepe",
                UrlVideo = "http://video2",
                Title = "Programación"
            };

            Videos.Add(video1.Id, video1);
            Videos.Add(video2.Id, video2);

            var tag1_lolo = new Tag()
            {
                Id = Guid.NewGuid(),
                UserName = "lolo",
                Title = "Video de curso de C#",
                TextTag = "tag1_lolo"
            };
            var tag2_lolo = new Tag()
            {
                Id = Guid.NewGuid(),
                UserName = "lolo",
                Title = "Video de curso de C#",
                TextTag = "tag2_lolo"
            };

            var tag1_pepe = new Tag()
            {
                Id = Guid.NewGuid(),
                UserName = "pepe",
                Title = "Programación",
                TextTag = "tag1_pepe"
            };
            var tag2_pepe = new Tag()
            {
                Id = Guid.NewGuid(),
                UserName = "pepe",
                Title = "Programación",
                TextTag = "tag2_pepe"
            };


            Tags.Add(tag1_pepe.Id, tag1_pepe);
            Tags.Add(tag2_pepe.Id, tag2_pepe);
            Tags.Add(tag1_lolo.Id, tag1_lolo);
            Tags.Add(tag2_lolo.Id, tag2_lolo);
        }
    }

    public enum CrudOptionsTypes
    {
        Add,
        Edit,
        DeleteOrView
    }
}
