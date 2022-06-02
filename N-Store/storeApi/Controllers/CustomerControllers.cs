using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using storeBL;
using storeModel;
using Microsoft.Data.SqlClient;

namespace storeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

     public class CustomerController : ControllerBase
     {
        //   ==== need to talk to bussines layer * this is where you use dependacy injection ===
        private IstoreBL _storeBL;
        public CustomerController(IstoreBL s_storeBL)
        {
            _storeBL = s_storeBL;
        }
        // ===================
        // create action to do something with api  (we use get to get) 
        // this is an action of a controller, it needs the HTTP verb it's associated with
        [HttpGet("GetAllCustomer")]
        public IActionResult GetAllCustomer()
        {
            try
            {
                 List<CustomerClass> listOfCurrentCustomers = _storeBL.GetAllCustomer();
               //  followed by "ok()" it determines what http status code to give
              return Ok(listOfCurrentCustomers);
            }
            catch (SqlException)
            {
                
                return NotFound("No Customer Exist");
            }
        }

       [HttpPost("AddCustomer")]
    //    asking user for infor
        public IActionResult AddCustomer([FromBody] CustomerClass s_store)
        {
          try
            {
                // use bussines layer used to add customer
                _storeBL.AddCustomer(s_store);
               //  followed by "ok()" it determines what http status code to give
              return Created("Customer was added", s_store);
            }
            catch (SqlException)
            {
                
                return Conflict("Customer already in the system or an invalid info");
            }
          
        }
     }
    

}