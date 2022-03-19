using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Basketball.Team
{
    internal class InOutUtils
    {
        public static PlayerRegister ReadPlayers(string fileName)
        {
            PlayerRegister Players = new PlayerRegister();
            StreamReader read = new StreamReader(fileName);
            string Year = read.ReadLine();
            DateTime startDate = DateTime.Parse(read.ReadLine());
            DateTime endDate = DateTime.Parse(read.ReadLine());
            string lines;

            while ((lines = read.ReadLine()) != null)
            {
                string[] Values = lines.Split(';');
                string name = Values[0];
                string lastName = Values[1];
                DateTime birthDate = DateTime.Parse(Values[2]);
                int height = int.Parse(Values[3]);
                string position = Values[4];
                string team = Values[5];
                InvitedOrNot invitedOrNot;
                Enum.TryParse(Values[6], out invitedOrNot);
                Captain captain;
                Enum.TryParse(Values[7], out captain);
                Player player = new Player(name, lastName, birthDate, height, position, team, invitedOrNot, captain);
                if (!Players.Contains(player))
                {
                    Players.Add(player);
                }
            }
            return Players;
        }
        public static void PrintPlayers(PlayerRegister register)
        {
            Console.WriteLine(new string('-', 122));
            Console.WriteLine("| {0,-8} | {1,-10} | {2,-12} | {3,-4} | {4,-17} | {5,-15} | {6,-16} | {7,-15} |", "Vardas", "Pavardė", "Gimimo data", "Ūgis", "Pozicija", "Klubas", "Pakviestas ar ne", "Kapitonas ar ne");
            Console.WriteLine(new string('-', 122));



            for (int i = 0; i < register.PlayersCount(); i++)
            {
                Console.WriteLine("| {0,-8} | {1,-10} | {2,-12:yyyy-MM-dd} | {3,-4} | {4,-17} | {5,-15} | {6,-16} | {7,-15} |", register.GetPlayer(i).Name, register.GetPlayer(i).LastName, register.GetPlayer(i).BirthDate, register.GetPlayer(i).Height, register.GetPlayer(i).Position, register.GetPlayer(i).Team, register.GetPlayer(i).InvitedOrNot, register.GetPlayer(i).Captain);
            }
            Console.WriteLine(new string('-', 122));
            Console.WriteLine();
        }
        public static void PrintPlayersByPosition(List<Player> Filtered, string position)
        {
            if(Filtered.Count() > 0)
            {
                Console.WriteLine("Žaidėjų kurių pozicija yra {0} sąrašas:", position);
                Console.WriteLine(new string('-', 32));
                Console.WriteLine("| {0,-8} | {1,-10} | {2,-4} |", "Vardas", "Pavardė", "Ūgis");
                Console.WriteLine(new string('-', 32));
                foreach(Player player in Filtered)
                {
                    Console.WriteLine("| {0,-8} | {1,-10} | {2,-4} |", player.Name, player.LastName, player.Height);
                }
                Console.WriteLine(new String('-', 32));
            }
            else
            {
                Console.WriteLine("{0} pozicijos žaidėjų nėra: ", position);
            }
            Console.WriteLine();
        }
        public static void PrintClubsToCSVFile(string fileName, List<string> Clubs)
        {
            string[] lines = new string[Clubs.Count() + 1];
            lines[0] = string.Format("{0}", "Klubai");
            int i = 0;
            foreach (string club in Clubs)
            {
                lines[i + 1] = String.Format("{0}", club);
                i++;
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
