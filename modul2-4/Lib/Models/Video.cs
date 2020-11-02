using System;
using System.Collections.Generic;
using System.Linq;

namespace modul2_4.Lib.Models
{
    class Video : User
    {

        #region Static Validations

        public static string VideoNameFormatError = "El video està buït o en un format incorrecte";

        public static bool IsVideoNameValid(string videoName)
        {
            if (!ValidateVideoNameFormat(videoName))
                return false;

            return Program.Videos.Values.Any(x => x.Title == videoName);
        }

        public static bool ValidateVideoNameFormat(string input)
        {
            return !(string.IsNullOrEmpty(input));
        }

        public static bool ValidateVideoNameDuplicated(string input, string currentVideoName = "")
        {
            if (string.IsNullOrEmpty(currentVideoName) || (input != currentVideoName))
            {
                return !Program.Videos.Values.Any(x => x.Title == input);
            }
            return true;
        }


        #endregion

        public User User { get; set; }

        public string UrlVideo { get; set; }
        public string Title { get; set; }
        public List<Tag> Tags { get; set; }


        public Video()
        {
            Tags = new List<Tag>();
        }


        public bool AddTag(Tag tag)
        {
            //tag.Video = this;
            Tags.Add(tag);

            return true;
        }
        //public static implicit operator Video(Tag v)
        //{
            //throw new NotImplementedException();
        //}
    }
}