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
        public static MemberContainer ReadMembers(string fileName, PlayerContainer Players, StaffContainer  Staff)
        {
            MemberContainer Members = new MemberContainer();
            StreamReader read = new StreamReader(fileName, Encoding.UTF8);
            int Year = int.Parse(read.ReadLine());
            DateTime startDate = DateTime.Parse(read.ReadLine());
            DateTime endDate = DateTime.Parse(read.ReadLine());
            Members.Year = Year;
            string lines;

            while ((lines = read.ReadLine()) != null)
            {
                string[] Values = lines.Split(';');
                string type = Values[0];
                string name = Values[1];
                string lastName = Values[2];
                DateTime birthDate = DateTime.Parse(Values[3]);
                switch (type)
                {
                    case "Player":
                        int height = int.Parse(Values[4]);
                        string position = Values[5];
                        string team = Values[6];
                        InvitedOrNot invitedOrNot;
                        Enum.TryParse(Values[7], out invitedOrNot);
                        Captain captain;
                        Enum.TryParse(Values[8], out captain);
                        Player player = new Player(type, name, lastName, birthDate, height, position, team, invitedOrNot, captain);
                        if (!Members.Contains(player))
                        {
                            Members.Add(player);
                        }
                        if (!Players.Contains(player))
                        {
                            Players.Add(player);
                        }
                        break;
                    case "Staff":
                        string duty = Values[4];
                        Staff staff = new Staff(type, name, lastName, birthDate, duty);
                        if (!Members.Contains(staff))
                        {
                            Members.Add(staff);
                        }
                        if (!Staff.Contains(staff))
                        {
                            Staff.Add(staff);
                        }
                        break;
                    default:
                        break; //unknown type
                }
            }
            return Members;
        }
        public static void PrintMembers(MemberContainer container)
        {
            Console.WriteLine("Stovykla {0}", container.Year);
            Console.WriteLine(new string('-', 51));
            Console.WriteLine("| {0,-8} | {1,-8} | {2,-10} | {3,-12} |", "Tipas", "Vardas", "Pavardė", "Gimimo data");
            Console.WriteLine(new string('-', 51));



            for (int i = 0; i < container.Count; i++)
            {
                Member member = container.Get(i);
                Console.WriteLine("| {0,-8} | {1,-8} | {2,-10} | {3,-12:yyyy-MM-dd} |",member.Type, member.Name, member.LastName, member.BirthDate);
            }
            Console.WriteLine(new string('-', 51));
            Console.WriteLine();
        }
        public static void PrintMembersInAllCamps(MemberContainer container)
        {
            if (container.Count > 0)
            {
                Console.WriteLine("dalyvavę visose trijose stovyklose:");
                Console.WriteLine(new string('-', 51));
                Console.WriteLine("| {0,-8} | {1,-8} | {2,-10} | {3,-12} |", "Tipas", "Vardas", "Pavardė", "Gimimo data");
                Console.WriteLine(new string('-', 51));
                for (int i = 0; i < container.Count; i++)
                {
                    Member member = container.Get(i);
                    Console.WriteLine("| {0,-8} | {1,-8} | {2,-10} | {3,-12:yyyy-MM-dd} |", member.Type, member.Name, member.LastName, member.BirthDate);
                }
                Console.WriteLine(new string('-', 51));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Dalyvavusių visose stovyklose nėra");
            }
        }
        public static void PrintPlayersByPosition(PlayerContainer Filtered, string position)
        {
            if (Filtered.Count > 0)
            {
                Console.WriteLine("Žaidėjų kurių pozicija yra {0} sąrašas:", position);
                Console.WriteLine(new string('-', 32));
                Console.WriteLine("| {0,-8} | {1,-10} | {2,-4} |", "Vardas", "Pavardė", "Ūgis");
                Console.WriteLine(new string('-', 32));
                for (int i = 0; i < Filtered.Count; i++)
                {
                    Player player = Filtered.Get(i);
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
        public static void PrintCoaches(StaffContainer coaches)
        {
            if (coaches.Count > 0)
            {
                Console.WriteLine("Trenerių sąrašas:");
                Console.WriteLine(new string('-', 25));
                Console.WriteLine("| {0,-8} | {1,-10} |", "Vardas", "Pavardė");
                Console.WriteLine(new string('-', 25));
                for (int i = 0; i < coaches.Count; i++)
                {
                    Staff coach = coaches.Get(i);
                    Console.WriteLine("| {0,-8} | {1,-10} |", coach.Name, coach.LastName);
                }
                Console.WriteLine(new String('-', 25));
            }
            else
            {
                Console.WriteLine("Trenerių nėra");
            }
            Console.WriteLine();
        }
        public static void PrintPlayersToCSVFile(string fileName, PlayerContainer container)
        {
            if (container.Count != 0)
            {
                string[] lines = new string[container.Count + 1];
                lines[0] = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", "Vardas", "Pavardė", "Gimimo data", "Ūgis", "Pozicija", "Klubas", "Pakviestas ar ne", "Kapitonas ar ne");
                for (int i = 0; i < container.Count; i++)
                {
                    Player player = container.Get(i);
                    lines[i + 1] = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", player.Name, player.LastName, player.BirthDate, player.Height, player.Position, player.Team, player.InvitedOrNot, player.Captain);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[container.Count + 1];
                lines[0] = string.Format("{0}", "Pakviestų į rinktinę žaidėjų nėra");
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
        public static void PrintStaffToCSVFile(string fileName, StaffContainer container)
        {
            if (container.Count != 0)
            {
                string[] lines = new string[container.Count + 1];
                lines[0] = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", "Vardas", "Pavardė", "Gimimo data", "Ūgis", "Pozicija", "Klubas", "Pakviestas ar ne", "Kapitonas ar ne");
                for (int i = 0; i < container.Count; i++)
                {
                    Staff staff = container.Get(i);
                    lines[i + 1] = string.Format("{0};{1};{2};{3};{4}", staff.Type, staff.Name, staff.LastName, staff.BirthDate, staff.Duties);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[container.Count + 1];
                lines[0] = string.Format("Pakviestų į rinktinę personalo nėra");
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
    }
}
