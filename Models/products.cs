namespace ECommerce_Application
{
    class products
    {
        public string Name { get; set; }
        public int prodId { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }

        public products(string name, int prodId, int price, int quantity)
        {
            this.Name = name;
            this.prodId = prodId;
            this.price = price;
            this.quantity = quantity;
        }
    }
}
