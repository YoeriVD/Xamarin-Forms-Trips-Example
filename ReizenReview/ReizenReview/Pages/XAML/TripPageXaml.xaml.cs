using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReizenReview.Factories;
using ReizenReview.Models;
using ReizenReview.ViewModels;
using Xamarin.Forms;

namespace ReizenReview.Pages.XAML
{
    public partial class TripPageXaml
    {

        public TripPageXaml(TripViewModel tripViewModel)
        {
            InitializeComponent();
            tripViewModel.AddCommand = new Command(() =>
            {
                var page = PageFactory.AddReviewPage;
                this.Navigation.PushAsync(page);
            });

            this.BindingContext = tripViewModel;
        }
    }
}
