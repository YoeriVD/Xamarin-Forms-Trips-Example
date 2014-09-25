using ReizenReview.ViewModels;
using Xamarin.Forms;

namespace ReizenReview.Factories
{
    internal static class ViewModelFactory
    {
        private static TripListViewModel _tripListViewModel;
        internal static TripListViewModel TripListViewModel
        {
            get
            {
                if (_tripListViewModel == null)
                {
                    _tripListViewModel = new TripListViewModel();
                    _tripListViewModel.PropertyChanged += (sender, args) =>
                    {
                        if (args.PropertyName == "SelectedTrip")
                        {
                            var selectedTrip = TripListViewModel.SelectedTrip;
                            TripViewModel.Trip = selectedTrip;
                            AddReviewViewModel.Reviews = selectedTrip.Reviews;
                        }
                    };
                }
                return _tripListViewModel;
            }
        }
        private static TripViewModel _tripViewModel;
        internal static TripViewModel TripViewModel
        {
            get
            {
                return _tripViewModel ?? (_tripViewModel = new TripViewModel());
            }
        }

        private static AddReviewViewModel _addReviewViewModel;

        internal static AddReviewViewModel AddReviewViewModel
        {
            get { return _addReviewViewModel ?? (_addReviewViewModel = new AddReviewViewModel()); }
        }
    }
}
