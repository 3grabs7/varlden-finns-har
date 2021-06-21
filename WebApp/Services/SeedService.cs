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
                await _context.AddAsync(new AvailableTimeSpan
                {
                    Weekday = Weekday.Måndag,
                    Time = DateTime.Parse("06/24/2021 10:30"),
                    TeacherRegistrationForm = form,
                    IsOutsideSchedule = false
                });
            }

            // Insert off schedule time
            for (int i = 0; i < count; i++)
            {
                await _context.AddAsync(new AvailableTimeSpan
                {
                    Weekday = Weekday.Måndag,
                    Time = DateTime.Parse("06/24/2021 10:30"),
                    TeacherRegistrationForm = form,
                    IsOutsideSchedule = true
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddSubjects()
        {
            _context.Subjects.Clear();

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
    }
}
