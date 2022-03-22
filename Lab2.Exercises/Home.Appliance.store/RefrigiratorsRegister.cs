using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class RefrigiratorsRegister
    {
        private List<Refrigirator> AllRefrigirators;
        public RefrigiratorsRegister()
        {
            AllRefrigirators = new List<Refrigirator>();
        }
        public RefrigiratorsRegister(List<Refrigirator> Refrigirators)
        {
            AllRefrigirators = new List<Refrigirator>();
            foreach (Refrigirator refrigirator in Refrigirators)
            {
                this.AllRefrigirators.Add(refrigirator);
            }
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public void Add(Refrigirator refrigirator)
        {
            AllRefrigirators.Add(refrigirator);
        }
         public int RefrigiratorCount()
         {
            return this.AllRefrigirators.Count;
         }
         public Refrigirator GetRefrigirator(int index)
         {
            return this.AllRefrigirators[index];
         }
         public bool Contains(Refrigirator refrigirator)
         {
            return AllRefrigirators.Contains(refrigirator);
         }
         public double FindsSmallestPriceOFStandingNoFreezer()
         {
             double minPrice = double.MaxValue;
             foreach (Refrigirator refrigirator in AllRefrigirators)
             {
                 if (refrigirator.MountingType.Contains("Pastatomas") && refrigirator.HasFreezer == HasFreezer.True && minPrice > refrigirator.Price)
                 {
                     minPrice = refrigirator.Price;
                 }
             }
             return minPrice;
         }
        public double FindsMaxPrice()
        {
            double maxPrice = double.MinValue;
            foreach (Refrigirator refrigirator in AllRefrigirators)
            {
                if (maxPrice < refrigirator.Price)
                {
                    maxPrice = refrigirator.Price;
                }
            }
            return maxPrice;
        }
        public RefrigiratorsRegister FilterByMaxPrice()
        {
            RefrigiratorsRegister Filtered = new RefrigiratorsRegister();
            foreach (Refrigirator refrigirator in AllRefrigirators)
            {
                if (refrigirator.Price == FindsMaxPrice())
                {
                    Filtered.Add(refrigirator);
                }
            }
            Filtered.ShopName = ShopName;
            return Filtered;
        }
    }
}
