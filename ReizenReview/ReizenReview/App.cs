using ReizenReview.Pages;
using Xamarin.Forms;

namespace ReizenReview
{
    public class App
    {
        internal static class Constants
        {
            internal static readonly Color BackgroundColor = Color.FromRgb(51,102,153);
        }
        public static Page GetMainPage()
        {
            return PageFactory.SplashPage;
        }
    }
}
