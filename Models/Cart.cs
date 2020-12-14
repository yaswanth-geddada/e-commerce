using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Application
{
  class Cart
  {

    private int _userId;
    private int _itemId;
    private string _itemName;
    private int _itemQuantity;
    private int _itemPrice;

    public int ItemId { get => _itemId; set => _itemId = value; }
    public int UserId { get => _userId; set => _userId = value; }
    public string ItemName { get => _itemName; set => _itemName = value; }
    public int ItemPrice { get => _itemPrice; set => _itemPrice = value; }
    public int ItemQuantity { get => _itemQuantity; set => _itemQuantity = value; }

    public Cart()
    {

    }

    public Cart(int argItemId, int argUserId, string argItemName, int _itemQuantity, int argItemPrice)
    {
      this._itemId = argItemId;
      this._userId = argUserId;
      this._itemName = argItemName;
      this._itemPrice = argItemPrice;
      this._itemQuantity = _itemQuantity;
    }

    public override bool Equals(object obj)
    {
      return base.Equals(obj);
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}