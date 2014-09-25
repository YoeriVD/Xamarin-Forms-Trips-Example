using ReizenReview.Pages.XAML;
using Xamarin.Forms;

namespace ReizenReview.Factories
{
    public static class PageFactory
    {
        internal static Page SplashPage { get { return new NavigationPage(new SplashPageXaml()); } }

        internal static Page MainPage
        {
            get
            {
                var tripListPage = new TripListPageXaml(ViewModelFactory.TripListViewModel);
                Page mainPage = null;
                Device.OnPlatform(
                    WinPhone: () => mainPage = new CarouselPage()
                    {
                        BackgroundColor = Constants.BackgroundColor,
                        Children = 
                        { 
                            tripListPage,
                            PageFactory.TripPage,
                            PageFactory.AddReviewPage
                        }
                    },
                    Default: () => mainPage = tripListPage
                    );
                return mainPage;
            }
        }

        private static AddReviewPageXaml _addReviewPage;

        public static AddReviewPageXaml AddReviewPage
        {
            get { return _addReviewPage ?? (_addReviewPage = new AddReviewPageXaml(ViewModelFactory.AddReviewViewModel)); }
        }

        private static ContentPage _tripPage;
        internal static ContentPage TripPage
        {
            get { return _tripPage ?? (_tripPage = new TripPageXaml(ViewModelFactory.TripViewModel)); }
        }

    }
}
