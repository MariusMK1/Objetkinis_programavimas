using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments
{
    internal class Apartment
    {
        public int ApartmentNumber { get; set; }
        public double Area { get; set; }
        public int RoomNumber { get; set; }
        public double Price { get; set; }
        public int PhoneNumber { get; set; }
        public Apartment(int apartmentNumber, double area, int roomNumber, double price, int phoneNumber)
        {
            this.ApartmentNumber = apartmentNumber;
            this.Area = area;
            this.RoomNumber = roomNumber;
            this.Price = price;
            this.PhoneNumber = phoneNumber;
        }
    }
}
