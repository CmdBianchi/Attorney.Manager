using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attorney.Manager.Domain.Registration
{
    [Serializable]
    public class Seniority
    {
        [Key]
        [Column("seniority_id")]
        public int SeniorityId { get; set; }

        [Column("seniority")]
        public SeniorityType SeniorityType { get; set; }

        [ForeignKey("attorney_id")]
        public Attorney Attorney { get; set; }

    }

    public enum SeniorityType
    {
        JuniorAnalyst = 0,
        Analyst = 1,
        SeniorAnalyst = 2
    }
}
