using System.Collections.Generic;

namespace ECommerce_Application
{
    public class Orders
    {
        public int prodId { get; set; }
        public int UserId { get; set; }
        public int quantity { get; set; }

        public string status { get; set; }

        public Orders()
        {

        }

        public Orders(int prodId, int userId, int quantity , string Status)
        {
            this.prodId = prodId;
            this.UserId = userId;
            this.quantity = quantity;
            this.status = Status;
        }
        //int prodId, int custId, int quantity
        
    }
}