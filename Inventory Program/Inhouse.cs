using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Program___C968___Seth_Meyer
{
    public class Inhouse : Part
    {
            private int machineID;

            public int MachineID
            {
                get { return machineID; }
                set { machineID = value; }
            }

            public Inhouse(int partID, string name, decimal price, int inStock, int min, int max)
            {
                PartID = partID;
                Name = name;
                Price = price;
                InStock = inStock;
                Min = min;
                Max = max;
            }

            public Inhouse (int partID, string name, decimal price, int inStock, int min, int max, int machineID)
            {
                PartID = partID;
                Name = name;
                Price = price;
                InStock = inStock;
                Min = min;
                Max = max;
                MachineID = machineID;
            }
    }
}
