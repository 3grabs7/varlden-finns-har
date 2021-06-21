using DAL.Registration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class GeocodingService : IGeocodingService
    {
        private static readonly HttpClient client = new();
        private const string BASE_URL = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
        private readonly string _apiKey;
        public GeocodingService()
        {
            _apiKey = Environment.GetEnvironmentVariable("GeocodingApiKey");
        }

        public async Task<List<double>> GetCoordinatesAsync(Adress adress, Municipality municipality)
        {
            var adressQuery = $"{adress.StreetAdress} {municipality.Name} Sweden";
            var fullUrl = $"{BASE_URL}{adressQuery}.json?access_token={_apiKey}";

            var response = await client.GetStringAsync(fullUrl);

            dynamic json = JObject.Parse(response);
            var result = json.features[0].geometry.coordinates;

            return new List<double> { result[0]?.Value, result[1]?.Value } ?? null;
        }
    }
}
