using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReizenReview.Factories;
using ReizenReview.Models;
using ReizenReview.ViewModels;
using Xamarin.Forms;

namespace ReizenReview.Pages.XAML
{
    public partial class TripListPageXaml
    {
        
        public TripListPageXaml(TripListViewModel vm)
        {
            InitializeComponent();
            vm.PropertyChanged += (sender, args) =>
            {
                Device.OnPlatform(
                    WinPhone: () => { },
                    Default: () =>
                    {
                        Navigation.PushAsync(PageFactory.TripPage);
                    });
            };
            this.BindingContext = vm;
        }

    }
}
