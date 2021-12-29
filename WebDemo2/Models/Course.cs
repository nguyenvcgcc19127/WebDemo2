namespace WebDemo2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Topics = new HashSet<Topic>();
            Trainee_Course = new HashSet<Trainee_Course>();
            Trainer_Course = new HashSet<Trainer_Course>();
        }

        [Key]
        [StringLength(10)]
        public string Course_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Course_Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Course_Category { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topic> Topics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainee_Course> Trainee_Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainer_Course> Trainer_Course { get; set; }
    }
}
