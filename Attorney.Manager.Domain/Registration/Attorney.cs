using Attorney.Manager.Domain.Addresses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attorney.Manager.Domain.Registration
{
    [Serializable]
    [Table("attorney")]
    public class Attorney
    {
        [Key]
        [Column("attoreny_id")]
        public int AttorneyId { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        public ICollection<Seniority> Seniority { get; set; }

        [Required]
        [ForeignKey("commercial_adress_id")]
        public CommercialAdress CommercialAdress { get; set; }

    }
}
