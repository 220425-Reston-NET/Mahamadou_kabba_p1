// using storeModel;
// using storeBL;

// namespace storeUI
// {
//     public class SelectProduct : IMenu
//     {

//         // ======= dependacy Injection ====
//         private IproductBL _productBL;
//         private IstoreBL _storeBL;
//         public SelectProduct(IproductBL _productBL, IstoreBL _storeBL)
//         {
//             _productBL = p_productBL;
//             _storeBL = p_storeBL;
//         }

//         // === ===== ====== =====
//         public void Display()
//         {
//         //     this will display all products currently available in the database
//         List<Product> listOfProduct = _productBL.GetAllProduct();
//         foreach (Product productObj in listOfProduct)
//         {
//             Console.WriteLine(productObj.Name);
//         }
//         }

//         public string YourChoice()
//         {
//            Console.WriteLine("Give me product name listed above to search product in stock");
//            string userInput = Console.ReadLine();

//           //     logic to select a specific product ffrom productList
//           Product foundedProduct = _productBL.SearchProductByName(userInput);

//           if (foundedProduct != null)
//           {
//             //   logic to add product founded to current customer cart using products property in its model
//             SearchCustomer.foundedCustomer.CustomerPhoneNumber.Add(foundedProduct);
//             _storeBL.AddProductToCustomer(SearchCustomer.foundedCustomer);
//             Console.WriteLine("Successfully added product to customer cart");

//           }
//           else
//           {
//               Console.WriteLine("Product not found! please check your spelling");
//               Console.WriteLine();
//               return "SelectProduct";
//           }

//         //    logic to save the information permanently (UPDATING)
//         Console.ReadLine();
//         return "MainMenu";
//         }
//     }
// }
