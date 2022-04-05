using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime LastVaccinationDate { get; set; }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (this.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
        public abstract bool RequiresVaccination { get; }
        public Animal(int id, string name, string breed, DateTime birthDate, Gender gender)
        {
            this.ID = id;
            this.Name = name;
            this.Breed = breed;
            this.BirthDate = birthDate;
            this.Gender = gender;
        }
        public override bool Equals(object other)
        {
            return this.ID == ((Animal)other).ID;
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
        public int CompareBreed(Animal other)
        {
            return this.Breed.CompareTo(other.Breed);
        }
        public int CompareGender(Animal other)
        {
            return this.Gender.CompareTo(other.Gender);
        }
        public int CompareTo(Animal other)
        {
            int dogcomp = this.Gender.CompareTo(other.Gender);
            if (dogcomp == 0)
            {
                int result = this.Breed.CompareTo(other.Breed);
                if (result == 0)
                {
                }
                return result;
            }
            return dogcomp;
        }
    }
}
