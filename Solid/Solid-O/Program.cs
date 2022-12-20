using System;

namespace Solid_O
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public interface IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Invoice { get; set; }
            public decimal GetPrice();
        }

        //utlizamos la interfaz para respetar la implementacion

        public class Water : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Invoice { get; set; }

            public decimal GetPrice()
            {
                return Price * Invoice;
            }
        }

        public class Alcohol : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Invoice { get; set; }
            public decimal Promo { get; set; }

            public decimal GetPrice()
            {
                return Invoice * Price - Promo;
            }

        }

        public class Sugary : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Invoice { get; set; }
            public decimal Expiration { get; set; }

            public decimal GetPrice()
            {
                return (Price * Invoice) - Expiration;
            }
        }

        public class Invoice
        {
            public decimal GetTotal(IEnumerable<IDrink> lstDrink)
            {
                decimal total = 0;
                foreach(var drink in lstDrink)
                {
                    total += drink.GetPrice();
                }
                return total;
            }
        }
    }
}
