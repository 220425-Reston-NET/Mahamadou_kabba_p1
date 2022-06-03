// using storeDL;
using storeBL;
using storeModel;

public class SearchCustomer : IMenu
{

     public static CustomerClass foundedCustomer; 
    

    // ===== Dependecy Injection ========
    private IstoreBL _storeBL;

    public SearchCustomer(IstoreBL p_storeBL)
    {
        _storeBL = p_storeBL;
    }

    // =============================
    public void Display()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("------------------- Hooray, welcome back ---------------------");
        Console.WriteLine("      How would you like to look up your information ?");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine(" ");
        Console.WriteLine("[2] - Search by Customer Name");
        Console.WriteLine("[2] - Search by Customer Phone Number");
        Console.WriteLine("[0] - Exit");
    }

    public string YourChoice()
    {
        string userInput = Console.ReadLine();
        if (userInput == "2")
        {
            Console.WriteLine("Enter customer phone number: ");
            string CustomerNumber = Console.ReadLine();

            foundedCustomer = _storeBL.SearchCustomerByPhoneNumber(CustomerNumber);
            
            // Condition to only display customer info if it found a customer
            if (foundedCustomer == null)
            {
                Console.WriteLine("Customer not found!");
            }
            else
            {
                Console.WriteLine(foundedCustomer.ToString());
                // Console.WriteLine("==Customer Info==");
                // Console.WriteLine("Name: " + foundedCustomer.CustomerName);
                // Console.WriteLine("Name: " + foundedCustomer.CustomerPhoneNumber);
                // Console.WriteLine("Name: " + foundedCustomer.CustomerEmail);
                // Console.WriteLine("=====================================");


                // ask if user want to see view products in stock
                 //Console.WriteLine(" do you want to see what we have in stock?");
                   // Console.WriteLine("[3] - view what we have in stock");
                     Console.WriteLine("[1] - see our different store locations");
                     Console.WriteLine("[2] - see what we have in stock");
                     Console.WriteLine("[0] - Go back");
                     string seeStoreLocations = Console.ReadLine();
                     if (seeStoreLocations == "1")
                     {
                        //  Console.WriteLine("==== KAW ====");
                         return "StoreLocations";
                     }
                     else if(seeStoreLocations == "2")
                     {
                         return "viewStoreProducts";
                     }
                     else
                     {
                         return "SearchCustomer";
                     }




            }

                Console.ReadLine();
                return "SearchCustomer";

        }
         return "Customer information found";
    }
}