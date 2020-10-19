using System;
using System.Collections.Generic;
using System.Linq;

namespace modul2_4.Lib.Models
{
    class User : Entity
    {

        #region Static Validations

        public static string UsernameFormatError = "El username está en un formato incorrecto";
        public static string NameFormatError = "El username está vacío o en un formato incorrecto";



        public static bool IsUsernameValid(string username)
        {
            if (!ValidateUsernameFormat(username))
                return false;

            return Program.Users.Values.Any(x => x.UserName == username);
        }


        public static bool ValidateUsernameFormat(string input)
        {
            return !(string.IsNullOrEmpty(input));
        }

        public static bool ValidateUsernameDuplicated(string input, string currentUsername = "")
        {
            if (string.IsNullOrEmpty(currentUsername) || (input != currentUsername))
            {
                return !Program.Users.Values.Any(x => x.UserName == input);
            }
            return true;
        }

        public static bool ValidateNameFormat(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        #endregion

        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public string Surname { get; set; }

        public List<Video> Videos { get; set; }


        public DateTime TimeStamp { get; set; }

        public User()
        {
            Videos = new List<Video>();
        }


        public bool AddVideo(Video video)
        {
            video.User = this;
            Videos.Add(video);

            return true;
        }

        //public static implicit operator User(Video v)
        //{
            //throw new NotImplementedException();
        //}
    }
}


