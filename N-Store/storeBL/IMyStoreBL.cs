using storeModel;

namespace storeBL
{
    /// <summary>
    /// Business Layer is responsible for further validation or process of data obtained from the database or the user
    /// What kind of process? That all depends on the type of functionality you will be doing
    /// </summary>
    public interface IstoreBL
    {
        
        /// <summary>
        /// Add pokemon to the database
        /// Randomize the health property of the pokemon
        /// </summary>
        /// <param name="p_store">This is the pokemon object that will be added to the DB</param>
        /// <returns>Gives back the pokemon that gets added to the DB</returns>
        void AddCustomer(CustomerClass p_store);

        /// <summary>
        /// This will search for a pokemon in the DB using their name
        /// </summary>
        /// <param number="p_customerNumber">Name of the pokemon used to search</param>
        /// <returns>Multiple pokemons if they have matching name</returns>
        CustomerClass SearchCustomerByPhoneNumber(string p_customerNumber);
        void AddProductToCustomer(CustomerClass foundedCustomer);

        // List<Pokemon> SearchPokemonById(int p_pokeId);
        // void AddAbilityToCustomerClass(Customer p_customer);

        // List of current customers method
        //  gives list of object that hold  customers in database
        List<CustomerClass> GetAllCustomer();
        
    }
    
}