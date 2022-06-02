using storeDL;
using storeModel;

namespace storeBL
{
  // **** ask stephen what's going on here
public class MyStoreBL : IstoreBL
{
//   ======== Dependency Injection ==============
  private IRepository<CustomerClass> _storeRepo;
  public MyStoreBL(IRepository<CustomerClass> p_storeRepo)
    {
       _storeRepo = p_storeRepo;

    }

  public void AddToCustomerClass(CustomerClass p_customer)
  {
    //   logic  to update customer
      _storeRepo.Update(p_customer);
  }

        

        //   ================================

        public void AddCustomer(CustomerClass p_store)
{
    

    // Check if that customer (pokemon) already exist
    CustomerClass foundedCustomer = SearchCustomerByPhoneNumber(p_store.CustomerName);
    if (foundedCustomer == null)
    {
        _storeRepo.Add(p_store);
    
    }
    else
    {
        throw new Exception("Customer number already exist");
    }
}

       

        public CustomerClass SearchCustomerByPhoneNumber(string p_customerNumber)
  {
      List<CustomerClass> currentListOfCustomer = _storeRepo.GetAllCustomers();

      foreach(CustomerClass menuObject in currentListOfCustomer)
      {
        //   condition to check that customer name/phone number is similar
        if (menuObject.CustomerPhoneNumber == p_customerNumber)
        {
            return menuObject;
            
        }
      }
    //   will return null or no value if no customer found
    return null;
  }

        public void AddProductToCustomer(CustomerClass foundedCustomer)
        {
            throw new NotImplementedException();
        }

        public List<CustomerClass> GetAllCustomer()
        {
            return _storeRepo.GetAllCustomers();
        }
      //  why addCustomer got created again if i already have it
      
        
    }
}
