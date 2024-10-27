using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctvrtletni_projekt_obp
{
    public class Inventory
    {
        public List<Product> Products { get; set; }
        public int PocetProduktu { get { return Products.Count; } }

        public Inventory()
        {
            Products = new List<Product>();
        }

        public void AddProduct(string name, double cena)
        {
            Products.Add(new Product { Name = name, Cena = cena });
        }
        public void RemoveProduct(string name)
        {
            Products.RemoveAll(product => product.Name == name);
        }
    }
}