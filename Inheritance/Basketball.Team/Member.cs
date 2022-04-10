using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    public abstract class Member
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Member (string type, string name, string lastName, DateTime birthDate)
        {
            this.Type = type;
            this.Name = name;
            this.LastName = lastName;
            this.BirthDate = birthDate;
        }
        public int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - this.BirthDate.Year;
            if (this.BirthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
        public override bool Equals(object other)
        {
            return this.LastName == ((Member)other).LastName;
        }
        public override int GetHashCode()
        {
            return this.LastName.GetHashCode();
        }
        public int CompareTo(Member other)
        {
            int studentcomp = other.Name.CompareTo(this.Name);
            if (studentcomp == 0)
            {
                int result = this.LastName.CompareTo(other.LastName);
                if (result == 0)
                {
                }
                return result;
            }
            return studentcomp;
        }
    }
}
