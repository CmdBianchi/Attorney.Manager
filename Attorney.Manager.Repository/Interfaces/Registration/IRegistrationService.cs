using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attorney.Manager.Repository.Interfaces.Registration
{
    public interface IRegistrationService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Domain.Registration.Attorney> GetAllRegistraions();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Domain.Registration.Attorney GetByIdRegistration(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newAttorney"></param>
        void PostRegistration(Domain.Registration.Attorney newAttorney);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatedAttorney"></param>
        void PutRegistraion(Domain.Registration.Attorney updatedAttorney);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deletedAttorney"></param>
        void DeleteRegistraion(int id);

    }
}
