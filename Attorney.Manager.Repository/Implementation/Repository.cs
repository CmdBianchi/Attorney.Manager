using Attorney.Manager.Repository.Context;
using System;

namespace Attorney.Manager.Repository.Implementation
{
    public class Repository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AttorneyManagerDbContext RepositoryLoader()
        {
            try
            {
                return new AttorneyManagerDbContext();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
            
    }
}
