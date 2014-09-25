using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReizenReview.Models;

namespace ReizenReview.Pages.XAML
{
    public partial class TripPageXaml
    {

        public TripPageXaml()
        {
            InitializeComponent();
            addButton.Clicked += (sender, args) =>
            {
                var page = PageFactory.AddReviewPage;
                page.Reviews = _trip.Reviews;
                this.Navigation.PushAsync(page);
            };
        }
        private Trip _trip;
        public Trip Trip
        {
            set
            {
                this._trip = value;
                this.BindingContext = this._trip;
            }
        }
    }
}
