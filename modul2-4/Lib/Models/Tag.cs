using System;
using System.Collections.Generic;
using System.Linq;

namespace modul2_4.Lib.Models
{
    class Tag : Video
    {
        #region Static Validations

        public static string TextFormatError = "El tag està buït o en un format incorrecte";


        public static bool ValidateTextTagFormat(string input)
        {
            return !(string.IsNullOrEmpty(input));
        }

        public static bool ValidateTextTagDuplicated(string input, string currentTextTag = "")
        {
            if (string.IsNullOrEmpty(currentTextTag) || (input != currentTextTag))
            {
                return !Program.Tags.Values.Any(x => x.TextTag == input);
            }
            return true;
        }



        #endregion

        //public User User { get; set; }
        public Video Video { get; set; }
        public string TextTag { get; set; }

        public Tag()
        {
        }


    }
}
