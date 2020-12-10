using System.Collections.Generic;

namespace ECommerce_Application
{
    class Orders
    {
        public int prodId { get; set; }
        public int UserId { get; set; }
        public int quantity { get; set; }

        public Orders()
        {

        }

        public Orders(int prodId, int userId, int quantity)
        {
            this.prodId = prodId;
            this.UserId = userId;
            this.quantity = quantity;
        }
        //int prodId, int custId, int quantity
        
    }
}