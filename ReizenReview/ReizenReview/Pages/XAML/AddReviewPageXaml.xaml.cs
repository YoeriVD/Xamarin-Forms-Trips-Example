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
    public partial class AddReviewPageXaml
    {

        public ObservableCollection<Review> Reviews { get; set; }
        public Review NewReview { get; set; }

        public AddReviewPageXaml()
        {
            InitializeComponent();
            Clear();
        }

        private void SliderOnValueChanged(object sender, ValueChangedEventArgs args)
        {
            scoreSlider.Value = Math.Round(args.NewValue);
        }

        private void ButtonOnClicked(object sender, EventArgs eventArgs)
        {
            Reviews.Add(NewReview);
            Clear();
            Device.OnPlatform(
                WinPhone: () => { },
                Default: () => this.Navigation.PopAsync());
        }

        public void Clear()
        {
            NewReview = new Review() { Score = 5 };
            this.BindingContext = NewReview;
        }

    }
}
