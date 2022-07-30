using Attorney.Manager.Repository.Context;
using Attorney.Manager.Repository.Interfaces.Registration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Attorney.Manager.Repository.Implementation.Registration
{
    public class RegistrationService : Repository, IRegistrationService
    {
        public IEnumerable<Domain.Registration.Attorney> GetAllRegistraions()
            => RepositoryLoader().Attorney.Include(a => a.CommercialAdress ).Include(a => a.Seniority).ToList();

        public Domain.Registration.Attorney GetByIdRegistration(int id)
            => RepositoryLoader().Attorney.Include(a => a.CommercialAdress).Include(a => a.Seniority).First(a => a.AttorneyId == id);

        public void PostRegistration(Domain.Registration.Attorney newAttorney)
        {
            var sd = new AttorneyManagerDbContext();
            sd.Attorney.Add(newAttorney);
            sd.SaveChanges();
        }

        public void PutRegistraion(Domain.Registration.Attorney updatedAttorney)
        {
            var currentAttorney = RepositoryLoader().Attorney.First(a => a.AttorneyId == updatedAttorney.AttorneyId);
            currentAttorney = updatedAttorney;
            RepositoryLoader().SaveChanges();
        }

        public void DeleteRegistraion(int id)
        {
            var currentAttorney = RepositoryLoader().Attorney.Include(a => a.CommercialAdress).Include(a => a.Seniority).First(a => a.AttorneyId == id);
            RepositoryLoader().Remove(currentAttorney);
            RepositoryLoader().SaveChanges();
        }

    }
}
