using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Eksamen2025Gruppe5.Models;
using System.Collections.Generic;

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

            // Gå inn i root-elementet (array), hent første element
            var root = parsed.RootElement;
            if (root.ValueKind == JsonValueKind.Array && root.GetArrayLength() > 0)
            {
                var firstElem = root[0];
                if (firstElem.TryGetProperty("plantInfo", out var plantInfoArray))
                {
                    foreach (var plant in plantInfoArray.EnumerateArray())
                    {
                        // Bare hvis indexInfo finnes på planten
                        if (plant.TryGetProperty("indexInfo", out var indexInfo))
                        {
                            // Finn farger (kan mangle r/g/b!)
                            int r = 0, g = 0, b = 0;
                            if (indexInfo.TryGetProperty("color", out var colorObj))
                            {
                                r = colorObj.TryGetProperty("red", out var redEl) ? (int)(redEl.GetDouble() * 255) : 0;
                                g = colorObj.TryGetProperty("green", out var greenEl) ? (int)(greenEl.GetDouble() * 255) : 0;
                                b = colorObj.TryGetProperty("blue", out var blueEl) ? (int)(blueEl.GetDouble() * 255) : 0;
                            }

                            result.Add(new PollenAPIViewModel
                            {
                                Code = plant.GetProperty("code").GetString(),
                                DisplayName = plant.GetProperty("displayName").GetString(),
                                Value = indexInfo.TryGetProperty("value", out var valueEl) ? valueEl.GetInt32() : 0,
                                Category = indexInfo.TryGetProperty("category", out var catEl) ? catEl.GetString() : "",
                                IndexDescription = indexInfo.TryGetProperty("indexDescription", out var descEl) ? descEl.GetString() : "",
                                Red = r,
                                Green = g,
                                Blue = b,
                                Date = "" // Google sitt API for plantInfo har ikke dato direkte per plante
                            });
                        }
                    }
                }
            }
            return result;
        }
    }
}
