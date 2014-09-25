using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReizenReview.Models;
using Xamarin.Forms;

namespace ReizenReview.Pages.XAML
{
    public partial class TripListPageXaml
    {
        public ObservableCollection<Trip> Trips { get; set; }
        public TripListPageXaml()
        {
            InitializeComponent();
            this.Title = "Trips";
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
            tripList.ItemsSource = Trips;
        }

        public void TripListItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var page = PageFactory.TripPage as TripPageXaml;
            var trip = (Trip)args.SelectedItem;
            page.Trip = trip;
            Device.OnPlatform(
                WinPhone: () => { PageFactory.AddReviewPage.Reviews = trip.Reviews; },
                Default: () => this.Navigation.PushAsync(page));
        }
    }
}
