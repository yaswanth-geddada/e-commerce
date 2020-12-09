using System.Collections.Generic;

namespace ECommerce_Application
{
    class orders
    {
        public int prodId { get; set; }
        public int UserId { get; set; }
        public int quantity { get; set; }

        public orders()
        {

        }

        public orders(int prodId, int userId, int quantity)
        {
            this.prodId = prodId;
            this.UserId = userId;
            this.quantity = quantity;
        }
        //int prodId, int custId, int quantity
        
    }
}