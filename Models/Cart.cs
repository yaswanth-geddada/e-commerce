using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    class Cart
    {

        private string _itemName;
        private string _itemCategory;
        private float _itemPrice;

        public string ItemName { get => _itemName; set => _itemName = value; }
        public string ItemCategory { get => _itemCategory; set => _itemCategory = value; }
        public float ItemPrice { get => _itemPrice; set => _itemPrice = value; }

        public void Cart()
        {

        }

        public void Cart(_itemName, _itemCategory, _itemPrice)
        {
            this._itemName = _itemName;
            this._itemCategory = _itemCategory;
            this._itemPrice = _itemPrice;
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