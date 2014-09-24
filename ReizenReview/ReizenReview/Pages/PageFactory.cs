using ReizenReview.Pages.XAML;
using Xamarin.Forms;

namespace ReizenReview.Pages
{
    public static class PageFactory
    {
        internal static Page SplashPage { get { return new NavigationPage(new SplashPageXaml()); } }

        internal static Page MainPage
        {
            get
            {
                Page mainPage = null;
                Device.OnPlatform(
                    WinPhone: () => mainPage = new CarouselPage()
                    {
                        BackgroundColor = Constants.BackgroundColor,
                        Children = 
                        { 
                            new TripListPageXaml(),
                            PageFactory.TripPage,
                            PageFactory.AddReviewPage
                        }
                    },
                    Default: () => mainPage = new TripListPageXaml()
                    );
                return mainPage;
            }
        }

        private static AddReviewPage _addReviewPage;

        public static AddReviewPage AddReviewPage
        {
            get { return _addReviewPage ?? (_addReviewPage = new AddReviewPage()); }
        }

        private static ContentPage _tripPage;
        internal static ContentPage TripPage
        {
            get { return _tripPage ?? (_tripPage = new TripPage()); }
        }

    }
}
