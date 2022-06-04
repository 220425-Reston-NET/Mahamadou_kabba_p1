using System.ComponentModel.DataAnnotations;
namespace storeModel
{
  public class CustomerClass
  { 
     // we using properties to save information
    // public int ProductID { get; set; }
    // public int CustomerId;
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }

    public string CustomerPhoneNumber { get; set;}

    

    // use list collection to hold multiple things
    // Different stores we want to use 
    public List<Product> Products { get; set; }

    // creating a constructor for every model you make => ctor
    //  make constructors for reference type (this constructor will instantiating other objects)
    public CustomerClass()
    {
        CustomerName = "Max";
        CustomerEmail = "max@max.com";
        CustomerPhoneNumber = "12";
        Products = new List<Product>();
    }

    // overide to-string method to display object information 
    // you can use (obejectName).ToString() => if you want to display object info in multiple places
    public override string ToString()
    {
      return $"====Customer info====\nName: {CustomerName}\nEmail: {CustomerEmail}\nCell: {CustomerPhoneNumber}\n==============";
    }
    
    
  }

}
