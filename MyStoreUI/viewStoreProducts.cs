using storeModel;

namespace StoreUI
{
    // create class and inharete interface Imenu
    public class viewStoreProducts : IMenu
    {
        public void Display()
        {
            Console.WriteLine("=== Current Products in Stock ===");
            foreach (Product productObj in SearchCustomer.foundedCustomer.Products)
            {
                Console.WriteLine(productObj);
            }
            //  allow user to go back after viewing the products
            Console.WriteLine("[-] - Buy product");
            Console.WriteLine("[0] - Go back");
        }

        public string YourChoice()
        {
            string userInput = Console.ReadLine();
            if (userInput == "0")
            {
                return "SearchCustomer";
            }
            else
            {
                return "Mainmenu";
            }
        
        }
    }
}