namespace Attorney.Manager.Web.Models.Registration
{

    public class SeniorityViewModel
    {
        public int SeniorityId { get; set; }
        public SeniorityType SeniorityType { get; set; }
        public AttorneyViewModel Attorney { get; set; }
    }

    #region " SeniorityType Enum "

    public enum SeniorityType
    {
        JuniorAnalyst = 0,
        Analyst = 1,
        SeniorAnalyst = 2
    }

    #endregion

}
