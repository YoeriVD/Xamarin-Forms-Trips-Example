using System.Collections.ObjectModel;
using ReizenReview.Models;
using Xamarin.Forms;

namespace ReizenReview.Pages
{
    public class TripListPage : ContentPage
    {
        public ObservableCollection<Trip> Trips { get; set; } 

        public TripListPage()
        {
            this.Title = "Trips";
            Trips = new ObservableCollection<Trip>()
            {
                new Trip() {Description = "Hotel trip all-in", Location = "Bermuda"},
                new Trip() {Description = "Camping trip", Location = "Ardennes"},
                new Trip() {Description = "City-trip", Location = "Madrid"},
                new Trip() {Description = "Roadtip", Location = "Berlin"}
            };
            foreach (var trip in Trips)
            {
                trip.Reviews.Add(new Review(){Commentary = "Splendid!",Score= 7});
            }

            BackgroundColor = App.Constants.BackgroundColor;
            var cellTemplate = new DataTemplate(typeof (TripCell));
            var triplist = new ListView()
            {
                ItemsSource = Trips,
                ItemTemplate = cellTemplate,
                RowHeight = 100,
                BackgroundColor = App.Constants.BackgroundColor
            };

            triplist.ItemSelected +=
                (sender, args) =>
                {
                    var page = PageFactory.TripPage as TripPage;
                    var trip = (Trip) args.SelectedItem;
                    page.Trip = trip;
                    Device.OnPlatform(
                        WinPhone: () => { PageFactory.AddReviewPage.Reviews = trip.Reviews; },
                        Default: () => this.Navigation.PushAsync(page));
                };

            Content = triplist;
        }


        
    }
}
