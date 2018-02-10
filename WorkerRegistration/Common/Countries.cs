using System.Collections.Generic;
using System.Globalization;

namespace Common
{
    public static class Countries
    {
        // Call Load(), Then Use List

        public static List<string> List;

        public static bool Load()
        {
            try
            {
                string R;
                List = new List<string>();
                foreach (CultureInfo c in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    R = new RegionInfo(c.LCID).EnglishName;

                    if (List.Contains(R))
                        continue;

                    List.Add(R);
                }

                List.Sort();
                return true;
            }
            catch
            {
                List.Clear();
                return false;
            }
        }
    }
}