using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConversion
{
    class ProductV3
    {
        public ProductV3(int id, string name, double price, int count)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.count = count;
        }

        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int count { get; set; }

    }

    class ProductV2
    {
        public string name { get; set; }
        public double price { get; set; }
        public int count { get; set; }
    }
    class V2Data
    {
        public string version { get; set; }
        public Dictionary<int,ProductV2> products { get; set; }
    
    }
    class V3Data
    {
        public V3Data(string version, List<ProductV3> products)
        {
            this.version = version;
            this.products = products;
        }

        public string version { get; set; }
        public List<ProductV3> products { get; set; }

    }
}
