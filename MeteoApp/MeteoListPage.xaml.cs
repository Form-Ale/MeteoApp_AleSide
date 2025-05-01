
namespace MeteoApp;

public partial class MeteoListPage : Shell
{
    public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

    public MeteoListPage()
	{
		InitializeComponent();
        RegisterRoutes();

        BindingContext = new MeteoListViewModel();
    }

    private void RegisterRoutes()
    {
        Routes.Add("entrydetails", typeof(MeteoItemPage));

        foreach (var item in Routes)
            Routing.RegisterRoute(item.Key, item.Value);
    }

    private void OnListItemSelected(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
    {
        if (selectionChangedEventArgs.CurrentSelection.FirstOrDefault() is Entry entry)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Entry", entry }
            };

            Shell.Current.GoToAsync("entrydetails", navigationParameter);
        }
    }

    private async void OnItemAdded(object sender, EventArgs e)
    {
         //_ = ShowPrompt("Add new city");
         await Navigation.PushAsync(new ListPage());
    }

    private async void OnMapClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapPage());
    }

    private void OnNotificationClicked(object sender, EventArgs e)
    {
        ShowPrompt("Notification handeling");
    }

    private async Task ShowPrompt(string message)
    {
        await DisplayAlert("To be implemented", message, "OK");
    }
}