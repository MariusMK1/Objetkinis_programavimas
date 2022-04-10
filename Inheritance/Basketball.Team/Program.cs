using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            //Reading and printing initial data
            PlayerContainer players = new PlayerContainer();
            StaffContainer staff = new StaffContainer();
            MemberContainer container1 = InOutUtils.ReadMembers(@"Duom.csv", players, staff);
            MemberContainer container2 = InOutUtils.ReadMembers(@"Duom2.csv", players, staff);
            MemberContainer container3 = InOutUtils.ReadMembers(@"Duom3.csv", players, staff);
            InOutUtils.PrintMembers(container1);
            InOutUtils.PrintMembers(container2);
            InOutUtils.PrintMembers(container3);
            // Finds members that attended in all camps
            MemberContainer filtered = container1.FindMembersInAllCamps(container2, container3);
            InOutUtils.PrintMembersInAllCamps(filtered);
            //Filtering players by positions and all coaches
            PlayerContainer FilteredByPosition = new PlayerContainer();
            players.FindPosition("Puolėjas", FilteredByPosition);
            InOutUtils.PrintPlayersByPosition(FilteredByPosition, "Puolėjas");
            StaffContainer Coaches = staff.FindCoach();
            InOutUtils.PrintCoaches(Coaches);
            //Sorting members by age
            Console.WriteLine("Surikiuoti stovyklū stovyklų dalyviai pagal amžių");
            container1.Sort(new MembersComparatorByAge());
            container2.Sort(new MembersComparatorByAge());
            container3.Sort(new MembersComparatorByAge());
            InOutUtils.PrintMembers(container1);
            InOutUtils.PrintMembers(container2);
            InOutUtils.PrintMembers(container3);
            //Fitering players who were selected to the national team
            PlayerContainer invited = players.FilterInvited();
            InOutUtils.PrintPlayersToCSVFile("Rinktinė.csv", invited);
            InOutUtils.PrintStaffToCSVFile("Personalas.csv", staff);
        }
    }
}
