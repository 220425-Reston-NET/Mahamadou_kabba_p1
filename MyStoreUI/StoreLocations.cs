namespace StoreUI
{
    public class StoreLocations : IMenu
    {
        public void Display()
        {
            // Console.WriteLine("=== KAW locations ===");
            // foreach (Locations item in collection)
            // {
                
            // }

            Console.WriteLine("[0] - Go back");

        }


        public string YourChoice()
        {
        //    Console.WriteLine("=== ")
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