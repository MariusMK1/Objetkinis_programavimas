using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments
{
    class ApartmentRegister
    {
        private List<Apartment> AllApartments;
        public ApartmentRegister()
        {
            AllApartments = new List<Apartment>();
        }
        public ApartmentRegister(List<Apartment> Apartments)
        {
            AllApartments = new List<Apartment>();
            foreach (Apartment apartment in Apartments)
            {
                this.AllApartments.Add(apartment);
            }
        }
        public void Add(Apartment apartment)
        {
            AllApartments.Add(apartment);
        }
        public Apartment GetApartment(int index)
        {
            return this.AllApartments[index];
        }
        public bool Contains(Apartment apartment)
        {
            return AllApartments.Contains(apartment);
        }
        public int ApartmentCount()
        {
            return this.AllApartments.Count;
        }
        public double CountFloor(Apartment apartment)
        {
            int count = apartment.ApartmentNumber;      
            while (count > 27)      //Finds in whitch staircase the apartment is 
            {
                count -= 27;
            }
            return Math.Ceiling((double)count / 3);
        }
        public List<Apartment> Filter(int roomNo, int minFloor, int maxFloor, double MaxPrice)
        {
            List<Apartment> Filtered = new List<Apartment>();
            foreach (Apartment apartment in this.AllApartments)
            {
                if (apartment.RoomNumber == roomNo && CountFloor(apartment) >= minFloor && CountFloor(apartment) <= maxFloor && apartment.Price <= MaxPrice)
                {
                    Filtered.Add(apartment);
                }
            }
            return Filtered;
        }
    }
}
