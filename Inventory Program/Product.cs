using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Inventory_Program___C968___Seth_Meyer
{
    public class Product
    {
        private int _productID;
        private string _name;
        private decimal _price;
        private int _inStock;
        private int _min;
        private int _max;

        public BindingList<Part> AssociatedParts = new BindingList<Part>();

        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int InStock
        {
            get { return _inStock; }
            set { _inStock = value; }
        }

        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public Product() { }

        public Product(int productID, string name, decimal price, int inStock, int min, int max)
        {
            _productID = productID;
            _name = name;
            _price = price;
            _inStock = inStock;
            _min = min;
            _max = max;
        }

        public void AddAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }

        public Part LookupAssoicatedPart(int partID)
        {
            foreach (Part part in AssociatedParts)
            {
                if (part.PartID == partID)
                {
                    return part;
                }
            }
            return null;
        }

        public bool RemoveAssociatedPart (int partID)
        {
            {
                bool check = false;
                foreach (Part part in AssociatedParts)
                {
                    if (part.PartID == partID)
                    {
                        AssociatedParts.Remove(part);
                        return check = true;
                    }
                    else check = false;
                }
                return check;
            }
        }
    }
}
