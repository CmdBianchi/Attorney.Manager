using Attorney.Manager.Domain.Addresses;
using Attorney.Manager.Domain.Registration;
using Attorney.Manager.Repository.Implementation.Registration;
using Attorney.Manager.Repository.Interfaces.Registration;
using Attorney.Manager.Web.Mapper;
using Attorney.Manager.Web.Models.Registration;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Attorney.Manager.Web.Controllers
{
    public class RegistrationController : Controller
    {
        public RegistrationController()
        {
            this.RegistrationService = new RegistrationService();
        }

        public IRegistrationService RegistrationService { get; set; }

        public ActionResult Index()
        {
            var attorneysList = this.RegistrationService.GetAllRegistraions().ToList();

            if (attorneysList.Count().Equals(0)) 
            {
                this.GenerateDummy();
                attorneysList = this.RegistrationService.GetAllRegistraions().ToList();
            }
               
            var attorneysListViewModel = this.AttorneyViewModelBuilder(attorneysList);
            return View(attorneysListViewModel);
        }

        public ActionResult Create()
        {          
            return View();
        }

        [HttpPost]
        public ActionResult Create(AttorneyViewModel attorneyViewModel)
        {
            try
            {
                this.RegistrationService.PostRegistration(AttorneyBuilder(attorneyViewModel));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var attorney = this.RegistrationService.GetByIdRegistration(id);
            var attorneyViewModel = this.AttorneyViewModelBuilder(attorney);
            return View(attorneyViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, AttorneyViewModel attorneyViewModel)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                this.RegistrationService.DeleteRegistraion(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region " Private Methods "

        private IList<AttorneyViewModel> AttorneyViewModelBuilder(IList<Domain.Registration.Attorney> attorneysList)
            => RegistrationMapper.AttorneyMapper<Domain.Registration.Attorney, AttorneyViewModel>(attorneysList);

        private AttorneyViewModel AttorneyViewModelBuilder(Domain.Registration.Attorney attorney)
            => RegistrationMapper.AttorneyMapper<Domain.Registration.Attorney, AttorneyViewModel>(attorney);

        private Domain.Registration.Attorney AttorneyBuilder(AttorneyViewModel attorney)
            => RegistrationMapper.AttorneyMapper<AttorneyViewModel, Domain.Registration.Attorney>(attorney);

        private void GenerateDummy()
        {
            this.RegistrationService.PostRegistration( new Domain.Registration.Attorney()
            {
                Name = "Doutor Test",
                CommercialAdress = new CommercialAdress()
                {
                    StreetName = "Rua teste",
                    City = "CWB",
                    State = "PR",
                    PostalCode = "78965412",
                    Country = "BR"
                },
                Seniority = new List<Seniority>()
                {
                     new Seniority()
                     {
                         SeniorityType = Domain.Registration.SeniorityType.SeniorAnalyst
                     },
                     new Seniority()
                     {
                         SeniorityType = Domain.Registration.SeniorityType.JuniorAnalyst
                     }
                }
            } );
        } 

        #endregion

    }
}
