using Microsoft.Data.SqlClient;
using storeModel;

namespace storeDL
{

    public class SQLStoreRepository : IRepository<CustomerClass>
    {
        //private string _connectionString = @"Server=tcp:restondbdemo220245.cvtq9j4axrge.us-east-1.rds.amazonaws.com;Initial Catalog=Kabba Mahamadou;Persist Security Info=False;User ID=KM;Password=W9$ufd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        //======= dependacy injection to hide coneectonString
    //  We  create a constructor and have our connection string inside that constructor to hide instead of just havin it in the class
       private string _connectionString;
       public SQLStoreRepository(string c_connectionString)
       {
           this._connectionString = c_connectionString;
       }

       // -----===========------Dependacy Injection-----------================------------
        public  void Add(CustomerClass c_resource)
        {
           string SQLQuery = @"insert into CustomerTablee 
                                values (@CustomerPhoneNumber, @CustomerName, @CustomerEmail)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
    
                SqlCommand command = new SqlCommand(SQLQuery, con);

                //We fill in the parameters we added earlier
                //We dynamically change information using AddWithValue and Parameters to avoid the risk of SQL Injection attack
                command.Parameters.AddWithValue("@CustomerPhoneNumber", c_resource.CustomerPhoneNumber);
                command.Parameters.AddWithValue("@CustomerName", c_resource.CustomerName);
                command.Parameters.AddWithValue("@CustomerEmail", c_resource.CustomerEmail);

                //Execute sql statement that is nonquery meaning it will not give any information back (unlike a select statement)
                //  once we add aync to the method, we changed ExecuteNonQuery to ExecuteNonQueryAsync and add await to the beginning
                 command.ExecuteNonQuery();
            }
        }
// =============bs update method to aviod implementing new interface =========
       void Update(CustomerClass c_resource)
        {
            throw new NotImplementedException();
        }


    //   we can add async to this method since it have a return (datatype alwsy in task<>)
        public  List<CustomerClass> GetAllCustomers()
        {
            string SQLQuery = @"select * from  CustomerTablee";
            // make list of customers to get all of em
            List<CustomerClass> listOfCustomers = new List<CustomerClass>();
            // sql connection object is responsible for making a connection to your database
            // that's why we pass out connectionString information when we make that object
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                // how to connect C# with your DB
                // we added the necessary package =>  dotnet add package Microsoft.Data.SqlClient --version 4.1.0
                //  have : using Microsoft.Data.SqlClient; on top

                //  1 first we use open method open connection to our db
                 con.Open();

                // 2 sql Comand class/object to execute sql statement to db
                //  in the parameter of the object we put in the cammand to be executed, then the connect called con
                SqlCommand command = new SqlCommand(SQLQuery, con);

                //  3 hence C# dont understand tables, and it only know class&object we need a class that reads
                // we need sqlDataReader object to convert the table to what c# understand class/object

                SqlDataReader reader =  command.ExecuteReader();

                // since we dont know how many table we might be repeating, we using a while loop
                // read method here push the SqlDataReader to the next row then the next
                // we map the table to a format sql understands
                while ( reader.Read())
                {
                    // we are adding new customerclass object to our list collection
                   listOfCustomers.Add(new CustomerClass(){

                    //    the new CustomerClass will hold the properties obtained from a single record in SQL
                    //  list list, this table is zero based index
                     CustomerPhoneNumber = reader.GetString(1), 
                     CustomerName = reader.GetString(2),
                     CustomerEmail = reader.GetString(3),
                    //  product set it to GiveProductToCustomer() you just created
                    // Products = GiveProductToCustomer(reader.GetString(1))

                   });  
                }  
                 return listOfCustomers;
            }
        }
        // build private method for product
        private List<Product> GiveProductToCustomer( string c_CustomerPhoneNumber)
        {
             string SQLQuery = @" select ct.CustomerName, p.productName, p.productId  from CustomerTablee
            inner join store_products sp on ct.CustomerPhoneNumber = sp.CustomerPhoneNumber  
            inner join Product p on p.productId = sp.productId
            where ct.CustomerPhoneNumber =  @CustomerPhoneNumber ";

            List<Product> listOfProduct = new List<Product>();
            // connecting to the database step
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@CustomerPhoneNumber", c_CustomerPhoneNumber);

                //  this above will give you a table. now you need a sql reader
                SqlDataReader reader = command.ExecuteReader();

                //  now we map it uisng while loop
                while (reader.Read())
                {
                    listOfProduct.Add(new Product()
                    {
                        Name = reader.GetString(1),
                         productId = reader.GetInt32(0),
                        //  , CustomerPhoneNumber = reader.GetString(2)


                    });
                    
                }

                return listOfProduct;

            }
        }

       

        public async Task<List<CustomerClass>> GetAllCustomersAsync()
        {
             string SQLQuery = @"select * from  CustomerTablee";
            // make list of customers to get all of em
            List<CustomerClass> listOfCustomers = new List<CustomerClass>();
            // sql connection object is responsible for making a connection to your database
            // that's why we pass out connectionString information when we make that object
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                // how to connect C# with your DB
                // we added the necessary package =>  dotnet add package Microsoft.Data.SqlClient --version 4.1.0
                //  have : using Microsoft.Data.SqlClient; on top

                //  1 first we use open method open connection to our db
                 await con.OpenAsync();

                // 2 sql Comand class/object to execute sql statement to db
                //  in the parameter of the object we put in the cammand to be executed, then the connect called con
                SqlCommand command = new SqlCommand(SQLQuery, con);

                //  3 hence C# dont understand tables, and it only know class&object we need a class that reads
                // we need sqlDataReader object to convert the table to what c# understand class/object

                SqlDataReader reader = await command.ExecuteReaderAsync();

                // since we dont know how many table we might be repeating, we using a while loop
                // read method here push the SqlDataReader to the next row then the next
                // we map the table to a format sql understands
                while ( await reader.ReadAsync())
                {
                    // we are adding new customerclass object to our list collection
                   listOfCustomers.Add(new CustomerClass(){

                    //    the new CustomerClass will hold the properties obtained from a single record in SQL
                    //  list list, this table is zero based index
                     CustomerPhoneNumber = reader.GetString(1), 
                     CustomerName = reader.GetString(2),
                     CustomerEmail = reader.GetString(3),
                    //  product set it to GiveProductToCustomer() you just created
                    // Products = GiveProductToCustomer(reader.GetString(1))

                   });  
                }  
                 return listOfCustomers;
            }
        }

        void IRepository<CustomerClass>.Update(CustomerClass c_resource)
        {
            throw new NotImplementedException();
        }
    }
}