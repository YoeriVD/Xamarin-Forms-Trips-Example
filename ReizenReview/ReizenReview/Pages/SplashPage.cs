using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReizenReview.Pages
{
    public class SplashPage : ContentPage
    {
        public SplashPage()
        {
            var image = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = ImageSource.FromResource("ReizenReview.palmtree.png")
            };
            var entry = new Entry
            {
                Placeholder = "fill in your name",
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = ""
            };
            var button = new Button
            {
                Text = "log in",
                BackgroundColor = Color.Transparent,
                TextColor = Color.White
            };
            button.Clicked += (sender, args) =>
            {
                DisplayAlert("Welcome", entry.Text, "ok");
                this.Navigation.PushAsync(PageFactory.MainPage);
            };
            var layout = new StackLayout
            {
                BackgroundColor = App.Constants.BackgroundColor,
                Children = { image, entry, button },
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            BackgroundColor = App.Constants.BackgroundColor;
            Content = new ScrollView() { Content = layout };
        }
    }
}
