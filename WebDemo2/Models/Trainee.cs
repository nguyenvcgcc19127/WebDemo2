namespace WebDemo2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trainee")]
    public partial class Trainee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainee()
        {
            Trainee_Course = new HashSet<Trainee_Course>();
        }

        [Key]
        [StringLength(10)]
        public string Trainee_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Trainee_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int Age { get; set; }

        public DateTime Date_of_Birth { get; set; }

        [Required]
        [StringLength(50)]
        public string Education { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainee_Course> Trainee_Course { get; set; }
    }
}
