using DAL.Registration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApp.Extensions
{
    public static class Extensions
    {
        // Extension for Ef core to clear all entries of a certain type
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }

        // Extensions for form
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
