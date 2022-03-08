using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muziejai
{
    internal class TaskUtils
    {
        public static int HowManyHaveGuide(List<Museum> Museums, string City)
        {
            int count = 0;
            foreach (Museum museum in Museums)
            {
                if(museum.City.Contains(City))
                    if (museum.Guide == "turi")
                    {
                        count++;
                    }
            }
                return count;
        }
        public static List<string> FindTypesInCityOnDay(List<Museum> Museums, string City, int day)
        {
            List<string> Types = new List<string>();
            foreach (Museum museum in Museums)
            {
                if (museum.City.Contains(City))
                {
                    if (museum.Week[day] == 1)
                    {
                        string type = museum.Type;
                        if (!Types.Contains(type))        //uses List method Contains()
                        {
                            Types.Add(type);
                        }
                    }
                }
            }
            return Types;
        }
        public static List<Museum> NotLessThanTwoDays(List<Museum> Museums, string City)
        {
            List<Museum> NotLessThanTwoDays = new List<Museum>();
            foreach (Museum museum in Museums)
            {
                if (museum.City.Contains(City))
                {
                    int sum = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        if (museum.Week[i] == 1)
                        {
                            sum++;
                        }
                    }
                    if (sum > 2)
                    {
                        NotLessThanTwoDays.Add(museum);
                    }

                }
            }
            return NotLessThanTwoDays;
        }
    }
}
