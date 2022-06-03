// See https://aka.ms/new-console-template for more information
using storeBL;
using storeDL;
using storeModel;
using StoreUI;
using Serilog;
using Microsoft.Extensions.Configuration;

// installing my logger using serilog
Log.Logger = new LoggerConfiguration()   //loggerconfiguration used to configure and create logger
.WriteTo.File("./logs/user.txt") // confuring the logger to save information  file called <=
.CreateLogger();  // a method to create logger

//-------------------------
// last steps to configure after adding packages (initializing configuration object)
var configuration = new ConfigurationBuilder() //used Builder class to my configuration object
    .SetBasePath(Directory.GetCurrentDirectory()) // Sets the path to current directory
    .AddJsonFile("appsetting.json") // Grabs the specific json file on where the infomation is from
    .Build(); //creates the object


// intract with a customer object
// MainMenu MenuObject = new MainMenu();
// changed MainMenu to IMenu => gives me error *******
IMenu MenuObject = new MainMenu();

bool repeat = true;
while (repeat)
{
    // clear terminal everytime it repeats
    Console.Clear();
   
   MenuObject.Display();
   //  add sting variable to your choice method to display a string

   string answer = MenuObject.YourChoice();
   if (answer == "Mainmenu")
   {
     Log.Information( "user going through mainmenu");
     MenuObject = new MainMenu();
   }
   else if (answer == "AddCustomer")
   {
      Log.Information( "user add Customer menu");
     MenuObject = new AddCustomer( new MyStoreBL(new SQLStoreRepository(configuration.GetConnectionString("KM_DB")))); 
   }
   else if(answer == "SearchCustomer")
   {
      Log.Information( "user going through searchCustomer menu");
      // change json (storeRepository) to sql (SQLStoreRepository)
     MenuObject = new SearchCustomer( new MyStoreBL(new SQLStoreRepository(configuration.GetConnectionString("KM_DB"))));
   }
   else if (answer == "viewStoreProducts")
   {
     Log.Information(" User selecting viewStoreProducts");
     MenuObject = new viewStoreProducts();
   }
    else if (answer == "Exit")
   {
              repeat = false;

   }
  

   

   
}

// // menu stuff  
// // store storeObject1 = new store();
// // Console.WriteLine(storeObject1);
// ProductsClass productsClassObject = new ProductsClass();
// Console.WriteLine(productsClassObject);





