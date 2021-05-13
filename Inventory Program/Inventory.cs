using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Program___C968___Seth_Meyer
{
    class Inventory
    {
        public static BindingList<Part> Parts = new BindingList<Part>();
        public static BindingList<Product> Products = new BindingList<Product>();

        public static void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public static bool RemoveProduct(int productID)
        {
            bool check = false;
            foreach (Product p in Products)
            {
                if (productID == p.ProductID)
                {
                    Products.Remove(p);
                    check = true;
                }
                else
                {
                    MessageBox.Show("Product does not exist.");
                    check = false;
                }
            }
            return check;
        }

        public static Product LookupProduct(int productID)
        {
            foreach (Product p in Products)
            {
                if (p.ProductID == productID)
                {
                    return p;
                }
            }
            return null;
        }

        public static void UpdateProduct(int productID, Product product)
        {
            foreach(Product p in Products)
            {
                if (productID == p.ProductID)
                {
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.InStock = product.InStock;
                    p.Min = product.Min;
                    p.Max = product.Max;
                    return;
                }
            }
        }

        public static void AddPart(Part part)
        {
            Parts.Add(part);
        }

        public static bool DeletePart(Part part)
        {
            bool check = false;
            foreach (Part p in Parts)
            {
                if (p.PartID == part.PartID)
                {
                    Parts.Remove(p);
                    check = true;
                }
                else
                {
                    MessageBox.Show("Part does not exist.");
                    check = false;
                }
            }
            return check;
        }

        public static Part LookupPart(int partID)
        {
            foreach (Part p in Parts)
            {
                if (p.PartID == partID)
                {
                    return p;
                }
            }
            return null;
        }

        public static void UpdatePart(int partID, Part part)
        {
            foreach(Part p in Parts)
            {
                if (p.PartID == partID)
                {
                    p.PartID = part.PartID;
                    p.Name = part.Name;
                    p.Price = part.Price;
                    p.InStock = part.InStock;
                    p.Min = part.Min;
                    p.Max = part.Max;
                    return;
                }
            }
        }




    }
}
