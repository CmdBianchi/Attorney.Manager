using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attorney.Manager.Domain.Addresses
{
    [Serializable]
    [Table("commercial_adress")]
    public class CommercialAdress
    {
        [Key]
        [Required]
        [Column("commercial_id")]
        public int Id { get; set; }

        [Required]
        [Column("postal_code")]
        public string PostalCode { get; set; }

        [Required]
        [Column("street_name")]
        public string StreetName { get; set; }

        [Required]
        [Column("city")]
        public string City { get; set; }

        [Required]
        [Column("state")]
        public string State { get; set; }

        [Required]
        [Column("country")]
        public string Country { get; set; }

    }
}
