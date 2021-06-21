using DAL.Registration;
using System.Collections.Generic;

namespace WebApp.Extensions
{
    public static class RegistrationFormExtensions
    {
        public static RegistrationOfInterest AppendAdress(this RegistrationOfInterest form, Adress adress)
        {
            form.SchoolAdress = adress;
            return form;
        }

        public static RegistrationOfInterest AppendSubjects(this RegistrationOfInterest form, IEnumerable<Subject> subjects)
        {
            form.Subjects = new List<Subject>();
            foreach (var s in subjects)
                form.Subjects.Add(s);
            return form;
        }
    }
}
