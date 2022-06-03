using System.Text.Json;
using storeModel;

namespace storeDL
{
    // this class is responsible for storeing and read our data
    public class storeRepository :IRepository<CustomerClass>
   {
    //    establish a file path in this class
          private static string _filepath = "../storeDL/Data/store.json";

    //  now you create a method => purpose of this method is to add a customer to our Data
    // using class from store model
         public  void Add(CustomerClass _customer)
            {
                 //   use list collection
              List<CustomerClass> listOfCustomers = GetAllCustomers();
              listOfCustomers.Add(_customer);
              //  now we creat json-string to use jsonSerializer **Serializer
              // add new JsonSerializerOption{WriteIndented = true} next to customersList to mkae it look nice
              string jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{WriteIndented = true});
              //  this is where we use File.writeAllText to to creat our filw
              File.WriteAllText(_filepath, jsonString);

            }

            // method add more customers instead of replacing them/ overwritiing
            public  List<CustomerClass> GetAllCustomers()
            {
               // string to readalltex
               string jsonString = File.ReadAllText(_filepath);
               // now covert the json string to C# object that C# understands ** Deserializer
               List<CustomerClass> listOfCustomers = JsonSerializer.Deserialize<List<CustomerClass>>(jsonString);

                return listOfCustomers;
            }

        public Task<List<CustomerClass>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerClass c_recources)
            {
               // current information from the db
               List<CustomerClass> listOfCustomers = GetAllCustomers();

               // fiind  the matching customer object in the db
               foreach(CustomerClass menuObject in listOfCustomers)
               {
                  // condition to find the customer object in the db system
                  if (menuObject.CustomerPhoneNumber == c_recources.CustomerPhoneNumber )
                  {
                     // saves this information to the database
                     // stephen have Abilities here as  CustomerPhone
                     menuObject.CustomerPhoneNumber = c_recources.CustomerPhoneNumber;
                      
                  }
               }

               // save this information to the database
               string jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{WriteIndented = true});
               File.WriteAllText(_filepath, jsonString);
            }
    
   }



}
