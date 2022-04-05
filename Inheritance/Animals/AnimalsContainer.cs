using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    internal class AnimalsContainer
    {
        private Animal[] animals;
        public int Count { get; private set; }
        public AnimalsContainer()
        {
            this.animals = new Animal[16]; //default capacity
        }
        public void Add(Animal animal)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.animals[this.Count++] = animal;
        }
        public void Put(int i, Animal animal)
        {
            this.Put(i, animal);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Animal animal)
        {
            if(this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.animals[i] = this.animals[i - 1];
            }
            this.animals[index] = animal;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Animal animal)
        {
            for(int i = 0; i < Count; i++)
            {
                if (this.animals[i].Equals(animal))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.animals[j] = this.animals[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for(int i = index; i < Count; i++)
            {
                this.animals[i] = this.animals[i + 1];
            }
            Count--;
        }
        public Animal Get (int index)
        {
            return this.animals[index];
        }
        public void Sort(AnimalsComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                    for(int i = 0; i < this.Count - 1; i++)
                {
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];
                    if (comparator.Compare(a,b) > 0)
                    {
                        this.animals[i] = b;
                        this.animals[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public void Sort()
        {
            Sort(new AnimalsComparator());
        }
        public bool Contains(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].Equals(animal))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public AnimalsContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.animals = new Dog[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Animal[] temp = new Animal[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.animals[i];
                }
                this.Capacity = minimumCapacity;
                this.animals = temp;
            }
        }
        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = animals[i];
                if (animal.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        public Animal FindOldestAnimal()
        {
            return this.FindOldestAnimal(this);
        }
        public Animal FindOldestAnimal(string breed)
        {
            AnimalsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestAnimal(Filtered);
        }
        private Animal FindOldestAnimal(AnimalsContainer Animals)
        {
            if(Animals.Count <= 0)
            {
                return null;
            }
            else
            {
                Animal oldest = Animals.Get(0);
                for (int i = 0; i < Animals.Count; i++)
                {
                    if (DateTime.Compare(Animals.Get(i).BirthDate, oldest.BirthDate) < 0)
                    {
                        oldest = Animals.Get(i);
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
        public AnimalsContainer FilterByBreed(string breed)
        {
            AnimalsContainer Filtered = new AnimalsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(this.Get(i));
                }
            }
            return Filtered;
        }
        private Animal FindDogByID(int ID)
        {
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = animals[i];
                if (animal.ID == ID)
                {
                    return animal;
                }
            }
            return null;
        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Animal animal = this.FindDogByID(vaccination.AnimalID);
                if (animal != null)
                {
                    if (vaccination > animal.LastVaccinationDate)
                    {
                        animal.LastVaccinationDate = vaccination.Date;
                    }
                }
            }
        }
        public AnimalsContainer FilterByVaccinationExpired()
        {
            AnimalsContainer Filtered = new AnimalsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = animals[i];
                if (animal.RequiresVaccination)
                {
                    Filtered.Add(animal);
                }
            }
            return Filtered;
        }
        public AnimalsContainer(AnimalsContainer container): this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public AnimalsContainer Intersect(AnimalsContainer other)
        {
            AnimalsContainer result = new AnimalsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal current = this.animals[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public int CountAggresiveDogs()
        {
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                Animal animal = this.Get(i);
                if (animal is Dog && (animal as Dog).Aggresive)
                {
                    count++;
                }
            }
            return count;
        }
    }
}   
