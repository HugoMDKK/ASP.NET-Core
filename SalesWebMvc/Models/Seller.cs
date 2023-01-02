using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public int MyProperty { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Seller seller &&
                   Id == seller.Id &&
                   Name == seller.Name &&
                   Email == seller.Email &&
                   BaseSalary == seller.BaseSalary &&
                   BirthDate == seller.BirthDate &&
                   EqualityComparer<Department>.Default.Equals(Department, seller.Department) &&
                   MyProperty == seller.MyProperty;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
