using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            StudentContainer container = InOutUtils.ReadStudents(@"Duom.txt");
            InOutUtils.PrintStudents(container);
            container.Sort();
            InOutUtils.PrintStudents(container);
        }
    }
}
