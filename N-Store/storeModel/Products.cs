namespace storeModel
{
    public class Product
    {
        // declearing variable/ properties
        // connect this with your store => quantity if more than want you have in store =sold out
        public string Name { get; set; }
        public int productInStock { get; set; }

        // validate product in stock 
        private int _productAmount;
        public int ProductAmount
        {
            get { return _productAmount; }
            set
             { 
                _productAmount = value; 
                if (value > 0)
                {
                    _productAmount = value;
                }
                else
                {
                    Console.WriteLine("number of products have to be greater than zero");
                }
             }
        }
        
        public int productId { get; set; }

        public override string ToString()
        {
            return $"Name : {Name}\nproductId: {productId}";
        }

    }
}