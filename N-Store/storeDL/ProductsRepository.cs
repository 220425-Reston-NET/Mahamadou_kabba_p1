using System.Text.Json;
using storeModel;

namespace storeDL
{
    // what  should i use here instead of Ability
    public class ProductRespository : IRepository<Product>
    {
        private string _filepath = "../storeDL/Data/Products.json";
        public void Add(Product c_resource)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllCustomers()
        {
            string jsonString = File.ReadAllText(_filepath);
            List<Product> listOfProducts = JsonSerializer.Deserialize<List<Product>>(jsonString);
            return listOfProducts;
        }

        public void Update(Product c_resource)
        {
            throw new NotImplementedException();
        }
    }
}