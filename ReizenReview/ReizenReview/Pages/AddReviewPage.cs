using System;
using System.Collections.ObjectModel;
using ReizenReview.Models;
using Xamarin.Forms;

namespace ReizenReview.Pages
{
    public class AddReviewPage : ContentPage
    {
        public ObservableCollection<Review> Reviews { get; set; }
        public Review NewReview { get; set; }
        public AddReviewPage()
        {
            Clear();
            BackgroundColor = Constants.BackgroundColor;
            //editor
            var editor = new Editor() {HeightRequest = 200};
            editor.SetBinding(Editor.TextProperty, "Commentary");
            //slider
            var slider = new Slider() {Minimum = 0, Maximum = 10};
            slider.SetBinding(Slider.ValueProperty, "Score", BindingMode.TwoWay);
            //trick to only allow round numbers
            slider.ValueChanged += (sender, args) => slider.Value = Math.Round(args.NewValue);
            //slidervalue
            var sliderValue = new Label() {XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, BindingContext = slider};
            sliderValue.SetBinding(Label.TextProperty, "Value", BindingMode.OneWay);
            //button
            var button = new Button() {Text = "Add"};
            button.Clicked += (sender, args) =>
            {
                Reviews.Add(NewReview);
                Clear();
                Device.OnPlatform(
                    WinPhone: () => { },
                    Default: () => this.Navigation.PopAsync());
            };

            Content = new StackLayout()
            {
                Children =
                {
                    new Label() {Text = "Review:"},
                    editor,
                    new Label() {Text = "Score:"},
                    slider,
                    sliderValue,
                    button
                }
            };
        }

        public void Clear()
        {
            NewReview = new Review(){Score = 5};
            this.BindingContext = NewReview;
        }
    }
}
