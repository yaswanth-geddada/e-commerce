namespace ECommerce_Application
{
    class products
    {
        public string Name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }

        public products(string name,int price, int quantity)
        {
            this.Name = name;
            this.price = price;
            this.quantity = quantity;
        }
    }
}
