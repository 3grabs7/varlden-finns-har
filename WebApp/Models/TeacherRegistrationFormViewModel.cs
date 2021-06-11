﻿using DAL.TeacherRegistrationForm;
using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class TeacherRegistrationFormViewModel
    {
        public TeacherRegistrationForm Form { get; set; }
        public List<ScheduledTimeSpan> TimeSpans { get; set; }
        public bool SubmitSuccessfull { get; set; }
        public SchoolForm SchoolForm { get; set; }

    }
}
