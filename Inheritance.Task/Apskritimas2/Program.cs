using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apskritimas2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Apskritimas apskritimasA = new Apskritimas(10);
            Console.WriteLine("Apskritimo A Duomenys: {0},", apskritimasA.ToString());
            Console.WriteLine("Apskritimo A ribojamas plotas: {0, 10:f3}", apskritimasA.Plotas());
            Apskritimas apskritimasB = new Apskritimas();
            Console.WriteLine("Apskritimo B Duomenys: {0},", apskritimasB.ToString());
            Console.WriteLine("Apskritimo B ribojamas plotas: {0, 10:f3}", apskritimasB.Plotas());
            Cilindras cilindrasA = new Cilindras();
            Console.WriteLine("Cilindro A Duomenys: {0},", cilindrasA.ToString());
            Console.WriteLine("Cilindro A turis = {0, 10:f3}", cilindrasA.Turis());
            Cilindras cilindrasB = new Cilindras(10, 50);
            Console.WriteLine("Cilindro B Duomenys: {0},", cilindrasB.ToString());
            Console.WriteLine("Cilindro B turis = {0, 10:f3}", cilindrasB.Turis());
            Cilindras cilindrasC = new Cilindras(10);
            Console.WriteLine("Cilindro C Duomenys: {0},", cilindrasC.ToString());
            Console.WriteLine("Cilindro C turis = {0, 10:f3}", cilindrasC.Turis());
        }
    }
}
