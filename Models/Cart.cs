using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Application
{
    class Cart
    {

        private string _itemName;
        private string _itemCategory;
        private float _itemPrice;

        public string ItemName { get => _itemName; set => _itemName = value; }
        public string ItemCategory { get => _itemCategory; set => _itemCategory = value; }
        public float ItemPrice { get => _itemPrice; set => _itemPrice = value; }

        public Cart()
        {

        }

        public Cart(string argItemName,string argItemCategory,float argItemPrice)
        {
            this._itemName = argItemName;
            this._itemCategory = argItemCategory;
            this._itemPrice = argItemPrice;
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