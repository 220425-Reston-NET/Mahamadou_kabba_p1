using Xunit;
using storeModel;
namespace storeTest
{
// change filename / class name to the test we doing  

  public class storeModelTest
  {
      //  all you put in unit test class is usualy viod methods
    //   ** [Fact] ** this fact keyword is how C#/Xunit know the method is for unit testing
    // how to restart my omnisharp => intellisense not working right 
    [Fact]
       public void customer_phoneNumber_should_be_unique()  // change method name of what you testing for
       {
        //  we use the the 3As here

        // * Arrange => 
        // use the object of what you testing => whatever value we need
        //  let say you checking if a value is < 0 => int value = +3 (any positive)
         CustomerClass MenuObject = new CustomerClass();
         string CustomerPhoneNumber = "1234";
        // Act ** 
        MenuObject.CustomerPhoneNumber = CustomerPhoneNumber;
        // here we run whatecer code/ condition we want to test for
        // object name from above . propertyname we checcking = the field (pokeobj.PokeID = pokeid)

        // Assert ***
        Assert.NotNull(MenuObject.CustomerPhoneNumber);

        // we validate whatever the condition or code is to see if it works as intended using Assert keyword
        // Assert.NotNull(object.property); => checks the property not null/ lack of value
        // Assert.Equal(); => needs to parameter, expect, actual value(variavle, object.property)

           // testing for exeption 
           //    Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(() =>
           //    {
            //        object.whateverwetesting = what we want
           //    })

           
        

    }
  }
}