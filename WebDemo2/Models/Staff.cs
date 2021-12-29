namespace WebDemo2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [Key]
        [StringLength(10)]
        public string Staff_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Staff_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int Age { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        public int Admin { get; set; }
    }
}
