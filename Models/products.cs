namespace ECommerce_Application
{
  class Products
  {
    public string Name { get; set; }
    public int prodId { get; set; }
    public int price { get; set; }
    public int vendorId { get; set; }
    public int quantity { get; set; }

    public Products()
    {

    }

    public Products(string name, int prodId, int price, int vendorId, int quantity)
    {
      this.Name = name;
      this.prodId = prodId;
      this.price = price;
      this.vendorId = vendorId;
      this.quantity = quantity;
    }
  }
}
