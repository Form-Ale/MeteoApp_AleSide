using System.Text.Json;
using MeteoApp.Models;

public class GPSOperations
{
    public static async Task<Coord> GetCurrentLocationAsync()
    {
        Coord meteoLocation = new Coord();
        
        try
        {
            var locationRequest = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(locationRequest);

            if (location != null)
            {
                // Traduci in placemark
                var placemarks = await Geocoding.GetPlacemarksAsync(location);
                var placemark = placemarks?.FirstOrDefault();

                meteoLocation.lat = location.Latitude;
                meteoLocation.lon = location.Longitude;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        return meteoLocation;
    }
    
    public static async Task<CurrentWeatherData?> GetMeteoDataAsync(double lat, double lon)
    {
        try
        {
            using var httpClient = new HttpClient();
            string apiKey = "e5ba032f446e37d73e6741f0a2dd2639";
            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=metric&lang=it";

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<CurrentWeatherData>(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore meteo: " + ex.Message);
        }

        return null;
    }

}