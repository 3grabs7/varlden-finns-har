using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Registration
{
    public class Subject : Entity
    {
        [Display(Name = "Ämne")]
        public string Name { get; set; }


        [Display(Name = "Skolform")]
        [Column(TypeName = "nvarchar(24)")]
        public SchoolForm SchoolForm { get; set; }


        public ICollection<RegistrationOfInterest> RegistrationOfInterests { get; set; }


        [NotMapped]
        public bool IsMarked { get; set; }
    }
}
