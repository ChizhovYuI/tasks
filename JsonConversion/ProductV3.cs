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
}