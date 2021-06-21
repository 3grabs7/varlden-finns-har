﻿using DAL.Registration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IGeocodingService
    {
        Task<List<double>> GetCoordinatesAsync(Adress adress, Municipality municipality);
    }
}
