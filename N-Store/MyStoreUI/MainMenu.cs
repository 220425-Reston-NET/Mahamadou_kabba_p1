// Main menu of my store [ interact with the user / customer] 
// using storeDL;
using storeModel;

namespace StoreUI
{
    public class MainMenu : IMenu
    {
        // this is a method that will display things in your terminal that will show how a customer can navigate in your store
        public void Display()
        {
            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><>");
            Console.WriteLine( "{== Welcom to Kabba's Athletic Wear (K.A.W) ==}");
            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><>");
            
            Console.WriteLine("<>-What can we help you with today?-<>");
            Console.WriteLine(" ");
            // options to show the stores or exit
            Console.WriteLine("[1] - Register new customer ");
            Console.WriteLine("[2] - Search returning Customer");
            Console.WriteLine("[0] - to exit");
            //Console.WriteLine("[2] - Returning Customer");
            // if customer wanna check the store => give options to pick which store
            // Console.WriteLine("Which of our stores would you like to visit today?");
           
        }

        // this method will ask user what to do 
        

        
        public string YourChoice()
        {
             
           
            //    ==================================
             string userInput = Console.ReadLine();

             if (userInput == "1")
             {
            
                return "AddCustomer";
                // can I have method here to ConsoleRead store pickedthen display that store
                
            }
            else if (userInput == "2")
            {
                return "SearchCustomer";
            }
            else if (userInput == "0")
            {
                // exit store logic
                Console.WriteLine("You're dead to us, bye.");
                Console.WriteLine("Jk, please come back! ");

                Console.ReadLine();
                return "Exit";
            }
            else
            {
                Console.WriteLine("please enter a valid options");
                Console.ReadLine();
                return "Mainmenu";
            }
           
        }
    }
}