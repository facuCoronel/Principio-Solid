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
                throw new NotImplementedException();
            }
        }


        public class Invoice
        {
            public decimal GetTotal(IEnumerable<IDrink> lstDrink)
            {
                decimal total = 0;
                foreach(var drink in lstDrink)
                {
                    total += drink.Price;
                }
                return total;
            }
        }
    }
}
