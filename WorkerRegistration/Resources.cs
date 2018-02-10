using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkerRegistration
{
    public static class Resources
    {
        public static List<string> Genders = new List<string> { { "Male" }, { "Female" }, { "Not Specified" } };

        public static List<string> Languages = new List<string>();

        public static bool LoadLanguages()
        {
            var AllLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures)
                .Select(c => c.DisplayName).ToList();

            Languages.Add("English");

            foreach (var lang in AllLanguages)
            {
                if (!Languages.Contains(lang))
                {
                    if (!lang.Contains('('))
                        Languages.Add(lang);

                }
            }

            if (Languages.Count != 0)
                return true;
            else return false;
        }
    }
}