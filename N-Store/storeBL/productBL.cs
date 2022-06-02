using storeDL;
using storeModel;

namespace storeBL
{
    public class productBL : IproductBL
    {
        // =============== Dependacy Injection =========
        private IRepository<CustomerClass> _productRepo;
        public productBL(IRepository<CustomerClass> p_productRepo)
        {
            _productRepo = p_productRepo;

        }
        // ========================
        public List<CustomerClass> GetAllProduct()
        {
            return _productRepo.GetAllCustomers();

        }

        public CustomerClass SearchProductByName(string p_productName)
        {
            List<CustomerClass> currentListOfProduct = _productRepo.GetAllCustomers();

            foreach (CustomerClass productObj in currentListOfProduct)
            {
                if (productObj.CustomerName == p_productName)
                {
                    return productObj;
                }
            }

            // will retunr null if no product found
            return null;
        }
    }
}