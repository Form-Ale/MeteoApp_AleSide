using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeteoApp
{
    public class MeteoListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Entry> _entries;
        private Entry _selectedCityMeteo;

        public ObservableCollection<Entry> Entries
        {
            get => _entries;
            set
            {
                if (_entries != value)
                {
                    _entries = value;
                    OnPropertyChanged();
                }
            }
        }

        public Entry SelectedCityMeteo
        {
            get => _selectedCityMeteo;
            set
            {
                if (_selectedCityMeteo != value)
                {
                    _selectedCityMeteo = value;
                    OnPropertyChanged();
                }
            }
        }

        public MeteoListViewModel()
        {
            SelectedCityMeteo = new Entry
            {
                Id = 1,
                Name = "London",
                Temperature = 10,
                Min = 10,
                Max = 30,
                Weather = "Sunny",
                Wind = 10,
                Humidity = 10,
                Icon = "sunny.png"
            };

            Entries = new ObservableCollection<Entry>();

            for (var i = 0; i < 10; i++)
            {
                var e = new Entry
                {
                    Id = i,
                    Name = "Name " + i,
                    Temperature = 20,
                    Min = 10,
                    Max = 30,
                    Weather = "Sunny",
                    Wind = 10,
                    Humidity = 50,
                    Icon = "sunny.png"
                };

                Entries.Add(e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
