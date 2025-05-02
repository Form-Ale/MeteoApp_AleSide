using MeteoApp.Models;
using System.Web;

namespace MeteoApp;

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();

        // Carica l'HTML locale
        var htmlPath = Path.Combine(FileSystem.AppDataDirectory, "map.html");
        if (!File.Exists(htmlPath))
        {
            using var stream = FileSystem.OpenAppPackageFileAsync("map.html").Result;
            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();
            File.WriteAllText(htmlPath, content);
        }

        MapWebView.Source = new UrlWebViewSource { Url = $"file://{htmlPath}" };
    }

    private async void OnNavigating(object sender, WebNavigatingEventArgs e)
    {
        if (e.Url.StartsWith("js2csharp://"))
        {
            e.Cancel = true;
            var payload = Uri.UnescapeDataString(e.Url.Replace("js2csharp://", ""));
            var query = HttpUtility.ParseQueryString("?" + payload);

            if (double.TryParse(query.Get("lat"), out double lat) && double.TryParse(query.Get("lon"), out double lon))
            {
                var meteo = await GPSOperations.GetMeteoDataAsync(lat, lon);
                if (meteo != null)
                {
                    await DisplayAlert("Meteo cliccato",
                        $"{meteo.Name}, {meteo.Sys?.Country}\n" +
                        $"{meteo.Main.Temp}°C\n" +
                        $"{meteo.Weather?.FirstOrDefault()?.Description}\n" +
                        $"Vento: {meteo.Wind?.Speed} m/s", "OK");
                }
            }
        }
    }
}


