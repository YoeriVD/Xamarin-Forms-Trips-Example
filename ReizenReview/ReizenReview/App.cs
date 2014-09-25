using ReizenReview.Factories;
using ReizenReview.Pages;
using Xamarin.Forms;

namespace ReizenReview
{
    public class App
    {
        public static Page GetMainPage()
        {
            return PageFactory.SplashPage;
        }
    }

    internal static class Constants
    {
        internal static readonly Color BackgroundColor = Color.FromRgb(51,102,153);
    }
}
