namespace WebDemo2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trainer_Course
    {
        [Key]
        [StringLength(10)]
        public string No { get; set; }

        [Required]
        [StringLength(10)]
        public string Course_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Trainer_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Trainer_Name { get; set; }

        public virtual Course Course { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
