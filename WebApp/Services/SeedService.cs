using DAL.Registration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Extensions;

namespace WebApp.Services
{
    public class SeedService : ISeedService
    {
        private readonly ApplicationDbContext _context;
        public SeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ResetAsync()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
        }

        // These needs to be seeded in!!!
        #region mandatorySeeding
        public async Task AddSubjects()
        {
            _context.Subjects.Clear();
            await _context.SaveChangesAsync();

            List<string> elementarySubjects = new()
            {
                "Bild",
                "Engelska",
                "Hem- och Konsumentkunskap",
                "Idrott och Hälsa",
                "Matematik",
                "Musik",
                "NO",
                "SO",
                "Slöjd",
                "Svenska",
                "Svenska som Andraspråk",
                "Teknik",
                "Moderna Språk"
            };
            List<string> gymnasiumSubjects = new()
            {
                "Svenska",
                "Svenska som Andraspråk",
                "Engelska",
                "Moderna Språk",
                "Idrott och Hälsa",
                "Musik",
                "Bild",
                "Matematik",
                "Kemi",
                "Biologi",
                "Fysik",
                "Samhällskunskap",
                "Religionskunskap",
                "Historia",
                "Geografi",
                "Psykologi",
                "Sociologi",
                "Pedagogik",
                "Media",
                "Gymnasiearbete",
                "Ekonomi",
                "Juridik",
                "Entreprenörskap",
                "SYV",
                "Vård och Omsorg",
                "Barn och Fritid",
                "Handel, Restaurang och Turism",
                "Hantverk",
                "El, Bygg och Fordon",
                "VVS och Industri"
            };
            List<string> adultEducationSubjects = new()
            {
                "Matematik",
                "Svenska",
                "Svenska som Andraspråk",
                "Teknik",
                "Engelska",
                "Moderna Språk",
                "Kemi",
                "Biologi",
                "Fysik",
                "Samhällskunskap",
                "Religionskunskap",
                "Historia",
                "Geografi",
                "Psykologi",
                "Sociologi",
                "Pedagogik",
                "Media",
                "Gymnasiearbete",
                "Ekonomi",
                "Juridik",
                "Entreprenörskap",
                "SYV",
                "Vård och Omsorg",
                "Barn och Fritid",
                "Handel, Restaurang och Turism",
                "Hantverk",
                "El, Bygg och Fordon",
                "VVS och Industri"
            };
            List<string> sfiSubjects = new()
            {
                "B",
                "C",
                "D"
            };

            foreach (var s in elementarySubjects)
                await _context.AddAsync(new Subject { Name = s, SchoolForm = SchoolForm.Grundskola });

            foreach (var s in gymnasiumSubjects)
                await _context.AddAsync(new Subject { Name = s, SchoolForm = SchoolForm.Gymnasium });

            foreach (var s in adultEducationSubjects)
                await _context.AddAsync(new Subject { Name = s, SchoolForm = SchoolForm.AnnanVuxenutbildning });

            foreach (var s in sfiSubjects)
                await _context.AddAsync(new Subject { Name = s, SchoolForm = SchoolForm.Sfi });

            await _context.SaveChangesAsync();
        }

        public async Task AddMunicipality()
        {
            _context.Municipalities.Clear();
            await _context.SaveChangesAsync();

            var municipalities = Utils.ParsingTools.ReadExcelFile("./Files/sveriges-kommuner.csv");
            // remove postfix - kommun
            municipalities = municipalities
                .Select(s => s.Replace(" kommun", "").Replace(" stad", ""))
                .ToList();
            foreach (var m in municipalities)
            {
                if (m.Last() == 's')
                {
                    await _context.AddAsync(new Municipality { Name = m.Remove(m.Length - 1) });
                    continue;
                }
                await _context.AddAsync(new Municipality { Name = m });
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddWeeks(int? year)
        {
            _context.Weeks.Clear();
            await _context.SaveChangesAsync();

            if (year is null) year = DateTime.Now.Year;
            for (int i = 1; i <= 52; i++)
                await _context.AddAsync(new Week { WeekNumber = i, Year = (int)year });
            await _context.SaveChangesAsync();
        }
        #endregion

        // Optional mock data seed
        #region optionalSeedings
        public async Task AddTeacherRegistrationForm(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var form = new RegistrationOfInterest
                {
                    FirstName = "Lärare Lärarsson",
                    Email = "1@2.se",
                    PhoneNumber = "112",
                    School = "HeltOk-Skolan",
                    SchoolForm = SchoolForm.Grundskola,
                    Municipality = _context.Municipalities.Find(1),
                    Grade = 9,
                    MeetingType = MeetingType.Digitalt
                };
                await _context.AddAsync(form);
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddTimeSpanToTeacherRegistrationForm(int count)
        {
            var form = await _context.RegistrationOfInterests.FirstOrDefaultAsync();
            if (form == default) return;

            // Insert scheduled time
            for (int i = 0; i < count; i++)
            {
                await _context.AddAsync(new RegistrationSchedule
                {
                    Weekday = Weekday.Måndag,
                    Time = DateTime.Parse("06/24/2021 10:30"),
                    TeacherRegistrationForm = form,
                });
            }

            await _context.SaveChangesAsync();
        }
        #endregion 
    }
}
