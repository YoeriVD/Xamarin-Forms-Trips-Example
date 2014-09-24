using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReizenReview.Models;
using Xamarin.Forms;

namespace ReizenReview.Pages
{
    public class TripPage : ContentPage
    {
        private Trip _trip;

        public Trip Trip
        {
            set
            {
                this._trip = value;
                this.BindingContext = this._trip;
            }
        }

        public TripPage()
        {
            this.Padding = new Thickness(2, 2, 2, Device.OnPlatform<double>(2,2,10));
            this.BackgroundColor = Constants.BackgroundColor;

            this.SetBinding(TitleProperty, "Location");
            var description = new Label() { XAlign = TextAlignment.Center, YAlign = TextAlignment.Center };
            description.SetBinding(Label.TextProperty, "Description");
            var reviews = new ListView()
            {
                ItemTemplate = new DataTemplate(typeof(ReviewCell)),
                BackgroundColor = Constants.BackgroundColor,
                RowHeight = 50
            };
            reviews.SetBinding(ListView.ItemsSourceProperty, "Reviews");

            var layout = new StackLayout()
            {
                Children =
                {
                    description,
                    new StackLayout()
                        {
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            Children =
                            {
                                reviews
                            }
                        }
                  }  

            };

            Device.OnPlatform(
                WinPhone: () => { },
                Default: () =>
                {
                    var addButton = new Button()
                    {
                        Text = "add review"
                    };
                    addButton.Clicked += (sender, args) =>
                    {
                        var page = PageFactory.AddReviewPage;
                        page.Reviews = _trip.Reviews;
                        this.Navigation.PushAsync(page);
                    };
                    layout.Children.Add(addButton);
                });
            Content = layout;
        }
    }
}
