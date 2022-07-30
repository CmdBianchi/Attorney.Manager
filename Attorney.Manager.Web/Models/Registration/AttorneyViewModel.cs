using Attorney.Manager.Web.Models.Addresses;
using System.Collections.Generic;

namespace Attorney.Manager.Web.Models.Registration
{
    public class AttorneyViewModel
    {
        public int AttorneyId { get; set; }
        public string Name { get; set; }
        public ICollection<SeniorityViewModel> Seniority { get; set; }
        public CommercialAdressViewModel CommercialAdress { get; set; }
    }
}
