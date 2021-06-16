using System.Collections.Generic;

namespace DAL.Registration
{
    public class Municipality : Entity
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<RegistrationOfInterest> RegistrationOfInterests { get; set; }
    }
}
