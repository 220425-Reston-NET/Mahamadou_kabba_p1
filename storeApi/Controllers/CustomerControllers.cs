using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
 using Serilog;
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
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                Log.Information("User going to Get all customer");
                 List<CustomerClass> listOfCurrentCustomers = await _storeBL.GetAllCustomerAsync();
               //  followed by "ok()" it determines what http status code to give
              return Ok(listOfCurrentCustomers);
            }
            catch (SqlException)
            {
                Log.Information("no customer found");
                return NotFound("No Customer Exist");
            }
        }

       [HttpPost("AddCustomer")]
    //    asking user for infor
        public IActionResult AddCustomer([FromBody] CustomerClass s_store)
        {
          try
            {
                Log.Information("Customer was added");
                // use bussines layer used to add customer
                _storeBL.AddCustomer(s_store);
               //  followed by "ok()" it determines what http status code to give
              return Created("Customer was added", s_store);
            }
            catch (SqlException)
            {
                Log.Information("No customer added / customer already in system");
                return Conflict("Customer already in the system or an invalid info");
            }

          
        }

        [HttpGet("SearchCustomerByPhoneNumber")]
        public IActionResult SearchCustomer([FromQuery] string SearchCustomerByNumber)
        {

            try
            {
                Log.Information("Customer searched by phone number");
                return Ok(_storeBL.SearchCustomerByPhoneNumber(SearchCustomerByNumber));
            }
            catch (System.Exception)
            {
                Log.Information("cutomer not in system");
                return Conflict();
            }
          
        }

       
     }
    

}