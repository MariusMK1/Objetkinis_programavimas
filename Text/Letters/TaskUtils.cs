using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Letters
{
    class TaskUtils
    {
        internal static void Dazniai(string fv, RaidziuDazniai eil)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    eil.eil = line;
                    eil.kiek();
                }
            }
        }
    }
}
