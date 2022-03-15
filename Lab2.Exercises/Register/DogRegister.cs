using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exercises.Register
{
    
    class DogsRegister
    {
        private List<Dog> AllDogs;
        public DogsRegister()
        {
            AllDogs = new List<Dog>();
        }
        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }
        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }
        public int DogsCount()
        {
            return this.AllDogs.Count;
        }
        public Dog GetDog(int index)
        {
            return this.AllDogs[index];
        }
        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }
        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in this.AllDogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed))        //uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }
        public List<Dog> FilterByBreed(string breed) 
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }
        public Dog FindOldestDog(string breed)
        {
            List<Dog> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }
        public Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0];
            for (int i = 0; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(Dogs[i].BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }
        private Dog FindDogByID(int ID)
        {
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            return null;
        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach(Vaccination vaccination in Vaccinations)
            {
                Dog dog = this.FindDogByID(vaccination.DogID);
                if (dog != null)
                {
                    if (vaccination > dog.LastVaccinationDate)
                    {
                        dog.LastVaccinationDate = vaccination.Date;
                    }
                }
            }
        }
        public List<Dog> FilterByVaccinationExpired()
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.requiresVaccination)
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }
        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }
    }
}
