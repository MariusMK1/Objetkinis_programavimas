using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turistai
{
    internal class TaskUtils
    {
        public static double SumContributions(List<Tourist> tourists)
        {
            double sumContribution = 0;
            foreach (Tourist tourist in tourists)
            {
                double contribution = tourist.Money * 0.25;
                sumContribution += contribution;
            }
            return sumContribution;
        }
        public static double MaxContribution(List<Tourist> tourists)
        {
            double max = 0;
            foreach (Tourist tourist in tourists)
            {
                double contribution = tourist.Money * 0.25;
                if (contribution > max)
                    max = contribution;
            }
            return max;
        }
        public static List<Tourist> FilterByMaxContribution(List<Tourist> tourists)
        {
            List<Tourist> filtered = new List<Tourist>();
            foreach (Tourist tourist in tourists)
            {
                double contribution = tourist.Money * 0.25;
                if (contribution == MaxContribution(tourists))
                    filtered.Add(tourist);
            }
            return filtered;
        }
    }
}
