namespace ECommerce_Application
{
  class CartService
  {

    private static CartAdo _cart = new CartAdo();

    public static void AddToCart(Cart cart)
    {
      CartAdo.AddToCart(cart);
    }

    public static Cart[] GetCartList()
    {

      return CartAdo.GetCartList();

    }
  }
}