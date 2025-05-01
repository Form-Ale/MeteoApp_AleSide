

namespace MeteoApp;

public partial class MapPage : ContentPage
{
    public MapPage() 
    { 
        InitializeComponent();
        var url = "https://embed.windy.com/embed2.html?lat=46.2&lon=9.0&detailLat=46.2&detailLon=9.0&width=650&height=450&zoom=8&level=surface&overlay=wind&menu=&message=true&marker=&calendar=&pressure=&type=map&location=coordinates&detail=&metricWind=default&metricTemp=default&radarRange=-1";
        WindyMap.Source = url;
    }
}
