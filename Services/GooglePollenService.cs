using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Eksamen2025Gruppe5.Models;
using System.Collections.Generic;
using System.Globalization;

namespace Eksamen2025Gruppe5.Services
{
    public class GooglePollenService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "AIzaSyCcJ3vf6FXeMkfgdGuJytfRuh6PQ_tDJ7U";
        private const string BaseUrl = "https://pollen.googleapis.com/v1/forecast:lookup";

        public GooglePollenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PollenAPIViewModel>> GetPollenForecastAsync()
        {
            var url = $"{BaseUrl}?location.latitude=59.26754&location.longitude=10.40762&days=5&key={ApiKey}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<PollenAPIViewModel>();

            var json = await response.Content.ReadAsStringAsync();
            var parsed = JsonDocument.Parse(json);

            var result = new List<PollenAPIViewModel>();

            // Gå gjennom dailyInfo-arrayet og hent bare BIRCH-data for hver dag
            if (parsed.RootElement.TryGetProperty("dailyInfo", out var dailyInfoArray))
            {
                foreach (var day in dailyInfoArray.EnumerateArray())
                {
                    // Hent dato (format: yyyy-mm-dd)
                    string dato = "";
                    if (day.TryGetProperty("date", out var dateObj))
                    {
                        if (dateObj.TryGetProperty("year", out var yearEl) &&
                            dateObj.TryGetProperty("month", out var monthEl) &&
                            dateObj.TryGetProperty("day", out var dayEl))
                        {
                            // Lag "dd.MM.yyyy"
                            dato = $"{dayEl.GetInt32()}.{monthEl.GetInt32()}.{yearEl.GetInt32()}";
                        }
                    }

                    // Hent plantInfo og finn BIRCH
                    if (day.TryGetProperty("plantInfo", out var plantInfoArray))
                    {
                        foreach (var plant in plantInfoArray.EnumerateArray())
                        {
                            if (plant.TryGetProperty("code", out var codeEl) && codeEl.GetString() == "BIRCH")
                            {
                                string code = codeEl.GetString() ?? "";
                                string displayName = plant.TryGetProperty("displayName", out var displayNameEl) ? displayNameEl.GetString() ?? "" : "";

                                int value = 0;
                                string category = "";
                                string description = "";
                                int r = 0, g = 0, b = 0;

                                if (plant.TryGetProperty("indexInfo", out var indexInfo))
                                {
                                    value = indexInfo.TryGetProperty("value", out var valueEl) ? valueEl.GetInt32() : 0;
                                    category = indexInfo.TryGetProperty("category", out var catEl) ? catEl.GetString() ?? "" : "";
                                    description = indexInfo.TryGetProperty("indexDescription", out var descEl) ? descEl.GetString() ?? "" : "";

                                    if (indexInfo.TryGetProperty("color", out var colorObj))
                                    {
                                        r = colorObj.TryGetProperty("red", out var redEl) ? (int)(redEl.GetDouble() * 255) : 0;
                                        g = colorObj.TryGetProperty("green", out var greenEl) ? (int)(greenEl.GetDouble() * 255) : 0;
                                        b = colorObj.TryGetProperty("blue", out var blueEl) ? (int)(blueEl.GetDouble() * 255) : 0;
                                    }
                                }

                                result.Add(new PollenAPIViewModel
                                {
                                    Date = dato,
                                    Code = code,
                                    DisplayName = displayName,
                                    Value = value,
                                    Category = category,
                                    IndexDescription = description,
                                    Red = r,
                                    Green = g,
                                    Blue = b
                                });

                                // Bare første birch per dag!
                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
