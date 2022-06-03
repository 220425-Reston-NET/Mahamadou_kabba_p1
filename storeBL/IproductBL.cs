using storeModel;

namespace storeBL
{
    public interface IproductBL
    {
        /// <summary>
        // this  will give you all the products we have in stock from DB
    //    ======
    //   <return> Returns a list of product objects <return>
    List<CustomerClass> GetAllProduct();


    // will find products in the DB based on name
    //  param name = "p_productName" the name parameter use to find ability
    // return returns product found or null when no product found

    CustomerClass SearchProductByName(string p_productName);
 
    } 
}