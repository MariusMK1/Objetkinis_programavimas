using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exercises.Register
{
    internal class DogsContainer
    {
        private Dog[] dogs;
        public int Count { get; private set; }
        public DogsContainer()
        {
            this.dogs = new Dog[16]; //default capacity
        }
        public void Add(Dog dog)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.dogs[this.Count++] = dog;
        }
        public void Put(int i, Dog dog)
        {
            this.Put(i, dog);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Dog dog)
        {
            if(this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.dogs[i] = this.dogs[i - 1];
            }
            this.dogs[index] = dog;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Dog dog)
        {
            for(int i = 0; i < Count; i++)
            {
                if (this.dogs[i].Equals(dog))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.dogs[j] = this.dogs[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for(int i = index; i < Count; i++)
            {
                this.dogs[i] = this.dogs[i + 1];
            }
            Count--;
        }
        public Dog Get (int index)
        {
            return this.dogs[index];
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                    for(int i = 0; i < this.Count - 1; i++)
                {
                    Dog a = this.dogs[i];
                    Dog b = this.dogs[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.dogs[i] = b;
                        this.dogs[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Dog dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Equals(dog))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public DogsContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.dogs = new Dog[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Dog[] temp = new Dog[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.dogs[i];
                }
                this.Capacity = minimumCapacity;
                this.dogs = temp;
            }
        }
        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                Dog dog = dogs[i];
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this);
        }
        public Dog FindOldestDog(string breed)
        {
            DogsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }
        private Dog FindOldestDog(DogsContainer Dogs)
        {
            if(Dogs.Count <= 0)
            {
                return null;
            }
            else
            {
                Dog oldest = Dogs.Get(0);
                for (int i = 0; i < Dogs.Count; i++)
                {
                    if (DateTime.Compare(Dogs.Get(i).BirthDate, oldest.BirthDate) < 0)
                    {
                        oldest = Dogs.Get(i);
                    }
                }
                return oldest;
            }
        }
        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < this.Count; i++)
            {
                string breed = this.Get(i).Breed;
                if (!Breeds.Contains(breed))        //uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }
        public DogsContainer FilterByBreed(string breed)
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(this.Get(i));
                }
            }
            return Filtered;
        }
        private Dog FindDogByID(int ID)
        {
            for (int i = 0; i < this.Count; i++)
            {
                Dog dog = dogs[i];
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            return null;
        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
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
        public DogsContainer FilterByVaccinationExpired()
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Dog dog = dogs[i];
                if (dog.requiresVaccination)
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }
        public DogsContainer(DogsContainer container): this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public DogsContainer Intersect(DogsContainer other)
        {
            DogsContainer result = new DogsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Dog current = this.dogs[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}   
