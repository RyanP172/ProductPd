using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPd.Data
{
    public interface IProductDataImported
    {
        public List<Product>? ImportProducts();
    }
    public class ProductImported : IProductDataImported
    {
        public List<Product>? ImportProducts()
        {
            string file = @"..\..\..\Import\Data.csv";
            using var sr = new StreamReader(file);
            var products = new List<Product>();
            string? line = sr.ReadLine();
            while (line != null)
            {
                string[] values = line.Split(',');
                var product = new Product()
                {
                    Id = int.Parse(values[0]),
                    Name = values[1],
                    PriceAmount = double.Parse(values[2]),
                    PriceDisplay = string.Format("${0:C}", values[2]),
                };
                products.Add(product);
                line = sr.ReadLine();

            }
            return products;
        }

        //public int Id { get; private set; }

    }
}
