using System.Collections.Generic;

namespace JsonConversion
{
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