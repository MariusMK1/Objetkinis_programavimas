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
        public static List<Player> ReadPlayers(string fileName)
        {
            List<Player> Players = new List<Player>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
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
                Players.Add(player);
            }
            return Players;
        }
        public static void PrintPlayers(List<Player> Players)
        {
            Console.WriteLine(new String('-', 122));
            Console.WriteLine("| {0,-8} | {1,-10} | {2,-12} | {3,-4} | {4,-17} | {5,-15} | {6,-16} | {7,-15} |", "Vardas", "Pavardė", "Gimimo data", "Ūgis", "Pozicija", "Klubas", "Pakviestas ar ne", "Kapitonas ar ne");
            Console.WriteLine(new String('-', 122));
            foreach (Player player in Players)
            {
                Console.WriteLine("| {0,-8} | {1,-10} | {2,-12:yyyy-MM-dd} | {3,-4} | {4,-17} | {5,-15} | {6,-16} | {7,-15} |", player.Name, player.LastName, player.BirthDate, player.Height, player.Position, player.Team, player.InvitedOrNot, player.Captain);
            }
            Console.WriteLine(new String('-', 122));
        }
        public static void PrintPlayersByPosition(List<Player> Players, string position)
        {
            if(Players.Count > 0)
            {
                Console.WriteLine(new String('-', 32));
                Console.WriteLine("| {0,-8} | {1,-10} | {2,-4} |", "Vardas", "Pavardė", "Ūgis");
                Console.WriteLine(new String('-', 32));
                foreach (Player player in Players)
                {
                    Console.WriteLine("| {0,-8} | {1,-10} | {2,-4} |", player.Name, player.LastName, player.Height);
                }
                Console.WriteLine(new String('-', 32));
            }
            else
            {
                Console.WriteLine("{0} pozicijos žaidėjų nėra: ", position);
            }
        }
        public static void PrintInvitedPlayersToCSVFile(string fileName, List<Player> Players)
        {
            if (!Players.Count.Equals(0))
            {
                string[] lines = new string[Players.Count + 1];
                lines[0] = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};", "Vardas", "Pavardė", "Gimimo data", "Ūgis", "Pozicija", "Klubas", "Pakviestas ar ne", "Kapitonas ar ne");
                for (int i = 0; i < Players.Count; i++)
                {
                    lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};", Players[i].Name, Players[i].LastName, Players[i].BirthDate, Players[i].Height, Players[i].Position, Players[i].Team, Players[i].InvitedOrNot, Players[i].Captain);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[Players.Count + 1];
                lines[0] = string.Format("Atrinktų į rimktinę žaidėjų nėra");
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
    }
}
