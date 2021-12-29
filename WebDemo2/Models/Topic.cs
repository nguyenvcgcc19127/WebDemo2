namespace WebDemo2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        [Key]
        [StringLength(10)]
        public string Topic_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Topic_Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Course_ID { get; set; }

        public virtual Course Course { get; set; }
    }
}
