using storeModel;

namespace storeDL
{
    // **  Summary
    // Generic repository that will accommodate for all models you will be creating in the future or existing models
     // ** Summary

    //  <typearam name="T"> The T is a placeholder for where the model will go in </typeparam>
    public interface IRepository<T>
    {
         //CRUD operations
        //Create, Read, Update, and Delete

        /// <summary>
        /// This will create a resource to the database
        /// </summary>
        /// <param name="c_resource">This is the resource being saved to the database</param>
        void Add(T c_resource);

        /// <summary>
        /// This will get all the specific resource from the database
        /// </summary>
        /// <returns>T is the resource being given</returns>
        List<T> GetAllCustomers();

        /// <summary>
        /// This will update an existing resource
        /// </summary>
        /// <param name="p_resource">This is the resource it is updating</param>
        void Update(T c_resource);
    }
}