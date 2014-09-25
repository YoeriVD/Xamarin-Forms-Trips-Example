using System.Collections.ObjectModel;
using System.Windows.Input;
using ReizenReview.Factories;
using ReizenReview.Models;
using Xamarin.Forms;

namespace ReizenReview.ViewModels
{
    public class TripListViewModel : ViewModelBase
    {
        public ObservableCollection<Trip> Trips { get; set; }
        private Trip _selectedTrip;

        public Trip SelectedTrip
        {
            get { return _selectedTrip; }
            set
            {
                if (value == _selectedTrip) return;
                _selectedTrip = value;
                RaisePropertyChanged();
            }
        }
        public TripListViewModel()
        {
            Trips = new ObservableCollection<Trip>
            {
                new Trip() {Description = "Hotel trip all-in", Location = "Bermuda"},
                new Trip() {Description = "Camping trip", Location = "Ardennes"},
                new Trip() {Description = "City-trip", Location = "Madrid"},
                new Trip() {Description = "Roadtip", Location = "Berlin"}
            };
            foreach (var trip in Trips)
            {
                trip.Reviews.Add(new Review() { Commentary = "Splendid!", Score = 7 });
            }

        }

    }
}
