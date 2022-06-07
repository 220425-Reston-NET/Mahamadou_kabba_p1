namespace storeModel
{
    public class CustomerOrders
    {

        public int orderId {get; set;}
        public string? ProductId {get; set;}
        public int quantity {get; set;}

        public override string ToString()
        {
             return $"===store info==\nID {orderId}\nName: {ProductId}\nAddress: {quantity}\n====";

        }
    }
}