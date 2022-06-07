using System.ComponentModel.DataAnnotations;

namespace storeModel
{
    
    public class storefront
    {
        public int _storeId;
        public int storeID
        {
            get { return _storeId; }
            set{
                if (value > 0)
                {
                    _storeId = value;
                }
                else
                {
                    throw new ValidationException(" Nmae only contain latters");
                }
            }
        }


        public string storeName {get; set;}

        public string storeAddress {get; set;}   

        public List<Product> products {get; set;}
        public List<CustomerOrders> CustomerOrders { get; }
        public List<CustomerOrders> customerOders {get; set;} 

        public storefront()
         {
             storeID = 1;
             storeName = "KAW";
             storeAddress = "Fordham Rd";
             products = new List<Product>();
             CustomerOrders = new List<CustomerOrders>();


        }
        public override string ToString()
        {
            return $"===store info==\nID {storeID}\nName: {storeName}\nAddress: {storeAddress}\n====";
        }

    }

    

   
   
    
}