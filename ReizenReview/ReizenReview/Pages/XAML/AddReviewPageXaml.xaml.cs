using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReizenReview.Models;
using ReizenReview.ViewModels;
using Xamarin.Forms;

namespace ReizenReview.Pages.XAML
{
    public partial class AddReviewPageXaml
    {
        private readonly AddReviewViewModel _addReviewViewModel;


        public AddReviewPageXaml(AddReviewViewModel addReviewViewModel)
        {
            _addReviewViewModel = addReviewViewModel;
            _addReviewViewModel.OnFinished = () =>
            {
                Device.OnPlatform(
                    WinPhone: () => { },
                    Default: () => this.Navigation.PopAsync());
            };
            InitializeComponent();
            this.BindingContext = _addReviewViewModel;
        }


    }
}
