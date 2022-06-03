// AddCustomer class is going to Inheret IMenu class
global using Serilog;  // allows every csharp project in the assembly to use serilog
using storeBL;
using storeDL;
using storeModel;

public class AddCustomer : IMenu
{
        // string CustomerClass MenuObject = new CustomerClass();
        // string CustomerClass MenuObject new CustomerClass();
        private CustomerClass MenuObject = new CustomerClass();
        

        // ====== Dependency Injection Patterm ==========
        // add the field of the interface you want to add
        private IstoreBL _storeBL;

        // create constructo with parameter of the interfsce
        public AddCustomer(IstoreBL p_storeBL)
        {
            // set the feild with the parameter
            _storeBL = p_storeBL;
        }

    public void Display()
    {
        // create poke/ customer class object
        // ProductsClass ProductClassObject = new  ProductsClass();

        // CustomerClass customerClassObject = new CustomerClass();
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("-----------------Hey there, freshman!------------------");
        Console.WriteLine("Please enter your information by following the prompts");
        Console.WriteLine(" <><><><><><>=======<><><><><><><><>=======<><><><><><>");
        Console.WriteLine("What is your name");
        MenuObject.CustomerName = Console.ReadLine();
            //  ask trainer how to grab the name and idsplay it like we did previously
        Console.WriteLine( "What is your Email");
        MenuObject.CustomerEmail = Console.ReadLine();

        Console.WriteLine("What is your Phone Number");
        MenuObject.CustomerPhoneNumber = Console.ReadLine();


        try
        {
            //  MenuObject.CustomerName = Console.ReadLine();
        }
        catch (System.Exception)
        {
            
           Console.WriteLine("User tried to add an existing customer");
        }
        Console.WriteLine("[1] - Save customer info");
        Console.WriteLine("[0] -   Exit  ");

        //  Repository.addCustomer(MenuObject);

    }

    public string YourChoice()
    {
        string userInput = Console.ReadLine();
        if (userInput == "1")
        {
            _storeBL.AddCustomer(MenuObject);

            Console.WriteLine("Do you want to see our store locations? (Y - Yes, N - No)");
                     string seeStoreLocations = Console.ReadLine();
            if (seeStoreLocations != "Y")
            {
                return "SearchCustomer";
            }
            else
            {
                //  Console.WriteLine("==== KAW ====");
                return "StoreLocations";
            }
            try
           {
                
           }
           catch (System.Exception)
           {
            //    log 
               Log.Warning("Customer  already exist in the system");
               Log.Information(MenuObject.ToString());
               Console.WriteLine("Customer already in the system");
               Console.ReadLine();
           } 


           return "Mainmenu";
        } else if (userInput == "0")
        {
            return "Exist";
        } else
        {
           Console.WriteLine("please enter a correct response");
           Console.ReadLine();
           return "AddCustomer";
           
        }
    }
}