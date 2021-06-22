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

        public static RegistrationOfInterest AppendWeeks(this RegistrationOfInterest form, IEnumerable<Week> weeks)
        {
            form.Weeks = new List<Week>();
            foreach (var w in weeks)
                form.Weeks.Add(w);
            return form;
        }
    }
}
